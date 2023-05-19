USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewGaCdrConferimenti]    Script Date: 17/04/2023 11:45:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP VIEW IF EXISTS [dbo].[ViewConsorzioCers]
GO
DROP VIEW IF EXISTS [dbo].[ViewConsorzioRegistrazioni]
GO



CREATE VIEW [dbo].[ViewConsorzioCers]
AS
SELECT        dbo.ConsorzioCers.Id, dbo.ConsorzioCers.Codice, dbo.ConsorzioCers.Pericoloso, dbo.ConsorzioCers.Immagine, dbo.ConsorzioCers.Descrizione, dbo.ConsorzioCersSmaltimenti.Descrizione AS TipoSmaltimento, 
                         dbo.ConsorzioCers.Disabled, dbo.ConsorzioCers.CodiceRaggruppamento
FROM            dbo.ConsorzioCers INNER JOIN
                         dbo.ConsorzioCersSmaltimenti ON dbo.ConsorzioCers.ConsorzioCerSmaltimentoId = dbo.ConsorzioCersSmaltimenti.Id
GO

CREATE VIEW [dbo].[ViewConsorzioRegistrazioni]
AS
SELECT        dbo.ConsorzioRegistrazioni.UserId, dbo.ConsorzioRegistrazioni.Roles, dbo.ConsorzioRegistrazioni.PesoTotale, dbo.ConsorzioRegistrazioni.Operazione, dbo.ConsorzioRegistrazioni.DataRegistrazione, 
                         dbo.ConsorzioCers.Codice AS Cer, dbo.ConsorzioProduttori.Descrizione AS Produttore, dbo.ConsorzioTrasportatori.Descrizione AS Trasportatore, dbo.ConsorzioDestinatari.Descrizione AS Destinatario, 
                         dbo.PrivateViewIdentityServerAdminUserList.FullName AS Nominativo, dbo.ConsorzioRegistrazioni.Id, dbo.ConsorzioRegistrazioni.Disabled, dbo.ConsorzioRegistrazioni.ConsorzioProduttoreId AS ProduttoreId, 
                         dbo.ConsorzioRegistrazioni.Note, dbo.ConsorzioCers.CodiceRaggruppamento
FROM            dbo.ConsorzioProduttori INNER JOIN
                         dbo.ConsorzioRegistrazioni ON dbo.ConsorzioProduttori.Id = dbo.ConsorzioRegistrazioni.ConsorzioProduttoreId INNER JOIN
                         dbo.ConsorzioDestinatari ON dbo.ConsorzioRegistrazioni.ConsorzioDestinatarioId = dbo.ConsorzioDestinatari.Id INNER JOIN
                         dbo.ConsorzioTrasportatori ON dbo.ConsorzioRegistrazioni.ConsorzioTrasportatoreId = dbo.ConsorzioTrasportatori.Id INNER JOIN
                         dbo.ConsorzioCers ON dbo.ConsorzioRegistrazioni.ConsorzioCerId = dbo.ConsorzioCers.Id INNER JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.ConsorzioRegistrazioni.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id
GO

CREATE VIEW [dbo].[ViewConsorzioComuni]
AS
SELECT        Id, Descrizione + N' ' + N'(' + Provincia + N')' AS Descrizione, Disabled
FROM            dbo.ConsorzioComuni
GO