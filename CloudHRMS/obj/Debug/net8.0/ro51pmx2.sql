BEGIN TRANSACTION;
GO

CREATE TABLE [AttendanceMaster] (
    [Id] nvarchar(450) NOT NULL,
    [AttendanceDate] datetime2 NOT NULL,
    [InTime] time NOT NULL,
    [OutTime] time NOT NULL,
    [IsLate] bit NOT NULL,
    [IsEarlyOut] bit NOT NULL,
    [IsLeave] bit NOT NULL,
    [EmployeeId] nvarchar(450) NOT NULL,
    [DepartmentId] nvarchar(450) NOT NULL,
    [ShiftId] nvarchar(450) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [ModifiedAt] datetime2 NOT NULL,
    [IpAddress] nvarchar(max) NOT NULL,
    [IsInActive] bit NOT NULL,
    CONSTRAINT [PK_AttendanceMaster] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AttendanceMaster_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Department] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AttendanceMaster_Employee_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employee] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AttendanceMaster_Shift_ShiftId] FOREIGN KEY ([ShiftId]) REFERENCES [Shift] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Payroll] (
    [Id] nvarchar(450) NOT NULL,
    [FromDate] datetime2 NOT NULL,
    [ToDate] datetime2 NOT NULL,
    [IncomeTax] decimal(18,2) NOT NULL,
    [GrossPay] decimal(18,2) NOT NULL,
    [NetPay] decimal(18,2) NOT NULL,
    [Allowance] decimal(18,2) NOT NULL,
    [Deduction] decimal(18,2) NOT NULL,
    [AttendanceDays] decimal(18,2) NOT NULL,
    [AttendanceDeduction] decimal(18,2) NOT NULL,
    [EmployeeId] nvarchar(450) NOT NULL,
    [DepartmentId] nvarchar(450) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [ModifiedAt] datetime2 NOT NULL,
    [IpAddress] nvarchar(max) NOT NULL,
    [IsInActive] bit NOT NULL,
    CONSTRAINT [PK_Payroll] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Payroll_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Department] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payroll_Employee_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employee] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_AttendanceMaster_DepartmentId] ON [AttendanceMaster] ([DepartmentId]);
GO

CREATE INDEX [IX_AttendanceMaster_EmployeeId] ON [AttendanceMaster] ([EmployeeId]);
GO

CREATE INDEX [IX_AttendanceMaster_ShiftId] ON [AttendanceMaster] ([ShiftId]);
GO

CREATE INDEX [IX_Payroll_DepartmentId] ON [Payroll] ([DepartmentId]);
GO

CREATE INDEX [IX_Payroll_EmployeeId] ON [Payroll] ([EmployeeId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240721063503_AttendancemasterAndPayroll', N'8.0.6');
GO

COMMIT;
GO

