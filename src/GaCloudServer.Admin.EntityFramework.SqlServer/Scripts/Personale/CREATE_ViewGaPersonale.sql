CREATE VIEW [dbo].[ViewGaPersonaleUsersOnDipendenti]
AS
SELECT CAST('0' AS BIGINT) Id, A.Id UserId,FirstName Nome,LastName Cognome, CONCAT(LastName,' ',FirstName) CognomeNome,Email,UserName, CASE WHEN(B.Id IS NULL) THEN CASt(0 as bigint) else B.Id END DipendenteId, CASE WHEN(B.Id IS NOT NULL) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END Active,CAST(0 as BIT) Disabled
FROM IdentityServerAdmin.dbo.Users A
LEFT JOIN GaPersonaleDipendenti B ON A.Id=B.UserId
GO  --mod

CREATE VIEW [dbo].[ViewGaPersonaleDipendenti]
AS
SELECT        A.Id, B.Id AS UserId, B.FirstName AS Nome, B.LastName AS Cognome, CONCAT(B.LastName,' ',B.FirstName) CognomeNome, C.Descrizione AS Sede, C.Id AS SedeId, D.Descrizione AS Qualifica, D.Id AS QualificaId, A.Disabled, dbo.GlobalSettori.Descrizione AS Settore, 
                         dbo.GlobalSettori.Id AS SettoreId,B.Email
FROM            dbo.GaPersonaleDipendenti AS A INNER JOIN
                         dbo.GlobalSettori ON A.GlobalSettoreId = dbo.GlobalSettori.Id LEFT OUTER JOIN
                         IdentityServerAdmin.dbo.Users AS B ON A.UserId = B.Id LEFT OUTER JOIN
                         dbo.GlobalSedi AS C ON C.Id = A.GlobalSedeId LEFT OUTER JOIN
                         dbo.GaPersonaleQualifiche AS D ON D.Id = A.PersonaleQualificaId
GO

CREATE VIEW [dbo].[ViewGaPersonaleScadenze]
AS
SELECT        [dbo].[GaPersonaleScadenze].Id, dbo.[GaPersonaleScadenze].[PersonaleDipendenteId] DipendenteId, dbo.[GaPersonaleScadenzeTipi].Descrizione AS ScadenzaTipo, [dbo].[GaPersonaleScadenzeTipi].[Id] AS ScadenzaTipoId, 
                                         dbo.[GaPersonaleScadenzeDettagli].Descrizione AS ScadenzaDettaglio, dbo.[GaPersonaleScadenze].DataScadenza, dbo.[GaPersonaleScadenze].FileId, dbo.[GaPersonaleScadenze].Disabled,
										 CASE WHEN DATEDIFF(day , GETDATE() , DataScadenza) < 0 THEN 'R' WHEN DATEDIFF(day , GETDATE() , DataScadenza) < 30 THEN 'G' ELSE 'V' END as Stato,dbo.[GaPersonaleScadenze].FileName
                FROM            [dbo].[GaPersonaleScadenze] INNER JOIN
                                         [dbo].[GaPersonaleScadenzeDettagli] ON dbo.[GaPersonaleScadenze].[PersonaleScadenzaDettaglioId] = dbo.[GaPersonaleScadenzeDettagli].Id INNER JOIN
                                         [dbo].[GaPersonaleScadenzeTipi] ON dbo.[GaPersonaleScadenze].[PersonaleScadenzaTipoId] = dbo.[GaPersonaleScadenzeTipi].Id
GO

CREATE VIEW [dbo].[ViewGaPersonaleNuoveSchede]
                AS
                SELECT        dbo.GaPersonaleArticoli.Id, dbo.GaPersonaleArticoliTipologie.Descrizione + ' - ' + dbo.GaPersonaleArticoliModelli.Descrizione AS Articolo, 
                                         dbo.GaPersonaleArticoliDpis.Descrizione AS Dpi, '' AS Taglia, CAST(0 as int) AS Qta, dbo.GaPersonaleArticoli.Disabled
                FROM            dbo.GaPersonaleArticoli INNER JOIN
                                         dbo.GaPersonaleArticoliTipologie ON dbo.GaPersonaleArticoli.PersonaleArticoloTipologiaId = dbo.GaPersonaleArticoliTipologie.Id INNER JOIN
                                         dbo.GaPersonaleArticoliModelli ON dbo.GaPersonaleArticoli.PersonaleArticoloModelloId = dbo.GaPersonaleArticoliModelli.Id INNER JOIN
                                         dbo.GaPersonaleArticoliDpis ON dbo.GaPersonaleArticoli.PersonaleArticoloDpiId = dbo.GaPersonaleArticoliDpis.Id
