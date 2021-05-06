CREATE TABLE [dbo].[ExerciseDetail](
	[ExerciseID] [int] NOT NULL,
	[ExerciseType] [varchar](50) NOT NULL,
	[ExerciseFor] [varchar](50) NOT NULL,
	[TotalSet] [int] NOT NULL,
	[Rest] [varchar](50) NOT NULL,
	[Focus] [varchar](50) NOT NULL,
	[Equipement] [varchar](50) NOT NULL,
	[Time] [varchar](50) NOT NULL,
	[ExerciseName] [varchar](50) NOT NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_ExerciseDetail] PRIMARY KEY CLUSTERED 
(
	[ExerciseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ExerciseDetail] ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[UserDetails] ([UserId])
GO