CREATE VIEW [dbo].[ViewGaRecapitiContatti]
AS
SELECT        CAST(0 AS BIGINT) AS Id, FirstName AS Nome, LastName AS Cognome, PhoneNumber AS Cellulare, OfficePhoneNumber AS Interno, CAST('false' AS bit) AS Disabled
FROM            IdentityServerAdmin.dbo.Users
WHERE        (FirstName IS NOT NULL)
GO