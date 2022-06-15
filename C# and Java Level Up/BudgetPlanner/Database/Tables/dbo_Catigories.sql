USE BudgetPlanner
GO
 DROP TABLE IF EXISTS dbo.Categories

CREATE TABLE [dbo].[Categories](
	[categoryID] [INT] NOT NULL,
	[categoryName] [VARCHAR] (50) NOT NULL,
	[categoryGoal] [DECIMAL] (18,2) NOT NULL,
	[categoryProgress] [DECIMAL] (18,2) NOT NULL
	PRIMARY KEY CLUSTERED ([categoryID])
)
	