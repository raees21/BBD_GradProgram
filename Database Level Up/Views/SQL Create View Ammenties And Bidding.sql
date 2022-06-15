USE PamellaGoldingDB
GO	

CREATE VIEW Ammenities_and_Bidding AS (
	SELECT 
		p.PropertyID,
		[PropertyTypeID], 
		[USERID], 
		[ERF], 
		[Bedrooms], 
		[Bathrooms], 
		a.[Description], 
		[StartDate], 
		[EndDate] 
	FROM 
		PamellaGoldingDB.dbo.Property p, 
		PamellaGoldingDB.dbo.BiddingSession b, 
		PamellaGoldingDB.dbo.PropertyAmenity pa,
		PamellaGoldingDB.dbo.Amenity a
	WHERE 
		p.[PropertyID] =  b.[PropertyID]
	AND 
		p.[PropertyID] = pa.[PropertyID]
	AND 
		pa.[AmenityID] = a.[AmenityID]
);

