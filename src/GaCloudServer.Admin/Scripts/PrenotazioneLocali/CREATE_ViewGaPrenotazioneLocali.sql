USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewGaPrenotazioneLocaliUffici]    Script Date: 16/05/2023 10:53:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewGaPrenotazioneLocaliUffici]
AS
SELECT        dbo.GaPrenotazioneLocaliUffici.Id, dbo.GaPrenotazioneLocaliUffici.Descrizione, dbo.GaPrenotazioneLocaliUffici.Colore, dbo.GaPrenotazioneLocaliSedi.Descrizione AS Sede, dbo.GaPrenotazioneLocaliUffici.Disabled
FROM            dbo.GaPrenotazioneLocaliSedi INNER JOIN
                         dbo.GaPrenotazioneLocaliUffici ON dbo.GaPrenotazioneLocaliSedi.Id = dbo.GaPrenotazioneLocaliUffici.PrenotazioneLocaliSedeId
GO

/****** Object:  View [dbo].[ViewGaPrenotazioneLocaliRegistrazioni]    Script Date: 16/05/2023 11:08:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewGaPrenotazioneLocaliRegistrazioni]
AS
SELECT        dbo.GaPrenotazioneLocaliRegistrazioni.Id, dbo.GaPrenotazioneLocaliRegistrazioni.DataInizio AS start, dbo.GaPrenotazioneLocaliRegistrazioni.DataFine AS [end], dbo.GaPrenotazioneLocaliUffici.Colore AS color, 
                         dbo.GaPrenotazioneLocaliUffici.Colore AS backgroundColor, LEFT(CONVERT(VARCHAR, dbo.GaPrenotazioneLocaliRegistrazioni.DataInizio, 108), LEN(CONVERT(VARCHAR, dbo.GaPrenotazioneLocaliRegistrazioni.DataInizio, 
                         108)) - 3) + N' - ' + LEFT(CONVERT(VARCHAR, dbo.GaPrenotazioneLocaliRegistrazioni.DataFine, 108), LEN(CONVERT(VARCHAR, dbo.GaPrenotazioneLocaliRegistrazioni.DataFine, 108)) - 3) 
                         + N' - ' + dbo.GaPrenotazioneLocaliRegistrazioni.Motivazione AS title, dbo.GaPrenotazioneLocaliRegistrazioni.Disabled
FROM            dbo.GaPrenotazioneLocaliRegistrazioni INNER JOIN
                         dbo.GaPrenotazioneLocaliUffici ON dbo.GaPrenotazioneLocaliRegistrazioni.PrenotazioneLocaliUfficioId = dbo.GaPrenotazioneLocaliUffici.Id
GO