USE BudgetPlanner
GO
 DROP TABLE IF EXISTS dbo.Goals

CREATE TABLE [dbo].[Goals](
	[id] [INT] NOT NULL,
	[type] [VARCHAR] (60) NOT NULL,
	PRIMARY KEY CLUSTERED ([id])
)
	