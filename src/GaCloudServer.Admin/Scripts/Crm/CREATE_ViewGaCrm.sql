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
DROP VIEW IF EXISTS [dbo].[ViewGaCrmState]
GO
DROP VIEW IF EXISTS [dbo].[ViewGaCrmCausaliType]
GO
DROP VIEW IF EXISTS [dbo].[ViewGaCrmMaster]
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
    SELECT [TYPE] as Id
          ,[DESCRIZIONE] as Descrizione
          ,[ACTIVE] AS Active
          ,CAST(0 AS BIT) Disabled
      FROM [20.82.75.6].[TARI].[dbo].[CRM_STATE]
GO

CREATE VIEW [dbo].[ViewGaCrmTickets]
AS
  SELECT  A.[ID] as Id
      ,A.[PREFIX] as Prefix
	  ,F.DESAZI AS DesAzi
      ,A.[DATA_INS] as DataIns
      ,A.[DATA_ANNULLAMENTO] as DataAnnullamento
      ,A.[ORIGIN_INS] as OriginIns
	  ,B.DESCRIZIONE AS OriginDesc
      ,A.[COGNOME] as Cognome
      ,A.[NOME] as Nome
      ,A.[RAPPRESENTA] as Rappresenta
      ,A.[CODCLI] as CodCLi
      ,A.[NUMCON] as NumCon
      ,A.[NOTA_ANAGRAFICA] as NotaAnagrafica
      ,A.[TELEFONO] as Telefono
      ,A.[CELLULARE] as Cellulare
      ,A.[EMAIL] as Email
      ,A.[PEC] as Pec
      ,A.[CANALE_RISPOSTA] as CanaleRisposta
	  ,G.Descrizione AS CanaleRispostaDesc
      ,A.[STATO] as Stato
	  ,H.DESCRIZIONE AS StatoDesc
      ,A.[DATA_STATO] as DataStato
      ,A.[CODUTE] as CodUte
	  ,D.Name AS CodUteDesc
      ,A.[CODUTEWORK] as CodUteWork
	  ,E.Name AS CodUteWorkDesc
      ,A.[TOTAL_MINUTE_WORK] as TotalMinutiWork
      ,A.[DTSCAD] as DtScad
      ,A.[CODCAUSALE] as CodCausale
      ,A.[DTULAG] as DtUlag
      ,A.[TYPE] as [Type]
	  ,C.Descrizione AS TypeDesc
      ,A.[INDIRIZZO] as Indirizzo
      ,A.[CODPERS] as CodPers
      ,A.[CODCOM] as CodCom
      ,A.[CITTA] as Citta
      ,A.[NUMCIV] as NumCiv
      ,A.[CODFIS] as CodFis
      ,A.[DOMEST] as Domest
      ,A.[CODVIA] as CodVia
      ,A.[TRASMESSO] as Trasmesso
      ,A.[ORATRASM] as OraTrasm
      ,A.[AUTO_CLOSE] as AutoClose
      ,A.[CPROWNUM] as CpRowNum
      FROM [20.82.75.6].[TARI].[dbo].[CRM_MASTER] A
	  INNER JOIN [20.82.75.6].[TARI].[dbo].[CRM_CANALE] B ON A.ORIGIN_INS=B.ID
	  INNER JOIN [20.82.75.6].[TARI].[dbo].[CRM_CAUSALE] C ON A.[TYPE]=C.ID
	  INNER JOIN [20.82.75.6].[TARI].[dbo].[CPUSER] D ON A.CODUTE=D.CODE
	  INNER JOIN [20.82.75.6].[TARI].[dbo].[CPUSER] E ON A.CODUTEWORK=E.CODE
	  INNER JOIN [20.82.75.6].[TARI].[dbo].[CPAZI] F ON A.PREFIX=F.CODAZI
	  INNER JOIN [20.82.75.6].[TARI].[dbo].[CRM_CANALE] G ON A.CANALE_RISPOSTA=G.ID
	  INNER JOIN [20.82.75.6].[TARI].[dbo].[CRM_STATE] H ON A.STATO=H.ID


GO