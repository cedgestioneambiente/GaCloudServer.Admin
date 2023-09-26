USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewConsorzioImportsTasks]    Script Date: 04/07/2023 09:54:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP VIEW IF EXISTS [dbo].[ViewConsorzioImportsTasks]
GO

CREATE VIEW [dbo].[ViewConsorzioImportsTasks]
AS
SELECT        dbo.ConsorzioImportsTasks.Id, dbo.ConsorzioImportsTasks.TaskId, dbo.ConsorzioImportsTasks.DateStart, dbo.ConsorzioImportsTasks.DateEnd, dbo.ConsorzioImportsTasks.Completed, dbo.ConsorzioImportsTasks.Error, (Error + Completed) AS Totale,
                         dbo.ConsorzioImportsTasks.FileId, dbo.PrivateViewIdentityServerAdminUserList.FullName, CASE WHEN DateEnd <= DateStart THEN 'ND' ELSE CONCAT(DATEDIFF(minute, dbo.ConsorzioImportsTasks.DateStart,dbo.ConsorzioImportsTasks.DateEnd),' minuti') END AS DurataMinuti,
						 CASE WHEN Error <= 0 THEN 'V' ELSE 'R' END AS Successo, dbo.ConsorzioImportsTasks.Disabled,
						 CASE WHEN DateEnd <= DateStart THEN 'ND' ELSE CONCAT(DATEDIFF(second, dbo.ConsorzioImportsTasks.DateStart,dbo.ConsorzioImportsTasks.DateEnd),' secondi') END AS DurataSecondi,dbo.ConsorzioImportsTasks.Deleted
FROM            dbo.ConsorzioImportsTasks INNER JOIN
                         dbo.PrivateViewIdentityServerAdminUserList ON dbo.ConsorzioImportsTasks.UserId = dbo.PrivateViewIdentityServerAdminUserList.Id
GO