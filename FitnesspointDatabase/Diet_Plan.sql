CREATE TABLE [dbo].[Diet_Plan](
    [UserId] [int] NOT NULL,
    [FoodType] [varchar](50) NOT NULL,
    [ProteinRatio] [float] NULL,
    [FatRaio] [float] NULL,
    [CarbsRatio] [float] NULL,
    [Total] [int] NOT NULL,
    [DietName] [varchar](50) NULL,
 CONSTRAINT [PK_Diet_Plan] PRIMARY KEY CLUSTERED 
(
    [UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
