ALTER TABLE Resources ADD [Version] int NULL DEFAULT 0

ALTER TABLE ResourceDocs ADD [Version] int NULL DEFAULT 0

--//@UNDO

ALTER TABLE Resources DROP [Version]
ALTER TABLE ResourceDocs DROP [Version]
