
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/27/2024 21:31:55
-- Generated from EDMX file: D:\universidad\2024\semestre I\Porgramación en Base de Datos\AdministadorDeTareasSln\CapaDato\Models\AppDbContext.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AdministradorDeTareas];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Correo] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Prioridades'
CREATE TABLE [dbo].[Prioridades] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Clase] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Estados'
CREATE TABLE [dbo].[Estados] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Clase] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Categorias'
CREATE TABLE [dbo].[Categorias] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Comentarios'
CREATE TABLE [dbo].[Comentarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ComentarioTxt] nvarchar(max)  NOT NULL,
    [FechaComentario] nvarchar(max)  NOT NULL,
    [UsuarioId] int  NOT NULL,
    [TareaId] int  NOT NULL
);
GO

-- Creating table 'Tareas'
CREATE TABLE [dbo].[Tareas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titulo] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [FechaCreacion] nvarchar(max)  NOT NULL,
    [FechaEstimadaEntrega] nvarchar(max)  NOT NULL,
    [PrioridadId] int  NOT NULL,
    [EstadoId] int  NOT NULL,
    [CategoriaId] int  NOT NULL,
    [UsuarioPropietarioId] int  NOT NULL,
    [UsuarioAsignadoId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Prioridades'
ALTER TABLE [dbo].[Prioridades]
ADD CONSTRAINT [PK_Prioridades]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Estados'
ALTER TABLE [dbo].[Estados]
ADD CONSTRAINT [PK_Estados]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categorias'
ALTER TABLE [dbo].[Categorias]
ADD CONSTRAINT [PK_Categorias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comentarios'
ALTER TABLE [dbo].[Comentarios]
ADD CONSTRAINT [PK_Comentarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tareas'
ALTER TABLE [dbo].[Tareas]
ADD CONSTRAINT [PK_Tareas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UsuarioId] in table 'Comentarios'
ALTER TABLE [dbo].[Comentarios]
ADD CONSTRAINT [FK_UsuarioComentario]
    FOREIGN KEY ([UsuarioId])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioComentario'
CREATE INDEX [IX_FK_UsuarioComentario]
ON [dbo].[Comentarios]
    ([UsuarioId]);
GO

-- Creating foreign key on [PrioridadId] in table 'Tareas'
ALTER TABLE [dbo].[Tareas]
ADD CONSTRAINT [FK_PrioridadTarea]
    FOREIGN KEY ([PrioridadId])
    REFERENCES [dbo].[Prioridades]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PrioridadTarea'
CREATE INDEX [IX_FK_PrioridadTarea]
ON [dbo].[Tareas]
    ([PrioridadId]);
GO

-- Creating foreign key on [EstadoId] in table 'Tareas'
ALTER TABLE [dbo].[Tareas]
ADD CONSTRAINT [FK_EstadoTarea]
    FOREIGN KEY ([EstadoId])
    REFERENCES [dbo].[Estados]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstadoTarea'
CREATE INDEX [IX_FK_EstadoTarea]
ON [dbo].[Tareas]
    ([EstadoId]);
GO

-- Creating foreign key on [CategoriaId] in table 'Tareas'
ALTER TABLE [dbo].[Tareas]
ADD CONSTRAINT [FK_CategoriaTarea]
    FOREIGN KEY ([CategoriaId])
    REFERENCES [dbo].[Categorias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriaTarea'
CREATE INDEX [IX_FK_CategoriaTarea]
ON [dbo].[Tareas]
    ([CategoriaId]);
GO

-- Creating foreign key on [TareaId] in table 'Comentarios'
ALTER TABLE [dbo].[Comentarios]
ADD CONSTRAINT [FK_TareaComentario]
    FOREIGN KEY ([TareaId])
    REFERENCES [dbo].[Tareas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TareaComentario'
CREATE INDEX [IX_FK_TareaComentario]
ON [dbo].[Comentarios]
    ([TareaId]);
GO

-- Creating foreign key on [UsuarioPropietarioId] in table 'Tareas'
ALTER TABLE [dbo].[Tareas]
ADD CONSTRAINT [FK_UsuarioTarea]
    FOREIGN KEY ([UsuarioPropietarioId])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioTarea'
CREATE INDEX [IX_FK_UsuarioTarea]
ON [dbo].[Tareas]
    ([UsuarioPropietarioId]);
GO

-- Creating foreign key on [UsuarioAsignadoId] in table 'Tareas'
ALTER TABLE [dbo].[Tareas]
ADD CONSTRAINT [FK_UsuarioTarea1]
    FOREIGN KEY ([UsuarioAsignadoId])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioTarea1'
CREATE INDEX [IX_FK_UsuarioTarea1]
ON [dbo].[Tareas]
    ([UsuarioAsignadoId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------