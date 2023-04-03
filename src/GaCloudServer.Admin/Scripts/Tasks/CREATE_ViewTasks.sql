CREATE VIEW [dbo].[ViewTasks]
AS
SELECT A.*,B.SharedName
FROM(
SELECT        dbo.TasksItems.id AS Id,dbo.TasksItems.UserId, dbo.TasksItems.Shared, dbo.TasksItems.Title, dbo.TasksItems.Notes, dbo.TasksItems.Completed, dbo.TasksItems.DueDate, dbo.TasksItems.Priority, dbo.TasksItems.Type, dbo.TasksItems.Tags, 
                         dbo.TasksItems.[Order],dbo.TasksItems.Warning, dbo.PrivateViewIdentityServerAdminUserList.FullName AS Owner, CASE WHEN Completed = 1 THEN 'V' ELSE 'R' END AS CompletionStatus, CASE WHEN Completed !=1 AND DATEDIFF(day, GETDATE(), DueDate) 
                         < 0 THEN 'R' WHEN DATEDIFF(day, GETDATE(), DueDate) < Warning AND Completed = 0 THEN 'G' ELSE 'V' END AS DeadlineStatus, dbo.TasksItems.Disabled

FROM            dbo.PrivateViewIdentityServerAdminUserList INNER JOIN
                         dbo.TasksItems ON dbo.PrivateViewIdentityServerAdminUserList.Id = dbo.TasksItems.UserId) A
left outer join (SELECT Id,STRING_AGG(FULLNAME,',') SharedName
from(
SELECT A.*,B.FullName FROM (SELECT ID,VALUE
FROM [GaCloud].[dbo].TasksItems
CROSS APPLY string_split(Shared,',')) A
LEFT OUTER JOIN IdentityServerAdmin.DBO.USERS B ON A.VALUE=B.Id) a
group by id) b on a.id=b.Id
GO