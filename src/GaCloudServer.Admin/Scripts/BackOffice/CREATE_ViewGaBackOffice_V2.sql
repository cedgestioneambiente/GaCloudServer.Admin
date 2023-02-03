USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewGaBackOfficeContenitoriLetture]    Script Date: 02/02/2023 15:37:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewGaBackOfficeContenitoriLetture]

AS

SELECT CAST(0 AS bigint) Id, A.DtReg,A.ORA,A.Identi1,A.Identi2,A.Mezzo,A.COORD_X CoordX,A.COORD_Y CoordY,A.Confe,
B.COMUNE CodComune,C.DESAZI Comune, B.NumCon,B.Partita, B.PrgCon,B.CpRowNum,B.TipCon,B.DesCon,B.TipMat, B.Cessato,
B.RagSo,B.CodFis,B.Tributo,B.NrComp,B.Cat,B.DesCat,CAST(0 as bit) Disabled
FROM
[20.82.75.6].[TARI].[dbo].FCTRASVU A
LEFT JOIN [20.82.75.6].[TARI].[dbo].[UTENTI_LIST_CONT] B ON A.NUMCON=B.NUMCON AND (A.DTREG BETWEEN B.DTCON AND B.DTRIT) AND A.IDENTI1=B.IDENTI1
INNER JOIN [20.82.75.6].[TARI].[dbo].[CPAZI] C ON C.CODAZI=B.COMUNE

GO

GO