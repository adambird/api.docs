CREATE TABLE [Fields] (
	Id uniqueidentifier NOT NULL,
	ResourceId uniqueidentifier NOT NULL,
	FieldIndex int NOT NULL DEFAULT (0),
	Name varchar(50) NOT NULL,
	FieldType varchar(50) NOT NULL,
	CONSTRAINT PK_Fields PRIMARY KEY NONCLUSTERED (Id)
)

CREATE TABLE [FieldDocs] (
	Id uniqueidentifier NOT NULL,
	FieldId uniqueidentifier NOT NULL,
	[Language] varchar(3) NULL,
	[Description] nvarchar(1000) NOT NULL,
	CONSTRAINT PK_FieldDocs PRIMARY KEY NONCLUSTERED (Id),
	CONSTRAINT UQ_FieldDocs_Culture UNIQUE (FieldId, [Language])
)

--//@UNDO

DROP TABLE [FieldDocs]
DROP TABLE [Fields]