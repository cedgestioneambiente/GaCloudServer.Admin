USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewGaPreventiviAnticipi]    Script Date: 29/01/2024 16:07:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewGaPreventiviAnticipi]
AS
SELECT        dbo.GaPreventiviAnticipi.Id, dbo.GaPreventiviAnticipi.RagioneSociale, dbo.GaPreventiviAnticipi.Numero, dbo.GaPreventiviAnticipi.DataPreventivo, dbo.GaPreventiviAnticipi.DataPagamento, dbo.GaPreventiviAnticipi.CfPiva, 
                         dbo.GaPreventiviAnticipi.Incassato, dbo.GaPreventiviAnticipi.ImportoTotale, dbo.GaPreventiviAnticipi.Anticipo, dbo.GaPreventiviAnticipi.NoteContabili, dbo.GaPreventiviAnticipi.NoteOperative, dbo.GaPreventiviAnticipi.Causale, 
                         dbo.GaPreventiviAnticipi.Pagato, dbo.GaPreventiviAnticipi.Fatturato, dbo.GaPreventiviAnticipi.RegistratoContabilita, dbo.GaPreventiviAnticipi.PreventiviAnticipoTipologiaId, 
                         dbo.GaPreventiviAnticipi.PreventiviAnticipoPagamentoId, dbo.GaPreventiviAnticipi.Disabled, dbo.GaPreventiviAnticipiPagamenti.Descrizione AS TipoPagamento, 
                         dbo.GaPreventiviAnticipiTipologie.Descrizione AS TipoLavoro,
                         CASE 
                            WHEN dbo.GaPreventiviAnticipi.Disabled = 1 THEN 'R'
                            WHEN dbo.GaPreventiviAnticipi.Pagato = 1 AND dbo.GaPreventiviAnticipi.ImportoTotale = dbo.GaPreventiviAnticipi.Incassato THEN 'V'
                            WHEN dbo.GaPreventiviAnticipi.Incassato <> dbo.GaPreventiviAnticipi.ImportoTotale AND dbo.GaPreventiviAnticipi.Anticipo <> 0 THEN 'G'
                            WHEN dbo.GaPreventiviAnticipi.Disabled = 0 AND dbo.GaPreventiviAnticipi.Pagato = 0  AND dbo.GaPreventiviAnticipi.Anticipo = 0  THEN 'Y'
                            ELSE NULL 
                         END AS Saldo
FROM            dbo.GaPreventiviAnticipi 
INNER JOIN dbo.GaPreventiviAnticipiTipologie ON dbo.GaPreventiviAnticipi.PreventiviAnticipoTipologiaId = dbo.GaPreventiviAnticipiTipologie.Id 
LEFT OUTER JOIN dbo.GaPreventiviAnticipiPagamenti ON dbo.GaPreventiviAnticipi.PreventiviAnticipoPagamentoId = dbo.GaPreventiviAnticipiPagamenti.Id
GO