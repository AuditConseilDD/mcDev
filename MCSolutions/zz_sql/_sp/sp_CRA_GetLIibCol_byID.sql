CREATE PROCEDURE sp_CRA_GetLIibCol_byID
(    
	@cratypeid	INT = NULL
)    
AS    
BEGIN

	SET NOCOUNT ON;

	DECLARE @COMPTE INT = 0

	

	SELECT A.[Id]
		, A.[LibShort]
		, A.[LibLong]
		, A.[Type]
		, A.[IsActive]
		, A.[CreationDate]
		, A.[DeletionDate]
	FROM [dbo].[CRA_LibeleCol] A
	INNER JOIN [dbo].[CRA_Definition] D ON D.CRALibeleColId = A.Id
	WHERE 
		(@cratypeid IS NULL OR  D.CRATypeId = @cratypeid)
	
END
