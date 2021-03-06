USE [QLTLKH]
GO
/****** Object:  Table [dbo].[ChuyenNganh]    Script Date: 14/05/2021 9:20:28 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuyenNganh](
	[MaCN] [char](10) NOT NULL,
	[TenCN] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTHD]    Script Date: 14/05/2021 9:20:28 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHD](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaHD] [char](14) NULL,
	[MaTL] [char](10) NULL,
	[Loai] [int] NULL,
	[SL] [int] NULL,
	[ThanhTien] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 14/05/2021 9:20:28 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [char](14) NOT NULL,
	[NgayLap] [datetime] NULL,
	[MaNV] [char](10) NULL,
	[MaKH] [char](11) NULL,
	[TongTien] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 14/05/2021 9:20:28 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [char](11) NOT NULL,
	[TenKH] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 14/05/2021 9:20:28 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [char](10) NOT NULL,
	[TenNV] [nvarchar](max) NULL,
	[TDN] [char](20) NULL,
	[MK] [nvarchar](max) NULL,
	[SDT] [char](11) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[GioiTinh] [int] NULL,
	[NgaySinh] [datetime] NULL,
	[Role] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NXB]    Script Date: 14/05/2021 9:20:28 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NXB](
	[MaNXB] [char](10) NOT NULL,
	[TenNXB] [nvarchar](max) NULL,
	[SDT] [char](11) NULL,
	[DiaChi] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNXB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TacGia]    Script Date: 14/05/2021 9:20:28 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TacGia](
	[MaTG] [char](10) NOT NULL,
	[TenTG] [nvarchar](max) NULL,
	[GioiTinh] [int] NULL,
	[SDT] [char](11) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TLKH]    Script Date: 14/05/2021 9:20:28 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TLKH](
	[MaTL] [char](10) NOT NULL,
	[TenTL] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
	[MaTG] [char](10) NULL,
	[MaCN] [char](10) NULL,
	[MaNXB] [char](10) NULL,
	[SoTrang] [int] NULL,
	[ThoiGianNhap] [datetime] NULL,
	[GiaBan] [bigint] NULL,
	[GiaThue] [bigint] NULL,
	[MaVach] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[ChuyenNganh] ([MaCN], [TenCN], [MoTa]) VALUES (N'CN01      ', N'Chuyên ngành 01', N'áđacsa')
GO
SET IDENTITY_INSERT [dbo].[CTHD] ON 

INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1, N'20042021161235', N'TL01      ', 0, NULL, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (2, N'20042021161424', N'TL01      ', 1, NULL, 65000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (3, N'20042021161438', N'TL01      ', 1, NULL, 65000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (4, N'20042021161442', N'TL01      ', 0, NULL, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (5, N'20042021161450', N'TL01      ', 0, NULL, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (6, N'20042021161521', N'TL01      ', 0, NULL, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (7, N'20042021161525', N'TL01      ', 1, NULL, 65000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (8, N'20042021161641', N'TL01      ', 0, NULL, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (9, N'20042021161644', N'TL01      ', 1, NULL, 65000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (10, N'20042021161651', N'TL01      ', 0, NULL, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (11, N'20042021161709', N'TL01      ', 0, NULL, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (12, N'20042021161709', N'TL01      ', 1, NULL, 65000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (13, N'20042021161709', N'TL01      ', 0, NULL, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (14, N'20042021161724', N'TL01      ', 1, NULL, 65000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (15, N'20042021161724', N'TL01      ', 0, NULL, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (16, N'20042021161724', N'TL01      ', 1, NULL, 65000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (17, N'20042021161900', N'TL01      ', 0, NULL, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (18, N'20042021161928', N'TL01      ', 0, NULL, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (19, N'20042021162323', N'TL01      ', 0, NULL, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (20, N'20042021162435', N'TL01      ', 0, NULL, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (29, N'21042021132732', N'TL01      ', 0, NULL, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (30, N'21042021132732', N'TL02      ', 0, NULL, 70000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (31, N'24042021142502', N'TL01      ', 0, NULL, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (32, N'24042021143553', N'TL01      ', 0, NULL, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (33, N'27042021000536', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (34, N'27042021000536', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (35, N'27042021003127', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (36, N'27042021003127', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (37, N'27042021003408', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (38, N'27042021003408', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (39, N'27042021003408', N'TL02      ', 0, 1, 70000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (40, N'27042021003433', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (41, N'27042021003433', N'TL01      ', 1, 1, 65000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (42, N'27042021003433', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (43, N'28042021194501', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (44, N'28042021194501', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (45, N'28042021194501', N'TL02      ', 1, 1, 90000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (46, N'28042021194501', N'TL02      ', 0, 1, 70000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (47, N'28042021195518', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (48, N'28042021195518', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (49, N'28042021195907', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (50, N'28042021201140', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (51, N'28042021201255', N'TL01      ', 1, 1, 65000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (52, N'28042021201623', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (53, N'28042021201928', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (54, N'28042021202048', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (55, N'28042021202309', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (56, N'28042021202518', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (57, N'28042021202710', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (58, N'28042021202936', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (59, N'28042021203033', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (60, N'28042021203212', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (61, N'28042021203259', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (62, N'28042021203651', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (63, N'28042021205057', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (64, N'28042021205625', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (65, N'28042021205625', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (66, N'28042021205625', N'TL02      ', 1, 1, 90000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1043, N'28042021205625', N'TL03      ', 0, 1, 80000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1044, N'28042021205625', N'TL03      ', 0, 1, 80000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1045, N'28042021205625', N'TL03      ', 1, 1, 105000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1046, N'28042021205625', N'TL02      ', 0, 1, 70000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1047, N'28042021205625', N'TL02      ', 1, 1, 90000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1048, N'28042021205625', N'TL02      ', 0, 1, 70000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1049, N'28042021205625', N'TL01      ', 1, 1, 65000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1050, N'28042021205625', N'TL02      ', 0, 1, 70000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1051, N'28042021205625', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1052, N'28042021205625', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1053, N'28042021205625', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1054, N'01052021102622', N'TL02      ', 0, 1, 70000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1055, N'01052021102645', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1056, N'01052021102645', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1057, N'01052021102645', N'TL01      ', 1, 1, 65000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1058, N'01052021102645', N'TL02      ', 1, 1, 90000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1059, N'01052021102645', N'TL02      ', 0, 1, 70000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1060, N'01052021102645', N'TL02      ', 1, 1, 90000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1061, N'01052021103004', N'TL03      ', 0, 1, 80000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1062, N'01052021103129', N'TL03      ', 0, 1, 80000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1063, N'01052021103129', N'TL02      ', 0, 1, 70000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1064, N'01052021104002', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1065, N'01052021104002', N'TL01      ', 1, 1, 65000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (1066, N'01052021110303', N'TL03      ', 0, 1, 80000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (2066, N'05052021114004', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (3066, N'08052021145826', N'TL03      ', 0, 1, 80000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (3067, N'08052021145826', N'TL03      ', 0, 1, 80000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (3068, N'08052021145902', N'TL02      ', 0, 1, 70000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (3069, N'08052021145902', N'TL01      ', 0, 1, 50000)
INSERT [dbo].[CTHD] ([ID], [MaHD], [MaTL], [Loai], [SL], [ThanhTien]) VALUES (3070, N'08052021145902', N'TL02      ', 0, 1, 70000)
SET IDENTITY_INSERT [dbo].[CTHD] OFF
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'01052021100304', CAST(N'2021-05-01T10:03:04.270' AS DateTime), N'admin     ', NULL, 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'01052021100316', CAST(N'2021-05-01T10:03:16.357' AS DateTime), N'admin     ', NULL, 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'01052021100358', CAST(N'2021-05-01T10:03:58.753' AS DateTime), N'admin     ', NULL, 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'01052021100428', CAST(N'2021-05-01T10:04:28.910' AS DateTime), N'admin     ', NULL, 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'01052021100549', CAST(N'2021-05-01T10:05:49.360' AS DateTime), N'admin     ', NULL, 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'01052021100936', CAST(N'2021-05-01T10:09:36.790' AS DateTime), N'admin     ', NULL, 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'01052021101010', CAST(N'2021-05-01T10:10:10.623' AS DateTime), N'admin     ', NULL, 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'01052021101426', CAST(N'2021-05-01T10:14:26.473' AS DateTime), N'admin     ', NULL, 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'01052021102210', CAST(N'2021-05-01T10:22:10.007' AS DateTime), N'admin     ', NULL, 0)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'01052021102622', CAST(N'2021-05-01T10:26:22.823' AS DateTime), N'admin     ', N'0926633452 ', 70000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'01052021102645', CAST(N'2021-05-01T10:26:45.827' AS DateTime), N'admin     ', N'21312312   ', 415000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'01052021103004', CAST(N'2021-05-01T10:30:04.830' AS DateTime), N'admin     ', N'24345      ', 80000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'01052021103129', CAST(N'2021-05-01T10:31:29.143' AS DateTime), N'admin     ', N'24345      ', 150000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'01052021104002', CAST(N'2021-05-01T10:40:02.223' AS DateTime), N'admin     ', N'24345      ', 115000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'01052021110303', CAST(N'2021-05-01T11:03:03.940' AS DateTime), N'admin     ', N'23412312   ', 80000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'05052021114004', CAST(N'2021-05-05T11:40:04.473' AS DateTime), N'admin     ', N'12413412   ', 50000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'08052021145826', CAST(N'2021-05-08T14:58:26.307' AS DateTime), N'admin     ', NULL, 160000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'08052021145902', CAST(N'2021-05-08T14:59:02.187' AS DateTime), N'admin     ', N'234234     ', 190000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'20042021161235', CAST(N'2021-04-20T16:12:35.430' AS DateTime), N'admin     ', NULL, NULL)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'20042021161424', CAST(N'2021-04-20T16:14:24.820' AS DateTime), N'admin     ', NULL, NULL)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'20042021161438', CAST(N'2021-04-20T16:14:38.377' AS DateTime), N'admin     ', NULL, NULL)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'20042021161442', CAST(N'2021-04-20T16:14:42.190' AS DateTime), N'admin     ', NULL, NULL)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'20042021161450', CAST(N'2021-04-20T16:14:50.820' AS DateTime), N'admin     ', NULL, NULL)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'20042021161521', CAST(N'2021-04-20T16:15:21.713' AS DateTime), N'admin     ', NULL, NULL)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'20042021161525', CAST(N'2021-04-20T16:15:25.653' AS DateTime), N'admin     ', NULL, NULL)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'20042021161641', CAST(N'2021-04-20T16:16:41.770' AS DateTime), N'admin     ', NULL, NULL)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'20042021161644', CAST(N'2021-04-20T16:16:44.627' AS DateTime), N'admin     ', NULL, NULL)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'20042021161651', CAST(N'2021-04-20T16:16:51.903' AS DateTime), N'admin     ', NULL, NULL)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'20042021161709', CAST(N'2021-04-20T16:17:09.817' AS DateTime), N'admin     ', NULL, NULL)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'20042021161724', CAST(N'2021-04-20T16:17:24.313' AS DateTime), N'admin     ', NULL, NULL)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'20042021161900', CAST(N'2021-04-20T16:19:00.117' AS DateTime), N'admin     ', NULL, 50000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'20042021161928', CAST(N'2021-04-20T16:19:28.280' AS DateTime), N'admin     ', NULL, 50000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'20042021162323', CAST(N'2021-04-20T16:23:23.693' AS DateTime), N'admin     ', NULL, 50000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'20042021162435', CAST(N'2021-04-20T16:24:35.380' AS DateTime), N'admin     ', NULL, 50000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'21042021132732', CAST(N'2021-04-21T13:27:32.403' AS DateTime), N'admin     ', N'0926633451 ', 120000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'24042021142502', CAST(N'2021-04-24T14:25:02.957' AS DateTime), N'admin     ', N'0926633451 ', 50000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'24042021143553', CAST(N'2021-04-24T14:35:53.507' AS DateTime), N'admin     ', N'0926633451 ', 50000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'27042021000536', CAST(N'2021-04-27T00:05:36.060' AS DateTime), N'admin     ', NULL, 100000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'27042021003127', CAST(N'2021-04-27T00:31:27.347' AS DateTime), N'admin     ', N'0926633451 ', 100000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'27042021003408', CAST(N'2021-04-27T00:34:08.530' AS DateTime), N'admin     ', N'0926633451 ', 170000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'27042021003433', CAST(N'2021-04-27T00:34:33.217' AS DateTime), N'admin     ', N'0926633451 ', 165000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'28042021194501', CAST(N'2021-04-28T19:45:01.313' AS DateTime), N'admin     ', N'0926633451 ', 260000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'28042021195518', CAST(N'2021-04-28T19:55:18.860' AS DateTime), N'admin     ', N'0926633452 ', 100000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'28042021195907', CAST(N'2021-04-28T19:59:07.587' AS DateTime), N'admin     ', N'0926633451 ', 50000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'28042021201140', CAST(N'2021-04-28T20:11:40.893' AS DateTime), N'admin     ', N'0926633452 ', 50000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'28042021201255', CAST(N'2021-04-28T20:12:55.847' AS DateTime), N'admin     ', N'0926633452 ', 65000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'28042021201623', CAST(N'2021-04-28T20:16:23.747' AS DateTime), N'admin     ', N'0926633452 ', 50000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'28042021201928', CAST(N'2021-04-28T20:19:28.430' AS DateTime), N'admin     ', N'0926633452 ', 50000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'28042021202048', CAST(N'2021-04-28T20:20:48.923' AS DateTime), N'admin     ', N'0926633451 ', 50000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'28042021202309', CAST(N'2021-04-28T20:23:09.060' AS DateTime), N'admin     ', N'0926633452 ', 50000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'28042021202518', CAST(N'2021-04-28T20:25:18.190' AS DateTime), N'admin     ', N'0926633451 ', 50000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'28042021202710', CAST(N'2021-04-28T20:27:10.687' AS DateTime), N'admin     ', N'0926633451 ', 50000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'28042021202936', CAST(N'2021-04-28T20:29:36.753' AS DateTime), N'admin     ', N'0926633451 ', 50000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'28042021203033', CAST(N'2021-04-28T20:30:33.620' AS DateTime), N'admin     ', N'0926633452 ', 50000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'28042021203212', CAST(N'2021-04-28T20:32:12.173' AS DateTime), N'admin     ', N'0926633451 ', 50000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'28042021203259', CAST(N'2021-04-28T20:32:59.787' AS DateTime), N'admin     ', N'0926633452 ', 50000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'28042021203651', CAST(N'2021-04-28T20:36:51.320' AS DateTime), N'admin     ', N'0926633452 ', 50000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'28042021205057', CAST(N'2021-04-28T20:50:57.483' AS DateTime), N'admin     ', N'0926633452 ', 50000)
INSERT [dbo].[HoaDon] ([MaHD], [NgayLap], [MaNV], [MaKH], [TongTien]) VALUES (N'28042021205625', CAST(N'2021-04-28T20:56:25.263' AS DateTime), N'admin     ', N'0926633451 ', 970000)
GO
INSERT [dbo].[KhachHang] ([MaKH], [TenKH]) VALUES (N'0926633451 ', N'Nguyễn 1')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH]) VALUES (N'0926633452 ', N'Nguyễn 2')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH]) VALUES (N'12413412   ', N'Nguyễn 3')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH]) VALUES (N'21312312   ', N'Nguyễn 4')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH]) VALUES (N'23412312   ', N'Nguyễn 5')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH]) VALUES (N'234234     ', N'Nguyễn 6')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH]) VALUES (N'24345      ', N'Nguyễn 7')
GO
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [TDN], [MK], [SDT], [DiaChi], [GioiTinh], [NgaySinh], [Role]) VALUES (N'ADMIN     ', N'Administrator', N'admin               ', N'admin', N'0123456789 ', N'Cần Thơ', 0, CAST(N'2001-04-30T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [TDN], [MK], [SDT], [DiaChi], [GioiTinh], [NgaySinh], [Role]) VALUES (N'nv01      ', N'Nhân viên 01', N'nv01                ', N'1', N'01231435443', N'dsfsfsdf', 0, CAST(N'1888-04-21T00:00:00.000' AS DateTime), 0)
GO
INSERT [dbo].[NXB] ([MaNXB], [TenNXB], [SDT], [DiaChi]) VALUES (N'NXB01     ', N'Nhà xuất bản 01', N'0123435536 ', N'cấcf 234124')
GO
INSERT [dbo].[TacGia] ([MaTG], [TenTG], [GioiTinh], [SDT], [DiaChi], [Email]) VALUES (N'TG01      ', N'Tác giả 01', 0, N'0123124    ', N'ưcqc', N'e12ce1@gmail.com')
GO
INSERT [dbo].[TLKH] ([MaTL], [TenTL], [MoTa], [MaTG], [MaCN], [MaNXB], [SoTrang], [ThoiGianNhap], [GiaBan], [GiaThue], [MaVach]) VALUES (N'TL01      ', N'Tài liệu 01', N'Mô tả tài liệu 01', N'TG01      ', N'CN01      ', N'NXB01     ', 100, CAST(N'2021-04-16T16:06:16.000' AS DateTime), 50000, 15000, N'123456')
INSERT [dbo].[TLKH] ([MaTL], [TenTL], [MoTa], [MaTG], [MaCN], [MaNXB], [SoTrang], [ThoiGianNhap], [GiaBan], [GiaThue], [MaVach]) VALUES (N'TL02      ', N'Tài liệu 02', N'Mô tả tài liệu 2', N'TG01      ', N'CN01      ', N'NXB01     ', 100, CAST(N'2021-04-16T16:06:16.000' AS DateTime), 70000, 20000, N'123457')
INSERT [dbo].[TLKH] ([MaTL], [TenTL], [MoTa], [MaTG], [MaCN], [MaNXB], [SoTrang], [ThoiGianNhap], [GiaBan], [GiaThue], [MaVach]) VALUES (N'TL03      ', N'Tài liệu 03', N'chuyên về IT', N'TG01      ', N'CN01      ', N'NXB01     ', 50, CAST(N'2021-04-16T16:06:16.000' AS DateTime), 80000, 25000, N'345689')
GO
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_HoaDon] FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDon] ([MaHD])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CTHD] CHECK CONSTRAINT [FK_CTHD_HoaDon]
GO
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_TLKH] FOREIGN KEY([MaTL])
REFERENCES [dbo].[TLKH] ([MaTL])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CTHD] CHECK CONSTRAINT [FK_CTHD_TLKH]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[TLKH]  WITH CHECK ADD  CONSTRAINT [FK_TLKH_ChuyenNganh] FOREIGN KEY([MaCN])
REFERENCES [dbo].[ChuyenNganh] ([MaCN])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TLKH] CHECK CONSTRAINT [FK_TLKH_ChuyenNganh]
GO
ALTER TABLE [dbo].[TLKH]  WITH CHECK ADD  CONSTRAINT [FK_TLKH_NXB] FOREIGN KEY([MaNXB])
REFERENCES [dbo].[NXB] ([MaNXB])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TLKH] CHECK CONSTRAINT [FK_TLKH_NXB]
GO
ALTER TABLE [dbo].[TLKH]  WITH CHECK ADD  CONSTRAINT [FK_TLKH_TacGia] FOREIGN KEY([MaTG])
REFERENCES [dbo].[TacGia] ([MaTG])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TLKH] CHECK CONSTRAINT [FK_TLKH_TacGia]
GO
