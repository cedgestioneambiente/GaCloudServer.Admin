USE [GaCloud]
GO

/****** Object:  View [dbo].[BiViewBackOfficeTariInsolutoNovi]    Script Date: 11/03/2024 15:58:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewGaBackOfficeInsolutoTariNovi]
AS
SELECT CAST(0 AS bigint) as Id,A.CODCLI CodCli,A.NUMCONT NumCont,A.ANNORIF AnnoRif,A.CODICE_TRIBUTO CodTributo,CAST(A.DA_PAGARE AS float) DaPagare,CAST(A.PAGATO AS float) Pagato,CAST(A.SALDO AS float) Saldo,
B.RAGSO RagSo,B.INDIRIZZO Indirizzo,B.CF CodFis,B.DTFAT DtFat,B.NUMFAT NumFat, B.NUM_AVVISO NumAvviso, CAST(0 as bit) Disabled
FROM
[20.82.75.6].[TARI].[dbo].[ViewBackOfficeTariInsolutoNovi] A
INNER JOIN [20.82.75.6].tari.dbo.ViewBackOfficeTariInsolutoDettNovi B ON A.CODCLI=B.CODCLI AND A.ANNORIF=B.ANNORIF
GO