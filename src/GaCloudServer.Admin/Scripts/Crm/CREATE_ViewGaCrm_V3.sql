USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewGaCdrConferimenti]    Script Date: 17/04/2023 11:45:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW ViewCrmEventJobs
AS
SELECT CAST(0 AS BIGINT) Id,
CONVERT(DATE,A.DateSchedule) DateSchedule,B.Descrizione, Count(*) AS TotalCount,CAST (0 as BIT) Disabled

FROM GaCrmEvents A
INNER JOIN GaCrmEventAreas B ON A.CrmEventAreaId=B.Id
GROUP BY CONVERT(DATE,A.DateSchedule),B.Descrizione
GO