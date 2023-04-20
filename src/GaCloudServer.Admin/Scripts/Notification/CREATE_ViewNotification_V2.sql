
DROP VIEW IF EXISTS [dbo].[ViewNotificationEvents]
GO

CREATE VIEW [dbo].[ViewNotificationEvents]
AS
SELECT        dbo.NotificationEvents.Id, dbo.NotificationEvents.DateEvent, dbo.NotificationEvents.UserId, dbo.NotificationApps.Descrizione AS AppDescription, dbo.NotificationApps.Info AS AppInfo, dbo.NotificationApps.Icon AS AppIcon, 
                         dbo.NotificationEvents.Title, dbo.NotificationEvents.Message, dbo.NotificationEvents.[Read],dbo.NotificationEvents.[Link],dbo.NotificationEvents.[Routing], CAST(0 AS BIT) Disabled
FROM            dbo.NotificationEvents INNER JOIN
                         dbo.NotificationApps ON dbo.NotificationEvents.NotificationAppId = dbo.NotificationApps.Id
GO
