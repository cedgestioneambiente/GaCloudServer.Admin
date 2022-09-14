CREATE VIEW [dbo].[ViewGaContrattiUtentiOnPermessi]
                AS
                SELECT        dbo.PrivateViewGaContrattiPermessiList.Id AS UtenteId, dbo.PrivateViewGaContrattiPermessiList.UserName AS Utente, dbo.PrivateViewGaContrattiPermessiList.PermessoId, dbo.PrivateViewGaContrattiPermessiList.Permesso, 
                                         CAST(CASE WHEN GaContrattiUtentiOnPermessi.Id IS NULL THEN 'false' ELSE 'true' END AS bit) AS Abilitato
                FROM            dbo.PrivateViewGaContrattiPermessiList LEFT OUTER JOIN
                                         dbo.GaContrattiUtentiOnPermessi ON CAST(dbo.PrivateViewGaContrattiPermessiList.Id as VARCHAR) = CAST(dbo.GaContrattiUtentiOnPermessi.UtenteId AS VARCHAR) COLLATE DATABASE_DEFAULT  AND 
                                         CAST(dbo.PrivateViewGaContrattiPermessiList.PermessoId AS VARCHAR) = CAST(dbo.GaContrattiUtentiOnPermessi.ContrattiPermessoId AS VARCHAR) COLLATE DATABASE_DEFAULT
GO