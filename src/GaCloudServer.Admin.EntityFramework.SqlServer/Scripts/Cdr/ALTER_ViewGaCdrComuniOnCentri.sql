ALTER VIEW [dbo].[ViewGaCdrComuniOnCentri]
                AS
                SELECT        dbo.PrivateViewGaCdrComuniList.CentroId AS Id, dbo.PrivateViewGaCdrComuniList.CentroId, dbo.PrivateViewGaCdrComuniList.ComuneId, dbo.PrivateViewGaCdrComuniList.Comune, 
                                         CAST(CASE WHEN gacdrcomuniOnCentri.Id IS NULL THEN 'false' ELSE 'true' END AS bit) AS Abilitato, CAST('false' AS bit) AS Disabled
                FROM            dbo.PrivateViewGaCdrComuniList LEFT OUTER JOIN
                                         dbo.GaCdrComuniOnCentri ON dbo.PrivateViewGaCdrComuniList.ComuneId = dbo.GaCdrComuniOnCentri.CdrComuneId AND dbo.PrivateViewGaCdrComuniList.CentroId = dbo.GaCdrComuniOnCentri.CdrCentroId
GO