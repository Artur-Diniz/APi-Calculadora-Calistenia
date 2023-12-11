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

CREATE TABLE [TB_EXERCICIO] (
    [exercicioId] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Descricao] nvarchar(max) NOT NULL,
    [dificuldade] int NOT NULL,
    [Tipo] nvarchar(max) NOT NULL,
    [Modo] nvarchar(max) NOT NULL,
    [GpMuscular_1] int NOT NULL,
    [GpMuscular_2] int NOT NULL,
    [GpMuscular_3] int NOT NULL,
    [GpMuscular_4] int NOT NULL,
    [exercicio_Facilitado] nvarchar(max) NULL,
    CONSTRAINT [PK_TB_EXERCICIO] PRIMARY KEY ([exercicioId])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'exercicioId', N'Descricao', N'GpMuscular_1', N'GpMuscular_2', N'GpMuscular_3', N'GpMuscular_4', N'Modo', N'Nome', N'Tipo', N'dificuldade', N'exercicio_Facilitado') AND [object_id] = OBJECT_ID(N'[TB_EXERCICIO]'))
    SET IDENTITY_INSERT [TB_EXERCICIO] ON;
INSERT INTO [TB_EXERCICIO] ([exercicioId], [Descricao], [GpMuscular_1], [GpMuscular_2], [GpMuscular_3], [GpMuscular_4], [Modo], [Nome], [Tipo], [dificuldade], [exercicio_Facilitado])
VALUES (1, N' ', 1, 2, 4, 0, N'Repetição', N'Flexão Padrão', N'PUSH', 2, N''),
(2, N' ', 1, 2, 4, 5, N'Repetição', N'Flexão Pike', N'PUSH', 3, N''),
(3, N' ', 10, 11, 0, 0, N'Repetição', N'Elevação de Pernas na barra', N'CORE', 3, N''),
(4, N' ', 6, 3, 0, 0, N'Repetição', N'Barra Fixa Pronada', N'PULL', 3, N''),
(5, N' ', 3, 8, 6, 0, N'Repetição', N'Barra Fixa Supinada', N'PULL', 3, N''),
(6, N' ', 9, 0, 0, 0, N'Repetição', N'Flexão Lombar', N'CORE', 2, N''),
(7, N' ', 12, 0, 0, 0, N'Repetição', N'Prancha Lateral', N'CORE', 2, N''),
(8, N' ', 15, 14, 0, 0, N'Repetição', N'Afundos', N'PERNA', 2, N''),
(9, N' ', 16, 0, 0, 0, N'Repetição', N'Elevação de Calcanhar', N'PERNA', 2, N'');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'exercicioId', N'Descricao', N'GpMuscular_1', N'GpMuscular_2', N'GpMuscular_3', N'GpMuscular_4', N'Modo', N'Nome', N'Tipo', N'dificuldade', N'exercicio_Facilitado') AND [object_id] = OBJECT_ID(N'[TB_EXERCICIO]'))
    SET IDENTITY_INSERT [TB_EXERCICIO] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231210050335_InitialCreate', N'7.0.4');
GO

COMMIT;
GO

