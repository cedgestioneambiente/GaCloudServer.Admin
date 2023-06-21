USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewGaPrevisioOds]    Script Date: 17/06/2022 12:15:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[ViewEmzWhiteList]
    AS
	SELECT 
	[IDENTI2] Identi2
      ,[CHIAVE1] Chiave1
      ,[ATTIVO] Attivo
      , cast(0 as bigint) Id
	  , cast(0 as bit) Disabled
  FROM [20.82.75.6].[SUPPORT].[dbo].[ViewGaEmzWhiteList]
  WHERE (Chiave1 LIKE '1004%' or Chiave1 LIKE 'C0%') AND DATALENGTH (Chiave1) =16

GO
