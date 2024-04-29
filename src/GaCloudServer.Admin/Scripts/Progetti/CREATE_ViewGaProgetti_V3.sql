
ALTER VIEW ViewGaProgettiJobs
AS
  SELECT A.*,
 CONCAT('[',ISNULL(A.WorkedDays2,'0'),'/',ISNULL(A.TotalDays,'0'),']') ProgressDays,
 ISNULL(CASE WHEN (A.WorkedDays=0 OR A.TotalDays=0)  THEN CEILING(0*10)/10
 ELSE CEILING(((A.WorkedDays/A.TotalDays)*100)*10)/10 END,0) ProgressByDays
 ,B.FullName AS Resources FROM
(SELECT Id
,ParentId
,CASE WHEN [start] IS NULL THEN NULL ELSE DATEDIFF(ss,'1970',[Start]) END [Start]
,CASE WHEN [end] IS NULL THEN NULL ELSE DATEDIFF(ss,'1970',[end]) END [end]
,[Links]
,[Type]
,Color
,[Group_id]
,[Title]
,[ProgettiWorkId]
,[Disabled]
,[Draggable]
,[Draggable] ItemDraggable
,(SELECT CASE WHEN COUNT(*)>0 THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END CONTA FROM GaProgettiJobs WHERE ParentId=T.Id) Expandable
,[Linkable]
,CASE 
    WHEN parentId <> 0 THEN workedDays
    ELSE (SELECT SUM(WorkedDays) FROM GaProgettiJobs WHERE parentId = T.id and CountDays=1)
END AS WorkedDays,
CASE 
    WHEN parentId <> 0 THEN workedDays
    ELSE (SELECT SUM(TotalDays) FROM GaProgettiJobs WHERE parentId = T.id and CountDays=1)
END AS WorkedDays2,
CASE 
    WHEN parentId <> 0 THEN TotalDays
    ELSE MaxDays
END AS TotalDays
,Progress
,[Priority]
,[Info]
,CASE WHEN [Completed] IS NULL THEN CAST(0 as bit) ELSE [completed] END AS [Completed]
,CASE WHEN [Approved] IS NULL THEN cast(0 as bit) ELSE [Approved] END AS [Approved]	  
FROM GaProgettiJobs T) A
LEFT OUTER JOIN (SELECT Id,STRING_AGG(FULLNAME,',') FullName
from(
SELECT A.*,B.FullName FROM (SELECT ID,VALUE
FROM [GaCloud].[dbo].[GaProgettiJobs]
CROSS APPLY STRING_SPLIT(RESOURCES,',')) A
LEFT OUTER JOIN IdentityServerAdmin.DBO.USERS B ON A.VALUE=B.Id) A
GROUP BY id) b ON A.Id=B.Id
GO