USE BudgetPlanner
GO
 DROP TABLE IF EXISTS [dbo].[Users]

CREATE TABLE [dbo].[Users](
	[userID] [INT] NOT NULL,
	[username] [VARCHAR] (100) NOT NULL,
	[token] [VARCHAR] (200) NOT NULL
	PRIMARY KEY CLUSTERED (userID)
)
	