USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewConsorzioComuniDemografie]    Script Date: 15/10/2024 16:55:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewConsorzioComuniDemografie]
AS
SELECT        dbo.ConsorzioComuniDemografie.Id, dbo.ConsorzioComuniDemografie.ConsorzioComuneId, dbo.ConsorzioComuniDemografie.Anno2022, dbo.ConsorzioComuniDemografie.Anno2024, 
                         dbo.ConsorzioComuniDemografie.Anno2023, dbo.ConsorzioComuniDemografie.Anno2025, dbo.ConsorzioComuniDemografie.Anno2026, dbo.ConsorzioComuniDemografie.Anno2027, dbo.ConsorzioComuniDemografie.Disabled, 
                         dbo.ConsorzioComuni.Cap, dbo.ConsorzioComuni.Descrizione, dbo.ConsorzioComuni.Istat, dbo.ConsorzioComuni.Provincia, dbo.ConsorzioComuni.Regione
FROM            dbo.ConsorzioComuni INNER JOIN
                         dbo.ConsorzioComuniDemografie ON dbo.ConsorzioComuni.Id = dbo.ConsorzioComuniDemografie.ConsorzioComuneId
GO