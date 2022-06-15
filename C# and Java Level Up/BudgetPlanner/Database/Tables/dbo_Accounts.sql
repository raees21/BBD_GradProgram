USE BudgetPlanner
GO
 DROP TABLE IF EXISTS dbo.Accounts

CREATE TABLE [dbo].[Accounts](
	[accountID] [INT] NOT NULL,
	[userID] [INT] FOREIGN KEY REFERENCES  [dbo].[Users](userID),
	[accountType] [VARCHAR] (50) NOT NULL,
	[accountName] [VARCHAR](50) NOT NULL
	PRIMARY KEY CLUSTERED ([accountID])
)
	