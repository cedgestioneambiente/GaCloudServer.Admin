USE [GaCloud]
GO

/****** Object:  View [dbo].[ViewGaCdrConferimenti]    Script Date: 17/04/2023 11:45:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP VIEW IF EXISTS [dbo].[ViewGaCsrCodiciCers]
GO
DROP VIEW IF EXISTS [dbo].[ViewGaCsrDestinatari]
GO
DROP VIEW IF EXISTS [dbo].[ViewGaCsrTrasportatori]
GO

CREATE VIEW [dbo].[ViewGaCsrCodiciCers]
                    AS
                    SELECT [Id]
                          ,CONCAT([Codice],' - ',[Descrizione],' - ',[Modalita]) as Descrizione
                          ,[Disabled]
                      FROM dbo.GaCsrCodiciCers
GO

CREATE VIEW [dbo].[ViewGaCsrDestinatari]
                    AS
                    SELECT  [Id],
                          CONCAT([RagioneSociale],' - ',[Indirizzo]) as Descrizione
                          ,[Disabled]
                      FROM dbo.GaCsrDestinatari
GO

CREATE VIEW[dbo].[ViewGaCsrTrasportatori]
                    AS
                    SELECT[Id],
                          CONCAT([RagioneSociale],' - ',[Indirizzo]) as Descrizione
                          ,[Disabled]
                    FROM dbo.GaCsrTrasportatori
GO