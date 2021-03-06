USE [master]
GO
/****** Object:  Database [DemoDB]    Script Date: 5/04/2016 2:31:30 p. m. ******/
CREATE DATABASE [DemoDB] ON  PRIMARY 
( NAME = N'DemoDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\DemoDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DemoDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\DemoDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DemoDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DemoDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DemoDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DemoDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DemoDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DemoDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DemoDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DemoDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DemoDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DemoDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DemoDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DemoDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DemoDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DemoDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DemoDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DemoDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DemoDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DemoDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DemoDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DemoDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DemoDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DemoDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DemoDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DemoDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DemoDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DemoDB] SET  MULTI_USER 
GO
ALTER DATABASE [DemoDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DemoDB] SET DB_CHAINING OFF 
GO
USE [DemoDB]
GO
/****** Object:  Table [dbo].[TB_CURSO]    Script Date: 5/04/2016 2:31:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_CURSO](
	[id] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[horasCredito] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_ESTUDIANTE]    Script Date: 5/04/2016 2:31:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_ESTUDIANTE](
	[id] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[fechaNacimiento] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TB_ESTUDIANTEXCURSO]    Script Date: 5/04/2016 2:31:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TB_ESTUDIANTEXCURSO](
	[estudiante_id] [int] NOT NULL,
	[curso_id] [int] NOT NULL,
	[semestre] [varchar](10) NULL,
	[añoAcademico] [int] NULL,
	[grado] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[TB_ESTUDIANTEXCURSO]  WITH CHECK ADD FOREIGN KEY([curso_id])
REFERENCES [dbo].[TB_CURSO] ([id])
GO
ALTER TABLE [dbo].[TB_ESTUDIANTEXCURSO]  WITH CHECK ADD FOREIGN KEY([estudiante_id])
REFERENCES [dbo].[TB_ESTUDIANTE] ([id])
GO
USE [master]
GO
ALTER DATABASE [DemoDB] SET  READ_WRITE 
GO
