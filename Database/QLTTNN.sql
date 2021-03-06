USE [QLTTNN]
GO
/****** Object:  Table [dbo].[monhoc]    Script Date: 05/28/2020 02:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[monhoc](
	[mamonhoc] [varchar](50) NOT NULL,
	[tenmonhoc] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_monhoc] PRIMARY KEY CLUSTERED 
(
	[mamonhoc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[monhoc] ([mamonhoc], [tenmonhoc]) VALUES (N'MH001', N'Tiếng nhật')
INSERT [dbo].[monhoc] ([mamonhoc], [tenmonhoc]) VALUES (N'MH002', N'Tiếng anh')
INSERT [dbo].[monhoc] ([mamonhoc], [tenmonhoc]) VALUES (N'MH003', N'Tiếng trung')
/****** Object:  Table [dbo].[lophoc]    Script Date: 05/28/2020 02:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[lophoc](
	[malophoc] [varchar](10) NOT NULL,
	[tenlophoc] [nvarchar](50) NOT NULL,
	[ngayhoc] [nvarchar](50) NOT NULL,
	[siso] [int] NOT NULL,
	[tengiaovien] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_lophoc] PRIMARY KEY CLUSTERED 
(
	[malophoc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[lophoc] ([malophoc], [tenlophoc], [ngayhoc], [siso], [tengiaovien]) VALUES (N'ML001', N'Tiếng nhật N3', N'T2,T4,T6 tiết (1,2,3)', 20, N'Lan Anh')
INSERT [dbo].[lophoc] ([malophoc], [tenlophoc], [ngayhoc], [siso], [tengiaovien]) VALUES (N'ML002', N'Tiếng nhật N5', N'T5,T6,T7 tiết (9,10,11)', 20, N'Lê Thị Hằng')
INSERT [dbo].[lophoc] ([malophoc], [tenlophoc], [ngayhoc], [siso], [tengiaovien]) VALUES (N'ML003', N'Tiếng anh TOIEC', N'T2,T4 ,T6  tiết (7,8,9)', 10, N'Lê Văn Đồng')
INSERT [dbo].[lophoc] ([malophoc], [tenlophoc], [ngayhoc], [siso], [tengiaovien]) VALUES (N'ML004', N'Tiếng trung cơ bản', N'T4,T6,T7 tiết (10,11,12)', 15, N'Nguyễn Văn Minh')
INSERT [dbo].[lophoc] ([malophoc], [tenlophoc], [ngayhoc], [siso], [tengiaovien]) VALUES (N'ML005', N'Tiếng anh bắt đầu', N'T3,T5,T7 tiết (2,3,4)', 14, N'Phạm Thị Linh')
/****** Object:  Table [dbo].[hocvien]    Script Date: 05/28/2020 02:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[hocvien](
	[mahocvien] [varchar](10) NOT NULL,
	[tenhocvien] [nvarchar](50) NOT NULL,
	[gioitinh] [nvarchar](50) NOT NULL,
	[ngaysinh] [nvarchar](50) NOT NULL,
	[quequan] [nvarchar](50) NOT NULL,
	[tenphuhuynh] [nvarchar](50) NOT NULL,
	[lienhe] [nvarchar](50) NOT NULL,
	[dotnhaphoc] [nvarchar](50) NOT NULL,
	[tenlophoc] [nvarchar](50) NOT NULL,
	[tenmonhoc] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_hocvien] PRIMARY KEY CLUSTERED 
(
	[mahocvien] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[hocvien] ([mahocvien], [tenhocvien], [gioitinh], [ngaysinh], [quequan], [tenphuhuynh], [lienhe], [dotnhaphoc], [tenlophoc], [tenmonhoc]) VALUES (N'MHV001', N'Phạm Văn Bách', N'Nam', N'25-05-2001', N'Nghệ An', N'Lê Thị Huế', N'1234567854', N'Đợt 1', N'Tiếng nhật N3', N'Tiếng nhật')
INSERT [dbo].[hocvien] ([mahocvien], [tenhocvien], [gioitinh], [ngaysinh], [quequan], [tenphuhuynh], [lienhe], [dotnhaphoc], [tenlophoc], [tenmonhoc]) VALUES (N'MHV002', N'Lê Thị Lan', N'Nữ', N'15-05-1998', N'Hà Tĩnh', N'Lê Văn Hoàng', N'145789564', N'Đợt 1', N'Tiếng nhật N5', N'Tiếng nhật')
INSERT [dbo].[hocvien] ([mahocvien], [tenhocvien], [gioitinh], [ngaysinh], [quequan], [tenphuhuynh], [lienhe], [dotnhaphoc], [tenlophoc], [tenmonhoc]) VALUES (N'MHV003', N'Hồ Quang Hiếu', N'Nam', N'20-05-2019', N'Hà Tĩnh', N'Lê Thị Thúy', N'154789558', N'Đợt 1', N'Tiếng anh TOIEC', N'Tiếng anh')
INSERT [dbo].[hocvien] ([mahocvien], [tenhocvien], [gioitinh], [ngaysinh], [quequan], [tenphuhuynh], [lienhe], [dotnhaphoc], [tenlophoc], [tenmonhoc]) VALUES (N'MHV004', N'Lê Thị Quý', N'Nữ', N'10-06-2000', N'Nghệ An', N'Lê Thị Sang', N'1234545545', N'Đợt 1', N'Tiếng trung cơ bản', N'Tiếng trung')
INSERT [dbo].[hocvien] ([mahocvien], [tenhocvien], [gioitinh], [ngaysinh], [quequan], [tenphuhuynh], [lienhe], [dotnhaphoc], [tenlophoc], [tenmonhoc]) VALUES (N'MHV005', N'Nguyễn Thị Lan Anh', N'Nữ', N'06-06-2001', N'Thanh Hóa', N'Lâm Thị Thơ', N'789459898', N'Đợt 1', N'Tiếng anh bắt đầu', N'Tiếng anh')
INSERT [dbo].[hocvien] ([mahocvien], [tenhocvien], [gioitinh], [ngaysinh], [quequan], [tenphuhuynh], [lienhe], [dotnhaphoc], [tenlophoc], [tenmonhoc]) VALUES (N'MHV006', N'Nguyễn Văn Sang', N'Nam', N'17-06-2001', N'Thanh Hóa', N'Nguyễn Văn Đức', N'789459898', N'Đợt 1', N'Tiếng nhật N3', N'Tiếng nhật')
INSERT [dbo].[hocvien] ([mahocvien], [tenhocvien], [gioitinh], [ngaysinh], [quequan], [tenphuhuynh], [lienhe], [dotnhaphoc], [tenlophoc], [tenmonhoc]) VALUES (N'MHV007', N'Nguyễn Văn Huỳnh', N'Nam', N'27-07-2000', N'Nghệ An', N'Lê Thị Liên', N'7894545444', N'Đợt 1', N'Tiếng nhật N3', N'Tiếng nhật')
INSERT [dbo].[hocvien] ([mahocvien], [tenhocvien], [gioitinh], [ngaysinh], [quequan], [tenphuhuynh], [lienhe], [dotnhaphoc], [tenlophoc], [tenmonhoc]) VALUES (N'MHV008', N'Phạm Văn Sỹ', N'Nam', N'20-10-2000', N'Nghệ An', N'Lê Thị Hoa', N'5565454568', N'Đợt 1', N'Tiếng nhật N5', N'Tiếng nhật')
INSERT [dbo].[hocvien] ([mahocvien], [tenhocvien], [gioitinh], [ngaysinh], [quequan], [tenphuhuynh], [lienhe], [dotnhaphoc], [tenlophoc], [tenmonhoc]) VALUES (N'MHV009', N'Nguyễn Thị Kim Hoa', N'Nữ', N'15-05-1998', N'Nghệ An', N'Nguyễn Hoáng Đức', N'44564567455', N'Đợt 1', N'Tiếng anh TOIEC', N'Tiếng anh')
INSERT [dbo].[hocvien] ([mahocvien], [tenhocvien], [gioitinh], [ngaysinh], [quequan], [tenphuhuynh], [lienhe], [dotnhaphoc], [tenlophoc], [tenmonhoc]) VALUES (N'MHV010', N'Lê Thị Uyên Nhi', N'Nữ', N'14-06-2002', N'Hà Tĩnh', N'Lê Bá Hào', N'45456785545', N'Đợt 1', N'Tiếng trung cơ bản', N'Tiếng trung')
INSERT [dbo].[hocvien] ([mahocvien], [tenhocvien], [gioitinh], [ngaysinh], [quequan], [tenphuhuynh], [lienhe], [dotnhaphoc], [tenlophoc], [tenmonhoc]) VALUES (N'MHV011', N'Phạm Đức Anh', N'Nam', N'15-06-2000', N'Hà Tĩnh', N'Phạm Văn Quang', N'4577865765', N'Đợt 2', N'Tiếng trung cơ bản', N'Tiếng trung')
INSERT [dbo].[hocvien] ([mahocvien], [tenhocvien], [gioitinh], [ngaysinh], [quequan], [tenphuhuynh], [lienhe], [dotnhaphoc], [tenlophoc], [tenmonhoc]) VALUES (N'MHV012', N'Phạm Quang Minh', N'Nam', N'15-09-2000', N'Nghệ An', N'Lê Thị Huyền', N'457445578', N'Đợt 2', N'Tiếng anh bắt đầu', N'Tiếng anh')
INSERT [dbo].[hocvien] ([mahocvien], [tenhocvien], [gioitinh], [ngaysinh], [quequan], [tenphuhuynh], [lienhe], [dotnhaphoc], [tenlophoc], [tenmonhoc]) VALUES (N'MHV013', N'Hà Minh Đức', N'Nam', N'15-09-2001', N'Nghệ An', N'Hà Văn Huấn', N'8798655889', N'Đợt 2', N'Tiếng nhật N5', N'Tiếng nhật')
/****** Object:  Table [dbo].[dangnhap]    Script Date: 05/28/2020 02:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dangnhap](
	[taikhoan] [nvarchar](50) NOT NULL,
	[matkhau] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dangnhap] PRIMARY KEY CLUSTERED 
(
	[taikhoan] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[dangnhap] ([taikhoan], [matkhau]) VALUES (N'admin', N'admin')
/****** Object:  Table [dbo].[giaovien]    Script Date: 05/28/2020 02:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[giaovien](
	[magiaovien] [varchar](10) NOT NULL,
	[tengiaovien] [nvarchar](50) NOT NULL,
	[gioitinh] [nvarchar](50) NOT NULL,
	[ngaysinh] [nvarchar](50) NOT NULL,
	[quequan] [nvarchar](50) NOT NULL,
	[ngaybatdaulam] [nvarchar](50) NOT NULL,
	[lienhe] [nvarchar](50) NOT NULL,
	[chuyennganh] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_giaovien] PRIMARY KEY CLUSTERED 
(
	[magiaovien] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[giaovien] ([magiaovien], [tengiaovien], [gioitinh], [ngaysinh], [quequan], [ngaybatdaulam], [lienhe], [chuyennganh]) VALUES (N'MGV001', N'Lan Anh', N'Nữ', N'17-05-1975', N'Nghệ An', N'10-05-2019', N'lananh@edu.vn', N'Tiếng nhật')
INSERT [dbo].[giaovien] ([magiaovien], [tengiaovien], [gioitinh], [ngaysinh], [quequan], [ngaybatdaulam], [lienhe], [chuyennganh]) VALUES (N'MGV002', N'Lê Thị Hằng', N'Nữ', N'10-05-1985', N'Hà Tĩnh', N'10-05-2019', N'thihang@gmail.com', N'Tiếng nhật')
INSERT [dbo].[giaovien] ([magiaovien], [tengiaovien], [gioitinh], [ngaysinh], [quequan], [ngaybatdaulam], [lienhe], [chuyennganh]) VALUES (N'MGV003', N'Lê Văn Đồng', N'Nam', N'20-05-1991', N'Hà Nội', N'20-05-2019', N'vandong@yahoo.com', N'Tiếng anh')
INSERT [dbo].[giaovien] ([magiaovien], [tengiaovien], [gioitinh], [ngaysinh], [quequan], [ngaybatdaulam], [lienhe], [chuyennganh]) VALUES (N'MGV004', N'Nguyễn Văn Minh', N'Nam', N'07-05-1985', N'Hà Tĩnh', N'20-05-2019', N'vanminh@edu.vn', N'Tiếng trung')
INSERT [dbo].[giaovien] ([magiaovien], [tengiaovien], [gioitinh], [ngaysinh], [quequan], [ngaybatdaulam], [lienhe], [chuyennganh]) VALUES (N'MGV005', N'Phạm Thị Linh', N'Nữ', N'08-05-1995', N'Thanh Hóa', N'01-06-2019', N'thiilinh@gmail.com', N'Tiếng anh')
/****** Object:  Table [dbo].[diemkt]    Script Date: 05/28/2020 02:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[diemkt](
	[mahocvien] [varchar](10) NULL,
	[tenhocvien] [nvarchar](50) NULL,
	[dotthi] [nvarchar](50) NULL,
	[tenlophoc] [nvarchar](50) NULL,
	[diemkt] [float] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[hocphi]    Script Date: 05/28/2020 02:11:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[hocphi](
	[mahocvien] [varchar](10) NULL,
	[tenhocvien] [nvarchar](50) NULL,
	[tenlophoc] [nvarchar](50) NULL,
	[dotnop] [nvarchar](50) NULL,
	[ngaynop] [nvarchar](50) NULL,
	[sotien] [float] NULL,
	[nguoithu] [nvarchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[hocphi] ([mahocvien], [tenhocvien], [tenlophoc], [dotnop], [ngaynop], [sotien], [nguoithu]) VALUES (N'MHV001', N'Phạm Văn Bách', N'Tiếng nhật N3', N'Đợt 1', N'20-06-2020', 400000, N'Linh')
INSERT [dbo].[hocphi] ([mahocvien], [tenhocvien], [tenlophoc], [dotnop], [ngaynop], [sotien], [nguoithu]) VALUES (N'MHV002', N'Lê Thị Lan', N'Tiếng nhật N5', N'Đợt 1', N'20-06-2020', 500000, N'Linh')
/****** Object:  ForeignKey [FK_diemkt_hocvien]    Script Date: 05/28/2020 02:11:09 ******/
ALTER TABLE [dbo].[diemkt]  WITH CHECK ADD  CONSTRAINT [FK_diemkt_hocvien] FOREIGN KEY([mahocvien])
REFERENCES [dbo].[hocvien] ([mahocvien])
GO
ALTER TABLE [dbo].[diemkt] CHECK CONSTRAINT [FK_diemkt_hocvien]
GO
/****** Object:  ForeignKey [FK_hocphi_hocvien]    Script Date: 05/28/2020 02:11:09 ******/
ALTER TABLE [dbo].[hocphi]  WITH CHECK ADD  CONSTRAINT [FK_hocphi_hocvien] FOREIGN KEY([mahocvien])
REFERENCES [dbo].[hocvien] ([mahocvien])
GO
ALTER TABLE [dbo].[hocphi] CHECK CONSTRAINT [FK_hocphi_hocvien]
GO
