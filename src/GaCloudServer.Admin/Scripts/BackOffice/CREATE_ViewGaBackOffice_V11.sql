USE [GaCloud]
GO

/****** Object:  View [dbo].[BiViewBackOfficeTariInsolutoNovi]    Script Date: 11/03/2024 15:58:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW ViewGaBackOfficeUtenzePartiteVariazioni
AS
SELECT 
CAST(0 as BIGINT) Id,CAST(0 AS BIT) Disabled,*
FROM [20.82.75.6].[tari].[dbo].[ViewBackOfficeUtenzePartiteVariazioni]
GO