GO

CREATE VIEW [dbo].[ViewGaPersonaleAbilitazioni]
AS
SELECT        dbo.GaPersonaleAbilitazioni.Id, dbo.GaPersonaleAbilitazioni.PersonaleDipendenteId AS DipendenteId, dbo.GaPersonaleAbilitazioni.DataVisita, dbo.GaPersonaleAbilitazioni.DataScadenza, dbo.GaPersonaleAbilitazioniTipi.Descrizione AS Tipo, 
                         dbo.GaPersonaleAbilitazioni.DettaglioAbilitazione, dbo.GaPersonaleAbilitazioni.FileId, dbo.GaPersonaleAbilitazioni.FileName, dbo.GaPersonaleAbilitazioni.Disabled
FROM            dbo.GaPersonaleAbilitazioni INNER JOIN
                         dbo.GaPersonaleAbilitazioniTipi ON dbo.GaPersonaleAbilitazioni.PersonaleAbilitazioneTipoId = dbo.GaPersonaleAbilitazioniTipi.Id
GO

CREATE VIEW [dbo].[ViewGaPersonaleArticoli]
                AS
                SELECT        dbo.GaPersonaleArticoli.Id, dbo.GaPersonaleArticoliTipologie.Descrizione AS Tipologia, dbo.GaPersonaleArticoliModelli.Descrizione AS Modello, 
                                         dbo.GaPersonaleArticoliDpis.Descrizione AS Dpi, dbo.GaPersonaleArticoli.Disabled
                FROM            dbo.GaPersonaleArticoli INNER JOIN
                                         dbo.GaPersonaleArticoliDpis ON dbo.GaPersonaleArticoli.PersonaleArticoloDpiId = dbo.GaPersonaleArticoliDpis.Id INNER JOIN
                                         dbo.GaPersonaleArticoliModelli ON dbo.GaPersonaleArticoli.PersonaleArticoloModelloId = dbo.GaPersonaleArticoliModelli.Id INNER JOIN
                                         dbo.GaPersonaleArticoliTipologie ON dbo.GaPersonaleArticoli.PersonaleArticoloTipologiaId = dbo.GaPersonaleArticoliTipologie.Id
GO

CREATE VIEW [dbo].[ViewGaPersonaleRetributivi]
AS
SELECT        dbo.GaPersonaleRetributivi.Id, dbo.GaPersonaleRetributivi.PersonaleDipendenteId AS DipendenteId, dbo.PrivateViewIdentityServerAdminUserList.FirstName + N' ' + dbo.PrivateViewIdentityServerAdminUserList.LastName AS Dipendente, 
                         dbo.GaPersonaleRetributivi.Data, dbo.GaPersonaleRetributivi.DettaglioRetributivo, dbo.GaPersonaleRetributivi.FileId, dbo.GaPersonaleRetributivi.FileName, dbo.GaPersonaleDipendenti.GlobalSedeId AS SedeId, dbo.GlobalSedi.Descrizione AS Sede, 
                         dbo.GaPersonaleRetributiviTipi.Descrizione AS Tipo, dbo.GaPersonaleRetributivi.Disabled
FROM            dbo.GaPersonaleRetributivi INNER JOIN
                         dbo.GaPersonaleRetributiviTipi ON dbo.GaPersonaleRetributivi.PersonaleRetributivoTipoId = dbo.GaPersonaleRetributiviTipi.Id INNER JOIN
                         dbo.GaPersonaleDipendenti ON dbo.GaPersonaleRetributivi.PersonaleDipendenteId = dbo.GaPersonaleDipendenti.Id INNER JOIN
                         dbo.GlobalSedi ON dbo.GaPersonaleDipendenti.GlobalSedeId = dbo.GlobalSedi.Id INNER JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.GaPersonaleDipendenti.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id
GO

