﻿CREATE TABLE [dbo].[NutritionPlan](
	[NutriPlanId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[PlanDescription] [varchar](50) NOT NULL,
	[Created_At] [datetime] NOT NULL,
	[Updated_At] [datetime] NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_NutritionPlan] PRIMARY KEY CLUSTERED 
(
	[NutriPlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO