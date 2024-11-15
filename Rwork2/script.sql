USE [master]
GO
/****** Object:  Database [SellingCentre]    Script Date: 2024/2/26 上午 08:45:10 ******/
CREATE DATABASE [SellingCentre]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SellingCentre', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SellingCentre.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SellingCentre_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SellingCentre_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SellingCentre] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SellingCentre].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SellingCentre] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SellingCentre] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SellingCentre] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SellingCentre] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SellingCentre] SET ARITHABORT OFF 
GO
ALTER DATABASE [SellingCentre] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SellingCentre] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SellingCentre] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SellingCentre] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SellingCentre] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SellingCentre] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SellingCentre] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SellingCentre] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SellingCentre] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SellingCentre] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SellingCentre] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SellingCentre] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SellingCentre] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SellingCentre] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SellingCentre] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SellingCentre] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SellingCentre] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SellingCentre] SET RECOVERY FULL 
GO
ALTER DATABASE [SellingCentre] SET  MULTI_USER 
GO
ALTER DATABASE [SellingCentre] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SellingCentre] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SellingCentre] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SellingCentre] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SellingCentre] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SellingCentre] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SellingCentre', N'ON'
GO
ALTER DATABASE [SellingCentre] SET QUERY_STORE = OFF
GO
USE [SellingCentre]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 2024/2/26 上午 08:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[Mid] [int] IDENTITY(1001,1) NOT NULL,
	[Lid] [int] NOT NULL,
	[Mname] [nvarchar](50) NOT NULL,
	[Account] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Mid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberLevel]    Script Date: 2024/2/26 上午 08:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberLevel](
	[Lid] [int] IDENTITY(1,1) NOT NULL,
	[Lname] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Lid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2024/2/26 上午 08:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Oid] [int] IDENTITY(10001,1) NOT NULL,
	[Sid] [int] NOT NULL,
	[Pid] [int] NOT NULL,
	[Mid] [int] NOT NULL,
	[Ocount] [int] NOT NULL,
	[OPrice] [int] NOT NULL,
	[OSale] [float] NOT NULL,
	[Ototalprice]  AS (([Ocount]*[OPrice])*[OSale]),
	[OrderDate] [date] NOT NULL,
	[ODueDate] [date] NOT NULL,
	[OShipDate] [date] NULL,
	[Oremark] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Oid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdersState]    Script Date: 2024/2/26 上午 08:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdersState](
	[Sid] [int] IDENTITY(1,1) NOT NULL,
	[State] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Sid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 2024/2/26 上午 08:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Pid] [int] IDENTITY(101,1) NOT NULL,
	[Lid] [int] NOT NULL,
	[Pname] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](20) NULL,
	[Account] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Pid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonLevel]    Script Date: 2024/2/26 上午 08:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonLevel](
	[Lid] [int] IDENTITY(1,1) NOT NULL,
	[Lname] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Lid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2024/2/26 上午 08:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Pid] [int] IDENTITY(101,1) NOT NULL,
	[Sid] [int] NOT NULL,
	[Pname] [nvarchar](50) NOT NULL,
	[Pcount] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Pdesc] [nvarchar](100) NOT NULL,
	[Pimage] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Pid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductsState]    Script Date: 2024/2/26 上午 08:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductsState](
	[Sid] [int] IDENTITY(1,1) NOT NULL,
	[State] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Sid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 2024/2/26 上午 08:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase](
	[Pid] [int] IDENTITY(10001,1) NOT NULL,
	[Sid] [int] NOT NULL,
	[Personid] [int] NULL,
	[Purchaseid] [int] NULL,
	[Productid] [int] NOT NULL,
	[Pcount] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[PSale] [float] NOT NULL,
	[Ptotalprice]  AS (([Pcount]*[Price])*[PSale]),
	[Pstartdate] [date] NOT NULL,
	[Pshipdate] [date] NOT NULL,
	[Penddate] [date] NULL,
	[Premark] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK__Purchase__C570593887BAEAC5] PRIMARY KEY CLUSTERED 
