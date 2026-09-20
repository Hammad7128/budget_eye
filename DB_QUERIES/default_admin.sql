USE BudgetEyeDB;
GO

-- Default admin user
IF NOT EXISTS (SELECT 1 FROM Users WHERE UserName = 'admin')
BEGIN
    INSERT INTO Users (UserId, UserName, Password, Email, Role, DisplayName, Timestamp)
    VALUES (1, 'admin', 'admin123', 'admin@budgeteye.com', 0, 'System Administrator', GETDATE());
END
GO

-- Default threshold
IF NOT EXISTS (SELECT 1 FROM Configuration)
BEGIN
    INSERT INTO Configuration (ConfigId, ThresholdAmount, SetByAdminId, EffectiveDate, IsActive)
    VALUES (1, 10000.00, 1, GETDATE(), 1);
END
GO

PRINT 'Seed data inserted successfully!';
GO