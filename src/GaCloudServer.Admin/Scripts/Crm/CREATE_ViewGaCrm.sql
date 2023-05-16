USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewGaCdrConferimenti]    Script Date: 17/04/2023 11:45:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP VIEW IF EXISTS [dbo].[ViewGaCrmCanali]
GO
DROP VIEW IF EXISTS [dbo].[ViewGaCrmCausali]
GO
DROP VIEW IF EXISTS [dbo].[ViewGaCrmStati]
GO
DROP VIEW IF EXISTS [dbo].[ViewGaCrmCausaliType]
GO
DROP VIEW IF EXISTS [dbo].[ViewGaCrmTickets]
GO

CREATE VIEW [dbo].[ViewGaCrmCanali]
AS
  SELECT ID as Id,DESCRIZIONE as Descrizione,CAST(0 AS BIT) Disabled
  FROM [20.82.75.6].[TARI].[dbo].[CRM_CANALE]
GO

CREATE VIEW [dbo].[ViewGaCrmCausali]
AS
	SELECT Id as Id,DESCRIZIONE as Descrizione,[TYPE] as [Type],TIPOOPERAZIONE as TipoOperazione, CAST(0 AS BIT) Disabled
	FROM [20.82.75.6].[TARI].[dbo].[CRM_CAUSALE]
GO

CREATE VIEW [dbo].[ViewGaCrmCausaliType]
AS
    SELECT [TYPE] as Id,
            [TYPE] as [Type]
          ,[DESCRI] as Descrizione
          ,CAST(0 AS BIT) Disabled
      FROM [20.82.75.6].[TARI].[dbo].[CRM_CAUSALE_TYPE]
GO

CREATE VIEW [dbo].[ViewGaCrmStati]
AS
    SELECT [ID] as Id
          ,[DESCRIZIONE] as Descrizione
          ,[ACTIVE] AS Active
          ,CAST(0 AS BIT) Disabled
      FROM [20.82.75.6].[TARI].[dbo].[CRM_STATE]
GO

CREATE VIEW [dbo].[ViewGaCrmTickets]
AS
    SELECT *
      FROM [20.82.75.6].[TARI].[dbo].[ViewGaCrmTickets] A
	  WHERE A.Id NOT IN (SELECT CrmTicketId FROM GaCrmEvents WHERE CrmEventStateId NOT IN('3','4'))

GO