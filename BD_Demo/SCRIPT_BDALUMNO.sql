USE [master]
GO
/****** Object:  Database [BDAlumno]    Script Date: 07/07/2017 15:19:33 ******/
CREATE DATABASE [BDAlumno]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDAlumno', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BDAlumno.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BDAlumno_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BDAlumno_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BDAlumno] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDAlumno].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDAlumno] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDAlumno] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDAlumno] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDAlumno] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDAlumno] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDAlumno] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BDAlumno] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDAlumno] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDAlumno] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDAlumno] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDAlumno] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDAlumno] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDAlumno] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDAlumno] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDAlumno] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BDAlumno] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDAlumno] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDAlumno] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDAlumno] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDAlumno] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDAlumno] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDAlumno] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDAlumno] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BDAlumno] SET  MULTI_USER 
GO
ALTER DATABASE [BDAlumno] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDAlumno] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDAlumno] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDAlumno] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BDAlumno] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BDAlumno]
GO
/****** Object:  Table [dbo].[Alumno]    Script Date: 07/07/2017 15:19:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Alumno](
	[AlumnoKey] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](60) NOT NULL,
	[Apellidos] [varchar](60) NOT NULL,
	[Practica1] [int] NOT NULL,
	[Practica2] [int] NOT NULL,
	[Practica3] [int] NOT NULL,
	[Practica4] [int] NOT NULL,
	[MenorPractica] [int] NOT NULL,
	[ExamenParcial] [int] NOT NULL,
	[ExamenFinal] [int] NOT NULL,
	[PromedioPracticas] [decimal](8, 5) NOT NULL,
	[PromedioFinal] [decimal](8, 5) NOT NULL,
	[Estado] [tinyint] NOT NULL,
 CONSTRAINT [PK_Alumno] PRIMARY KEY CLUSTERED 
(
	[AlumnoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Alumno] ON 

INSERT [dbo].[Alumno] ([AlumnoKey], [Nombres], [Apellidos], [Practica1], [Practica2], [Practica3], [Practica4], [MenorPractica], [ExamenParcial], [ExamenFinal], [PromedioPracticas], [PromedioFinal], [Estado]) VALUES (1, N'dsf', N'fdsfd', 11, 14, 12, 13, 11, 14, 15, CAST(13.00000 AS Decimal(8, 5)), CAST(14.00000 AS Decimal(8, 5)), 1)
INSERT [dbo].[Alumno] ([AlumnoKey], [Nombres], [Apellidos], [Practica1], [Practica2], [Practica3], [Practica4], [MenorPractica], [ExamenParcial], [ExamenFinal], [PromedioPracticas], [PromedioFinal], [Estado]) VALUES (2, N'Marisco', N'Soto', 15, 18, 12, 19, 12, 11, 15, CAST(17.33333 AS Decimal(8, 5)), CAST(14.44444 AS Decimal(8, 5)), 0)
SET IDENTITY_INSERT [dbo].[Alumno] OFF
/****** Object:  StoredProcedure [dbo].[PA_ALUMNO_INSERT]    Script Date: 07/07/2017 15:19:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PA_ALUMNO_INSERT]
    @Nombres varchar(60),
    @Apellidos varchar(60),
    @Practica1 int,
    @Practica2 int,
    @Practica3 int,
    @Practica4 int,
    @MenorPractica int,
    @ExamenParcial int,
    @ExamenFinal int,
    @PromedioPracticas decimal(8,5),
    @PromedioFinal decimal(8,5),
    @Estado tinyint
AS
BEGIN
	INSERT INTO [dbo].[Alumno]
			   ([Nombres],[Apellidos],[Practica1],[Practica2],[Practica3],[Practica4],[MenorPractica],[ExamenParcial]
			   ,[ExamenFinal],[PromedioPracticas],[PromedioFinal],[Estado])
		 VALUES
			   (@Nombres,@Apellidos,@Practica1 ,@Practica2 ,@Practica3,@Practica4,@MenorPractica,@ExamenParcial ,
			    @ExamenFinal, @PromedioPracticas ,@PromedioFinal ,@Estado )
END

GO
USE [master]
GO
ALTER DATABASE [BDAlumno] SET  READ_WRITE 
GO
