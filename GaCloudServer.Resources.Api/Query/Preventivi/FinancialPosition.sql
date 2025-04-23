SELECT 
[CODCLI] CodCli
,[RAGSO] RagSo
,[CODFIS] CodFis
,[PIVA] PIva
,[TELEF] Telef
,[CEL] Cel
,[EMAIL] Email
,[EMAIL_PEC] EmailPec
,[VIA] Via
,[NUMCIV] NumCiv
,[PRESSO] Presso
,[CAP] Cap
,[PROV] Prov
,[CITTA] Citta
,[NUMFAT] NumFat
,[TIPDOC] TipDoc
,[STORNO] Storno
,[NUMFATO] NumFato
,[ANNORIF] AnnoRif
,[COMUNE] Comune
,[UTEDOM] UteDom
,[PERIODO] Periodo
,[DTFAT] DtFat
,[DATSCA1] DatSca1
,[DATSCA2] DatSca2
,CAST([TOTFAT] AS FLOAT) TotFat
,CAST([PAGATO] AS FLOAT) Pagato
,CAST([SALDO] AS FLOAT) Saldo
,CAST(
CAST(SALDO AS FLOAT)/
CASE WHEN CAST(TOTFAT AS FLOAT)=0 THEN 1 ELSE CAST(TOTFAT AS FLOAT) END
AS FLOAT) PrcInsoluto,
'Cliente Tariffa' TipCli
FROM [20.82.75.6].TARI.dbo.ViewBackOfficeIncassatoInsoluto
WHERE (CODFIS='{0}' OR PIVA ='{1}') OR (CODFIS='{2}' OR PIVA ='{3}')
UNION
SELECT 
[CODCLI] CodCli
,[RAGSO] RagSo
,[CODFIS] CodFis
,[PIVA] PIva
,[TELEF] Telef
,[CEL] Cel
,[EMAIL] Email
,[EMAIL_PEC] EmailPec
,[VIA] Via
,[NUMCIV] NumCiv
,[PRESSO] Presso
,[CAP] Cap
,[PROV] Prov
,[CITTA] Citta
,[NUMFAT] NumFat
,[TIPDOC] TipDoc
,[STORNO] Storno
,[NUMFATO] NumFato
,[ANNORIF] AnnoRif
,[COMUNE] Comune
,[UTEDOM] UteDom
,[PERIODO] Periodo
,[DTFAT] DtFat
,[DATSCA1] DatSca1
,[DATSCA2] DatSca2
,CAST([TOTFAT] AS FLOAT) TotFat
,CAST([PAGATO] AS FLOAT) Pagato
,CAST([SALDO] AS FLOAT) Saldo
,CAST(
CAST(SALDO AS FLOAT)/
CASE WHEN CAST(TOTFAT AS FLOAT)=0 THEN 1 ELSE CAST(TOTFAT AS FLOAT) END
AS FLOAT) PrcInsoluto,
'Cliente Privato' TipCli
FROM [20.82.75.6].TARI.dbo.ViewBackOfficeIncassatoInsolutoC90
WHERE (CODFIS='{0}' OR PIVA ='{1}') OR (CODFIS='{2}' OR PIVA ='{3}')
--UNION
--SELECT 
--[CODCLI] CodCli
--,[RAGSO] RagSo
--,[CODFIS] CodFis
--,[PIVA] PIva
--,[TELEF] Telef
--,[CEL] Cel
--,[EMAIL] Email
--,[EMAIL_PEC] EmailPec
--,[VIA] Via
--,[NUMCIV] NumCiv
--,[PRESSO] Presso
--,[CAP] Cap
--,[PROV] Prov
--,[CITTA] Citta
--,[NUMFAT] NumFat
--,[TIPDOC] TipDoc
--,[STORNO] Storno
--,[NUMFATO] NumFato
--,[ANNORIF] AnnoRif
--,[COMUNE] Comune
--,[UTEDOM] UteDom
--,[PERIODO] Periodo
--,[DTFAT] DtFat
--,[DATSCA1] DatSca1
--,[DATSCA2] DatSca2
--,CAST([TOTFAT] AS FLOAT) TotFat
--,CAST([PAGATO] AS FLOAT) Pagato
--,CAST([SALDO] AS FLOAT) Saldo
--,CAST(
--CAST(SALDO AS FLOAT)/
--CASE WHEN CAST(TOTFAT AS FLOAT)=0 THEN 1 ELSE CAST(TOTFAT AS FLOAT) END
--AS FLOAT) PrcInsoluto,
--'Cliente Tari' TipCli
--FROM [20.82.75.6].TARI.dbo.ViewBackOfficeIncassatoInsolutoC19
--WHERE (CODFIS='{0}' OR PIVA ='{1}') OR (CODFIS='{2}' OR PIVA ='{3}')