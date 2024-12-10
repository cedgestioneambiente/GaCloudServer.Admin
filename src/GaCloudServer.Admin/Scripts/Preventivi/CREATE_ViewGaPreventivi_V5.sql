USE [GaCloud]
GO

/****** Object:  View [dbo].[[ViewGaPreventiviTickets]]    Script Date: 28/05/2024 10:13:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[ViewGaPreventiviCrmTickets]
AS
SELECT 
A.Id
,A.DataTicket
,A.DataRichiesta
,B.CodAzi ComuneCod
,CASE WHEN B.CodAzi='C00' THEN A.ComuneAlt ELSE B.Descrizione END ClienteComune
,A.CodCli CodCliente
,A.Utente Cliente
,CONCAT(A.Via,', ',A.NumCiv) ClienteIndirizzo
,A.CfPiva ClienteCfPiva
,A.CodSdi ClienteCodSdi
,A.Intestatario
,A.IntestatarioComune
,A.IntestatarioIndirizzo
,A.IntestatarioIndirizzoOperativo
,A.IntestatarioCfPiva
,A.Telefono,A.Cellulare,A.Email,A.EmailPec
,A.NoteCrm,A.NoteOperatore
,H.Id ObjectId,H.ObjectNumber,H.StatusId ObjectStatusId,I.Descrizione ObjectStatusDesc, 
L.Id ObjectAssigneeId, 
CASE WHEN L.Id IS NULL THEN 'Non Assegnato' ELSE L.FullName END AS ObjectAssigneeDesc,
CASE WHEN L.Id IS NULL THEN 'NA' ELSE CONCAT(UPPER(LEFT(L.FirstName,1)),UPPER(LEFT(L.LastName,1))) END AS ObjectAssigneeCode
,D.Descrizione TipoDesc
,D.Important
,M.FullName CreatorDesc
,CAST(0 AS BIT) Disabled
FROM GaCrmTickets A
INNER JOIN GaCrmEventComuni B ON A.CrmEventComuneId=B.Id
INNER JOIN GaContactCenterTipiRichieste D ON A.ContactCenterTipoRichiestaId=D.Id
INNER JOIN IdentityServerAdmin.dbo.Roles G ON A.Assignee=G.Id
LEFT OUTER JOIN GaPreventiviObjects H ON H.CrmTicketId=A.Id
LEFT OUTER JOIN GaPreventiviObjectStatuses I ON H.StatusId=I.Id
LEFT OUTER JOIN IdentityServerAdmin.dbo.Users L ON H.AssigneeId=L.Id
LEFT OUTER JOIN IdentityServerAdmin.dbo.Users M ON A.Creator=M.Id
WHERE G.Name='AppCrmCommerciale'
GO


