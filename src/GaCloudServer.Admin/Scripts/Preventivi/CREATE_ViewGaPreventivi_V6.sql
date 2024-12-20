USE [GaCloud]
GO

/****** Object:  View [dbo].[[ViewGaPreventiviIsmartDocumenti]]    Script Date: 28/05/2024 10:13:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].ViewGaPreventiviIsmartDocumenti
AS
SELECT cast(0 as bigint) as Id,TRIM(A.[CODCLI]) Codcli
      ,TRIM([BRANCH]) Branch
      ,TRIM([RAGSOC]) Ragsoc
      ,TRIM([PIVA]) Piva
      ,TRIM([CODPAG]) Codpag
      ,TRIM([CODSEZ]) Codsez
      ,TRIM(a.[NUMFAT]) Numfat
      ,[DTFAT] Dtfat
      ,TRIM([TIPDOC]) Tipdoc
      ,A.[PRGFAT] Prgfat
      ,a.[CODCLISED] Codclised
      ,[CONTROLLATA] Controllata
      ,[RAGFAT] Ragfat
      ,[SPLIT_PAYMENT] SplitPayment
      ,[RITENUTE] Ritenute
      ,[IMPORTO_FATT] ImportoFatt
      ,[FILE_XML_FATTURA] FileXmlFattura
      ,[anticipo] Anticipo
      ,[ARCHIVIA] Archivio
      ,[PDF_FILE] PdfFile
	  ,B.IDDOCUMENTO IdDocumento
	  ,B.DATA DataDocCorr
	  ,B.NUMITEM NumItem
	  ,ISNULL(C.INCRIM,0.0) Pagato
      ,cast(0 as bit) [Disabled]
  FROM [20.82.75.6].[GA_ISMART].[dbo].[FATTURE_m001] A
  INNER JOIN [20.82.75.6].[GA_ISMART].[dbo].[FATTURE_DOC_CORRELATI001] B ON A.CODCLI=B.CODCLI AND A.PRGFAT=B.PRGFAT
  LEFT OUTER JOIN (SELECT NUMFAT,DATFAT,SUM(INCRIM) INCRIM FROM [20.82.75.6].[TARI].[dbo].[C90FCAVVPAG] GROUP BY NUMFAT,DATFAT) C ON TRIM(C.NUMFAT)=CONCAT(TRIM(A.NUMFAT),TRIM(A.CODSEZ)) COLLATE DATABASE_DEFAULT AND C.DATFAT=A.DTFAT
  where B.IDDOCUMENTO='PREV'
GO


