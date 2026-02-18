------------------------------------------------------------
-- DROP INDEXES (SAFE)
------------------------------------------------------------

IF EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = 'IX_ConsorzioRegistrazioni_DataRegistrazione'
    AND object_id = OBJECT_ID('dbo.ConsorzioRegistrazioni')
)
DROP INDEX IX_ConsorzioRegistrazioni_DataRegistrazione
ON dbo.ConsorzioRegistrazioni
GO

IF EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = 'IX_ConsorzioRegistrazioni_UserId'
    AND object_id = OBJECT_ID('dbo.ConsorzioRegistrazioni')
)
DROP INDEX IX_ConsorzioRegistrazioni_UserId
ON dbo.ConsorzioRegistrazioni
GO

IF EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = 'IX_ConsorzioRegistrazioni_CerId'
    AND object_id = OBJECT_ID('dbo.ConsorzioRegistrazioni')
)
DROP INDEX IX_ConsorzioRegistrazioni_CerId
ON dbo.ConsorzioRegistrazioni
GO

IF EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = 'IX_ConsorzioRegistrazioni_ProduttoreId'
    AND object_id = OBJECT_ID('dbo.ConsorzioRegistrazioni')
)
DROP INDEX IX_ConsorzioRegistrazioni_ProduttoreId
ON dbo.ConsorzioRegistrazioni
GO

IF EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = 'IX_ConsorzioRegistrazioni_TrasportatoreId'
    AND object_id = OBJECT_ID('dbo.ConsorzioRegistrazioni')
)
DROP INDEX IX_ConsorzioRegistrazioni_TrasportatoreId
ON dbo.ConsorzioRegistrazioni
GO

IF EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = 'IX_ConsorzioRegistrazioni_DestinatarioId'
    AND object_id = OBJECT_ID('dbo.ConsorzioRegistrazioni')
)
DROP INDEX IX_ConsorzioRegistrazioni_DestinatarioId
ON dbo.ConsorzioRegistrazioni
GO

IF EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = 'IX_ConsorzioRegistrazioni_OperazioneId'
    AND object_id = OBJECT_ID('dbo.ConsorzioRegistrazioni')
)
DROP INDEX IX_ConsorzioRegistrazioni_OperazioneId
ON dbo.ConsorzioRegistrazioni
GO

IF EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = 'IX_ConsorzioRegistrazioni_PeriodoId'
    AND object_id = OBJECT_ID('dbo.ConsorzioRegistrazioni')
)
DROP INDEX IX_ConsorzioRegistrazioni_PeriodoId
ON dbo.ConsorzioRegistrazioni
GO


------------------------------------------------------------
-- RESTORE ORIGINAL VIEW (WITH FORMAT)
------------------------------------------------------------

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[ViewConsorzioRegistrazioni] AS
SELECT
    dbo.ConsorzioRegistrazioni.UserId,
    dbo.ConsorzioRegistrazioni.Roles,
    CAST(dbo.ConsorzioRegistrazioni.PesoTotale AS float) AS PesoTotale,
    dbo.ConsorzioRegistrazioni.DataRegistrazione,
    dbo.ConsorzioCers.Codice AS Cer,
    dbo.ConsorzioProduttori.Descrizione AS Produttore,
    dbo.ConsorzioTrasportatori.Descrizione AS Trasportatore,
    dbo.ConsorzioDestinatari.Descrizione AS Destinatario,
    dbo.PrivateViewIdentityServerAdminUserList.FullName AS Nominativo,
    dbo.ConsorzioRegistrazioni.Id,
    dbo.ConsorzioRegistrazioni.Disabled,
    dbo.ConsorzioRegistrazioni.Note,
    dbo.ConsorzioCers.CodiceRaggruppamento,
    dbo.ConsorzioPeriodi.Descrizione AS Periodo,
    dbo.ConsorzioOperazioni.Descrizione AS Operazione,
    FORMAT(dbo.ConsorzioRegistrazioni.DataRegistrazione, 'MMMM', 'it-IT') AS Mese,
    YEAR(dbo.ConsorzioRegistrazioni.DataRegistrazione) AS Anno
FROM dbo.ConsorzioRegistrazioni
INNER JOIN dbo.ConsorzioProduttori
    ON dbo.ConsorzioProduttori.Id = dbo.ConsorzioRegistrazioni.ConsorzioProduttoreId
INNER JOIN dbo.ConsorzioDestinatari
    ON dbo.ConsorzioRegistrazioni.ConsorzioDestinatarioId = dbo.ConsorzioDestinatari.Id
INNER JOIN dbo.ConsorzioTrasportatori
    ON dbo.ConsorzioRegistrazioni.ConsorzioTrasportatoreId = dbo.ConsorzioTrasportatori.Id
INNER JOIN dbo.ConsorzioCers
    ON dbo.ConsorzioRegistrazioni.ConsorzioCerId = dbo.ConsorzioCers.Id
INNER JOIN dbo.PrivateViewIdentityServerAdminUserList
    ON dbo.ConsorzioRegistrazioni.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id
INNER JOIN dbo.ConsorzioOperazioni
    ON dbo.ConsorzioRegistrazioni.ConsorzioOperazioneId = dbo.ConsorzioOperazioni.Id
INNER JOIN dbo.ConsorzioPeriodi
    ON dbo.ConsorzioRegistrazioni.ConsorzioPeriodoId = dbo.ConsorzioPeriodi.Id
GO
