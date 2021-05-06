CREATE TABLE [dbo].[DietPlan](
	[DietId] [int] IDENTITY(1,1) NOT NULL,
	[Slots] [int] NOT NULL,
	[FoodType] [varchar](50) NOT NULL,
	[FatRatio] [int] NOT NULL,
	[CarbsRatio] [int] NOT NULL,
	[ProteinRatio] [int] NOT NULL,
	[TotalCalorie] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_DietPlan] PRIMARY KEY CLUSTERED 
(
	[DietId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DietPlan] ADD  CONSTRAINT [FK_DietPlan_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserDetails] ([UserId])
GO

ALTER TABLE [dbo].[DietPlan] CHECK CONSTRAINT [FK_DietPlan_User]
GO