CREATE VIEW [dbo].[ViewGaPresenzeResponsabili]
AS
SELECT        dbo.GaPresenzeResponsabili.Id, dbo.ViewGaPersonaleDipendenti.CognomeNome, dbo.GaPresenzeResponsabili.PersonaleDipendenteId DipendenteId, dbo.GaPresenzeResponsabili.Disabled
FROM            dbo.GaPresenzeResponsabili LEFT OUTER JOIN
                         dbo.ViewGaPersonaleDipendenti ON dbo.GaPresenzeResponsabili.PersonaleDipendenteId = dbo.ViewGaPersonaleDipendenti.Id

GO


CREATE VIEW [dbo].[ViewGaPresenzeResponsabiliOnSettori]
AS
SELECT A.*,
CAST(CASE WHEN B.Id IS NULL THEN 'false' ELSE 'true' END as BIT) Abilitato,CAST(0 as BIT) Disabled
FROM(
SELECT A.Id,PersonaleDipendenteId,B.CognomeNome,B.UserId,C.Id GlobalIdSettore,C.Descrizione Settore
FROM [dbo].[GaPresenzeResponsabili] A
LEFT JOIN ViewGaPersonaleDipendenti B ON A.PersonaleDipendenteId=B.Id
CROSS JOIN dbo.GlobalSettori C) A
LEFT OUTER JOIN dbo.GaPresenzeResponsabiliOnSettori B 
ON A.GlobalIdSettore=B.GlobalSettoreId AND A.Id=B.PresenzeResponsabileId
GO

CREATE VIEW [dbo].[ViewGaPresenzeDipendenti]
AS
SELECT        ISNULL(dbo.GaPresenzeDipendenti.Id, 0) AS Id, dbo.ViewGaPersonaleDipendenti.Id AS PersonaleDipendenteId, dbo.ViewGaPersonaleDipendenti.UserId, dbo.ViewGaPersonaleDipendenti.CognomeNome, 
                         dbo.ViewGaPersonaleDipendenti.Sede, dbo.ViewGaPersonaleDipendenti.SedeId, dbo.ViewGaPersonaleDipendenti.Settore, dbo.ViewGaPersonaleDipendenti.SettoreId, ISNULL(dbo.GaPresenzeDipendenti.HhFerie, 0) AS HhFerie, 
                         ISNULL(dbo.GaPresenzeDipendenti.HhPermessiCcnl, 0) AS HhPermessiCcnl, ISNULL(dbo.GaPresenzeDipendenti.HhRecupero, 0) AS HhRecupero, CASE WHEN (dbo.GaPresenzeDipendenti.Id IS NULL OR
                         GaPresenzeDipendenti.Disabled = 'True') THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS Enabled, CASE WHEN (dbo.GaPresenzeDipendenti.Id IS NULL OR
                         GaPresenzeDipendenti.Disabled = 'True') THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END AS Disabled, ISNULL(dbo.GaPresenzeProfili.Descrizione, 'NESSUN PROFILO IMPOSTATO') AS Profilo, 
                         ISNULL(dbo.GaPresenzeOrari.Descrizione, 'NESSUN ORARIO IMPOSTATO') AS Orario
FROM            dbo.GaPresenzeOrari RIGHT OUTER JOIN
                         dbo.GaPresenzeDipendenti ON dbo.GaPresenzeOrari.Id = dbo.GaPresenzeDipendenti.PresenzeOrarioId LEFT OUTER JOIN
                         dbo.GaPresenzeProfili ON dbo.GaPresenzeDipendenti.PresenzeProfiloId = dbo.GaPresenzeProfili.Id RIGHT OUTER JOIN
                         dbo.ViewGaPersonaleDipendenti ON dbo.GaPresenzeDipendenti.PersonaleDipendenteId = dbo.ViewGaPersonaleDipendenti.Id
GO


