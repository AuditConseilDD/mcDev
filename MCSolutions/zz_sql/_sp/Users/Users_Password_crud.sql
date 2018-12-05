/****** Object:  StoredProcedure [dbo].[sp_Users_Password_ups]    Script Date: Nov 30 2018  5:14PM  ******/
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
-- Description : Upsert CRUD Users_Password
-- ===================================================================

CREATE PROCEDURE [dbo].[sp_Users_Password_InsertUpdate]
  (@UsersId int, @Password nvarchar(250), @IsActive bit, @CreationDate datetime, @DeletionDate datetime=NULL, @Action VARCHAR(10))
AS
BEGIN

	DECLARE 
	@COMPTE INT = 0

	,@NOW	DATETIME
	SET @NOW = GETDATE()

	IF UPPER(@Action)='INSERT'
	BEGIN
		INSERT INTO [dbo].[Users_Password] ([UsersId], [Password], [IsActive], [CreationDate], [DeletionDate])
		VALUES (@UsersId, @Password, @IsActive, @CreationDate, @DeletionDate);
	END

	IF UPPER(@Action)='UPDATE'
	BEGIN
		UPDATE [dbo].[Users_Password]
		SET 
			[UsersId]		= @UsersId, 
			[Password]		= @Password, 
			[IsActive]		= @IsActive, 
			[CreationDate]	= @CreationDate, 
			[DeletionDate]	= @DeletionDate
		WHERE 
			IsActive = @IsActive
		AND Password = @Password
		AND UsersId = @UsersId;
	END

	SELECT * 
	FROM [dbo].[Users_Password]
	WHERE 
		IsActive = @IsActive
	AND Password = @Password
	AND UsersId = @UsersId;
END
GO



/****** Object:  StoredProcedure [dbo].[sp_Users_Password_sel]    Script Date: Nov 30 2018  5:14PM  ******/
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
-- Description : Select CRUD Users_Password
-- ===================================================================

CREATE PROCEDURE [dbo].[sp_Users_Password_sel]
  (@ID int=NULL)
AS
BEGIN
  IF @ID IS NULL OR @ID = 0
    SELECT * FROM [dbo].[Users_Password] ORDER BY [IsActive,Password,UsersId] ASC;
  ELSE
    SELECT * FROM [dbo].[Users_Password] WHERE [ID] = @ID;
END
GO



/****** Object:  StoredProcedure [dbo].[sp_Users_Password_del]    Script Date: Nov 30 2018  5:14PM  ******/
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
-- Description : Delete CRUD Users_Password
-- ===================================================================

CREATE PROCEDURE [dbo].[sp_Users_Password_del]
  (@ID int, @RowVersion int)
AS
BEGIN
  SET NOCOUNT ON;
  DELETE FROM [dbo].[Users_Password] WHERE [IsActive,Password,UsersId]=@ID AND [RowVersion]=@RowVersion;
  SELECT @@ROWCOUNT as [Rows Affected];
END
GO

