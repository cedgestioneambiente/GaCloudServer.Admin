/****** Object:  StoredProcedure [dbo].[SP_GetGaContrattiPermessiMode]    Script Date: 14/10/2022 11:36:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetGaContrattiPermessiMode]
	--Mode 1: Attivi [1,4]
	--Mode 2: Passivi [2,3]
	--Mode 3: Archivio 
	--Mode 4: Totale
	-- Add the parameters for the stored procedure here
	@userId nvarchar(100),
	@userRoles LIST_OF_STRING READONLY,
	@mode bigint
AS
BEGIN
	DECLARE	@isAdministrative int;
	DECLARE @permessi TABLE ( permesso varchar(max) not null);
	DECLARE @permessiContratto TABLE(idContratto bigint, permesso varchar(max) not null);
	DECLARE @contrattiPermessi TABLE(id bigint);

	DECLARE @contrattiCount int;

	DECLARE @contrattoId bigint;
	DECLARE @direzione bit;
	DECLARE @contabilita bit;
	DECLARE @personale bit;
	DECLARE @informatica bit;
	DECLARE @tecnico bit;
	DECLARE @qualitasicurezza bit;
	DECLARE @commerciale bit;
	DECLARE @affarigenerali bit;
	DECLARE @comunicazione bit;

	IF @mode='1'
	BEGIN
	DECLARE load_cursor CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR 
		SELECT id,Direzione,Contabilita,Personale,Informatica,Tecnico,QualitaSicurezza,Commerciale,AffariGenerali,Comunicazione
		FROM GaContrattiDocumenti
		where (ContrattiTipologiaId='1' or ContrattiTipologiaId='4') and Archiviato='0'
	END

	IF @mode='2'
	BEGIN
	DECLARE load_cursor CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR 
		SELECT id,Direzione,Contabilita,Personale,Informatica,Tecnico,QualitaSicurezza,Commerciale,AffariGenerali,Comunicazione
		FROM GaContrattiDocumenti
		where (ContrattiTipologiaId='2' or ContrattiTipologiaId='3') and Archiviato='0'
	END

	IF @mode='3'
	BEGIN
	DECLARE load_cursor CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR 
		SELECT id,Direzione,Contabilita,Personale,Informatica,Tecnico,QualitaSicurezza,Commerciale,AffariGenerali,Comunicazione
		FROM GaContrattiDocumenti
		where Archiviato='1'
	END

	IF @mode='4'
	BEGIN
	DECLARE load_cursor CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR 
		SELECT id,Direzione,Contabilita,Personale,Informatica,Tecnico,QualitaSicurezza,Commerciale,AffariGenerali,Comunicazione
		FROM GaContrattiDocumenti
	END



	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET @isAdministrative=(select count(*) from @userRoles where (Valore='Administrator' or Valore='GaContrattiAdmin'));

	IF(@isAdministrative>'0')
	BEGIN
		OPEN load_cursor 
		FETCH NEXT FROM load_cursor INTO @contrattoId, @direzione,@contabilita,@personale,@informatica,@tecnico,@qualitasicurezza,@commerciale,@affarigenerali,@comunicazione 

		WHILE @@FETCH_STATUS = 0 
		BEGIN
			INSERT INTO @contrattiPermessi VALUES(@contrattoId)
			FETCH NEXT FROM load_cursor INTO @contrattoId, @direzione,@contabilita,@personale,@informatica,@tecnico,@qualitasicurezza,@commerciale,@affarigenerali,@comunicazione 
		END
		SELECT * FROM ViewGaContrattiDocumentiList WHERE Id in(SELECT id FROM @contrattiPermessi);
		CLOSE load_cursor
		DEALLOCATE load_cursor
	END

	ELSE
	BEGIN -- BEGIN ELSE
		--Creazione variabile con permessi utente
		INSERT INTO @permessi select Permesso from ViewGaContrattiUtentiOnPermessi where UtenteId=@userId and Abilitato='1';

		
		--Ciclo per creazione variabile permessi contratti
		OPEN load_cursor 
		FETCH NEXT FROM load_cursor INTO @contrattoId, @direzione,@contabilita,@personale,@informatica,@tecnico,@qualitasicurezza,@commerciale,@affarigenerali,@comunicazione 

		WHILE @@FETCH_STATUS = 0 
		BEGIN
		delete from @permessiContratto;

		if @direzione='1' begin insert into @permessiContratto values(@contrattoId,'DIREZIONE') end
		if @contabilita='1' begin insert into @permessiContratto values(@contrattoId,'CONTABILTA') end
		if @personale='1' begin insert into @permessiContratto values(@contrattoId,'PERSONALE') end
		if @informatica='1' begin insert into @permessiContratto values(@contrattoId,'INFORMATICA') end
		if @tecnico='1' begin insert into @permessiContratto values(@contrattoId,'TECNICO') end
		if @qualitasicurezza='1' begin insert into @permessiContratto values(@contrattoId,'QUALITASICUREZZA') end
		if @commerciale='1' begin insert into @permessiContratto values(@contrattoId,'COMMERCIALE') end
		if @affarigenerali='1' begin insert into @permessiContratto values(@contrattoId,'AFFARIGENERALI') end
		if @comunicazione='1' begin insert into @permessiContratto values(@contrattoId,'COMUNICAZIONE') end

		SET @contrattiCount = (select count(*)from @permessiContratto as t1, @permessi as t2 where t1.permesso=t2.permesso);
		
		IF @contrattiCount>'0'
		BEGIN
		INSERT INTO @contrattiPermessi VALUES(@contrattoId)
		END

		FETCH NEXT FROM load_cursor INTO @contrattoId, @direzione,@contabilita,@personale,@informatica,@tecnico,@qualitasicurezza,@commerciale,@affarigenerali,@comunicazione 
		--RETURN STATAMENT
		
		END --END ELSE
		SELECT * FROM ViewGaContrattiDocumentiList WHERE Id IN(SELECT id FROM @contrattiPermessi);
		CLOSE load_cursor
		DEALLOCATE load_cursor


	END
	

END



GO


/****** Object:  StoredProcedure [dbo].[SP_GetGaContrattiPermessi]    Script Date: 14/10/2022 11:38:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetGaContrattiPermessi]
	                -- Add the parameters for the stored procedure here
	                @userId nvarchar(100),
	                @userRoles LIST_OF_STRING READONLY,
	                @fornitoreId bigint,
	                @archiviato bit
                AS
                BEGIN
	                declare	@isAdministrative int;
	                DECLARE @permessi TABLE ( permesso varchar(max) not null);
	                declare @permessiContratto TABLE(idContratto bigint, permesso varchar(max) not null);
	                DECLARE @contrattiPermessi TABLE(id bigint);

	                DECLARE @contrattiCount int;

	                DECLARE @contrattoId bigint;
	                DECLARE @direzione bit;
	                DECLARE @contabilita bit;
	                DECLARE @personale bit;
	                DECLARE @informatica bit;
	                DECLARE @tecnico bit;
	                DECLARE @qualitasicurezza bit;
	                DECLARE @commerciale bit;
	                DECLARE @affarigenerali bit;
	                DECLARE @comunicazione bit;

	                DECLARE load_cursor CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR 
		                SELECT id,Direzione,Contabilita,Personale,Informatica,Tecnico,QualitaSicurezza,Commerciale,AffariGenerali,Comunicazione
		                FROM GaContrattiDocumenti
		                where ContrattiSoggettoId=@soggettoId


	                -- SET NOCOUNT ON added to prevent extra result sets from
	                -- interfering with SELECT statements.
	                SET NOCOUNT ON;
	                SET @isAdministrative=(select count(*) from @userRoles where (Valore='Administrator' or Valore='GaContrattiAdmin'));

	                IF(@isAdministrative>'0')
	                BEGIN
	                select * from ViewGaContrattiDocumenti where ContrattiSoggettoId=@soggettoId and Archiviato=@archiviato
	                END

	                ELSE
	                BEGIN -- BEGIN ELSE
		                --Creazione variabile con permessi utente
		                INSERT INTO @permessi select Permesso from ViewGaContrattiUtentiOnPermessi where UtenteId=@userId and Abilitato='1';

		
		                --Ciclo per creazione variabile permessi contratti
		                OPEN load_cursor 
		                FETCH NEXT FROM load_cursor INTO @contrattoId, @direzione,@contabilita,@personale,@informatica,@tecnico,@qualitasicurezza,@commerciale,@affarigenerali,@comunicazione 

		                WHILE @@FETCH_STATUS = 0 
		                BEGIN
		                delete from @permessiContratto;

		                if @direzione='1' begin insert into @permessiContratto values(@contrattoId,'DIREZIONE') end
		                if @contabilita='1' begin insert into @permessiContratto values(@contrattoId,'CONTABILTA') end
		                if @personale='1' begin insert into @permessiContratto values(@contrattoId,'PERSONALE') end
		                if @informatica='1' begin insert into @permessiContratto values(@contrattoId,'INFORMATICA') end
		                if @tecnico='1' begin insert into @permessiContratto values(@contrattoId,'TECNICO') end
		                if @qualitasicurezza='1' begin insert into @permessiContratto values(@contrattoId,'QUALITASICUREZZA') end
		                if @commerciale='1' begin insert into @permessiContratto values(@contrattoId,'COMMERCIALE') end
		                if @affarigenerali='1' begin insert into @permessiContratto values(@contrattoId,'AFFARIGENERALI') end
		                if @comunicazione='1' begin insert into @permessiContratto values(@contrattoId,'COMUNICAZIONE') end

		                --PRINT @contrattoId
		                --SELECT * FROM @permessiContratto;
		                SET @contrattiCount = (select count(*)from @permessiContratto as t1, @permessi as t2 where t1.permesso=t2.permesso);
		                --print CONCAT(@contrattoId,'-',@contrattiCount)
		                IF @contrattiCount>'0'
		                BEGIN
		                INSERT INTO @contrattiPermessi VALUES(@contrattoId)
		                END

		                FETCH NEXT FROM load_cursor INTO @contrattoId, @direzione,@contabilita,@personale,@informatica,@tecnico,@qualitasicurezza,@commerciale,@affarigenerali,@comunicazione 
		                --RETURN STATAMENT
		
		                END --END ELSE
		                select * from ViewGaContrattiDocumenti where Id in(select id from @contrattiPermessi) and Archiviato=@archiviato;
		                CLOSE load_cursor
		                DEALLOCATE load_cursor


                END
	

                END
GO

/****** Object:  StoredProcedure [dbo].[SP_GetGaContrattiNumeratori]    Script Date: 14/10/2022 11:38:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[SP_GetGaContrattiNumeratori]
                        AS
                        BEGIN
	                        SET NOCOUNT ON;
	                        SELECT        c.Numero + 1 AS start, ISNULL(c.Id, - 9999) AS id
	                        FROM            dbo.GaContrattiDocumenti AS c LEFT OUTER JOIN
                                                 dbo.GaContrattiDocumenti AS r ON c.Numero + 1 = r.Numero
                        WHERE        (r.Numero IS NULL)
                        END
GO