/****** Object:  StoredProcedure [dbo].[sp_LNK_Users_UserRole_ups]    Script Date: Dec  5 2018 12:31AM  ******/
USE [mcdev002];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- ===================================================================
-- Author      : MC
-- Create date : 12/05/2018
-- Revised date: 
-- Description : Upsert CRUD LNK_Users_UserRole
-- ===================================================================

CREATE PROCEDURE [dbo].[sp_LNK_Users_UserRole__InsertUpdate]
  (@UsersId int, @UsersRolesId int, @IsActive bit, @CreationDate datetime, @CompanyId int=NULL,@DeletionDate datetime=NULL, @Action VARCHAR(10))
AS
BEGIN

	DECLARE 
	@COMPTE INT = 0

	,@NOW	DATETIME
	SET @NOW = GETDATE()

	IF UPPER(@Action)='INSERT'
	BEGIN
		INSERT INTO [dbo].[LNK_Users_UserRole] ([UsersId], [UsersRolesId], [IsActive], [CreationDate], [CompanyId], [DeletionDate])
		VALUES (@UsersId, @UsersRolesId, @IsActive, @CreationDate, @CompanyId, @DeletionDate);
	END

	IF UPPER(@Action)='UPDATE'
	BEGIN
		UPDATE [dbo].[LNK_Users_UserRole]
		SET 
			[UsersId] =			@UsersId, 
			[UsersRolesId] =	@UsersRolesId, 
			[IsActive] =		@IsActive, 
			[CreationDate] =	@CreationDate, 
			[CompanyId] =		@CompanyId, 
			[DeletionDate] =	@DeletionDate
		WHERE 
			[UsersId] =			@UsersId
		AND [UsersRolesId] =	@UsersRolesId
		AND [IsActive] =		@IsActive;

	END
END
GO



/****** Object:  StoredProcedure [dbo].[sp_LNK_Users_UserRole_sel]    Script Date: Dec  5 2018 12:31AM  ******/
USE [mcdev002];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- ===================================================================
-- Author      : MC
-- Create date : 12/05/2018
-- Revised date: 
-- Description : Select CRUD LNK_Users_UserRole
-- ===================================================================

CREATE PROCEDURE [dbo].[sp_LNK_Users_UserRole_sel]
  (@ID int=NULL)
AS
BEGIN
  IF @ID IS NULL OR @ID = 0
    SELECT * FROM [dbo].[LNK_Users_UserRole] ORDER BY [ID] ASC;
  ELSE
    SELECT * FROM [dbo].[LNK_Users_UserRole] WHERE [ID] = @ID;
END
GO



/****** Object:  StoredProcedure [dbo].[sp_LNK_Users_UserRole_del]    Script Date: Dec  5 2018 12:31AM  ******/
USE [mcdev002];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- ===================================================================
-- Author      : MC
-- Create date : 12/05/2018
-- Revised date: 
-- Description : Delete CRUD LNK_Users_UserRole
-- ===================================================================

CREATE PROCEDURE [dbo].[sp_LNK_Users_UserRole_del]
  (@ID int, @RowVersion int)
AS
BEGIN
  SET NOCOUNT ON;
  DELETE FROM [dbo].[LNK_Users_UserRole] WHERE [ID]=@ID AND [RowVersion]=@RowVersion;
  SELECT @@ROWCOUNT as [Rows Affected];
END
GO

