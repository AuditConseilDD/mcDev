/****** Object:  StoredProcedure [dbo].[sp_CRA_ActiviteDetail_ups]    Script Date: Nov 14 2018 12:10PM  ******/
USE [mcdev002];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- ===================================================================
-- Author      : MC
-- Create date : 11/14/2018
-- Revised date: 
-- Description : Upsert CRUD CRA_ActiviteDetail
-- ===================================================================

CREATE PROCEDURE [dbo].[sp_CRA_ActiviteDetail__InsertUpdate]
(
	@CRAActiviteId	INT, 
	@DateBegin		DATETIME, 
	@DateEnd		DATETIME, 
	@CRAlibeleColId INT, 
	@Quantity		NUMERIC(10, 4)=NULL, 
	@CreationBY		NVARCHAR(250)=NULL, 
	@ModificationBY NVARCHAR(250)=NULL,    
	@Action			VARCHAR(10)
)
AS
BEGIN

	DECLARE 
	@COMPTE INT = 0

	,@NOW	DATETIME
	SET @NOW = GETDATE()

	IF UPPER(@Action)='INSERT'    
	BEGIN

		PRINT '>> ' + @ACTION
		INSERT INTO [dbo].[CRA_ActiviteDetail] ([CRAActiviteId], [DateBegin], [DateEnd], [CRAlibeleColId], [Quantity], [CreationDate], [CreationBY], [modificationDate], [ModificationBY])
		VALUES (@CRAActiviteId, @DateBegin, @DateEnd, @CRAlibeleColId, @Quantity, @NOW , @CreationBY, NULL, NULL);

		--SELECT * FROM [dbo].[CRA_ActiviteDetail] WHERE [ID] = SCOPE_IDENTITY();
	END

	IF UPPER(@Action)='UPDATE'
	BEGIN
		UPDATE [dbo].[CRA_ActiviteDetail]
		SET 
			[DateBegin]			= @DateBegin, 
			[DateEnd]			= @DateEnd, 
			[CRAlibeleColId]	= @CRAlibeleColId, 
			[Quantity]			= @Quantity, 
			[modificationDate]	= @NOW, 
			[ModificationBY]	= @ModificationBY
		WHERE 
			CRAActiviteId	= @CRAActiviteId
		AND CRAlibeleColId	= @CRAlibeleColId
		AND DateBegin		= @DateBegin
		AND DateEnd			= @DateEnd

		--SELECT * FROM [dbo].[CRA_ActiviteDetail] WHERE [ID]  =  @ID;
	END
END
GO

--CREATE PROCEDURE [dbo].[sp_CRA_ActiviteDetail_ups]
--	(@MyID int, @CRAActiviteId int, @DateBegin datetime, @DateEnd datetime, @CRAlibeleColId int, @Quantity numeric=NULL, @CreationDate datetime=NULL, @CreationBY nvarchar(250)=NULL, @modificationDate datetime=NULL, @ModificationBY nvarchar(250)=NULL)
--AS
--BEGIN
--	SET CONTEXT_INFO @MyID;
--	IF @ID IS NULL OR @ID = 0
--	BEGIN
--		INSERT INTO [dbo].[CRA_ActiviteDetail] ([CRAActiviteId], [DateBegin], [DateEnd], [CRAlibeleColId], [Quantity], [CreationDate], [CreationBY], [modificationDate], [ModificationBY])
--		VALUES (@CRAActiviteId, @DateBegin, @DateEnd, @CRAlibeleColId, @Quantity, @CreationDate, @CreationBY, @modificationDate, @ModificationBY);

--		--SELECT * FROM [dbo].[CRA_ActiviteDetail] WHERE [ID] = SCOPE_IDENTITY();
--	END
--	ELSE
--	BEGIN
--		UPDATE [dbo].[CRA_ActiviteDetail]
--		SET [DateBegin] = @DateBegin, [DateEnd] = @DateEnd, [CRAlibeleColId] = @CRAlibeleColId, [Quantity] = @Quantity, [modificationDate] = @modificationDate, [ModificationBY] = @ModificationBY
--		WHERE 
--			CRAActiviteId	= @CRAActiviteId
--		AND CRAlibeleColId	= @CRAlibeleColId
--		AND DateBegin		= @DateBegin
--		AND DateEnd			= @DateEnd

--		SELECT * FROM [dbo].[CRA_ActiviteDetail] WHERE [ID]  =  @ID;
--	END
--	END
--GO



/****** Object:  StoredProcedure [dbo].[sp_CRA_ActiviteDetail_sel]    Script Date: Nov 14 2018 12:10PM  ******/
USE [mcdev002];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- ===================================================================
-- Author      : MC
-- Create date : 11/14/2018
-- Revised date: 
-- Description : Select CRUD CRA_ActiviteDetail
-- ===================================================================

CREATE PROCEDURE [dbo].[sp_CRA_ActiviteDetail_sel]
  --(@MyID int, @ID int=NULL)
  (@craId INT)
AS
BEGIN
	--SET CONTEXT_INFO @MyID;
	--IF @craId IS NULL OR @craId = 0
	--	SELECT * FROM [dbo].[CRA_ActiviteDetail] ORDER BY [CRAActiviteId, CRAlibeleColId, DateBegin, DateEnd] ASC;
	--ELSE
	SELECT		
		[CRAActiviteId]
		,[DateBegin]
		,[DateEnd]
		,[CRAlibeleColId]
		,[Quantity]
		,[CreationDate]
		,[CreationBY]
		,[modificationDate]
		,[ModificationBY]
	FROM [dbo].[CRA_ActiviteDetail] 
	WHERE [CRAActiviteId] = @craId
	ORDER BY [DateBegin] ASC, [DateEnd] DESC;
END
GO



/****** Object:  StoredProcedure [dbo].[sp_CRA_ActiviteDetail_del]    Script Date: Nov 14 2018 12:10PM  ******/
USE [mcdev002];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- ===================================================================
-- Author      : MC
-- Create date : 11/14/2018
-- Revised date: 
-- Description : Delete CRUD CRA_ActiviteDetail
-- ===================================================================

CREATE PROCEDURE [dbo].[sp_CRA_ActiviteDetail_del]
  (@MyID int, @ID int, @RowVersion int)
AS
BEGIN
  SET CONTEXT_INFO @MyID;
  SET NOCOUNT ON;
  DELETE FROM [dbo].[CRA_ActiviteDetail] WHERE [ CRAActiviteId, CRAlibeleColId, DateBegin, DateEnd]=@ID AND [RowVersion]=@RowVersion;
  SELECT @@ROWCOUNT as [Rows Affected];
END
GO

