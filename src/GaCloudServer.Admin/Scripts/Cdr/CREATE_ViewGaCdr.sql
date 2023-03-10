CREATE VIEW [dbo].[ViewGaCdrConferimenti]
AS
SELECT        GaCdrConferimenti.Id, GaCdrConferimenti.Data, GaCdrCentri.Centro, GaCdrCers.Cer, GaCdrCersDettagli.Descrizione AS CerDettaglio, GaCdrConferimenti.Ditta, GaCdrConferimenti.Peso, GaCdrConferimenti.Quantita, 
                         GaCdrCers.Imm, CONCAT(AUTH.LastName,' ',AUTH.FirstName) AS UtenteRegistrazione, GaCdrConferimenti.Targa, GaCdrConferimenti.Note, GaCdrConferimenti.Disabled, GaCdrConferimenti.CdrUtenteId, 
						 ViewGaBackOfficeComuni.Descrizione AS Comune,
						 UTENZE.RagSo RagioneSociale,UTENZE.NumCon,GaCdrConferimenti.Partita Partita,UTENZE.CodFis CfPiva
FROM            GaCdrConferimenti INNER JOIN
                         GaCdrCers ON GaCdrConferimenti.CdrCerId = GaCdrCers.Id INNER JOIN
                         GaCdrCersDettagli ON GaCdrConferimenti.CdrCerDettaglioId = GaCdrCersDettagli.Id INNER JOIN
                         IdentityServerAdmin.dbo.Users AUTH ON GaCdrConferimenti.UserId = AUTH.Id COLLATE DATABASE_DEFAULT INNER JOIN
                         GaCdrCentri ON GaCdrConferimenti.CdrCentroId = GaCdrCentri.Id LEFT OUTER JOIN
                         dbo.ViewGaBackOfficeComuni ON  CAST(dbo.GaCdrConferimenti.CdrComuneId AS VARCHAR) COLLATE DATABASE_DEFAULT = CAST(dbo.ViewGaBackOfficeComuni.CodAzi AS VARCHAR) LEFT OUTER JOIN
						 dbo.ViewGaBackOfficeUtenze UTENZE ON GaCdrConferimenti.NumCon collate database_default  = UTENZE.NumCon and GaCdrConferimenti.CdrComuneId collate database_default =UTENZE.CpAzi
GO

CREATE VIEW [dbo].[ViewGaCdrRichiesteViaggi]
AS
SELECT        dbo.GaCdrRichiesteViaggi.Id, dbo.GaCdrRichiesteViaggi.Id AS Numero, dbo.GaCdrRichiesteViaggi.Data, dbo.GaCdrCentri.Id AS CentroId, dbo.GaCdrCentri.Centro, dbo.GaCdrCers.Descrizione AS Cer, dbo.GaCdrCers.Imm, 
                         dbo.GaCdrRichiesteViaggi.PesoPresunto, dbo.GaCdrRichiesteViaggi.PesoDestino, dbo.GaCdrRichiesteViaggi.DataChiusura, dbo.GaCdrStatiRichieste.Descrizione AS StatoRichiesta, 
                         dbo.GaCdrStatiRichieste.Id AS StatoRichiestaId, CAST('false' AS bit) AS Disabled, dbo.PrivateViewIdentityServerAdminUserList.FullName AS Richiedente, dbo.GaCdrRichiesteViaggi.Inviata, dbo.GaCdrRichiesteViaggi.Note,dbo.GaCdrRichiesteViaggi.UserId
FROM            dbo.GaCdrRichiesteViaggi INNER JOIN
                         dbo.GaCdrStatiRichieste ON dbo.GaCdrRichiesteViaggi.CdrStatoRichiestaId = dbo.GaCdrStatiRichieste.Id INNER JOIN
                         dbo.GaCdrCers ON dbo.GaCdrRichiesteViaggi.CdrCerId = dbo.GaCdrCers.Id INNER JOIN
                         dbo.GaCdrCentri ON dbo.GaCdrRichiesteViaggi.CdrCentroId = dbo.GaCdrCentri.Id INNER JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.GaCdrRichiesteViaggi.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id COLLATE DATABASE_DEFAULT
GO

