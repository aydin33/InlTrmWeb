USE [master]
GO
/****** Object:  Database [INLTRM]    Script Date: 21.10.2020 09:20:22 ******/
CREATE DATABASE [INLTRM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'INLTRM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\INLTRM.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'INLTRM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\INLTRM_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [INLTRM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [INLTRM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [INLTRM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [INLTRM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [INLTRM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [INLTRM] SET ARITHABORT OFF 
GO
ALTER DATABASE [INLTRM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [INLTRM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [INLTRM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [INLTRM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [INLTRM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [INLTRM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [INLTRM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [INLTRM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [INLTRM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [INLTRM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [INLTRM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [INLTRM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [INLTRM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [INLTRM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [INLTRM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [INLTRM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [INLTRM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [INLTRM] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [INLTRM] SET  MULTI_USER 
GO
ALTER DATABASE [INLTRM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [INLTRM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [INLTRM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [INLTRM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [INLTRM] SET DELAYED_DURABILITY = DISABLED 
GO
USE [INLTRM]
GO
/****** Object:  Table [dbo].[ATTACHMENTS]    Script Date: 21.10.2020 09:20:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[ATTACHMENTS](
	[ATTACH_ID] [int] IDENTITY(1,1) NOT NULL,
	[FILE] [varbinary](1) NOT NULL,
	[CREATED] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ATTACH_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[COST_TYPES]    Script Date: 21.10.2020 09:20:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COST_TYPES](
	[COST_TYPE_ID] [int] IDENTITY(1,1) NOT NULL,
	[COST_NAME] [varchar](80) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[COST_TYPE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[COSTS]    Script Date: 21.10.2020 09:20:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COSTS](
	[COST_ID] [int] IDENTITY(1,1) NOT NULL,
	[COST_TYPE_ID] [int] NOT NULL,
	[COST_EMP_ID] [int] NOT NULL,
	[COST_DATE] [datetime] NOT NULL,
	[COST_DESCRIPTION] [varchar](300) NOT NULL,
	[COST_AMOUNT] [numeric](28, 6) NOT NULL,
	[ATTACH_ID] [int] NULL,
	[CREATED] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[COST_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EMPLOYEE]    Script Date: 21.10.2020 09:20:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[EMPLOYEE](
	[EMP_ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [varchar](50) NOT NULL,
	[SURNAME] [varchar](100) NOT NULL,
	[USER_NAME] [varchar](30) NOT NULL,
	[PASSWORD] [varchar](30) NOT NULL,
	[EMAIL] [varchar](80) NULL,
	[PHONE_NUMBER] [varchar](80) NULL,
	[ADDRESS] [varchar](200) NULL,
	[AUTH_LEVEL] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EMP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[COSTS]  WITH CHECK ADD FOREIGN KEY([ATTACH_ID])
REFERENCES [dbo].[ATTACHMENTS] ([ATTACH_ID])
GO
ALTER TABLE [dbo].[COSTS]  WITH CHECK ADD FOREIGN KEY([COST_EMP_ID])
REFERENCES [dbo].[EMPLOYEE] ([EMP_ID])
GO
ALTER TABLE [dbo].[COSTS]  WITH CHECK ADD FOREIGN KEY([COST_TYPE_ID])
REFERENCES [dbo].[COST_TYPES] ([COST_TYPE_ID])
GO
USE [master]
GO
ALTER DATABASE [INLTRM] SET  READ_WRITE 
GO
