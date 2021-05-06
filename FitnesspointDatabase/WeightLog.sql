CREATE TABLE [dbo].[WeightLog](
	[WeightId] [int] IDENTITY(1,1) NOT NULL,
	[Weight] [int] NOT NULL,
	[Created_At] [datetime] NOT NULL,
	[Updated_At] [datetime] NOT NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_WeightLog] PRIMARY KEY CLUSTERED 
(
	[WeightId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[WeightLog] ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[UserDetails] ([UserId])
GO