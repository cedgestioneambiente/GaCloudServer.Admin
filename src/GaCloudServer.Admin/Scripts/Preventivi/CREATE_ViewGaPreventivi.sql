USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewGaPreventiviAnticipi]    Script Date: 29/01/2024 16:07:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewGaPreventiviAnticipi]
AS
SELECT        dbo.GaPreventiviAnticipiPagamenti.Descrizione AS TipoPagamento, dbo.GaPreventiviAnticipiTipologie.Descrizione AS TipoLavoro, dbo.GaPreventiviAnticipi.Id, dbo.GaPreventiviAnticipi.NoteOperative, 
                         dbo.GaPreventiviAnticipi.NoteContabili, dbo.GaPreventiviAnticipi.Numero, dbo.GaPreventiviAnticipi.DataPreventivo, dbo.GaPreventiviAnticipi.DataPagamento, dbo.GaPreventiviAnticipi.ValoreIncassato, 
                         dbo.GaPreventiviAnticipi.ValorePrevisto, dbo.GaPreventiviAnticipi.Pagato, dbo.GaPreventiviAnticipi.Disabled, dbo.GaPreventiviAnticipi.RagioneSociale, dbo.GaPreventiviAnticipi.Causale, dbo.GaPreventiviAnticipi.CfPiva, 
                         dbo.GaPreventiviAnticipi.Fatturato, dbo.GaPreventiviAnticipi.PreventiviAnticipoTipologiaId, dbo.GaPreventiviAnticipi.PreventiviAnticipoPagamentoId, 
                         CASE WHEN ValoreIncassato = ValorePrevisto THEN 'V' ELSE 'R' END AS Saldo
FROM            dbo.GaPreventiviAnticipi INNER JOIN
                         dbo.GaPreventiviAnticipiPagamenti ON dbo.GaPreventiviAnticipi.Id = dbo.GaPreventiviAnticipiPagamenti.Id INNER JOIN
                         dbo.GaPreventiviAnticipiTipologie ON dbo.GaPreventiviAnticipi.PreventiviAnticipoTipologiaId = dbo.GaPreventiviAnticipiTipologie.Id
GO