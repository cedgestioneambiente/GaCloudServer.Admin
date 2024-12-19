USE [GaCloud]
GO

/****** Object:  View [dbo].[[ViewGaPreventiviIsmartDocumenti]]    Script Date: 28/05/2024 10:13:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].ViewGaPreventiviIsmartDocumenti
AS
SELECT A.[CODCLI]
      ,[BRANCH]
      ,[RAGSOC]
      ,[PIVA]
      ,[CODPAG]
      ,[CODSEZ]
      ,[NUMFAT]
      ,[DTFAT]
      ,[TIPDOC]
      ,A.[PRGFAT]
      ,[CODCLISED]
      ,[CONTROLLATA]
      ,[RAGFAT]
      ,[SPLIT_PAYMENT]
      ,[RITENUTE]
      ,[IMPORTO_FATT]
      ,[FILE_XML_FATTURA]
      ,[anticipo]
      ,[ARCHIVIA]
      ,[PDF_FILE]
	  ,B.IDDOCUMENTO
	  ,B.DATA DATA_DOC_CORR
	  ,B.NUMITEM
  FROM [20.82.75.6].[GA_ISMART].[dbo].[FATTURE_m001] A
  INNER JOIN [20.82.75.6].[GA_ISMART].[dbo].[FATTURE_DOC_CORRELATI001] B ON A.CODCLI=B.CODCLI AND A.PRGFAT=B.PRGFAT
  where B.IDDOCUMENTO='PREV'
GO


