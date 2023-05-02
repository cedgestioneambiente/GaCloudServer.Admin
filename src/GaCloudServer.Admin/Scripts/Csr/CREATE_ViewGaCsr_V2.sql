USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewGaCdrConferimenti]    Script Date: 17/04/2023 11:45:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP VIEW IF EXISTS [dbo].[ViewGaCsrCodiciCers]
GO
DROP VIEW IF EXISTS [dbo].[ViewGaCsrRegistrazioni]
GO


CREATE VIEW [dbo].[ViewGaCsrCodiciCers]
                    AS
                    SELECT [Id]
                          ,CONCAT([Codice],' - ',[Descrizione]) as Descrizione,CASE WHEN (dbo.GaCsrCodiciCers.Modalita IS NULL) THEN 'ND' ELSE dbo.GaCsrCodiciCers.Modalita END AS Modalita
                          ,[Disabled]
                      FROM dbo.GaCsrCodiciCers
GO

CREATE VIEW [dbo].[ViewGaCsrRegistrazioni]
AS
SELECT        dbo.GaCsrRegistrazioni.Id, dbo.GaCsrRegistrazioni.Data, dbo.GaCsrComuni.Descrizione AS Comune, dbo.GaCsrTrasportatori.RagioneSociale AS Trasportatore, dbo.GaCsrRegistrazioni.PesoTotale, 
                         dbo.GaCsrDestinatari.RagioneSociale AS Destinatario, CAST('False' AS bit) AS Disabled, dbo.ViewGaCsrCodiciCers.Descrizione AS CodiceCer, dbo.ViewGaCsrCodiciCers.Modalita
FROM            dbo.GaCsrRegistrazioni INNER JOIN
                         dbo.GaCsrDestinatari ON dbo.GaCsrRegistrazioni.CsrDestinatarioId = dbo.GaCsrDestinatari.Id INNER JOIN
                         dbo.GaCsrComuni ON dbo.GaCsrRegistrazioni.CsrComuneId = dbo.GaCsrComuni.Id INNER JOIN
                         dbo.GaCsrTrasportatori ON dbo.GaCsrRegistrazioni.CsrTrasportatoreId = dbo.GaCsrTrasportatori.Id INNER JOIN
                         dbo.ViewGaCsrCodiciCers ON dbo.GaCsrRegistrazioni.Id = dbo.ViewGaCsrCodiciCers.Id
GO