/****** Object:  StoredProcedure [dbo].[CRA_Type_ups]    Script Date: Nov 26 2018  9:15PM  ******/
USE [mcdev002];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- ===================================================================
-- Author      : MC
-- Create date : 11/26/2018
-- Revised date: 
-- Description : Upsert CRUD CRA_Type
-- ===================================================================

CREATE PROCEDURE [dbo].[sp_CRA_Type__InsertUpdate]
  (@Id int,@NbrColTotal int,@CreationDate datetime,@CRAName nvarchar(50)=NULL,@CRADescription nvarchar(250)=NULL,@IsActive bit=NULL,@DeletionDate datetime=NULL)
AS
BEGIN
  --SET CONTEXT_INFO @MyID;
  IF @ID IS NULL OR @ID = 0
    BEGIN
      INSERT INTO [dbo].[CRA_Type]
        ([Id],[NbrColTotal],[CreationDate],[CRAName],[CRADescription],[IsActive],[DeletionDate])
      VALUES
        (@Id,@NbrColTotal,@CreationDate,@CRAName,@CRADescription,@IsActive,@DeletionDate);
      SELECT * FROM [dbo].[CRA_Type] WHERE [ID] = SCOPE_IDENTITY();
    END
  ELSE
    BEGIN
      UPDATE [dbo].[CRA_Type]
        SET [Id]=@Id,[NbrColTotal]=@NbrColTotal,[CreationDate]=@CreationDate,[CRAName]=@CRAName,[CRADescription]=@CRADescription,[IsActive]=@IsActive,[DeletionDate]=@DeletionDate
        WHERE ([ CRAActiviteId, CRAlibeleColId, DateBegin, DateEnd] = @ID) AND ([RowVersion] = @RowVersion);
      SELECT * FROM [dbo].[CRA_Type] WHERE [ID] = @ID;
    END
END
GO



/****** Object:  StoredProcedure [dbo].[CRA_Type_sel]    Script Date: Nov 26 2018  9:15PM  ******/
USE [mcdev002];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- ===================================================================
-- Author      : MC
-- Create date : 11/26/2018
-- Revised date: 
-- Description : Select CRUD CRA_Type
-- ===================================================================

CREATE PROCEDURE [dbo].[sp_CRA_Type__List]
  (@ID int=NULL)
AS
BEGIN
  --SET CONTEXT_INFO @MyID;
  IF @ID IS NULL OR @ID = 0
    SELECT [Id]
      ,[NbrColTotal]
      ,[CRAName]
      ,[CRADescription]
      ,[IsActive]
      ,[CreationDate]
      ,[DeletionDate]
	FROM [dbo].[CRA_Type] ORDER BY [Id] ASC;
  ELSE
    SELECT [Id]
      ,[NbrColTotal]
      ,[CRAName]
      ,[CRADescription]
      ,[IsActive]
      ,[CreationDate]
      ,[DeletionDate]
	 FROM [dbo].[CRA_Type] WHERE [ID] = @ID;
END
GO



/****** Object:  StoredProcedure [dbo].[CRA_Type_del]    Script Date: Nov 26 2018  9:15PM  ******/
USE [mcdev002];
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- ===================================================================
-- Author      : MC
-- Create date : 11/26/2018
-- Revised date: 
-- Description : Delete CRUD CRA_Type
-- ===================================================================

CREATE PROCEDURE [dbo].[sp_CRA_Type_del]
  (@ID int, @RowVersion int)
AS
BEGIN
  SET CONTEXT_INFO @MyID;
  SET NOCOUNT ON;
  DELETE FROM [dbo].[CRA_Type] WHERE [ CRAActiviteId, CRAlibeleColId, DateBegin, DateEnd]=@ID AND [RowVersion]=@RowVersion;
  SELECT @@ROWCOUNT as [Rows Affected];
END
GO

