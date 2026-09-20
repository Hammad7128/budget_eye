-- =============================================
-- BUDGET EYE - ALL STORED PROCEDURES
-- Run this AFTER running 01_Tables.sql
-- =============================================

USE BudgetEyeDB;
GO

-- =============================================
-- USER MANAGEMENT PROCEDURES
-- =============================================

CREATE OR ALTER PROCEDURE sp_GetAllUsers
AS
BEGIN
    SELECT 
        UserId,
        UserName,
        Password,
        Email,
        Role,
        DisplayName,
        Timestamp
    FROM Users
    ORDER BY UserId;
END
GO

CREATE OR ALTER PROCEDURE sp_GetDeletedUsers
AS
BEGIN
    SELECT 
        UserId,
        UserName,
        DisplayName,
        Email,
        Role,
        OriginalTimestamp,
        DeletionTime
    FROM DeletedUsers
    ORDER BY DeletionTime DESC;
END
GO

CREATE OR ALTER PROCEDURE sp_CreateUser
    @UserName NVARCHAR(50),
    @Password NVARCHAR(100),
    @Email NVARCHAR(100),
    @Role INT,
    @DisplayName NVARCHAR(100)
AS
BEGIN
    DECLARE @NewId INT;
    SELECT @NewId = ISNULL(MAX(UserId), 0) + 1 FROM Users;
    
    INSERT INTO Users (UserId, UserName, Password, Email, Role, DisplayName, Timestamp)
    VALUES (@NewId, @UserName, @Password, @Email, @Role, @DisplayName, GETDATE());
    
    SELECT @NewId AS NewUserId;
END
GO

CREATE OR ALTER PROCEDURE sp_UpdateUser
    @UserId INT,
    @UserName NVARCHAR(50),
    @Password NVARCHAR(100),
    @Email NVARCHAR(100),
    @Role INT,
    @DisplayName NVARCHAR(100)
AS
BEGIN
    UPDATE Users
    SET UserName = @UserName,
        Password = @Password,
        Email = @Email,
        Role = @Role,
        DisplayName = @DisplayName
    WHERE UserId = @UserId;
END
GO

CREATE OR ALTER PROCEDURE sp_DeleteUser
    @UserId INT
AS
BEGIN
    INSERT INTO DeletedUsers (UserId, UserName, Password, Email, Role, DisplayName, OriginalTimestamp, DeletionTime)
    SELECT UserId, UserName, Password, Email, Role, DisplayName, Timestamp, GETDATE()
    FROM Users
    WHERE UserId = @UserId;
    
    DELETE FROM Users WHERE UserId = @UserId;
END
GO

-- =============================================
-- REQUEST MANAGEMENT PROCEDURES
-- =============================================

CREATE OR ALTER PROCEDURE sp_GetAllRequests
    @StatusFilter INT = NULL
AS
BEGIN
    SELECT 
        r.ApplicationId,
        r.EmployeeId,
        u.DisplayName AS EmployeeName,
        r.RequestedAmount,
        r.Purpose,
        r.Status,
        r.SubmittedDate,
        r.ResolvedDate,
        r.ApprovedBy,
        m.DisplayName AS ApprovedByName,
        r.RequiresSenior,
        r.Comments
    FROM Requests r
    INNER JOIN Users u ON r.EmployeeId = u.UserId
    LEFT JOIN Users m ON r.ApprovedBy = m.UserId
    WHERE (@StatusFilter IS NULL 
           OR r.Status = @StatusFilter
           OR (@StatusFilter = 3 AND r.Status IN (1, 2)))
    ORDER BY r.SubmittedDate DESC;
END
GO

CREATE OR ALTER PROCEDURE sp_GetDeletedRequests
AS
BEGIN
    SELECT 
        d.ApplicationId,
        d.EmployeeId,
        u.DisplayName AS EmployeeName,
        d.RequestedAmount,
        d.Purpose,
        d.Status,
        d.SubmittedDate,
        d.ResolvedDate,
        d.Comments,
        d.DeletedBy,
        del.DisplayName AS DeletedByName,
        d.DeletionTime
    FROM DeletedRequests d
    INNER JOIN Users u ON d.EmployeeId = u.UserId
    LEFT JOIN Users del ON d.DeletedBy = del.UserId
    ORDER BY d.DeletionTime DESC;
END
GO

CREATE OR ALTER PROCEDURE sp_GetRequestAudit
    @ApplicationId INT
