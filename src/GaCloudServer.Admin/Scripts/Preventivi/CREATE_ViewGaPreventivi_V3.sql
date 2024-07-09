USE [GaCloud]
GO

/****** Object:  View [dbo].[[ViewGaPreventiviTickets]]    Script Date: 28/05/2024 10:13:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[ViewGaPreventiviCrmTickets]
AS
SELECT A.Id,A.Id Numero,DataTicket,A.DataRichiesta,
B.Id ComuneId,B.CodAzi ComuneCod,
CASE WHEN B.CodAzi='C00' THEN A.ComuneAlt ELSE B.Descrizione END ComuneDesc,
B.Duration,
A.Utente,A.CodCli,A.NumCon, A.Partita, A.Prg,A.CfPiva,A.CodSdi,
C.Id CanaleId,C.Descrizione CanaleDesc,
A.Via,A.NumCiv,A.CodZona,
A.Telefono,A.Cellulare,A.Email,A.EmailPec,
D.Id TipoId,D.Descrizione TipoDesc,D.Fatturazione,D.Magazzino,D.ContactCenterPrintTemplateId PrintTemplate,D.ContactCenterCalendar,D.MagazzinoCalendar,D.Commerciale,D.Important,
A.DataChiusura,
E.Id StatoId,E.Descrizione StatoDesc,
A.Creator, F.FullName CreatorDesc,A.Assignee,REPLACE(G.Name,'AppCRM','') AssigneeDesc,
A.NoteCrm,A.NoteOperatore,
A.Tributo,
A.Tags,
H.Id ObjectId,H.ObjectNumber,H.StatusId ObjectStatusId,I.Descrizione ObjectStatusDesc, 
L.Id ObjectAssigneeId, 
CASE WHEN L.Id IS NULL THEN 'Non Assegnato' ELSE L.FullName END AS ObjectAssigneeDesc,
CASE WHEN L.Id IS NULL THEN 'NA' ELSE CONCAT(UPPER(LEFT(L.FirstName,1)),UPPER(LEFT(L.LastName,1))) END AS ObjectAssigneeCode,
CAST(0 AS BIT) Disabled
FROM GaCrmTickets A
INNER JOIN GaCrmEventComuni B ON A.CrmEventComuneId=B.Id
INNER JOIN GaContactCenterProvenienze C ON A.ContactCenterProvenienzaId=C.Id
INNER JOIN GaContactCenterTipiRichieste D ON A.ContactCenterTipoRichiestaId=D.Id
INNER JOIN GaContactCenterStatiRichieste E ON A.ContactCenterStatoRichiestaId=E.Id
INNER JOIN IdentityServerAdmin.dbo.Users F ON A.Creator=F.Id
INNER JOIN IdentityServerAdmin.dbo.Roles G ON A.Assignee=G.Id
LEFT OUTER JOIN GaPreventiviObjects H ON H.CrmTicketId=A.Id
LEFT OUTER JOIN GaPreventiviObjectStatuses I ON H.StatusId=I.Id
LEFT OUTER JOIN IdentityServerAdmin.dbo.Users L ON H.AssigneeId=L.Id
WHERE G.Name='AppCrmCommerciale'
GO


