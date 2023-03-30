
CREATE VIEW ViewGaProgettiJobs
AS

 select a.*,b.FullName as Resources from(
  SELECT [Id]
      ,case when [start] is null then null else DATEDIFF(ss,'1970',[Start]) end [Start]
      ,case when [end] is null then null else DATEDIFF(ss,'1970',[end]) end [end]
      ,[Links]
      ,[Type]
      ,Color
      ,[Group_id]
      ,[Title]
      ,[ProgettiWorkId]
      ,[Disabled]
      ,[Draggable]
      ,[Draggable] ItemDraggable
      ,CASE WHEN B.CONTA>0 THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END AS [Expandable]
      ,[Linkable]
      ,A.[ParentId]
      ,Progress
	  ,[Priority]
      ,[Info]
	  ,case when [Completed] is null then cast(0 as bit) else [completed] end as [Completed]
	  ,case when [Approved] is null then cast(0 as bit) else [Approved] end as [Approved]	  
  FROM [GaCloud].[dbo].[GaProgettiJobs] A
  LEFT OUTER JOIN (SELECT ParentId,COUNT(*) CONTA
FROM [GaCloud].[dbo].[GaProgettiJobs]
GROUP BY ParentId) B ON A.Id=B.ParentId) a
left outer join (SELECT Id,STRING_AGG(FULLNAME,',') FullName
from(
SELECT A.*,B.FullName FROM (SELECT ID,VALUE
FROM [GaCloud].[dbo].[GaProgettiJobs]
CROSS APPLY string_split(RESOURCES,',')) A
LEFT OUTER JOIN IdentityServerAdmin.DBO.USERS B ON A.VALUE=B.Id) a
group by id) b on a.id=b.Id
GO