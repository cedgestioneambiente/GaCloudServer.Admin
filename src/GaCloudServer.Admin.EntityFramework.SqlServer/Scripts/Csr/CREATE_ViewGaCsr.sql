CREATE VIEW [dbo].[ViewGaCsrCodiciCers]
                    AS
                    SELECT [Id]
                          ,CONCAT([Codice],' - ',[Descrizione],' - ',[Modalita]) as Descrizione
                          ,[Disabled]
                      FROM [Intranet].[dbo].[GaCsrCodiciCers]
GO

CREATE VIEW [dbo].[ViewGaCsrDestinatari]
                    AS
                    SELECT  [Id],
                          CONCAT([RagioneSociale],' - ',[Indirizzo]) as Descrizione
                          ,[Disabled]
                      FROM [Intranet].[dbo].[GaCsrDestinatari]
GO

CREATE VIEW [dbo].[ViewGaCsrProduttori]
                        AS
                        SELECT        Id, RagioneSociale AS Descrizione,Disabled
                        FROM            dbo.GaCsrProduttori
GO

CREATE VIEW [dbo].[ViewGaCsrRegistrazioni]
AS
SELECT        dbo.GaCsrRegistrazioni.Id, dbo.GaCsrRegistrazioni.Data, dbo.GaCsrComuni.Descrizione AS Comune, dbo.ViewGaCsrCodiciCers.Descrizione AS CodiceCer, dbo.GaCsrTrasportatori.RagioneSociale AS Trasportatore, 
                         dbo.GaCsrRegistrazioni.PesoTotale, dbo.GaCsrDestinatari.RagioneSociale AS Destinatario, CAST('False' AS bit) AS Disabled
FROM            dbo.GaCsrRegistrazioni INNER JOIN
                         dbo.GaCsrDestinatari ON dbo.GaCsrRegistrazioni.CsrDestinatarioId = dbo.GaCsrDestinatari.Id INNER JOIN
                         dbo.GaCsrComuni ON dbo.GaCsrRegistrazioni.CsrComuneId = dbo.GaCsrComuni.Id INNER JOIN
                         dbo.GaCsrTrasportatori ON dbo.GaCsrRegistrazioni.CsrTrasportatoreId = dbo.GaCsrTrasportatori.Id INNER JOIN
                         dbo.ViewGaCsrCodiciCers ON dbo.GaCsrRegistrazioni.CsrCodiceCerId = dbo.ViewGaCsrCodiciCers.Id
GO

CREATE VIEW [dbo].[ViewGaCsrRegistrazioniPesi]
                    AS
                    SELECT        dbo.GaCsrRegistrazioniPesi.Id, dbo.GaCsrRegistrazioniPesi.CsrRegistrazioneId AS RegistrazioneId, dbo.GaCsrRegistrazioniPesi.CsrProduttoreId, dbo.GaCsrProduttori.RagioneSociale AS Produttore, 
                                             dbo.GaCsrProduttori.Colore, dbo.GaCsrRegistrazioniPesi.Percentuale, dbo.GaCsrRegistrazioniPesi.Peso, CAST('False' AS bit) AS Disabled
                    FROM            dbo.GaCsrRegistrazioniPesi INNER JOIN
                                             dbo.GaCsrProduttori ON dbo.GaCsrRegistrazioniPesi.CsrProduttoreId = dbo.GaCsrProduttori.Id
GO

CREATE VIEW [dbo].[ViewGaCsrRipartizioniPercentuali]
                    AS
                    SELECT        dbo.GaCsrRipartizioniPercentuali.Id, dbo.GaCsrRipartizioniPercentuali.CsrComuneId AS ComuneId, dbo.GaCsrRipartizioniPercentuali.CsrProduttoreId AS ProduttoreId, dbo.GaCsrProduttori.RagioneSociale AS Produttore, 
                                             dbo.GaCsrRipartizioniPercentuali.Percentuale, CAST('False' AS bit) AS Disabled
                    FROM            dbo.GaCsrRipartizioniPercentuali INNER JOIN
                                             dbo.GaCsrComuni ON dbo.GaCsrRipartizioniPercentuali.CsrComuneId = dbo.GaCsrComuni.Id INNER JOIN
                                             dbo.GaCsrProduttori ON dbo.GaCsrRipartizioniPercentuali.CsrProduttoreId = dbo.GaCsrProduttori.Id
GO

CREATE VIEW[dbo].[ViewGaCsrTrasportatori]
                    AS
                    SELECT[Id],
                          CONCAT([RagioneSociale],' - ',[Indirizzo]) as Descrizione
                          ,[Disabled]
                    FROM[Intranet].[dbo].[GaCsrTrasportatori]
GO

CREATE VIEW [dbo].[ViewGaCsrExports]
AS
SELECT        CAST(0 AS BIGINT) AS Id, MONTH(dbo.GaCsrRegistrazioni.Data) AS MeseId, FORMAT(dbo.GaCsrRegistrazioni.Data, 'MMMM', 'it-IT') AS Mese, YEAR(dbo.GaCsrRegistrazioni.Data) AS AnnoId, dbo.GaCsrCodiciCers.Codice AS Cer, 
                         dbo.GaCsrCodiciCers.Modalita, dbo.GaCsrProduttori.RagioneSociale AS Produttore, dbo.GaCsrDestinatari.RagioneSociale AS Destinatario, dbo.GaCsrDestinatari.Indirizzo AS DestinatarioIndirizzo, 
                         dbo.GaCsrTrasportatori.RagioneSociale AS Trasportatore, dbo.GaCsrTrasportatori.Indirizzo AS TrasportatoreIndirizzo, dbo.GaCsrRegistrazioniPesi.Peso AS PesoTotale, dbo.GaCsrComuni.Id AS ComuneId, 
                         dbo.GaCsrRegistrazioni.Data, dbo.GaCsrComuni.Descrizione AS Cdr, CAST('False' AS bit) AS Disabled
FROM            dbo.GaCsrCodiciCers INNER JOIN
                         dbo.GaCsrRegistrazioniPesi ON dbo.GaCsrCodiciCers.Id = dbo.GaCsrRegistrazioniPesi.CsrCodiceCerId INNER JOIN
                         dbo.GaCsrDestinatari ON dbo.GaCsrRegistrazioniPesi.CsrDestinatarioId = dbo.GaCsrDestinatari.Id INNER JOIN
                         dbo.GaCsrProduttori ON dbo.GaCsrRegistrazioniPesi.CsrProduttoreId = dbo.GaCsrProduttori.Id INNER JOIN
                         dbo.GaCsrTrasportatori ON dbo.GaCsrRegistrazioniPesi.CsrTrasportatoreId = dbo.GaCsrTrasportatori.Id INNER JOIN
                         dbo.GaCsrComuni ON dbo.GaCsrRegistrazioniPesi.CsrComuneId = dbo.GaCsrComuni.Id INNER JOIN
                         dbo.GaCsrRegistrazioni ON dbo.GaCsrRegistrazioniPesi.CsrRegistrazioneId = dbo.GaCsrRegistrazioni.Id
GO