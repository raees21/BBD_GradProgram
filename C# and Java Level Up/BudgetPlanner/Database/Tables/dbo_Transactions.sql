USE BudgetPlanner
GO
 DROP TABLE IF EXISTS dbo.[Transactions]

CREATE TABLE [dbo].[Transactions](
	[transactionID] [INT] NOT NULL,
	[transactionAmount] [DECIMAL] (18,2) NOT NULL,
	[accountID] [INT] FOREIGN KEY REFERENCES  [dbo].[Accounts](accountID),
	[categoriesID] [INT] FOREIGN KEY REFERENCES  [dbo].[Categories](categoryID),
	[userID] [INT] FOREIGN KEY REFERENCES  [dbo].[Users](userID),
	[transactionDate] [DATE] NOT NULL
	PRIMARY KEY CLUSTERED ([transactionID])
)
	