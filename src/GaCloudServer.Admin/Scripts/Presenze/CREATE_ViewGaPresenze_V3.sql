USE [GaCloud]
GO

/****** Object:  View [dbo].[WidgetGaPresenzeSchedule]    Script Date: 26/04/2023 12:20:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[WidgetGaPresenzeSchedule]
AS
SELECT CAST(0 AS bigint) Id,Cast(0 as Bit) Disabled,Personale,MIN(Datainizio) DataInizio,MAX(DataFine) DataFine, cast(MAX(Oggi) as bit) AS Oggi, cast(MAX(Domani) as bit) AS Domani, Settore, PresenzeTipoOraId AS TipoOreId,TipoOre
FROM(
SELECT A.Id,D.FullName Personale,a.DataInizio,A.DataFine, E.Descrizione Settore,A.PresenzeStatoRichiestaId,A.PresenzeTipoOraId,F.Descrizione TipoOre,
CASE WHEN CAST(getdate() AS DATE) >= CAST(A.DataInizio AS DATE) AND CAST(getdate() AS DATE) <= CAST(A.DataFine AS DATE) THEN '1' ELSE '0' END AS Oggi,
CASE WHEN dateadd(dd, 1, CAST(getdate() AS DATE)) >= CAST(DataInizio AS DATE) AND dateadd(dd, 
                         1, CAST(getdate() AS DATE)) <= CAST(DataFine AS DATE) THEN '1' ELSE '0' END AS Domani
FROM GaPresenzeRichieste A
INNER JOIN GaPresenzeDipendenti B ON A.PresenzeDipendenteId=B.Id
INNER JOIN GaPersonaleDipendenti C ON B.PersonaleDipendenteId=C.Id
INNER JOIN IdentityServerAdmin.dbo.Users D ON C.UserId=D.Id
INNER JOIN GlobalSettori E ON E.Id=C.GlobalSettoreId
INNER JOIN GaPresenzeTipiOre F ON F.Id=A.PresenzeTipoOraId
WHERE C.PersonaleQualificaId='3') A
WHERE Oggi=1 OR Domani=1
GROUP BY Personale, Settore, PresenzeTipoOraId,TipoOre
GO