(
	[Pid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseState]    Script Date: 2024/2/26 上午 08:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseState](
	[Sid] [int] IDENTITY(1,1) NOT NULL,
	[State] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Sid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseStore]    Script Date: 2024/2/26 上午 08:45:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseStore](
	[Pid] [int] IDENTITY(11,1) NOT NULL,
	[Pname] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Pid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Member] ON 

INSERT [dbo].[Member] ([Mid], [Lid], [Mname], [Account], [Password]) VALUES (1001, 5, N'野比海皇', N'god', N'god1234')
INSERT [dbo].[Member] ([Mid], [Lid], [Mname], [Account], [Password]) VALUES (1002, 4, N'劇場版胖虎', N'gph', N'gph1234')
INSERT [dbo].[Member] ([Mid], [Lid], [Mname], [Account], [Password]) VALUES (1003, 1, N'TV版胖虎', N'ph', N'ph1234')
INSERT [dbo].[Member] ([Mid], [Lid], [Mname], [Account], [Password]) VALUES (1004, 6, N'會員二君', N'101二君1', N'二君1234君1234')
SET IDENTITY_INSERT [dbo].[Member] OFF
GO
SET IDENTITY_INSERT [dbo].[MemberLevel] ON 

INSERT [dbo].[MemberLevel] ([Lid], [Lname]) VALUES (3, N'不錯的會員')
INSERT [dbo].[MemberLevel] ([Lid], [Lname]) VALUES (2, N'好一點會員')
INSERT [dbo].[MemberLevel] ([Lid], [Lname]) VALUES (6, N'真神級會員')
INSERT [dbo].[MemberLevel] ([Lid], [Lname]) VALUES (4, N'真會員')
INSERT [dbo].[MemberLevel] ([Lid], [Lname]) VALUES (5, N'神會員')
INSERT [dbo].[MemberLevel] ([Lid], [Lname]) VALUES (7, N'停權')
INSERT [dbo].[MemberLevel] ([Lid], [Lname]) VALUES (1, N'普通會員')
SET IDENTITY_INSERT [dbo].[MemberLevel] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10001, 2, 103, 1001, 10, 10, 0, CAST(N'1980-01-01' AS Date), CAST(N'1980-01-31' AS Date), CAST(N'1980-01-12' AS Date), N'現金')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10002, 1, 104, 1002, 10, 20, 1, CAST(N'1980-01-01' AS Date), CAST(N'1980-01-31' AS Date), NULL, N'現金')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10004, 1, 101, 1001, 1, 10, 1, CAST(N'2023-11-28' AS Date), CAST(N'2023-12-28' AS Date), NULL, N'現金')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10005, 1, 102, 1001, 10, 11, 1, CAST(N'2023-11-28' AS Date), CAST(N'2023-12-28' AS Date), NULL, N'現金')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10007, 1, 101, 1001, 10, 10, 1, CAST(N'2023-11-28' AS Date), CAST(N'2023-12-28' AS Date), NULL, N'現金')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10008, 1, 109, 1001, 1, 2, 1, CAST(N'2023-11-28' AS Date), CAST(N'2023-12-28' AS Date), NULL, N'購物袋')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10010, 1, 101, 1002, 100, 10, 1, CAST(N'2023-10-25' AS Date), CAST(N'2023-11-25' AS Date), CAST(N'2023-11-29' AS Date), N'現金')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10011, 1, 101, 1001, 110, 10, 1, CAST(N'1980-01-01' AS Date), CAST(N'1980-01-31' AS Date), CAST(N'1980-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10012, 2, 102, 1002, 150, 11, 1, CAST(N'1981-01-01' AS Date), CAST(N'1981-01-31' AS Date), CAST(N'1981-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10013, 3, 103, 1003, 106, 12, 1, CAST(N'1982-01-01' AS Date), CAST(N'1982-01-31' AS Date), CAST(N'1982-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10014, 4, 104, 1004, 108, 100, 1, CAST(N'1983-01-01' AS Date), CAST(N'1983-01-31' AS Date), CAST(N'1983-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10015, 5, 105, 1001, 109, 100, 1, CAST(N'1984-01-01' AS Date), CAST(N'1984-01-31' AS Date), CAST(N'1984-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10016, 6, 106, 1002, 140, 100, 1, CAST(N'1985-01-01' AS Date), CAST(N'1985-01-31' AS Date), CAST(N'1985-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10017, 7, 107, 1003, 180, 10, 1, CAST(N'1986-01-01' AS Date), CAST(N'1986-01-31' AS Date), CAST(N'1986-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10018, 1, 101, 1004, 109, 10, 1, CAST(N'1987-01-01' AS Date), CAST(N'1987-01-31' AS Date), CAST(N'1987-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10019, 2, 102, 1001, 910, 11, 1, CAST(N'1988-01-01' AS Date), CAST(N'1988-01-31' AS Date), CAST(N'1988-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10020, 3, 103, 1002, 180, 12, 1, CAST(N'1989-01-01' AS Date), CAST(N'1989-01-31' AS Date), CAST(N'1989-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10021, 4, 104, 1003, 104, 100, 1, CAST(N'2000-01-01' AS Date), CAST(N'2000-01-31' AS Date), CAST(N'2000-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10022, 5, 105, 1004, 150, 100, 1, CAST(N'2022-01-01' AS Date), CAST(N'2022-01-31' AS Date), CAST(N'2022-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10023, 5, 105, 1004, 190, 100, 1, CAST(N'2022-10-01' AS Date), CAST(N'2022-10-31' AS Date), CAST(N'2022-10-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10024, 5, 105, 1004, 105, 100, 1, CAST(N'2022-11-01' AS Date), CAST(N'2022-12-01' AS Date), CAST(N'2022-11-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10025, 5, 105, 1004, 102, 100, 1, CAST(N'2022-12-01' AS Date), CAST(N'2022-12-31' AS Date), CAST(N'2022-12-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10026, 5, 105, 1004, 104, 100, 1, CAST(N'2022-12-31' AS Date), CAST(N'2023-01-30' AS Date), CAST(N'2023-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10027, 1, 101, 1003, 101, 10, 1, CAST(N'2023-10-01' AS Date), CAST(N'2023-10-31' AS Date), CAST(N'2023-10-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10028, 6, 106, 1001, 150, 100, 1, CAST(N'2023-11-01' AS Date), CAST(N'2023-12-01' AS Date), CAST(N'2023-11-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10029, 7, 107, 1002, 610, 10, 1, CAST(N'2023-12-01' AS Date), CAST(N'2023-12-31' AS Date), CAST(N'2023-12-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10030, 1, 101, 1001, 110, 10, 1, CAST(N'1990-01-01' AS Date), CAST(N'1990-01-31' AS Date), CAST(N'1990-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10031, 2, 102, 1002, 150, 11, 1, CAST(N'1991-01-01' AS Date), CAST(N'1991-01-31' AS Date), CAST(N'1991-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10032, 3, 103, 1003, 106, 12, 1, CAST(N'1992-01-01' AS Date), CAST(N'1992-01-31' AS Date), CAST(N'1992-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10033, 4, 104, 1004, 108, 100, 1, CAST(N'1993-01-01' AS Date), CAST(N'1993-01-31' AS Date), CAST(N'1993-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10034, 5, 105, 1001, 109, 100, 1, CAST(N'1994-01-01' AS Date), CAST(N'1994-01-31' AS Date), CAST(N'1994-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10035, 6, 106, 1002, 140, 100, 1, CAST(N'1995-01-01' AS Date), CAST(N'1995-01-31' AS Date), CAST(N'1995-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10036, 7, 107, 1003, 180, 10, 1, CAST(N'1996-01-01' AS Date), CAST(N'1996-01-31' AS Date), CAST(N'1996-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10037, 1, 101, 1004, 109, 10, 1, CAST(N'1997-01-01' AS Date), CAST(N'1997-01-31' AS Date), CAST(N'1997-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10038, 2, 102, 1001, 910, 11, 1, CAST(N'1998-01-01' AS Date), CAST(N'1998-01-31' AS Date), CAST(N'1998-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10039, 3, 103, 1002, 180, 12, 1, CAST(N'1999-01-01' AS Date), CAST(N'1999-01-31' AS Date), CAST(N'1999-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10040, 7, 107, 1003, 180, 10, 1, CAST(N'2014-01-01' AS Date), CAST(N'2014-01-31' AS Date), CAST(N'2014-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10041, 1, 101, 1001, 110, 10, 1, CAST(N'2015-01-01' AS Date), CAST(N'2015-01-31' AS Date), CAST(N'2015-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10042, 2, 102, 1002, 150, 11, 1, CAST(N'2016-01-01' AS Date), CAST(N'2016-01-31' AS Date), CAST(N'2016-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10043, 3, 103, 1003, 106, 12, 1, CAST(N'2017-01-01' AS Date), CAST(N'2017-01-31' AS Date), CAST(N'2017-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10044, 4, 104, 1004, 108, 100, 1, CAST(N'2018-01-01' AS Date), CAST(N'2018-01-31' AS Date), CAST(N'2018-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10045, 5, 105, 1001, 109, 100, 1, CAST(N'2019-01-01' AS Date), CAST(N'2019-01-31' AS Date), CAST(N'2019-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10046, 6, 106, 1002, 140, 100, 1, CAST(N'2020-01-01' AS Date), CAST(N'2020-01-31' AS Date), CAST(N'2020-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10047, 7, 107, 1003, 180, 10, 1, CAST(N'2021-01-01' AS Date), CAST(N'2021-01-31' AS Date), CAST(N'2021-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10048, 1, 101, 1001, 110, 10, 1, CAST(N'2001-01-01' AS Date), CAST(N'2001-01-31' AS Date), CAST(N'2001-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10049, 2, 102, 1002, 150, 11, 1, CAST(N'2002-01-01' AS Date), CAST(N'2002-01-31' AS Date), CAST(N'2002-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10050, 3, 103, 1003, 106, 12, 1, CAST(N'2003-01-01' AS Date), CAST(N'2003-01-31' AS Date), CAST(N'2003-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10051, 4, 104, 1004, 108, 100, 1, CAST(N'2004-01-01' AS Date), CAST(N'2004-01-31' AS Date), CAST(N'2004-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10052, 5, 105, 1001, 109, 100, 1, CAST(N'2005-01-01' AS Date), CAST(N'2005-01-31' AS Date), CAST(N'2005-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10053, 6, 106, 1002, 140, 100, 1, CAST(N'2006-01-01' AS Date), CAST(N'2006-01-31' AS Date), CAST(N'2006-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10054, 7, 107, 1003, 180, 10, 1, CAST(N'2007-01-01' AS Date), CAST(N'2007-01-31' AS Date), CAST(N'2007-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10055, 1, 101, 1001, 110, 10, 1, CAST(N'2008-01-01' AS Date), CAST(N'2008-01-31' AS Date), CAST(N'2008-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10056, 2, 102, 1002, 150, 11, 1, CAST(N'2009-01-01' AS Date), CAST(N'2009-01-31' AS Date), CAST(N'2009-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10057, 3, 103, 1003, 106, 12, 1, CAST(N'2010-01-01' AS Date), CAST(N'2010-01-31' AS Date), CAST(N'2010-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10058, 4, 104, 1004, 108, 100, 1, CAST(N'2011-01-01' AS Date), CAST(N'2011-01-31' AS Date), CAST(N'2011-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10059, 5, 105, 1001, 109, 100, 1, CAST(N'2012-01-01' AS Date), CAST(N'2012-01-31' AS Date), CAST(N'2012-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10060, 6, 106, 1002, 140, 100, 1, CAST(N'2013-01-01' AS Date), CAST(N'2013-01-31' AS Date), CAST(N'2013-01-12' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10061, 6, 106, 1001, 150, 100, 1, CAST(N'2023-11-05' AS Date), CAST(N'2023-12-05' AS Date), CAST(N'2023-11-17' AS Date), N'')
INSERT [dbo].[Orders] ([Oid], [Sid], [Pid], [Mid], [Ocount], [OPrice], [OSale], [OrderDate], [ODueDate], [OShipDate], [Oremark]) VALUES (10062, 6, 106, 1001, 150, 100, 1, CAST(N'2023-11-05' AS Date), CAST(N'2023-12-05' AS Date), CAST(N'2023-11-17' AS Date), N'')
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[OrdersState] ON 

INSERT [dbo].[OrdersState] ([Sid], [State]) VALUES (5, N'已到貨')
INSERT [dbo].[OrdersState] ([Sid], [State]) VALUES (3, N'出貨前')
INSERT [dbo].[OrdersState] ([Sid], [State]) VALUES (6, N'延遲出貨')
INSERT [dbo].[OrdersState] ([Sid], [State]) VALUES (7, N'退貨')
INSERT [dbo].[OrdersState] ([Sid], [State]) VALUES (2, N'補貨中')
INSERT [dbo].[OrdersState] ([Sid], [State]) VALUES (4, N'運輸中')
INSERT [dbo].[OrdersState] ([Sid], [State]) VALUES (1, N'審理中')
SET IDENTITY_INSERT [dbo].[OrdersState] OFF
GO
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([Pid], [Lid], [Pname], [Phone], [Account], [Password]) VALUES (101, 6, N'二君', N'09-8765-4321', N'101二君', N'二君1234君1234')
INSERT [dbo].[Person] ([Pid], [Lid], [Pname], [Phone], [Account], [Password]) VALUES (102, 5, N'A君', N'', N'102A君帳', N'君1234')
INSERT [dbo].[Person] ([Pid], [Lid], [Pname], [Phone], [Account], [Password]) VALUES (103, 4, N'B君', N'', N'103B君帳', N'B君1234')
INSERT [dbo].[Person] ([Pid], [Lid], [Pname], [Phone], [Account], [Password]) VALUES (104, 3, N'C君', N'', N'104C君帳', N'君1234')
INSERT [dbo].[Person] ([Pid], [Lid], [Pname], [Phone], [Account], [Password]) VALUES (105, 1, N'D君', N'', N'105D君帳', N'D君1234')
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
SET IDENTITY_INSERT [dbo].[PersonLevel] ON 

INSERT [dbo].[PersonLevel] ([Lid], [Lname]) VALUES (6, N'老闆')
INSERT [dbo].[PersonLevel] ([Lid], [Lname]) VALUES (3, N'店長')
INSERT [dbo].[PersonLevel] ([Lid], [Lname]) VALUES (1, N'員工')
INSERT [dbo].[PersonLevel] ([Lid], [Lname]) VALUES (7, N'停權')
INSERT [dbo].[PersonLevel] ([Lid], [Lname]) VALUES (2, N'副店長')
INSERT [dbo].[PersonLevel] ([Lid], [Lname]) VALUES (4, N'副經理')
INSERT [dbo].[PersonLevel] ([Lid], [Lname]) VALUES (5, N'經理')
SET IDENTITY_INSERT [dbo].[PersonLevel] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Pid], [Sid], [Pname], [Pcount], [Price], [Pdesc], [Pimage]) VALUES (101, 4, N'紅豆', 50, 10, N'紅豆製成', N'')
INSERT [dbo].[Products] ([Pid], [Sid], [Pname], [Pcount], [Price], [Pdesc], [Pimage]) VALUES (102, 4, N'奶油', 10, 11, N'經典款', N'')
INSERT [dbo].[Products] ([Pid], [Sid], [Pname], [Pcount], [Price], [Pdesc], [Pimage]) VALUES (103, 5, N'巧克力', 0, 12, N'CEO的最愛', N'')
INSERT [dbo].[Products] ([Pid], [Sid], [Pname], [Pcount], [Price], [Pdesc], [Pimage]) VALUES (104, 4, N'炒麵', 100, 100, N'唯一正常的鹹', N'')
INSERT [dbo].[Products] ([Pid], [Sid], [Pname], [Pcount], [Price], [Pdesc], [Pimage]) VALUES (105, 9, N'伊勢龍蝦', 0, 10000, N'偽神', N'')
INSERT [dbo].[Products] ([Pid], [Sid], [Pname], [Pcount], [Price], [Pdesc], [Pimage]) VALUES (106, 4, N'鯡魚', 1, 1000000, N'神', N'')
INSERT [dbo].[Products] ([Pid], [Sid], [Pname], [Pcount], [Price], [Pdesc], [Pimage]) VALUES (107, 3, N'綠豆', 100, 10, N'CEO不喜歡', N'')
INSERT [dbo].[Products] ([Pid], [Sid], [Pname], [Pcount], [Price], [Pdesc], [Pimage]) VALUES (109, 2, N'購物袋', 9999, 2, N'購物袋', N'')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductsState] ON 

INSERT [dbo].[ProductsState] ([Sid], [State]) VALUES (8, N'下架中')
INSERT [dbo].[ProductsState] ([Sid], [State]) VALUES (4, N'上架中')
INSERT [dbo].[ProductsState] ([Sid], [State]) VALUES (9, N'已下架')
INSERT [dbo].[ProductsState] ([Sid], [State]) VALUES (2, N'未上架')
INSERT [dbo].[ProductsState] ([Sid], [State]) VALUES (5, N'缺貨中')
INSERT [dbo].[ProductsState] ([Sid], [State]) VALUES (6, N'進貨中')
INSERT [dbo].[ProductsState] ([Sid], [State]) VALUES (1, N'開發中')
INSERT [dbo].[ProductsState] ([Sid], [State]) VALUES (7, N'補貨中')
INSERT [dbo].[ProductsState] ([Sid], [State]) VALUES (3, N'審理中')
SET IDENTITY_INSERT [dbo].[ProductsState] OFF
GO
SET IDENTITY_INSERT [dbo].[Purchase] ON 

INSERT [dbo].[Purchase] ([Pid], [Sid], [Personid], [Purchaseid], [Productid], [Pcount], [Price], [PSale], [Pstartdate], [Pshipdate], [Penddate], [Premark]) VALUES (10001, 1, 101, 11, 102, 2, 100, 1, CAST(N'1980-01-01' AS Date), CAST(N'1980-01-31' AS Date), CAST(N'1980-01-12' AS Date), N'')
INSERT [dbo].[Purchase] ([Pid], [Sid], [Personid], [Purchaseid], [Productid], [Pcount], [Price], [PSale], [Pstartdate], [Pshipdate], [Penddate], [Premark]) VALUES (10002, 1, 102, 12, 103, 3, 200, 1, CAST(N'1980-01-01' AS Date), CAST(N'1980-01-31' AS Date), NULL, N'')
SET IDENTITY_INSERT [dbo].[Purchase] OFF
GO
SET IDENTITY_INSERT [dbo].[PurchaseState] ON 

INSERT [dbo].[PurchaseState] ([Sid], [State]) VALUES (5, N'已到貨')
INSERT [dbo].[PurchaseState] ([Sid], [State]) VALUES (3, N'出貨前')
INSERT [dbo].[PurchaseState] ([Sid], [State]) VALUES (6, N'延遲出貨')
INSERT [dbo].[PurchaseState] ([Sid], [State]) VALUES (7, N'退貨')
INSERT [dbo].[PurchaseState] ([Sid], [State]) VALUES (2, N'補貨中')
INSERT [dbo].[PurchaseState] ([Sid], [State]) VALUES (4, N'運輸中')
INSERT [dbo].[PurchaseState] ([Sid], [State]) VALUES (1, N'審理中')
SET IDENTITY_INSERT [dbo].[PurchaseState] OFF
GO
SET IDENTITY_INSERT [dbo].[PurchaseStore] ON 

INSERT [dbo].[PurchaseStore] ([Pid], [Pname], [Phone]) VALUES (11, N'二君股份有限公司', N'09-1234-5678')
INSERT [dbo].[PurchaseStore] ([Pid], [Pname], [Phone]) VALUES (12, N'藤子國際', N'')
SET IDENTITY_INSERT [dbo].[PurchaseStore] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Member__B0C3AC4676CFE442]    Script Date: 2024/2/26 上午 08:45:11 ******/
ALTER TABLE [dbo].[Member] ADD UNIQUE NONCLUSTERED 
(
	[Account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Member__D3C738F11020D536]    Script Date: 2024/2/26 上午 08:45:11 ******/
ALTER TABLE [dbo].[Member] ADD UNIQUE NONCLUSTERED 
(
	[Mname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__MemberLe__8CFE8A7D3524B4F6]    Script Date: 2024/2/26 上午 08:45:11 ******/
ALTER TABLE [dbo].[MemberLevel] ADD UNIQUE NONCLUSTERED 
(
	[Lname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__OrdersSt__BA803DADA4C52693]    Script Date: 2024/2/26 上午 08:45:11 ******/
ALTER TABLE [dbo].[OrdersState] ADD UNIQUE NONCLUSTERED 
(
	[State] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Person__173BB01C77D8309D]    Script Date: 2024/2/26 上午 08:45:11 ******/
ALTER TABLE [dbo].[Person] ADD UNIQUE NONCLUSTERED 
(
	[Pname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Person__B0C3AC4612FFB081]    Script Date: 2024/2/26 上午 08:45:11 ******/
ALTER TABLE [dbo].[Person] ADD UNIQUE NONCLUSTERED 
(
	[Account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__PersonLe__8CFE8A7DED43FE66]    Script Date: 2024/2/26 上午 08:45:11 ******/
ALTER TABLE [dbo].[PersonLevel] ADD UNIQUE NONCLUSTERED 
(
	[Lname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Products__173BB01C1736DBF2]    Script Date: 2024/2/26 上午 08:45:11 ******/
ALTER TABLE [dbo].[Products] ADD UNIQUE NONCLUSTERED 
(
	[Pname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Products__BA803DAD1E38F709]    Script Date: 2024/2/26 上午 08:45:11 ******/
ALTER TABLE [dbo].[ProductsState] ADD UNIQUE NONCLUSTERED 
(
	[State] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Purchase__BA803DAD10F230B0]    Script Date: 2024/2/26 上午 08:45:11 ******/
ALTER TABLE [dbo].[PurchaseState] ADD UNIQUE NONCLUSTERED 
(
	[State] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Purchase__173BB01C05A39153]    Script Date: 2024/2/26 上午 08:45:11 ******/
ALTER TABLE [dbo].[PurchaseStore] ADD UNIQUE NONCLUSTERED 
(
	[Pname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Member] ADD  DEFAULT ((1)) FOR [Lid]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((1)) FOR [Sid]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_OSale]  DEFAULT ((1)) FOR [OSale]
GO
ALTER TABLE [dbo].[Person] ADD  DEFAULT ((1)) FOR [Lid]
GO
ALTER TABLE [dbo].[Person] ADD  DEFAULT ('君1234') FOR [Password]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((2)) FOR [Sid]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ('無描述') FOR [Pdesc]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ('00000') FOR [Pimage]
GO
ALTER TABLE [dbo].[Purchase] ADD  CONSTRAINT [DF__Purchase__Sid__6C390A4C]  DEFAULT ((1)) FOR [Sid]
GO
ALTER TABLE [dbo].[Member]  WITH CHECK ADD FOREIGN KEY([Lid])
REFERENCES [dbo].[MemberLevel] ([Lid])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([Mid])
REFERENCES [dbo].[Member] ([Mid])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([Pid])
REFERENCES [dbo].[Products] ([Pid])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([Sid])
REFERENCES [dbo].[OrdersState] ([Sid])
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD FOREIGN KEY([Lid])
REFERENCES [dbo].[PersonLevel] ([Lid])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([Sid])
REFERENCES [dbo].[ProductsState] ([Sid])
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK__Purchase__Person__6E2152BE] FOREIGN KEY([Personid])
REFERENCES [dbo].[Person] ([Pid])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK__Purchase__Person__6E2152BE]
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK__Purchase__Produc__70099B30] FOREIGN KEY([Productid])
REFERENCES [dbo].[Products] ([Pid])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK__Purchase__Produc__70099B30]
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK__Purchase__Purcha__6F1576F7] FOREIGN KEY([Purchaseid])
REFERENCES [dbo].[PurchaseStore] ([Pid])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK__Purchase__Purcha__6F1576F7]
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK__Purchase__Sid__6D2D2E85] FOREIGN KEY([Sid])
REFERENCES [dbo].[PurchaseState] ([Sid])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK__Purchase__Sid__6D2D2E85]
GO
USE [master]
GO
ALTER DATABASE [SellingCentre] SET  READ_WRITE 
GO
