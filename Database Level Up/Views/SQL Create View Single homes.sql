USE PamellaGoldingDB
GO

CREATE VIEW Single_family_homes AS (
	SELECT * FROM PamellaGoldingDB.dbo.Property
	WHERE 
	PropertyTypeID = 1
);