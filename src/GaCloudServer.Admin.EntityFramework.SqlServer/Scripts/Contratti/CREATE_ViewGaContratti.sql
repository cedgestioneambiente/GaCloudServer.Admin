CREATE VIEW [dbo].[ViewGaContrattiDocumenti]
AS
SELECT   dbo.GaContrattiDocumenti.Id, dbo.GaContrattiDocumenti.ContrattiFornitoreId, dbo.GaContrattiDocumenti.Numero, dbo.GaContrattiDocumenti.Descrizione, 
                         dbo.GaContrattiDocumenti.Faldone, dbo.GaContrattiDocumenti.DataScadenza, dbo.GaContrattiModalitas.Descrizione AS Modalita, dbo.GaContrattiServizi.Descrizione AS Servizio, 
                         dbo.GaContrattiTipologie.Descrizione AS Tipologia, dbo.GaContrattiDocumenti.FileId, dbo.GaContrattiDocumenti.FileName, CASE WHEN DATEDIFF(day, GETDATE(), DataScadenza) 
                         < 0 THEN 'R' WHEN DATEDIFF(day, GETDATE(), DataScadenza) < SogliaAvviso THEN 'G' ELSE 'V' END AS Stato, dbo.GaContrattiDocumenti.Archiviato, 
                         dbo.GaContrattiDocumenti.Disabled
FROM         dbo.GaContrattiDocumenti INNER JOIN
                         dbo.GaContrattiModalitas ON dbo.GaContrattiDocumenti.ContrattiModalitaId = dbo.GaContrattiModalitas.Id INNER JOIN
                         dbo.GaContrattiServizi ON dbo.GaContrattiDocumenti.ContrattiServizioId = dbo.GaContrattiServizi.Id INNER JOIN
                         dbo.GaContrattiTipologie ON dbo.GaContrattiDocumenti.ContrattiTipologiaId = dbo.GaContrattiTipologie.Id
GO

CREATE VIEW [dbo].[ViewGaContrattiDocumentiList]
AS
SELECT   dbo.GaContrattiDocumenti.Id, dbo.GaContrattiDocumenti.ContrattiFornitoreId, dbo.GaContrattiDocumenti.Numero, dbo.GaContrattiDocumenti.Faldone, 
                         dbo.GaContrattiFornitori.RagioneSociale, dbo.GaContrattiDocumenti.Descrizione, dbo.GaContrattiDocumenti.CodiceCig, dbo.GaContrattiTipologie.Descrizione AS Tipologia, 
                         dbo.GaContrattiDocumenti.DataScadenza, dbo.GaContrattiModalitas.Descrizione AS Modalita, dbo.GaContrattiDocumenti.FileId, dbo.GaContrattiDocumenti.FileName, 
                         CASE WHEN DATEDIFF(day, GETDATE(), DataScadenza) < 0 THEN 'R' WHEN DATEDIFF(day, GETDATE(), DataScadenza) < SogliaAvviso THEN 'G' ELSE 'V' END AS Stato, 
                         dbo.GaContrattiTipologie.Id AS TipologiaId, dbo.GaContrattiDocumenti.Archiviato, dbo.GaContrattiDocumenti.Disabled
FROM         dbo.GaContrattiDocumenti INNER JOIN
                         dbo.GaContrattiFornitori ON dbo.GaContrattiDocumenti.ContrattiFornitoreId = dbo.GaContrattiFornitori.Id INNER JOIN
                         dbo.GaContrattiModalitas ON dbo.GaContrattiDocumenti.ContrattiModalitaId = dbo.GaContrattiModalitas.Id INNER JOIN
                         dbo.GaContrattiServizi ON dbo.GaContrattiDocumenti.ContrattiServizioId = dbo.GaContrattiServizi.Id INNER JOIN
                         dbo.GaContrattiTipologie ON dbo.GaContrattiDocumenti.ContrattiTipologiaId = dbo.GaContrattiTipologie.Id
GO

CREATE VIEW [dbo].[ViewGaContrattiNumeratori]
AS
SELECT   ISNULL(c.Id, - 9999) AS Id, c.Numero + 1 AS start, CAST('False' AS bit) AS Disabled
FROM         dbo.GaContrattiDocumenti AS c LEFT OUTER JOIN
                         dbo.GaContrattiDocumenti AS r ON c.Numero + 1 = r.Numero
WHERE     (r.Numero IS NULL)
GO

CREATE VIEW [dbo].[ViewGaContrattiUtenti]
AS
SELECT    ROW_NUMBER() OVER(ORDER BY Username DESC) AS Id,  IdentityServerAdmin.dbo.Users.Id AS UtenteId,  IdentityServerAdmin.dbo.Users.UserName, CAST('False' AS bit) AS Disabled
FROM          IdentityServerAdmin.dbo.Users INNER JOIN
                          IdentityServerAdmin.dbo.UserRoles ON  IdentityServerAdmin.dbo.Users.Id =  IdentityServerAdmin.dbo.UserRoles.UserId INNER JOIN
                          IdentityServerAdmin.dbo.Roles ON  IdentityServerAdmin.dbo.UserRoles.RoleId =  IdentityServerAdmin.dbo.Roles.Id
WHERE     ( IdentityServerAdmin.dbo.Roles.Name = N'GaContrattiRO') OR
                         ( IdentityServerAdmin.dbo.Roles.Name = N'GaContrattiRW')
GO

CREATE VIEW [dbo].[PrivateViewGaContrattiPermessiList]
                AS
                SELECT        dbo.ViewGaContrattiUtenti.Id, dbo.ViewGaContrattiUtenti.UserName, dbo.GaContrattiPermessi.Id AS PermessoId, dbo.GaContrattiPermessi.Descrizione AS Permesso
                FROM            dbo.GaContrattiPermessi CROSS JOIN
                                         dbo.ViewGaContrattiUtenti
GO

CREATE VIEW [dbo].[ViewGaContrattiUtentiOnPermessi]
AS
SELECT        ROW_NUMBER() OVER (ORDER BY UserName DESC) AS Id, CAST(dbo.PrivateViewGaContrattiPermessiList.Id AS VARCHAR) AS UtenteId, dbo.PrivateViewGaContrattiPermessiList.UserName AS Utente, 
dbo.PrivateViewGaContrattiPermessiList.PermessoId, dbo.PrivateViewGaContrattiPermessiList.Permesso, CAST(CASE WHEN GaContrattiUtentiOnPermessi.Id IS NULL THEN 'false' ELSE 'true' END AS bit) AS Abilitato, CAST('False' AS bit) 
AS Disabled
FROM            dbo.PrivateViewGaContrattiPermessiList LEFT OUTER JOIN
                         dbo.GaContrattiUtentiOnPermessi ON CAST(dbo.PrivateViewGaContrattiPermessiList.Id AS VARCHAR) = CAST(dbo.GaContrattiUtentiOnPermessi.UtenteId AS VARCHAR) COLLATE DATABASE_DEFAULT AND 
                         CAST(dbo.PrivateViewGaContrattiPermessiList.PermessoId AS VARCHAR) = CAST(dbo.GaContrattiUtentiOnPermessi.ContrattiPermessoId AS VARCHAR) COLLATE DATABASE_DEFAULT
GO