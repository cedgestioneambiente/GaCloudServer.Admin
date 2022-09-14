CREATE VIEW [dbo].[ViewGaCdrCersOnCentri]
                AS
                SELECT        dbo.PrivateViewGaCdrCersList.CdrId AS Id, dbo.PrivateViewGaCdrCersList.CdrId AS CentroId, dbo.PrivateViewGaCdrCersList.Id AS CerId, dbo.PrivateViewGaCdrCersList.Descrizione AS Cer, 
                                         CAST(CASE WHEN gacdrCersOnCentri.Id IS NULL THEN 'false' ELSE 'true' END AS bit) AS Abilitato, CAST('false' AS bit) AS Disabled
                FROM            dbo.PrivateViewGaCdrCersList LEFT OUTER JOIN
                                         dbo.GaCdrCersOnCentri ON dbo.PrivateViewGaCdrCersList.CdrId = dbo.GaCdrCersOnCentri.CdrCentroId AND dbo.PrivateViewGaCdrCersList.Id = dbo.GaCdrCersOnCentri.CdrCerId
GO