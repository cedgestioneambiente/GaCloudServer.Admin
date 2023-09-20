USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewGaContactCenterTickets]    Script Date: 01/06/2023 08:40:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewGaCrmGarbageUtenze]
AS
SELECT *
  FROM [20.82.75.6].[TARI].[dbo].ViewGaCrmGarbageUtenze 

GO

CREATE VIEW [dbo].[ViewGaCrmGarbagePartite]
AS
SELECT *
  FROM [20.82.75.6].[TARI].[dbo].ViewGaCrmGarbagePartite

GO

CREATE VIEW [dbo].[ViewGaCrmGarbageTipologie]
AS
SELECT [Id]
      ,[Descrizione]
      ,[CodArera]
	  ,CAST(0 as BIT) [Disabled]
  FROM [GaCloud].[dbo].[GaContactCenterTipiRichieste]
GO

CREATE VIEW [dbo].[ViewGaCrmGarbageProvenienze]
AS
SELECT [Id]
      ,[Descrizione]
	  ,CAST(0 as BIT) [Disabled]
  FROM [GaCloud].[dbo].[GaContactCenterProvenienze]
GO

CREATE VIEW [dbo].[ViewGaCrmGarbageStati]
AS
SELECT [Id]
      ,[Descrizione]
	  ,CAST(0 as BIT) [Disabled]
  FROM [GaCloud].[dbo].[GaContactCenterStatiRichieste]
GO

CREATE VIEW [dbo].[ViewGaCrmGarbageTicketContactCenter]
AS
SELECT
A.Id,
CONCAT('CC-',A.Id) NUMERO_TICKET,
DataTicket DATA_RICHIESTA
,DataEsecuzione DATA_CHIUSURA
,REPLACE(B.CodAzi,'C','') COD_COMUNE
,CONCAT(A.NumCon,'-',A.Partita) COD_UTENZA
,CASE WHEN D.Tributo IS NULL THEN 'DOM' ELSE D.Tributo END TRIBUTO
,A.Via VIA
,CAST(CASE WHEN PATINDEX('%[0-9]%',A.NumCiv)>0 THEN SUBSTRING(A.NumCiv, PATINDEX('%[0-9]%', A.NumCiv),ISNULL(NULLIF(PATINDEX('%[^0-9]%', SUBSTRING(A.NumCiv, PATINDEX('%[0-9]%',A.NumCiv), LEN(A.NumCiv))), 0) - 1, LEN(A.NumCiv))) ELSE CAST(0 as int) END AS VARCHAR) AS CIVICO
,Zona ZONA
,ContactCenterProvenienzaId COD_PROVENIENZA_RICHIESTA
,ContactCenterTipoRichiestaId COD_TIPO_RICHIESTA
,'' TELEFONO
,'' CELLULARE
,TelefonoMail EMAIL
,'' EMAIL_PEC
,Note1 NOTE_TICKET
,NOTE2 NOTE_CHIUSURA
,ContactCenterStatoRichiestaId COD_STATO_RICHIESTA
,C.FullName CREATO_DA
,C.FullName ASSEGNATO_A
,CAST(0 as BIT) [Disabled]
FROM [GaCloud].[dbo].[GaContactCenterTickets] A
INNER JOIN GaContactCenterComuni B ON A.ContactCenterComuneId=B.Id
INNER JOIN [IdentityServerAdmin].DBO.Users C ON A.UserId=C.Id
LEFT JOIN ViewGaBackOfficeUtenze D ON B.CodAzi=D.CpAzi COLLATE database_default and A.NumCon=d.NumCon COLLATE database_default
WHERE DataTicket >='20230101'
GO

CREATE VIEW [dbo].[ViewGaCrmGarbageTicketMagazzino]
AS
SELECT
A.id
,CONCAT('CRM-',A.Id) NUMERO_TICKET
,DataRichiesta DATA_RICHIESTA
,DataChiusura DATA_CHIUSURA
,CrmEventComuneId COD_COMUNE
,CONCAT(NumCon,'-',Partita) COD_UTENZA
,CASE WHEN Tributo IS NULL THEN 'DOM' ELSE Tributo END TRIBUTO
,Via VIA
,CAST(CASE WHEN PATINDEX('%[0-9]%',A.NumCiv)>0 THEN SUBSTRING(A.NumCiv, PATINDEX('%[0-9]%', A.NumCiv),ISNULL(NULLIF(PATINDEX('%[^0-9]%', SUBSTRING(A.NumCiv, PATINDEX('%[0-9]%',A.NumCiv), LEN(A.NumCiv))), 0) - 1, LEN(A.NumCiv))) ELSE CAST(0 as int) END AS VARCHAR) AS CIVICO
,CodZona ZONA
,ContactCenterProvenienzaId COD_PROVENIENZA_RICHIESTA
,ContactCenterTipoRichiestaId COD_TIPO_RICHIESTA
,Telefono TELEFONO
,Cellulare CELLULARE
,A.Email EMAIL
,EmailPec EMAIL_PEC
,NoteCrm NOTE_TICKET
,NoteOperatore NOTE_CHIUSURA
,ContactCenterStatoRichiestaId COD_STATO_RICHIESTA
,B.FullName CREATO_DA
,REPLACE(C.Name,'AppCrm','') ASSEGNATO_A
,CAST(0 as BIT) [Disabled]
FROM [GaCloud].[dbo].[GaCrmTickets] A
INNER JOIN [IdentityServerAdmin].[dbo].[Users] B ON A.Creator=B.Id
INNER JOIN [IdentityServerAdmin].[dbo].[Roles] C ON A.Assignee=C.Id
GO