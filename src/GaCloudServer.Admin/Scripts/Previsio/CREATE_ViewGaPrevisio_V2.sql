USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewGaPrevisioOdsReport]    Script Date: 06/03/2023 14:17:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
DROP VIEW IF EXISTS [dbo].[ViewGaPrevisioOdsServiziReport]
GO

CREATE VIEW [dbo].[ViewGaPrevisioOdsServiziReport]
    AS
SELECT CAST(IDServizio as bigint) Id
      ,[IDservizio]
	  ,Mezzo
      ,Rimorchio
      ,Autista
      ,Operatore
      ,DataOraIniMezzo
      ,DataOraFineMezzo
      ,DataOraIniAutista
      ,DataOraFineAutista
      ,CAST([KmPartenza] as float) KmPartenza
      ,CAST([KmFine] as float) KmFine
      ,Committente
      ,Servizio
      ,DenominazioneEstesa
      ,CodiceErp
      ,Denominazione
      ,Categoria
      ,Confermato
      ,Completo
      ,Annullato
      ,FaseConsuntivata
      ,IDFase
      ,CAST(0 as bit) Disabled
	  FROM [20.82.75.6].SUPPORT.dbo.[ViewOdsServiziReport] 
GO


