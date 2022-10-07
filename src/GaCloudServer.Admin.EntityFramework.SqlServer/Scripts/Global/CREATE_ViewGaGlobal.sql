CREATE VIEW [dbo].[PrivateViewAuthServerUserList]
                AS
                SELECT   Id, UserName, FirstName, LastName, LastName + N' ' + FirstName AS FullName, Email
                FROM         AuthServerSSO.dbo.Users
GO