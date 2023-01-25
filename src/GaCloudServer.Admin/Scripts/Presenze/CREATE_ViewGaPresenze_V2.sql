CREATE VIEW [dbo].[ViewGaPresenzeRichiesteRisorse]
AS
SELECT A.Id,A.PersonaleDipendenteId, CONCAT(C.LastName,' ',C.FirstName) AS title,'green' as eventColor,b.GlobalSettoreId AS settoreId,
CAST(A.HhFerie as varchar) as F,CAST(A.HhPermessiCcnl AS varchar) as OCCNL,CAST(A.HhRecupero as VARCHAR) AS ORC,CAST(0 AS BIT) Disabled
FROM GaPresenzeDipendenti A
LEFT JOIN GaPersonaleDipendenti B ON A.PersonaleDipendenteId=B.Id
LEFT JOIN  IdentityServerAdmin.dbo.Users C ON C.Id=B.UserId
GO

CREATE VIEW [dbo].[ViewGaPresenzeRichiesteEventi]
AS
SELECT B.Id,CAST(B.Id as VARCHAR) resourceId,  CONCAT(E.Descrizione,' - ',CONCAT(D.LastName,D.FirstName))title,A.DataInizio start,A.DataFine [end],c.GlobalSettoreId settoreId,A.Id eventId,CAST(0 AS BIT) Disabled
FROM GaPresenzeRichieste A
INNER JOIN GaPresenzeDipendenti B ON A.PresenzeDipendenteId=B.Id
LEFT JOIN GaPersonaleDipendenti C ON B.PersonaleDipendenteId=C.Id
LEFT JOIN  IdentityServerAdmin.dbo.Users D ON D.Id=C.UserId
LEFT JOIN GaPresenzeTipiOre E ON A.PresenzeTipoOraId=E.Id
GO