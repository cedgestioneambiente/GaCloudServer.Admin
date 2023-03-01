USE [GaCloud]
GO
DROP VIEW [dbo].[ViewGaBackOfficeUtenze]
GO
/****** Object:  View [dbo].[ViewGaBackOfficeContenitoriLetture]    Script Date: 02/02/2023 15:37:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewGaBackOfficeUtenze]

AS

SELECT *
FROM
[20.82.75.6].[TARI].[dbo].ViewBackOfficeUtenze 

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewGaBackOfficeUtenzePartite]

AS

SELECT *
FROM
[20.82.75.6].[TARI].[dbo].ViewBackOfficeUtenzePartite 

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewGaBackOfficeUtenzeDispositivi]

AS

SELECT *
FROM
[20.82.75.6].[TARI].[dbo].ViewBackOfficeUtenzeDispositivi 

GO

GO