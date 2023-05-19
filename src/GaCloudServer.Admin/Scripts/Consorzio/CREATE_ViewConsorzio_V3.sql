USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewGaCdrConferimenti]    Script Date: 17/04/2023 11:45:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP VIEW IF EXISTS [dbo].[ViewConsorzioProduttori]
GO
DROP VIEW IF EXISTS [dbo].[ViewConsorzioDestinatari]
GO
DROP VIEW IF EXISTS [dbo].[ViewConsorzioTrasportatori]
GO

CREATE VIEW [dbo].[ViewConsorzioProduttori]
AS
SELECT        dbo.ConsorzioProduttori.Id, dbo.ConsorzioComuni.Descrizione + N' ' + N'(' + dbo.ConsorzioComuni.Provincia + N')' AS Comune, dbo.ConsorzioProduttori.Indirizzo, dbo.ConsorzioProduttori.CdPiva AS CfPiva, 
                         dbo.ConsorzioProduttori.Descrizione, dbo.ConsorzioProduttori.Disabled, dbo.ConsorzioProduttori.Indirizzo + N' ' + dbo.ConsorzioComuni.Descrizione + N' ' + N'(' + dbo.ConsorzioComuni.Provincia + N')' AS IndirizzoEsteso
FROM            dbo.ConsorzioProduttori INNER JOIN
                         dbo.ConsorzioComuni ON dbo.ConsorzioProduttori.ConsorzioComuneId = dbo.ConsorzioComuni.Id
GO

CREATE VIEW [dbo].[ViewConsorzioDestinatari]
AS
SELECT        dbo.ConsorzioDestinatari.Id, dbo.ConsorzioComuni.Descrizione + N' ' + N'(' + dbo.ConsorzioComuni.Provincia + N')' AS Comune, dbo.ConsorzioDestinatari.Indirizzo, dbo.ConsorzioDestinatari.CdPiva AS CfPiva, 
                         dbo.ConsorzioDestinatari.Descrizione, dbo.ConsorzioDestinatari.Disabled, 
                         dbo.ConsorzioDestinatari.Indirizzo + N' ' + dbo.ConsorzioComuni.Descrizione + N' ' + N'(' + dbo.ConsorzioComuni.Provincia + N')' AS IndirizzoEsteso
FROM            dbo.ConsorzioDestinatari INNER JOIN
                         dbo.ConsorzioComuni ON dbo.ConsorzioDestinatari.ConsorzioComuneId = dbo.ConsorzioComuni.Id
GO

CREATE VIEW [dbo].[ViewConsorzioTrasportatori]
AS
SELECT        dbo.ConsorzioTrasportatori.Id, dbo.ConsorzioComuni.Descrizione + N' ' + N'(' + dbo.ConsorzioComuni.Provincia + N')' AS Comune, dbo.ConsorzioTrasportatori.Indirizzo, dbo.ConsorzioTrasportatori.CdPiva AS CfPiva, 
                         dbo.ConsorzioTrasportatori.Descrizione, dbo.ConsorzioTrasportatori.Disabled, 
                         dbo.ConsorzioTrasportatori.Indirizzo + N' ' + dbo.ConsorzioComuni.Descrizione + N' ' + N'(' + dbo.ConsorzioComuni.Provincia + N')' AS IndirizzoEsteso
FROM            dbo.ConsorzioTrasportatori INNER JOIN
                         dbo.ConsorzioComuni ON dbo.ConsorzioTrasportatori.ConsorzioComuneId = dbo.ConsorzioComuni.Id
GO