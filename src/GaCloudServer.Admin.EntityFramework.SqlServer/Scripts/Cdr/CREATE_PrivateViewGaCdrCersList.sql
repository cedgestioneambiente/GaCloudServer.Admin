CREATE VIEW [dbo].[PrivateViewGaCdrCersList]
                AS
                SELECT        dbo.GaCdrCentri.Id AS CdrId, dbo.GaCdrCentri.Centro, dbo.GaCdrCers.Id, dbo.GaCdrCers.Descrizione
                FROM            dbo.GaCdrCentri CROSS JOIN
                                         dbo.GaCdrCers
GO