USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewGaCdrConferimenti]    Script Date: 17/04/2023 11:45:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP VIEW IF EXISTS [dbo].[ViewConsorzioProduttori]
GO
DROP VIEW IF EXISTS [dbo].[ViewConsorzioDestinatari]
GO
DROP VIEW IF EXISTS [dbo].[ViewConsorzioTrasportatori]
GO
DROP VIEW IF EXISTS [dbo].[ViewConsorzioCers]
GO
DROP VIEW IF EXISTS [dbo].[ViewConsorzioRegistrazioni]
GO
DROP VIEW IF EXISTS [dbo].[ViewConsorzioExport]
GO


CREATE VIEW [dbo].[ViewConsorzioCers]
AS
SELECT        dbo.ConsorzioCers.Id, dbo.ConsorzioCers.Codice, dbo.ConsorzioCers.Pericoloso, dbo.ConsorzioCers.Immagine, dbo.ConsorzioCers.Descrizione, 
                         dbo.ConsorzioCers.Disabled, dbo.ConsorzioCers.CodiceRaggruppamento,            
						 CONCAT(dbo.ConsorzioCers.Codice , N' - ' , dbo.ConsorzioCers.CodiceRaggruppamento , N' ' , N'(' + dbo.ConsorzioCers.Descrizione + N')') AS DescrizioneEstesa
FROM            dbo.ConsorzioCers
GO

CREATE VIEW [dbo].[ViewConsorzioDestinatari]
AS
SELECT        dbo.ConsorzioDestinatari.Id, dbo.ConsorzioComuni.Descrizione + N' ' + N'(' + dbo.ConsorzioComuni.Provincia + N')' AS Comune, dbo.ConsorzioDestinatari.Indirizzo, dbo.ConsorzioDestinatari.CfPiva AS CfPiva, 
                         dbo.ConsorzioDestinatari.Descrizione, dbo.ConsorzioDestinatari.Disabled, 
                         dbo.ConsorzioDestinatari.Indirizzo + N' ' + dbo.ConsorzioComuni.Descrizione + N' ' + N'(' + dbo.ConsorzioComuni.Provincia + N')' AS IndirizzoEsteso
FROM            dbo.ConsorzioDestinatari INNER JOIN
                         dbo.ConsorzioComuni ON dbo.ConsorzioDestinatari.ConsorzioComuneId = dbo.ConsorzioComuni.Id
GO

CREATE VIEW [dbo].[ViewConsorzioProduttori]
AS
SELECT        dbo.ConsorzioProduttori.Id, dbo.ConsorzioComuni.Descrizione + N' ' + N'(' + dbo.ConsorzioComuni.Provincia + N')' AS Comune, dbo.ConsorzioProduttori.Indirizzo, dbo.ConsorzioProduttori.CfPiva AS CfPiva, 
                         dbo.ConsorzioProduttori.Descrizione, dbo.ConsorzioProduttori.Disabled, dbo.ConsorzioProduttori.Indirizzo + N' ' + dbo.ConsorzioComuni.Descrizione + N' ' + N'(' + dbo.ConsorzioComuni.Provincia + N')' AS IndirizzoEsteso
FROM            dbo.ConsorzioProduttori INNER JOIN
                         dbo.ConsorzioComuni ON dbo.ConsorzioProduttori.ConsorzioComuneId = dbo.ConsorzioComuni.Id
GO

CREATE VIEW [dbo].[ViewConsorzioTrasportatori]
AS
SELECT        dbo.ConsorzioTrasportatori.Id, dbo.ConsorzioComuni.Descrizione + N' ' + N'(' + dbo.ConsorzioComuni.Provincia + N')' AS Comune, dbo.ConsorzioTrasportatori.Indirizzo, dbo.ConsorzioTrasportatori.CfPiva AS CfPiva, 
                         dbo.ConsorzioTrasportatori.Descrizione, dbo.ConsorzioTrasportatori.Disabled, 
                         dbo.ConsorzioTrasportatori.Indirizzo + N' ' + dbo.ConsorzioComuni.Descrizione + N' ' + N'(' + dbo.ConsorzioComuni.Provincia + N')' AS IndirizzoEsteso
FROM            dbo.ConsorzioTrasportatori INNER JOIN
                         dbo.ConsorzioComuni ON dbo.ConsorzioTrasportatori.ConsorzioComuneId = dbo.ConsorzioComuni.Id
GO

