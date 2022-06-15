/********************************************************************************************************************************************
    -- AUTHOR: Lebohang, on behalf of "Estate Agent Commission Bid System"
    -- CREATED: 21 Feb 2022
    -- DESCRIPTION:
        Get information for a particular Bid, given an id[int] as a parameter, and as a result returns HighestBidder's name and surname, Amount, Details, Start_Date, End_Date
        Status, PropertyAddress, ERF, NumberOfBathrooms, NumberOfRooms
    -- EXEC: [dbo].[spGetBidInfo] @BidId = [ID<int>]
 ********************************************************************************************************************************************/
CREATE PROCEDURE [dbo].[spGetBidInfo]
@BidId INT = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CONCAT([User].[Name], ' ', [User].[Surname])
	AS [FullName], [User].[CellNumber], [UserType].[Type] AS [UserType], [Bid].[Commission], [Bid].[ServiceDetails], [BiddingSession].[StartDate], [BiddingSession].[EndDate],
	IIF([BiddingSession].[EndDate] >= GETDATE() AND [BiddingSession].[StartDate] <= GETDATE(), 'AT HAND',
	IIF([BiddingSession].[EndDate] >= GETDATE() AND [BiddingSession].[StartDate] >= GETDATE(), 'UPCOMING', 'ENDED')) AS [Status],
	CONCAT([Property].[StreetNumber], ' ', [Property].[StreetName], ' ', [Property].[City], ' ', [Property].[PostalCode])
	AS PropertyAddress, [Property].[ERF], [Property].[Bathrooms], [Property].[Bedrooms]
	FROM [Bid]
	INNER JOIN [BiddingSession]
	ON [Bid].[BiddingSessionID] = [BiddingSession].[BiddingSessionID]
	INNER JOIN [Property]
	ON [BiddingSession].[PropertyID] = [Property].[PropertyID]
	INNER JOIN [User]
	ON [User].[UserID] = [Property].[UserID]
	INNER JOIN [UserType]
	ON [User].[UserTypeID] = [UserType].UserTypeID
	WHERE [BidID] = @BidId
END



/********************************************************************************************************************************************
    -- AUTHOR: Lebohang, on behalf of "Estate Agent Commission Bid System"
    -- CREATED: 21 Feb 2022
    -- DESCRIPTION:
        Get information for all Bids and as a result returns HighestBidder's name and surname, Amount, Details, Start_Date, End_Date
        Status, PropertyAddress, ERF, NumberOfBathrooms, NumberOfRooms
 ********************************************************************************************************************************************/
CREATE PROCEDURE [dbo].[spGetAllBidsInfo]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CONCAT([User].[Name], ' ', [User].[Surname])
	AS [FullName], [User].[CellNumber], [UserType].[Type] AS [UserType], [Bid].[Commission], [Bid].[ServiceDetails], [BiddingSession].[StartDate], [BiddingSession].[EndDate],
	IIF([BiddingSession].[EndDate] >= GETDATE() AND [BiddingSession].[StartDate] <= GETDATE(), 'AT HAND',
	IIF([BiddingSession].[EndDate] >= GETDATE() AND [BiddingSession].[StartDate] >= GETDATE(), 'UPCOMING', 'ENDED')) AS [Status],
	CONCAT([Property].[StreetNumber], ' ', [Property].[StreetName], ' ', [Property].[City], ' ', [Property].[PostalCode])
	AS PropertyAddress, [Property].[ERF], [Property].[Bathrooms], [Property].[Bedrooms]
	FROM [Bid]
	INNER JOIN [BiddingSession]
	ON [Bid].[BiddingSessionID] = [BiddingSession].[BiddingSessionID]
	INNER JOIN [Property]
	ON [BiddingSession].[PropertyID] = [Property].[PropertyID]
	INNER JOIN [User]
	ON [User].[UserID] = [Property].[UserID]
	INNER JOIN [UserType]
	ON [User].[UserTypeID] = [UserType].UserTypeID
END


/********************************************************************************************************************************************
    -- AUTHOR: Lebohang, on behalf of "Estate Agent Commission Bid System"
    -- CREATED: 21 Feb 2022
    -- DESCRIPTION:
        Get user's properties, given an ID[int] as a parameter and returns HouseOwner[user's name and surname], and their property
        information [PropertyAddress, and ERF]
 ********************************************************************************************************************************************/
CREATE PROCEDURE [dbo].[spGetUsersProperties]
@UserId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CONCAT([User].[Name], ' ', [User].[Surname])
	AS [HouseOwner], CONCAT([Property].[StreetNumber], ' ', [Property].[StreetName], ' ', [Property].[City], ' ', [Property].[PostalCode])
	AS PropertyAddress, [Property].[ERF]
	FROM [User] INNER JOIN [Property]
	ON [User].[User_ID] = [Property].[User_ID]
	WHERE [User].[User_ID] = @UserId
END