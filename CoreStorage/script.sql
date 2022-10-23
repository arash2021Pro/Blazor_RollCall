IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Licenses] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [LegalCode] nvarchar(max) NULL,
    [ConstPhone] nvarchar(max) NULL,
    [CompanyName] nvarchar(max) NULL,
    [CompanyAddress] nvarchar(max) NULL,
    [SoftwareType] int NOT NULL,
    [Expiration] datetime2 NULL,
    [IsSmsPanelActive] bit NOT NULL,
    [IsMobileVersionActive] bit NOT NULL,
    [ClientCount] int NOT NULL,
    [AppSerialCount] int NOT NULL,
    [IsActive] bit NOT NULL,
    [LicenseCode] nvarchar(max) NULL,
    [IsOtpConfirmed] bit NOT NULL,
    [CreationTime] datetime2 NOT NULL,
    [ModificationTime] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Licenses] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [UserName] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    [IsAdmin] bit NOT NULL,
    [CreationTime] datetime2 NOT NULL,
    [ModificationTime] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Clients] (
    [Id] int NOT NULL IDENTITY,
    [LicenseSerial] nvarchar(max) NULL,
    [SystemSerial] nvarchar(max) NULL,
    [LicenseId] int NOT NULL,
    [CreationTime] datetime2 NOT NULL,
    [ModificationTime] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Clients_Licenses_LicenseId] FOREIGN KEY ([LicenseId]) REFERENCES [Licenses] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Otps] (
    [Id] int NOT NULL IDENTITY,
    [LicenseId] int NOT NULL,
    [Code] nvarchar(max) NULL,
    [IsUsed] bit NOT NULL,
    [ExpireTime] datetimeoffset NOT NULL,
    [CreationTime] datetime2 NOT NULL,
    [ModificationTime] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Otps] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Otps_Licenses_LicenseId] FOREIGN KEY ([LicenseId]) REFERENCES [Licenses] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Clients_LicenseId] ON [Clients] ([LicenseId]);
GO

CREATE INDEX [IX_Otps_LicenseId] ON [Otps] ([LicenseId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221021093648_init', N'6.0.9');
GO

COMMIT;
GO

