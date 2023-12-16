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

BEGIN TRANSACTION;
GO

ALTER TABLE [TB_TREINOS] ADD [UsuarioId] int NULL;
GO

CREATE TABLE [TB_USUARIO] (
    [Id] int NOT NULL IDENTITY,
    [U_Name] nvarchar(max) NOT NULL,
    [PassWord_H] varbinary(max) NULL,
    [PassWord_S] varbinary(max) NULL,
    [Foto] varbinary(max) NULL,
    [Latitude] float NULL,
    [Longitude] float NULL,
    [Dt_Acesso] datetime2 NULL,
    [Perfil] nvarchar(max) NOT NULL DEFAULT N'Usuario',
    [Email] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TB_USUARIO] PRIMARY KEY ([Id])
);
GO

UPDATE [TB_TREINOS] SET [Rep_2] = 3, [UsuarioId] = NULL
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dt_Acesso', N'Email', N'Foto', N'Latitude', N'Longitude', N'PassWord_H', N'PassWord_S', N'Perfil', N'U_Name') AND [object_id] = OBJECT_ID(N'[TB_USUARIO]'))
    SET IDENTITY_INSERT [TB_USUARIO] ON;
INSERT INTO [TB_USUARIO] ([Id], [Dt_Acesso], [Email], [Foto], [Latitude], [Longitude], [PassWord_H], [PassWord_S], [Perfil], [U_Name])
VALUES (1, NULL, N'arturdiniz06@gmail.com', NULL, -23.520024100000001E0, -46.596497999999997E0, 0xA795B8AFC2E6ECA3943AF10880171565A6F4CD0A15CC1C3E61AF289DFA16CE61A7DA67CA8D6228DE1226EF5A5A57537C3B0755B35424FC24B25B11EECEBFFF51, 0x743F98DCBC40D1F7E99DFEBB04892974F49771BE24FEDACBA061030C22913A1C187DA196C74613431873F675C5A0627E64EC4C723876794C043DC6CCEFD057C2052833E3E7A1A3F6DBD93DEA0758D02383B049CF267C5175119AA1B903EBF130E9EEB6E5E19FAE67A377BEF9FD0D217EE1959064C647F6A2CEBA38AF55254E95, N'Admin', N'UsuarioAdmin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dt_Acesso', N'Email', N'Foto', N'Latitude', N'Longitude', N'PassWord_H', N'PassWord_S', N'Perfil', N'U_Name') AND [object_id] = OBJECT_ID(N'[TB_USUARIO]'))
    SET IDENTITY_INSERT [TB_USUARIO] OFF;
GO

CREATE INDEX [IX_TB_TREINOS_UsuarioId] ON [TB_TREINOS] ([UsuarioId]);
GO

ALTER TABLE [TB_TREINOS] ADD CONSTRAINT [FK_TB_TREINOS_TB_USUARIO_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [TB_USUARIO] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231213170908_InitialCreate', N'7.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [TB_USUARIO] SET [PassWord_H] = 0x44B2897EDFCA3ECCEB6DABBB6B2D7B7FE9E000085A9CF884E889B53065790C60F403145D664D8B092BCACF5EDD498D5BBC296430BE1406B68E3E9869D8C1E244, [PassWord_S] = 0x621DF64C485A45AABF7D36B84F8DB047229D355511B7AD770A684D57A4AFA2190E9072844E28F5FFE1971B103C3CAC9EFCAEE5043D0DF45DA754E6165DDDE0F43125E95470A1545E2BD350D3EF5C3EA94A4E059D67602864889BABF54849AE29D223AB0974D8490474DD199BD20894F4ACBAA70B93670ABB18618D7861A9DD08
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231213233544_Initial', N'7.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [TB_REPSERIE] DROP CONSTRAINT [FK_TB_REPSERIE_TB_TREINOS_treinoId];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_REPSERIE]') AND [c].[name] = N'treinoId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [TB_REPSERIE] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [TB_REPSERIE] ALTER COLUMN [treinoId] int NULL;
GO

UPDATE [TB_USUARIO] SET [PassWord_H] = 0x0307D93C021AE5CC233E1E89F51FA6A6B7E5C41B4693CA86E4723F7198B89AD191E70D5A8CFAE4C278CE637865FDFA1183C44637E8FB40589A5EA659C7B7BD67, [PassWord_S] = 0xE3797A7715E412A92C97C07A2C17C51A5045B387009B39026440DA8001676A5B80733CAC860AA8CB21984FDBA12E007838E5BD983F14A9E1615B06195E5CC50C955A16E59E3B3FBBA89CD7DCC939949814489081206F5FE30716E122D64ABC7DD7314F1489DEF2A68016BC3E0C26681B724F74D44B4368D0F1E93944A262E989
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

ALTER TABLE [TB_REPSERIE] ADD CONSTRAINT [FK_TB_REPSERIE_TB_TREINOS_treinoId] FOREIGN KEY ([treinoId]) REFERENCES [TB_TREINOS] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231214000353_in', N'7.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DELETE FROM [TB_EXERCICIO]
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

DELETE FROM [TB_EXERCICIO]
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

DELETE FROM [TB_EXERCICIO]
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

DELETE FROM [TB_EXERCICIO]
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

DELETE FROM [TB_EXERCICIO]
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

DELETE FROM [TB_EXERCICIO]
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

DELETE FROM [TB_EXERCICIO]
WHERE [Id] = 8;
SELECT @@ROWCOUNT;

GO

DELETE FROM [TB_REPSERIE]
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

DELETE FROM [TB_REPSERIE]
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

DELETE FROM [TB_EXERCICIO]
WHERE [Id] = 9;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_USUARIO] SET [PassWord_H] = 0x47C222B9F4B9AEF45017B1B7851E9CE8FE3838CE60BEC3ABCEC9000E6D332DADF112B9298151361230826E1FC8FF8B3DA40D43B424B8F90D4E775D86BB94A037, [PassWord_S] = 0xA7D1C981D368A4B5BC874866DD860D1CF991549078CE4FB084672D51B20C9691F61F5D8F70957010592B1D983F85A7F21D11BB8C485887D53F5CDA9FB3903483E8AECB32ED569CB16FAD0E23C224A8634C4108405AED1C2099552BE5B173BCA9D300691F5DA221D2A247B1B1CAF7371B9BC1558A8485183CBA7F7913F1B449E6
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231214041548_migracao', N'7.0.4');
GO

COMMIT;
GO

