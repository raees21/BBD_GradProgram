USE PamellaGoldingDB
GO

CREATE VIEW Properties_with_Ammenities AS (
	SELECT
		[PropertyTypeID], 
		[USERID], 
		[ERF], 
		[Bedrooms], 
		[Bathrooms], 
		a.[Description]
	FROM
		PamellaGoldingDB.dbo.PropertyAmenity pa,
		PamellaGoldingDB.dbo.Amenity a,
		PamellaGoldingDB.dbo.Property p
	WHERE
		p.[PropertyID] = pa.[PropertyID]
	AND 
		pa.[AmenityID] = a.[AmenityID]
);