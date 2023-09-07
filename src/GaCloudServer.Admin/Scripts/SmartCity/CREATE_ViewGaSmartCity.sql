Use GaCloud
GO
CREATE VIEW ViewGaSmartCityPermissions 
AS
SELECT
    CAST(0 as BIGINT) Id,
	i.Id UserId,
    i.UserName,
	i.Email,
    i.Roles,
    p.Permissions,
    CAST(0 AS BIT) [Disabled] 
FROM
(
    SELECT
		u.Id,
        u.UserName,
		u.Email,
        STRING_AGG(r.Name, ', ') AS Roles
    FROM
        IdentityServerAdmin.dbo.Users AS u
    JOIN
        IdentityServerAdmin.dbo.UserRoles AS ur ON u.Id = ur.UserId
    JOIN
        IdentityServerAdmin.dbo.Roles AS r ON ur.RoleId = r.Id
    WHERE
        r.Name IN ('GaSmartCityRW', 'GaSmartCityRO', 'GaSmartCityADMIN')
    GROUP BY
        u.Id,u.UserName,u.Email
) AS i
LEFT JOIN
    GaSmartCityPermissions AS p ON i.Id = p.UserId;
GO