CREATE VIEW [dbo].[ViewShortcutItems]
AS
SELECT A.Id,Label,Description,Icon,B.Link ShortcutLink,UseRouter,UserId,A.Disabled
FROM ShortcutItems A
LEFT JOIN ShortcutLinks B ON A.ShortcutLinkId= B.Id
GO