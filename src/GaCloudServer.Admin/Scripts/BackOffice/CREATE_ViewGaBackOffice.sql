/****** Object:  View [dbo].[ViewGaBackOfficeComuni]    Script Date: 14/02/2022 16:53:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[ViewGaBackOfficeComuni]

AS

SELECT 
CAST(0 AS BIGINT) AS Id,
CODAZI CodAzi,
DESAZI as Descrizione,
CAST('false' as bit) as Disabled

FROM [20.82.75.6].[TARI].dbo.[CPAZI]
WHERE CODAZI LIKE 'C%'
GO

/****** Object:  View [dbo].[ViewGaBackOfficeComuni]    Script Date: 14/02/2022 16:53:31 ******/
SET ANSI_NULLS ON
GO

CREATE VIEW [dbo].[ViewGaBackOfficeUtenze]

AS

SELECT 
CAST(0 AS BIGINT) AS Id,
CODAZI AS CodAzi,
CODFIS as CodFis,
NUMCON as NumCon,
CODCOM as CodCom,
RAGCLI as RagCli,
PARTITA as Partita,
DECORRENZA as Decorrenza,
COMUNE as Comune,
DESVIA as DesVia,
CIVICO as Civico,
BARRATO as Barrato,
INTERNO as Interno,
cast(SUPERFIC as float) as Superfic,
CATEG as Categ,
DESTAR as Destar,
ISTAT as Istat,
DESISTAT as DesIstat,
CODZONA as CodZona,
DESCRI as Descri,
DOMEST as Domest,
CAST('false' as bit) as Disabled

FROM [20.82.75.6].[TARI].dbo.[UTENTI_LIST]
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewGaBackOfficeUtenzeGrouped]

AS

SELECT        CAST(0 AS BIGINT) AS Id,CODAZI CodAzi, CODFIS CodFis, NUMCON NumCon, CODCOM CodCom,PARTITA Partita,CPROWNUM Prg, RAGCLI RagCli, COMUNE Comune, DESVIA DesVia, CIVICO Civico, CODZONA CodZona, DESCRI Descri,DOMEST Domest, Categ,Destar,CAST('false' AS bit) AS Disabled
FROM            [20.82.75.6].TARI.dbo.UTENTI_LIST
group by CODAZI, CODFIS, NUMCON, CODCOM, PARTITA, CPROWNUM,RAGCLI, COMUNE, DESVIA, CIVICO, CODZONA, DESCRI,DOMEST,Categ,Destar
GO

/****** Object:  View [dbo].[ViewGaBackOfficeComuni]    Script Date: 22/02/2022 14:02:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewGaBackOfficeCatagorie]

AS

SELECT 
CAST(0 AS BIGINT) AS Id,
TIPO as Tipo,
TRIBUTO as Tributo,
CATEg as Categ,
DESTAR as DesTar,
DOMEST as Domest,
CAST('false' AS bit) AS Disabled

FROM [20.82.75.6].[TARI].dbo.[TIATAR]
GO

/****** Object:  View [dbo].[ViewGaBackOfficeNdUtenzeGrouped]    Script Date: 22/02/2022 10:15:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewGaBackOfficeNdUtenzeGrouped]

AS

SELECT       CAST(0 AS BIGINT) AS Id, CODAZI, CODFIS, NUMCON, CODCOM, RAGCLI, COMUNE, DESVIA, CIVICO, CODZONA, DESCRI,CAST('false' AS bit) AS Disabled
FROM            [20.82.75.6].TARI.dbo.UTENTI_NDOM
group by CODAZI, CODFIS, NUMCON, CODCOM, RAGCLI, COMUNE, DESVIA, CIVICO, CODZONA, DESCRI
GO




