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
SELECT A.Id,A.Id Numero,DataTicket,A.DataRichiesta,
B.Id ComuneId,B.CodAzi ComuneCod,CASE WHEN TRIM(B.CodAzi)='C90' OR TRIM(B.CodAzi)='C00' THEN A.ComuneAlt ELSE B.Descrizione END ComuneDesc,B.Duration,
A.Utente,A.CodCli,A.NumCon, A.Partita, A.Prg,A.CfPiva,
C.Id CanaleId,C.Descrizione CanaleDesc,
A.Via,A.NumCiv,A.CodZona,
A.Telefono,A.Cellulare,A.Email,A.EmailPec,
D.Id TipoId,D.Descrizione TipoDesc,D.Fatturazione,D.Magazzino,D.ContactCenterPrintTemplateId PrintTemplate,D.ContactCenterCalendar,D.MagazzinoCalendar,
A.DataChiusura,
E.Id StatoId,E.Descrizione StatoDesc,
A.Creator, F.FullName CreatorDesc,A.Assignee,REPLACE(G.Name,'AppCRM','') AssigneeDesc,
A.NoteCrm,A.NoteOperatore,
A.Tributo,
A.Tags
,H.DateSchedule DataProgrammazione,
CAST(0 AS BIT) Disabled
FROM GaCrmTickets A
INNER JOIN GaCrmEventComuni B ON A.CrmEventComuneId=B.Id
INNER JOIN GaContactCenterProvenienze C ON A.ContactCenterProvenienzaId=C.Id
INNER JOIN GaContactCenterTipiRichieste D ON A.ContactCenterTipoRichiestaId=D.Id
INNER JOIN GaContactCenterStatiRichieste E ON A.ContactCenterStatoRichiestaId=E.Id
INNER JOIN IdentityServerAdmin.dbo.Users F ON A.Creator=F.Id
INNER JOIN IdentityServerAdmin.dbo.Roles G ON A.Assignee=G.Id
LEFT OUTER JOIN GaCrmEvents H ON H.CrmTicketId=A.Id
GO
