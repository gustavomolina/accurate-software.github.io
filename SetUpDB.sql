/*********************************************************************
*																	 *
* SQL Server script to create and populate a database for IFound API *  
*																	 *
*********************************************************************/

CREATE DATABASE IFound
GO 

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

GO

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

GO	   

--Category table
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] NOT NULL,
	[CategoryDescription] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--Insert Some DATABASE
INSERT INTO [dbo].[Category]
           ([CategoryId]
           ,[CategoryDescription])
     VALUES
           (3
           ,'Sapatos')

GO

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

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Procedure to add object
CREATE PROCEDURE [dbo].[sp_AddFoundOrLost] 
       @ObjectName        NVARCHAR(50)  , 
       @ObjectDescription     NVARCHAR(50)      , 
       @ObjectStatus         NVARCHAR(50)  , 
       @ObjectPhoto NVARCHAR(50)  ,
	   @ObjectFoundLocation NVARCHAR(50)  ,
	   @ObjectLostLocation NVARCHAR(50)  ,
	   @ObjectCreationDate NVARCHAR(50)  ,
	   @ObjectLastUpdate NVARCHAR(50),
	   @Category_FK integer,
	   @PersonWhoFound_FK integer,
	   @PersonWhoLost_FK integer,
	   @SuccessOnAdding int OUTPUT

AS 
BEGIN

     INSERT INTO [dbo].[Object]
          (                    
			   ObjectName, 
			   ObjectDescription, 
			   ObjectStatus, 
			   ObjectPhoto,
			   ObjectFoundLocation,
			   ObjectLostLocation,
			   ObjectCreationDate,
			   ObjectLastUpdate,
			   Category_FK,
			   PersonWhoFound_FK,
			   PersonWhoLost_FK            
          ) 
     VALUES 
          ( 
			   @ObjectName, 
			   @ObjectDescription, 
			   @ObjectStatus, 
			   @ObjectPhoto,
			   @ObjectFoundLocation,
			   @ObjectLostLocation,
			   @ObjectCreationDate,
			   @ObjectLastUpdate,
			   @Category_FK,
			   @PersonWhoFound_FK,
			   @PersonWhoLost_FK                     
          ) 
	IF(@@ROWCOUNT>0) SET @SuccessOnAdding=1
	ELSE SET @SuccessOnAdding=0
END 

GO

--Procedure to update object
CREATE PROCEDURE [dbo].[sp_UpdateFoundOrLost] 
	   @ObjectId INTEGER,
       @ObjectName        NVARCHAR(50)  , 
       @ObjectDescription     NVARCHAR(50)      , 
       @ObjectStatus         NVARCHAR(50)  , 
       @ObjectPhoto NVARCHAR(50)  ,
	   @ObjectFoundLocation NVARCHAR(50)  ,
	   @ObjectLostLocation NVARCHAR(50)  ,
	   @ObjectCreationDate NVARCHAR(50)  ,
	   @ObjectLastUpdate NVARCHAR(50),
	   @Category_FK integer,
	   @PersonWhoFound_FK integer,
	   @PersonWhoLost_FK integer,
	   @SuccessOnUpdating int OUTPUT

AS 
BEGIN
     UPDATE [dbo].[Object]
           SET                   
			   ObjectName = @ObjectName, 
			   ObjectDescription = @ObjectDescription, 
			   ObjectStatus = @ObjectStatus, 
			   ObjectPhoto = @ObjectPhoto,
			   ObjectFoundLocation = @ObjectFoundLocation,
			   ObjectLostLocation = @ObjectLostLocation,
			   ObjectCreationDate = @ObjectCreationDate,
			   ObjectLastUpdate = @ObjectLastUpdate,
			   Category_FK = @Category_FK,
			   PersonWhoFound_FK = @PersonWhoFound_FK,
			   PersonWhoLost_FK = @PersonWhoLost_FK             

		  WHERE 
			  ObjectId = @ObjectId

		IF(@@ROWCOUNT>0) SET @SuccessOnUpdating=1
		ELSE SET @SuccessOnUpdating=0
END 
GO







