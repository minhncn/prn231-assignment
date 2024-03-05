USE [master]
GO
/****** Object:  Database [PetShop]    Script Date: 3/5/2024 11:01:11 AM ******/
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
/****** Object:  Table [dbo].[Category]    Script Date: 3/5/2024 11:01:12 AM ******/
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
/****** Object:  Table [dbo].[Order]    Script Date: 3/5/2024 11:01:12 AM ******/
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
/****** Object:  Table [dbo].[Product]    Script Date: 3/5/2024 11:01:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[Category_ID] [uniqueidentifier] NULL,
	[Status] [char](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/5/2024 11:01:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Status] [char](20) NULL,
	[Role] [char](20) NOT NULL,
	[Order_ID] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Category] ([ID], [Name], [Description], [Status]) VALUES (N'a06cf980-98a2-47f3-a2ff-103e94dc08bc', N'string', N'string', NULL)
INSERT [dbo].[Category] ([ID], [Name], [Description], [Status]) VALUES (N'dbe8b1e1-4a22-44c9-b946-456e6c73157d', N'Category2', N'Description2', NULL)
GO
INSERT [dbo].[Order] ([ID], [User_ID], [Product_ID], [Quantity], [Order_date], [Status]) VALUES (N'3da7e523-9b8f-4484-9ebc-3265eddebef1', N'9290dd37-295f-48f6-9d31-9115946f12a9', N'd7c8eaf6-67e0-425b-abf6-e1faa4fba676', 1, CAST(N'2024-03-03' AS Date), NULL)
INSERT [dbo].[Order] ([ID], [User_ID], [Product_ID], [Quantity], [Order_date], [Status]) VALUES (N'b799d9ef-8757-418e-9a6c-93e8a3e4dabd', N'a707eed7-6618-406a-aa48-7896f17070cd', N'e3f6a65c-b07f-437a-ac27-565b6763225f', 2, CAST(N'2024-03-03' AS Date), NULL)
GO
INSERT [dbo].[Product] ([ID], [Name], [Price], [Category_ID], [Status]) VALUES (N'e3f6a65c-b07f-437a-ac27-565b6763225f', N'Product1', CAST(10.00 AS Decimal(10, 2)), N'a06cf980-98a2-47f3-a2ff-103e94dc08bc', NULL)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Category_ID], [Status]) VALUES (N'd7c8eaf6-67e0-425b-abf6-e1faa4fba676', N'Product2', CAST(20.00 AS Decimal(10, 2)), N'dbe8b1e1-4a22-44c9-b946-456e6c73157d', NULL)
GO
INSERT [dbo].[User] ([ID], [Username], [Password], [Email], [Status], [Role], [Order_ID]) VALUES (N'a707eed7-6618-406a-aa48-7896f17070cd', N'user1', N'password1', N'user1@example.com', NULL, N'Role1               ', N'3da7e523-9b8f-4484-9ebc-3265eddebef1')
INSERT [dbo].[User] ([ID], [Username], [Password], [Email], [Status], [Role], [Order_ID]) VALUES (N'9290dd37-295f-48f6-9d31-9115946f12a9', N'user2', N'password2', N'user2@example.com', NULL, N'Role2               ', N'3da7e523-9b8f-4484-9ebc-3265eddebef1')
INSERT [dbo].[User] ([ID], [Username], [Password], [Email], [Status], [Role], [Order_ID]) VALUES (N'ce978664-b4aa-4391-916e-faf62f2a9e99', N'admin', N'admin', N'admin@gmail.com', N'Activate            ', N'admin               ', NULL)
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
