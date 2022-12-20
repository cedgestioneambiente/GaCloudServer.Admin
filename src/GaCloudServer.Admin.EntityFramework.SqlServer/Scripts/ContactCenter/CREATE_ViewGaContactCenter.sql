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
SELECT        GaContactCenterTickets.Id, PrivateViewIdentityServerAdminUserList.FullName AS Richiedente, 
                         CASE WHEN GaContactCenterComuni.CodAzi = 'C00' THEN GaContactCenterTickets.ComuneAltro ELSE GaContactCenterComuni.Descrizione END AS Comune, GaContactCenterTickets.Utente AS RagioneSociale, 
                         GaContactCenterTickets.NumCon, GaContactCenterTickets.Partita, GaContactCenterTickets.CfPiva, GaAziendeListe.DescrizioneBreve AS Cantiere, GaContactCenterStatiRichieste.Descrizione AS Stato, 
                         GaContactCenterProvenienze.Descrizione AS Provenienza, GaContactCenterTipiRichieste.Descrizione AS TipoTicket, CONCAT(GaContactCenterTickets.Via, ', ', GaContactCenterTickets.NumCiv)  AS Indirizzo, 
                         GaContactCenterTickets.Zona, GaContactCenterTickets.DataTicket, GaContactCenterTickets.EseguitoIl, GaContactCenterTickets.DataEsecuzione, GaContactCenterTickets.Materiali, GaContactCenterTickets.Promemoria, 
                         GaContactCenterTickets.Inviato, GaContactCenterTickets.Note1, GaContactCenterTickets.Note2, GaContactCenterTickets.Reclamo, GaContactCenterTickets.Stampato, GaContactCenterTickets.DaFatturare, 
                         GaContactCenterTickets.TelefonoMail, GaContactCenterTickets.Id AS Numero,CASE WHEN Ingombranti IS NULL 
                         THEN 'False' ELSE Ingombranti END AS Ingombranti

FROM            GaContactCenterTickets INNER JOIN
                         PrivateViewIdentityServerAdminUserList ON GaContactCenterTickets.UserId = PrivateViewIdentityServerAdminUserList.Id INNER JOIN
                         GaContactCenterComuni ON GaContactCenterTickets.ContactCenterComuneId = GaContactCenterComuni.Id INNER JOIN
                         GaAziendeListe ON GaContactCenterTickets.AziendeListaId = GaAziendeListe.Id INNER JOIN
                         GaContactCenterStatiRichieste ON GaContactCenterTickets.ContactCenterStatoRichiestaId = GaContactCenterStatiRichieste.Id INNER JOIN
                         GaContactCenterProvenienze ON GaContactCenterTickets.ContactCenterProvenienzaId = GaContactCenterProvenienze.Id INNER JOIN
                         GaContactCenterTipiRichieste ON GaContactCenterTickets.ContactCenterTipoRichiestaId = GaContactCenterTipiRichieste.Id LEFT OUTER JOIN
                         ViewGaContactCenterTicketsMailsInfos ON GaContactCenterTickets.Id = ViewGaContactCenterTicketsMailsInfos.ContactCenterTicketId
GO