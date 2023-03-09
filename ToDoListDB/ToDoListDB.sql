Create Database ToDoListDB

Create table Tasks(
Id int primary key identity (1,1) Not Null,
[Description] varchar(40) Not Null,
FinishDate datetime Not Null,
)

Create table [Status](
Id int primary key identity (1,1) Not Null,
[Status] varchar(20) Not Null,
)

ALTER TABLE Tasks 
ADD IdStatus int Not Null;







