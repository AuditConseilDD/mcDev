/****** Object:  StoredProcedure [dbo].[CRA_Activite_ups]    Script Date: Nov 26 2018 10:42PM  ******/
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
-- Description : Upsert CRUD CRA_Activite
-- ===================================================================

CREATE PROCEDURE [dbo].[CRA_Activite__InsertUpdate]
  (@Id int,@UsersId int,@CRATypeId int,@Period nvarchar(50),@CreationDate datetime,@ModificaitonDate datetime=NULL,@ModificaitonBy nvarchar(250)=NULL,@PeriodBegin datetime=NULL,@PeriodEnd datetime=NULL)
AS
BEGIN
  --SET CONTEXT_INFO @MyID;
  IF @ID IS NULL OR @ID = 0
    BEGIN
      INSERT INTO [dbo].[CRA_Activite]
        ([Id],[UsersId],[CRATypeId],[Period],[CreationDate],[ModificaitonDate],[ModificaitonBy],[PeriodBegin],[PeriodEnd])
      VALUES
        (@Id,@UsersId,@CRATypeId,@Period,@CreationDate,@ModificaitonDate,@ModificaitonBy,@PeriodBegin,@PeriodEnd);
      SELECT * FROM [dbo].[CRA_Activite] WHERE [ID] = SCOPE_IDENTITY();
    END
  ELSE
    BEGIN
      UPDATE [dbo].[CRA_Activite]
        SET [Id]=@Id,[UsersId]=@UsersId,[CRATypeId]=@CRATypeId,[Period]=@Period,[CreationDate]=@CreationDate,[ModificaitonDate]=@ModificaitonDate,[ModificaitonBy]=@ModificaitonBy,[PeriodBegin]=@PeriodBegin,[PeriodEnd]=@PeriodEnd
        WHERE ([ CRAActiviteId, CRAlibeleColId, DateBegin, DateEnd] = @ID) AND ([RowVersion] = @RowVersion);
      SELECT * FROM [dbo].[CRA_Activite] WHERE [ID] = @ID;
    END
END
GO



/****** Object:  StoredProcedure [dbo].[CRA_Activite_sel]    Script Date: Nov 26 2018 10:42PM  ******/
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
-- Description : Select CRUD CRA_Activite
-- ===================================================================

CREATE PROCEDURE [dbo].[CRA_Activite_List]
  (@UsersId int=NULL)
AS
BEGIN
  --SET CONTEXT_INFO @MyID;
  --IF @ID IS NULL OR @ID = 0
  --  SELECT [Id]
  --    ,[UsersId]
  --    ,[CRATypeId]
  --    ,[Period]
  --    ,[CreationDate]
  --    ,[CreatedBy]
  --    ,[ModificaitonDate]
  --    ,[ModificaitonBy]
  --    ,[PeriodBegin]
  --    ,[PeriodEnd]
	 -- FROM [dbo].[CRA_Activite] ORDER BY [Id] ASC;
  --ELSE
    SELECT [Id]
      ,[UsersId]
      ,[CRATypeId]
      ,[Period]
      ,[CreationDate]
      ,[CreatedBy]
      ,[ModificaitonDate]
      ,[ModificaitonBy]
      ,[PeriodBegin]
      ,[PeriodEnd]
	 FROM [dbo].[CRA_Activite] 
	 WHERE [UsersId] = @UsersId;
END
GO



/****** Object:  StoredProcedure [dbo].[CRA_Activite_del]    Script Date: Nov 26 2018 10:42PM  ******/
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
-- Description : Delete CRUD CRA_Activite
-- ===================================================================

CREATE PROCEDURE [dbo].[CRA_Activite_del]
  (@MyID int, @ID int, @RowVersion int)
AS
BEGIN
  SET CONTEXT_INFO @MyID;
  SET NOCOUNT ON;
  DELETE FROM [dbo].[CRA_Activite] WHERE [ CRAActiviteId, CRAlibeleColId, DateBegin, DateEnd]=@ID AND [RowVersion]=@RowVersion;
  SELECT @@ROWCOUNT as [Rows Affected];
END
GO

