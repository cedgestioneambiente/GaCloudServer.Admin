CREATE VIEW [dbo].[ViewGaPersonaleUsersOnDipendenti]
AS
SELECT CAST('0' AS BIGINT) Id, A.Id UserId,FirstName Nome,LastName Cognome, CONCAT(LastName,' ',FirstName) CognomeNome,Email,UserName, CASE WHEN(B.Id IS NULL) THEN CASt(0 as bigint) else B.Id END DipendenteId, CASE WHEN(B.Id IS NOT NULL) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END Active,CAST(0 as BIT) Disabled
FROM IdentityServerAdmin.dbo.Users A
LEFT JOIN GaPersonaleDipendenti B ON A.Id=B.UserId
GO

CREATE VIEW [dbo].[ViewGaPersonaleDipendenti]
AS
SELECT A.Id, B.Id UserId,FirstName Nome,LastName Cognome,C.Descrizione Sede,C.Id SedeId,D.Descrizione Qualifica,D.Id QualificaId, A.Disabled
FROM GaPersonaleDipendenti A 
LEFT JOIN IdentityServerAdmin.dbo.Users B ON A.UserId=B.Id
LEFT JOIN GlobalSedi C ON C.Id= A.GlobalSedeId
LEFT JOIN GaPersonaleQualifiche D ON D.Id=A.PersonaleQualificaId
GO
