USE [master]
GO

/****** Object:  Database [Photohosting]    Script Date: 28.05.2021 11:12:01 ******/
CREATE DATABASE [Photohosting]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PhotohHosting', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PhotohHosting.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PhotohHosting_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PhotohHosting_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Photohosting].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Photohosting] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Photohosting] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Photohosting] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Photohosting] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Photohosting] SET ARITHABORT OFF 
GO

ALTER DATABASE [Photohosting] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Photohosting] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Photohosting] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Photohosting] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Photohosting] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Photohosting] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Photohosting] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Photohosting] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Photohosting] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Photohosting] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Photohosting] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Photohosting] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Photohosting] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Photohosting] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Photohosting] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Photohosting] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Photohosting] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Photohosting] SET RECOVERY FULL 
GO

ALTER DATABASE [Photohosting] SET  MULTI_USER 
GO

ALTER DATABASE [Photohosting] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Photohosting] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Photohosting] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Photohosting] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Photohosting] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Photohosting] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [Photohosting] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Photohosting] SET  READ_WRITE 
GO


USE [Photohosting]
GO

/****** Object:  Table [dbo].[Accounts]    Script Date: 28.05.2021 11:12:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Accounts](
	[UID] [int] IDENTITY(0,1) NOT NULL,
	[Login] [nvarchar](10) NULL,
	[Password] [nvarchar](10) NULL,
	[Email] [nvarchar](20) NULL,
	[Phone_Number] [int] NULL,
	[BdayDate] [date] NULL,
	[Name] [nchar](15) NULL,
	[LastName] [nchar](15) NULL,
	[Pic] [varbinary](max) NULL,
	[ImagePath] [varchar](max) NULL,
	[IsAdmin] [bit] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_IsAdmin]  DEFAULT ((0)) FOR [IsAdmin]
GO

USE [Photohosting]
GO

/****** Object:  Table [dbo].[Comments]    Script Date: 28.05.2021 11:13:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[UId] [int] NULL,
	[Message] [nvarchar](max) NOT NULL,
	[PId] [int] NOT NULL,
	[UName] [nvarchar](max) NULL,
	[UPic] [varbinary](max) NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Accounts] FOREIGN KEY([UId])
REFERENCES [dbo].[Accounts] ([UID])
GO

ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Accounts]
GO

ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Picture] FOREIGN KEY([PId])
REFERENCES [dbo].[Picture] ([PID])
GO

ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Picture]
GO


USE [Photohosting]
GO

/****** Object:  Table [dbo].[Errors]    Script Date: 28.05.2021 11:13:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Errors](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[Message] [varchar](max) NOT NULL,
	[Solved] [bit] NULL,
	[UId] [int] NULL,
	[UName] [varchar](max) NULL,
 CONSTRAINT [PK_Errors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Errors] ADD  DEFAULT ((0)) FOR [Solved]
GO

ALTER TABLE [dbo].[Errors]  WITH CHECK ADD  CONSTRAINT [FK_Errors_Accounts] FOREIGN KEY([UId])
REFERENCES [dbo].[Accounts] ([UID])
GO

ALTER TABLE [dbo].[Errors] CHECK CONSTRAINT [FK_Errors_Accounts]
GO


USE [Photohosting]
GO

/****** Object:  Table [dbo].[Picture]    Script Date: 28.05.2021 11:14:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Picture](
	[PID] [int] IDENTITY(0,1) NOT NULL,
	[PicFileName] [nvarchar](max) NULL,
	[Pic] [varbinary](max) NULL,
	[MainTopic] [nchar](10) NULL,
	[Description] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Picture] PRIMARY KEY CLUSTERED 
(
	[PID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


insert into Accounts (Login, Password, Name, LastName, IsAdmin)
values (00, 00, 'Kora', 'Merhel', 0)

insert into Accounts (Login, Password, Name, LastName, IsAdmin)
values (11, 11, 'User', 'Test', 1)

insert into Comments (UId, Message, PId, Date)
values	(0, 'памагити', 0 ,2021-05-28),
		(0, 'памагити', 1 ,2021-05-28);