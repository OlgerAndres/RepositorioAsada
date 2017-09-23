USE [ASADA]
GO
/****** Object:  Table [dbo].[Abonados]    Script Date: 09/15/2017 17:45:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Abonados](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[PrimerApellido] [nvarchar](50) NOT NULL,
	[SegundoApellido] [nvarchar](50) NOT NULL,
	[Cedula] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](50) NOT NULL,
	[Celular] [nvarchar](50) NULL,
	[Direccion] [nvarchar](225) NOT NULL,
	[Correo] [nvarchar](100) NULL,
	[NumeroAbonado] [nvarchar](100) NOT NULL,
	[Afiliado] [bit] NOT NULL,
 CONSTRAINT [PK_Abonados] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 09/15/2017 17:45:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] NOT NULL,
	[Usuario] [nvarchar](50) NOT NULL,
	[Clave] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarifas]    Script Date: 09/15/2017 17:45:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarifas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Precio] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_Tarifa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sectores]    Script Date: 09/15/2017 17:45:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sectores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Sectores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Previstas]    Script Date: 09/15/2017 17:45:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Previstas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdAbonado] [int] NOT NULL,
	[IdTarifa] [int] NOT NULL,
	[IdSector] [int] NOT NULL,
	[Direccion] [nvarchar](225) NOT NULL,
	[FolioReal] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Previstas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Previstas_Abonados]    Script Date: 09/15/2017 17:45:07 ******/
ALTER TABLE [dbo].[Previstas]  WITH CHECK ADD  CONSTRAINT [FK_Previstas_Abonados] FOREIGN KEY([IdAbonado])
REFERENCES [dbo].[Abonados] ([Id])
GO
ALTER TABLE [dbo].[Previstas] CHECK CONSTRAINT [FK_Previstas_Abonados]
GO
/****** Object:  ForeignKey [FK_Previstas_Sectores]    Script Date: 09/15/2017 17:45:07 ******/
ALTER TABLE [dbo].[Previstas]  WITH CHECK ADD  CONSTRAINT [FK_Previstas_Sectores] FOREIGN KEY([IdSector])
REFERENCES [dbo].[Sectores] ([Id])
GO
ALTER TABLE [dbo].[Previstas] CHECK CONSTRAINT [FK_Previstas_Sectores]
GO
/****** Object:  ForeignKey [FK_Previstas_Tarifas]    Script Date: 09/15/2017 17:45:07 ******/
ALTER TABLE [dbo].[Previstas]  WITH CHECK ADD  CONSTRAINT [FK_Previstas_Tarifas] FOREIGN KEY([IdSector])
REFERENCES [dbo].[Tarifas] ([Id])
GO
ALTER TABLE [dbo].[Previstas] CHECK CONSTRAINT [FK_Previstas_Tarifas]
GO