CREATE VIEW [dbo].[ViewGaPersonaleSanzioni]
AS
SELECT        dbo.GaPersonaleSanzioni.Id, dbo.PrivateViewIdentityServerAdminUserList.FirstName + N' ' + dbo.PrivateViewIdentityServerAdminUserList.LastName AS Dipendente, dbo.GaPersonaleSanzioni.PersonaleDipendenteId AS DipendenteId, 
                         dbo.GaPersonaleSanzioni.Data, dbo.GaPersonaleSanzioni.FileId, dbo.GaPersonaleSanzioni.FileName, dbo.GaPersonaleSanzioniMotivi.Descrizione AS Motivo, dbo.GaPersonaleDipendenti.GlobalSedeId AS SedeId, 
                         dbo.GlobalSedi.Descrizione AS Sede, dbo.GaPersonaleSanzioniDescrizioni.Descrizione, dbo.GaPersonaleSanzioni.Disabled, dbo.GaPersonaleSanzioni.DettaglioSanzione
FROM            dbo.GaPersonaleSanzioni INNER JOIN
                         dbo.GaPersonaleDipendenti ON dbo.GaPersonaleSanzioni.PersonaleDipendenteId = dbo.GaPersonaleDipendenti.Id INNER JOIN
                         dbo.GaPersonaleSanzioniDescrizioni ON dbo.GaPersonaleSanzioni.PersonaleSanzioneDescrizioneId = dbo.GaPersonaleSanzioniDescrizioni.Id INNER JOIN
                         dbo.GaPersonaleSanzioniMotivi ON dbo.GaPersonaleSanzioni.PersonaleSanzioneMotivoId = dbo.GaPersonaleSanzioniMotivi.Id INNER JOIN
                         dbo.GlobalSedi ON dbo.GaPersonaleDipendenti.GlobalSedeId = dbo.GlobalSedi.Id INNER JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.GaPersonaleDipendenti.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id
GO

CREATE VIEW [dbo].[ViewGaPersonaleSchedeConsegne]
AS
SELECT        dbo.GaPersonaleSchedeConsegneDettagli.Id, dbo.GaPersonaleSchedeConsegne.Id AS SchedaConsegnaId, dbo.GaPersonaleSchedeConsegne.Data, dbo.GaPersonaleSchedeConsegne.PersonaleDipendenteId AS DipendenteId, 
                         dbo.PrivateViewIdentityServerAdminUserList.FirstName + N' ' + dbo.PrivateViewIdentityServerAdminUserList.LastName AS Dipendente, dbo.GlobalSedi.Descrizione AS Sede, 
                         dbo.GaPersonaleArticoliTipologie.Descrizione + ' - ' + dbo.GaPersonaleArticoliModelli.Descrizione AS Articolo, dbo.GaPersonaleArticoliDpis.Descrizione AS Dpi, dbo.GaPersonaleSchedeConsegneDettagli.Taglia, 
                         dbo.GaPersonaleSchedeConsegneDettagli.Qta, dbo.GaPersonaleSchedeConsegne.Numero, dbo.GaPersonaleDipendenti.Disabled
FROM            dbo.GaPersonaleSchedeConsegneDettagli INNER JOIN
                         dbo.GaPersonaleSchedeConsegne ON dbo.GaPersonaleSchedeConsegneDettagli.PersonaleSchedaConsegnaId = dbo.GaPersonaleSchedeConsegne.Id INNER JOIN
                         dbo.GaPersonaleDipendenti ON dbo.GaPersonaleSchedeConsegne.PersonaleDipendenteId = dbo.GaPersonaleDipendenti.Id INNER JOIN
                         dbo.GlobalSedi ON dbo.GaPersonaleDipendenti.GlobalSedeId = dbo.GlobalSedi.Id INNER JOIN
                         dbo.GaPersonaleArticoli ON dbo.GaPersonaleSchedeConsegneDettagli.PersonaleArticoloId = dbo.GaPersonaleArticoli.Id INNER JOIN
                         dbo.GaPersonaleArticoliDpis ON dbo.GaPersonaleArticoli.PersonaleArticoloDpiId = dbo.GaPersonaleArticoliDpis.Id INNER JOIN
                         dbo.GaPersonaleArticoliTipologie ON dbo.GaPersonaleArticoli.PersonaleArticoloTipologiaId = dbo.GaPersonaleArticoliTipologie.Id INNER JOIN
                         dbo.GaPersonaleArticoliModelli ON dbo.GaPersonaleArticoli.PersonaleArticoloModelloId = dbo.GaPersonaleArticoliModelli.Id INNER JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.GaPersonaleDipendenti.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id
