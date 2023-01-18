USE [master]
GO
/****** Object:  Database [AudioShopDb]    Script Date: 11/8/2022 9:19:22 PM ******/
CREATE DATABASE [AudioShopDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AudioShopDb', FILENAME = N'D:\sqlData\AudioShopDb\AudioShopDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AudioShopDb_log', FILENAME = N'D:\sqlData\AudioShopDb\AudioShopDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AudioShopDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AudioShopDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AudioShopDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AudioShopDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AudioShopDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AudioShopDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AudioShopDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [AudioShopDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AudioShopDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AudioShopDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AudioShopDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AudioShopDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AudioShopDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AudioShopDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AudioShopDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AudioShopDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AudioShopDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AudioShopDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AudioShopDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AudioShopDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AudioShopDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AudioShopDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AudioShopDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AudioShopDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AudioShopDb] SET RECOVERY FULL 
GO
ALTER DATABASE [AudioShopDb] SET  MULTI_USER 
GO
ALTER DATABASE [AudioShopDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AudioShopDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AudioShopDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AudioShopDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AudioShopDb] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AudioShopDb', N'ON'
GO
ALTER DATABASE [AudioShopDb] SET QUERY_STORE = OFF
GO
USE [AudioShopDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [AudioShopDb]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 11/8/2022 9:19:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[NidBrand] [uniqueidentifier] NOT NULL,
	[BrandName] [nvarchar](500) NOT NULL,
	[CategoryId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Keywords] [nvarchar](max) NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastModified] [datetime] NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[NidBrand] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 11/8/2022 9:19:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[NidCart] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastModified] [datetime] NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[NidCart] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 11/8/2022 9:19:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[NidCategory] [uniqueidentifier] NOT NULL,
	[CategoryName] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Keywords] [nvarchar](max) NULL,
	[State] [tinyint] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastModified] [datetime] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[NidCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 11/8/2022 9:19:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[NidComment] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[CommentText] [nvarchar](max) NULL,
	[State] [tinyint] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[NidComment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favorites]    Script Date: 11/8/2022 9:19:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favorites](
	[NidFav] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Favorites] PRIMARY KEY CLUSTERED 
(
	[NidFav] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Files]    Script Date: 11/8/2022 9:19:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Files](
	[NidFile] [uniqueidentifier] NOT NULL,
	[FileExtension] [nvarchar](10) NOT NULL,
	[FilePath] [nvarchar](max) NOT NULL,
	[RelateId] [uniqueidentifier] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[FileSize] [int] NULL,
	[FileUrl] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Priority] [tinyint] NOT NULL,
 CONSTRAINT [PK_Files] PRIMARY KEY CLUSTERED 
(
	[NidFile] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Links]    Script Date: 11/8/2022 9:19:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Links](
	[NidLink] [uniqueidentifier] NOT NULL,
	[RelateId] [uniqueidentifier] NOT NULL,
	[LinkUrl] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Links] PRIMARY KEY CLUSTERED 
(
	[NidLink] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 11/8/2022 9:19:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[NidDetail] [uniqueidentifier] NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastModified] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/8/2022 9:19:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[NidOrder] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[TotalPrice] [decimal](12, 0) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[State] [tinyint] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[StateId] [int] NULL,
	[CityId] [int] NULL,
	[Address] [nvarchar](max) NULL,
	[ZipCode] [decimal](12, 0) NULL,
	[Tel] [nvarchar](25) NULL,
	[Email] [nvarchar](50) NULL,
	[MelliCode] [decimal](12, 0) NULL,
	[RefId] [bigint] NULL,
	[LastModified] [datetime] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[NidOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 11/8/2022 9:19:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[NidProduct] [uniqueidentifier] NOT NULL,
	[ProductNumber] [int] IDENTITY(1000,1) NOT NULL,
	[ProductName] [nvarchar](1000) NOT NULL,
	[CategoryId] [uniqueidentifier] NOT NULL,
	[BrandId] [uniqueidentifier] NOT NULL,
	[TypeId] [uniqueidentifier] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastModified] [datetime] NULL,
	[Description] [nvarchar](max) NULL,
	[Keywords] [nvarchar](max) NULL,
	[Price] [decimal](12, 0) NOT NULL,
	[State] [tinyint] NOT NULL,
	[Priority] [tinyint] NOT NULL,
	[OffPercentage] [tinyint] NOT NULL,
	[AvailableCount] [int] NOT NULL,
	[Specification] [nvarchar](max) NULL,
	[DetailDesc] [nvarchar](max) NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Rating] [tinyint] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[NidProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Settings]    Script Date: 11/8/2022 9:19:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[NidSetting] [uniqueidentifier] NOT NULL,
	[SettingAttribute] [nvarchar](max) NOT NULL,
	[SettingValue] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[NidSetting] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ships]    Script Date: 11/8/2022 9:19:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ships](
	[NidShip] [uniqueidentifier] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[DueDate] [datetime] NULL,
	[ShipVia] [tinyint] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[ZipCode] [decimal](12, 0) NOT NULL,
	[State] [tinyint] NOT NULL,
	[ShipPrice] [decimal](12, 0) NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Ships] PRIMARY KEY CLUSTERED 
