USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewGaCrmCanali]    Script Date: 09/06/2023 11:38:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP VIEW IF EXISTS [dbo].[ViewGaBackOfficeTipCon]
GO

CREATE VIEW [dbo].[ViewGaBackOfficeTipCon]
AS
  SELECT CAST(0 AS BIGINT) Id,TIPCON TipCon,DESCON DesCon,TIPMAT TipMat,CAST(CONTE AS INT) Lt,CAST(0 as BIT) Disabled
  FROM [20.82.75.6].[TARI].[dbo].FCTIPCOT
GO


