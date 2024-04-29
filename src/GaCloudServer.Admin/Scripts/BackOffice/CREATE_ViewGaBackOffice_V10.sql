USE [GaCloud]
GO

/****** Object:  View [dbo].[BiViewBackOfficeTariInsolutoNovi]    Script Date: 11/03/2024 15:58:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW ViewGaBackOfficeUtenzeCliFat
AS
SELECT 
CAST(0 as BIGINT) Id,CodCli,Trim(RagSo1) RagSo1,Trim(Ragso2) RagSo2,Via,NumCiv,Cap,Citta,Piva,Prov,CodIva,TipCli,CodPag,Nazione,
Telef,Cel,CodFis,
DtNas,LocNas,CAST(0 AS BIT) Disabled
FROM [20.82.75.6].[tari].[dbo].[C19FCCLIFAT]
GO

CREATE VIEW ViewGaBackOfficeUtenzeCliSed
AS
SELECT
CAST(0 as BIGINT) Id,A.CodCli,A.PrgCli,Trim(A.RagSo1) RagSo1,TRIM(A.Ragso2) RagSo2,
A.Via,A.NumCiv,A.Cap,A.Citta,A.Prov,A.Nazione,A.Scala,A.Piano,A.Isolato,A.Interno,A.Palazzina,
A.ViaR,A.CapR,A.CittaR,A.ProvR,
A.Email,A.EmailF1,A.EmailF2,A.EmailF3,A.Fatture_Email FattureEmail,CAST(0 AS BIT) Disabled
FROM [20.82.75.6].[tari].[dbo].[C19FCCLISED] A
INNER JOIN [20.82.75.6].[tari].[dbo].[C19M_TSCON] b on a.CODCLI=b.CODCOM and a.PRGCLI=b.CODCOMSE
GO


