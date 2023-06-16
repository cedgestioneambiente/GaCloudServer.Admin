USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewGaCdrConferimenti]    Script Date: 17/04/2023 11:45:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP VIEW IF EXISTS [dbo].[ViewConsorzioExportSingoliEsteso]
GO


CREATE VIEW [dbo].[ViewConsorzioExportSingoliEsteso]
AS
SELECT        dbo.ConsorzioRegistrazioni.Id, dbo.ConsorzioRegistrazioni.DataRegistrazione AS [Data Registrazione], dbo.ConsorzioCers.Codice AS Cer, dbo.ConsorzioCers.CodiceRaggruppamento AS [Codice Raggruppamento], 
                         dbo.ConsorzioCers.Descrizione AS [Descrizione CER], dbo.ConsorzioRegistrazioni.PesoTotale AS [Peso (Kg)], dbo.ConsorzioProduttori.Descrizione AS Produttore, dbo.ConsorzioTrasportatori.Descrizione AS Trasportatore, 
                         dbo.ConsorzioDestinatari.Descrizione AS Destinatario, dbo.PrivateViewIdentityServerAdminUserList.FullName AS [Nominativo Registrazione], dbo.ConsorzioRegistrazioni.Note, 
                         dbo.ConsorzioOperazioni.Descrizione AS Operazione, dbo.ConsorzioPeriodi.Descrizione AS Periodo, dbo.ConsorzioSmaltimenti.Descrizione AS [Tipo Smaltimento], dbo.ConsorzioComuni.Descrizione AS ProduttoreComune, 
                         dbo.ConsorzioComuni.Istat AS ProduttoreComuneIstat, dbo.ConsorzioProduttori.Indirizzo AS ProduttoreIndirizzo, dbo.ConsorzioProduttori.CfPiva AS ProduttoreCfPiva, ConsorzioComuni_1.Descrizione AS DestinatarioComune, 
                         ConsorzioComuni_1.Istat AS DestinatarioComuneIstat, dbo.ConsorzioDestinatari.Indirizzo AS DestinatarioIndirizzo, dbo.ConsorzioDestinatari.CfPiva AS DestinatarioCfPiva, 
                         ConsorzioComuni_2.Descrizione AS TrasportatoreComune, ConsorzioComuni_2.Istat AS TrasportatoreComuneIstat, dbo.ConsorzioTrasportatori.Indirizzo AS TrasportatoreIndirizzo, 
                         dbo.ConsorzioTrasportatori.CfPiva AS TrasportatoreCfPiva
FROM            dbo.ConsorzioProduttori INNER JOIN
                         dbo.ConsorzioRegistrazioni ON dbo.ConsorzioProduttori.Id = dbo.ConsorzioRegistrazioni.ConsorzioProduttoreId INNER JOIN
                         dbo.ConsorzioDestinatari ON dbo.ConsorzioRegistrazioni.ConsorzioDestinatarioId = dbo.ConsorzioDestinatari.Id INNER JOIN
                         dbo.ConsorzioTrasportatori ON dbo.ConsorzioRegistrazioni.ConsorzioTrasportatoreId = dbo.ConsorzioTrasportatori.Id INNER JOIN
                         dbo.ConsorzioCers ON dbo.ConsorzioRegistrazioni.ConsorzioCerId = dbo.ConsorzioCers.Id INNER JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.ConsorzioRegistrazioni.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id INNER JOIN
                         dbo.ConsorzioPeriodi ON dbo.ConsorzioRegistrazioni.ConsorzioPeriodoId = dbo.ConsorzioPeriodi.Id INNER JOIN
                         dbo.ConsorzioOperazioni ON dbo.ConsorzioRegistrazioni.ConsorzioOperazioneId = dbo.ConsorzioOperazioni.Id INNER JOIN
                         dbo.ConsorzioSmaltimenti ON dbo.ConsorzioOperazioni.ConsorzioSmaltimentoId = dbo.ConsorzioSmaltimenti.Id INNER JOIN
                         dbo.ConsorzioComuni ON dbo.ConsorzioProduttori.ConsorzioComuneId = dbo.ConsorzioComuni.Id INNER JOIN
                         dbo.ConsorzioComuni AS ConsorzioComuni_1 ON dbo.ConsorzioDestinatari.ConsorzioComuneId = ConsorzioComuni_1.Id INNER JOIN
                         dbo.ConsorzioComuni AS ConsorzioComuni_2 ON dbo.ConsorzioTrasportatori.ConsorzioComuneId = ConsorzioComuni_2.Id
GO