USE [master]
GO
/****** Object:  Database [ACME]    Script Date: 27/03/2022 05:31:10 p. m. ******/
CREATE DATABASE [ACME]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ACME', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ACME.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ACME_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ACME_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ACME] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ACME].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ACME] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ACME] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ACME] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ACME] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ACME] SET ARITHABORT OFF 
GO
ALTER DATABASE [ACME] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ACME] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ACME] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ACME] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ACME] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ACME] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ACME] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ACME] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ACME] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ACME] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ACME] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ACME] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ACME] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ACME] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ACME] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ACME] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ACME] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ACME] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ACME] SET  MULTI_USER 
GO
ALTER DATABASE [ACME] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ACME] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ACME] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ACME] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ACME] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ACME] SET QUERY_STORE = OFF
GO
USE [ACME]
GO
/****** Object:  Table [dbo].[campos]    Script Date: 27/03/2022 05:31:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[campos](
	[id_campo] [int] IDENTITY(1,1) NOT NULL,
	[id_encuesta] [int] NOT NULL,
	[nombre] [varchar](256) NOT NULL,
	[titulo] [varchar](50) NOT NULL,
	[requerido] [int] NOT NULL,
	[tipo] [int] NOT NULL,
 CONSTRAINT [PK_campos] PRIMARY KEY CLUSTERED 
(
	[id_campo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[encuestas]    Script Date: 27/03/2022 05:31:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[encuestas](
	[id_encuesta] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](100) NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_encuestas] PRIMARY KEY CLUSTERED 
(
	[id_encuesta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[campos] ON 
GO
INSERT [dbo].[campos] ([id_campo], [id_encuesta], [nombre], [titulo], [requerido], [tipo]) VALUES (2, 1, N'test', N'test', 1, 1)
GO
INSERT [dbo].[campos] ([id_campo], [id_encuesta], [nombre], [titulo], [requerido], [tipo]) VALUES (3, 1, N'test2', N'test2', 1, 1)
GO
INSERT [dbo].[campos] ([id_campo], [id_encuesta], [nombre], [titulo], [requerido], [tipo]) VALUES (4, 3, N'nuevo1', N'titulo nuevo 1', 0, 0)
GO
INSERT [dbo].[campos] ([id_campo], [id_encuesta], [nombre], [titulo], [requerido], [tipo]) VALUES (5, 3, N'nuevo2', N'titulo nuevo 2', 1, 1)
GO
INSERT [dbo].[campos] ([id_campo], [id_encuesta], [nombre], [titulo], [requerido], [tipo]) VALUES (7, 5, N'nombre', N'ingrese su nombre', 1, 1)
GO
INSERT [dbo].[campos] ([id_campo], [id_encuesta], [nombre], [titulo], [requerido], [tipo]) VALUES (8, 5, N'telefono', N'ingrese su telefono', 2, 2)
GO
SET IDENTITY_INSERT [dbo].[campos] OFF
GO
SET IDENTITY_INSERT [dbo].[encuestas] ON 
GO
INSERT [dbo].[encuestas] ([id_encuesta], [descripcion], [nombre]) VALUES (1, N'Encuesta de prueba', N'Ejemplo de encuesta')
GO
INSERT [dbo].[encuestas] ([id_encuesta], [descripcion], [nombre]) VALUES (2, N'Prueba de insercion', N'Nueva encuesta')
GO
INSERT [dbo].[encuestas] ([id_encuesta], [descripcion], [nombre]) VALUES (3, N'Prueba de insercion', N'Nueva encuesta')
GO
INSERT [dbo].[encuestas] ([id_encuesta], [descripcion], [nombre]) VALUES (5, N'datos de usuarios', N'datos')
GO
SET IDENTITY_INSERT [dbo].[encuestas] OFF
GO
ALTER TABLE [dbo].[campos]  WITH CHECK ADD  CONSTRAINT [FK_Campos_Encuesta] FOREIGN KEY([id_encuesta])
REFERENCES [dbo].[encuestas] ([id_encuesta])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[campos] CHECK CONSTRAINT [FK_Campos_Encuesta]
GO
USE [master]
GO
ALTER DATABASE [ACME] SET  READ_WRITE 
GO
