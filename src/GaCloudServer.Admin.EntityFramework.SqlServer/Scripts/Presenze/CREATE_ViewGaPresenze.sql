--CREATE VIEW [dbo].[ViewGaPresenzeResponsabili]
--AS
--    SELECT 

--GO

CREATE VIEW [dbo].[PrivateViewGaPresenzeResponsabiliList]
AS
SELECT   dbo.GaPresenzeResponsabili.Id AS ResponsabileId, dbo.GaPresenzeResponsabili.PersonaleDipendenteId AS DipendenteId, 
                         dbo.PrivateViewIdentityServerAdminUserList.FullName AS Responsabile, dbo.GlobalSettori.Descrizione AS Settore, dbo.PrivateViewIdentityServerAdminUserList.Email, 
                         dbo.GlobalSettori.Id AS SettoreId
FROM         dbo.GaPresenzeResponsabili INNER JOIN
                         dbo.GaPersonaleDipendenti ON dbo.GaPresenzeResponsabili.PersonaleDipendenteId = dbo.GaPersonaleDipendenti.Id INNER JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.GaPersonaleDipendenti.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id CROSS JOIN
                         dbo.GlobalSettori
GO

CREATE VIEW [dbo].[ViewGaPresenzeResponsabiliOnSettori]
AS
SELECT   dbo.PrivateViewGaPresenzeResponsabiliList.ResponsabileId AS Id, dbo.PrivateViewGaPresenzeResponsabiliList.Responsabile, dbo.PrivateViewGaPresenzeResponsabiliList.SettoreId, 
                         dbo.PrivateViewGaPresenzeResponsabiliList.Settore, dbo.PrivateViewGaPresenzeResponsabiliList.Email, CAST(CASE WHEN GaPresenzeResponsabiliOnSettori.Id IS NULL 
                         THEN 'false' ELSE 'true' END AS bit) AS Abilitato, dbo.PrivateViewGaPresenzeResponsabiliList.DipendenteId, CAST('false' AS bit) AS Disabled
FROM         dbo.PrivateViewGaPresenzeResponsabiliList LEFT OUTER JOIN
                         dbo.GaPresenzeResponsabiliOnSettori ON dbo.PrivateViewGaPresenzeResponsabiliList.SettoreId = dbo.GaPresenzeResponsabiliOnSettori.GlobalSettoreId AND 
                         dbo.PrivateViewGaPresenzeResponsabiliList.ResponsabileId = dbo.GaPresenzeResponsabiliOnSettori.PresenzeResponsabileId
GO

CREATE VIEW [dbo].[ViewGaPresenzeResponsabili]
AS
SELECT   dbo.GaPresenzeResponsabili.Id AS ResponsabileId, dbo.GaPresenzeResponsabili.PersonaleDipendenteId, dbo.PrivateViewIdentityServerAdminUserList.FullName AS Utente, 
                         dbo.PrivateViewIdentityServerAdminUserList.Email, dbo.GaPresenzeResponsabili.Disabled
FROM         dbo.GaPresenzeResponsabili INNER JOIN
                         dbo.GaPersonaleDipendenti ON dbo.GaPresenzeResponsabili.PersonaleDipendenteId = dbo.GaPersonaleDipendenti.Id INNER JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.GaPersonaleDipendenti.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id
GO

CREATE VIEW [dbo].[ViewGaPresenzeRichieste]
AS
SELECT   dbo.GaPresenzeRichieste.Id, dbo.GaPresenzeRichieste.DataInizio AS start, dbo.GaPresenzeRichieste.DataFine AS [end], dbo.PrivateViewIdentityServerAdminUserList.FullName AS title, 
                         dbo.GlobalSettori.Id AS SettoreId, dbo.GlobalSettori.Descrizione AS Settore, 
                         CASE WHEN PresenzeStatoRichiestaId = '1' THEN '#ff9800' WHEN PresenzeStatoRichiestaId = '2' THEN '#4caf50' WHEN PresenzeStatoRichiestaId = '3' THEN '#f44336' END AS color, 
                         dbo.GaPresenzeRichieste.Disabled
