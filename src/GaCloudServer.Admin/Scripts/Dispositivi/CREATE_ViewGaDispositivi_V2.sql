USE[GaCloud]
GO

/****** Object:  View [dbo].[ViewGaDispositiviItems]    Script Date: 12/07/2023 08:51:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


DROP VIEW IF EXISTS [dbo].[ViewGaDispositiviOnDipendenti]
GO


CREATE VIEW [dbo].[ViewGaDispositiviOnDipendenti]
AS
SELECT        dbo.GaDispositiviOnDipendenti.Id, dbo.GaDispositiviOnDipendenti.PersonaleDipendenteId, dbo.GaDispositiviOnDipendenti.DataConsegna, dbo.GaDispositiviOnDipendenti.DataRitiro, dbo.GaDispositiviOnDipendenti.Disabled, 
                         dbo.ViewGaPersonaleDipendenti.CognomeNome AS Nominativo, dbo.ViewGaDispositiviStocks.InfoDispositivo, dbo.ViewGaDispositiviStocks.Serial, dbo.ViewGaDispositiviStocks.Note, dbo.ViewGaDispositiviStocks.AltriDati, 
                         dbo.GaDispositiviOnDipendenti.Note AS NoteAssegnazione
FROM            dbo.GaDispositiviOnDipendenti INNER JOIN
                         dbo.ViewGaPersonaleDipendenti ON dbo.GaDispositiviOnDipendenti.PersonaleDipendenteId = dbo.ViewGaPersonaleDipendenti.Id INNER JOIN
                         dbo.ViewGaDispositiviStocks ON dbo.GaDispositiviOnDipendenti.DispositiviStockId = dbo.ViewGaDispositiviStocks.Id
GO