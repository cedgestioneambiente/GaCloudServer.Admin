/****** Object:  StoredProcedure [dbo].[SP_GetGaBackOfficeUtenzaByIdenti2]    Script Date: 25/02/2022 11:04:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Federico Laigueglia
-- Create date: 25/02/2022 11:04:06
-- Description:	Ricerce Utenze da Matricola Contenitore (IDENTI2)
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetGaBackOfficeUtenzaByIdenti2]
	-- Add the parameters for the stored procedure here
	@IDENTI2 NVARCHAR(100)
AS
BEGIN

	DECLARE @SQL nvarchar(MAX) ='';
	DECLARE @CPAZI nvarchar(100);

	DECLARE MY_CURSOR CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR
		SELECT CODAZI FROM [20.82.75.6].TARI.dbo.CPAZI
	OPEN MY_CURSOR
	FETCH NEXT FROM MY_CURSOR INTO @CPAZI
	WHILE @@FETCH_STATUS=0
	BEGIN
	print @cpazi


	SET @SQL+=@SQL+'SELECT A.NUMCON as NumCon,A.PRGCON as PrgCon,A.CPROWNUM as CpRowNum,F.PARTITA as Partita,A.TIPCON as TipCon,T.DESCON as DesCon,CONVERT(FLOAT,T.CONTE) as Lt,A.IDENTI1 as Identi1,A.IDENTI2 as Identi2,A.CESSATO as Cessato
			,B.RAGCLI as RagCli,C.CODFIS as CodFis,DESVIA as DesVia,F.NUMCIV as NumCiv,F.COMUNE as Comune 
			FROM [20.82.75.6].TARI.dbo.'+TRIM(@CPAZI)+'M_DTTIC A
			INNER JOIN [20.82.75.6].TARI.dbo.'+TRIM(@CPAZI)+'M_DTTIA F ON F.NUMCON=A.NUMCON AND F.CPROWNUM=A.PRGCON
			INNER JOIN [20.82.75.6].TARI.dbo.'+TRIM(@CPAZI)+'M_TSCON B ON B.NUMCON=A.NUMCON 
			INNER JOIN [20.82.75.6].TARI.dbo.'+TRIM(@CPAZI)+'FCCLIFAT C ON B.CODCOM=C.CODCLI
			INNER JOIN [20.82.75.6].TARI.dbo.'+TRIM(@CPAZI)+'FCCLISED S ON B.CODCOM=S.CODCLI
			INNER JOIN [20.82.75.6].TARI.dbo.FCTIPCOT T ON T.TIPCON=A.TIPCON 
			WHERE A.CESSATO=''N'' AND A.IDENTI2='''+TRIM(@IDENTI2)+''' UNION '
	

	FETCH NEXT FROM MY_CURSOR INTO @CPAZI

	END

	print 'sql'
	print @sql

	DECLARE @QUERY nvarchar(max)=SUBSTRING(@SQL,1,(LEN(@SQL)-6));

	print 'query'
	PRINT @query
	
	EXEC sp_executesql @query

END

/****** Object:  StoredProcedure [dbo].[SP_GetGaBackOfficeUtenzaByIdenti2AndComune]    Script Date: 25/02/2022 11:03:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Federico Laigueglia
-- Create date: 25/02/2022 11:03:48
-- Description:	Ricerca Utenza da Matricola Contenitore+Comune
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetGaBackOfficeUtenzaByIdenti2AndComune]
	-- Add the parameters for the stored procedure here
	@IDENTI2 NVARCHAR(100),
	@CPAZI nvarchar(100)
AS
BEGIN

	DECLARE @SQL nvarchar(MAX) ='';

	--SET @SQL+='SELECT * FROM [20.82.75.6].TARI.dbo.'+TRIM(@CPAZI)+'M_DTTIC where identi2='''+TRIM(@IDENTI2)+''' UNION '

	SET @SQL=@SQL+'SELECT A.NUMCON,A.PRGCON,A.CPROWNUM,F.PARTITA,A.TIPCON,T.DESCON,CONVERT(FLOAT,T.CONTE) as Lt,A.IDENTI1,A.IDENTI2,A.CESSATO,B.RAGCLI,C.CODFIS,DESVIA,F.NUMCIV,F.COMUNE 
			FROM [20.82.75.6].TARI.dbo.'+TRIM(@CPAZI)+'M_DTTIC A
			INNER JOIN [20.82.75.6].TARI.dbo.'+TRIM(@CPAZI)+'M_DTTIA F ON F.NUMCON=A.NUMCON AND F.CPROWNUM=A.PRGCON
			INNER JOIN [20.82.75.6].TARI.dbo.'+TRIM(@CPAZI)+'M_TSCON B ON B.NUMCON=A.NUMCON 
			INNER JOIN [20.82.75.6].TARI.dbo.'+TRIM(@CPAZI)+'FCCLIFAT C ON B.CODCOM=C.CODCLI
			INNER JOIN [20.82.75.6].TARI.dbo.FCTIPCOT T ON T.TIPCON=A.TIPCON 
			WHERE A.CESSATO=''N'' AND A.IDENTI2='''+TRIM(@IDENTI2)+''''
	
	PRINT @SQL
	
	EXEC sp_executesql @sql

END

/****** Object:  StoredProcedure [dbo].[SP_GetGaBackOfficeUtenzaByNumConAndComune]    Script Date: 25/02/2022 11:04:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Federico Laigueglia
-- Create date: 25/02/2022 11:04:01
-- Description:	Ricerca Utenza da Numero Contratto+Comune
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetGaBackOfficeUtenzaByNumConAndComune]
	-- Add the parameters for the stored procedure here
	@NUMCON NVARCHAR(100),
	@CPAZI nvarchar(100)
AS
BEGIN

	DECLARE @SQL nvarchar(MAX) ='';

	--SET @SQL+='SELECT * FROM [20.82.75.6].TARI.dbo.'+TRIM(@CPAZI)+'M_DTTIC where identi2='''+TRIM(@IDENTI2)+''' UNION '

	SET @SQL=@SQL+'SELECT A.NUMCON,A.PRGCON,A.CPROWNUM,F.PARTITA,A.TIPCON,T.DESCON,CONVERT(FLOAT,T.CONTE) as Lt,A.IDENTI1,A.IDENTI2,A.CESSATO,B.RAGCLI,C.CODFIS,DESVIA,F.NUMCIV,F.COMUNE 
			FROM [20.82.75.6].TARI.dbo.'+TRIM(@CPAZI)+'M_DTTIC A
			INNER JOIN [20.82.75.6].TARI.dbo.'+TRIM(@CPAZI)+'M_DTTIA F ON F.NUMCON=A.NUMCON AND F.CPROWNUM=A.PRGCON
			INNER JOIN [20.82.75.6].TARI.dbo.'+TRIM(@CPAZI)+'M_TSCON B ON B.NUMCON=A.NUMCON 
			INNER JOIN [20.82.75.6].TARI.dbo.'+TRIM(@CPAZI)+'FCCLIFAT C ON B.CODCOM=C.CODCLI
			INNER JOIN [20.82.75.6].TARI.dbo.FCTIPCOT T ON T.TIPCON=A.TIPCON 
			WHERE A.CESSATO=''N'' AND A.NUMCON='''+TRIM(@NUMCON)+''''
	
	PRINT @SQL
	
	EXEC sp_executesql @sql

END

/****** Object:  StoredProcedure [dbo].[SP_GetGaBackOfficeLettureMezzi]    Script Date: 25/07/2022 12:09:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Federico Laigueglia
-- Create date: 25/07/2022 12:09:52
-- Description:	Ricerca Letture Mezzi per periodo
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetGaBackOfficeLettureMezzi]
-- Add the parameters for the stored procedure here
	@DtSvuoInizio nvarchar(8),
	@DtSvuoFine nvarchar(8),
	@DtCarInizio nvarchar(8),
	@DtCarFine nvarchar(8),
	@Top int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF(@top>0)
	
		SELECT TOP (@Top) * FROM(
		SELECT A.[DATA CONFERIMENTO] DataConferimento,A.[ORA SVUOTAMENTO] OraSvuotamento,A.INDENTI1 Indenti1,A.MATRICOLA Matricola,A.[MATERIALE LETTO DA ANAGRAFICA] MaterialeLettoDaAnagrafica,B.DESCON DesCon,CAST(A.CONTE AS FLOAT) Lt,B.NUMCON NumCon,B.PARTITA Partita,B.RAGSO RagSo,B.CODFIS CodFis,B.TRIBUTO Tributo, A.PREFIX CodComune,A.DESAZI Comune,B.NRCOMP NrComp,B.CAT Cat,B.DESCAT DesCat,
		A.[SERVIZIO IDENTIFICATO] ServizioIdentificativo,A.NOTE  DescAnomalia FROM(
		select A.*,B.PREFIX,c.DESAZI, D.CONTE
		from(SELECT SFILE ,  CASt ( DDATAIMPORTAZIONE AS DATE) AS [DATA IMPORT], SNOMEFILE AS [NOME FILE], DDATASVUOTAMENTO AS [DATA CONFERIMENTO], ORA AS [ORA SVUOTAMENTO],
		''''+ SFKTRASPONDER AS [RFID],SFKTRASPONDER AS INDENTI1, SINDIRIZZO AS [MATRICOLA], TIPCON , CODAZI AS [MATERIALE LETTO DA ANAGRAFICA]
		, [ORA_GPS] AS [SERVIZIO IDENTIFICATO], CASE WHEN TIPO_RACCOLTA = '01' THEN TIPMAT ELSE '' END AS [TIPO GIRO INDICATO]
		,LATITUDINE, LONGITUDINE, STIPO AS [NOTE], LPROCESSATO_01 AS [COD ANOMALIA], TIPO_RACCOLTA
		FROM [20.82.75.6].TARI.dbo.TABESVUO_STO
		WHERE SFILE<>'' AND SFILE IN (SELECT ID_FILE  FROM [20.82.75.6].TARI.dbo.FCFILELOAD WHERE   DT_CAR  >= CONCAT(@DtCarInizio,' 00:00:00') AND DT_CAR   <= CONCAT(@DtCarFine,' 23:59:59') AND TIPOFILE = 'S')
		and DDATASVUOTAMENTO BETWEEN  CONCAT(@DtSvuoInizio,' 00:00:00')  AND  CONCAT(@DtSvuoFine,' 23:59:59')
		and tipo_record not in ('s')) A
		LEFT outer JOIN [20.82.75.6].TARI.dbo.FCTABARCCONT B ON TRIM(A.INDENTI1)=TRIM(B.INDENTI1)
		LEFT outer JOIN [20.82.75.6].TARI.dbo.CPAZI C ON c.CODAZI=b.PREFIX
		LEFT OUTER JOIN [20.82.75.6].TARI.dbo.FCTIPCOT D ON D.TIPCON=A.TIPCON
		WHERE PREFIX IS NOT NULL)A
		LEFT JOIN [20.82.75.6].TARI.dbo.UTENTI_LIST_CONT B ON TRIM(B.IDENTI1)=TRIM(A.INDENTI1)
		where B.CESSATO='N') A
	ELSE
		-- Insert statements for procedure here
		SELECT A.[DATA CONFERIMENTO] DataConferimento,A.[ORA SVUOTAMENTO] OraSvuotamento,A.INDENTI1 Indenti1,A.MATRICOLA Matricola,A.[MATERIALE LETTO DA ANAGRAFICA] MaterialeLettoDaAnagrafica,B.DESCON DesCon,CAST(A.CONTE AS FLOAT) Lt,B.NUMCON NumCon,B.PARTITA Partita,B.RAGSO RagSo,B.CODFIS CodFis,B.TRIBUTO Tributo, A.PREFIX CodComune,A.DESAZI Comune,B.NRCOMP NrComp,B.CAT Cat,B.DESCAT DesCat,
		A.[SERVIZIO IDENTIFICATO] ServizioIdentificativo,A.NOTE  DescAnomalia FROM(
		select A.*,B.PREFIX,c.DESAZI, D.CONTE
		from(SELECT SFILE ,  CASt ( DDATAIMPORTAZIONE AS DATE) AS [DATA IMPORT], SNOMEFILE AS [NOME FILE], DDATASVUOTAMENTO AS [DATA CONFERIMENTO], ORA AS [ORA SVUOTAMENTO],
		''''+ SFKTRASPONDER AS [RFID],SFKTRASPONDER AS INDENTI1, SINDIRIZZO AS [MATRICOLA], TIPCON , CODAZI AS [MATERIALE LETTO DA ANAGRAFICA]
		, [ORA_GPS] AS [SERVIZIO IDENTIFICATO], CASE WHEN TIPO_RACCOLTA = '01' THEN TIPMAT ELSE '' END AS [TIPO GIRO INDICATO]
		,LATITUDINE, LONGITUDINE, STIPO AS [NOTE], LPROCESSATO_01 AS [COD ANOMALIA], TIPO_RACCOLTA
		FROM [20.82.75.6].TARI.dbo.TABESVUO_STO
		WHERE SFILE<>'' AND SFILE IN (SELECT ID_FILE  FROM [20.82.75.6].TARI.dbo.FCFILELOAD WHERE   DT_CAR  >= CONCAT(@DtCarInizio,' 00:00:00') AND DT_CAR   <= CONCAT(@DtCarFine,' 23:59:59') AND TIPOFILE = 'S')
		and DDATASVUOTAMENTO BETWEEN  CONCAT(@DtSvuoInizio,' 00:00:00')  AND  CONCAT(@DtSvuoFine,' 23:59:59')
		and tipo_record not in ('s')) A
		LEFT outer JOIN [20.82.75.6].TARI.dbo.FCTABARCCONT B ON TRIM(A.INDENTI1)=TRIM(B.INDENTI1)
		LEFT outer JOIN [20.82.75.6].TARI.dbo.CPAZI C ON c.CODAZI=b.PREFIX
		LEFT OUTER JOIN [20.82.75.6].TARI.dbo.FCTIPCOT D ON D.TIPCON=A.TIPCON
		WHERE PREFIX IS NOT NULL)A
		LEFT JOIN [20.82.75.6].TARI.dbo.UTENTI_LIST_CONT B ON TRIM(B.IDENTI1)=TRIM(A.INDENTI1)
		where B.CESSATO='N'

END
GO

/****** Object:  StoredProcedure [dbo].[Sp_GetGaBackOfficeLettureEmz]    Script Date: 25/07/2022 12:10:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Federico Laigueglia
-- Create date: 25/07/2022 12:10:23
-- Description:	Ricerca Conferimenti EMZ per periodo
-- =============================================
CREATE PROCEDURE [dbo].[Sp_GetGaBackOfficeLettureEmz]
	-- Add the parameters for the stored procedure here
	@DtSvuoInizio nvarchar(8),
	@DtSvuoFine nvarchar(8),
	@Top int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    IF(@Top>0)
		SELECT TOP(@Top) * FROM (
		SELECT A.DTREG DataConferimento,ORA OraSvuotamento,A.IDENTI1 Indenti1, MEZZO Calotta, D.DESCON DesCon,CAST(D.CONTE AS FLOAT) Lt,C.DESCON DispositivoAssociato,C.NUMCON NumCon,PARTITA Partita,RAGSO RagSo,CODFIS CodFis,C.TRIBUTO Tributo, COMUNE CodComune, E.DESAZI Comune,
		C.NRCOMP NrComp,C.CAT Cat,C.DESCAT DesCat
		FROM            [20.82.75.6].TARI.dbo.FCTRASVU AS A LEFT OUTER JOIN
								 [20.82.75.6].TARI.dbo.FCTABARCCONT AS B ON A.MEZZO = B.INDENTI1
								 LEFT OUTER JOIN [20.82.75.6].TARI.dbo.UTENTI_LIST_CONT C ON C.IDENTI1=RIGHT(TRIM(A.IDENTI1),14)
								 LEFT OUTER JOIN [20.82.75.6].TARI.dbo.FCTIPCOT D ON D.TIPCON=B.TIPCON
								 LEFT OUTER JOIN [20.82.75.6].TARI.dbo.CPAZI E ON E.CODAZI=C.COMUNE
		WHERE B.TIPCON IS NOT NULL AND A.DTREG BETWEEN  CONCAT(@DtSvuoInizio,' 00:00:00')  AND  CONCAT(@DtSvuoFine,' 23:59:59') --AND A.IDENTI1='1004755132E06780'-- AND c.NUMCON='00239889'-- and A.IDENTI1='1004755132E06780'
		)A

	ELSE
		SELECT A.DTREG DataConferimento,ORA OraSvuotamento,A.IDENTI1 Indenti1, MEZZO Calotta, D.DESCON DesCon,CAST(D.CONTE AS FLOAT) Lt,C.DESCON DispositivoAssociato,C.NUMCON NumCon,PARTITA Partita,RAGSO RagSo,CODFIS CodFis,C.TRIBUTO Tributo, COMUNE CodComune, E.DESAZI Comune,
		C.NRCOMP NrComp,C.CAT Cat,C.DESCAT DesCat
		FROM            [20.82.75.6].TARI.dbo.FCTRASVU AS A LEFT OUTER JOIN
								 [20.82.75.6].TARI.dbo.FCTABARCCONT AS B ON A.MEZZO = B.INDENTI1
								 LEFT OUTER JOIN [20.82.75.6].TARI.dbo.UTENTI_LIST_CONT C ON C.IDENTI1=RIGHT(TRIM(A.IDENTI1),14)
								 LEFT OUTER JOIN [20.82.75.6].TARI.dbo.FCTIPCOT D ON D.TIPCON=B.TIPCON
								 LEFT OUTER JOIN [20.82.75.6].TARI.dbo.CPAZI E ON E.CODAZI=C.COMUNE
		WHERE B.TIPCON IS NOT NULL AND A.DTREG BETWEEN  CONCAT(@DtSvuoInizio,' 00:00:00')  AND  CONCAT(@DtSvuoFine,' 23:59:59') --AND A.IDENTI1='1004755132E06780'-- AND c.NUMCON='00239889'-- and A.IDENTI1='1004755132E06780'


	
END
GO
