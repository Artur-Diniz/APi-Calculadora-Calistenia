﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
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

CREATE TABLE [TB_EXERCICIO] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Descricao] nvarchar(max) NOT NULL,
    [dificuldade] int NOT NULL,
    [Tipo] nvarchar(max) NOT NULL,
    [Modo] nvarchar(max) NOT NULL,
    [GpMuscular_1] int NOT NULL,
    [GpMuscular_2] int NOT NULL,
    [GpMuscular_3] int NOT NULL,
    [GpMuscular_4] int NOT NULL,
    [Exercicio_Facilitado] nvarchar(max) NULL,
    CONSTRAINT [PK_TB_EXERCICIO] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TB_TREINOS] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Descricao] nvarchar(max) NOT NULL,
    [Tipo] nvarchar(max) NOT NULL,
    [Rep_1] int NOT NULL,
    [Rep_2] int NULL,
    [Rep_3] int NULL,
    [Rep_4] int NULL,
    [Rep_5] int NULL,
    [Rep_6] int NULL,
    [Rep_7] int NULL,
    [Rep_8] int NULL,
    [Rep_9] int NULL,
    [Rep_10] int NULL,
    CONSTRAINT [PK_TB_TREINOS] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TB_REPSERIE] (
    [Id] int NOT NULL IDENTITY,
    [Repeticao] int NOT NULL,
    [Serie] int NOT NULL,
    [exercicioId] int NOT NULL,
    [treinoId] int NOT NULL,
    CONSTRAINT [PK_TB_REPSERIE] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TB_REPSERIE_TB_EXERCICIO_exercicioId] FOREIGN KEY ([exercicioId]) REFERENCES [TB_EXERCICIO] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TB_REPSERIE_TB_TREINOS_treinoId] FOREIGN KEY ([treinoId]) REFERENCES [TB_TREINOS] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descricao', N'Exercicio_Facilitado', N'GpMuscular_1', N'GpMuscular_2', N'GpMuscular_3', N'GpMuscular_4', N'Modo', N'Nome', N'Tipo', N'dificuldade') AND [object_id] = OBJECT_ID(N'[TB_EXERCICIO]'))
    SET IDENTITY_INSERT [TB_EXERCICIO] ON;
INSERT INTO [TB_EXERCICIO] ([Id], [Descricao], [Exercicio_Facilitado], [GpMuscular_1], [GpMuscular_2], [GpMuscular_3], [GpMuscular_4], [Modo], [Nome], [Tipo], [dificuldade])
VALUES (1, N' ', N'', 1, 2, 4, 0, N'Repetição', N'Flexão Padrão', N'PUSH', 2),
(2, N' ', N'', 1, 2, 4, 5, N'Repetição', N'Flexão Pike', N'PUSH', 3),
(3, N' ', N'', 10, 11, 0, 0, N'Repetição', N'Elevação de Pernas na barra', N'CORE', 3),
(4, N' ', N'', 6, 3, 0, 0, N'Repetição', N'Barra Fixa Pronada', N'PULL', 3),
(5, N' ', N'', 3, 8, 6, 0, N'Repetição', N'Barra Fixa Supinada', N'PULL', 3),
(6, N' ', N'', 9, 0, 0, 0, N'Repetição', N'Flexão Lombar', N'CORE', 2),
(7, N' ', N'', 12, 0, 0, 0, N'Repetição', N'Prancha Lateral', N'CORE', 2),
(8, N' ', N'', 15, 14, 0, 0, N'Repetição', N'Afundos', N'PERNA', 2),
(9, N' ', N'', 16, 0, 0, 0, N'Repetição', N'Elevação de Calcanhar', N'PERNA', 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descricao', N'Exercicio_Facilitado', N'GpMuscular_1', N'GpMuscular_2', N'GpMuscular_3', N'GpMuscular_4', N'Modo', N'Nome', N'Tipo', N'dificuldade') AND [object_id] = OBJECT_ID(N'[TB_EXERCICIO]'))
    SET IDENTITY_INSERT [TB_EXERCICIO] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descricao', N'Nome', N'Rep_1', N'Rep_10', N'Rep_2', N'Rep_3', N'Rep_4', N'Rep_5', N'Rep_6', N'Rep_7', N'Rep_8', N'Rep_9', N'Tipo') AND [object_id] = OBJECT_ID(N'[TB_TREINOS]'))
    SET IDENTITY_INSERT [TB_TREINOS] ON;
INSERT INTO [TB_TREINOS] ([Id], [Descricao], [Nome], [Rep_1], [Rep_10], [Rep_2], [Rep_3], [Rep_4], [Rep_5], [Rep_6], [Rep_7], [Rep_8], [Rep_9], [Tipo])
VALUES (1, N'ta potente essa perna fibrada ai meu mano', N'treino de Perna', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'PERNA');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descricao', N'Nome', N'Rep_1', N'Rep_10', N'Rep_2', N'Rep_3', N'Rep_4', N'Rep_5', N'Rep_6', N'Rep_7', N'Rep_8', N'Rep_9', N'Tipo') AND [object_id] = OBJECT_ID(N'[TB_TREINOS]'))
    SET IDENTITY_INSERT [TB_TREINOS] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Repeticao', N'Serie', N'exercicioId', N'treinoId') AND [object_id] = OBJECT_ID(N'[TB_REPSERIE]'))
    SET IDENTITY_INSERT [TB_REPSERIE] ON;
INSERT INTO [TB_REPSERIE] ([Id], [Repeticao], [Serie], [exercicioId], [treinoId])
VALUES (1, 8, 3, 9, 1),
(2, 10, 2, 9, 1),
(3, 12, 2, 9, 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Repeticao', N'Serie', N'exercicioId', N'treinoId') AND [object_id] = OBJECT_ID(N'[TB_REPSERIE]'))
    SET IDENTITY_INSERT [TB_REPSERIE] OFF;
GO

CREATE INDEX [IX_TB_REPSERIE_exercicioId] ON [TB_REPSERIE] ([exercicioId]);
GO

CREATE INDEX [IX_TB_REPSERIE_treinoId] ON [TB_REPSERIE] ([treinoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231211010732_AddBlogCreatedTimestamp', N'7.0.4');
GO

COMMIT;
GO