FROM         dbo.GaPersonaleDipendenti INNER JOIN
                         dbo.GlobalSettori ON dbo.GaPersonaleDipendenti.GlobalSettoreId = dbo.GlobalSettori.Id INNER JOIN
                         dbo.GaPresenzeRichieste ON dbo.GaPersonaleDipendenti.Id = dbo.GaPresenzeRichieste.PersonaleDipendenteId INNER JOIN
                         dbo.GaPresenzeStatiRichieste ON dbo.GaPresenzeRichieste.PresenzeStatoRichiestaId = dbo.GaPresenzeStatiRichieste.Id INNER JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.GaPersonaleDipendenti.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id
GO

CREATE VIEW [dbo].[ViewGaPresenzeRichiesteEventi]
AS
SELECT   dbo.GaPersonaleDipendenti.Id, CASE WHEN PresenzeStatoRichiestaId = '1' THEN 'IN ATTESA' WHEN PresenzeStatoRichiestaId = '2' AND 
                         PresenzeTipoOraId = '11' THEN 'SMART WORKING' ELSE 'ASSENTE' END AS title, dbo.GaPresenzeRichieste.DataInizio AS start, dbo.GaPresenzeRichieste.DataFine AS [end], 
                         dbo.GaPersonaleDipendenti.GlobalSettoreId AS settoreId, dbo.GaPresenzeRichieste.Id AS eventId, dbo.GaPresenzeRichieste.PresenzeStatoRichiestaId, 
                         dbo.PrivateViewIdentityServerAdminUserList.FullName AS resource
FROM         dbo.GaPresenzeRichieste INNER JOIN
                         dbo.GaPersonaleDipendenti ON dbo.GaPresenzeRichieste.PersonaleDipendenteId = dbo.GaPersonaleDipendenti.Id INNER JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.GaPersonaleDipendenti.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id
WHERE     (dbo.GaPresenzeRichieste.PresenzeStatoRichiestaId < 3)
GO

CREATE VIEW [dbo].[ViewGaPresenzeRichiesteMails]
AS
SELECT   dbo.GaPresenzeRichieste.Id, dbo.GaPersonaleDipendenti.Id AS DipendenteId, dbo.PrivateViewIdentityServerAdminUserList.FullName AS Richiedente, 
                         dbo.PrivateViewIdentityServerAdminUserList.Email, dbo.GaPresenzeRichieste.DataInizio, dbo.GaPresenzeRichieste.DataFine, dbo.GaPresenzeStatiRichieste.Descrizione AS Stato, 
                         dbo.GaPresenzeRichieste.PresenzeStatoRichiestaId AS StatoId, dbo.GaPresenzeRichieste.PresenzeTipoOraId AS TipoId, dbo.GaPresenzeTipiOre.Descrizione AS Tipo, 
                         dbo.GlobalSettori.Id AS SettoreId, dbo.GlobalSettori.Descrizione AS Settore, GETDATE() AS Data, dbo.GaPresenzeRichieste.Disabled
FROM         dbo.GlobalSettori INNER JOIN
                         dbo.GaPersonaleDipendenti ON dbo.GlobalSettori.Id = dbo.GaPersonaleDipendenti.GlobalSettoreId INNER JOIN
                         dbo.GaPresenzeRichieste ON dbo.GaPersonaleDipendenti.Id = dbo.GaPresenzeRichieste.PersonaleDipendenteId INNER JOIN
                         dbo.GaPresenzeStatiRichieste ON dbo.GaPresenzeRichieste.PresenzeStatoRichiestaId = dbo.GaPresenzeStatiRichieste.Id INNER JOIN
                         dbo.GaPresenzeTipiOre ON dbo.GaPresenzeRichieste.PresenzeTipoOraId = dbo.GaPresenzeTipiOre.Id INNER JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.GaPersonaleDipendenti.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id
GO

CREATE VIEW [dbo].[ViewGaPresenzeRichiesteRisorse]
AS
SELECT   dbo.GaPresenzeRichieste.PersonaleDipendenteId AS Id, dbo.PrivateViewIdentityServerAdminUserList.FullName AS title, 'green' AS eventColor, 
                         dbo.GaPersonaleDipendenti.GlobalSettoreId, dbo.GaPresenzeRichieste.Disabled
FROM         dbo.GaPresenzeRichieste INNER JOIN
                         dbo.GaPersonaleDipendenti ON dbo.GaPresenzeRichieste.PersonaleDipendenteId = dbo.GaPersonaleDipendenti.Id INNER JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.GaPersonaleDipendenti.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id
WHERE     (dbo.GaPresenzeRichieste.PresenzeStatoRichiestaId < 3)
GO

