CREATE VIEW [dbo].[ViewGaContrattiUtenti]
                AS
                SELECT        AuthServerSSO.dbo.Users.Id, AuthServerSSO.dbo.Users.UserName
                FROM            AuthServerSSO.dbo.Users INNER JOIN
                                         AuthServerSSO.dbo.UserRoles ON AuthServerSSO.dbo.Users.Id = AuthServerSSO.dbo.UserRoles.UserId INNER JOIN
                                         AuthServerSSO.dbo.Roles ON AuthServerSSO.dbo.UserRoles.RoleId = AuthServerSSO.dbo.Roles.Id
                WHERE        (AuthServerSSO.dbo.Roles.Name = N'GaContrattiRO' OR
                                         AuthServerSSO.dbo.Roles.Name = N'GaContrattiRW')
GO