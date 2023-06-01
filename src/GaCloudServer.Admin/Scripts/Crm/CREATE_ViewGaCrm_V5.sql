USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewGaContactCenterTickets]    Script Date: 01/06/2023 08:40:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP VIEW IF EXISTS [dbo].[ViewGaCrmTickets]
GO
CREATE VIEW [dbo].[ViewGaCrmTickets]
AS
SELECT A.Id,A.Id Numero,DataTicket,DataRichiesta,
B.Id ComuneId,B.CodAzi ComuneCod,B.Descrizione ComuneDesc,B.Duration,
A.Utente,A.CodCli,A.NumCon, A.Partita, A.Prg,A.CfPiva,
C.Id CanaleId,C.Descrizione CanaleDesc,
A.Via,A.NumCiv,
A.Telefono,A.Cellulare,A.Email,
D.Id TipoId,D.Descrizione TipoDesc,D.Fatturazione,D.Magazzino,D.PrintTemplate,D.ContactCenterCalendar,D.MagazzinoCalendar,
A.DataChiusura,
E.Id StatoId,E.Descrizione StatoDesc,
A.Creator,A.Assignee,
A.NoteCrm,A.NoteOperatore
FROM GaCrmTickets A
INNER JOIN GaCrmEventComuni B ON A.CrmEventComuneId=B.Id
INNER JOIN GaContactCenterProvenienze C ON A.ContactCenterProvenienzaId=C.Id
INNER JOIN GaContactCenterTipiRichieste D ON A.ContactCenterTipoRichiestaId=D.Id
INNER JOIN GaContactCenterStatiRichieste E ON A.ContactCenterStatoRichiestaId=E.Id
GO