CREATE TABLE [dbo].[UserDetails](
[UserId] [int] IDENTITY(1,1) NOT NULL,
[Name] [varchar](50) NOT NULL,
[Gender] [varchar](50) NOT NULL,
[DOB] [date] NOT NULL,
[Weight] [int] NOT NULL,
[Height] [int] NOT NULL,
[MedicalCondition] [varchar](50) NULL,
[AllergicTo] [varchar](50) NULL,
[Goal] [varchar](50) NULL,
[Contact] [numeric](18, 0) NULL,
[Email] [varchar](50) NOT NULL,
[Username] [varchar](50) NOT NULL,
[Password] [varchar](50) NOT NULL,
[Role] [varchar](50) NULL,
[Diet_Plan_id] [int] NULL,
CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED 
(
[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserDetails] ADD CONSTRAINT [DF_UserDetails_Role] DEFAULT ('User') FOR [Role]
GO