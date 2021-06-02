
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/01/2021 21:54:51
-- Generated from EDMX file: C:\Users\Korisnik\Desktop\New folder\Baze2\Baze2\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AerodromAvion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Avioni] DROP CONSTRAINT [FK_AerodromAvion];
GO
IF OBJECT_ID(N'[dbo].[FK_AvionCentrala]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Avioni] DROP CONSTRAINT [FK_AvionCentrala];
GO
IF OBJECT_ID(N'[dbo].[FK_AerodromKlijent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Klijenti] DROP CONSTRAINT [FK_AerodromKlijent];
GO
IF OBJECT_ID(N'[dbo].[FK_AerodromOsoblje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Osobljes] DROP CONSTRAINT [FK_AerodromOsoblje];
GO
IF OBJECT_ID(N'[dbo].[FK_Op_LetovaCentrala]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Osobljes_Op_Letova] DROP CONSTRAINT [FK_Op_LetovaCentrala];
GO
IF OBJECT_ID(N'[dbo].[FK_PilotUpravlja]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Upravljas] DROP CONSTRAINT [FK_PilotUpravlja];
GO
IF OBJECT_ID(N'[dbo].[FK_AvionUpravlja]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Upravljas] DROP CONSTRAINT [FK_AvionUpravlja];
GO
IF OBJECT_ID(N'[dbo].[FK_LetCentrala]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Letovi] DROP CONSTRAINT [FK_LetCentrala];
GO
IF OBJECT_ID(N'[dbo].[FK_AvionIzvrsava]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Izvrsavas] DROP CONSTRAINT [FK_AvionIzvrsava];
GO
IF OBJECT_ID(N'[dbo].[FK_LetIzvrsava]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Izvrsavas] DROP CONSTRAINT [FK_LetIzvrsava];
GO
IF OBJECT_ID(N'[dbo].[FK_KompanijaPoseduje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Posedujes] DROP CONSTRAINT [FK_KompanijaPoseduje];
GO
IF OBJECT_ID(N'[dbo].[FK_AvionPoseduje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Posedujes] DROP CONSTRAINT [FK_AvionPoseduje];
GO
IF OBJECT_ID(N'[dbo].[FK_KlijentPoseduje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Klijenti] DROP CONSTRAINT [FK_KlijentPoseduje];
GO
IF OBJECT_ID(N'[dbo].[FK_KlijentLet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Klijenti] DROP CONSTRAINT [FK_KlijentLet];
GO
IF OBJECT_ID(N'[dbo].[FK_Op_Letova_inherits_Osoblje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Osobljes_Op_Letova] DROP CONSTRAINT [FK_Op_Letova_inherits_Osoblje];
GO
IF OBJECT_ID(N'[dbo].[FK_Pilot_inherits_Osoblje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Osobljes_Pilot] DROP CONSTRAINT [FK_Pilot_inherits_Osoblje];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Aerodromi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Aerodromi];
GO
IF OBJECT_ID(N'[dbo].[Avioni]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Avioni];
GO
IF OBJECT_ID(N'[dbo].[Centrale]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Centrale];
GO
IF OBJECT_ID(N'[dbo].[Klijenti]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Klijenti];
GO
IF OBJECT_ID(N'[dbo].[Osobljes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Osobljes];
GO
IF OBJECT_ID(N'[dbo].[Upravljas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Upravljas];
GO
IF OBJECT_ID(N'[dbo].[Letovi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Letovi];
GO
IF OBJECT_ID(N'[dbo].[Izvrsavas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Izvrsavas];
GO
IF OBJECT_ID(N'[dbo].[Kompanije]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kompanije];
GO
IF OBJECT_ID(N'[dbo].[Posedujes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Posedujes];
GO
IF OBJECT_ID(N'[dbo].[Osobljes_Op_Letova]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Osobljes_Op_Letova];
GO
IF OBJECT_ID(N'[dbo].[Osobljes_Pilot]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Osobljes_Pilot];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Aerodromi'
CREATE TABLE [dbo].[Aerodromi] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [Adresa] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Avioni'
CREATE TABLE [dbo].[Avioni] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BrojMesta] nvarchar(max)  NOT NULL,
    [AerodromId] int  NOT NULL,
    [CentralaId] int  NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Centrale'
CREATE TABLE [dbo].[Centrale] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Klijenti'
CREATE TABLE [dbo].[Klijenti] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [AerodromId] int  NOT NULL,
    [PosedujeKompanijaId] int  NOT NULL,
    [PosedujeAvionId] int  NOT NULL,
    [LetId] int  NOT NULL
);
GO

-- Creating table 'Osobljes'
CREATE TABLE [dbo].[Osobljes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [AerodromId] int  NOT NULL
);
GO

-- Creating table 'Upravljas'
CREATE TABLE [dbo].[Upravljas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PilotId] int  NOT NULL,
    [AvionId] int  NOT NULL
);
GO

-- Creating table 'Letovi'
CREATE TABLE [dbo].[Letovi] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Datum] nvarchar(max)  NOT NULL,
    [Vreme] nvarchar(max)  NOT NULL,
    [Destinacija] nvarchar(max)  NOT NULL,
    [MestoPolaska] nvarchar(max)  NOT NULL,
    [CentralaId] int  NOT NULL
);
GO

-- Creating table 'Izvrsavas'
CREATE TABLE [dbo].[Izvrsavas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AvionId] int  NOT NULL,
    [LetId] int  NOT NULL
);
GO

-- Creating table 'Kompanije'
CREATE TABLE [dbo].[Kompanije] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Posedujes'
CREATE TABLE [dbo].[Posedujes] (
    [KompanijaId] int  NOT NULL,
    [AvionId] int  NOT NULL
);
GO

-- Creating table 'Osobljes_Op_Letova'
CREATE TABLE [dbo].[Osobljes_Op_Letova] (
    [CentralaId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Osobljes_Pilot'
CREATE TABLE [dbo].[Osobljes_Pilot] (
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Aerodromi'
ALTER TABLE [dbo].[Aerodromi]
ADD CONSTRAINT [PK_Aerodromi]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Avioni'
ALTER TABLE [dbo].[Avioni]
ADD CONSTRAINT [PK_Avioni]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Centrale'
ALTER TABLE [dbo].[Centrale]
ADD CONSTRAINT [PK_Centrale]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Klijenti'
ALTER TABLE [dbo].[Klijenti]
ADD CONSTRAINT [PK_Klijenti]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Osobljes'
ALTER TABLE [dbo].[Osobljes]
ADD CONSTRAINT [PK_Osobljes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Upravljas'
ALTER TABLE [dbo].[Upravljas]
ADD CONSTRAINT [PK_Upravljas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Letovi'
ALTER TABLE [dbo].[Letovi]
ADD CONSTRAINT [PK_Letovi]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Izvrsavas'
ALTER TABLE [dbo].[Izvrsavas]
ADD CONSTRAINT [PK_Izvrsavas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Kompanije'
ALTER TABLE [dbo].[Kompanije]
ADD CONSTRAINT [PK_Kompanije]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [KompanijaId], [AvionId] in table 'Posedujes'
ALTER TABLE [dbo].[Posedujes]
ADD CONSTRAINT [PK_Posedujes]
    PRIMARY KEY CLUSTERED ([KompanijaId], [AvionId] ASC);
GO

-- Creating primary key on [Id] in table 'Osobljes_Op_Letova'
ALTER TABLE [dbo].[Osobljes_Op_Letova]
ADD CONSTRAINT [PK_Osobljes_Op_Letova]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Osobljes_Pilot'
ALTER TABLE [dbo].[Osobljes_Pilot]
ADD CONSTRAINT [PK_Osobljes_Pilot]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AerodromId] in table 'Avioni'
ALTER TABLE [dbo].[Avioni]
ADD CONSTRAINT [FK_AerodromAvion]
    FOREIGN KEY ([AerodromId])
    REFERENCES [dbo].[Aerodromi]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AerodromAvion'
CREATE INDEX [IX_FK_AerodromAvion]
ON [dbo].[Avioni]
    ([AerodromId]);
GO

-- Creating foreign key on [CentralaId] in table 'Avioni'
ALTER TABLE [dbo].[Avioni]
ADD CONSTRAINT [FK_AvionCentrala]
    FOREIGN KEY ([CentralaId])
    REFERENCES [dbo].[Centrale]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AvionCentrala'
CREATE INDEX [IX_FK_AvionCentrala]
ON [dbo].[Avioni]
    ([CentralaId]);
GO

-- Creating foreign key on [AerodromId] in table 'Klijenti'
ALTER TABLE [dbo].[Klijenti]
ADD CONSTRAINT [FK_AerodromKlijent]
    FOREIGN KEY ([AerodromId])
    REFERENCES [dbo].[Aerodromi]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AerodromKlijent'
CREATE INDEX [IX_FK_AerodromKlijent]
ON [dbo].[Klijenti]
    ([AerodromId]);
GO

-- Creating foreign key on [AerodromId] in table 'Osobljes'
ALTER TABLE [dbo].[Osobljes]
ADD CONSTRAINT [FK_AerodromOsoblje]
    FOREIGN KEY ([AerodromId])
    REFERENCES [dbo].[Aerodromi]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AerodromOsoblje'
CREATE INDEX [IX_FK_AerodromOsoblje]
ON [dbo].[Osobljes]
    ([AerodromId]);
GO

-- Creating foreign key on [CentralaId] in table 'Osobljes_Op_Letova'
ALTER TABLE [dbo].[Osobljes_Op_Letova]
ADD CONSTRAINT [FK_Op_LetovaCentrala]
    FOREIGN KEY ([CentralaId])
    REFERENCES [dbo].[Centrale]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Op_LetovaCentrala'
CREATE INDEX [IX_FK_Op_LetovaCentrala]
ON [dbo].[Osobljes_Op_Letova]
    ([CentralaId]);
GO

-- Creating foreign key on [PilotId] in table 'Upravljas'
ALTER TABLE [dbo].[Upravljas]
ADD CONSTRAINT [FK_PilotUpravlja]
    FOREIGN KEY ([PilotId])
    REFERENCES [dbo].[Osobljes_Pilot]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PilotUpravlja'
CREATE INDEX [IX_FK_PilotUpravlja]
ON [dbo].[Upravljas]
    ([PilotId]);
GO

-- Creating foreign key on [AvionId] in table 'Upravljas'
ALTER TABLE [dbo].[Upravljas]
ADD CONSTRAINT [FK_AvionUpravlja]
    FOREIGN KEY ([AvionId])
    REFERENCES [dbo].[Avioni]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AvionUpravlja'
CREATE INDEX [IX_FK_AvionUpravlja]
ON [dbo].[Upravljas]
    ([AvionId]);
GO

-- Creating foreign key on [CentralaId] in table 'Letovi'
ALTER TABLE [dbo].[Letovi]
ADD CONSTRAINT [FK_LetCentrala]
    FOREIGN KEY ([CentralaId])
    REFERENCES [dbo].[Centrale]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LetCentrala'
CREATE INDEX [IX_FK_LetCentrala]
ON [dbo].[Letovi]
    ([CentralaId]);
GO

-- Creating foreign key on [AvionId] in table 'Izvrsavas'
ALTER TABLE [dbo].[Izvrsavas]
ADD CONSTRAINT [FK_AvionIzvrsava]
    FOREIGN KEY ([AvionId])
    REFERENCES [dbo].[Avioni]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AvionIzvrsava'
CREATE INDEX [IX_FK_AvionIzvrsava]
ON [dbo].[Izvrsavas]
    ([AvionId]);
GO

-- Creating foreign key on [LetId] in table 'Izvrsavas'
ALTER TABLE [dbo].[Izvrsavas]
ADD CONSTRAINT [FK_LetIzvrsava]
    FOREIGN KEY ([LetId])
    REFERENCES [dbo].[Letovi]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LetIzvrsava'
CREATE INDEX [IX_FK_LetIzvrsava]
ON [dbo].[Izvrsavas]
    ([LetId]);
GO

-- Creating foreign key on [KompanijaId] in table 'Posedujes'
ALTER TABLE [dbo].[Posedujes]
ADD CONSTRAINT [FK_KompanijaPoseduje]
    FOREIGN KEY ([KompanijaId])
    REFERENCES [dbo].[Kompanije]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AvionId] in table 'Posedujes'
ALTER TABLE [dbo].[Posedujes]
ADD CONSTRAINT [FK_AvionPoseduje]
    FOREIGN KEY ([AvionId])
    REFERENCES [dbo].[Avioni]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AvionPoseduje'
CREATE INDEX [IX_FK_AvionPoseduje]
ON [dbo].[Posedujes]
    ([AvionId]);
GO

-- Creating foreign key on [PosedujeKompanijaId], [PosedujeAvionId] in table 'Klijenti'
ALTER TABLE [dbo].[Klijenti]
ADD CONSTRAINT [FK_KlijentPoseduje]
    FOREIGN KEY ([PosedujeKompanijaId], [PosedujeAvionId])
    REFERENCES [dbo].[Posedujes]
        ([KompanijaId], [AvionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KlijentPoseduje'
CREATE INDEX [IX_FK_KlijentPoseduje]
ON [dbo].[Klijenti]
    ([PosedujeKompanijaId], [PosedujeAvionId]);
GO

-- Creating foreign key on [LetId] in table 'Klijenti'
ALTER TABLE [dbo].[Klijenti]
ADD CONSTRAINT [FK_KlijentLet]
    FOREIGN KEY ([LetId])
    REFERENCES [dbo].[Letovi]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KlijentLet'
CREATE INDEX [IX_FK_KlijentLet]
ON [dbo].[Klijenti]
    ([LetId]);
GO

-- Creating foreign key on [Id] in table 'Osobljes_Op_Letova'
ALTER TABLE [dbo].[Osobljes_Op_Letova]
ADD CONSTRAINT [FK_Op_Letova_inherits_Osoblje]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Osobljes]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Osobljes_Pilot'
ALTER TABLE [dbo].[Osobljes_Pilot]
ADD CONSTRAINT [FK_Pilot_inherits_Osoblje]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Osobljes]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------