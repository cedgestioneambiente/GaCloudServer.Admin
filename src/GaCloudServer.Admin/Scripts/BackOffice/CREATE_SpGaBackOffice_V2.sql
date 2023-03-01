USE [GaCloud]
GO

/****** Object:  StoredProcedure [dbo].[SP_GetGaBackOfficeUtenze]    Script Date: 28/02/2023 12:06:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Federico Laigueglia
-- Create date: 25/02/2022 11:04:01
-- Description:	Ricerca Utenza da Numero Contratto+Comune
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetGaBackOfficeUtenze]
	-- Add the parameters for the stored procedure here
    @CPAZI nvarchar(100),
	@FILTER NVARCHAR(100)
AS
BEGIN

	DECLARE @SQL nvarchar(MAX) ='';

	--SET @SQL+='SELECT * FROM [20.82.75.6].TARI.dbo.'+TRIM(@CPAZI)+'M_DTTIC where identi2='''+TRIM(@IDENTI2)+''' UNION '

	SET @SQL=@SQL+'SELECT ''0'' as Id,cast(0 as bit) Disabled, COUNT(T.NUMCON) Tt, COUNT(A.CODCLI) Aa,
                M.NUMCON NumCon, F.CODCLI CodCli,
                MAX(F.CODFIS) CodFis, MAX(F.PIVA) Piva,
                MAX(F.RAGSO1) RagSo1, MAX(F.RAGSO2) RagSo2,
				CONCAT(MAX(F.RAGSO1),'' '', MAX(F.RAGSO2)) RagSo,
				MAX(T.TRIBUTO) Tributo,
                MAX(F.VIA) Via, MAX(F.NUMCIV) NumCiv, MAX(F.BARRATO) Barrato,
                MAX(F.SCALA) Scala, MAX(F.PIANO) Piano, MAX(F.INTERNO) Interno,
                MAX(F.CAP) Cap, MAX(F.CITTA) Citta, MAX(F.PROV) Prov,
				MAX(Z.CODZONA) CodZona,MAX(Z.DESCRI) DesZona,
                MAX(A.IDATTO) IdAtto,
                MAX(CASE WHEN COALESCE(F.COOBLIGANTE,''N'') = ''S'' THEN 1 ELSE (CASE WHEN  COALESCE(F.CODCLICOOB, 0) = 0 THEN 1  ELSE 0 END) END) CodCliCoob,
                MAX(CA.ID_FAMIGLIA) IdFamiglia
				FROM [20.82.75.6].TARI.DBO.['+@CPAZI+'FCCLIFAT] [F]
				LEFT JOIN [20.82.75.6].TARI.DBO.['+@CPAZI+'M_TSCON] [M] ON F.CODCLI = M.CODCOM
				LEFT JOIN [20.82.75.6].TARI.DBO.['+@CPAZI+'CONTRATTIANAG] [CA] ON CA.NUMCON = M.NUMCON
				LEFT JOIN [20.82.75.6].TARI.DBO.['+@CPAZI+'M_DTTIA] [T] ON M.NUMCON = T.NUMCON
				LEFT JOIN [20.82.75.6].TARI.DBO.['+@CPAZI+'ACCERTAMENTO] [A] ON A.CODCLI = F.CODCLI
				LEFT JOIN [20.82.75.6].TARI.DBO.[ZONE] [Z] ON T.CODZONA = Z.CODZONA
				WHERE ((((((((UPPER(F.CODFIS) LIKE ''%'+@FILTER+'%'') OR (UPPER(RTRIM(COALESCE(F.RAGSO1, '' '')) + SPACE(1) +  RTRIM(COALESCE(F.RAGSO2, '' ''))) LIKE ''%'+@FILTER+'%'')) OR (UPPER(RTRIM(COALESCE(F.RAGSO1, '' '')) + RTRIM(COALESCE(F.RAGSO2, '' ''))) LIKE ''%'+@FILTER+'%'')) OR (UPPER(F.STCONTO) LIKE ''%'+@FILTER+'%''))
				OR (UPPER(F.VIA) LIKE ''%'+@FILTER+'%'')) OR (UPPER(M.NUMCON) LIKE ''%'+@FILTER+'%'')) OR (UPPER(F.CODCLI) LIKE ''%'+@FILTER+'%'')) OR (UPPER(F.PIVA) LIKE ''%'+@FILTER+'%'')) OR (UPPER(CA.ID_FAMIGLIA) LIKE ''%'+@FILTER+'%'')
				GROUP BY [M].[NUMCON], [F].[CODCLI]'
	
	PRINT @SQL
	
	EXEC sp_executesql @sql

END

/****** Object:  StoredProcedure [dbo].[SP_GetGaBackOfficeLettureMezzi]    Script Date: 25/07/2022 12:09:52 ******/
SET ANSI_NULLS ON
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_GetGaBackOfficeUtenzePartite]
	-- Add the parameters for the stored procedure here
    @CPAZI nvarchar(100),
	@FILTER NVARCHAR(100)
