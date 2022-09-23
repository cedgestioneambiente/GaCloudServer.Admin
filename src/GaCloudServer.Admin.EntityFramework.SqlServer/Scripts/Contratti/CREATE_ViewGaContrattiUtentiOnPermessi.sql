CREATE VIEW [dbo].[ViewGaContrattiUtentiOnPermessi]
AS
SELECT        ROW_NUMBER() OVER (ORDER BY UserName DESC) AS Id,dbo.PrivateViewGaContrattiPermessiList.Id AS UtenteId, dbo.PrivateViewGaContrattiPermessiList.UserName AS Utente, dbo.PrivateViewGaContrattiPermessiList.PermessoId, dbo.PrivateViewGaContrattiPermessiList.Permesso, 
                         CAST(CASE WHEN GaContrattiUtentiOnPermessi.Id IS NULL THEN 'false' ELSE 'true' END AS bit) AS Abilitato, CAST('False' AS bit) AS Disabled
FROM            dbo.PrivateViewGaContrattiPermessiList LEFT OUTER JOIN
                         dbo.GaContrattiUtentiOnPermessi ON CAST(dbo.PrivateViewGaContrattiPermessiList.Id AS VARCHAR) = CAST(dbo.GaContrattiUtentiOnPermessi.UtenteId AS VARCHAR) COLLATE DATABASE_DEFAULT AND 
                         CAST(dbo.PrivateViewGaContrattiPermessiList.PermessoId AS VARCHAR) = CAST(dbo.GaContrattiUtentiOnPermessi.ContrattiPermessoId AS VARCHAR) COLLATE DATABASE_DEFAULT
GO