CREATE VIEW [dbo].[ViewConsorzioRegistrazioni]
AS
SELECT        dbo.ConsorzioRegistrazioni.UserId, dbo.ConsorzioRegistrazioni.Roles, dbo.ConsorzioRegistrazioni.PesoTotale, dbo.ConsorzioRegistrazioni.DataRegistrazione, dbo.ConsorzioCers.Codice AS Cer, 
                         dbo.ConsorzioProduttori.Descrizione AS Produttore, dbo.ConsorzioTrasportatori.Descrizione AS Trasportatore, dbo.ConsorzioDestinatari.Descrizione AS Destinatario, 
                         dbo.PrivateViewIdentityServerAdminUserList.FullName AS Nominativo, dbo.ConsorzioRegistrazioni.Id, dbo.ConsorzioRegistrazioni.Disabled, dbo.ConsorzioRegistrazioni.Note, dbo.ConsorzioCers.CodiceRaggruppamento, 
                         dbo.ConsorzioPeriodi.Descrizione AS Periodo, dbo.ConsorzioOperazioni.Descrizione AS Operazione, FORMAT(dbo.ConsorzioRegistrazioni.DataRegistrazione, 'MMMM', 'it-IT') AS Mese, 
                         YEAR(dbo.ConsorzioRegistrazioni.DataRegistrazione) AS Anno
FROM            dbo.ConsorzioProduttori INNER JOIN
                         dbo.ConsorzioRegistrazioni ON dbo.ConsorzioProduttori.Id = dbo.ConsorzioRegistrazioni.ConsorzioProduttoreId INNER JOIN
                         dbo.ConsorzioDestinatari ON dbo.ConsorzioRegistrazioni.ConsorzioDestinatarioId = dbo.ConsorzioDestinatari.Id INNER JOIN
                         dbo.ConsorzioTrasportatori ON dbo.ConsorzioRegistrazioni.ConsorzioTrasportatoreId = dbo.ConsorzioTrasportatori.Id INNER JOIN
                         dbo.ConsorzioCers ON dbo.ConsorzioRegistrazioni.ConsorzioCerId = dbo.ConsorzioCers.Id INNER JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.ConsorzioRegistrazioni.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id INNER JOIN
                         dbo.ConsorzioOperazioni ON dbo.ConsorzioRegistrazioni.ConsorzioOperazioneId = dbo.ConsorzioOperazioni.Id INNER JOIN
                         dbo.ConsorzioPeriodi ON dbo.ConsorzioRegistrazioni.ConsorzioPeriodoId = dbo.ConsorzioPeriodi.Id
GO

CREATE VIEW [dbo].[ViewConsorzioExportSingoli]
AS
SELECT        dbo.ConsorzioRegistrazioni.Id, dbo.ConsorzioRegistrazioni.DataRegistrazione AS [Data Registrazione], dbo.ConsorzioCers.Codice AS Cer, 
                          dbo.ConsorzioCers.CodiceRaggruppamento AS [Codice Raggruppamento], dbo.ConsorzioCers.Descrizione AS [Descrizione CER], dbo.ConsorzioRegistrazioni.PesoTotale AS [Peso (Kg)], dbo.ConsorzioProduttori.Descrizione AS Produttore, dbo.ConsorzioTrasportatori.Descrizione AS Trasportatore, dbo.ConsorzioDestinatari.Descrizione AS Destinatario, 
                         dbo.PrivateViewIdentityServerAdminUserList.FullName AS [Nominativo Registrazione], dbo.ConsorzioRegistrazioni.Note, dbo.ConsorzioOperazioni.Descrizione AS Operazione, dbo.ConsorzioPeriodi.Descrizione AS Periodo, 
                         dbo.ConsorzioSmaltimenti.Descrizione AS [Tipo Smaltimento]
FROM            dbo.ConsorzioProduttori INNER JOIN
                         dbo.ConsorzioRegistrazioni ON dbo.ConsorzioProduttori.Id = dbo.ConsorzioRegistrazioni.ConsorzioProduttoreId INNER JOIN
                         dbo.ConsorzioDestinatari ON dbo.ConsorzioRegistrazioni.ConsorzioDestinatarioId = dbo.ConsorzioDestinatari.Id INNER JOIN
                         dbo.ConsorzioTrasportatori ON dbo.ConsorzioRegistrazioni.ConsorzioTrasportatoreId = dbo.ConsorzioTrasportatori.Id INNER JOIN
                         dbo.ConsorzioCers ON dbo.ConsorzioRegistrazioni.ConsorzioCerId = dbo.ConsorzioCers.Id INNER JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.ConsorzioRegistrazioni.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id INNER JOIN
                         dbo.ConsorzioPeriodi ON dbo.ConsorzioRegistrazioni.ConsorzioPeriodoId = dbo.ConsorzioPeriodi.Id INNER JOIN
                         dbo.ConsorzioOperazioni ON dbo.ConsorzioRegistrazioni.ConsorzioOperazioneId = dbo.ConsorzioOperazioni.Id INNER JOIN
                         dbo.ConsorzioSmaltimenti ON dbo.ConsorzioOperazioni.ConsorzioSmaltimentoId = dbo.ConsorzioSmaltimenti.Id
GO