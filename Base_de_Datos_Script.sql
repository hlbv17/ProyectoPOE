USE [master]
GO
/****** Object:  Database [Dentalig]    Script Date: 13/09/2021 17:31:21 ******/
CREATE DATABASE [Dentalig]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Dentalig', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Dentalig.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Dentalig_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Dentalig_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Dentalig] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Dentalig].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Dentalig] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Dentalig] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Dentalig] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Dentalig] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Dentalig] SET ARITHABORT OFF 
GO
ALTER DATABASE [Dentalig] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Dentalig] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Dentalig] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Dentalig] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Dentalig] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Dentalig] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Dentalig] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Dentalig] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Dentalig] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Dentalig] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Dentalig] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Dentalig] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Dentalig] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Dentalig] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Dentalig] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Dentalig] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Dentalig] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Dentalig] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Dentalig] SET  MULTI_USER 
GO
ALTER DATABASE [Dentalig] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Dentalig] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Dentalig] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Dentalig] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Dentalig] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Dentalig] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Dentalig] SET QUERY_STORE = OFF
GO
USE [Dentalig]
GO
/****** Object:  Table [dbo].[Antecedentes]    Script Date: 13/09/2021 17:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Antecedentes](
	[id_antecedentes] [int] IDENTITY(1,1) NOT NULL,
	[antecedenteFamiliar] [varchar](500) NOT NULL,
	[antecedentePersonal] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Antecedentes] PRIMARY KEY CLUSTERED 
(
	[id_antecedentes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AtencionMedica]    Script Date: 13/09/2021 17:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AtencionMedica](
	[id_atencionMedica] [int] IDENTITY(1,1) NOT NULL,
	[id_historiaClinica] [int] NOT NULL,
	[id_cita] [int] NOT NULL,
	[id_piezaDental] [int] NOT NULL,
	[motivoConsulta] [varchar](300) NOT NULL,
	[diagnostico] [varchar](300) NOT NULL,
 CONSTRAINT [PK_AtencionMedica] PRIMARY KEY CLUSTERED 
(
	[id_atencionMedica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cita]    Script Date: 13/09/2021 17:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cita](
	[id_cita] [int] IDENTITY(1,1) NOT NULL,
	[id_paciente] [int] NOT NULL,
	[id_odontologo] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[hora] [time](0) NOT NULL,
 CONSTRAINT [PK_Cita] PRIMARY KEY CLUSTERED 
(
	[id_cita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CuadrantePieza]    Script Date: 13/09/2021 17:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuadrantePieza](
	[id_cuadrantePieza] [int] NOT NULL,
	[nombreCuadrante] [varchar](25) NOT NULL,
 CONSTRAINT [PK_CuadrantePieza] PRIMARY KEY CLUSTERED 
(
	[id_cuadrantePieza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dias]    Script Date: 13/09/2021 17:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dias](
	[id_dias] [int] NOT NULL,
	[dia] [varchar](50) NOT NULL,
	[horaEntrada] [time](0) NOT NULL,
	[horaSalida] [time](0) NOT NULL,
 CONSTRAINT [PK_Dias] PRIMARY KEY CLUSTERED 
(
	[id_dias] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Especialidad]    Script Date: 13/09/2021 17:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especialidad](
	[id_especialidad] [int] NOT NULL,
	[especialidad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Especialidad] PRIMARY KEY CLUSTERED 
(
	[id_especialidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EtapaEdad]    Script Date: 13/09/2021 17:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EtapaEdad](
	[id_etapaEdad] [int] NOT NULL,
	[etapa] [varchar](50) NOT NULL,
	[edadMin] [int] NOT NULL,
	[edadMax] [int] NOT NULL,
 CONSTRAINT [PK_EtapaEdad] PRIMARY KEY CLUSTERED 
(
	[id_etapaEdad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistoriaClinica]    Script Date: 13/09/2021 17:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistoriaClinica](
	[id_historiaClinica] [int] IDENTITY(1,1) NOT NULL,
	[id_paciente] [int] NOT NULL,
	[id_antecedentes] [int] NOT NULL,
 CONSTRAINT [PK_HistoriaClinica] PRIMARY KEY CLUSTERED 
(
	[id_historiaClinica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Horario]    Script Date: 13/09/2021 17:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horario](
	[id_horario] [int] NOT NULL,
	[tipo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Horario] PRIMARY KEY CLUSTERED 
(
	[id_horario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HorarioDias]    Script Date: 13/09/2021 17:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HorarioDias](
	[id_horario] [int] NOT NULL,
	[id_dias] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NombrePieza]    Script Date: 13/09/2021 17:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NombrePieza](
	[id_nombrePieza] [int] NOT NULL,
	[nombrePieza] [varchar](25) NOT NULL,
 CONSTRAINT [PK_NombrePieza] PRIMARY KEY CLUSTERED 
(
	[id_nombrePieza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Odontologo]    Script Date: 13/09/2021 17:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Odontologo](
	[id_odontologo] [int] NOT NULL,
	[id_horario] [int] NOT NULL,
	[id_especialidad] [int] NOT NULL,
	[consultorio] [int] NULL,
 CONSTRAINT [PK_Odontologo] PRIMARY KEY CLUSTERED 
(
	[id_odontologo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paciente]    Script Date: 13/09/2021 17:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paciente](
	[id_paciente] [int] NOT NULL,
	[discapacidad] [varchar](50) NOT NULL,
	[id_etapaEdad] [int] NOT NULL,
 CONSTRAINT [PK_Paciente] PRIMARY KEY CLUSTERED 
(
	[id_paciente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 13/09/2021 17:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[id_persona] [int] IDENTITY(1,1) NOT NULL,
	[cedula] [varchar](10) NOT NULL,
	[id_sexo] [char](1) NOT NULL,
	[nombres] [varchar](150) NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[telefono] [varchar](10) NOT NULL,
	[correo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[id_persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PiezaDental]    Script Date: 13/09/2021 17:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PiezaDental](
	[id_piezaDental] [int] NOT NULL,
	[id_cuadrantePieza] [int] NOT NULL,
	[id_nombrePieza] [int] NOT NULL,
 CONSTRAINT [PK_PiezaDental] PRIMARY KEY CLUSTERED 
(
	[id_piezaDental] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sexo]    Script Date: 13/09/2021 17:31:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sexo](
	[id_sexo] [char](1) NOT NULL,
	[sexo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Sexo] PRIMARY KEY CLUSTERED 
(
	[id_sexo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Antecedentes] ON 

INSERT [dbo].[Antecedentes] ([id_antecedentes], [antecedenteFamiliar], [antecedentePersonal]) VALUES (1, N'No tiene.', N'No tiene.')
INSERT [dbo].[Antecedentes] ([id_antecedentes], [antecedenteFamiliar], [antecedentePersonal]) VALUES (2, N'No tiene. ', N'Sí tiene.')
INSERT [dbo].[Antecedentes] ([id_antecedentes], [antecedenteFamiliar], [antecedentePersonal]) VALUES (3, N'Sí tiene. ', N'Sí tiene.')
INSERT [dbo].[Antecedentes] ([id_antecedentes], [antecedenteFamiliar], [antecedentePersonal]) VALUES (4, N'Sí tiene. ', N'No tiene.')
INSERT [dbo].[Antecedentes] ([id_antecedentes], [antecedenteFamiliar], [antecedentePersonal]) VALUES (5, N'Texto', N'Texto')
INSERT [dbo].[Antecedentes] ([id_antecedentes], [antecedenteFamiliar], [antecedentePersonal]) VALUES (6, N'Texto', N'Texto')
SET IDENTITY_INSERT [dbo].[Antecedentes] OFF
GO
SET IDENTITY_INSERT [dbo].[AtencionMedica] ON 

INSERT [dbo].[AtencionMedica] ([id_atencionMedica], [id_historiaClinica], [id_cita], [id_piezaDental], [motivoConsulta], [diagnostico]) VALUES (37, 6, 23, 34, N'cccccccccccccc', N'ccccccccccccccccc')
INSERT [dbo].[AtencionMedica] ([id_atencionMedica], [id_historiaClinica], [id_cita], [id_piezaDental], [motivoConsulta], [diagnostico]) VALUES (38, 2, 16, 46, N'dddddddddddddd', N'ddddddddddddddddddddd')
INSERT [dbo].[AtencionMedica] ([id_atencionMedica], [id_historiaClinica], [id_cita], [id_piezaDental], [motivoConsulta], [diagnostico]) VALUES (39, 2, 21, 26, N'eeeeeeeeeeeee', N'eeeeeeeeeeeeee')
INSERT [dbo].[AtencionMedica] ([id_atencionMedica], [id_historiaClinica], [id_cita], [id_piezaDental], [motivoConsulta], [diagnostico]) VALUES (41, 6, 20, 16, N'gggggggggggggg', N'ggggggggggggggg')
INSERT [dbo].[AtencionMedica] ([id_atencionMedica], [id_historiaClinica], [id_cita], [id_piezaDental], [motivoConsulta], [diagnostico]) VALUES (42, 4, 18, 35, N'hhhhhhhhhhhhhh', N'hhhhhhhhhhhhhhh')
INSERT [dbo].[AtencionMedica] ([id_atencionMedica], [id_historiaClinica], [id_cita], [id_piezaDental], [motivoConsulta], [diagnostico]) VALUES (43, 5, 19, 25, N'zzzzzzzzzzzz', N'zzzzzzzzzzzzzzz')
INSERT [dbo].[AtencionMedica] ([id_atencionMedica], [id_historiaClinica], [id_cita], [id_piezaDental], [motivoConsulta], [diagnostico]) VALUES (1025, 1, 15, 13, N'asdf', N'asdf')
SET IDENTITY_INSERT [dbo].[AtencionMedica] OFF
GO
SET IDENTITY_INSERT [dbo].[Cita] ON 

INSERT [dbo].[Cita] ([id_cita], [id_paciente], [id_odontologo], [fecha], [hora]) VALUES (15, 67, 61, CAST(N'2021-08-16' AS Date), CAST(N'07:00:00' AS Time))
INSERT [dbo].[Cita] ([id_cita], [id_paciente], [id_odontologo], [fecha], [hora]) VALUES (16, 68, 62, CAST(N'2021-08-17' AS Date), CAST(N'12:00:00' AS Time))
INSERT [dbo].[Cita] ([id_cita], [id_paciente], [id_odontologo], [fecha], [hora]) VALUES (17, 69, 63, CAST(N'2021-08-19' AS Date), CAST(N'14:00:00' AS Time))
INSERT [dbo].[Cita] ([id_cita], [id_paciente], [id_odontologo], [fecha], [hora]) VALUES (18, 70, 64, CAST(N'2021-08-23' AS Date), CAST(N'16:00:00' AS Time))
INSERT [dbo].[Cita] ([id_cita], [id_paciente], [id_odontologo], [fecha], [hora]) VALUES (19, 71, 65, CAST(N'2021-08-24' AS Date), CAST(N'16:00:00' AS Time))
INSERT [dbo].[Cita] ([id_cita], [id_paciente], [id_odontologo], [fecha], [hora]) VALUES (20, 72, 66, CAST(N'2021-08-20' AS Date), CAST(N'13:00:00' AS Time))
INSERT [dbo].[Cita] ([id_cita], [id_paciente], [id_odontologo], [fecha], [hora]) VALUES (21, 68, 61, CAST(N'2021-08-16' AS Date), CAST(N'08:00:00' AS Time))
INSERT [dbo].[Cita] ([id_cita], [id_paciente], [id_odontologo], [fecha], [hora]) VALUES (22, 69, 62, CAST(N'2021-08-16' AS Date), CAST(N'07:00:00' AS Time))
INSERT [dbo].[Cita] ([id_cita], [id_paciente], [id_odontologo], [fecha], [hora]) VALUES (23, 72, 65, CAST(N'2021-08-17' AS Date), CAST(N'07:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[Cita] OFF
GO
INSERT [dbo].[CuadrantePieza] ([id_cuadrantePieza], [nombreCuadrante]) VALUES (1, N'Superior Derecho')
INSERT [dbo].[CuadrantePieza] ([id_cuadrantePieza], [nombreCuadrante]) VALUES (2, N'Superior Izquierdo')
INSERT [dbo].[CuadrantePieza] ([id_cuadrantePieza], [nombreCuadrante]) VALUES (3, N'Inferior Izquierdo')
INSERT [dbo].[CuadrantePieza] ([id_cuadrantePieza], [nombreCuadrante]) VALUES (4, N'Inferior Derecho')
GO
INSERT [dbo].[Dias] ([id_dias], [dia], [horaEntrada], [horaSalida]) VALUES (85869, N'Lunes', CAST(N'07:00:00' AS Time), CAST(N'15:00:00' AS Time))
INSERT [dbo].[Dias] ([id_dias], [dia], [horaEntrada], [horaSalida]) VALUES (85870, N'Martes', CAST(N'07:00:00' AS Time), CAST(N'15:00:00' AS Time))
INSERT [dbo].[Dias] ([id_dias], [dia], [horaEntrada], [horaSalida]) VALUES (85871, N'Miercoles', CAST(N'07:00:00' AS Time), CAST(N'15:00:00' AS Time))
INSERT [dbo].[Dias] ([id_dias], [dia], [horaEntrada], [horaSalida]) VALUES (85872, N'Jueves', CAST(N'07:00:00' AS Time), CAST(N'15:00:00' AS Time))
INSERT [dbo].[Dias] ([id_dias], [dia], [horaEntrada], [horaSalida]) VALUES (85873, N'Viernes', CAST(N'07:00:00' AS Time), CAST(N'15:00:00' AS Time))
INSERT [dbo].[Dias] ([id_dias], [dia], [horaEntrada], [horaSalida]) VALUES (85874, N'Sábado', CAST(N'08:00:00' AS Time), CAST(N'14:00:00' AS Time))
INSERT [dbo].[Dias] ([id_dias], [dia], [horaEntrada], [horaSalida]) VALUES (85875, N'Lunes', CAST(N'12:00:00' AS Time), CAST(N'17:00:00' AS Time))
INSERT [dbo].[Dias] ([id_dias], [dia], [horaEntrada], [horaSalida]) VALUES (85876, N'Martes', CAST(N'12:00:00' AS Time), CAST(N'17:00:00' AS Time))
INSERT [dbo].[Dias] ([id_dias], [dia], [horaEntrada], [horaSalida]) VALUES (85877, N'Miercoles', CAST(N'12:00:00' AS Time), CAST(N'17:00:00' AS Time))
INSERT [dbo].[Dias] ([id_dias], [dia], [horaEntrada], [horaSalida]) VALUES (85878, N'Jueves', CAST(N'12:00:00' AS Time), CAST(N'17:00:00' AS Time))
INSERT [dbo].[Dias] ([id_dias], [dia], [horaEntrada], [horaSalida]) VALUES (85879, N'Viernes', CAST(N'12:00:00' AS Time), CAST(N'17:00:00' AS Time))
GO
INSERT [dbo].[Especialidad] ([id_especialidad], [especialidad]) VALUES (1, N'Ortodoncia')
INSERT [dbo].[Especialidad] ([id_especialidad], [especialidad]) VALUES (2, N'Periodoncia')
INSERT [dbo].[Especialidad] ([id_especialidad], [especialidad]) VALUES (3, N'Endodoncia')
INSERT [dbo].[Especialidad] ([id_especialidad], [especialidad]) VALUES (4, N'Odontopediatría')
GO
INSERT [dbo].[EtapaEdad] ([id_etapaEdad], [etapa], [edadMin], [edadMax]) VALUES (1, N'Bebé', 0, 1)
INSERT [dbo].[EtapaEdad] ([id_etapaEdad], [etapa], [edadMin], [edadMax]) VALUES (2, N'Niño', 1, 12)
INSERT [dbo].[EtapaEdad] ([id_etapaEdad], [etapa], [edadMin], [edadMax]) VALUES (3, N'Adolescente', 12, 18)
INSERT [dbo].[EtapaEdad] ([id_etapaEdad], [etapa], [edadMin], [edadMax]) VALUES (4, N'Adulto joven', 18, 25)
INSERT [dbo].[EtapaEdad] ([id_etapaEdad], [etapa], [edadMin], [edadMax]) VALUES (5, N'Adulto', 25, 65)
INSERT [dbo].[EtapaEdad] ([id_etapaEdad], [etapa], [edadMin], [edadMax]) VALUES (6, N'Adulto mayor', 65, 80)
INSERT [dbo].[EtapaEdad] ([id_etapaEdad], [etapa], [edadMin], [edadMax]) VALUES (7, N'Anciano', 80, 130)
GO
SET IDENTITY_INSERT [dbo].[HistoriaClinica] ON 

INSERT [dbo].[HistoriaClinica] ([id_historiaClinica], [id_paciente], [id_antecedentes]) VALUES (1, 67, 1)
INSERT [dbo].[HistoriaClinica] ([id_historiaClinica], [id_paciente], [id_antecedentes]) VALUES (2, 68, 2)
INSERT [dbo].[HistoriaClinica] ([id_historiaClinica], [id_paciente], [id_antecedentes]) VALUES (3, 69, 3)
INSERT [dbo].[HistoriaClinica] ([id_historiaClinica], [id_paciente], [id_antecedentes]) VALUES (4, 70, 4)
INSERT [dbo].[HistoriaClinica] ([id_historiaClinica], [id_paciente], [id_antecedentes]) VALUES (5, 71, 5)
INSERT [dbo].[HistoriaClinica] ([id_historiaClinica], [id_paciente], [id_antecedentes]) VALUES (6, 72, 6)
SET IDENTITY_INSERT [dbo].[HistoriaClinica] OFF
GO
INSERT [dbo].[Horario] ([id_horario], [tipo]) VALUES (86592, N'Matutino I')
INSERT [dbo].[Horario] ([id_horario], [tipo]) VALUES (86593, N'Matutino II')
INSERT [dbo].[Horario] ([id_horario], [tipo]) VALUES (86594, N'Vespertino I')
INSERT [dbo].[Horario] ([id_horario], [tipo]) VALUES (86595, N'Vespertino II')
INSERT [dbo].[Horario] ([id_horario], [tipo]) VALUES (86596, N'Fines de Semana')
GO
INSERT [dbo].[HorarioDias] ([id_horario], [id_dias]) VALUES (86592, 85869)
INSERT [dbo].[HorarioDias] ([id_horario], [id_dias]) VALUES (86592, 85871)
INSERT [dbo].[HorarioDias] ([id_horario], [id_dias]) VALUES (86592, 85873)
INSERT [dbo].[HorarioDias] ([id_horario], [id_dias]) VALUES (86593, 85874)
INSERT [dbo].[HorarioDias] ([id_horario], [id_dias]) VALUES (86593, 85871)
INSERT [dbo].[HorarioDias] ([id_horario], [id_dias]) VALUES (86593, 85872)
INSERT [dbo].[HorarioDias] ([id_horario], [id_dias]) VALUES (86594, 85874)
INSERT [dbo].[HorarioDias] ([id_horario], [id_dias]) VALUES (86594, 85878)
INSERT [dbo].[HorarioDias] ([id_horario], [id_dias]) VALUES (86594, 85879)
INSERT [dbo].[HorarioDias] ([id_horario], [id_dias]) VALUES (86595, 85870)
INSERT [dbo].[HorarioDias] ([id_horario], [id_dias]) VALUES (86595, 85871)
INSERT [dbo].[HorarioDias] ([id_horario], [id_dias]) VALUES (86595, 85879)
INSERT [dbo].[HorarioDias] ([id_horario], [id_dias]) VALUES (86596, 85875)
INSERT [dbo].[HorarioDias] ([id_horario], [id_dias]) VALUES (86596, 85876)
GO
INSERT [dbo].[NombrePieza] ([id_nombrePieza], [nombrePieza]) VALUES (1, N'Incisivo Central')
INSERT [dbo].[NombrePieza] ([id_nombrePieza], [nombrePieza]) VALUES (2, N'Incisivo Lateral')
INSERT [dbo].[NombrePieza] ([id_nombrePieza], [nombrePieza]) VALUES (3, N'Canino')
INSERT [dbo].[NombrePieza] ([id_nombrePieza], [nombrePieza]) VALUES (4, N'Primer Premolar')
INSERT [dbo].[NombrePieza] ([id_nombrePieza], [nombrePieza]) VALUES (5, N'Segundo Premolar')
INSERT [dbo].[NombrePieza] ([id_nombrePieza], [nombrePieza]) VALUES (6, N'Primer Molar')
INSERT [dbo].[NombrePieza] ([id_nombrePieza], [nombrePieza]) VALUES (7, N'Segundo Molar')
INSERT [dbo].[NombrePieza] ([id_nombrePieza], [nombrePieza]) VALUES (8, N'Tercer Molar')
GO
INSERT [dbo].[Odontologo] ([id_odontologo], [id_horario], [id_especialidad], [consultorio]) VALUES (61, 86592, 1, 1)
INSERT [dbo].[Odontologo] ([id_odontologo], [id_horario], [id_especialidad], [consultorio]) VALUES (62, 86593, 2, 2)
INSERT [dbo].[Odontologo] ([id_odontologo], [id_horario], [id_especialidad], [consultorio]) VALUES (63, 86594, 3, 3)
INSERT [dbo].[Odontologo] ([id_odontologo], [id_horario], [id_especialidad], [consultorio]) VALUES (64, 86595, 4, 4)
INSERT [dbo].[Odontologo] ([id_odontologo], [id_horario], [id_especialidad], [consultorio]) VALUES (65, 86596, 2, 5)
INSERT [dbo].[Odontologo] ([id_odontologo], [id_horario], [id_especialidad], [consultorio]) VALUES (66, 86596, 3, 6)
GO
INSERT [dbo].[Paciente] ([id_paciente], [discapacidad], [id_etapaEdad]) VALUES (67, N'Si', 4)
INSERT [dbo].[Paciente] ([id_paciente], [discapacidad], [id_etapaEdad]) VALUES (68, N'No', 7)
INSERT [dbo].[Paciente] ([id_paciente], [discapacidad], [id_etapaEdad]) VALUES (69, N'No', 5)
INSERT [dbo].[Paciente] ([id_paciente], [discapacidad], [id_etapaEdad]) VALUES (70, N'Si', 3)
INSERT [dbo].[Paciente] ([id_paciente], [discapacidad], [id_etapaEdad]) VALUES (71, N'No', 2)
INSERT [dbo].[Paciente] ([id_paciente], [discapacidad], [id_etapaEdad]) VALUES (72, N'No', 1)
GO
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([id_persona], [cedula], [id_sexo], [nombres], [fechaNacimiento], [telefono], [correo]) VALUES (61, N'0945627894', N'F', N'María Espinoza', CAST(N'1970-08-03' AS Date), N'0123456789', N'and@hotmail.com')
INSERT [dbo].[Persona] ([id_persona], [cedula], [id_sexo], [nombres], [fechaNacimiento], [telefono], [correo]) VALUES (62, N'1945269871', N'F', N'Carolina Mendez', CAST(N'1980-01-10' AS Date), N'0741852963', N'sdfde@hotmail.com')
INSERT [dbo].[Persona] ([id_persona], [cedula], [id_sexo], [nombres], [fechaNacimiento], [telefono], [correo]) VALUES (63, N'0975631478', N'M', N'Pedro Rodriguez', CAST(N'1995-01-06' AS Date), N'0987654321', N'rew@hotmail.com')
INSERT [dbo].[Persona] ([id_persona], [cedula], [id_sexo], [nombres], [fechaNacimiento], [telefono], [correo]) VALUES (64, N'0937841236', N'M', N'Fernando Lino', CAST(N'1990-07-25' AS Date), N'0852789456', N'sdfsd@hotmail.com')
INSERT [dbo].[Persona] ([id_persona], [cedula], [id_sexo], [nombres], [fechaNacimiento], [telefono], [correo]) VALUES (65, N'0987631587', N'F', N'Melina Naula', CAST(N'1996-06-30' AS Date), N'0951369789', N'qwe@hotmail.com')
INSERT [dbo].[Persona] ([id_persona], [cedula], [id_sexo], [nombres], [fechaNacimiento], [telefono], [correo]) VALUES (66, N'0942562184', N'M', N'Carlos Peralta', CAST(N'2005-10-11' AS Date), N'0123456543', N'fghg@hotmail.com')
INSERT [dbo].[Persona] ([id_persona], [cedula], [id_sexo], [nombres], [fechaNacimiento], [telefono], [correo]) VALUES (67, N'0965874154', N'M', N'Matias Zambrano', CAST(N'2000-10-12' AS Date), N'0123456654', N'iyt@hotmail.com')
INSERT [dbo].[Persona] ([id_persona], [cedula], [id_sexo], [nombres], [fechaNacimiento], [telefono], [correo]) VALUES (68, N'0697853648', N'F', N'Daniela Moreira', CAST(N'1960-09-26' AS Date), N'0321654987', N'fd45@hotmail.com')
INSERT [dbo].[Persona] ([id_persona], [cedula], [id_sexo], [nombres], [fechaNacimiento], [telefono], [correo]) VALUES (69, N'0969521489', N'F', N'Mayra Loaiza', CAST(N'1956-11-07' AS Date), N'0321654987', N'ghf6@hotmail.com')
INSERT [dbo].[Persona] ([id_persona], [cedula], [id_sexo], [nombres], [fechaNacimiento], [telefono], [correo]) VALUES (70, N'0968741595', N'M', N'Jose Castro', CAST(N'1979-08-09' AS Date), N'0147852369', N'er3@hotmail.com')
INSERT [dbo].[Persona] ([id_persona], [cedula], [id_sexo], [nombres], [fechaNacimiento], [telefono], [correo]) VALUES (71, N'0984512478', N'F', N'María Briones', CAST(N'2009-10-16' AS Date), N'015979852', N're8@hotmail.com')
INSERT [dbo].[Persona] ([id_persona], [cedula], [id_sexo], [nombres], [fechaNacimiento], [telefono], [correo]) VALUES (72, N'0932154784', N'M', N'Marcos Plaza', CAST(N'1996-10-17' AS Date), N'0321654649', N'645r@hotmail.com')
SET IDENTITY_INSERT [dbo].[Persona] OFF
GO
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (11, 1, 1)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (12, 1, 2)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (13, 1, 3)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (14, 1, 4)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (15, 1, 5)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (16, 1, 6)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (17, 1, 7)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (18, 1, 8)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (21, 2, 1)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (22, 2, 2)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (23, 2, 3)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (24, 2, 4)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (25, 2, 5)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (26, 2, 6)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (27, 2, 7)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (28, 2, 8)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (31, 3, 1)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (32, 3, 2)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (33, 3, 3)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (34, 3, 4)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (35, 3, 5)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (36, 3, 6)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (37, 3, 7)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (38, 3, 8)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (41, 4, 1)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (42, 4, 2)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (43, 4, 3)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (44, 4, 4)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (45, 4, 5)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (46, 4, 6)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (47, 4, 7)
INSERT [dbo].[PiezaDental] ([id_piezaDental], [id_cuadrantePieza], [id_nombrePieza]) VALUES (48, 4, 8)
GO
INSERT [dbo].[Sexo] ([id_sexo], [sexo]) VALUES (N'F', N'Femenino')
INSERT [dbo].[Sexo] ([id_sexo], [sexo]) VALUES (N'M', N'Masculino')
GO
ALTER TABLE [dbo].[AtencionMedica]  WITH CHECK ADD  CONSTRAINT [FK_AtencionMedica_Cita] FOREIGN KEY([id_cita])
REFERENCES [dbo].[Cita] ([id_cita])
GO
ALTER TABLE [dbo].[AtencionMedica] CHECK CONSTRAINT [FK_AtencionMedica_Cita]
GO
ALTER TABLE [dbo].[AtencionMedica]  WITH CHECK ADD  CONSTRAINT [FK_AtencionMedica_HistoriaClinica] FOREIGN KEY([id_historiaClinica])
REFERENCES [dbo].[HistoriaClinica] ([id_historiaClinica])
GO
ALTER TABLE [dbo].[AtencionMedica] CHECK CONSTRAINT [FK_AtencionMedica_HistoriaClinica]
GO
ALTER TABLE [dbo].[AtencionMedica]  WITH CHECK ADD  CONSTRAINT [FK_AtencionMedica_PiezaDental] FOREIGN KEY([id_piezaDental])
REFERENCES [dbo].[PiezaDental] ([id_piezaDental])
GO
ALTER TABLE [dbo].[AtencionMedica] CHECK CONSTRAINT [FK_AtencionMedica_PiezaDental]
GO
ALTER TABLE [dbo].[Cita]  WITH CHECK ADD  CONSTRAINT [FK_Cita_Odontologo] FOREIGN KEY([id_odontologo])
REFERENCES [dbo].[Odontologo] ([id_odontologo])
GO
ALTER TABLE [dbo].[Cita] CHECK CONSTRAINT [FK_Cita_Odontologo]
GO
ALTER TABLE [dbo].[Cita]  WITH CHECK ADD  CONSTRAINT [FK_Cita_Paciente] FOREIGN KEY([id_paciente])
REFERENCES [dbo].[Paciente] ([id_paciente])
GO
ALTER TABLE [dbo].[Cita] CHECK CONSTRAINT [FK_Cita_Paciente]
GO
ALTER TABLE [dbo].[HistoriaClinica]  WITH CHECK ADD  CONSTRAINT [FK_HistoriaClinica_Antecedentes] FOREIGN KEY([id_antecedentes])
REFERENCES [dbo].[Antecedentes] ([id_antecedentes])
GO
ALTER TABLE [dbo].[HistoriaClinica] CHECK CONSTRAINT [FK_HistoriaClinica_Antecedentes]
GO
ALTER TABLE [dbo].[HistoriaClinica]  WITH CHECK ADD  CONSTRAINT [FK_HistoriaClinica_Paciente] FOREIGN KEY([id_paciente])
REFERENCES [dbo].[Paciente] ([id_paciente])
GO
ALTER TABLE [dbo].[HistoriaClinica] CHECK CONSTRAINT [FK_HistoriaClinica_Paciente]
GO
ALTER TABLE [dbo].[HorarioDias]  WITH CHECK ADD  CONSTRAINT [FK_HorarioDias_Dias] FOREIGN KEY([id_dias])
REFERENCES [dbo].[Dias] ([id_dias])
GO
ALTER TABLE [dbo].[HorarioDias] CHECK CONSTRAINT [FK_HorarioDias_Dias]
GO
ALTER TABLE [dbo].[HorarioDias]  WITH CHECK ADD  CONSTRAINT [FK_HorarioDias_Horario] FOREIGN KEY([id_horario])
REFERENCES [dbo].[Horario] ([id_horario])
GO
ALTER TABLE [dbo].[HorarioDias] CHECK CONSTRAINT [FK_HorarioDias_Horario]
GO
ALTER TABLE [dbo].[Odontologo]  WITH CHECK ADD  CONSTRAINT [FK_Odontologo_Persona] FOREIGN KEY([id_odontologo])
REFERENCES [dbo].[Persona] ([id_persona])
GO
ALTER TABLE [dbo].[Odontologo] CHECK CONSTRAINT [FK_Odontologo_Persona]
GO
ALTER TABLE [dbo].[Paciente]  WITH CHECK ADD  CONSTRAINT [FK_Paciente_EtapaEdad] FOREIGN KEY([id_etapaEdad])
REFERENCES [dbo].[EtapaEdad] ([id_etapaEdad])
GO
ALTER TABLE [dbo].[Paciente] CHECK CONSTRAINT [FK_Paciente_EtapaEdad]
GO
ALTER TABLE [dbo].[Paciente]  WITH CHECK ADD  CONSTRAINT [FK_Paciente_Persona] FOREIGN KEY([id_paciente])
REFERENCES [dbo].[Persona] ([id_persona])
GO
ALTER TABLE [dbo].[Paciente] CHECK CONSTRAINT [FK_Paciente_Persona]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Sexo] FOREIGN KEY([id_sexo])
REFERENCES [dbo].[Sexo] ([id_sexo])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_Sexo]
GO
ALTER TABLE [dbo].[PiezaDental]  WITH CHECK ADD  CONSTRAINT [FK_PiezaDental_CuadrantePieza] FOREIGN KEY([id_cuadrantePieza])
REFERENCES [dbo].[CuadrantePieza] ([id_cuadrantePieza])
GO
ALTER TABLE [dbo].[PiezaDental] CHECK CONSTRAINT [FK_PiezaDental_CuadrantePieza]
GO
ALTER TABLE [dbo].[PiezaDental]  WITH CHECK ADD  CONSTRAINT [FK_PiezaDental_NombrePieza] FOREIGN KEY([id_nombrePieza])
REFERENCES [dbo].[NombrePieza] ([id_nombrePieza])
GO
ALTER TABLE [dbo].[PiezaDental] CHECK CONSTRAINT [FK_PiezaDental_NombrePieza]
GO
USE [master]
GO
ALTER DATABASE [Dentalig] SET  READ_WRITE 
GO
