CREATE VIEW [dbo].[ViewShortcutItems]
AS
SELECT Id,Label,Description,Icon,B.Link ShortcutLink,UserRouter,UserId,Disabled
FROM ShortcutItems A
LEFT JOIN ShortcutLinks B ON A.ShortcutLinkId= B.Id
GO