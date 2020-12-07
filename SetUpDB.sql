/*********************************************************************
*																	 *
* SQL Server script to create and populate a database for IFound API *  
*																	 *
*********************************************************************/

CREATE DATABASE IFound

USE [IFound]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
--Person table
CREATE TABLE [dbo].[Person](
	[PersonId] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[Age] [int] NULL,
	[Nationality] [varchar](50) NULL,
	[Telephone] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--Insert some data
INSERT INTO [dbo].[Person]
           ([PersonId]
           ,[Name]
           ,[Age]
           ,[Nationality]
           ,[Telephone]
           ,[Email])
     VALUES
           (2
           ,'Ana Moreira'
           ,22
           ,'Brasileiro(a)'
           ,'(60) 63384-0485'
           ,'ana@email.com.br')
		   
--Category table
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] NOT NULL,
	[CategoryDescription] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

--Insert Some DATABASE
INSERT INTO [dbo].[Category]
           ([CategoryId]
           ,[CategoryDescription])
     VALUES
           (3
           ,Sapatos)
		   
--Object TABLE

CREATE TABLE [dbo].[Object](
	[ObjectName] [varchar](50) NULL,
	[ObjectDescription] [varchar](50) NULL,
	[ObjectStatus] [varchar](50) NULL,
	[ObjectPhoto] [varchar](50) NULL,
	[ObjectFoundLocation] [varchar](50) NULL,
	[ObjectLostLocation] [varchar](50) NULL,
	[ObjectCreationDate] [varchar](50) NULL,
	[ObjectLastUpdate] [varchar](50) NULL,
	[Category_FK] [int] NULL,
	[PersonWhoFound_FK] [int] NULL,
	[PersonWhoLost_FK] [int] NULL,
	[ObjectId] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ObjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Object]  WITH CHECK ADD FOREIGN KEY([Category_FK])
REFERENCES [dbo].[Category] ([CategoryId])
GO

ALTER TABLE [dbo].[Object]  WITH CHECK ADD FOREIGN KEY([PersonWhoFound_FK])
REFERENCES [dbo].[Person] ([PersonId])
GO

ALTER TABLE [dbo].[Object]  WITH CHECK ADD FOREIGN KEY([PersonWhoLost_FK])
REFERENCES [dbo].[Person] ([PersonId])
GO

GO


