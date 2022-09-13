CREATE VIEW [dbo].[PrivateViewGaCdrCersOnCentri]
AS
SELECT        dbo.GaCdrCentri.Id, dbo.GaCdrCentri.Centro, dbo.GaCdrCers.Cer, dbo.GaCdrCersDettagli.Descrizione
FROM            dbo.GaCdrCersOnCentri INNER JOIN
                         dbo.GaCdrCers ON dbo.GaCdrCersOnCentri.CdrCerId = dbo.GaCdrCers.Id INNER JOIN
                         dbo.GaCdrCersDettagli ON dbo.GaCdrCers.Id = dbo.GaCdrCersDettagli.CdrCerId INNER JOIN
                         dbo.GaCdrCentri ON dbo.GaCdrCersOnCentri.CdrCentroId = dbo.GaCdrCentri.Id
GO