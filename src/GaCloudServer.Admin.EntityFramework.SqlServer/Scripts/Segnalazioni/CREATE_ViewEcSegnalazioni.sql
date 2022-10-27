CREATE VIEW [dbo].[ViewEcSegnalazioniDocumenti]
AS
SELECT        dbo.EcSegnalazioniDocumenti.Id, dbo.EcSegnalazioniTipi.Id AS TipoId, dbo.EcSegnalazioniTipi.Descrizione AS Tipo, dbo.EcSegnalazioniDocumenti.Note, dbo.EcSegnalazioniDocumenti.Longitudine, dbo.EcSegnalazioniDocumenti.Latitudine, 
                         dbo.EcSegnalazioniDocumenti.Indirizzo, dbo.EcSegnalazioniDocumenti.DataOra, dbo.EcSegnalazioniDocumenti.ImgFolder, dbo.EcSegnalazioniDocumenti.UserId, dbo.PrivateViewIdentityServerAdminUserList.FullName AS [User], dbo.EcSegnalazioniStati.Id AS StatoId, 
                         dbo.EcSegnalazioniStati.Descrizione AS Stato, dbo.EcSegnalazioniDocumenti.Sanzione, dbo.EcSegnalazioniDocumenti.NoteSanzione, dbo.EcSegnalazioniDocumenti.NoteGestione, dbo.EcSegnalazioniDocumenti.Disabled
FROM            dbo.EcSegnalazioniDocumenti INNER JOIN
                         dbo.EcSegnalazioniStati ON dbo.EcSegnalazioniDocumenti.SegnalazioniStatoId = dbo.EcSegnalazioniStati.Id INNER JOIN
                         dbo.EcSegnalazioniTipi ON dbo.EcSegnalazioniDocumenti.SegnalazioniTipoId = dbo.EcSegnalazioniTipi.Id INNER JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.EcSegnalazioniDocumenti.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id
GO