CREATE VIEW [dbo].[ViewGaPresenzeOrariGiornate]
AS
SELECT        Id, PresenzeOrarioId, 
                         CASE WHEN Giorno = '1' THEN 'LUN' WHEN Giorno = '2' THEN 'MAR' WHEN Giorno = '3' THEN 'MERC' WHEN Giorno = '4' THEN 'GIOV' WHEN Giorno = '5' THEN 'VEN' WHEN Giorno = '6' THEN 'SAB' WHEN Giorno = '7' THEN 'DOM'
                          END AS GiornoDescrizione, OraInizio, OraFine, PausaInizio, PausaFine, Disabled
FROM            dbo.GaPresenzeOrariGiornate

GO

CREATE VIEW [dbo].[ViewGaPresenzeRichieste]
AS
SELECT        dbo.GaPresenzeRichieste.Id, dbo.GaPresenzeRichieste.DataInizio AS Start, dbo.GaPresenzeRichieste.DataFine AS [End], dbo.ViewGaPresenzeDipendenti.CognomeNome AS Title, dbo.ViewGaPresenzeDipendenti.SettoreId, 
                         dbo.ViewGaPresenzeDipendenti.Settore, CASE WHEN PresenzeStatoRichiestaId = '1' THEN '#4caf50' WHEN PresenzeStatoRichiestaId = '2' THEN '#ff9800' WHEN PresenzeStatoRichiestaId = '3' THEN '#f44336' END AS Color, 
                         dbo.ViewGaPresenzeDipendenti.UserId, CAST(0 AS BIT) AS Disabled
FROM            dbo.GaPresenzeRichieste INNER JOIN
                         dbo.ViewGaPresenzeDipendenti ON dbo.GaPresenzeRichieste.PresenzeDipendenteId = dbo.ViewGaPresenzeDipendenti.Id
GO

--CREATE VIEW [dbo].[ViewGaPresenzeResponsabili]
--AS
--SELECT   dbo.GaPresenzeResponsabili.Id AS ResponsabileId, dbo.GaPresenzeResponsabili.PersonaleDipendenteId, dbo.PrivateViewIdentityServerAdminUserList.FullName AS Utente, 
--                         dbo.PrivateViewIdentityServerAdminUserList.Email, dbo.GaPresenzeResponsabili.Disabled
--FROM         dbo.GaPresenzeResponsabili INNER JOIN
--                         dbo.GaPersonaleDipendenti ON dbo.GaPresenzeResponsabili.PersonaleDipendenteId = dbo.GaPersonaleDipendenti.Id INNER JOIN
--                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.GaPersonaleDipendenti.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id
--GO

--CREATE VIEW [dbo].[ViewGaPresenzeRichieste]
--AS
--SELECT   dbo.GaPresenzeRichieste.Id, dbo.GaPresenzeRichieste.DataInizio AS start, dbo.GaPresenzeRichieste.DataFine AS [end], dbo.PrivateViewIdentityServerAdminUserList.FullName AS title, 
--                         dbo.GlobalSettori.Id AS SettoreId, dbo.GlobalSettori.Descrizione AS Settore, 
--                         CASE WHEN PresenzeStatoRichiestaId = '1' THEN '#ff9800' WHEN PresenzeStatoRichiestaId = '2' THEN '#4caf50' WHEN PresenzeStatoRichiestaId = '3' THEN '#f44336' END AS color, 
--                         dbo.GaPresenzeRichieste.Disabled
--FROM         dbo.GaPersonaleDipendenti INNER JOIN
--                         dbo.GlobalSettori ON dbo.GaPersonaleDipendenti.GlobalSettoreId = dbo.GlobalSettori.Id INNER JOIN
--                         dbo.GaPresenzeRichieste ON dbo.GaPersonaleDipendenti.Id = dbo.GaPresenzeRichieste.PersonaleDipendenteId INNER JOIN
--                         dbo.GaPresenzeStatiRichieste ON dbo.GaPresenzeRichieste.PresenzeStatoRichiestaId = dbo.GaPresenzeStatiRichieste.Id INNER JOIN
--                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.GaPersonaleDipendenti.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id
--GO

