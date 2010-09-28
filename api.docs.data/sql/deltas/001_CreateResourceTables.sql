CREATE TABLE [Resource] (
	Id int NOT NULL identity(1,1) PRIMARY KEY,
	Name varchar(50) NOT NULL,
	CONSTRAINT UQ_Resource_Name UNIQUE (Name)
)

CREATE TABLE [ResourceDoc] (
	Id int NOT NULL identity(1,1) PRIMARY KEY,
	ResourceId int NOT NULL,
	Language char(3) NULL,
	Region char(3) NULL,
	Summary nvarchar(1000) NOT NULL,
	CONSTRAINT UQ_ResourceDoc_Culture UNIQUE (ResourceId, Language, Region)
)

--//@UNDO

DROP TABLE [ResourceDoc]
DROP TABLE [Resource]
