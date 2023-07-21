USE[GaCloud]
GO

/****** Object:  View [dbo].[ViewGaDispositiviItems]    Script Date: 12/07/2023 08:51:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


DROP VIEW IF EXISTS [dbo].[ViewGaDispositiviItems]
GO
DROP VIEW IF EXISTS [dbo].[ViewGaDispositiviStocks]
GO
DROP VIEW IF EXISTS [dbo].[ViewGaDispositiviOnDipendenti]
GO
DROP VIEW IF EXISTS [dbo].[ViewGaDispositiviOnModuli]
GO


CREATE VIEW [dbo].[ViewGaDispositiviItems]
AS
SELECT        dbo.GaDispositiviItems.Id, dbo.GaDispositiviItems.Descrizione, dbo.GaDispositiviTipologie.Descrizione AS Tipologia, dbo.GaDispositiviModelli.Descrizione AS Modello, dbo.GaDispositiviMarche.Descrizione AS Marca,
                         dbo.GaDispositiviClassi.Descrizione AS Classe, dbo.GaDispositiviTipologie.Descrizione + N' - ' + dbo.GaDispositiviMarche.Descrizione + N' ' + dbo.GaDispositiviModelli.Descrizione AS InfoDispositivo,
                         dbo.GaDispositiviItems.Disabled
FROM            dbo.GaDispositiviTipologie INNER JOIN
                         dbo.GaDispositiviItems ON dbo.GaDispositiviTipologie.Id = dbo.GaDispositiviItems.DispositiviTipologiaId INNER JOIN
                         dbo.GaDispositiviModelli ON dbo.GaDispositiviItems.DispositiviModelloId = dbo.GaDispositiviModelli.Id INNER JOIN
                         dbo.GaDispositiviMarche ON dbo.GaDispositiviItems.DispositiviMarcaId = dbo.GaDispositiviMarche.Id INNER JOIN
                         dbo.GaDispositiviClassi ON dbo.GaDispositiviItems.DispositiviClasseId = dbo.GaDispositiviClassi.Id
GO

CREATE VIEW [dbo].[ViewGaDispositiviStocks]
AS
SELECT        dbo.GaDispositiviStocks.Id, dbo.ViewGaDispositiviItems.InfoDispositivo, dbo.GaDispositiviStocks.Serial, dbo.GaDispositiviStocks.Descrizione AS Note, dbo.GaDispositiviStocks.DataRegistrazione, 
                         dbo.GaDispositiviStocks.DataDismissione, dbo.GaDispositiviCategorie.Descrizione AS Categoria, dbo.GaDispositiviStocks.Disponibile, dbo.GaDispositiviStocks.Disabled, dbo.GaDispositiviStocks.AltriDati, 
                         dbo.ViewGaPersonaleDipendenti.CognomeNome AS Nominativo
FROM            dbo.ViewGaPersonaleDipendenti INNER JOIN
                             (SELECT        A.Id, A.DispositiviStockId, A.PersonaleDipendenteId, A.DataConsegna, A.DataRitiro, A.Disabled
                               FROM            dbo.GaDispositiviOnDipendenti AS A INNER JOIN
                                                             (SELECT        DispositiviStockId, MAX(DataConsegna) AS DataConsegna
                                                               FROM            dbo.GaDispositiviOnDipendenti
                                                               WHERE        (DataRitiro IS NULL)
                                                               GROUP BY DispositiviStockId) AS B ON A.DispositiviStockId = B.DispositiviStockId AND A.DataConsegna = B.DataConsegna) AS A_1 ON 
                         dbo.ViewGaPersonaleDipendenti.Id = A_1.PersonaleDipendenteId RIGHT OUTER JOIN
                         dbo.GaDispositiviStocks INNER JOIN
                         dbo.GaDispositiviCategorie ON dbo.GaDispositiviStocks.DispositiviCategoriaId = dbo.GaDispositiviCategorie.Id INNER JOIN
                         dbo.ViewGaDispositiviItems ON dbo.GaDispositiviStocks.DispositiviItemId = dbo.ViewGaDispositiviItems.Id ON A_1.DispositiviStockId = dbo.GaDispositiviStocks.Id
GO

CREATE VIEW [dbo].[ViewGaDispositiviOnDipendenti]
AS
SELECT        dbo.GaDispositiviOnDipendenti.Id, dbo.GaDispositiviOnDipendenti.PersonaleDipendenteId, dbo.GaDispositiviOnDipendenti.DataConsegna, dbo.GaDispositiviOnDipendenti.DataRitiro, dbo.GaDispositiviOnDipendenti.Disabled, 
                         dbo.ViewGaPersonaleDipendenti.CognomeNome AS Nominativo, dbo.ViewGaDispositiviStocks.InfoDispositivo, dbo.ViewGaDispositiviStocks.Serial, dbo.ViewGaDispositiviStocks.Note, 
                         dbo.ViewGaDispositiviStocks.AltriDati
FROM            dbo.GaDispositiviOnDipendenti INNER JOIN
                         dbo.ViewGaPersonaleDipendenti ON dbo.GaDispositiviOnDipendenti.PersonaleDipendenteId = dbo.ViewGaPersonaleDipendenti.Id INNER JOIN
                         dbo.ViewGaDispositiviStocks ON dbo.GaDispositiviOnDipendenti.DispositiviStockId = dbo.ViewGaDispositiviStocks.Id
GO


CREATE VIEW [dbo].[ViewGaDispositiviOnModuli]
AS
SELECT        dbo.GaDispositiviModuli.Id, dbo.GaDispositiviModuli.Data, dbo.GaDispositiviModuli.Numero, dbo.GaDispositiviModuli.PersonaleDipendenteId, dbo.ViewGaDispositiviOnDipendenti.InfoDispositivo, 
                         dbo.ViewGaDispositiviOnDipendenti.Serial, dbo.ViewGaDispositiviOnDipendenti.DataConsegna, dbo.ViewGaDispositiviOnDipendenti.AltriDati, dbo.ViewGaPersonaleDipendenti.CognomeNome AS Nominativo, 
                         dbo.ViewGaPersonaleDipendenti.Sede, dbo.GaDispositiviModuli.Disabled
FROM            dbo.GaDispositiviOnModuli INNER JOIN
                         dbo.GaDispositiviModuli ON dbo.GaDispositiviOnModuli.DispositiviModuloId = dbo.GaDispositiviModuli.Id INNER JOIN
                         dbo.ViewGaDispositiviOnDipendenti ON dbo.GaDispositiviOnModuli.DispositiviOnDipendenteId = dbo.ViewGaDispositiviOnDipendenti.Id INNER JOIN
                         dbo.ViewGaPersonaleDipendenti ON dbo.GaDispositiviModuli.PersonaleDipendenteId = dbo.ViewGaPersonaleDipendenti.Id
GO