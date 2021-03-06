﻿CREATE PROCEDURE sp_CRA_InsertUpdate    
(    
	@CRAID INT = NULL,
	@LIBELLE   NVARCHAR(MAX) = NULL,
	@NUMCRA   NVARCHAR(MAX) = NULL,
	@MOIS   NVARCHAR(MAX) = NULL,
	@NBTOTALJOURS   INT,
	@FK_IDCONSULTANT   INT = NULL,
	@FK_IDCLIENT   INT = NULL,
	@LIB_CLIENT   NVARCHAR(MAX) = NULL,
	@FK_IDRESPONSABLE   INT = NULL,
	@LIB_RESPONSABLE   NVARCHAR(MAX) = NULL,
	@FK_IDSTATUT   INT = NULL,
	@SIGNECONSULTANT   BIT = NULL,
	@DTSIGNECONSULTANT   DATETIME = NULL,
	@SIGNECLIENTFINAL   BIT = NULL,
	@DTSIGNECLIENTFINAL   DATETIME = NULL,
	@SIGNEAGENT   BIT = NULL,
	@DTSIGNEAGENT   DATETIME = NULL,
	@ADDEDDATE   DATETIME = NULL,
	@MODIFIEDDATE   DATETIME = NULL,
	@IPADDRESS   NVARCHAR(MAX) = NULL,    
	@ACTION VARCHAR(10)   
)    
AS    
BEGIN

	SET NOCOUNT ON;

	DECLARE @COMPTE INT = 0

	IF @ACTION='INSERT'    
	BEGIN

		PRINT '>> ' + @ACTION
	
		INSERT INTO [DBO].[CRA] ([LIBELLE], [NUMCRA], [MOIS], [NBTOTALJOURS], [FK_IDCONSULTANT], [FK_IDCLIENT], [LIB_CLIENT], [FK_IDRESPONSABLE], [LIB_RESPONSABLE], [FK_IDSTATUT], [SIGNECONSULTANT], [DTSIGNECONSULTANT], [SIGNECLIENTFINAL], [DTSIGNECLIENTFINAL], [SIGNEAGENT], [DTSIGNEAGENT], [ADDEDDATE], [MODIFIEDDATE], [IPADDRESS])
		VALUES (@LIBELLE, @NUMCRA, @MOIS, @NBTOTALJOURS, @FK_IDCONSULTANT, @FK_IDCLIENT, @LIB_CLIENT, @FK_IDRESPONSABLE, @LIB_RESPONSABLE, @FK_IDSTATUT, @SIGNECONSULTANT, @DTSIGNECONSULTANT, @SIGNECLIENTFINAL, @DTSIGNECLIENTFINAL, @SIGNEAGENT, @DTSIGNEAGENT, @ADDEDDATE, @MODIFIEDDATE, @IPADDRESS)

		SELECT @compte  = @@ROWCOUNT
	END    
	IF @ACTION='UPDATE'
	BEGIN

		PRINT '>> ' + @ACTION

		UPDATE [DBO].[CRA] 
		SET 
			[LIBELLE] 				= @LIBELLE, 
			[NUMCRA] 				= @NUMCRA, 
			[MOIS] 				= @MOIS, 
			[NBTOTALJOURS] 		= @NBTOTALJOURS, 
			[FK_IDCONSULTANT] 		= @FK_IDCONSULTANT, 
			[FK_IDCLIENT] 			= @FK_IDCLIENT, 
			[LIB_CLIENT] 			= @LIB_CLIENT, 
			[FK_IDRESPONSABLE] 	= @FK_IDRESPONSABLE, 
			[LIB_RESPONSABLE] 		= @LIB_RESPONSABLE, 
			[FK_IDSTATUT] 			= @FK_IDSTATUT, 
			[SIGNECONSULTANT] 		= @SIGNECONSULTANT, 
			[DTSIGNECONSULTANT] 	= @DTSIGNECONSULTANT, 
			[SIGNECLIENTFINAL] 	= @SIGNECLIENTFINAL, 
			[DTSIGNECLIENTFINAL] 	= @DTSIGNECLIENTFINAL,
			[SIGNEAGENT] 			= @SIGNEAGENT, 
			[DTSIGNEAGENT] 		= @DTSIGNEAGENT, 
			[ADDEDDATE] 			= @ADDEDDATE, 
			[MODIFIEDDATE] 		= @MODIFIEDDATE, 
			[IPADDRESS] 			= @IPADDRESS
		WHERE
			CRAID = @CRAID

		SELECT @compte  = @@ROWCOUNT
	END      
END