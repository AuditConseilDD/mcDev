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
-- Description : Upsert CRUD CRA_LibeleCol
-- ===================================================================

CREATE PROCEDURE [dbo].[sp_CRA_LibeleCol_List]
AS
BEGIN
	SELECT [Id]
		,([LibShort] + ' - ' + [Type]) AS 'LibShort'
		,[LibLong]
		,[Type]
		,[IsActive]
		,[CreationDate]
		,[DeletionDate]
	FROM [dbo].[CRA_LibeleCol]
	WHERE 
		IsActive = 1
	ORDER BY Id ASC;
END
GO

CREATE PROCEDURE [dbo].[sp_CRA_LibeleCol_sel]
  (@craId INT)
AS
BEGIN
	SELECT	A.[Id]
      , MAX(A.[LibShort]) AS LibShort
      , MAX(A.[LibLong]) AS LibLong
      , MAX(A.[Type]) AS Type
      , MAX(CAST(A.[IsActive] as int))	AS IsActive
      , MAX(A.[CreationDate]) AS CreationDate
      , MAX(A.[DeletionDate]) AS DeletionDate
	FROM [dbo].[CRA_LibeleCol] A INNER JOIN [dbo].[CRA_ActiviteDetail] B ON B.CRAlibeleColId = A.Id
	WHERE 
		CRAActiviteId = @craId
	AND	IsActive = 1
	GROUP BY A.Id
	ORDER BY LibShort ASC;
	--ORDER BY A.Id ASsC;
END
GO


CREATE PROCEDURE [dbo].[sp_CRA_ActiviteDetail_sel_NEW]
(
	@craId INT
)
AS
BEGIN

	DECLARE 
		@compte 	AS INT
	,	@j			AS INT
	,	@sqlScript 	AS NVARCHAR(MAX)
	,	@tmpTable 	AS NVARCHAR(20)
	,	@Columns 	AS NVARCHAR(500)

	SET @compte = 1
	SELECT @compte = COUNT(*)-- AS CMPT
	FROM (
		SELECT A.LibShort, COUNT(*) AS NB
		FROM [dbo].[CRA_LibeleCol] A 
		INNER JOIN [dbo].[CRA_ActiviteDetail] B ON B.CRAlibeleColId = A.Id
		GROUP BY A.LibShort
	) T

	SELECT @Columns = (STUFF(STUFF((SELECT '], [' + A.LibShort 
	FROM [dbo].[CRA_LibeleCol] A 
	INNER JOIN [dbo].[CRA_ActiviteDetail] B ON B.CRAlibeleColId = A.Id
	GROUP BY A.LibShort
	ORDER BY A.LibShort ASC
	FOR XML PATH('')),1,1,''), 1, 1, '')) + ']'

	PRINT @Columns
	PRINT '@compte >> ' + CONVERT(VARCHAR(10), @compte)

	SET @tmpTable = '#yourtable'
	SET @sqlScript = 'CREATE table ' + @tmpTable + ' (DATEBEGIN DATIME'

	PRINT '||@compte >> ' + CONVERT(VARCHAR(10), @compte)
	SET @j = 1
	WHILE @compte >= 0
	BEGIN
		SET @sqlScript = @sqlScript + ', COL_00' + CONVERT(VARCHAR(10), @j) + ' VARCHAR(100)'

		SET @compte = @compte - @j
		SET @j = @j + 1
	END
	SET @sqlScript = @sqlScript + ');'
	PRINT @sqlScript



	SET @sqlScript = 
	N'SELECT * 
	FROM ( 
		SELECT A.Id, A.Id AS ID2, A.LibShort, B.DateBegin, B.Quantity 
		FROM [dbo].[CRA_LibeleCol] A 
		INNER JOIN [dbo].[CRA_ActiviteDetail] B ON B.CRAlibeleColId = A.Id 
		) p 
	PIVOT 
	( 
		MAX(Quantity) FOR LibShort IN (' + @Columns + ') 
	) as revpiv 
	order by DateBegin '
	PRINT @sqlScript
	EXEC(@sqlScript)
	--EXECUTE  (@sqlScript)


END
GO