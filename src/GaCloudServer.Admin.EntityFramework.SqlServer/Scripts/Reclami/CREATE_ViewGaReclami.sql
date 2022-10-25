CREATE VIEW [dbo].[ViewGaReclamiDocumenti]
AS
SELECT        dbo.GaReclamiDocumenti.Id, dbo.GaReclamiDocumenti.ReclamiDocumentoId AS NumeroReclamo, dbo.GaReclamiTipiOrigini.Descrizione + N' ' + dbo.GaReclamiDocumenti.OrigineDescrizione AS OrigineReclami, dbo.GaReclamiDocumenti.OrigineData AS OrigineReclamiData, 
                         dbo.GaReclamiMittenti.Descrizione AS Mittente, dbo.GaReclamiDocumenti.Oggetto, dbo.GaReclamiDocumenti.RispostaEntroData, dbo.GaReclamiDocumenti.RispostaInviata AS RispostaInviataData, 
                         dbo.GaReclamiDocumenti.RispostaDefinitiva AS RispostaDefinitivaData, dbo.GaReclamiDocumenti.Fondato, dbo.GaReclamiDocumenti.Infondato, dbo.GaReclamiStati.Descrizione AS Stato, dbo.GlobalSedi.Descrizione AS Cantiere, dbo.GaReclamiDocumenti.Note, 
                         CASE WHEN RispostaInviata <= RispostaEntroData THEN 'V' ELSE 'R' END AS Avanzamento, CAST('false' AS bit) AS Disabled
FROM            dbo.GaReclamiDocumenti INNER JOIN
                         dbo.GlobalSedi ON dbo.GaReclamiDocumenti.GlobalSedeId = dbo.GlobalSedi.Id INNER JOIN
                         dbo.GaReclamiMittenti ON dbo.GaReclamiDocumenti.ReclamiMittenteId = dbo.GaReclamiMittenti.Id INNER JOIN
                         dbo.GaReclamiStati ON dbo.GaReclamiDocumenti.ReclamiStatoId = dbo.GaReclamiStati.Id INNER JOIN
                         dbo.GaReclamiTempiRisposte ON dbo.GaReclamiDocumenti.ReclamiTempoRispostaId = dbo.GaReclamiTempiRisposte.Id INNER JOIN
                         dbo.GaReclamiTipiOrigini ON dbo.GaReclamiDocumenti.ReclamiTipoOrigineId = dbo.GaReclamiTipiOrigini.Id
GO

CREATE VIEW [dbo].[ViewGaReclamiAzioni]
AS

SELECT        dbo.GaReclamiAzioni.Id, dbo.GaReclamiAzioni.ReclamiDocumentoId, CASE WHEN GaReclamiAzioni.Descrizione IS NULL THEN '' ELSE GaReclamiAzioni.Descrizione END AS DescrizioneAzione, dbo.GaReclamiAzioni.Data, 
                         dbo.GaReclamiTipiAzioni.Descrizione AS TipoAzione, dbo.GaReclamiAzioni.Note, dbo.GaReclamiAzioni.Risposta, dbo.GaReclamiAzioni.RispostaDefinitiva, CAST('false' AS bit) AS Disabled
FROM            dbo.GaReclamiAzioni INNER JOIN
                         dbo.GaReclamiTipiAzioni ON dbo.GaReclamiAzioni.ReclamiTipoAzioneId = dbo.GaReclamiTipiAzioni.Id
GO

CREATE VIEW [dbo].[ViewGaReclamiRegistri]
AS
SELECT        dbo.GaReclamiDocumenti.Id, dbo.GaReclamiDocumenti.ReclamiDocumentoId AS Numeratore, dbo.GaReclamiDocumenti.OrigineData AS Data, dbo.GaReclamiMittenti.Descrizione AS Cliente, dbo.GaReclamiDocumenti.Oggetto AS Motivo, 
                         dbo.GaReclamiDocumenti.RispostaEntroData AS RispostaEntro, dbo.GaReclamiDocumenti.RispostaInviata, dbo.GaReclamiDocumenti.RispostaDefinitiva, dbo.GaReclamiDocumenti.Fondato, dbo.GaReclamiStati.Descrizione AS StatoReclamo, dbo.GaReclamiDocumenti.Note, 
                         '' AS AzioniIntraprese, dbo.GaReclamiDocumenti.Infondato, 
                         CASE WHEN RispostaInviata <= RispostaEntroData THEN 'V' ELSE 'R' END AS Avanzamento, CAST('false' AS bit) AS Disabled
FROM            dbo.GaReclamiDocumenti INNER JOIN
                         dbo.GaReclamiMittenti ON dbo.GaReclamiDocumenti.ReclamiMittenteId = dbo.GaReclamiMittenti.Id INNER JOIN
                         dbo.GaReclamiStati ON dbo.GaReclamiDocumenti.ReclamiStatoId = dbo.GaReclamiStati.Id
GO