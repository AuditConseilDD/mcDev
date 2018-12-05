/****** Object:  StoredProcedure [dbo].[sp_Users_Email_ups]    Script Date: Nov 30 2018  4:43PM  ******/
USE [mcdev002];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- ===================================================================
-- Author      : MC
-- Create date : 11/30/2018
-- Revised date: 
-- Description : Upsert CRUD Users_Email
-- ===================================================================

CREATE PROCEDURE [dbo].[sp_Users_Email_InsertUpdate]
  (@UsersId int,@Email nvarchar(250),@IsActive bit,@AccountType int,@CreationDate datetime,@DeletionDate datetime=NULL, @Action VARCHAR(10))
AS
BEGIN

	DECLARE 
	@COMPTE INT = 0

	,@NOW	DATETIME
	SET @NOW = GETDATE()

	IF UPPER(@Action)='INSERT'
	BEGIN
		INSERT INTO [dbo].[Users_Email] ([UsersId], [Email], [IsActive], [AccountType], [CreationDate], [DeletionDate])
		VALUES (@UsersId, @Email, @IsActive, @AccountType, @CreationDate, @DeletionDate);
	END

	IF UPPER(@Action)='UPDATE'
	BEGIN
		UPDATE [dbo].[Users_Email]
		SET 
			[UsersId]		= @UsersId, 
			[Email]			= @Email, 
			[IsActive]		= @IsActive, 
			[AccountType]	= @AccountType, 
			[CreationDate]	= @CreationDate, 
			[DeletionDate]	= @DeletionDate
		WHERE 
			Email = @Email
		AND IsActive = @IsActive
		AND UsersId = @UsersId;
	END

	SELECT * 
	FROM [dbo].[Users_Email] 
	WHERE 
		Email = @Email
	AND IsActive = @IsActive
	AND UsersId = @UsersId;
END
GO



/****** Object:  StoredProcedure [dbo].[sp_Users_Email_sel]    Script Date: Nov 30 2018  4:43PM  ******/
USE [mcdev002];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- ===================================================================
-- Author      : MC
-- Create date : 11/30/2018
-- Revised date: 
-- Description : Select CRUD Users_Email
-- ===================================================================

CREATE PROCEDURE [dbo].[sp_Users_Email_sel]
  (@ID int = NULL)
AS
BEGIN
  IF @ID IS NULL OR @ID = 0
    SELECT * FROM [dbo].[Users_Email] ORDER BY [Email,IsActive,UsersId] ASC;
  ELSE
    SELECT * FROM [dbo].[Users_Email] WHERE [ID] = @ID;
END
GO



/****** Object:  StoredProcedure [dbo].[sp_Users_Email_del]    Script Date: Nov 30 2018  4:43PM  ******/
USE [mcdev002];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- ===================================================================
-- Author      : MC
-- Create date : 11/30/2018
-- Revised date: 
-- Description : Delete CRUD Users_Email
-- ===================================================================

CREATE PROCEDURE [dbo].[sp_Users_Email_del]
  (@ID int, @RowVersion int)
AS
BEGIN
  SET NOCOUNT ON;
  DELETE FROM [dbo].[Users_Email] WHERE [Email,IsActive,UsersId]=@ID AND [RowVersion]=@RowVersion;
  SELECT @@ROWCOUNT as [Rows Affected];
END
GO

