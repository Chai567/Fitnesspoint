CREATE TABLE [dbo].[Payment](
    [TransactionId] [int] IDENTITY(1000001,1) NOT NULL,
    [Payment1] [int] NULL,
    [Discount] [int] NOT NULL,
    [UserId] [int] NOT NULL,
    [PlanId] [int] NOT NULL,
    [NationalId] [bigint] NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
    [UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO