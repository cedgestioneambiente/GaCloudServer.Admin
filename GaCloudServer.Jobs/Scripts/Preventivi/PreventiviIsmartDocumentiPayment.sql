SELECT 
    P.Id,
    P.Numfat,
    P.Codsez,
    P.Dtfat,
    P.Codcli Codcli,
    ISNULL(SUM(T.INCRIM), 0.0) AS ImportoPagato,
    MAX(T.DT_AVPAG) AS DataPagamento,
    TRIM(P.Numprev) Numprev,
    P.Ragsoc,
    P.PreventiviObjectId
FROM [GACLOUD].[dbo].[GaPreventiviIsmartDocumenti] P
LEFT JOIN [20.82.75.6].[TARI].[dbo].[C90FCAVVPAG] T
    ON TRIM(T.Numfat) = CONCAT(TRIM(P.Numfat), TRIM(P.Codsez)) COLLATE DATABASE_DEFAULT
    AND T.Datfat = P.Dtfat
WHERE P.Gestito = 0
GROUP BY P.Id,P.Codcli, P.Numfat, P.Codsez, P.Dtfat, P.Numprev,P.Ragsoc,P.PreventiviObjectId
HAVING SUM(T.INCRIM) > 0