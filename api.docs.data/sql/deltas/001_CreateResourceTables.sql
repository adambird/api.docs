CREATE TABLE [Resources] (
	Id uniqueidentifier NOT NULL,
	Name varchar(50) NOT NULL,
	CONSTRAINT PK_Resources PRIMARY KEY NONCLUSTERED (Id),
	CONSTRAINT UQ_Resources_Name UNIQUE (Name)
)

CREATE TABLE [ResourceDocs] (
	Id uniqueidentifier NOT NULL,
	ResourceId uniqueidentifier NULL,
	Language varchar(3) NULL,
	Region varchar(10) NULL,
	Summary nvarchar(1000) NOT NULL,
	CONSTRAINT PK_ResourceDocs PRIMARY KEY NONCLUSTERED (Id) ,
	CONSTRAINT UQ_ResourceDocs_Culture UNIQUE (ResourceId, Language, Region)
)

--//@UNDO

DROP TABLE [ResourceDocs]
DROP TABLE [Resources]
