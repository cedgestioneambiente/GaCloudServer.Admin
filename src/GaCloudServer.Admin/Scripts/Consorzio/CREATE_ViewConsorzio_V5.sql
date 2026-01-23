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
SELECT 
    R.Id, 
    R.DataRegistrazione AS [Data Registrazione], 
    Cers.Codice AS Cer, 
    Cers.CodiceRaggruppamento AS [Codice Raggruppamento], 
    Cers.Descrizione AS [Descrizione CER], 
    Cers.Conteggio,
    R.PesoTotale AS [Peso (Kg)], 

    P.Descrizione AS Produttore, 
    P.Indirizzo AS ProduttoreIndirizzo,
    P.CfPiva AS ProduttoreCfPiva,
    ComProd.Descrizione AS ProduttoreComune,
    ComProd.Istat AS ProduttoreComuneIstat,

    T.Descrizione AS Trasportatore,
    T.Indirizzo AS TrasportatoreIndirizzo,
    T.CfPiva AS TrasportatoreCfPiva,
    ComTras.Descrizione AS TrasportatoreComune,
    ComTras.Istat AS TrasportatoreComuneIstat,

    D.Descrizione AS Destinatario,
    D.Indirizzo AS DestinatarioIndirizzo,
    D.CfPiva AS DestinatarioCfPiva,
    ComDest.Descrizione AS DestinatarioComune,
    ComDest.Istat AS DestinatarioComuneIstat,

    Op.Id AS OperazioneId,
    Op.Descrizione AS Operazione,
    Per.Descrizione AS Periodo,
    Smalt.Descrizione AS [Tipo Smaltimento],

    -- Campo calcolato
    CASE 
        WHEN Op.Id = 15 AND Cers.Codice IN ('200132', '080318', '150110') THEN 'RACCOLTA DIFFERENZIATA'
        WHEN Cers.Conteggio = 1 THEN Smalt.Descrizione
        ELSE 'NON CONTEGGIABILE'
    END AS TIPO_SMALTIMENTO_CUSTOM,

    R.Note,
    U.FullName AS [Nominativo Registrazione],

    -- Azienda Registrazione derivata da NormalizedName
    (
        SELECT TOP 1 
            SUBSTRING(Roles.NormalizedName, LEN('APPCONSORZIO') + 1, LEN(Roles.NormalizedName) - LEN('APPCONSORZIO'))
        FROM [IdentityServerAdmin].[dbo].[UserRoles] UR
        INNER JOIN [IdentityServerAdmin].[dbo].[Roles] Roles ON UR.RoleId = Roles.Id
        WHERE UR.UserId = U.Id AND Roles.NormalizedName LIKE 'APPCONSORZIO%'
    ) AS [Azienda Registrazione]

FROM dbo.ConsorzioRegistrazioni R
INNER JOIN dbo.ConsorzioProduttori P ON R.ConsorzioProduttoreId = P.Id 
INNER JOIN dbo.ConsorzioTrasportatori T ON R.ConsorzioTrasportatoreId = T.Id 
INNER JOIN dbo.ConsorzioDestinatari D ON R.ConsorzioDestinatarioId = D.Id 
INNER JOIN dbo.ConsorzioCers Cers ON R.ConsorzioCerId = Cers.Id 
INNER JOIN dbo.ConsorzioOperazioni Op ON R.ConsorzioOperazioneId = Op.Id 
INNER JOIN dbo.ConsorzioSmaltimenti Smalt ON Op.ConsorzioSmaltimentoId = Smalt.Id 
INNER JOIN dbo.ConsorzioPeriodi Per ON R.ConsorzioPeriodoId = Per.Id 
INNER JOIN dbo.ConsorzioComuni ComProd ON P.ConsorzioComuneId = ComProd.Id 
INNER JOIN dbo.ConsorzioComuni ComDest ON D.ConsorzioComuneId = ComDest.Id 
INNER JOIN dbo.ConsorzioComuni ComTras ON T.ConsorzioComuneId = ComTras.Id 
INNER JOIN dbo.PrivateViewIdentityServerAdminUserList U ON R.UserId = U.Id;
GO