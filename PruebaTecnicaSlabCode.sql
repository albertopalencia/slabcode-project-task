USE [master]
GO
/****** Object:  Database [PruebaTecnica]    Script Date: 5/10/2021 6:33:28 AM ******/
CREATE DATABASE [PruebaTecnica]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PruebaTecnica', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PruebaTecnica.mdf' , SIZE = 10240KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PruebaTecnica_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PruebaTecnica_log.ldf' , SIZE = 5120KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PruebaTecnica] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PruebaTecnica].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PruebaTecnica] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PruebaTecnica] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PruebaTecnica] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PruebaTecnica] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PruebaTecnica] SET ARITHABORT OFF 
GO
ALTER DATABASE [PruebaTecnica] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PruebaTecnica] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PruebaTecnica] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PruebaTecnica] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PruebaTecnica] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PruebaTecnica] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PruebaTecnica] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PruebaTecnica] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PruebaTecnica] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PruebaTecnica] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PruebaTecnica] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PruebaTecnica] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PruebaTecnica] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PruebaTecnica] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PruebaTecnica] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PruebaTecnica] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PruebaTecnica] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PruebaTecnica] SET RECOVERY FULL 
GO
ALTER DATABASE [PruebaTecnica] SET  MULTI_USER 
GO
ALTER DATABASE [PruebaTecnica] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PruebaTecnica] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PruebaTecnica] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PruebaTecnica] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PruebaTecnica] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PruebaTecnica] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PruebaTecnica] SET QUERY_STORE = OFF
GO
USE [PruebaTecnica]
GO
/****** Object:  Table [dbo].[Proyecto]    Script Date: 5/10/2021 6:33:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proyecto](
	[IdProyecto] [int] IDENTITY(1,1) NOT NULL,
	[NombreProyecto] [nvarchar](150) NOT NULL,
	[Descripcion] [nvarchar](400) NOT NULL,
	[FechaInicio] [date] NOT NULL,
	[FechaFinalizacion] [date] NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_Proyecto] PRIMARY KEY CLUSTERED 
(
	[IdProyecto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarea]    Script Date: 5/10/2021 6:33:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarea](
	[IdTarea] [int] IDENTITY(1,1) NOT NULL,
	[IdProyecto] [int] NOT NULL,
	[Nombre] [nvarchar](350) NOT NULL,
	[Descripcion] [nvarchar](600) NOT NULL,
	[FechaEjecucion] [date] NOT NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_Tarea] PRIMARY KEY CLUSTERED 
(
	[IdTarea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 5/10/2021 6:33:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Contrasena] [varchar](200) NOT NULL,
	[Email] [nvarchar](90) NOT NULL,
	[Activo] [int] NOT NULL,
	[Rol] [int] NOT NULL,
	[CambioContrasena] [bit] NULL,
	[FechaCambioContrasena] [datetime] NULL,
 CONSTRAINT [PK_Seguridad] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Proyecto] ON 

INSERT [dbo].[Proyecto] ([IdProyecto], [NombreProyecto], [Descripcion], [FechaInicio], [FechaFinalizacion], [Estado]) VALUES (2, N'Proyecto 2', N'Proyecto 2', CAST(N'2021-05-10' AS Date), CAST(N'2021-05-11' AS Date), 2)
INSERT [dbo].[Proyecto] ([IdProyecto], [NombreProyecto], [Descripcion], [FechaInicio], [FechaFinalizacion], [Estado]) VALUES (3, N'Proyecto 3', N'Proyecto 3', CAST(N'2021-05-10' AS Date), CAST(N'2021-05-11' AS Date), 1)
INSERT [dbo].[Proyecto] ([IdProyecto], [NombreProyecto], [Descripcion], [FechaInicio], [FechaFinalizacion], [Estado]) VALUES (4, N'Proyecto 4', N'Proyecto 4', CAST(N'2021-05-10' AS Date), CAST(N'2021-05-11' AS Date), 1)
INSERT [dbo].[Proyecto] ([IdProyecto], [NombreProyecto], [Descripcion], [FechaInicio], [FechaFinalizacion], [Estado]) VALUES (5, N'Proyecto 5', N'Proyecto 5', CAST(N'2021-05-10' AS Date), CAST(N'2021-05-11' AS Date), 1)
INSERT [dbo].[Proyecto] ([IdProyecto], [NombreProyecto], [Descripcion], [FechaInicio], [FechaFinalizacion], [Estado]) VALUES (6, N'Proyecto 6', N'Proyecto 6', CAST(N'2021-05-10' AS Date), CAST(N'2021-05-11' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Proyecto] OFF
GO
SET IDENTITY_INSERT [dbo].[Tarea] ON 

INSERT [dbo].[Tarea] ([IdTarea], [IdProyecto], [Nombre], [Descripcion], [FechaEjecucion], [Estado]) VALUES (2, 2, N'Tarea  2', N'Descripcion Tarea No. 2', CAST(N'2021-05-10' AS Date), 1)
INSERT [dbo].[Tarea] ([IdTarea], [IdProyecto], [Nombre], [Descripcion], [FechaEjecucion], [Estado]) VALUES (3, 2, N'Tarea  3', N'Descripcion Tarea No. 3', CAST(N'2021-05-10' AS Date), 1)
INSERT [dbo].[Tarea] ([IdTarea], [IdProyecto], [Nombre], [Descripcion], [FechaEjecucion], [Estado]) VALUES (4, 3, N'Tarea 4', N'Descripcion Tarea No. 4', CAST(N'2021-05-10' AS Date), 1)
INSERT [dbo].[Tarea] ([IdTarea], [IdProyecto], [Nombre], [Descripcion], [FechaEjecucion], [Estado]) VALUES (5, 5, N'Tarea  5', N'Descripcion Tarea No. 5', CAST(N'2021-05-10' AS Date), 1)
INSERT [dbo].[Tarea] ([IdTarea], [IdProyecto], [Nombre], [Descripcion], [FechaEjecucion], [Estado]) VALUES (6, 4, N'Tarea  6', N'Descripcion Tarea No. 6', CAST(N'2021-05-10' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Tarea] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([IdUsuario], [Usuario], [Contrasena], [Email], [Activo], [Rol], [CambioContrasena], [FechaCambioContrasena]) VALUES (1, N'apalencia', N'10000.H8aN5mbZ8mXGMaDtZoTgCA==.fci4LLe3GwtREAB8m98Ji189yvccZVFhzF/BRO+yZSw=', N'apalenciabenedetti@gmail.com', 1, 1, 0, NULL)
INSERT [dbo].[Usuario] ([IdUsuario], [Usuario], [Contrasena], [Email], [Activo], [Rol], [CambioContrasena], [FechaCambioContrasena]) VALUES (2, N'operador', N'10000.0EQkXOOu4keKbVPrlNOnnQ==.pcSJniNK2hH79pdZdrA80opszrCkDuFONKP2ghttcks=', N'alpabe@misena.edu.co', 1, 2, 0, NULL)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
/****** Object:  Index [IX_Proyecto_IdEstadoProyecto]    Script Date: 5/10/2021 6:33:29 AM ******/
CREATE NONCLUSTERED INDEX [IX_Proyecto_IdEstadoProyecto] ON [dbo].[Proyecto]
(
	[Estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tarea_IdEstadoTarea]    Script Date: 5/10/2021 6:33:29 AM ******/
CREATE NONCLUSTERED INDEX [IX_Tarea_IdEstadoTarea] ON [dbo].[Tarea]
(
	[Estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tarea_IdProyecto]    Script Date: 5/10/2021 6:33:29 AM ******/
CREATE NONCLUSTERED INDEX [IX_Tarea_IdProyecto] ON [dbo].[Tarea]
(
	[IdProyecto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Proyecto] ADD  CONSTRAINT [DF_Proyecto_Estado]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[Tarea] ADD  CONSTRAINT [DF_Tarea_Estado]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT ((0)) FOR [CambioContrasena]
GO
USE [master]
GO
ALTER DATABASE [PruebaTecnica] SET  READ_WRITE 
GO
