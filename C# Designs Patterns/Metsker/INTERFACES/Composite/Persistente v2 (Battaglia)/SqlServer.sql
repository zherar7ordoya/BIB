﻿USE [COMPOSITE]
GO
	/****** Object:  Table [dbo].[PERMISO]    Script Date: 04/15/2019 12:07:02 ******/
SET
	ANSI_NULLS ON
GO
SET
	QUOTED_IDENTIFIER ON
GO
SET
	ANSI_PADDING ON
GO
	CREATE TABLE [dbo].[PERMISO] (
		[ID_PERMISO] [int] NOT NULL,
		[PERMISO] [varchar](50) NOT NULL,
		CONSTRAINT [PK_PERMISO] PRIMARY KEY CLUSTERED ([ID_PERMISO] ASC) WITH (
			PAD_INDEX = OFF,
			STATISTICS_NORECOMPUTE = OFF,
			IGNORE_DUP_KEY = OFF,
			ALLOW_ROW_LOCKS = ON,
			ALLOW_PAGE_LOCKS = ON
		) ON [PRIMARY]
	) ON [PRIMARY]
GO
SET
	ANSI_PADDING OFF
GO
INSERT
	[dbo].[PERMISO] ([ID_PERMISO], [PERMISO])
VALUES
	(1, N'ALTA')
INSERT
	[dbo].[PERMISO] ([ID_PERMISO], [PERMISO])
VALUES
	(2, N'BAJA')
INSERT
	[dbo].[PERMISO] ([ID_PERMISO], [PERMISO])
VALUES
	(3, N 'MODIFICACION')
INSERT
	[dbo].[PERMISO] ([ID_PERMISO], [PERMISO])
VALUES
	(4, N 'INICIAR SESION')
INSERT
	[dbo].[PERMISO] ([ID_PERMISO], [PERMISO])
VALUES
	(5, N'VER')
INSERT
	[dbo].[PERMISO] ([ID_PERMISO], [PERMISO])
VALUES
	(100, N 'INVITADOS')
INSERT
	[dbo].[PERMISO] ([ID_PERMISO], [PERMISO])
VALUES
	(101, N'USUARIOS')
INSERT
	[dbo].[PERMISO] ([ID_PERMISO], [PERMISO])
VALUES
	(102, N 'ADMINISTRADORES')
	/****** Object:  Table [dbo].[USUARIO]    Script Date: 04/15/2019 12:07:02 ******/
SET
	ANSI_NULLS ON
GO
SET
	QUOTED_IDENTIFIER ON
GO
SET
	ANSI_PADDING ON
GO
	CREATE TABLE [dbo].[USUARIO] (
		[Id] [int] NOT NULL,
		[nombre] [varchar](50) NOT NULL,
		CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (
			PAD_INDEX = OFF,
			STATISTICS_NORECOMPUTE = OFF,
			IGNORE_DUP_KEY = OFF,
			ALLOW_ROW_LOCKS = ON,
			ALLOW_PAGE_LOCKS = ON
		) ON [PRIMARY]
	) ON [PRIMARY]
GO
SET
	ANSI_PADDING OFF
GO
INSERT
	[dbo].[USUARIO] ([Id], [nombre])
VALUES
	(1, N'a')
INSERT
	[dbo].[USUARIO] ([Id], [nombre])
VALUES
	(2, N'b')
INSERT
	[dbo].[USUARIO] ([Id], [nombre])
VALUES
	(3, N'c')
	/****** Object:  Table [dbo].[GRUPO]    Script Date: 04/15/2019 12:07:02 ******/
SET
	ANSI_NULLS ON
GO
SET
	QUOTED_IDENTIFIER ON
GO
	CREATE TABLE [dbo].[GRUPO] (
		[ID_GRUPO] [int] NOT NULL,
		[ID_HIJO] [int] NOT NULL,
		CONSTRAINT [PK_GRUPO] PRIMARY KEY CLUSTERED ([ID_GRUPO] ASC, [ID_HIJO] ASC) WITH (
			PAD_INDEX = OFF,
			STATISTICS_NORECOMPUTE = OFF,
			IGNORE_DUP_KEY = OFF,
			ALLOW_ROW_LOCKS = ON,
			ALLOW_PAGE_LOCKS = ON
		) ON [PRIMARY]
	) ON [PRIMARY]
GO
INSERT
	[dbo].[GRUPO] ([ID_GRUPO], [ID_HIJO])
VALUES
	(100, 5)
INSERT
	[dbo].[GRUPO] ([ID_GRUPO], [ID_HIJO])
VALUES
	(101, 4)
INSERT
	[dbo].[GRUPO] ([ID_GRUPO], [ID_HIJO])
VALUES
	(101, 100)
INSERT
	[dbo].[GRUPO] ([ID_GRUPO], [ID_HIJO])
VALUES
	(102, 1)
INSERT
	[dbo].[GRUPO] ([ID_GRUPO], [ID_HIJO])
VALUES
	(102, 2)
INSERT
	[dbo].[GRUPO] ([ID_GRUPO], [ID_HIJO])
VALUES
	(102, 3)
INSERT
	[dbo].[GRUPO] ([ID_GRUPO], [ID_HIJO])
VALUES
	(102, 101)
	/****** Object:  Table [dbo].[USUARIO_PERMISO]    Script Date: 04/15/2019 12:07:02 ******/
SET
	ANSI_NULLS ON
