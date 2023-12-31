USE [master]
GO
/****** Object:  Database [Keskin]    Script Date: 25.08.2023 02:46:54 ******/
CREATE DATABASE [Keskin]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Keskin', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.AAA\MSSQL\DATA\Keskin.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Keskin_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.AAA\MSSQL\DATA\Keskin_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Keskin] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Keskin].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Keskin] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Keskin] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Keskin] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Keskin] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Keskin] SET ARITHABORT OFF 
GO
ALTER DATABASE [Keskin] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Keskin] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Keskin] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Keskin] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Keskin] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Keskin] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Keskin] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Keskin] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Keskin] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Keskin] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Keskin] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Keskin] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Keskin] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Keskin] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Keskin] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Keskin] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Keskin] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Keskin] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Keskin] SET  MULTI_USER 
GO
ALTER DATABASE [Keskin] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Keskin] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Keskin] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Keskin] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Keskin] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Keskin] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Keskin] SET QUERY_STORE = OFF
GO
USE [Keskin]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 25.08.2023 02:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Writer] [nvarchar](50) NULL,
	[Price] [money] NULL,
	[NumberPage] [int] NULL,
	[CategoryID] [int] NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 25.08.2023 02:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 25.08.2023 02:46:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([BookID], [Name], [Writer], [Price], [NumberPage], [CategoryID]) VALUES (1, N'Atomik Alışkanlıklar', N'James Clear', 95.0000, 352, 1)
INSERT [dbo].[Books] ([BookID], [Name], [Writer], [Price], [NumberPage], [CategoryID]) VALUES (2, N'Python Eğitim Kitabı', N'Volkan Taşçı', 206.0000, 560, 2)
INSERT [dbo].[Books] ([BookID], [Name], [Writer], [Price], [NumberPage], [CategoryID]) VALUES (3, N'Osmanlı’yı Yeniden Keşfetmek', N'Prof. Dr. İlber Ortaylı ', 31.0000, 208, 3)
INSERT [dbo].[Books] ([BookID], [Name], [Writer], [Price], [NumberPage], [CategoryID]) VALUES (4, N'Tüfek, Mikrop ve Çelik (Karton Kapak)', N'Jared Diamond ', 145.0000, 664, 4)
INSERT [dbo].[Books] ([BookID], [Name], [Writer], [Price], [NumberPage], [CategoryID]) VALUES (5, N'Küçük İşler Büyük Özgürlükler', N'Mert Başaran  ', 154.0000, 208, 6)
INSERT [dbo].[Books] ([BookID], [Name], [Writer], [Price], [NumberPage], [CategoryID]) VALUES (6, N'Muhtelif 1', N'Altay Cem Meriç n  ', 71.0000, 184, 5)
INSERT [dbo].[Books] ([BookID], [Name], [Writer], [Price], [NumberPage], [CategoryID]) VALUES (7, N'Beden Dili', N'Joe Navarro, Marvin Karlins  ', 105.0000, 300, 1)
INSERT [dbo].[Books] ([BookID], [Name], [Writer], [Price], [NumberPage], [CategoryID]) VALUES (8, N'Ezbere Yaşayanlar', N'Emrah Safa Gürkan   ', 60.0000, 400, 4)
INSERT [dbo].[Books] ([BookID], [Name], [Writer], [Price], [NumberPage], [CategoryID]) VALUES (9, N'JAVA ile Programlama ve Veri Yapıları', N'Bülent Çobanoğlu', 75.0000, 404, 2)
INSERT [dbo].[Books] ([BookID], [Name], [Writer], [Price], [NumberPage], [CategoryID]) VALUES (10, N'Son Cüret', N'Yılmaz Özdil ', 17.0000, 456, 3)
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description]) VALUES (1, N'Kişisel Gelişim', N'Kendini Geliştirmek İçin Okuman Gereken Kitaplar')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description]) VALUES (2, N'Bilgisayar', N'Bilgisayar İle İlgili Kitaplar.')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description]) VALUES (3, N'Tarih', N'Geçmişte Kalmış Bilgileri Okuyarak Öğren')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description]) VALUES (4, N'Bilim & Mühendislik', N'Bilim İle İlgili Kitaplar.')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description]) VALUES (5, N'Din', N'Dinler İle İlgili Kitaplar.')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description]) VALUES (6, N'Ekonomi', N'Ekonomi İle İlgili Kitaplar.')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [UserName], [Email], [Password]) VALUES (1, N'Admin', N'admin@gmail.com', N'123')
INSERT [dbo].[Users] ([UserID], [UserName], [Email], [Password]) VALUES (2, N'Mehmet', N'mk9391470@gmail.com', N'1597530')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
USE [master]
GO
ALTER DATABASE [Keskin] SET  READ_WRITE 
GO
