USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewGaCdrRichiesteViaggi]    Script Date: 17/04/2023 11:45:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP VIEW IF EXISTS [dbo].[ViewGaCdrRichiesteViaggi]
GO

CREATE VIEW [dbo].[ViewGaCdrRichiesteViaggi]
AS
  SELECT   dbo.GaCdrRichiesteViaggi.Id, dbo.GaCdrRichiesteViaggi.Id AS Numero, dbo.GaCdrRichiesteViaggi.Data, dbo.GaCdrCentri.Id AS CentroId, dbo.GaCdrCentri.Centro, 
                         dbo.GaCdrCers.Descrizione AS Cer, dbo.GaCdrCers.Imm, dbo.GaCdrRichiesteViaggi.PesoPresunto, dbo.GaCdrRichiesteViaggi.PesoDestino, dbo.GaCdrRichiesteViaggi.DataChiusura, 
                         dbo.GaCdrStatiRichieste.Descrizione AS StatoRichiesta, dbo.GaCdrStatiRichieste.Id AS StatoRichiestaId, CAST('false' AS bit) AS Disabled, 
                         dbo.PrivateViewIdentityServerAdminUserList.FullName AS Richiedente, dbo.GaCdrRichiesteViaggi.Inviata, dbo.GaCdrRichiesteViaggi.Note, dbo.GaCdrRichiesteViaggi.UserId, 
                         dbo.GaCdrRichiesteViaggi.CdrRichiestaId
FROM         dbo.GaCdrRichiesteViaggi INNER JOIN
                         dbo.GaCdrStatiRichieste ON dbo.GaCdrRichiesteViaggi.CdrStatoRichiestaId = dbo.GaCdrStatiRichieste.Id INNER JOIN
                         dbo.GaCdrCers ON dbo.GaCdrRichiesteViaggi.CdrCerId = dbo.GaCdrCers.Id INNER JOIN
                         dbo.GaCdrCentri ON dbo.GaCdrRichiesteViaggi.CdrCentroId = dbo.GaCdrCentri.Id INNER JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.GaCdrRichiesteViaggi.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id COLLATE DATABASE_DEFAULT
GO


