CREATE VIEW [dbo].[PrivateViewGaContrattiPermessiList]
                AS
                SELECT        dbo.ViewGaContrattiUtenti.Id, dbo.ViewGaContrattiUtenti.UserName, dbo.GaContrattiPermessi.Id AS PermessoId, dbo.GaContrattiPermessi.Descrizione AS Permesso
                FROM            dbo.GaContrattiPermessi CROSS JOIN
                                         dbo.ViewGaContrattiUtenti
GO