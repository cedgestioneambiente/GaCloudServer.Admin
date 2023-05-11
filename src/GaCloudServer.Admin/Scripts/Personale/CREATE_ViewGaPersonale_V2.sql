USE [GaCloud]
GO

DROP VIEW IF EXISTS [dbo].[ViewGaPersonaleScadenziario]
DROP VIEW IF EXISTS [dbo].[ViewGaPersonaleScadenziarioAbilitazioni]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[ViewGaPersonaleScadenziario]
AS
SELECT        dbo.GaPersonaleDipendenti.Id, dbo.PrivateViewIdentityServerAdminUserList.FirstName + N' ' + dbo.PrivateViewIdentityServerAdminUserList.LastName AS Dipendente, dbo.GlobalSedi.Descrizione AS Sede, 
                         dbo.GaPersonaleScadenzeTipi.Descrizione AS ScadenzaTipo, dbo.GaPersonaleScadenzeDettagli.Descrizione AS ScadenzaDettaglio, dbo.GaPersonaleScadenze.DataScadenza, dbo.GaPersonaleScadenze.FileId, 
                         dbo.GaPersonaleDipendenti.Disabled AS DipendentiDisabled, (CASE WHEN DATEDIFF(day, GETDATE(), GaPersonaleScadenze.DataScadenza) < 0 THEN 'R' WHEN DATEDIFF(day, GETDATE(), 
                         GaPersonaleScadenze.DataScadenza) < 30 THEN 'G' ELSE 'V' END) AS Stato, dbo.GaPersonaleScadenze.FileName, dbo.GaPersonaleScadenze.Disabled
FROM            dbo.GaPersonaleDipendenti INNER JOIN
                         dbo.GlobalSedi ON dbo.GaPersonaleDipendenti.GlobalSedeId = dbo.GlobalSedi.Id INNER JOIN
                         dbo.GaPersonaleScadenze ON dbo.GaPersonaleDipendenti.Id = dbo.GaPersonaleScadenze.PersonaleDipendenteId INNER JOIN
                         dbo.GaPersonaleScadenzeDettagli ON dbo.GaPersonaleScadenze.PersonaleScadenzaDettaglioId = dbo.GaPersonaleScadenzeDettagli.Id INNER JOIN
                         dbo.GaPersonaleScadenzeTipi ON dbo.GaPersonaleScadenze.PersonaleScadenzaTipoId = dbo.GaPersonaleScadenzeTipi.Id INNER JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.GaPersonaleDipendenti.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id
WHERE        (dbo.GaPersonaleScadenze.Disabled = 0) AND (dbo.GaPersonaleDipendenti.Disabled = 0)
GO

CREATE VIEW [dbo].[ViewGaPersonaleScadenziarioAbilitazioni]
AS
SELECT        dbo.GaPersonaleDipendenti.Id, dbo.PrivateViewIdentityServerAdminUserList.FirstName + N' ' + dbo.PrivateViewIdentityServerAdminUserList.LastName AS Dipendente, dbo.GlobalSedi.Descrizione AS Sede, 
                         dbo.GaPersonaleAbilitazioniTipi.Descrizione AS AbilitazioneTipo, dbo.GaPersonaleAbilitazioni.DettaglioAbilitazione AS AbilitazioneDettaglio, dbo.GaPersonaleAbilitazioni.DataVisita, dbo.GaPersonaleAbilitazioni.DataScadenza, 
                         dbo.GaPersonaleAbilitazioni.FileId, dbo.GaPersonaleAbilitazioni.FileName, CASE WHEN DATEDIFF(day, GETDATE(), dbo.GaPersonaleAbilitazioni.DataScadenza) < 0 THEN 'R' WHEN DATEDIFF(day, GETDATE(), 
                         dbo.GaPersonaleAbilitazioni.DataScadenza) < 30 THEN 'G' ELSE 'V' END AS Stato, dbo.GaPersonaleDipendenti.Disabled AS DipendentiDisabled, dbo.GaPersonaleAbilitazioni.Disabled
FROM            dbo.GaPersonaleDipendenti INNER JOIN
                         dbo.GlobalSedi ON dbo.GaPersonaleDipendenti.GlobalSedeId = dbo.GlobalSedi.Id INNER JOIN
                         dbo.GaPersonaleAbilitazioni ON dbo.GaPersonaleDipendenti.Id = dbo.GaPersonaleAbilitazioni.PersonaleDipendenteId INNER JOIN
                         dbo.GaPersonaleAbilitazioniTipi ON dbo.GaPersonaleAbilitazioni.PersonaleAbilitazioneTipoId = dbo.GaPersonaleAbilitazioniTipi.Id INNER JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.GaPersonaleDipendenti.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id
WHERE        (dbo.GaPersonaleDipendenti.Disabled = 0) AND (dbo.GaPersonaleAbilitazioni.Disabled = 0)
GO