AS
BEGIN
    SELECT 
        a.LogId,
        a.ApplicationId,
        a.Action,
        a.PerformedBy,
        u.DisplayName AS PerformedByName,
        a.Timestamp,
        a.Details
    FROM AuditLogs a
    INNER JOIN Users u ON a.PerformedBy = u.UserId
    WHERE a.ApplicationId = @ApplicationId
    ORDER BY a.Timestamp DESC;
END
GO

CREATE OR ALTER PROCEDURE sp_DeletePendingRequest
    @ApplicationId INT,
    @DeletedBy INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Requests WHERE ApplicationId = @ApplicationId AND Status = 0)
    BEGIN
        INSERT INTO DeletedRequests (
            ApplicationId, EmployeeId, RequestedAmount, Purpose, 
            Status, SubmittedDate, ResolvedDate, ApprovedBy, 
            RequiresSenior, Comments, DeletedBy, DeletionTime
        )
        SELECT 
            ApplicationId, EmployeeId, RequestedAmount, Purpose,
            Status, SubmittedDate, ResolvedDate, ApprovedBy,
            RequiresSenior, Comments, @DeletedBy, GETDATE()
        FROM Requests
        WHERE ApplicationId = @ApplicationId;
        
        DELETE FROM Requests WHERE ApplicationId = @ApplicationId;
        
        INSERT INTO AuditLogs (LogId, ApplicationId, Action, PerformedBy, Timestamp, Details)
        VALUES (
            (SELECT ISNULL(MAX(LogId), 0) + 1 FROM AuditLogs),
            @ApplicationId,
            'Deleted',
            @DeletedBy,
            GETDATE(),
            'Request deleted by admin'
        );
        
        SELECT 1 AS Success;
    END
    ELSE
    BEGIN
        SELECT 0 AS Success;
    END
END
GO

CREATE OR ALTER PROCEDURE sp_GetRequestsByDateRange
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT 
        r.ApplicationId,
        r.EmployeeId,
        u.DisplayName AS EmployeeName,
        r.RequestedAmount,
        r.Purpose,
        r.Status,
        r.SubmittedDate,
        r.ResolvedDate,
        r.Comments
    FROM Requests r
    INNER JOIN Users u ON r.EmployeeId = u.UserId
    WHERE CAST(r.SubmittedDate AS DATE) BETWEEN @StartDate AND @EndDate
    ORDER BY r.SubmittedDate DESC;
    
    SELECT 
        COUNT(*) AS TotalRequests,
        SUM(CASE WHEN Status = 1 THEN RequestedAmount ELSE 0 END) AS TotalApprovedAmount,
        SUM(CASE WHEN Status = 0 THEN RequestedAmount ELSE 0 END) AS TotalPendingAmount,
        SUM(CASE WHEN Status = 2 THEN RequestedAmount ELSE 0 END) AS TotalDisapprovedAmount
    FROM Requests
    WHERE CAST(SubmittedDate AS DATE) BETWEEN @StartDate AND @EndDate;
END
GO

CREATE OR ALTER PROCEDURE sp_GetRequestStats
AS
BEGIN
    SELECT 
        COUNT(*) AS TotalRequests,
        SUM(CASE WHEN Status = 0 THEN 1 ELSE 0 END) AS PendingCount,
        SUM(CASE WHEN Status = 1 THEN 1 ELSE 0 END) AS ApprovedCount,
        SUM(CASE WHEN Status = 2 THEN 1 ELSE 0 END) AS DisapprovedCount,
        SUM(CASE WHEN Status = 3 THEN 1 ELSE 0 END) AS ResolvedCount,
        SUM(CASE WHEN Status = 1 THEN RequestedAmount ELSE 0 END) AS TotalApprovedAmount
    FROM Requests;
END
GO

-- =============================================
-- CONFIGURATION PROCEDURES
-- =============================================

CREATE OR ALTER PROCEDURE sp_GetAllConfigurations
AS
BEGIN
    SELECT 
        c.ConfigId,
        c.ThresholdAmount,
        c.SetByAdminId,
        u.DisplayName AS SetByName,
        c.EffectiveDate,
        c.IsActive
    FROM Configuration c
    LEFT JOIN Users u ON c.SetByAdminId = u.UserId
    ORDER BY c.EffectiveDate DESC;
END
GO

PRINT 'All stored procedures created successfully!';
GO