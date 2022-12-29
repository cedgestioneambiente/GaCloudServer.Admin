CREATE VIEW [dbo].[ViewGaSegnalazioniDocumenti]
AS
SELECT        dbo.GaSegnalazioniDocumenti.Id, dbo.GaSegnalazioniTipi.Id AS TipoId, dbo.GaSegnalazioniTipi.Descrizione AS Tipo, dbo.GaSegnalazioniDocumenti.Note, dbo.GaSegnalazioniDocumenti.Longitudine, dbo.GaSegnalazioniDocumenti.Latitudine, 
                         dbo.GaSegnalazioniDocumenti.Indirizzo, dbo.GaSegnalazioniDocumenti.DataOra, dbo.GaSegnalazioniDocumenti.ImgFolder, dbo.GaSegnalazioniDocumenti.UserId, dbo.PrivateViewIdentityServerAdminUserList.FullName AS [User], dbo.GaSegnalazioniStati.Id AS StatoId, 
                         dbo.GaSegnalazioniStati.Descrizione AS Stato, dbo.GaSegnalazioniDocumenti.Sanzione, dbo.GaSegnalazioniDocumenti.NoteSanzione, dbo.GaSegnalazioniDocumenti.NoteGestione, dbo.GaSegnalazioniDocumenti.Disabled
FROM            dbo.GaSegnalazioniDocumenti INNER JOIN
                         dbo.GaSegnalazioniStati ON dbo.GaSegnalazioniDocumenti.SegnalazioniStatoId = dbo.GaSegnalazioniStati.Id INNER JOIN
                         dbo.GaSegnalazioniTipi ON dbo.GaSegnalazioniDocumenti.SegnalazioniTipoId = dbo.GaSegnalazioniTipi.Id LEFT JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.GaSegnalazioniDocumenti.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id
GO