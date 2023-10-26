USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewGaPrevisioOdsReport]    Script Date: 06/03/2023 14:17:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[ViewGaPrevisioOdsLetture]
AS
SELECT cast(0 as bigint) Id, IDSERVIZIO IdServizio,[FileName],STRING_AGG(Descrizione,' | ') Descrizione, cast(0 as bit) Disabled
FROM [20.82.75.6].SUPPORT.[dbo].[ViewPrevisioOdsLetture]
WHERE [fileName] COLLATE DATABASE_DEFAULT NOT IN (SELECT replace([FILENAME],'.txt','') from GaPrevisioOdsLetture  WHERE Elaborato=1 OR(Elaborato=0 AND Retry<10))
group by idservizio,filename
GO


