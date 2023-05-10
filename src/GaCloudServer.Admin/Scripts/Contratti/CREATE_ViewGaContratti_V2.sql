USE [GaCloud]
GO

DROP VIEW IF EXISTS [dbo].[ViewGaContrattiDocumenti]
DROP VIEW IF EXISTS [dbo].[ViewGaContrattiDocumentiScadenziario]
GO

/****** Object:  View [dbo].[ViewGaContrattiDocumenti]    Script Date: 27/04/2023 14:45:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[ViewGaContrattiDocumenti]
AS
SELECT A.Id,a.ContrattiSoggettoId, A.Numero, A.Descrizione,A.Faldone,A.DataScadenza,B.Tipologie Tipologia,A.ContrattiTipologia TipologiaId, C.Modalita,A.ContrattiModalita  ModalitaId,
R.Permission,R.PermissionFriendlyName,A.Permissions PermissionId,
CASE WHEN D.NumAllegati IS NULL THEN CAST(0 AS INT) ELSE D.NumAllegati END NumAllegati,
CASE WHEN DATEDIFF(day, GETDATE(), DataScadenza) 
                         < 0 THEN 'R' WHEN DATEDIFF(day, GETDATE(), DataScadenza) < SogliaAvviso THEN 'G' ELSE 'V' END AS Stato,a.Archiviato,A.Disabled
FROM GaContrattiDocumenti A
INNER JOIN
(SELECT A.Id,STRING_AGG(b.Descrizione,',') as Tipologie
FROM GaContrattiDocumenti A
INNER JOIN [dbo].[GaContrattiTipologie] B ON CHARINDEX(','+CAST (B.Id as varchar)+',',','+A.ContrattiTipologia+',')>0
GROUP BY A.Id) B ON A.Id=B.Id
INNER JOIN
(SELECT A.Id,STRING_AGG(c.Descrizione,',') as Modalita
FROM GaContrattiDocumenti A
INNER JOIN GaContrattiModalitas C ON CHARINDEX(','+CAST (c.Id as varchar)+',',','+A.ContrattiModalita+',')>0
GROUP BY A.Id) C ON A.Id=C.Id
INNER JOIN
(SELECT A.Id,STRING_AGG(B.[Name],',') as Permission,REPLACE(STRING_AGG(B.[Name],','),'AppContratti','') as PermissionFriendlyName
FROM GaContrattiDocumenti A
INNER JOIN IdentityServerAdmin.dbo.Roles B ON CHARINDEX(B.Id,A.Permissions,0)>0
GROUP BY A.Id) R ON A.Id=R.Id
LEFT OUTER JOIN (SELECT ContrattiDocumentoId,COUNT(*) NumAllegati FROM GaContrattiDocumentiAllegati Group By ContrattiDocumentoId) D ON A.Id=D.ContrattiDocumentoId
GO

CREATE VIEW [dbo].[ViewGaContrattiDocumentiScadenziario]
AS
SELECT A.Id, A.Numero,a.ContrattiSoggettoId,E.RagioneSociale, A.Descrizione,A.CodiceCig, A.Faldone,A.DataScadenza,B.Tipologie Tipologia,A.ContrattiTipologia TipologiaId, C.Modalita,A.ContrattiModalita  ModalitaId,
R.Permission,R.PermissionFriendlyName,A.Permissions PermissionId,
E.Fornitore,E.Cliente,
CASE WHEN D.NumAllegati IS NULL THEN CAST(0 AS INT) ELSE D.NumAllegati END NumAllegati,
CASE WHEN DATEDIFF(day, GETDATE(), DataScadenza) 
                         < 0 THEN 'R' WHEN DATEDIFF(day, GETDATE(), DataScadenza) < SogliaAvviso THEN 'G' ELSE 'V' END AS Stato,a.Archiviato,E.Disabled SoggettoDisabled,A.Disabled
FROM GaContrattiDocumenti A
INNER JOIN
(SELECT A.Id,STRING_AGG(b.Descrizione,',') as Tipologie
FROM GaContrattiDocumenti A
INNER JOIN [dbo].[GaContrattiTipologie] B ON CHARINDEX(','+CAST (B.Id as varchar)+',',','+A.ContrattiTipologia+',')>0
GROUP BY A.Id) B ON A.Id=B.Id
INNER JOIN
(SELECT A.Id,STRING_AGG(c.Descrizione,',') as Modalita
FROM GaContrattiDocumenti A
INNER JOIN GaContrattiModalitas C ON CHARINDEX(','+CAST (c.Id as varchar)+',',','+A.ContrattiModalita+',')>0
GROUP BY A.Id) C ON A.Id=C.Id
INNER JOIN
(SELECT A.Id,STRING_AGG(B.[Name],',') as Permission,STRING_AGG(SUBSTRING(B.[Name],13,LEN(B.[Name])-12),',') as PermissionFriendlyName
FROM GaContrattiDocumenti A
INNER JOIN IdentityServerAdmin.dbo.Roles B ON CHARINDEX(B.Id,A.Permissions,0)>0
GROUP BY A.Id) R ON A.Id=R.Id
LEFT OUTER JOIN (SELECT ContrattiDocumentoId,COUNT(*) NumAllegati FROM GaContrattiDocumentiAllegati Group By ContrattiDocumentoId) D ON A.Id=D.ContrattiDocumentoId
INNER JOIN GaContrattiSoggetti E ON E.Id=A.ContrattiSoggettoId
GO
