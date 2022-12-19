CREATE VIEW [dbo].[ViewGaContactCenterTicketsMailsInfos] AS
                            SELECT        ContactCenterTicketId, STRING_AGG(CONVERT(nvarchar(MAX), MailAddress), ',') AS Info
                            FROM            dbo.GaContactCenterMailsOnTickets
                            GROUP BY ContactCenterTicketId
GO

CREATE VIEW [dbo].[ViewGaContactCenterTicketsIngombranti]
AS
SELECT        dbo.GaContactCenterTickets.Id, dbo.GaContactCenterTickets.Utente, dbo.GaContactCenterTickets.Via + N' ' + dbo.GaContactCenterTickets.NumCiv AS Indirizzo, dbo.GaContactCenterTickets.Materiali, 
                         dbo.GaContactCenterTickets.ContactCenterTipoRichiestaId, dbo.GaContactCenterTickets.DataEsecuzione, dbo.GaContactCenterTickets.ContactCenterComuneId AS ComuneId, 
                         dbo.GaContactCenterTipiRichieste.Descrizione AS TipoTicket, dbo.GaContactCenterTickets.Disabled
FROM            dbo.GaContactCenterTickets INNER JOIN
                         dbo.GaContactCenterTipiRichieste ON dbo.GaContactCenterTickets.ContactCenterTipoRichiestaId = dbo.GaContactCenterTipiRichieste.Id
WHERE        (dbo.GaContactCenterTipiRichieste.Ingombranti = 1)
GO

CREATE VIEW [dbo].[ViewGaContactCenterTickets]
AS
SELECT        dbo.GaContactCenterTickets.Id, dbo.PrivateViewIdentityServerAdminUserList.FullName AS Richiedente, dbo.GaContactCenterTickets.Disabled, dbo.ViewGaBackOfficeUtenzeGrouped.RagCli AS RagioneSociale, dbo.GaContactCenterTickets.NumCon, dbo.GaContactCenterTickets.Partita, dbo.ViewGaBackOfficeUtenzeGrouped.CodFis AS CfPiva, 
                         dbo.ViewGaBackOfficeComuni.Descrizione AS Comune, dbo.GlobalSedi.Descrizione AS Cantiere, dbo.GaContactCenterStatiRichieste.Descrizione AS Stato, dbo.GaContactCenterProvenienze.Descrizione AS Provenienza, 
                         dbo.GaContactCenterTipiRichieste.Descrizione AS TipoTicket, dbo.GaContactCenterTickets.Via + N'N ' + dbo.GaContactCenterTickets.NumCiv AS Indirizzo, dbo.GaContactCenterTickets.Zona, 
                         dbo.GaContactCenterTickets.DataTicket, dbo.GaContactCenterTickets.EseguitoIl, dbo.GaContactCenterTickets.DataEsecuzione, dbo.GaContactCenterTickets.Materiali, dbo.GaContactCenterTickets.Promemoria, 
                         dbo.GaContactCenterTickets.Inviato, dbo.GaContactCenterTickets.Note1, dbo.GaContactCenterTickets.Note2, dbo.GaContactCenterTickets.Note3, dbo.GaContactCenterTickets.Reclamo, dbo.GaContactCenterTickets.Stampato, 
                         dbo.GaContactCenterTickets.DaFatturare, dbo.GaContactCenterTickets.TelefonoMail, dbo.ViewGaContactCenterTicketsMailsInfos.Info, dbo.GaContactCenterTickets.Id AS Numero, CASE WHEN Ingombranti IS NULL 
                         THEN 'False' ELSE Ingombranti END AS Ingombranti
FROM            dbo.GaContactCenterTickets INNER JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.GaContactCenterTickets.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id COLLATE DATABASE_DEFAULT INNER JOIN
                         dbo.GaContactCenterComuni ON dbo.GaContactCenterTickets.ContactCenterComuneId = dbo.GaContactCenterComuni.Id INNER JOIN
                         dbo.GaContactCenterProvenienze ON dbo.GaContactCenterTickets.ContactCenterProvenienzaId = dbo.GaContactCenterProvenienze.Id INNER JOIN
                         dbo.GaContactCenterStatiRichieste ON dbo.GaContactCenterTickets.ContactCenterStatoRichiestaId = dbo.GaContactCenterStatiRichieste.Id INNER JOIN
                         dbo.GaContactCenterTipiRichieste ON dbo.GaContactCenterTickets.ContactCenterTipoRichiestaId = dbo.GaContactCenterTipiRichieste.Id INNER JOIN
                         dbo.GlobalSedi ON dbo.GaContactCenterTickets.GlobalSedeId = dbo.GlobalSedi.Id INNER JOIN
                         dbo.ViewGaContactCenterTicketsMailsInfos ON dbo.GaContactCenterTickets.Id = dbo.ViewGaContactCenterTicketsMailsInfos.ContactCenterTicketId LEFT OUTER JOIN
                         dbo.ViewGaBackOfficeComuni ON CAST(dbo.GaContactCenterTickets.ContactCenterComuneId AS VARCHAR) COLLATE DATABASE_DEFAULT = CAST(dbo.ViewGaBackOfficeComuni.Id AS VARCHAR) LEFT OUTER JOIN
                         dbo.ViewGaBackOfficeUtenzeGrouped ON CAST(dbo.GaContactCenterTickets.NumCon AS VARCHAR) COLLATE DATABASE_DEFAULT = CAST(dbo.ViewGaBackOfficeUtenzeGrouped.NumCon AS VARCHAR) AND 
                         CAST(dbo.GaContactCenterTickets.Partita AS VARCHAR) COLLATE DATABASE_DEFAULT = CAST(dbo.ViewGaBackOfficeUtenzeGrouped.Partita AS VARCHAR)
GO