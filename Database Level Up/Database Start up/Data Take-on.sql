USE [PamellaGoldingDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amenity](
	[AmenityID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_Amenity] PRIMARY KEY CLUSTERED 
(
	[AmenityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bid](
	[BidID] [int] IDENTITY(1,1) NOT NULL,
	[BiddingSessionID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Commission] [money] NULL,
	[ServiceDetails] [varchar](max) NULL,
 CONSTRAINT [PK_Bid] PRIMARY KEY CLUSTERED 
(
	[BidID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BiddingSession](
	[BiddingSessionID] [int] IDENTITY(1,1) NOT NULL,
	[PropertyID] [int] NOT NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
 CONSTRAINT [PK_BiddingSession] PRIMARY KEY CLUSTERED 
(
	[BiddingSessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Property](
	[PropertyID] [int] IDENTITY(1,1) NOT NULL,
	[PropertyTypeID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[ERF] [varchar](50) NULL,
	[Bedrooms] [varchar](50) NULL,
	[Bathrooms] [varchar](50) NULL,
	[StreetNumber] [varchar](50) NULL,
	[StreetName] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[PostalCode] [varchar](50) NULL,
 CONSTRAINT [PK_Property] PRIMARY KEY CLUSTERED 
(
	[PropertyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyAmenity](
	[AmenityID] [int] NOT NULL,
	[PropertyID] [int] NOT NULL,
 CONSTRAINT [PK_PropertyAmenity] PRIMARY KEY CLUSTERED 
(
	[AmenityID] ASC,
	[PropertyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PropertyType](
	[PropertyTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](50) NULL,
 CONSTRAINT [PK_PropertyType] PRIMARY KEY CLUSTERED 
(
	[PropertyTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeID] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[Surname] [varchar](50) NULL,
	[CellNumber] [varchar](15) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[UserTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](50) NULL,
 CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED 
(
	[UserTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Amenity] ON 
GO
INSERT [dbo].[Amenity] ([AmenityID], [Description]) VALUES (2, N'Swimming Pool')
GO
INSERT [dbo].[Amenity] ([AmenityID], [Description]) VALUES (3, N'Garden ')
GO
INSERT [dbo].[Amenity] ([AmenityID], [Description]) VALUES (4, N'Tennis Court ')
GO
INSERT [dbo].[Amenity] ([AmenityID], [Description]) VALUES (5, N'Hot Tub')
GO
SET IDENTITY_INSERT [dbo].[Amenity] OFF
GO
SET IDENTITY_INSERT [dbo].[Bid] ON 
GO
INSERT [dbo].[Bid] ([BidID], [BiddingSessionID], [UserID], [Commission], [ServiceDetails]) VALUES (1, 1, 1, 10000.0000, N'Advertising')
GO
INSERT [dbo].[Bid] ([BidID], [BiddingSessionID], [UserID], [Commission], [ServiceDetails]) VALUES (2, 2, 1, 20000.0000, N'Advertising and Documentation ')
GO
INSERT [dbo].[Bid] ([BidID], [BiddingSessionID], [UserID], [Commission], [ServiceDetails]) VALUES (3, 3, 1, 15000.0000, N'No transfer cost')
GO
INSERT [dbo].[Bid] ([BidID], [BiddingSessionID], [UserID], [Commission], [ServiceDetails]) VALUES (4, 10, 1, 7000.0000, N'Advertising ')
GO
SET IDENTITY_INSERT [dbo].[Bid] OFF
GO
SET IDENTITY_INSERT [dbo].[BiddingSession] ON 
GO
INSERT [dbo].[BiddingSession] ([BiddingSessionID], [PropertyID], [StartDate], [EndDate]) VALUES (1, 5, CAST(N'2021-04-02' AS Date), CAST(N'2022-04-02' AS Date))
GO
INSERT [dbo].[BiddingSession] ([BiddingSessionID], [PropertyID], [StartDate], [EndDate]) VALUES (2, 4, CAST(N'2021-03-09' AS Date), CAST(N'2022-03-09' AS Date))
GO
INSERT [dbo].[BiddingSession] ([BiddingSessionID], [PropertyID], [StartDate], [EndDate]) VALUES (3, 3, CAST(N'2021-09-10' AS Date), CAST(N'2022-09-10' AS Date))
GO
INSERT [dbo].[BiddingSession] ([BiddingSessionID], [PropertyID], [StartDate], [EndDate]) VALUES (10, 1, CAST(N'2021-07-11' AS Date), CAST(N'2022-07-11' AS Date))
GO
SET IDENTITY_INSERT [dbo].[BiddingSession] OFF
GO
SET IDENTITY_INSERT [dbo].[Property] ON 
GO
INSERT [dbo].[Property] ([PropertyID], [PropertyTypeID], [UserID], [ERF], [Bedrooms], [Bathrooms], [StreetNumber], [StreetName], [City], [PostalCode]) VALUES (1, 2, 2, N'70 sqm ', N'3', N'1', N'31', N'Neon', N'Johannesburg', N'1111')
GO
INSERT [dbo].[Property] ([PropertyID], [PropertyTypeID], [UserID], [ERF], [Bedrooms], [Bathrooms], [StreetNumber], [StreetName], [City], [PostalCode]) VALUES (3, 3, 2, N'100 sqm', N'5', N'2', N'52', N'Perseus ', N'Pretoria', N'2222')
GO
INSERT [dbo].[Property] ([PropertyID], [PropertyTypeID], [UserID], [ERF], [Bedrooms], [Bathrooms], [StreetNumber], [StreetName], [City], [PostalCode]) VALUES (4, 4, 2, N'150 sqm', N'6', N'3', N'63', N'Rose', N'KZN', N'3333')
GO
INSERT [dbo].[Property] ([PropertyID], [PropertyTypeID], [UserID], [ERF], [Bedrooms], [Bathrooms], [StreetNumber], [StreetName], [City], [PostalCode]) VALUES (5, 1, 2, N'80 sqm ', N'4', N'2', N'42', N'Flamingo', N'Cape Town', N'4444')
GO
SET IDENTITY_INSERT [dbo].[Property] OFF
GO
INSERT [dbo].[PropertyAmenity] ([AmenityID], [PropertyID]) VALUES (2, 1)
GO
INSERT [dbo].[PropertyAmenity] ([AmenityID], [PropertyID]) VALUES (3, 3)
GO
INSERT [dbo].[PropertyAmenity] ([AmenityID], [PropertyID]) VALUES (4, 4)
GO
SET IDENTITY_INSERT [dbo].[PropertyType] ON 
GO
INSERT [dbo].[PropertyType] ([PropertyTypeID], [Type]) VALUES (1, N'Single-family home')
GO
INSERT [dbo].[PropertyType] ([PropertyTypeID], [Type]) VALUES (2, N'Condominiums')
GO
INSERT [dbo].[PropertyType] ([PropertyTypeID], [Type]) VALUES (3, N'Townhomes')
GO
INSERT [dbo].[PropertyType] ([PropertyTypeID], [Type]) VALUES (4, N'Duplexes')
GO
INSERT [dbo].[PropertyType] ([PropertyTypeID], [Type]) VALUES (5, N'Triplexes')
GO
SET IDENTITY_INSERT [dbo].[PropertyType] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([UserID], [UserTypeID], [Name], [Surname], [CellNumber]) VALUES (1, 1, N'John ', N'Doe', N'+27896523654')
GO
INSERT [dbo].[User] ([UserID], [UserTypeID], [Name], [Surname], [CellNumber]) VALUES (2, 1, N'Jack ', N'Black ', N'+27965326548')
GO
INSERT [dbo].[User] ([UserID], [UserTypeID], [Name], [Surname], [CellNumber]) VALUES (3, 2, N'Nick', N'Jones', N'+27965832146')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserType] ON 
GO
INSERT [dbo].[UserType] ([UserTypeID], [Type]) VALUES (1, N'Estate Agent ')
GO
INSERT [dbo].[UserType] ([UserTypeID], [Type]) VALUES (2, N'Property Owner ')
GO
INSERT [dbo].[UserType] ([UserTypeID], [Type]) VALUES (3, N'')
GO
SET IDENTITY_INSERT [dbo].[UserType] OFF
GO
ALTER TABLE [dbo].[Bid]  WITH CHECK ADD  CONSTRAINT [FK_Bid_BiddingSession] FOREIGN KEY([BiddingSessionID])
REFERENCES [dbo].[BiddingSession] ([BiddingSessionID])
GO
ALTER TABLE [dbo].[Bid] CHECK CONSTRAINT [FK_Bid_BiddingSession]
GO
ALTER TABLE [dbo].[Bid]  WITH CHECK ADD  CONSTRAINT [FK_Bid_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Bid] CHECK CONSTRAINT [FK_Bid_User]
GO
ALTER TABLE [dbo].[BiddingSession]  WITH CHECK ADD  CONSTRAINT [FK_BiddingSession_Property] FOREIGN KEY([PropertyID])
REFERENCES [dbo].[Property] ([PropertyID])
GO
ALTER TABLE [dbo].[BiddingSession] CHECK CONSTRAINT [FK_BiddingSession_Property]
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_PropertyType] FOREIGN KEY([PropertyTypeID])
REFERENCES [dbo].[PropertyType] ([PropertyTypeID])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_PropertyType]
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_User]
GO
ALTER TABLE [dbo].[PropertyAmenity]  WITH CHECK ADD  CONSTRAINT [FK_PropertyAmenity_Amenity] FOREIGN KEY([AmenityID])
REFERENCES [dbo].[Amenity] ([AmenityID])
GO
ALTER TABLE [dbo].[PropertyAmenity] CHECK CONSTRAINT [FK_PropertyAmenity_Amenity]
GO
ALTER TABLE [dbo].[PropertyAmenity]  WITH CHECK ADD  CONSTRAINT [FK_PropertyAmenity_Property] FOREIGN KEY([PropertyID])
REFERENCES [dbo].[Property] ([PropertyID])
GO
ALTER TABLE [dbo].[PropertyAmenity] CHECK CONSTRAINT [FK_PropertyAmenity_Property]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserType] FOREIGN KEY([UserTypeID])
REFERENCES [dbo].[UserType] ([UserTypeID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserType]
GO
