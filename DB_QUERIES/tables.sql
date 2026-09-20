-- =============================================
-- BUDGET EYE - TABLES SETUP
-- Run this first in SQL Server Management Studio
-- =============================================

USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'BudgetEyeDB')
BEGIN
    CREATE DATABASE BudgetEyeDB;
END
GO

USE BudgetEyeDB;
GO

-- =============================================
-- 1. USERS TABLE
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
BEGIN
    CREATE TABLE Users (
        UserId INT PRIMARY KEY,
        UserName NVARCHAR(50) NOT NULL UNIQUE,
        Password NVARCHAR(100) NOT NULL,
        Email NVARCHAR(100) NOT NULL,
        Role INT NOT NULL,
        DisplayName NVARCHAR(100) NOT NULL,
        Timestamp DATETIME NOT NULL DEFAULT GETDATE()
    );
END
GO

-- =============================================
-- 2. REQUESTS TABLE
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Requests')
BEGIN
    CREATE TABLE Requests (
        ApplicationId INT PRIMARY KEY,
        EmployeeId INT NOT NULL,
        RequestedAmount DECIMAL(18,2) NOT NULL,
        Purpose NVARCHAR(500) NOT NULL,
        Status INT NOT NULL DEFAULT 0,
        SubmittedDate DATETIME NOT NULL DEFAULT GETDATE(),
        ResolvedDate DATETIME NULL,
        ApprovedBy INT NULL,
        RequiresSenior BIT NOT NULL DEFAULT 0,
        Comments NVARCHAR(500) NULL
    );
END
GO

-- =============================================
-- 3. AUDIT LOGS TABLE
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'AuditLogs')
BEGIN
    CREATE TABLE AuditLogs (
        LogId INT PRIMARY KEY,
        ApplicationId INT NOT NULL,
        Action NVARCHAR(50) NOT NULL,
        PerformedBy INT NOT NULL,
        Timestamp DATETIME NOT NULL DEFAULT GETDATE(),
        Details NVARCHAR(500) NULL
    );
END
GO

-- =============================================
-- 4. CONFIGURATION TABLE
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Configuration')
BEGIN
    CREATE TABLE Configuration (
        ConfigId INT PRIMARY KEY,
        ThresholdAmount DECIMAL(18,2) NOT NULL,
        SetByAdminId INT NOT NULL,
        EffectiveDate DATETIME NOT NULL DEFAULT GETDATE(),
        IsActive BIT NOT NULL DEFAULT 1
    );
END
GO

-- =============================================
-- 5. DELETED USERS TABLE (Admin User Management)
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'DeletedUsers')
BEGIN
    CREATE TABLE DeletedUsers (
        UserId INT PRIMARY KEY,
        UserName NVARCHAR(50) NOT NULL,
        Password NVARCHAR(100) NOT NULL,
        Email NVARCHAR(100) NOT NULL,
        Role INT NOT NULL,
        DisplayName NVARCHAR(100) NOT NULL,
        OriginalTimestamp DATETIME NOT NULL,
        DeletionTime DATETIME NOT NULL DEFAULT GETDATE()
    );
END
GO

-- =============================================
-- 6. DELETED REQUESTS TABLE (Admin Request Management)
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'DeletedRequests')
BEGIN
    CREATE TABLE DeletedRequests (
        ApplicationId INT PRIMARY KEY,
        EmployeeId INT NOT NULL,
        RequestedAmount DECIMAL(18,2) NOT NULL,
        Purpose NVARCHAR(500) NOT NULL,
        Status INT NOT NULL,
        SubmittedDate DATETIME NOT NULL,
        ResolvedDate DATETIME NULL,
        ApprovedBy INT NULL,
        RequiresSenior BIT NOT NULL,
        Comments NVARCHAR(500) NULL,
        DeletedBy INT NOT NULL,
        DeletionTime DATETIME NOT NULL DEFAULT GETDATE()
    );
END
GO

PRINT 'All tables created successfully!';
GO