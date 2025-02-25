USE [GaCloud]
GO
/****** Object:  UserDefinedFunction [dbo].[CsrCalcPercMonth]    Script Date: 21/02/2025 11:27:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
DROP FUNCTION IF EXISTS [dbo].[CsrCalcPercMonth]
GO
DROP FUNCTION IF EXISTS [dbo].[CsrCalcTotKgMonth]
GO
DROP FUNCTION IF EXISTS [dbo].[CsrCalcTotKgMonthDiff]
GO
DROP FUNCTION IF EXISTS [dbo].[CsrCalcTotKgMonthInDiff]
GO
DROP FUNCTION IF EXISTS [dbo].[CsrCalcTotKgMonthProCap]
GO
DROP FUNCTION IF EXISTS [dbo].[CsrCalcTotKgMonthProCapDiff]
GO
DROP FUNCTION IF EXISTS [dbo].[CsrCalcTotKgMonthProCapInDiff]
GO

USE [GaCloud]
GO
/****** Object:  UserDefinedFunction [dbo].[CsrCalcPercMonth]    Script Date: 25/02/2025 11:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[CsrCalcPercMonth]
(
    @Month INT,
    @Year INT,
	@Produttore nvarchar(255)
)
RETURNS FLOAT
AS
BEGIN
    DECLARE @PERCENTUALE_DIFF_MESE FLOAT;

    SELECT @PERCENTUALE_DIFF_MESE = 
        CASE 
            WHEN (SUM(CASE 
                        WHEN dbo.ConsorzioSmaltimenti.Id IN (1, 2) 
                             AND MONTH(dbo.ConsorzioRegistrazioni.DataRegistrazione) = @Month 
                             AND dbo.ConsorzioRegistrazioni.ConsorzioPeriodoId <> 3 
                            THEN dbo.ConsorzioRegistrazioni.PesoTotale 
                        WHEN dbo.ConsorzioRegistrazioni.ConsorzioPeriodoId = 3 
                             AND YEAR(dbo.ConsorzioRegistrazioni.DataRegistrazione) = @Year 
                             AND dbo.ConsorzioSmaltimenti.Id IN (1,2) 
                            THEN dbo.ConsorzioRegistrazioni.PesoTotale / 12
                        ELSE 0 
                    END)) = 0 
            THEN NULL
            ELSE
                ROUND(
                    (SUM(CASE 
                            WHEN dbo.ConsorzioSmaltimenti.Id = 1 
                                 AND MONTH(dbo.ConsorzioRegistrazioni.DataRegistrazione) = @Month 
                                 AND dbo.ConsorzioRegistrazioni.ConsorzioPeriodoId <> 3 
                                THEN dbo.ConsorzioRegistrazioni.PesoTotale 
                            WHEN dbo.ConsorzioRegistrazioni.ConsorzioPeriodoId = 3 
                                 AND YEAR(dbo.ConsorzioRegistrazioni.DataRegistrazione) = @Year 
                                 AND dbo.ConsorzioSmaltimenti.Id = 1 
                                THEN dbo.ConsorzioRegistrazioni.PesoTotale / 12
                            ELSE 0 
                        END) * 100.0 /
                    SUM(CASE 
                            WHEN dbo.ConsorzioSmaltimenti.Id IN (1, 2) 
                                 AND MONTH(dbo.ConsorzioRegistrazioni.DataRegistrazione) = @Month 
                                 AND dbo.ConsorzioRegistrazioni.ConsorzioPeriodoId <> 3 
                                THEN dbo.ConsorzioRegistrazioni.PesoTotale 
                            WHEN dbo.ConsorzioRegistrazioni.ConsorzioPeriodoId = 3 
                                 AND YEAR(dbo.ConsorzioRegistrazioni.DataRegistrazione) = @Year 
                                 AND dbo.ConsorzioSmaltimenti.Id IN (1,2) 
                                THEN dbo.ConsorzioRegistrazioni.PesoTotale / 12
                            ELSE 0 
                        END)),
                    2
                )
        END
    FROM dbo.ConsorzioRegistrazioni
    INNER JOIN dbo.ConsorzioOperazioni
        ON dbo.ConsorzioRegistrazioni.ConsorzioOperazioneId = dbo.ConsorzioOperazioni.Id
    INNER JOIN dbo.ConsorzioSmaltimenti
        ON dbo.ConsorzioOperazioni.ConsorzioSmaltimentoId = dbo.ConsorzioSmaltimenti.Id inner join ConsorzioProduttori on ConsorzioRegistrazioni.ConsorzioProduttoreId=ConsorzioProduttori.Id
    WHERE YEAR(dbo.ConsorzioRegistrazioni.DataRegistrazione) = @Year and ConsorzioProduttori.Descrizione=@Produttore

    RETURN @PERCENTUALE_DIFF_MESE;
END;
GO
/****** Object:  UserDefinedFunction [dbo].[CsrCalcTotKgMonth]    Script Date: 25/02/2025 11:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[CsrCalcTotKgMonth]
(
	@Month int,
	@Year int,
	@Produttore nvarchar(255)

)
RETURNS Float
AS
BEGIN
	DECLARE @TOTALE_KG_RIFIUTI_MESE FLOAT;

	SELECT @TOTALE_KG_RIFIUTI_MESE=  ROUND(
        SUM(CASE
            WHEN MONTH(DataRegistrazione) = @Month AND ConsorzioPeriodoId <> 3
                THEN PesoTotale
            WHEN ConsorzioPeriodoId = 3 AND YEAR(DataRegistrazione) = @Year
                THEN PesoTotale / 12
            ELSE 0
        END),
        2
    )
	FROM ConsorzioRegistrazioni
	inner join ConsorzioProduttori on ConsorzioRegistrazioni.ConsorzioProduttoreId=ConsorzioProduttori.Id
	WHERE YEAR(DataRegistrazione)=@Year and ConsorzioProduttori.Descrizione=@Produttore


	-- Return the result of the function
	RETURN @TOTALE_KG_RIFIUTI_MESE

END
GO
/****** Object:  UserDefinedFunction [dbo].[CsrCalcTotKgMonthDiff]    Script Date: 25/02/2025 11:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[CsrCalcTotKgMonthDiff]
(
    @Month INT,
    @Year INT,
	@Produttore nvarchar(255)
)
RETURNS FLOAT
AS
BEGIN
    DECLARE @TOTALE_KG_RIFIUTI_MESE_DIFF FLOAT;

    SELECT @TOTALE_KG_RIFIUTI_MESE_DIFF = ROUND(
        SUM(CASE
            WHEN MONTH(ConsorzioRegistrazioni.DataRegistrazione) = @Month 
                 AND ConsorzioRegistrazioni.ConsorzioPeriodoId <> 3 
                 AND ConsorzioSmaltimenti.Id = 1
                THEN ConsorzioRegistrazioni.PesoTotale
            WHEN ConsorzioRegistrazioni.ConsorzioPeriodoId = 3 
                 AND YEAR(ConsorzioRegistrazioni.DataRegistrazione) = @Year 
                 AND ConsorzioSmaltimenti.Id = 1
                THEN ConsorzioRegistrazioni.PesoTotale / 12
            ELSE 0
        END),
        2
    )
    FROM dbo.ConsorzioRegistrazioni
    INNER JOIN dbo.ConsorzioOperazioni
        ON dbo.ConsorzioRegistrazioni.ConsorzioOperazioneId = dbo.ConsorzioOperazioni.Id
    INNER JOIN dbo.ConsorzioSmaltimenti
        ON dbo.ConsorzioOperazioni.ConsorzioSmaltimentoId = dbo.ConsorzioSmaltimenti.Id
   inner join ConsorzioProduttori on ConsorzioRegistrazioni.ConsorzioProduttoreId=ConsorzioProduttori.Id
	WHERE YEAR(DataRegistrazione)=@Year and ConsorzioProduttori.Descrizione=@Produttore

    RETURN @TOTALE_KG_RIFIUTI_MESE_DIFF;
END;
GO
/****** Object:  UserDefinedFunction [dbo].[CsrCalcTotKgMonthInDiff]    Script Date: 25/02/2025 11:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[CsrCalcTotKgMonthInDiff]
(
    @Month INT,
    @Year INT,
	@Produttore nvarchar(255)
)
RETURNS FLOAT
AS
BEGIN
    DECLARE @TOTALE_KG_RIFIUTI_MESE_INDIFF FLOAT;

    SELECT @TOTALE_KG_RIFIUTI_MESE_INDIFF = ROUND(
        SUM(CASE
            WHEN MONTH(ConsorzioRegistrazioni.DataRegistrazione) = @Month 
                 AND ConsorzioRegistrazioni.ConsorzioPeriodoId <> 3 
                 AND ConsorzioSmaltimenti.Id = 2
                THEN ConsorzioRegistrazioni.PesoTotale
            WHEN ConsorzioRegistrazioni.ConsorzioPeriodoId = 3 
                 AND YEAR(ConsorzioRegistrazioni.DataRegistrazione) = @Year 
                 AND ConsorzioSmaltimenti.Id = 2
                THEN ConsorzioRegistrazioni.PesoTotale / 12
            ELSE 0
        END),
        2
    )
    FROM dbo.ConsorzioRegistrazioni
    INNER JOIN dbo.ConsorzioOperazioni
        ON dbo.ConsorzioRegistrazioni.ConsorzioOperazioneId = dbo.ConsorzioOperazioni.Id
    INNER JOIN dbo.ConsorzioSmaltimenti
        ON dbo.ConsorzioOperazioni.ConsorzioSmaltimentoId = dbo.ConsorzioSmaltimenti.Id
    inner join ConsorzioProduttori on ConsorzioRegistrazioni.ConsorzioProduttoreId=ConsorzioProduttori.Id
	WHERE YEAR(DataRegistrazione)=@Year and ConsorzioProduttori.Descrizione=@Produttore

    RETURN @TOTALE_KG_RIFIUTI_MESE_INDIFF;
END;
GO
/****** Object:  UserDefinedFunction [dbo].[CsrCalcTotKgMonthProCap]    Script Date: 25/02/2025 11:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[CsrCalcTotKgMonthProCap]
(
    @Month INT,
    @Year INT,
	@Produttore nvarchar(255)
)
RETURNS FLOAT
AS
BEGIN
    DECLARE @TOTALE_KG_RIFIUTI_MESE_PROCAP FLOAT;

    SELECT @TOTALE_KG_RIFIUTI_MESE_PROCAP = 
        CASE 
            WHEN MAX(dbo.ConsorzioComuniDemografie.Anno2023) = 0 THEN NULL
            ELSE 
                ROUND(
                    SUM(CASE
                        WHEN MONTH(dbo.ConsorzioRegistrazioni.DataRegistrazione) = @Month 
                             AND dbo.ConsorzioRegistrazioni.ConsorzioPeriodoId <> 3
                            THEN dbo.ConsorzioRegistrazioni.PesoTotale
                        WHEN dbo.ConsorzioRegistrazioni.ConsorzioPeriodoId = 3 
                             AND YEAR(dbo.ConsorzioRegistrazioni.DataRegistrazione) = @Year
                            THEN dbo.ConsorzioRegistrazioni.PesoTotale / 12
                        ELSE 0
                    END) * 1.0 / MAX(dbo.ConsorzioComuniDemografie.Anno2023),
                    2
                )
        END
    FROM dbo.ConsorzioRegistrazioni
    INNER JOIN dbo.ConsorzioProduttori
        ON dbo.ConsorzioRegistrazioni.ConsorzioProduttoreId = dbo.ConsorzioProduttori.Id
    INNER JOIN dbo.ConsorzioComuni
        ON dbo.ConsorzioProduttori.ConsorzioComuneId = dbo.ConsorzioComuni.Id
    INNER JOIN dbo.ConsorzioComuniDemografie
        ON dbo.ConsorzioComuniDemografie.ConsorzioComuneId = dbo.ConsorzioComuni.Id
   
	WHERE YEAR(DataRegistrazione)=@Year and ConsorzioProduttori.Descrizione=@Produttore

    RETURN @TOTALE_KG_RIFIUTI_MESE_PROCAP;
END;
GO
/****** Object:  UserDefinedFunction [dbo].[CsrCalcTotKgMonthProCapDiff]    Script Date: 25/02/2025 11:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[CsrCalcTotKgMonthProCapDiff]
(
    @Month INT,
    @Year INT,
	@Produttore nvarchar(255)

)
RETURNS FLOAT
AS
BEGIN
    DECLARE @TOTALE_KG_RIFIUTI_MESE_PROCAP_DIFF FLOAT;

    SELECT @TOTALE_KG_RIFIUTI_MESE_PROCAP_DIFF = 
        CASE 
            WHEN MAX(dbo.ConsorzioComuniDemografie.Anno2023) = 0 THEN NULL
            ELSE 
                ROUND(
                    SUM(CASE
                        WHEN MONTH(dbo.ConsorzioRegistrazioni.DataRegistrazione) = @Month 
                             AND dbo.ConsorzioRegistrazioni.ConsorzioPeriodoId <> 3 AND ConsorzioSmaltimenti.Id = 1
                            THEN dbo.ConsorzioRegistrazioni.PesoTotale
                        WHEN dbo.ConsorzioRegistrazioni.ConsorzioPeriodoId = 3 
                             AND YEAR(dbo.ConsorzioRegistrazioni.DataRegistrazione) = @Year AND ConsorzioSmaltimenti.Id = 1
                            THEN dbo.ConsorzioRegistrazioni.PesoTotale / 12
                        ELSE 0
                    END) * 1.0 / MAX(dbo.ConsorzioComuniDemografie.Anno2023),
                    2
                )
        END
    FROM dbo.ConsorzioRegistrazioni
INNER JOIN dbo.ConsorzioOperazioni
        ON dbo.ConsorzioRegistrazioni.ConsorzioOperazioneId = dbo.ConsorzioOperazioni.Id
    INNER JOIN dbo.ConsorzioSmaltimenti
        ON dbo.ConsorzioOperazioni.ConsorzioSmaltimentoId = dbo.ConsorzioSmaltimenti.Id
    INNER JOIN dbo.ConsorzioProduttori
        ON dbo.ConsorzioRegistrazioni.ConsorzioProduttoreId = dbo.ConsorzioProduttori.Id
    INNER JOIN dbo.ConsorzioComuni
        ON dbo.ConsorzioProduttori.ConsorzioComuneId = dbo.ConsorzioComuni.Id
    INNER JOIN dbo.ConsorzioComuniDemografie
        ON dbo.ConsorzioComuniDemografie.ConsorzioComuneId = dbo.ConsorzioComuni.Id
    WHERE YEAR(dbo.ConsorzioRegistrazioni.DataRegistrazione) = @Year and ConsorzioProduttori.Descrizione=@Produttore

    RETURN @TOTALE_KG_RIFIUTI_MESE_PROCAP_DIFF;
END;
GO
/****** Object:  UserDefinedFunction [dbo].[CsrCalcTotKgMonthProCapInDiff]    Script Date: 25/02/2025 11:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[CsrCalcTotKgMonthProCapInDiff]
(
    @Month INT,
    @Year INT,
	@Produttore nvarchar(255)
)
RETURNS FLOAT
AS
BEGIN
    DECLARE @TOTALE_KG_RIFIUTI_MESE_PROCAP_INDIFF FLOAT;

    SELECT @TOTALE_KG_RIFIUTI_MESE_PROCAP_INDIFF = 
        CASE 
            WHEN MAX(dbo.ConsorzioComuniDemografie.Anno2023) = 0 THEN NULL
            ELSE 
                ROUND(
                    SUM(CASE
                        WHEN MONTH(dbo.ConsorzioRegistrazioni.DataRegistrazione) = @Month 
                             AND dbo.ConsorzioRegistrazioni.ConsorzioPeriodoId <> 3 AND ConsorzioSmaltimenti.Id = 2
                            THEN dbo.ConsorzioRegistrazioni.PesoTotale
                        WHEN dbo.ConsorzioRegistrazioni.ConsorzioPeriodoId = 3 
                             AND YEAR(dbo.ConsorzioRegistrazioni.DataRegistrazione) = @Year AND ConsorzioSmaltimenti.Id = 2
                            THEN dbo.ConsorzioRegistrazioni.PesoTotale / 12
                        ELSE 0
                    END) * 1.0 / MAX(dbo.ConsorzioComuniDemografie.Anno2023),
                    2
                )
        END
    FROM dbo.ConsorzioRegistrazioni
INNER JOIN dbo.ConsorzioOperazioni
        ON dbo.ConsorzioRegistrazioni.ConsorzioOperazioneId = dbo.ConsorzioOperazioni.Id
    INNER JOIN dbo.ConsorzioSmaltimenti
        ON dbo.ConsorzioOperazioni.ConsorzioSmaltimentoId = dbo.ConsorzioSmaltimenti.Id
    INNER JOIN dbo.ConsorzioProduttori
        ON dbo.ConsorzioRegistrazioni.ConsorzioProduttoreId = dbo.ConsorzioProduttori.Id
    INNER JOIN dbo.ConsorzioComuni
        ON dbo.ConsorzioProduttori.ConsorzioComuneId = dbo.ConsorzioComuni.Id
    INNER JOIN dbo.ConsorzioComuniDemografie
        ON dbo.ConsorzioComuniDemografie.ConsorzioComuneId = dbo.ConsorzioComuni.Id
    WHERE YEAR(dbo.ConsorzioRegistrazioni.DataRegistrazione) = @Year and ConsorzioProduttori.Descrizione=@Produttore

    RETURN @TOTALE_KG_RIFIUTI_MESE_PROCAP_INDIFF;
END;
GO