--CREATE VIEW [dbo].[ViewGaPresenzeRichiesteEventi]
--AS
--SELECT   dbo.GaPersonaleDipendenti.Id, CASE WHEN PresenzeStatoRichiestaId = '1' THEN 'IN ATTESA' WHEN PresenzeStatoRichiestaId = '2' AND 
--                         PresenzeTipoOraId = '11' THEN 'SMART WORKING' ELSE 'ASSENTE' END AS title, dbo.GaPresenzeRichieste.DataInizio AS start, dbo.GaPresenzeRichieste.DataFine AS [end], 
--                         dbo.GaPersonaleDipendenti.GlobalSettoreId AS settoreId, dbo.GaPresenzeRichieste.Id AS eventId, dbo.GaPresenzeRichieste.PresenzeStatoRichiestaId, 
--                         dbo.PrivateViewIdentityServerAdminUserList.FullName AS resource
--FROM         dbo.GaPresenzeRichieste INNER JOIN
--                         dbo.GaPersonaleDipendenti ON dbo.GaPresenzeRichieste.PersonaleDipendenteId = dbo.GaPersonaleDipendenti.Id INNER JOIN
--                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.GaPersonaleDipendenti.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id
--WHERE     (dbo.GaPresenzeRichieste.PresenzeStatoRichiestaId < 3)
--GO

--CREATE VIEW [dbo].[ViewGaPresenzeRichiesteMails]
--AS
--SELECT   dbo.GaPresenzeRichieste.Id, dbo.GaPersonaleDipendenti.Id AS DipendenteId, dbo.PrivateViewIdentityServerAdminUserList.FullName AS Richiedente, 
--                         dbo.PrivateViewIdentityServerAdminUserList.Email, dbo.GaPresenzeRichieste.DataInizio, dbo.GaPresenzeRichieste.DataFine, dbo.GaPresenzeStatiRichieste.Descrizione AS Stato, 
--                         dbo.GaPresenzeRichieste.PresenzeStatoRichiestaId AS StatoId, dbo.GaPresenzeRichieste.PresenzeTipoOraId AS TipoId, dbo.GaPresenzeTipiOre.Descrizione AS Tipo, 
--                         dbo.GlobalSettori.Id AS SettoreId, dbo.GlobalSettori.Descrizione AS Settore, GETDATE() AS Data, dbo.GaPresenzeRichieste.Disabled
--FROM         dbo.GlobalSettori INNER JOIN
--                         dbo.GaPersonaleDipendenti ON dbo.GlobalSettori.Id = dbo.GaPersonaleDipendenti.GlobalSettoreId INNER JOIN
--                         dbo.GaPresenzeRichieste ON dbo.GaPersonaleDipendenti.Id = dbo.GaPresenzeRichieste.PersonaleDipendenteId INNER JOIN
--                         dbo.GaPresenzeStatiRichieste ON dbo.GaPresenzeRichieste.PresenzeStatoRichiestaId = dbo.GaPresenzeStatiRichieste.Id INNER JOIN
--                         dbo.GaPresenzeTipiOre ON dbo.GaPresenzeRichieste.PresenzeTipoOraId = dbo.GaPresenzeTipiOre.Id INNER JOIN
--                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.GaPersonaleDipendenti.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id
--GO

--CREATE VIEW [dbo].[ViewGaPresenzeRichiesteRisorse]
--AS
--SELECT   dbo.GaPresenzeRichieste.PersonaleDipendenteId AS Id, dbo.PrivateViewIdentityServerAdminUserList.FullName AS title, 'green' AS eventColor, 
--                         dbo.GaPersonaleDipendenti.GlobalSettoreId, dbo.GaPresenzeRichieste.Disabled
--FROM         dbo.GaPresenzeRichieste INNER JOIN
--                         dbo.GaPersonaleDipendenti ON dbo.GaPresenzeRichieste.PersonaleDipendenteId = dbo.GaPersonaleDipendenti.Id INNER JOIN
--                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.GaPersonaleDipendenti.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id
--WHERE     (dbo.GaPresenzeRichieste.PresenzeStatoRichiestaId < 3)
--GO

