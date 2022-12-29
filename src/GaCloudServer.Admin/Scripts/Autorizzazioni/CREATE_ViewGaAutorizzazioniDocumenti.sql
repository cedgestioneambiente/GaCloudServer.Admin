CREATE VIEW [dbo].[ViewGaAutorizzazioniDocumenti]
AS
SELECT        dbo.GaAutorizzazioniDocumenti.Id, dbo.GaAutorizzazioniDocumenti.RagioneSociale, dbo.GaAutorizzazioniDocumenti.Indirizzo, dbo.GaAutorizzazioniDocumenti.Numero, dbo.GaAutorizzazioniDocumenti.DataRilascio, dbo.GaAutorizzazioniDocumenti.DataScadenza, 
                         dbo.GaAutorizzazioniTipi.Descrizione AS AutorizzazioniTipo, CASE WHEN DATEDIFF(day, GETDATE(), DataScadenza) < 0 THEN 'R' WHEN DATEDIFF(day, GETDATE(), DataScadenza) < Preavviso THEN 'G' ELSE 'V' END AS Stato,
                          dbo.GaAutorizzazioniDocumenti.Archiviata, dbo.GaAutorizzazioniDocumenti.Disabled
FROM            dbo.GaAutorizzazioniDocumenti INNER JOIN
                         dbo.GaAutorizzazioniTipi ON dbo.GaAutorizzazioniDocumenti.AutorizzazioniTipoId = dbo.GaAutorizzazioniTipi.Id
GO