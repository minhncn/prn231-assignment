USE [master]
GO
/****** Object:  Database [PetShop]    Script Date: 3/8/2024 2:06:35 PM ******/
CREATE DATABASE [PetShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PetShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\PetShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PetShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\PetShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PetShop] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PetShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PetShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PetShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PetShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PetShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PetShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [PetShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PetShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PetShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PetShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PetShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PetShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PetShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PetShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PetShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PetShop] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PetShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PetShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PetShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PetShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PetShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PetShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PetShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PetShop] SET RECOVERY FULL 
GO
ALTER DATABASE [PetShop] SET  MULTI_USER 
GO
ALTER DATABASE [PetShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PetShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PetShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PetShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PetShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PetShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PetShop', N'ON'
GO
ALTER DATABASE [PetShop] SET QUERY_STORE = ON
GO
ALTER DATABASE [PetShop] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PetShop]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 3/8/2024 2:06:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [text] NULL,
	[Status] [char](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 3/8/2024 2:06:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [uniqueidentifier] NOT NULL,
	[User_ID] [uniqueidentifier] NULL,
	[Product_ID] [uniqueidentifier] NULL,
	[Quantity] [int] NULL,
	[Order_date] [date] NULL,
	[Status] [char](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 3/8/2024 2:06:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[Category_ID] [uniqueidentifier] NULL,
	[Status] [char](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/8/2024 2:06:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [uniqueidentifier] NOT NULL,
	[Username] [varchar](max) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[Email] [varchar](max) NOT NULL,
	[Status] [varchar](20) NULL,
	[Role] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Category] ([ID], [Name], [Description], [Status]) VALUES (N'a1377625-62c5-46e8-b873-24078cabe410', N'string', N'string', N'Available           ')
INSERT [dbo].[Category] ([ID], [Name], [Description], [Status]) VALUES (N'159e16be-291d-4601-8ce7-275ba00f148f', N'string', N'string', N'Available           ')
INSERT [dbo].[Category] ([ID], [Name], [Description], [Status]) VALUES (N'49297e77-b858-4774-8602-302b66e78daf', N'string', N'string', N'Available           ')
INSERT [dbo].[Category] ([ID], [Name], [Description], [Status]) VALUES (N'df29d1f1-e80b-425f-85c8-4155ab6decb3', N'string', N'string', N'Available           ')
INSERT [dbo].[Category] ([ID], [Name], [Description], [Status]) VALUES (N'53381489-482d-4ee3-9c7d-4a8486fadc4e', N'string', N'string', N'Available           ')
INSERT [dbo].[Category] ([ID], [Name], [Description], [Status]) VALUES (N'325b5b0b-9aab-45ef-af58-85581d9856a7', N'string', N'string', N'Available           ')
INSERT [dbo].[Category] ([ID], [Name], [Description], [Status]) VALUES (N'56cbfa92-a7bb-44d2-9acf-fb24d8d83a63', N'string', N'string', N'Available           ')
GO
INSERT [dbo].[User] ([ID], [Username], [Password], [Email], [Status], [Role]) VALUES (N'00000000-0000-0000-0000-000000000000', N'staff', N'staff', N'staff@gmail.com', N'Activate', N'Staff')
INSERT [dbo].[User] ([ID], [Username], [Password], [Email], [Status], [Role]) VALUES (N'2a35fb47-752c-49e7-adda-cc6a9bf99d45', N'admin', N'admin', N'admin@gmail.co', N'Activate            ', N'admin               ')
INSERT [dbo].[User] ([ID], [Username], [Password], [Email], [Status], [Role]) VALUES (N'3a35fb47-752c-49e7-adda-cc6a9bf99d45', N'admin', N'admin', N'admin@gmail.com', N'Activate', N'admin')
INSERT [dbo].[User] ([ID], [Username], [Password], [Email], [Status], [Role]) VALUES (N'2a35fb47-752c-49e7-adda-cc6a9bf99d46', N'as', N'ad', N'admin@gmail.com', N'Activate', N'admin')
INSERT [dbo].[User] ([ID], [Username], [Password], [Email], [Status], [Role]) VALUES (N'2a35fb47-752c-49e7-adda-cc6a9bf99d4b', N'admin', N'admin', N'admin@gmail.com', N'Activate            ', N'admin               ')
INSERT [dbo].[User] ([ID], [Username], [Password], [Email], [Status], [Role]) VALUES (N'2a35fb47-752c-49e7-adda-cc6a9bf99d4c', N'admin1', N'admin', N'1@gm', N'Activate', N'Admin')
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([Product_ID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([User_ID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([Category_ID])
REFERENCES [dbo].[Category] ([ID])
GO
USE [master]
GO
ALTER DATABASE [PetShop] SET  READ_WRITE 
GO
