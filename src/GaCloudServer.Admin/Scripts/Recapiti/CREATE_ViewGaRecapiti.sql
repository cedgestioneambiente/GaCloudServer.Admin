CREATE VIEW [dbo].[ViewGaRecapitiContatti]
AS
SELECT        CAST(0 AS BIGINT) AS Id, FirstName AS Nome, LastName AS Cognome, PhoneNumber AS Cellulare, OfficePhoneNumber AS Interno, CAST('false' AS bit) AS Disabled, ShowEmailInContacts, ShowInContacts, Email,Id as UserId
FROM            IdentityServerAdmin.dbo.Users
GO