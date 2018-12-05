/****** Object:  StoredProcedure [dbo].[sp_Users_ups]    Script Date: Nov 30 2018  4:17PM  ******/
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
-- Description : Upsert CRUD Users
-- ===================================================================

CREATE PROCEDURE [dbo].[sp_Users_InsertUpdate]
  (@Id int, @IsActive bit, @CGU_CGV bit, @Robot bit, @PartnersInfos bit, @MonCRAInfos bit, @ActivationCode uniqueidentifier, @FirstName nvarchar(MAX)=NULL, @LastName nvarchar(MAX)=NULL, @Email nvarchar(250), @Password nvarchar(250), @Action VARCHAR(10))
AS
BEGIN

	DECLARE 
	@UsersId	INT,
	@COMPTE		INT = 0

	,@NOW	DATETIME
	SET @NOW = GETDATE()

	IF UPPER(@Action)='INSERT'
	BEGIN
		INSERT INTO [dbo].[Users] ([IsActive], [CGU_CGV], [Robot], [PartnersInfos], [MonCRAInfos], [ActivationCode], [FirstName], [LastName])
		VALUES (@IsActive, @CGU_CGV, @Robot, @PartnersInfos, @MonCRAInfos, @ActivationCode, @FirstName, @LastName);

		--SELECT * FROM [dbo].[Users] WHERE [ID] = SCOPE_IDENTITY();
		
		SET @UsersId = SCOPE_IDENTITY();

		EXEC [dbo].[sp_Users_Email_InsertUpdate]
		@UsersId =  @UsersId,
		@Email = @Email,
		@IsActive =  1,
		@AccountType =  10,
		@CreationDate = @NOW,
		@DeletionDate = NULL,
		@Action = N'INSERT'

		EXEC [dbo].[sp_Users_Password_InsertUpdate]
		@UsersId =  @UsersId,
		@Password = @Password,
		@IsActive = 1,
		@CreationDate = @NOW,
		@DeletionDate = NULL,
		@Action = N'INSERT'


	END

	IF UPPER(@Action)='UPDATE'
	BEGIN
		UPDATE [dbo].[Users]
		SET 
			[IsActive]			= @IsActive, 
			[CGU_CGV]			= @CGU_CGV, 
			[Robot]				= @Robot, 
			[PartnersInfos]		= @PartnersInfos, 
			[MonCRAInfos]		= @MonCRAInfos, 
			[ActivationCode]	= @ActivationCode, 
			[FirstName]			= @FirstName, 
			[LastName]			= @LastName
		WHERE
			[ID]  =  @ID;

		SELECT * FROM [dbo].[Users] WHERE [ID]  =  @ID;
	END

END
GO



/****** Object:  StoredProcedure [dbo].[sp_Users_sel]    Script Date: Nov 30 2018  4:24PM  ******/
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
-- Description : Select CRUD Users
-- ===================================================================

CREATE PROCEDURE [dbo].[sp_Users_GetById]
	(@ID int=NULL)
AS
BEGIN


	SELECT 
		U.[Id],
		U.[FirstName],
		U.[LastName],
		U.[IsActive],
		U.[CGU_CGV],
		U.[Robot],
		U.[PartnersInfos],
		U.[MonCRAInfos],
		U.[ActivationCode],
		E.[Email],
		P.Password
	FROM [dbo].[Users] U
	INNER JOIN [dbo].[Users_Email] E	ON E.[UsersId] = U.Id AND E.[IsActive] = 1
	INNEr JOIN [dbo].[Users_Password] p	ON P.[UsersId] = U.Id AND P.[IsActive] = 1
	WHERE 
		U.[Id] = @ID;
END
GO

CREATE PROCEDURE [dbo].[sp_Users_GetByEmail]
	(@Email nvarchar(250) = NULL)
AS
BEGIN


	SELECT 
		U.[Id],
		U.[FirstName],
		U.[LastName],
		U.[IsActive],
		U.[CGU_CGV],
		U.[Robot],
		U.[PartnersInfos],
		U.[MonCRAInfos],
		U.[ActivationCode],
		E.[Email],
		P.Password
	FROM [dbo].[Users] U
	INNER JOIN [dbo].[Users_Email] E	ON E.[UsersId] = U.Id AND E.[IsActive] = 1
	INNEr JOIN [dbo].[Users_Password] p	ON P.[UsersId] = U.Id AND P.[IsActive] = 1
	WHERE 
		E.[Email] = @Email;
END
GO

CREATE PROCEDURE [dbo].[sp_Users_Validate]
	(@Email nvarchar(250) = NULL, @Password nvarchar(250) = NULL)
AS
BEGIN

	SELECT 
		U.[Id],
		U.[FirstName],
		U.[LastName],
		U.[IsActive],
		U.[CGU_CGV],
		U.[Robot],
		U.[PartnersInfos],
		U.[MonCRAInfos],
		U.[ActivationCode],
		E.[Email],
		P.Password
	FROM [dbo].[Users] U
	INNER JOIN [dbo].[Users_Email] E	ON E.[UsersId] = U.Id AND E.[IsActive] = 1
	INNEr JOIN [dbo].[Users_Password] p	ON P.[UsersId] = U.Id AND P.[IsActive] = 1
	WHERE 
		E.[Email] = @Email
	AND P.Password = @Password;

END
GO



/****** Object:  StoredProcedure [dbo].[sp_Users_del]    Script Date: Nov 30 2018  4:24PM  ******/
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
-- Description : Delete CRUD Users
-- ===================================================================

CREATE PROCEDURE [dbo].[sp_Users_del]
	(@ID int)
AS
BEGIN
	SET NOCOUNT ON;
	
	DELETE 
	FROM [dbo].[Users] 
	WHERE 
		[Id] = @ID;

	SELECT @@ROWCOUNT as [Rows Affected];
END
GO

