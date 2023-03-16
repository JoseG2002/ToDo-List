USE ToDoListDB
GO

DECLARE @StatusPendienteId INT;
SELECT TOP 1 @StatusPendienteId = Id FROM [Status] WHERE StatusTask = 'Pendiente';

DECLARE @StatusTerminadaId INT;
SELECT TOP 1 @StatusTerminadaId = Id FROM [Status] WHERE StatusTask = 'Terminada';

IF NOT EXISTS (SELECT * FROM Tasks WHERE [Description] = 'Estudiar')
BEGIN
	INSERT INTO Tasks([Description], FinishDate, IdStatus) VALUES ('Estudiar', '2023-03-16 12:00:00.000', @StatusPendienteId);
END
DECLARE @TaskId1 INT;
SELECT TOP 1 @TaskId1 = Id FROM Tasks WHERE [Description] = 'Estudiar';

IF NOT EXISTS (SELECT * FROM Tasks WHERE [Description] = 'Jugar')
BEGIN
	INSERT INTO Tasks([Description], FinishDate, IdStatus) VALUES ('Jugar', '2023-03-13 12:00:00.000', @StatusTerminadaId);
END
DECLARE @TaskId2 INT;
SELECT TOP 1 @TaskId2 = Id FROM Tasks WHERE [Description] = 'Jugar';