(
	[NidShip] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Types]    Script Date: 11/8/2022 9:19:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Types](
	[NidType] [uniqueidentifier] NOT NULL,
	[TypeName] [nvarchar](500) NOT NULL,
	[CategoryId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Keywords] [nvarchar](max) NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastModified] [datetime] NULL,
 CONSTRAINT [PK_Types] PRIMARY KEY CLUSTERED 
(
	[NidType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/8/2022 9:19:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[NidUser] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[IsDisabled] [bit] NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NULL,
	[ZipCode] [decimal](12, 0) NULL,
	[Address] [nvarchar](max) NULL,
	[Tel] [nvarchar](25) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[NidUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Carts] ADD  CONSTRAINT [DF_Carts_Quantity]  DEFAULT ((1)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_State]  DEFAULT ((0)) FOR [State]
GO
ALTER TABLE [dbo].[Comments] ADD  CONSTRAINT [DF_Comments_State]  DEFAULT ((0)) FOR [State]
GO
ALTER TABLE [dbo].[Files] ADD  CONSTRAINT [DF_Files_Priority]  DEFAULT ((0)) FOR [Priority]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  CONSTRAINT [DF_OrderDetails_Quantity]  DEFAULT ((1)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_State]  DEFAULT ((0)) FOR [State]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_Priority]  DEFAULT ((0)) FOR [Priority]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_OffPercentage]  DEFAULT ((0)) FOR [OffPercentage]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_AvailableCount]  DEFAULT ((0)) FOR [AvailableCount]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_Rating]  DEFAULT ((3)) FOR [Rating]
GO
ALTER TABLE [dbo].[Ships] ADD  CONSTRAINT [DF_Ships_ShipVia]  DEFAULT ((0)) FOR [ShipVia]
GO
ALTER TABLE [dbo].[Ships] ADD  CONSTRAINT [DF_Ships_State]  DEFAULT ((0)) FOR [State]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsEnabled]  DEFAULT ((0)) FOR [IsDisabled]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsAdmin]  DEFAULT ((0)) FOR [IsAdmin]
GO
ALTER TABLE [dbo].[Brands]  WITH CHECK ADD  CONSTRAINT [FK_Brands_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([NidCategory])
GO
ALTER TABLE [dbo].[Brands] CHECK CONSTRAINT [FK_Brands_Categories]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([NidProduct])
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_Products]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([NidUser])
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_Users]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([NidUser])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users]
GO
ALTER TABLE [dbo].[Favorites]  WITH CHECK ADD  CONSTRAINT [FK_Favorites_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([NidProduct])
GO
ALTER TABLE [dbo].[Favorites] CHECK CONSTRAINT [FK_Favorites_Products]
GO
ALTER TABLE [dbo].[Favorites]  WITH CHECK ADD  CONSTRAINT [FK_Favorites_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([NidUser])
GO
ALTER TABLE [dbo].[Favorites] CHECK CONSTRAINT [FK_Favorites_Users]
GO
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_Brands] FOREIGN KEY([RelateId])
REFERENCES [dbo].[Brands] ([NidBrand])
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_Brands]
GO
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_Categories] FOREIGN KEY([RelateId])
REFERENCES [dbo].[Categories] ([NidCategory])
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_Categories]
GO
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_Products] FOREIGN KEY([RelateId])
REFERENCES [dbo].[Products] ([NidProduct])
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_Products]
GO
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_Types] FOREIGN KEY([RelateId])
REFERENCES [dbo].[Types] ([NidType])
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_Types]
GO
ALTER TABLE [dbo].[Links]  WITH CHECK ADD  CONSTRAINT [FK_Links_Products] FOREIGN KEY([RelateId])
REFERENCES [dbo].[Products] ([NidProduct])
GO
ALTER TABLE [dbo].[Links] CHECK CONSTRAINT [FK_Links_Products]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([NidOrder])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([NidProduct])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([NidUser])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([NidCategory])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([NidUser])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Users]
GO
ALTER TABLE [dbo].[Ships]  WITH CHECK ADD  CONSTRAINT [FK_Ships_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([NidOrder])
GO
ALTER TABLE [dbo].[Ships] CHECK CONSTRAINT [FK_Ships_Orders]
GO
ALTER TABLE [dbo].[Types]  WITH CHECK ADD  CONSTRAINT [FK_Types_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([NidCategory])
GO
ALTER TABLE [dbo].[Types] CHECK CONSTRAINT [FK_Types_Categories]
GO
USE [master]
GO
ALTER DATABASE [AudioShopDb] SET  READ_WRITE 
GO
