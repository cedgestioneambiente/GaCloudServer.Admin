USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewGaPrevisioOdsReport]    Script Date: 06/03/2023 14:17:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [dbo].[ViewGaPrevisioOdsReport]
    AS
SELECT CAST(IDServizio as bigint) Id
      ,[IDservizio]
	  ,ContaServizi
      ,DataOraIniMezzo
	  ,DataOraFineMezzo
      ,MinutiMezzo
      ,EffettivoMinMezzo
      ,DataOraIniAutista
	  ,DataOraFineAutista
      ,MinutiAutista
      ,EffettivoMinAutista
      ,CAST([KmPartenza] as float) KmPartenza
      ,CAST([KmFine] as float) KmFine
      ,[Committente]
      ,[Servizio]
      ,[Categoria]
      ,[NomeCliente]
      ,[DescrizioneProduttore]
      ,[IndirizzoImpiantoProduttore]
      ,[LocalitaImpiantoProduttore]
      ,[Autista]
      ,[Operatore]
      ,[Mezzo]
      ,[Rimorchio]
      ,[DescrizioneDestinatario]
      ,[IndirizzoImpiantoDestinatario]
      ,[LocalitaImpiantoDestinatario]
      ,[DescrizioneIntermediario]
      ,[IndirizzoImpiantoIntermediario]
      ,[LocalitaImpiantoIntermediario]
      ,[DescrizioneIntermediario1]
      ,[IndirizzoImpiantoIntermediario1]
      ,[LocalitaImpiantoIntermediario1]
      ,CASE WHEN [CodiceCer] IS NULL THEN CodiceErp ELSE CodiceCer END CodiceCer
      ,CASE WHEN [DescrizioneRifiuto] IS NULL THEN DenominazioneEstesa ELSE DescrizioneRifiuto END DescrizioneRifiuto
      ,[Operazione]
      ,[NumMov]
      ,[IDMOV] IdMov
      ,CAST([QUATON] as float) Quaton
      ,[TARGA] Targa
      ,[DTREG] DtReg
      ,Annullato
      ,Completo
      ,Confermato
	  ,FaseAnnullata
      ,CAST(0 as bit) Disabled
	  from [20.82.75.6].SUPPORT.dbo.[ViewOdsReport] 
GO


