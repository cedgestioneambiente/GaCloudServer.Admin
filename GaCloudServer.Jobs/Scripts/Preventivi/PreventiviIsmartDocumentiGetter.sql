SELECT 
    TRIM(A.[CODCLI]) AS Codcli,
    A.[PRGFAT] AS Prgfat,
    B.IDDOCUMENTO AS IdDocumento,
    TRIM(A.[NUMFAT]) AS Numfat,
    TRIM(A.[CODSEZ]) AS Codsez,
    A.[DTFAT] AS Dtfat,
	B.NUMITEM AS Numprev,
	A.RAGSOC AS Ragsoc,
	C.Id PreventiviObjectId
FROM [20.82.75.6].[GA_ISMART].[dbo].[FATTURE_m001] A
INNER JOIN [20.82.75.6].[GA_ISMART].[dbo].[FATTURE_DOC_CORRELATI001] B 
    ON A.CODCLI = B.CODCLI AND A.PRGFAT = B.PRGFAT
INNER JOIN GaPreventiviObjects C ON C.ObjectNumber=TRIM(B.NUMITEM)
LEFT JOIN [GaPreventiviIsmartDocumenti] G
    ON TRIM(A.CODCLI) = G.Codcli 
    AND A.PRGFAT = G.Prgfat 
    AND B.IDDOCUMENTO = G.IdDocumento
WHERE B.IDDOCUMENTO = 'PREV'
  AND A.CODSEZ = 'AT'
  AND A.DTFAT IS NOT NULL
  AND G.Id IS NULL -- solo quelli non ancora presenti