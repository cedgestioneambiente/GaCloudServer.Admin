/****** Object:  View [dbo].[ViewGaPrenotazioniAuto]    Script Date: 06/10/2022 08:42:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


    CREATE VIEW [dbo].[ViewGaPrenotazioneAutoRegistrazioni]
    AS
    SELECT        dbo.GaPrenotazioneAutoRegistrazioni.Id, dbo.GaPrenotazioneAutoRegistrazioni.DataInizio AS start, dbo.GaPrenotazioneAutoRegistrazioni.DataFine AS [end], LEFT(CONVERT(VARCHAR, dbo.GaPrenotazioneAutoRegistrazioni.DataInizio, 108), 
                                LEN(CONVERT(VARCHAR, dbo.GaPrenotazioneAutoRegistrazioni.DataInizio, 108)) - 3) + N' - ' + LEFT(CONVERT(VARCHAR, dbo.GaPrenotazioneAutoRegistrazioni.DataFine, 108), LEN(CONVERT(VARCHAR, dbo.GaPrenotazioneAutoRegistrazioni.DataFine, 108)) - 3) 
                                + N' - ' + dbo.GaPrenotazioneAutoRegistrazioni.RealeUtilizzatore AS title, dbo.GaPrenotazioneAutoVeicoli.Colore AS color, dbo.GaPrenotazioneAutoVeicoli.Colore AS backgroundColor
    FROM            dbo.GaPrenotazioneAutoRegistrazioni INNER JOIN
                                dbo.GaPrenotazioneAutoVeicoli ON dbo.GaPrenotazioneAutoRegistrazioni.PrenotazioneAutoVeicoloId = dbo.GaPrenotazioneAutoVeicoli.Id
GO

/****** Object:  View [dbo].[ViewGaPrenotazioniAutoVeicoli]    Script Date: 06/10/2022 08:42:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


    CREATE VIEW [dbo].ViewGaPrenotazioneAutoVeicoli
    AS
    SELECT        dbo.GaPrenotazioneAutoVeicoli.Id, dbo.GaPrenotazioneAutoVeicoli.Targa,dbo.GaPrenotazioneAutoVeicoli.Descrizione, dbo.GaPrenotazioneAutoVeicoli.Colore
                , dbo.GaPrenotazioneAutoVeicoli.Weekend, GaPrenotazioneAutoSedi.Descrizione Sede,dbo.GaPrenotazioneAutoVeicoli.Disabled
    FROM            dbo.GaPrenotazioneAutoVeicoli LEFT JOIN
                                dbo.GaPrenotazioneAutoSedi ON dbo.GaPrenotazioneAutoVeicoli.PrenotazioneAutoSedeId = dbo.GaPrenotazioneAutoSedi.Id
GO