CREATE VIEW [dbo].[ViewGaCdrUtenti]
                AS
                SELECT        dbo.GaCdrUtenti.Id, dbo.GaCdrUtenti.RagioneSociale, dbo.GaCdrUtenti.CfPiva, dbo.GaCdrComuni.Comune, dbo.GaCdrUtenti.Indirizzo, CASE WHEN Ditta = 'true' THEN 'SI' ELSE 'NO' END AS Ditta, 
                                         CASE WHEN InserimentoUtente = 'True' THEN 'SI' ELSE 'NO' END AS InserimentoUtente, CASE WHEN Approvato = 'True' THEN 'SI' ELSE 'NO' END AS Approvato, dbo.GaCdrUtenti.Disabled
                FROM            dbo.GaCdrComuni INNER JOIN
                                         dbo.GaCdrUtenti ON dbo.GaCdrComuni.Id = dbo.GaCdrUtenti.CdrComuneId
GO

CREATE VIEW [dbo].[PrivateViewGaCdrCersList]
                AS
                SELECT        dbo.GaCdrCentri.Id AS CdrId, dbo.GaCdrCentri.Centro, dbo.GaCdrCers.Id, dbo.GaCdrCers.Descrizione,dbo.GaCdrCers.Imm
                FROM            dbo.GaCdrCentri CROSS JOIN
                                         dbo.GaCdrCers
GO

CREATE VIEW [dbo].[PrivateViewGaCdrCersOnCentri]
AS
SELECT        dbo.GaCdrCentri.Id, dbo.GaCdrCentri.Centro, dbo.GaCdrCers.Cer, dbo.GaCdrCersDettagli.Descrizione
FROM            dbo.GaCdrCersOnCentri INNER JOIN
                         dbo.GaCdrCers ON dbo.GaCdrCersOnCentri.CdrCerId = dbo.GaCdrCers.Id INNER JOIN
                         dbo.GaCdrCersDettagli ON dbo.GaCdrCers.Id = dbo.GaCdrCersDettagli.CdrCerId INNER JOIN
                         dbo.GaCdrCentri ON dbo.GaCdrCersOnCentri.CdrCentroId = dbo.GaCdrCentri.Id
GO

CREATE VIEW [dbo].[PrivateViewGaCdrComuniList]
                AS
                SELECT        dbo.GaCdrCentri.Id AS CentroId, dbo.GaCdrCentri.Centro, dbo.GaCdrComuni.Id AS ComuneId, dbo.GaCdrComuni.Comune
                FROM            dbo.GaCdrCentri CROSS JOIN
                                         dbo.GaCdrComuni
GO

CREATE VIEW [dbo].[ViewGaCdrCersOnCentri]
                AS
                SELECT        dbo.PrivateViewGaCdrCersList.CdrId AS Id, dbo.PrivateViewGaCdrCersList.CdrId AS CentroId, dbo.PrivateViewGaCdrCersList.Id AS CerId, dbo.PrivateViewGaCdrCersList.Descrizione AS Cer, 
                                         CAST(CASE WHEN gacdrCersOnCentri.Id IS NULL THEN 'false' ELSE 'true' END AS bit) AS Abilitato, dbo.PrivateViewGaCdrCersList.Imm, CAST('false' AS bit) AS Disabled
                FROM            dbo.PrivateViewGaCdrCersList LEFT OUTER JOIN
                                         dbo.GaCdrCersOnCentri ON dbo.PrivateViewGaCdrCersList.CdrId = dbo.GaCdrCersOnCentri.CdrCentroId AND dbo.PrivateViewGaCdrCersList.Id = dbo.GaCdrCersOnCentri.CdrCerId
GO

CREATE VIEW [dbo].[ViewGaCdrComuni]
                AS
                SELECT        Id, Comune AS Descrizione, Disabled
                FROM            dbo.GaCdrComuni
GO

CREATE VIEW [dbo].[ViewGaCdrComuniOnCentri]
                AS
                SELECT        dbo.PrivateViewGaCdrComuniList.CentroId AS Id, dbo.PrivateViewGaCdrComuniList.CentroId, dbo.PrivateViewGaCdrComuniList.ComuneId, dbo.PrivateViewGaCdrComuniList.Comune, 
                                         CAST(CASE WHEN gacdrcomuniOnCentri.Id IS NULL THEN 'false' ELSE 'true' END AS bit) AS Abilitato, CAST('false' AS bit) AS Disabled
                FROM            dbo.PrivateViewGaCdrComuniList LEFT OUTER JOIN
                                         dbo.GaCdrComuniOnCentri ON dbo.PrivateViewGaCdrComuniList.ComuneId = dbo.GaCdrComuniOnCentri.CdrComuneId AND dbo.PrivateViewGaCdrComuniList.CentroId = dbo.GaCdrComuniOnCentri.CdrCentroId
GO