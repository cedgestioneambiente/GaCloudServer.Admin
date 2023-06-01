USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewGaBackOfficeUtenzePartiteGrp]    Script Date: 01/06/2023 12:21:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP VIEW IF EXISTS [dbo].[ViewGaBackOfficeUtenzePartiteGrp]
GO

CREATE VIEW [dbo].[ViewGaBackOfficeUtenzePartiteGrp]

AS
SELECT *
FROM [20.82.75.6].[TARI].[dbo].ViewGaBackOfficeUtenzePartiteGrp 
GO