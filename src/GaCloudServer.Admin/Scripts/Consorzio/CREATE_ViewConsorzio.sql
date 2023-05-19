CREATE VIEW [dbo].[ViewConsorzioCers]
AS
SELECT        dbo.ConsorzioCers.Id, dbo.ConsorzioCers.Codice, dbo.ConsorzioCers.Pericoloso, dbo.ConsorzioCers.Immagine, dbo.ConsorzioCers.Descrizione, dbo.ConsorzioCersSmaltimenti.Descrizione AS TipoSmaltimento, 
                         dbo.ConsorzioCers.Disabled
FROM            dbo.ConsorzioCers INNER JOIN
                         dbo.ConsorzioCersSmaltimenti ON dbo.ConsorzioCers.ConsorzioCerSmaltimentoId = dbo.ConsorzioCersSmaltimenti.Id
GO


CREATE VIEW [dbo].[ViewConsorzioDestinatari]
AS
SELECT        dbo.ConsorzioDestinatari.Id, dbo.ConsorzioComuni.Descrizione AS Comune, dbo.ConsorzioDestinatari.Indirizzo, dbo.ConsorzioDestinatari.CdPiva AS CfPiva, dbo.ConsorzioDestinatari.Descrizione, 
                         dbo.ConsorzioDestinatari.Disabled
FROM            dbo.ConsorzioDestinatari INNER JOIN
                         dbo.ConsorzioComuni ON dbo.ConsorzioDestinatari.ConsorzioComuneId = dbo.ConsorzioComuni.Id
GO

CREATE VIEW [dbo].[ViewConsorzioTrasportatori]
AS
SELECT        dbo.ConsorzioTrasportatori.Id, dbo.ConsorzioComuni.Descrizione AS Comune, dbo.ConsorzioTrasportatori.Indirizzo, dbo.ConsorzioTrasportatori.CdPiva AS CfPiva, dbo.ConsorzioTrasportatori.Descrizione, 
                         dbo.ConsorzioTrasportatori.Disabled
FROM            dbo.ConsorzioTrasportatori INNER JOIN
                         dbo.ConsorzioComuni ON dbo.ConsorzioTrasportatori.ConsorzioComuneId = dbo.ConsorzioComuni.Id
GO

CREATE VIEW [dbo].[ViewConsorzioProduttori]
AS
SELECT        dbo.ConsorzioProduttori.Id, dbo.ConsorzioComuni.Descrizione AS Comune, dbo.ConsorzioProduttori.Indirizzo, dbo.ConsorzioProduttori.CdPiva AS CfPiva, dbo.ConsorzioProduttori.Descrizione, 
                         dbo.ConsorzioProduttori.Disabled
FROM            dbo.ConsorzioProduttori INNER JOIN
                         dbo.ConsorzioComuni ON dbo.ConsorzioProduttori.ConsorzioComuneId = dbo.ConsorzioComuni.Id
GO

CREATE VIEW [dbo].[ViewConsorzioRegistrazioni]
AS
SELECT        dbo.ConsorzioRegistrazioni.UserId, dbo.ConsorzioRegistrazioni.Roles, dbo.ConsorzioRegistrazioni.PesoTotale, dbo.ConsorzioRegistrazioni.Operazione, dbo.ConsorzioRegistrazioni.DataRegistrazione, 
                         dbo.ConsorzioCers.Codice AS Cer, dbo.ConsorzioProduttori.Descrizione AS Produttore, dbo.ConsorzioTrasportatori.Descrizione AS Trasportatore, dbo.ConsorzioDestinatari.Descrizione AS Destinatario, 
                         dbo.PrivateViewIdentityServerAdminUserList.FullName AS Nominativo, dbo.ConsorzioRegistrazioni.Id, dbo.ConsorzioRegistrazioni.Disabled, dbo.ConsorzioRegistrazioni.ConsorzioProduttoreId AS ProduttoreId
FROM            dbo.ConsorzioProduttori INNER JOIN
                         dbo.ConsorzioRegistrazioni ON dbo.ConsorzioProduttori.Id = dbo.ConsorzioRegistrazioni.ConsorzioProduttoreId INNER JOIN
                         dbo.ConsorzioDestinatari ON dbo.ConsorzioRegistrazioni.ConsorzioDestinatarioId = dbo.ConsorzioDestinatari.Id INNER JOIN
                         dbo.ConsorzioTrasportatori ON dbo.ConsorzioRegistrazioni.ConsorzioTrasportatoreId = dbo.ConsorzioTrasportatori.Id INNER JOIN
                         dbo.ConsorzioCers ON dbo.ConsorzioRegistrazioni.ConsorzioCerId = dbo.ConsorzioCers.Id INNER JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.ConsorzioRegistrazioni.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id
GO