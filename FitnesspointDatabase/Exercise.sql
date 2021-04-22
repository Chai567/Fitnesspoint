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
	[UserID] [bigint] NULL
) ON [PRIMARY]
GO
