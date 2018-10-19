﻿SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CRA](
	[CRAId] INT IDENTITY(1,1) NOT NULL,
	[LIBELLE] [nvarchar](max) NULL,
	[NUMCRA] [nvarchar](max) NULL,
	[MOIS] [nvarchar](max) NULL,
	[NBTOTALJOURS] INT NOT NULL,
	[FK_IDCONSULTANT] INT NULL,
	[FK_IDCLIENT] INT NULL,
	[LIB_CLIENT] [nvarchar](max) NULL,
	[FK_IDRESPONSABLE] INT NULL,
	[LIB_RESPONSABLE] [nvarchar](max) NULL,
	[FK_IDSTATUT] INT NULL,
	[SIGNECONSULTANT] [bit] NULL,
	[DTSIGNECONSULTANT] [datetime] NULL,
	[SIGNECLIENTFINAL] [bit] NULL,
	[DTSIGNECLIENTFINAL] [datetime] NULL,
	[SIGNEAGENT] [bit] NULL,
	[DTSIGNEAGENT] [datetime] NULL,
	[AddedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[IPAddress] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.TB_CRA] PRIMARY KEY CLUSTERED 
(
	[CRAId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

