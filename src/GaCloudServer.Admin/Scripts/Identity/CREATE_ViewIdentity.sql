CREATE VIEW [dbo].ViewUserIdentity
                AS
                SELECT   cast(0 as bigint) Id, Id UserId, UserName, FirstName, LastName, LastName + N' ' + FirstName AS FullName, Email,cast(0 as bit) [Disabled]
                FROM         IdentityServerAdmin.dbo.Users
GO