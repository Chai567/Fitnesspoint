CREATE TABLE [dbo].[Payment_cred](
    [DebitCardNo] [int] NOT NULL,
    [CreditCardNo] [int] NOT NULL,
    [Expiry_Month] [int] NOT NULL,
    [Expiry_Year] [int] NOT NULL,
    [cvv] [int] NOT NULL,
    [Nid] [bigint] NOT NULL,
    [AtmPin] [int] NOT NULL,
 CONSTRAINT [PK_Payment_cred] PRIMARY KEY CLUSTERED 
(
    [Nid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

 

ALTER TABLE [dbo].[Payment_cred] ADD  CONSTRAINT [DF_Payment_cred_Debit_card_No.]  DEFAULT ((0)) FOR [DebitCardNo]
GO

 

ALTER TABLE [dbo].[Payment_cred] ADD  CONSTRAINT [DF_Payment_cred_Credit_Card_No.]  DEFAULT ((0)) FOR [CreditCardNo]
GO

 

ALTER TABLE [dbo].[Payment_cred]  WITH CHECK ADD  CONSTRAINT [FK_Payment_cred_Payment_cred] FOREIGN KEY([Nid])
REFERENCES [dbo].[Payment_cred] ([Nid])
GO

