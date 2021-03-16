
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/16/2021 12:14:16
-- Generated from EDMX file: C:\Users\prijitha.ezhava\Documents\Gateway-Projects\WebApi Assignment\HMS.WebApi\HMS.DAL\Database\DB_HMS.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DB_HMS];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__tbl_Booking__rID__07F6335A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_Bookings] DROP CONSTRAINT [FK__tbl_Booking__rID__07F6335A];
GO
IF OBJECT_ID(N'[dbo].[FK__tbl_Rooms__hID__03317E3D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbl_Rooms] DROP CONSTRAINT [FK__tbl_Rooms__hID__03317E3D];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[tbl_Bookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_Bookings];
GO
IF OBJECT_ID(N'[dbo].[tbl_Hotels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_Hotels];
GO
IF OBJECT_ID(N'[dbo].[tbl_Rooms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_Rooms];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'tbl_Bookings'
CREATE TABLE [dbo].[tbl_Bookings] (
    [bID] int  NOT NULL,
    [bDate] datetime  NOT NULL,
    [bStatus] nvarchar(50)  NOT NULL,
    [rID] int  NULL
);
GO

-- Creating table 'tbl_Hotels'
CREATE TABLE [dbo].[tbl_Hotels] (
    [hID] int IDENTITY(1,1) NOT NULL,
    [hName] nvarchar(50)  NOT NULL,
    [hAddress] nvarchar(50)  NOT NULL,
    [hCity] nvarchar(50)  NOT NULL,
    [hPincode] int  NOT NULL,
    [hContactNumber] nvarchar(50)  NOT NULL,
    [hContactPerson] nvarchar(50)  NOT NULL,
    [hWebsite] nvarchar(50)  NOT NULL,
    [hFacebook] nvarchar(50)  NOT NULL,
    [hTwitter] nvarchar(50)  NOT NULL,
    [hIsActive] bit  NOT NULL,
    [hCreatedDate] datetime  NOT NULL,
    [hCreatedBy] nvarchar(50)  NOT NULL,
    [hUpdatedDate] datetime  NOT NULL,
    [hUpdatedBy] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'tbl_Rooms'
CREATE TABLE [dbo].[tbl_Rooms] (
    [rID] int IDENTITY(1,1) NOT NULL,
    [rName] nvarchar(50)  NOT NULL,
    [rCategory] nvarchar(50)  NOT NULL,
    [rPrice] float  NOT NULL,
    [rIsActive] bit  NOT NULL,
    [rCreatedDate] datetime  NOT NULL,
    [rCreatedBy] nvarchar(50)  NOT NULL,
    [rUpdatedDate] datetime  NOT NULL,
    [rUpdatedBy] nvarchar(50)  NOT NULL,
    [hID] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [bID] in table 'tbl_Bookings'
ALTER TABLE [dbo].[tbl_Bookings]
ADD CONSTRAINT [PK_tbl_Bookings]
    PRIMARY KEY CLUSTERED ([bID] ASC);
GO

-- Creating primary key on [hID] in table 'tbl_Hotels'
ALTER TABLE [dbo].[tbl_Hotels]
ADD CONSTRAINT [PK_tbl_Hotels]
    PRIMARY KEY CLUSTERED ([hID] ASC);
GO

-- Creating primary key on [rID] in table 'tbl_Rooms'
ALTER TABLE [dbo].[tbl_Rooms]
ADD CONSTRAINT [PK_tbl_Rooms]
    PRIMARY KEY CLUSTERED ([rID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [rID] in table 'tbl_Bookings'
ALTER TABLE [dbo].[tbl_Bookings]
ADD CONSTRAINT [FK__tbl_Booking__rID__07F6335A]
    FOREIGN KEY ([rID])
    REFERENCES [dbo].[tbl_Rooms]
        ([rID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbl_Booking__rID__07F6335A'
CREATE INDEX [IX_FK__tbl_Booking__rID__07F6335A]
ON [dbo].[tbl_Bookings]
    ([rID]);
GO

-- Creating foreign key on [hID] in table 'tbl_Rooms'
ALTER TABLE [dbo].[tbl_Rooms]
ADD CONSTRAINT [FK__tbl_Rooms__hID__03317E3D]
    FOREIGN KEY ([hID])
    REFERENCES [dbo].[tbl_Hotels]
        ([hID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tbl_Rooms__hID__03317E3D'
CREATE INDEX [IX_FK__tbl_Rooms__hID__03317E3D]
ON [dbo].[tbl_Rooms]
    ([hID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------