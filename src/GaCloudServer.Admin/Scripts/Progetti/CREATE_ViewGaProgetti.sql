
CREATE VIEW ViewGaProgettiJobs
AS

  select [Id]
      ,[Resources]
      ,DATEDIFF(ss,'1970',[Start]) [Start]
      ,DATEDIFF(ss,'1970',[End]) [End]
      ,[Links]
      ,[Type]
      ,[Color]
      ,[Group_id]
      ,[Title]
      ,[ProgettiWorkId]
      ,[Disabled]
      ,[Draggable]
      ,[Expandable]
      ,[Linkable]
      ,[ParentId]
      ,[Progress]
  FROM [GaCloud].[dbo].[GaProgettiJobs]