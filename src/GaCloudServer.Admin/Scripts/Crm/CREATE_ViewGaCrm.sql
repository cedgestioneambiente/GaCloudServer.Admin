USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewGaCdrConferimenti]    Script Date: 17/04/2023 11:45:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP VIEW IF EXISTS [dbo].[ViewGaCrmTickets]
GO

CREATE VIEW [dbo].[ViewGaCrmTickets]
AS
    SELECT A.*,b.Duration
      FROM [20.82.75.6].[TARI].[dbo].[ViewGaCrmTickets] A

GO