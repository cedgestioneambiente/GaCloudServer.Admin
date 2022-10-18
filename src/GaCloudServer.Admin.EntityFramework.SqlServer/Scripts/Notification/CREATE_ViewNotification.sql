CREATE VIEW [dbo].[ViewNotificationRolesOnApps]
AS
SELECT A.*,CASE WHEN B.Id IS NULL THEN  CAST(0 AS bit) ELSE CAST(1 AS BIT) END Enabled
FROM
(SELECT A.Id,A.Descrizione,A.Info,A.Disabled,B.Id RoleId,B.Name
FROM NotificationApps A,IdentityServerAdmin.dbo.Roles B) A
LEFT JOIN NotificationRolesOnApps B ON B.RoleId=A.RoleId AND A.Id=B.NotificationAppId
GO

CREATE VIEW [dbo].[ViewNotificationUsersOnApps]
AS
SELECT CAST(0 AS bigint) Id,A.UserId,FullName,AppId,AppName,
CASE WHEN (result IS NOT NULL AND Result<>'') THEN CAST(1 as bit) ELSE CAST(0 AS bit) END Show,
CASE WHEN (B.Id IS NOT NULL) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END Enabled ,CAST(0 as BIT) Disabled
FROM(
SELECT A.UserId,A.FullName,A.AppId,A.AppName,A.UserRoles,B.AppRoles,
REPLACE(TRY_CAST('<root>'+
    '<source><r><![CDATA[' + REPLACE(A.UserRoles, ', ', ']]></r><r><![CDATA[') + 
        ']]></r></source>' + 
    '<target><r><![CDATA[' + REPLACE(B.AppRoles, ', ', ']]></r><r><![CDATA[') + 
        ']]></r></target>' + 
    '</root>' AS XML)
    .query('
    for $x in /root/source/r/text(),
        $y in /root/target/r/text()
    where lower-case($y) eq lower-case($x)
    return data($x)
    ').value('.', 'NVARCHAR(MAX)'), SPACE(1), ',')  AS result
FROM(
SELECT UserId,FullName,AppId,AppName,STRING_AGG(RoleId,', ') UserRoles
FROM(
SELECT  A.Id UserId,A.FullName,B.Id AppId, B.Descrizione AppName,c.RoleId,C.UserId UtenteID,D.Name
FROM IdentityServerAdmin.dbo.Users A
INNER JOIN IdentityServerAdmin.dbo.UserRoles C ON C.UserId=A.Id
LEFT JOIN IdentityServerAdmin.dbo.Roles D ON D.Id=C.RoleId,
NotificationApps B) A
GROUP BY UserId,FullName,AppId,AppName) A
LEFT JOIN (SELECT NotificationAppId,STRING_AGG(RoleId,', ') AppRoles FROM NotificationRolesOnApps GROUP BY NotificationAppId) B ON A.AppId=B.NotificationAppId) A
LEFT JOIN NotificationUsersOnApps B ON A.UserId=B.UserId AND A.AppId=B.NotificationAppId
GO
