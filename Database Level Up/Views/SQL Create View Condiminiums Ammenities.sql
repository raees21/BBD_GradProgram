USE [PamellaGoldingDB]
GO

/****** Object:  View [dbo].[Single_family_homes]    Script Date: 2022/02/25 08:22:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[Condiminiums_Ammenities] AS (
	SELECT 
	  p.PropertyID
	  ,[USERID]
      ,[ERF]
      ,[Bedrooms]
      ,[Bathrooms]
      ,[Description]
	FROM 
		PamellaGoldingDB.dbo.PropertyAmenity pa,
		PamellaGoldingDB.dbo.Amenity a,
		PamellaGoldingDB.dbo.Property p,
		PamellaGoldingDB.dbo.PropertyType pt
	WHERE 
		p.PropertyTypeID = 2
	AND
		p.[PropertyID] = pa.[PropertyID]
	AND 
		pa.[AmenityID] = a.[AmenityID]
	AND 
		p.[PropertyTypeID] = pt.[PropertyTypeID]

);
GO


