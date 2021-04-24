CREATE TABLE [dbo].[Payment_](
    [TransactionId] [int] NOT NULL,
    [UserId] [int] NOT NULL,
    [PlanId] [int] NOT NULL,
    [Payment1] [int] NOT NULL,
    [Discount] [int] NOT NULL,
    [NationalId] [int] NOT NULL,
 CONSTRAINT [PK_Payment_] PRIMARY KEY CLUSTERED 
(
    [TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

 

ALTER TABLE [dbo].[Payment_]  WITH CHECK ADD  CONSTRAINT [FK_Payment__NutritionPlan] FOREIGN KEY([PlanId])
REFERENCES [dbo].[NutritionPlan] ([NutriPlanId])
GO

 

ALTER TABLE [dbo].[Payment_] CHECK CONSTRAINT [FK_Payment__NutritionPlan]
GO

 

ALTER TABLE [dbo].[Payment_]  WITH CHECK ADD  CONSTRAINT [FK_Payment__UserDetails] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserDetails] ([UserId])
GO

 

ALTER TABLE [dbo].[Payment_] CHECK CONSTRAINT [FK_Payment__UserDetails]
GO