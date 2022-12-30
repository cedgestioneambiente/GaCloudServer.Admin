CREATE VIEW [dbo].[PrivateViewIdentityServerAdminUserList]
                AS
                SELECT   Id, UserName, FirstName, LastName, LastName + N' ' + FirstName AS FullName, Email
                FROM         IdentityServerAdmin.dbo.Users
GO