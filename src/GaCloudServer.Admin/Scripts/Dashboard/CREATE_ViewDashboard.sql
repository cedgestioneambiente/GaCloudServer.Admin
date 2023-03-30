CREATE VIEW ViewDashboardUserRoles
AS
SELECT A.*,
C.RolesId,C.RoleNames
FROM(
SELECT 
A.Id,A.FirstName,A.LastName,A.FullName,
B.*
FROM [IdentityServerAdmin].dbo.Users A,
(SELECT B.* FROM(
SELECT A.Id DashId,A.Title,A.Descrizione DashDescrizione,A.DashboardSectionId DashSectionId,B.Descrizione DashSection,A.DashboardTypeId DashTypeId,C.[Type] DashType,A.Script DashScript,A.Roles DashRoles,A.Disabled DashDisabled
FROM DashBoardItems A
INNER JOIN DashboardSections B ON A.DashboardSectionId=B.Id
INNER JOIN DashboardTypes C ON A.DashboardTypeId=C.Id) B) B)A
LEFT JOIN (SELECT UserId,STRING_AGG(RoleId,',') RolesId,STRING_AGG(Name,',') RoleNames
FROM(
SELECT A.*,B.Name
  FROM [IdentityServerAdmin].[dbo].[UserRoles] A
  INNER JOIN IdentityServerAdmin.dbo.Roles B ON a.RoleId=b.Id) A
  GROUP BY UserId) C ON A.Id=C.UserId
GO

CREATE VIEW ViewDashboardStores
AS
SELECT CASE WHEN B.Id IS NULL THEN CAST(0 as bigint) ELSE B.Id END  Id,A.DashId,A.UserId,A.DashRoles,C.Title DashTitle,C.Descrizione DashDesc, 
C.DashboardTypeId DashTypeId,D.[Type] DashType,D.Descrizione DashTypeDesc ,
C.DashboardSectionId DashSectionId,E.Descrizione DashSection,
CASE when B.[Order] IS NULL THEN 0 ELSE B.[Order] END [Order],
CASE WHEN B.Id IS NULL THEN CAST(0 as BIT) ELSE CAST(1 as BIT) END [Enabled],
CAST(0 AS BIT) [Disabled]
FROM(
SELECT Id UserId,DashId,FullName, DashRoles,RoleNames,COUNT(*) AS RolesCount
FROM (
SELECT Id,FullName,DashId,DashRoles,RoleNames, value as Word
FROM ViewDashboardUserRoles
CROSS APPLY STRING_SPLIT(DashRoles,',')
) A
WHERE CHARINDEX(A.Word,RoleNames)>0
GROUP BY Id,DashId,FullName, DashRoles,RoleNames) A
LEFT OUTER JOIN DashboardStores B ON A.DashId=B.DashboardItemId AND A.UserId=b.UserId
INNER JOIN DashboardItems C ON A.DashId=C.Id
LEFT JOIN DashboardTypes D ON C.DashboardTypeId=D.Id
LEFT JOIN DashboardSections E ON C.DashboardSectionId=E.Id
GO
