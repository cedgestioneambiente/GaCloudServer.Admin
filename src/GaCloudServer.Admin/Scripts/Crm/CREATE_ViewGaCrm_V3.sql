USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewGaCdrConferimenti]    Script Date: 17/04/2023 11:45:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW ViewGaCrmEventJobs
AS
SELECT CAST(0 AS BIGINT) Id,
CONVERT(DATE,A.DateSchedule) DateSchedule,B.Id AreaId, B.Descrizione Area, 
Count(case a.CrmEventStateId when 1 then 1 else null end) AS ToDoCount,
Count(case a.CrmEventStateId when 2 then 1 else null end) AS CompletedCount,
Count(case a.CrmEventStateId when 4 then 1 else null end) AS CancelledCount,
CAST (0 as BIT) Disabled
FROM GaCrmEvents A
INNER JOIN GaCrmEventAreas B ON A.CrmEventAreaId=B.Id
GROUP BY CONVERT(DATE,A.DateSchedule),B.Id,B.Descrizione
GO