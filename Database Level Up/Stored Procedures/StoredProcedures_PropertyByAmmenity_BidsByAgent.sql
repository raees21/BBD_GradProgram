/********************************************************************************************************************************************
    -- AUTHOR: Sashen, on behalf of "Estate Agent Commission Bid System"
    -- CREATED: 21 Feb 2022
    -- DESCRIPTION:
        This stored procedure returns the details of all properties that have a certain specified amenity
    -- EXEC FindBidDetails @Description = ‘Garden';
 ********************************************************************************************************************************************/

CREATE PROCEDURE FindBidDetails @Description varchar(50)
AS
Select 
Property.PropertyID, Property.Bedrooms, Property.Bathrooms, Property.ERF, Property.StreetNumber,
Property.StreetName, Property.City, Property.PostalCode, BiddingSession.[StartDate] as BidSessionStart,
BiddingSession.[EndDate] as BidSessionEnd
from [dbo].[Property] 
INNER JOIN [dbo].[BiddingSession]
on 
Property.PropertyID = BiddingSession.PropertyID 
where Property.PropertyID =(Select PropertyID from PropertyAmenity where AmenityID = 
(Select AmenityID from Amenity where [Description] = @Description))
GO;

/********************************************************************************************************************************************
    -- DESCRIPTION:
        This stored procedure returns the details of all bids made by a specific agent
    -- EXEC ListBids @Name = ‘John’;
 ********************************************************************************************************************************************/

CREATE PROCEDURE ListBids @UserID int
AS
Select
[User].UserID as [Agent ID], [User].[Name] as [Agent Name], Bid.BidID as [Bid ID],
CONCAT((Select StreetNumber from Property where PropertyID =
(Select PropertyID from BiddingSession where BiddingSessionID = Bid.BiddingSessionID)) 
,' ',(Select StreetName from Property where PropertyID =
(Select PropertyID from BiddingSession where BiddingSessionID = Bid.BiddingSessionID)) 
,', ',(Select City from Property where PropertyID =
(Select PropertyID from BiddingSession where BiddingSessionID = Bid.BiddingSessionID))) 
as [Property Address], FORMAT(Bid.Commission, 'c','af-ZA') as [Bid Amount],
Bid.ServiceDetails as [Offering]
from
Bid
inner join
[User]
on
[User].UserID = Bid.UserID
where
[User].UserID = @UserID
GO;