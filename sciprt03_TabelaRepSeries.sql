BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231210221834_TreinoSeries', N'7.0.4');
GO

COMMIT;
GO