AS
BEGIN

	DECLARE @SQL nvarchar(MAX) ='';

	--SET @SQL+=''SELECT * FROM [20.82.75.6].TARI.dbo.''+TRIM(@CPAZI)+''M_DTTIC where identi2=''''''+TRIM(@IDENTI2)+'''''' UNION ''

	SET @SQL=@SQL+'SELECT ''0'' as Id,cast(''0'' as bit) Disabled, A.NUMCON NumCon, A.PARTITA Partita,
        CONVERT(NVARCHAR(10), MIN(DTINI), 103) AS DtIni,
        (
            CASE WHEN (
                SELECT TOP 1 B.CESSATO
                FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIA B
                WHERE B.NUMCON = A.NUMCON
                    AND B.PARTITA = A.PARTITA
                    AND B.DTFIN = MAX(A.DTFIN))  = ''S''
            THEN CONVERT(nvarchar(10), MAX(DTFIN), 103)
            ELSE '''' END
        ) AS DtFin,
        CONVERT(NVARCHAR(10), MAX(DTFIN), 103) AS DtFin1,
        (
            SELECT TOP 1 B.COMUNE
            FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIA B
            WHERE B.NUMCON = A.NUMCON
                AND B.PARTITA = A.PARTITA
                AND B.DTFIN = MAX(A.DTFIN)
        ) AS Comune,
        (
            SELECT TOP 1 B.DESVIA
            FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIA B
            WHERE B.NUMCON = A.NUMCON
                AND B.PARTITA = A.PARTITA
                AND B.DTFIN = MAX(A.DTFIN)
        ) AS DesVia,
        (
            SELECT TOP 1 B.NUMCIV
            FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIA B
            WHERE B.NUMCON = A.NUMCON
                AND B.PARTITA = A.PARTITA
                AND B.DTFIN = MAX(A.DTFIN)
        ) AS NumCiv,
        (
            SELECT TOP 1 B.BARRATO
            FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIA B
            WHERE B.NUMCON = A.NUMCON
                AND B.PARTITA = A.PARTITA
                AND B.DTFIN = MAX(A.DTFIN)
        ) AS Barrato,
        (
            SELECT TOP 1 B.SCALA
            FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIA B
            WHERE B.NUMCON = A.NUMCON
                AND B.PARTITA = A.PARTITA
                AND B.DTFIN = MAX(A.DTFIN)
        ) AS Scala,
        (
            SELECT TOP 1 B.PIANO
            FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIA B
            WHERE B.NUMCON = A.NUMCON
                AND B.PARTITA = A.PARTITA
                AND B.DTFIN = MAX(A.DTFIN)
        ) AS Piano,
        (
            SELECT TOP 1 B.INTERNO
            FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIA B
            WHERE B.NUMCON = A.NUMCON
                AND B.PARTITA = A.PARTITA
                AND B.DTFIN = MAX(A.DTFIN)
        ) AS Interno,
        (
            SELECT TOP 1 B.NRCOMP
            FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIA B
            WHERE B.NUMCON = A.NUMCON
                AND B.PARTITA = A.PARTITA
                AND B.DTFIN = MAX(A.DTFIN)
        ) AS NrComp,
        (
            SELECT TOP 1 B.TRIBUTO
            FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIA B
            WHERE B.NUMCON = A.NUMCON
                AND B.PARTITA = A.PARTITA
                AND B.DTFIN = MAX(A.DTFIN)
        ) AS Tributo,
        (
            SELECT TOP 1 B.CATEG
            FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIA B
            WHERE B.NUMCON = A.NUMCON
                AND B.PARTITA = A.PARTITA
                AND B.DTFIN = MAX(A.DTFIN)
        ) AS Categ,
        (
            SELECT TOP 1 B.CPROWNUM
            FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIA B
            WHERE B.NUMCON = A.NUMCON
                AND B.PARTITA = A.PARTITA
                AND B.DTFIN = MAX(A.DTFIN)
        ) AS CpRowNum,
        (
            SELECT TOP 1 B.NRCOMP
            FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIA B
            WHERE B.NUMCON = A.NUMCON
                AND B.PARTITA = A.PARTITA
                AND B.DTFIN = MAX(A.DTFIN)
        ) AS NrComp2,
        (
            SELECT TOP 1 B.SUPERFIC
            FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIA B
            WHERE B.NUMCON = A.NUMCON
                AND B.PARTITA = A.PARTITA
                AND B.DTFIN = MAX(A.DTFIN)
        ) AS Superfic,
        (
            SELECT TOP 1 B.SUPERFICF
            FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIA B
            WHERE B.NUMCON = A.NUMCON
                AND B.PARTITA = A.PARTITA
                AND B.DTFIN = MAX(A.DTFIN)
        ) AS Superficf,
        (
            SELECT TOP 1 RTRIM(B.TRIBUTO)+'' ''+RTRIM(B.CATEG)+'' ''+RTRIM(C.DESTAR)
            FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIA B, [20.82.75.6].TARI.DBO.'+@CPAZI+'TIATAR C
            WHERE B.NUMCON = A.NUMCON
                AND B.PARTITA = A.PARTITA
                AND B.DTFIN = MAX(A.DTFIN)
                AND B.TRIBUTO = C.TRIBUTO
                AND B.CATEG = C.CATEG
        ) AS DescriCat,
        (
            SELECT TOP 1 B.CESSATO
            FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIA B
            WHERE B.NUMCON = A.NUMCON
                AND B.PARTITA = A.PARTITA
                AND B.DTFIN = MAX(A.DTFIN)
        ) AS Cessato,
        (
            SELECT TOP 1 B.SOSPESO
            FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIA B
            WHERE B.NUMCON = A.NUMCON
                AND B.PARTITA = A.PARTITA
                AND B.DTFIN = MAX(A.DTFIN)
        ) AS Sospeso,
        (
            SELECT TOP 1 B.C_CATCOMUNE
            FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIA B
            WHERE B.NUMCON = A.NUMCON
                AND B.PARTITA = A.PARTITA
                AND B.DTFIN = MAX(A.DTFIN)
        ) AS CatComune,
        (
            SELECT TOP 1 B.CODZONA
            FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIA B
            WHERE B.NUMCON = A.NUMCON
                AND B.PARTITA = A.PARTITA
                AND B.DTFIN = MAX(A.DTFIN)
        ) AS CodZona
    FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIA A
    WHERE NUMCON = '''+@FILTER+'''
    GROUP BY NUMCON, PARTITA
    ORDER BY DTFIN1 DESC, PARTITA ASC'
	
	PRINT @SQL
	
	EXEC sp_executesql @sql

END

/****** Object:  StoredProcedure [dbo].[SP_GetGaBackOfficeLettureMezzi]    Script Date: 25/07/2022 12:09:52 ******/
SET ANSI_NULLS ON
GO

/****** Object:  StoredProcedure [dbo].[SP_GetGaBackOfficeUtenzeDispositivi]    Script Date: 28/02/2023 12:06:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Federico Laigueglia
-- Create date: 25/02/2022 11:04:01
-- Description:	Ricerca Utenza da Numero Contratto+Comune
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetGaBackOfficeUtenzeDispositivi]
	-- Add the parameters for the stored procedure here
    @CPAZI nvarchar(100),
	@FILTER NVARCHAR(100)
AS
BEGIN

	DECLARE @SQL nvarchar(MAX) ='';

	--SET @SQL+=''SELECT * FROM [20.82.75.6].TARI.dbo.''+TRIM(@CPAZI)+''M_DTTIC where identi2=''''''+TRIM(@IDENTI2)+'''''' UNION ''

	SET @SQL=@SQL+'SELECT ''0'' as Id,cast(''0'' as bit) Disabled, A.Identi1, A.Identi2,
	(SELECT TOP 1 F1.TIPCON FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIC C1 LEFT JOIN [20.82.75.6].TARI.DBO.FCTIPCOT F1 ON F1.TIPCON = C1.TIPCON
                WHERE C1.PRGCON =  MAX(B.CPROWNUM) AND C1.NUMCON = MAX(A.NUMCON) AND C1.IDENTI1 = A.IDENTI1 AND C1.IDENTI2 = A.IDENTI2) AS TipCon ,
     (SELECT TOP 1 F1.DESCON FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIC C1 LEFT JOIN [20.82.75.6].TARI.DBO.FCTIPCOT F1 ON F1.TIPCON = C1.TIPCON
                WHERE C1.PRGCON =  MAX(B.CPROWNUM) AND C1.NUMCON = MAX(A.NUMCON) AND C1.IDENTI1 = A.IDENTI1 AND C1.IDENTI2 = A.IDENTI2) AS DesCon ,
	(SELECT TOP 1 F1.TIPMAT FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIC C1 LEFT JOIN [20.82.75.6].TARI.DBO.FCTIPCOT F1 ON F1.TIPCON = C1.TIPCON
                WHERE C1.PRGCON =  MAX(B.CPROWNUM) AND C1.NUMCON = MAX(A.NUMCON) AND C1.IDENTI1 = A.IDENTI1 AND C1.IDENTI2 = A.IDENTI2) AS TipMat ,
	(SELECT TOP 1 F1.CONTE FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIC C1 LEFT JOIN [20.82.75.6].TARI.DBO.FCTIPCOT F1 ON F1.TIPCON = C1.TIPCON
                WHERE C1.PRGCON =  MAX(B.CPROWNUM) AND C1.NUMCON = MAX(A.NUMCON) AND C1.IDENTI1 = A.IDENTI1 AND C1.IDENTI2 = A.IDENTI2) AS Lt ,
    CONVERT(NVARCHAR(10), MIN(A.DTCON), 103) AS DtCon,
    CONVERT(NVARCHAR(10), MAX(A.DTRIT), 103) AS DtRit,
    (
        SELECT TOP 1 F.PARTITA
        FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIA F
            INNER JOIN [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIC G ON F.NUMCON = G.NUMCON
                AND G.IDENTI1 = A.IDENTI1
        WHERE F.NUMCON = '''+@FILTER+'''
            AND F.CPROWNUM = MAX(B.CPROWNUM)
        ORDER BY F.DTFIN DESC
    ) AS Partita,
    MAX(B.NUMCON) AS NumCon,
    MAX(B.CPROWNUM) AS CpRowNum
FROM [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIC [A]
JOIN [20.82.75.6].TARI.DBO.'+@CPAZI+'M_DTTIA [B] ON A.NUMCON = B.NUMCON AND A.PRGCON = B.CPROWNUM
JOIN [20.82.75.6].TARI.DBO.[FCTIPCOT] [F] ON F.TIPCON = A.TIPCON
WHERE A.NUMCON = '''+@FILTER+'''
                AND (COALESCE(F.HIDEINLIST, ''N'') = ''N'')
                AND (A.IDENTI1 > '' '' OR A.IDENTI2 > '' '')
GROUP BY [A].[IDENTI1], [A].[IDENTI2]'
	
	PRINT @SQL
	
	EXEC sp_executesql @sql

END

/****** Object:  StoredProcedure [dbo].[SP_GetGaBackOfficeLettureMezzi]    Script Date: 25/07/2022 12:09:52 ******/
SET ANSI_NULLS ON
GO

