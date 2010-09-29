CREATE TABLE [Resources] (
	Id int NOT NULL identity(1,1),
	Name varchar(50) NOT NULL,
	CONSTRAINT PK_Resources PRIMARY KEY (Id),
	CONSTRAINT UQ_Resources_Name UNIQUE (Name)
)

CREATE TABLE [Resource_Docs] (
	Id int NOT NULL identity(1,1),
	ResourceId int NOT NULL,
	Language varchar(3) NULL,
	Region varchar(10) NULL,
	Summary nvarchar(1000) NOT NULL,
	CONSTRAINT PK_ResourceDocs PRIMARY KEY (Id),
	CONSTRAINT UQ_ResourceDocs_Culture UNIQUE (ResourceId, Language, Region)
)

--//@UNDO

DROP TABLE [Resource_Docs]
DROP TABLE [Resources]
