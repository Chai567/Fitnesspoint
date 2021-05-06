CREATE TABLE [dbo].[PaymentTbl](
[Order_id] [int] IDENTITY(1001,1) NOT NULL,
[User_id] [int] NULL,
[Plan_id] [int] NULL,
[Plan_name] [varchar](50) NULL,
[Amount] [int] NOT NULL,
CONSTRAINT [PK_PaymentTbl] PRIMARY KEY CLUSTERED
(
[Order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PaymentTbl] ADD CONSTRAINT [FK_PaymentTbl_NutritionPlan] FOREIGN KEY([Plan_id])
REFERENCES [dbo].[NutritionPlan] ([NutriPlanId])
GO
ALTER TABLE [dbo].[PaymentTbl] CHECK CONSTRAINT [FK_PaymentTbl_NutritionPlan]
GO
ALTER TABLE [dbo].[PaymentTbl] ADD CONSTRAINT [FK_PaymentTbl_UserDetails] FOREIGN KEY([User_id])
REFERENCES [dbo].[UserDetails] ([UserId])
GO
ALTER TABLE [dbo].[PaymentTbl] CHECK CONSTRAINT [FK_PaymentTbl_UserDetails]
GO
