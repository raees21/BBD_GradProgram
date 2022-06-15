CREATE DATABASE BudgetPlanner
GO

USE BudgetPlanner
GO

DROP TABLE IF EXISTS dbo.Accounts

CREATE TABLE [dbo].[Accounts](
	[AccountID] [INT] NOT NULL,
	[AccountType] [VARCHAR] (60) NOT NULL,
);
GO

ALTER TABLE dbo.Accounts
ADD CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED ([AccountID] ASC);
GO

DROP TABLE IF EXISTS dbo.Categories

CREATE TABLE [dbo].[Categories](
	[CategoryID] [INT] NOT NULL,
	[CategoryName] [VARCHAR] (60) NOT NULL,
    [CategoryGoal] [DECIMAL] (18,2) NOT NULL,
    [userID] [INT] FOREIGN KEY REFERENCES  [dbo].[Users](Token)
);
GO

ALTER TABLE dbo.Categories
ADD CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryID] ASC);
GO

DROP TABLE IF EXISTS [dbo].[Users]

CREATE TABLE [dbo].[Users](
	[UserName] [VARCHAR] (100) NOT NULL,
	[Token] [INT] NOT NULL
);
GO

ALTER TABLE dbo.Users
ADD CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Token] ASC);
GO


DROP TABLE IF EXISTS dbo.[Transactions]

CREATE TABLE [dbo].[Transactions](
	[TransactionID] [INT] NOT NULL,
	[TransactionAmount] [DECIMAL] (18,2) NOT NULL,
	[AccountID] [INT],
	[CategoryID] [INT], 
	[Token] [INT],
    [TransactionDate] [VARCHAR](11)
);
GO

ALTER TABLE dbo.Transactions
ADD CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([TransactionID] ASC);
GO

ALTER TABLE dbo.Transactions
ADD CONSTRAINT FK_AccountID
FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID);

ALTER TABLE dbo.Transactions
ADD CONSTRAINT FK_CategoryID
FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID);

ALTER TABLE dbo.Transactions
ADD CONSTRAINT FK_token
FOREIGN KEY ([Token]) REFERENCES Users(Token);

INSERT INTO [dbo].[Accounts]
           ([AccountID],
            [AccountType]
           )
		   VALUES    (1, 'Credit'),
           (2, 'Cheque'),
           (3, 'Cash')
GO
	
INSERT INTO [dbo].[Categories]
           ([CategoryID],
           [CategoryName],
           [CategoryGoal],
           [userID]
           )
		   VALUES    (1, 'Groceries', 10000.00,1),
           (2, 'Internet',100000.00,1),
           (3, 'Cellphone',1000.00,2),
           (4, 'Clothing',2600,2),
           (5, 'Entertainment',1,5000),
           (6, 'Tech and Appliances',3,1000)
GO

INSERT INTO [dbo].[Users]
           ([UserName],
           [Token]
           )
		   VALUES    ('Bob', 1),
           ('Chris', 2),
           ('James', 3)
GO

INSERT INTO [dbo].[Transactions]
           ([TransactionID],
           [TransactionAmount],
           [AccountID],
           [CategoryID],
           [Token],
           [TransactionDate]
           )
		   VALUES    (1, '500.00', 1, 1, 1, '2021-12-05'),
           (2, '200.00', 2, 1, 1, '2021-12-08'),
           (3, '90.00', 1, 2, 1, '2021-12-09'),
           (4, '3000.00', 1, 3, 1, '2021-12-18'),
           (5, '800.00', 3, 5, 1, '2021-12-25'),
           (6, '20.00', 1, 1, 1, '2021-12-26'),
           (7, '500.00', 2, 1, 1, '2021-11-08'),
           (8, '450.00', 1, 2, 1, '2021-11-09'),
           (9, '3200.00', 1, 3, 1, '2021-11-18'),
           (10, '1800.00', 3, 5, 1, '2021-11-25'),
           (11, '6770.00', 1, 1, 1, '2021-11-26'),
           (12, '800.00', 2, 1, 1, '2021-10-08'),
           (13, '550.00', 1, 2, 1, '2021-10-09'),
           (14, '4200.00', 1, 3, 1, '2021-10-18'),
           (15, '7800.00', 3, 5, 1, '2021-10-25'),
           (16, '8770.00', 1, 1, 1, '2021-18-26'),
           (17, '2500.00', 2, 1, 2, '2021-12-08'),
           (18, '900.00', 1, 2, 2, '2021-12-09'),
           (19, '9000.00', 1, 3, 2, '2021-12-18'),
           (20, '8000.00', 3, 5, 2, '2021-12-25'),
           (21, '200.00', 1, 1, 2, '2021-12-26'),
           (22, '5006.00', 2, 1, 2, '2021-11-08'),
           (23, '4505.00', 1, 2, 2, '2021-11-09'),
           (24, '3900.00', 1, 3, 2, '2021-11-18'),
           (25, '10800.00', 3, 5, 2, '2021-11-25'),
           (26, '6770.00', 1, 1, 2, '2021-11-26'),
           (27, '6600.00', 2, 1, 2, '2021-10-08'),
           (28, '250.00', 1, 2, 2, '2021-10-09'),
           (29, '200.00', 1, 3, 2, '2021-10-18'),
           (30, '800.00', 3, 5, 2, '2021-10-25'),
           (31, '5770.00', 1, 1, 2, '2021-18-26'),
           (32, '500.00', 2, 1, 3, '2021-12-08'),
           (33, '1900.00', 1, 2, 3, '2021-12-09'),
           (34, '9200.00', 1, 3, 3, '2021-12-18'),
           (35, '800.00', 3, 5, 3, '2021-12-25'),
           (36, '900.00', 1, 1, 3, '2021-12-26'),
           (37, '2566.00', 2, 1, 3, '2021-11-08'),
           (38, '1505.00', 1, 2, 3, '2021-11-09'),
           (39, '2900.00', 1, 3, 3, '2021-11-18'),
           (40, '30800.00', 3, 5, 3, '2021-11-25'),
           (41, '770.00', 1, 1, 3, '2021-11-26'),
           (42, '600.00', 2, 1, 3, '2021-10-08'),
           (43, '50.00', 1, 2, 3, '2021-10-09'),
           (44, '1200.00', 1, 3, 3, '2021-10-18'),
           (45, '400.00', 3, 5, 3, '2021-10-25'),
           (46, '3770.00', 1, 1, 3, '2021-18-26')
GO


	