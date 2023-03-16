IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ToDoList')
BEGIN
	Create Database ToDoListDB;
END
GO

USE ToDoListDB;
GO

IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE name = '[Status]' and xtype = 'U')
BEGIN
	Create table [Status](
		Id int primary key identity (1,1) Not Null,
		StatusTask varchar(20) Not Null,
)

END
GO

IF NOT EXISTS (SELECT * FROM sys.sysobjects WHERE name = 'Tasks' and xtype = 'U')
BEGIN
	Create table Tasks(
		Id int primary key identity (1,1) Not Null,
		[Description] varchar(40) Not Null,
		FinishDate datetime Not Null,
		IdStatus int Not Null,
		CONSTRAINT FKStatus FOREIGN KEY (IdStatus) REFERENCES [Status](Id)
	);

END
GO

IF NOT EXISTS (SELECT * FROM [Status] WHERE StatusTask = 'Pendiente')
BEGIN
	INSERT INTO [Status] (StatusTask) VALUES ('Pendiente');
END

IF NOT EXISTS (SELECT * FROM [Status] WHERE StatusTask = 'Terminada')
BEGIN
	INSERT INTO [Status] (StatusTask) VALUES ('Terminada');
END
GO




