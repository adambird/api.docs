ALTER TABLE ResourceDocs ADD [DocIndex] int NULL

--//@UNDO

ALTER TABLE ResourceDocs DROP [DocIndex]
