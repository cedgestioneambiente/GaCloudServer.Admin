USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewConsorzioImportsTasks]    Script Date: 04/07/2023 09:54:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP VIEW IF EXISTS [dbo].[ViewConsorzioImportsTasks]
GO
DROP VIEW IF EXISTS [dbo].[ViewConsorzioReport]
GO

CREATE VIEW [dbo].[ViewConsorzioImportsTasks]
AS
SELECT        dbo.ConsorzioImportsTasks.Id, dbo.ConsorzioImportsTasks.TaskId, dbo.ConsorzioImportsTasks.DateStart, dbo.ConsorzioImportsTasks.DateEnd, dbo.ConsorzioImportsTasks.Completed, dbo.ConsorzioImportsTasks.Error, (Error + Completed) AS Totale,
                         dbo.ConsorzioImportsTasks.FileId, dbo.PrivateViewIdentityServerAdminUserList.FullName, CASE WHEN DateEnd <= DateStart THEN 'ND' ELSE CONCAT(DATEDIFF(minute, dbo.ConsorzioImportsTasks.DateStart,dbo.ConsorzioImportsTasks.DateEnd),' minuti') END AS DurataMinuti,
						 CASE WHEN Error <= 0 THEN 'V' ELSE 'R' END AS Successo, dbo.ConsorzioImportsTasks.Disabled,
						 CASE WHEN DateEnd <= DateStart THEN 'ND' ELSE CONCAT(DATEDIFF(second, dbo.ConsorzioImportsTasks.DateStart,dbo.ConsorzioImportsTasks.DateEnd),' secondi') END AS DurataSecondi
FROM            dbo.ConsorzioImportsTasks INNER JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.ConsorzioImportsTasks.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id
GO



CREATE VIEW [dbo].[ViewConsorzioReport]
AS
SELECT dbo.ConsorzioProduttori.Descrizione AS COMUNI,
	dbo.ConsorzioCers.Codice AS EER,
	CASE WHEN CodiceRaggruppamento IS NOT NULL THEN CodiceRaggruppamento ELSE '' END AS RAGG,
	dbo.ConsorzioCers.Descrizione AS DESCRIZIONE,
	dbo.ConsorzioDestinatari.Descrizione AS DESTINATARIO,
	dbo.ConsorzioDestinatari.Indirizzo AS INDIRIZZO_DESTINATARIO,
	ConsorzioComuni_1.cap AS CAP_DESTINATARIO, 
	ConsorzioComuni_1.Descrizione AS CITTA_DESTINATARIO,
	ConsorzioComuni_1.Provincia AS PROV_DESTINATARIO,
	dbo.ConsorzioDestinatari.CfPiva AS 'CODICE FISCALE_DESTINATARIO',
	dbo.ConsorzioDestinatari.CfPiva AS 'P.IVA_DESTINATARIO',
	dbo.ConsorzioTrasportatori.Descrizione AS TRASPORTATORE,
	dbo.ConsorzioTrasportatori.Indirizzo AS INDIRIZZO_TRASPORTATORE,
	ConsorzioComuni_1.cap AS CAP_TRASPORTATORE, 
	ConsorzioComuni_1.Descrizione AS CITTA_TRASPORTATORE,
	ConsorzioComuni_1.Provincia AS PROV_TRASPORTATORE,
	dbo.ConsorzioTrasportatori.CfPiva AS 'CODICE FISCALE_TRASPORTATORE',
	dbo.ConsorzioTrasportatori.CfPiva AS 'P.IVA_TRASPORTATORE',
	SUM(CASE WHEN MONTH(DataRegistrazione) = 1 THEN PesoTotale ELSE 0 END) AS 'GEN kg'
	,SUM(CASE WHEN MONTH(DataRegistrazione) = 2 THEN PesoTotale ELSE 0 END) AS 'FEB kg'
	,SUM(CASE WHEN MONTH(DataRegistrazione) = 3 THEN PesoTotale ELSE 0 END) AS 'MAR kg'
	,SUM(CASE WHEN MONTH(DataRegistrazione) = 4 THEN PesoTotale ELSE 0 END) AS 'APR kg'
	,SUM(CASE WHEN MONTH(DataRegistrazione) = 5 THEN PesoTotale ELSE 0 END) AS 'MAG kg'
	,SUM(CASE WHEN MONTH(DataRegistrazione) = 6 THEN PesoTotale ELSE 0 END) AS 'GIU kg'
	,SUM(CASE WHEN MONTH(DataRegistrazione) = 7 THEN PesoTotale ELSE 0 END) AS 'LUG kg'
	,SUM(CASE WHEN MONTH(DataRegistrazione) = 8 THEN PesoTotale ELSE 0 END) AS 'AGO kg'
	,SUM(CASE WHEN MONTH(DataRegistrazione) = 9 THEN PesoTotale ELSE 0 END) AS 'SET kg'
	,SUM(CASE WHEN MONTH(DataRegistrazione) = 10 THEN PesoTotale ELSE 0 END) AS 'OTT kg'
	,SUM(CASE WHEN MONTH(DataRegistrazione) = 11 THEN PesoTotale ELSE 0 END) AS 'NOV kg'
	,SUM(CASE WHEN MONTH(DataRegistrazione) = 12 THEN PesoTotale ELSE 0 END) AS 'DIC kg'
	,SUM(PesoTotale) AS 'ANNO 2023 kg'
	, dbo.ConsorzioOperazioni.Descrizione AS 'OP REC SMAL'
	,CAST('' AS varchar) AS Note
	,dbo.ConsorzioSmaltimenti.Descrizione AS Tipo_Smaltimento

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
WHERE YEAR(DataRegistrazione) = 2023
GROUP BY dbo.ConsorzioCers.Codice, dbo.ConsorzioCers.CodiceRaggruppamento, dbo.ConsorzioCers.Descrizione, 
                         dbo.ConsorzioProduttori.Descrizione, dbo.ConsorzioTrasportatori.Descrizione, dbo.ConsorzioDestinatari.Descrizione, 
                          dbo.ConsorzioOperazioni.Descrizione,  
                         dbo.ConsorzioSmaltimenti.Descrizione, dbo.ConsorzioComuni.Descrizione,  ConsorzioComuni_1.Descrizione, ConsorzioComuni_1.cap, ConsorzioComuni_1.Provincia, 
                         dbo.ConsorzioDestinatari.Indirizzo, dbo.ConsorzioDestinatari.CfPiva, ConsorzioComuni_2.Descrizione, 
                         ConsorzioComuni_2.cap, ConsorzioComuni_2.Provincia, dbo.ConsorzioTrasportatori.Indirizzo, dbo.ConsorzioTrasportatori.CfPiva, dbo.ConsorzioOperazioni.Descrizione, NOTE
GO