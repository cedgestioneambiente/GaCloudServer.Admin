CREATE VIEW [dbo].[ViewGaCdrConferimenti]
AS
SELECT        GaCdrConferimenti.Id, GaCdrConferimenti.Data, GaCdrCentri.Centro, GaCdrCers.Cer, GaCdrCersDettagli.Descrizione AS CerDettaglio, GaCdrConferimenti.Ditta, GaCdrConferimenti.Peso, GaCdrConferimenti.Quantita, 
                         GaCdrCers.Imm, PrivateViewAuthServerUserList.FullName AS UtenteRegistrazione, GaCdrConferimenti.Targa, GaCdrConferimenti.Note, GaCdrConferimenti.Disabled, GaCdrConferimenti.CdrUtenteId, 
                         ViewGaBackOfficeUtenzeGrouped.RagCli AS RagioneSociale, GaCdrConferimenti.NumCon, GaCdrConferimenti.Partita, ViewGaBackOfficeUtenzeGrouped.CodFis AS CfPiva, ViewGaBackOfficeComuni.Descrizione AS Comune
FROM            GaCdrConferimenti INNER JOIN
                         GaCdrCers ON GaCdrConferimenti.CdrCerId = GaCdrCers.Id INNER JOIN
                         GaCdrCersDettagli ON GaCdrConferimenti.CdrCerDettaglioId = GaCdrCersDettagli.Id INNER JOIN
                         PrivateViewAuthServerUserList ON GaCdrConferimenti.UserId = PrivateViewAuthServerUserList.Id INNER JOIN
                         GaCdrCentri ON GaCdrConferimenti.CdrCentroId = GaCdrCentri.Id LEFT OUTER JOIN
                         ViewGaBackOfficeComuni ON GaCdrConferimenti.CdrComuneId COLLATE Latin1_General_CI_AS = ViewGaBackOfficeComuni.Id LEFT OUTER JOIN
                         ViewGaBackOfficeUtenzeGrouped ON GaCdrConferimenti.NumCon COLLATE Latin1_General_CI_AS = ViewGaBackOfficeUtenzeGrouped.NumCon AND 
                         GaCdrConferimenti.Partita COLLATE Latin1_General_CI_AS = ViewGaBackOfficeUtenzeGrouped.Partita
GO

CREATE VIEW [dbo].[ViewGaCdrRichiesteViaggi]
AS
SELECT        dbo.GaCdrRichiesteViaggi.Id, dbo.GaCdrRichiesteViaggi.Id AS Numero, dbo.GaCdrRichiesteViaggi.Data, dbo.GaCdrCentri.Id AS CentroId, dbo.GaCdrCentri.Centro, dbo.GaCdrCers.Descrizione AS Cer, dbo.GaCdrCers.Imm, 
                         dbo.GaCdrRichiesteViaggi.PesoPresunto, dbo.GaCdrRichiesteViaggi.PesoDestino, dbo.GaCdrRichiesteViaggi.DataChiusura, dbo.GaCdrStatiRichieste.Descrizione AS StatoRichiesta, 
                         dbo.GaCdrStatiRichieste.Id AS StatoRichiestaId, CAST('false' AS bit) AS Disabled, dbo.PrivateViewAuthServerUserList.FullName AS Richiedente, dbo.GaCdrRichiesteViaggi.Inviata, dbo.GaCdrRichiesteViaggi.Note
FROM            dbo.GaCdrRichiesteViaggi INNER JOIN
                         dbo.GaCdrStatiRichieste ON dbo.GaCdrRichiesteViaggi.CdrStatoRichiestaId = dbo.GaCdrStatiRichieste.Id INNER JOIN
                         dbo.GaCdrCers ON dbo.GaCdrRichiesteViaggi.CdrCerId = dbo.GaCdrCers.Id INNER JOIN
                         dbo.GaCdrCentri ON dbo.GaCdrRichiesteViaggi.CdrCentroId = dbo.GaCdrCentri.Id INNER JOIN
                         dbo.PrivateViewAuthServerUserList ON dbo.GaCdrRichiesteViaggi.UserId = dbo.PrivateViewAuthServerUserList.Id
GO

CREATE VIEW [dbo].[ViewGaCdrUtenti]
                AS
                SELECT        dbo.GaCdrUtenti.Id, dbo.GaCdrUtenti.RagioneSociale, dbo.GaCdrUtenti.CfPiva, dbo.GaCdrComuni.Comune, dbo.GaCdrUtenti.Indirizzo, CASE WHEN Ditta = 'true' THEN 'SI' ELSE 'NO' END AS Ditta, 
                                         CASE WHEN InserimentoUtente = 'True' THEN 'SI' ELSE 'NO' END AS InserimentoUtente, CASE WHEN Approvato = 'True' THEN 'SI' ELSE 'NO' END AS Approvato, dbo.GaCdrUtenti.Disabled
                FROM            dbo.GaCdrComuni INNER JOIN
                                         dbo.GaCdrUtenti ON dbo.GaCdrComuni.Id = dbo.GaCdrUtenti.CdrComuneId
GO