GO
SET
	QUOTED_IDENTIFIER ON
GO
	CREATE TABLE [dbo].[USUARIO_PERMISO] (
		[ID_USUARIO] [int] NOT NULL,
		[ID_PERMISO] [int] NOT NULL,
		CONSTRAINT [PK_USUARIO_PERMISO] PRIMARY KEY CLUSTERED ([ID_USUARIO] ASC, [ID_PERMISO] ASC) WITH (
			PAD_INDEX = OFF,
			STATISTICS_NORECOMPUTE = OFF,
			IGNORE_DUP_KEY = OFF,
			ALLOW_ROW_LOCKS = ON,
			ALLOW_PAGE_LOCKS = ON
		) ON [PRIMARY]
	) ON [PRIMARY]
GO
INSERT
	[dbo].[USUARIO_PERMISO] ([ID_USUARIO], [ID_PERMISO])
VALUES
	(1, 100)
INSERT
	[dbo].[USUARIO_PERMISO] ([ID_USUARIO], [ID_PERMISO])
VALUES
	(2, 101)
INSERT
	[dbo].[USUARIO_PERMISO] ([ID_USUARIO], [ID_PERMISO])
VALUES
	(3, 102)
	/****** Object:  StoredProcedure [dbo].[USUARIO_PERMISO_LISTAR]    Script Date: 04/15/2019 12:07:04 ******/
SET
	ANSI_NULLS ON
GO
SET
	QUOTED_IDENTIFIER ON
GO
	CREATE PROC [dbo].[USUARIO_PERMISO_LISTAR] @id INT AS BEGIN
SELECT
	*
FROM
	PERMISO p
	INNER JOIN USUARIO_PERMISO u ON p.ID_PERMISO = u.ID_PERMISO
WHERE
	u.ID_USUARIO = @id
END
GO
	/****** Object:  StoredProcedure [dbo].[PERMISO_LISTAR]    Script Date: 04/15/2019 12:07:04 ******/
SET
	ANSI_NULLS ON
GO
SET
	QUOTED_IDENTIFIER ON
GO
	CREATE PROC [dbo].[PERMISO_LISTAR] AS BEGIN
SELECT
	DISTINCT p.ID_PERMISO,
	p.PERMISO,
	'TIPO' = CASE
		WHEN G.ID_GRUPO IS NULL THEN 'P'
		ELSE 'G'
	END
FROM
	PERMISO p
	LEFT JOIN GRUPO G ON p.ID_PERMISO = g.ID_GRUPO
END
GO
	/****** Object:  StoredProcedure [dbo].[GRUPO_LISTAR]    Script Date: 04/15/2019 12:07:04 ******/
SET
	ANSI_NULLS ON
GO
SET
	QUOTED_IDENTIFIER ON
GO
	CREATE PROC [dbo].[GRUPO_LISTAR] AS BEGIN
SELECT
	G.ID_GRUPO,
	P.ID_PERMISO,
	P.PERMISO
FROM
	GRUPO G
	INNER JOIN PERMISO p ON G.ID_HIJO = p.ID_PERMISO
END
GO
	/****** Object:  ForeignKey [FK_GRUPO_PERMISO]    Script Date: 04/15/2019 12:07:02 ******/
ALTER TABLE
	[dbo].[GRUPO] WITH CHECK
ADD
	CONSTRAINT [FK_GRUPO_PERMISO] FOREIGN KEY ([ID_GRUPO]) REFERENCES [dbo].[PERMISO]([ID_PERMISO])
GO
ALTER TABLE
	[dbo].[GRUPO] CHECK CONSTRAINT [FK_GRUPO_PERMISO]
GO
	/****** Object:  ForeignKey [FK_GRUPO_PERMISO1]    Script Date: 04/15/2019 12:07:02 ******/
ALTER TABLE
	[dbo].[GRUPO] WITH CHECK
ADD
	CONSTRAINT [FK_GRUPO_PERMISO1] FOREIGN KEY ([ID_HIJO]) REFERENCES [dbo].[PERMISO]([ID_PERMISO])
GO
ALTER TABLE
	[dbo].[GRUPO] CHECK CONSTRAINT [FK_GRUPO_PERMISO1]
GO
	/****** Object:  ForeignKey [FK_USUARIO_PERMISO_PERMISO]    Script Date: 04/15/2019 12:07:02 ******/
ALTER TABLE
	[dbo].[USUARIO_PERMISO] WITH CHECK
ADD
	CONSTRAINT [FK_USUARIO_PERMISO_PERMISO] FOREIGN KEY ([ID_PERMISO]) REFERENCES [dbo].[PERMISO]([ID_PERMISO])
GO
ALTER TABLE
	[dbo].[USUARIO_PERMISO] CHECK CONSTRAINT [FK_USUARIO_PERMISO_PERMISO]
GO
	/****** Object:  ForeignKey [FK_USUARIO_PERMISO_USUARIO]    Script Date: 04/15/2019 12:07:02 ******/
ALTER TABLE
	[dbo].[USUARIO_PERMISO] WITH CHECK
ADD
	CONSTRAINT [FK_USUARIO_PERMISO_USUARIO] FOREIGN KEY ([ID_USUARIO]) REFERENCES [dbo].[USUARIO]([Id])
GO
ALTER TABLE
	[dbo].[USUARIO_PERMISO] CHECK CONSTRAINT [FK_USUARIO_PERMISO_USUARIO]
GO