GO

CREATE VIEW [dbo].[ViewGaPersonaleScadenziario]
AS
SELECT        dbo.GaPersonaleDipendenti.Id, dbo.PrivateViewIdentityServerAdminUserList.FirstName + N' ' + dbo.PrivateViewIdentityServerAdminUserList.LastName AS Dipendente, dbo.GlobalSedi.Descrizione AS Sede, 
                         dbo.GaPersonaleScadenzeTipi.Descrizione AS ScadenzaTipo, dbo.GaPersonaleScadenzeDettagli.Descrizione AS ScadenzaDettaglio, dbo.GaPersonaleScadenze.DataScadenza, 
                         dbo.GaPersonaleScadenze.FileId, dbo.GaPersonaleDipendenti.Disabled, (CASE WHEN DATEDIFF(day, GETDATE(), GaPersonaleScadenze.DataScadenza) < 0 THEN 'R' WHEN DATEDIFF(day, GETDATE(), 
                         GaPersonaleScadenze.DataScadenza) < 30 THEN 'G' ELSE 'V' END) AS Stato, dbo.GaPersonaleScadenze.FileName
FROM            dbo.GaPersonaleDipendenti INNER JOIN
                         dbo.GlobalSedi ON dbo.GaPersonaleDipendenti.GlobalSedeId = dbo.GlobalSedi.Id INNER JOIN
                         dbo.GaPersonaleScadenze ON dbo.GaPersonaleDipendenti.Id = dbo.GaPersonaleScadenze.PersonaleDipendenteId INNER JOIN
                         dbo.GaPersonaleScadenzeDettagli ON dbo.GaPersonaleScadenze.PersonaleScadenzaDettaglioId = dbo.GaPersonaleScadenzeDettagli.Id INNER JOIN
                         dbo.GaPersonaleScadenzeTipi ON dbo.GaPersonaleScadenze.PersonaleScadenzaTipoId = dbo.GaPersonaleScadenzeTipi.Id INNER JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.GaPersonaleDipendenti.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id
GO

CREATE VIEW [dbo].[ViewGaPersonaleScadenziarioAbilitazioni]
AS
SELECT        dbo.GaPersonaleDipendenti.Id, dbo.PrivateViewIdentityServerAdminUserList.FirstName + N' ' + dbo.PrivateViewIdentityServerAdminUserList.LastName AS Dipendente, dbo.GlobalSedi.Descrizione AS Sede, 
                         dbo.GaPersonaleAbilitazioniTipi.Descrizione AS AbilitazioneTipo, dbo.GaPersonaleAbilitazioni.DettaglioAbilitazione AS AbilitazioneDettaglio, dbo.GaPersonaleAbilitazioni.DataVisita, dbo.GaPersonaleAbilitazioni.DataScadenza, 
                         dbo.GaPersonaleAbilitazioni.FileId, dbo.GaPersonaleAbilitazioni.FileName, CASE WHEN DATEDIFF(day, GETDATE(), dbo.GaPersonaleAbilitazioni.DataScadenza) < 0 THEN 'R' WHEN DATEDIFF(day, GETDATE(), 
                         dbo.GaPersonaleAbilitazioni.DataScadenza) < 30 THEN 'G' ELSE 'V' END AS Stato, dbo.GaPersonaleDipendenti.Disabled
FROM            dbo.GaPersonaleDipendenti INNER JOIN
                         dbo.GlobalSedi ON dbo.GaPersonaleDipendenti.GlobalSedeId = dbo.GlobalSedi.Id INNER JOIN
                         dbo.GaPersonaleAbilitazioni ON dbo.GaPersonaleDipendenti.Id = dbo.GaPersonaleAbilitazioni.PersonaleDipendenteId INNER JOIN
                         dbo.GaPersonaleAbilitazioniTipi ON dbo.GaPersonaleAbilitazioni.PersonaleAbilitazioneTipoId = dbo.GaPersonaleAbilitazioniTipi.Id INNER JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.GaPersonaleDipendenti.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id
GO