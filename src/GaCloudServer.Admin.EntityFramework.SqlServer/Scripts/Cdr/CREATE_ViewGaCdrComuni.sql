CREATE VIEW [dbo].[ViewGaCdrComuni]
                AS
                SELECT        Id, Comune AS Descrizione, Disabled
                FROM            dbo.GaCdrComuni
GO