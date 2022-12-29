CREATE VIEW [dbo].[ViewGaMezziCDPACI]
AS
SELECT *
FROM     (SELECT dbo.GaMezziDocumenti.MezziVeicoloId AS Mezzi, dbo.GaMezziDocumenti.Descrizione AS TIPO, dbo.GaMezziDocumenti.FileId AS DOC
                    FROM      dbo.GaMezziDocumenti) AS s PIVOT (Max(DOC) FOR TIPO IN (CDP, CDPD)) AS pvt
GO

CREATE VIEW [dbo].[ViewGaMezziVeicoli]
AS
SELECT        dbo.GaMezziVeicoli.Id, dbo.GaMezziVeicoli.Targa, dbo.GaMezziTipi.Descrizione AS Tipo, dbo.GaMezziProprietari.Descrizione AS Proprietario, dbo.GlobalSedi.Descrizione AS Cantiere, dbo.GaMezziVeicoli.AlboGestori, 
                            dbo.GaMezziAlimentazioni.Descrizione AS Alimentazione, dbo.GaMezziPatenti.Descrizione AS Patente, dbo.GaMezziClassi.Descrizione AS Euro, dbo.GaMezziVeicoli.NumeroTelaio, dbo.GaMezziVeicoli.PortataKg, 
                            dbo.GaMezziVeicoli.MassaKg, dbo.GaMezziVeicoli.AnnoImmatricolazione, dbo.GaMezziVeicoli.Ce, dbo.GaMezziVeicoli.ManualeUsoManutenzione, dbo.GaMezziVeicoli.CatalogoRicambi, dbo.GaMezziVeicoli.Garanzia, dbo.GaMezziVeicoli.Note, 
                            CAST(CASE WHEN CDP IS NULL THEN 'false' ELSE 'true' END AS bit) AS CDP, CAST(CASE WHEN CDPD IS NULL THEN 'false' ELSE 'true' END AS bit) AS CDPD, dbo.GaMezziVeicoli.Dismesso,dbo.GaMezziVeicoli.DismessoData, dbo.GaMezziVeicoli.ScadenzaContratto, dbo.GaMezziVeicoli.Disabled
FROM            dbo.GaMezziVeicoli INNER JOIN
                            dbo.GaMezziTipi ON dbo.GaMezziVeicoli.MezziTipoId = dbo.GaMezziTipi.Id INNER JOIN
                            dbo.GlobalSedi ON dbo.GaMezziVeicoli.GlobalSedeId = dbo.GlobalSedi.Id INNER JOIN
                            dbo.GaMezziProprietari ON dbo.GaMezziVeicoli.MezziProprietarioId = dbo.GaMezziProprietari.Id INNER JOIN
                            dbo.GaMezziAlimentazioni ON dbo.GaMezziVeicoli.MezziAlimentazioneId = dbo.GaMezziAlimentazioni.Id INNER JOIN
                            dbo.GaMezziPatenti ON dbo.GaMezziVeicoli.MezziPatenteId = dbo.GaMezziPatenti.Id INNER JOIN
                            dbo.GaMezziClassi ON dbo.GaMezziVeicoli.MezziClasseId = dbo.GaMezziClassi.Id LEFT OUTER JOIN
                            dbo.ViewGaMezziCDPACI ON dbo.GaMezziVeicoli.Id = dbo.ViewGaMezziCDPACI.Mezzi
GO

CREATE VIEW [dbo].[ViewGaMezziDocumenti]
AS
SELECT dbo.GaMezziDocumenti.Id, dbo.GaMezziDocumenti.MezziVeicoloId, dbo.GaMezziVeicoli.Targa, dbo.GaMezziDocumenti.Descrizione, dbo.GaMezziDocumenti.FileId, dbo.GaMezziDocumenti.FileName,dbo.GaMezziDocumenti.Disabled
FROM     dbo.GaMezziDocumenti INNER JOIN
                    dbo.GaMezziVeicoli ON dbo.GaMezziDocumenti.MezziVeicoloId = dbo.GaMezziVeicoli.Id
GO

CREATE VIEW [dbo].[ViewGaMezziScadenze]
AS
SELECT          dbo.GaMezziScadenze.Id, dbo.GaMezziScadenze.MezziVeicoloId, dbo.GaMezziVeicoli.Targa, dbo.GlobalSedi.Descrizione AS Cantiere, dbo.GaMezziScadenzeTipi.Descrizione AS TipoScadenza, 
                dbo.GaMezziScadenze.DataUltimaScadenza, dbo.GaMezziScadenze.DataScadenza, dbo.GaMezziPeriodiScadenze.Descrizione AS PeriodoScadenza, dbo.GaMezziScadenze.Note, CASE WHEN DATEDIFF(day, GETDATE(), 
                DataScadenza) < 0 THEN 'R' WHEN DATEDIFF(day, GETDATE(), DataScadenza) < 30 THEN 'G' ELSE 'V' END AS Stato, dbo.GaMezziScadenze.FileId, dbo.GaMezziScadenze.FileName, dbo.GaMezziVeicoli.Dismesso,dbo.GaMezziScadenze.Disabled
FROM            dbo.GaMezziVeicoli INNER JOIN
                dbo.GlobalSedi ON dbo.GaMezziVeicoli.GlobalSedeId = dbo.GlobalSedi.Id INNER JOIN
                dbo.GaMezziPeriodiScadenze ON dbo.GaMezziVeicoli.MezziPeriodoScadenzaId = dbo.GaMezziPeriodiScadenze.Id INNER JOIN
                dbo.GaMezziScadenze ON dbo.GaMezziVeicoli.Id = dbo.GaMezziScadenze.MezziVeicoloId INNER JOIN
                dbo.GaMezziScadenzeTipi ON dbo.GaMezziScadenze.MezziScadenzaTipoId = dbo.GaMezziScadenzeTipi.Id
GO