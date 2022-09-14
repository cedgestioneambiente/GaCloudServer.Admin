CREATE VIEW [dbo].[PrivateViewGaCdrComuniList]
                AS
                SELECT        dbo.GaCdrCentri.Id AS CentroId, dbo.GaCdrCentri.Centro, dbo.GaCdrComuni.Id AS ComuneId, dbo.GaCdrComuni.Comune
                FROM            dbo.GaCdrCentri CROSS JOIN
                                         dbo.GaCdrComuni
GO