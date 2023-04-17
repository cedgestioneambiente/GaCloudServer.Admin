USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewGaCdrConferimenti]    Script Date: 17/04/2023 11:45:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP VIEW IF EXISTS [dbo].[ViewGaCdrConferimenti]
GO

CREATE VIEW [dbo].[ViewGaCdrConferimenti]
AS
SELECT A.Id, A.[Data],
D.Centro,
B.Cer,B.Imm,
C.Descrizione CerDettaglio,
A.Ditta,A.Peso,A.Quantita,
CONCAT(USERS.LastName,' ',USERS.FirstName) UtenteRegistrazione,
A.Targa,A.Note,A.CdrUtenteId,
TCOMUNI.Descrizione Comune,
TUTENZE.RagSo RagioneSociale,A.NumCon,A.Partita, TUTENZE.CodFis CfPiva,
A.Disabled
FROM GaCdrConferimenti A
INNER JOIN GaCdrCers B ON A.CdrCerId = B.Id
INNER JOIN GaCdrCersDettagli C ON A.CdrCerDettaglioId = C.Id 
INNER JOIN GaCdrCentri D ON A.CdrCentroId=D.Id
INNER JOIN [IdentityServerAdmin].dbo.Users USERS ON USERS.Id=A.UserId
LEFT OUTER JOIN dbo.ViewGaBackOfficeComuni TCOMUNI ON A.CdrComuneId COLLATE Latin1_General_CI_AS=TCOMUNI.CodAzi COLLATE Latin1_General_CI_AS
LEFT OUTER JOIN dbo.[ViewGaBackOfficeUtenze] TUTENZE ON A.NumCon COLLATE Latin1_General_CI_AS= TUTENZE.NumCon COLLATE Latin1_General_CI_AS
AND A.CdrComuneId COLLATE Latin1_General_CI_AS= TUTENZE.CpAzi COLLATE Latin1_General_CI_AS
GO


