﻿/*
Deployment script for FitnesspointDatabase_1

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "FitnesspointDatabase_1"
:setvar DefaultFilePrefix "FitnesspointDatabase_1"
:setvar DefaultDataPath "C:\Users\Chaitanya.shah\AppData\Local\Microsoft\VisualStudio\SSDT\Fitnesspoint"
:setvar DefaultLogPath "C:\Users\Chaitanya.shah\AppData\Local\Microsoft\VisualStudio\SSDT\Fitnesspoint"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                CURSOR_DEFAULT LOCAL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE,
                DISABLE_BROKER 
            WITH ROLLBACK IMMEDIATE;
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

PRINT('Pre deployment script')
GO

GO
PRINT N'Creating Table [dbo].[NutritionPlan]...';


GO
CREATE TABLE [dbo].[NutritionPlan] (
    [NutriPlanId]     INT          IDENTITY (1, 1) NOT NULL,
    [Name]            VARCHAR (50) NOT NULL,
    [PlanDescription] VARCHAR (50) NOT NULL,
    [Created_At]      DATETIME     NOT NULL,
    [Updated_At]      DATETIME     NOT NULL,
    [Price]           INT          NOT NULL,
    CONSTRAINT [PK_NutritionPlan] PRIMARY KEY CLUSTERED ([NutriPlanId] ASC) ON [PRIMARY]
) ON [PRIMARY];


GO
PRINT N'Creating Table [dbo].[Payment]...';


GO
CREATE TABLE [dbo].[Payment] (
    [TransactionId] INT    IDENTITY (1000001, 1) NOT NULL,
    [Payment1]      INT    NULL,
    [Discount]      INT    NOT NULL,
    [UserId]        INT    NOT NULL,
    [PlanId]        INT    NOT NULL,
    [NationalId]    BIGINT NOT NULL,
    CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED ([UserId] ASC) ON [PRIMARY]
) ON [PRIMARY];


GO
PRINT N'Creating Table [dbo].[Payment_cred]...';


GO
CREATE TABLE [dbo].[Payment_cred] (
    [DebitCardNo]  INT    NOT NULL,
    [CreditCardNo] INT    NOT NULL,
    [Expiry_Month] INT    NOT NULL,
    [Expiry_Year]  INT    NOT NULL,
    [cvv]          INT    NOT NULL,
    [Nid]          BIGINT NOT NULL,
    [AtmPin]       INT    NOT NULL,
    CONSTRAINT [PK_Payment_cred] PRIMARY KEY CLUSTERED ([Nid] ASC) ON [PRIMARY]
) ON [PRIMARY];


GO
PRINT N'Creating Table [dbo].[UserDetails]...';


GO
CREATE TABLE [dbo].[UserDetails] (
    [UserId]           INT          IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (50) NOT NULL,
    [Gender]           VARCHAR (50) NOT NULL,
    [DOB]              DATE         NOT NULL,
    [Weight]           INT          NOT NULL,
    [Height]           INT          NOT NULL,
    [MedicalCondition] VARCHAR (50) NULL,
    [AllergicTo]       VARCHAR (50) NULL,
    [Goal]             VARCHAR (50) NULL,
    [Contact]          NUMERIC (18) NULL,
    [Email]            VARCHAR (50) NOT NULL,
    [Username]         VARCHAR (50) NOT NULL,
    [Password]         VARCHAR (50) NOT NULL,
    [Role]             VARCHAR (50) NULL,
    [Diet_Plan_id]     INT          NULL,
    CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED ([UserId] ASC) ON [PRIMARY]
) ON [PRIMARY];


GO
PRINT N'Creating Table [dbo].[WeightLog]...';


GO
CREATE TABLE [dbo].[WeightLog] (
    [WeightId]   INT      IDENTITY (1, 1) NOT NULL,
    [Weight]     INT      NOT NULL,
    [Created_At] DATETIME NOT NULL,
    [Updated_At] DATETIME NOT NULL,
    [UserId]     INT      NULL,
    CONSTRAINT [PK_WeightLog] PRIMARY KEY CLUSTERED ([WeightId] ASC) ON [PRIMARY]
) ON [PRIMARY];


GO
PRINT N'Creating Default Constraint [dbo].[DF_Payment_cred_Debit_card_No.]...';


GO
ALTER TABLE [dbo].[Payment_cred]
    ADD CONSTRAINT [DF_Payment_cred_Debit_card_No.] DEFAULT ((0)) FOR [DebitCardNo];


GO
PRINT N'Creating Default Constraint [dbo].[DF_Payment_cred_Credit_Card_No.]...';


GO
ALTER TABLE [dbo].[Payment_cred]
    ADD CONSTRAINT [DF_Payment_cred_Credit_Card_No.] DEFAULT ((0)) FOR [CreditCardNo];


GO
PRINT N'Creating Default Constraint [dbo].[DF_UserDetails_Role]...';


GO
ALTER TABLE [dbo].[UserDetails]
    ADD CONSTRAINT [DF_UserDetails_Role] DEFAULT ('User') FOR [Role];


GO
PRINT N'Creating Foreign Key [dbo].[FK_Payment_cred_Payment_cred]...';


GO
ALTER TABLE [dbo].[Payment_cred] WITH NOCHECK
    ADD CONSTRAINT [FK_Payment_cred_Payment_cred] FOREIGN KEY ([Nid]) REFERENCES [dbo].[Payment_cred] ([Nid]);


GO
PRINT N'Creating Foreign Key <unnamed>...';


GO
ALTER TABLE [dbo].[WeightLog] WITH NOCHECK
    ADD FOREIGN KEY ([UserId]) REFERENCES [dbo].[UserDetails] ([UserId]);


GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

PRINT('Post deployment')
GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Payment_cred] WITH CHECK CHECK CONSTRAINT [FK_Payment_cred_Payment_cred];


GO
CREATE TABLE [#__checkStatus] (
    id           INT            IDENTITY (1, 1) PRIMARY KEY CLUSTERED,
    [Schema]     NVARCHAR (256),
    [Table]      NVARCHAR (256),
    [Constraint] NVARCHAR (256)
);

SET NOCOUNT ON;

DECLARE tableconstraintnames CURSOR LOCAL FORWARD_ONLY
    FOR SELECT SCHEMA_NAME([schema_id]),
               OBJECT_NAME([parent_object_id]),
               [name],
               0
        FROM   [sys].[objects]
        WHERE  [parent_object_id] IN (OBJECT_ID(N'dbo.WeightLog'))
               AND [type] IN (N'F', N'C')
                   AND [object_id] IN (SELECT [object_id]
                                       FROM   [sys].[check_constraints]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0
                                       UNION
                                       SELECT [object_id]
                                       FROM   [sys].[foreign_keys]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0);

DECLARE @schemaname AS NVARCHAR (256);

DECLARE @tablename AS NVARCHAR (256);

DECLARE @checkname AS NVARCHAR (256);

DECLARE @is_not_trusted AS INT;

DECLARE @statement AS NVARCHAR (1024);

BEGIN TRY
    OPEN tableconstraintnames;
    FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
    WHILE @@fetch_status = 0
        BEGIN
            PRINT N'Checking constraint: ' + @checkname + N' [' + @schemaname + N'].[' + @tablename + N']';
            SET @statement = N'ALTER TABLE [' + @schemaname + N'].[' + @tablename + N'] WITH ' + CASE @is_not_trusted WHEN 0 THEN N'CHECK' ELSE N'NOCHECK' END + N' CHECK CONSTRAINT [' + @checkname + N']';
            BEGIN TRY
                EXECUTE [sp_executesql] @statement;
            END TRY
            BEGIN CATCH
                INSERT  [#__checkStatus] ([Schema], [Table], [Constraint])
                VALUES                  (@schemaname, @tablename, @checkname);
            END CATCH
            FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
        END
END TRY
BEGIN CATCH
    PRINT ERROR_MESSAGE();
END CATCH

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') >= 0
    CLOSE tableconstraintnames;

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') = -1
    DEALLOCATE tableconstraintnames;

SELECT N'Constraint verification failed:' + [Schema] + N'.' + [Table] + N',' + [Constraint]
FROM   [#__checkStatus];

IF @@ROWCOUNT > 0
    BEGIN
        DROP TABLE [#__checkStatus];
        RAISERROR (N'An error occurred while verifying constraints', 16, 127);
    END

SET NOCOUNT OFF;

DROP TABLE [#__checkStatus];


GO
PRINT N'Update complete.';


GO
