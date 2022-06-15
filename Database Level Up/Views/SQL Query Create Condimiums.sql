USE PamellaGoldingDB
GO

CREATE VIEW Condiminiums AS (
	SELECT * FROM PamellaGoldingDB.dbo.Property
	WHERE 
	PropertyTypeID = 2
);