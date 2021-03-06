USE [master]
GO
/****** Object:  Database [BTCK]    Script Date: 8/5/2021 6:40:54 PM ******/
CREATE DATABASE [BTCK]
 go
USE [BTCK]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 8/5/2021 6:40:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NULL,
	[Name] [nvarchar](500) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 8/5/2021 6:40:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 8/5/2021 6:40:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Description] [ntext] NULL,
	[Content] [ntext] NULL,
	[Hot] [int] NULL,
	[Photo] [nvarchar](500) NULL,
 CONSTRAINT [PK_News_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 8/5/2021 6:40:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[Create] [date] NULL,
	[Price] [float] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdersDetail]    Script Date: 8/5/2021 6:40:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdersDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[ProductID] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [float] NULL,
 CONSTRAINT [PK_orders_detail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 8/5/2021 6:40:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NULL,
	[Name] [nvarchar](4000) NULL,
	[Description] [nvarchar](4000) NULL,
	[Content] [ntext] NULL,
	[Photo] [nvarchar](4000) NULL,
	[Hot] [int] NULL,
	[Price] [float] NULL,
	[Discount] [float] NULL,
 CONSTRAINT [PK_news] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rating]    Script Date: 8/5/2021 6:40:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rating](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[Star] [int] NULL,
 CONSTRAINT [PK_Rating] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/5/2021 6:40:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Email] [nvarchar](500) NULL,
	[Password] [nvarchar](500) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([ID], [ParentID], [Name]) VALUES (1, 0, N'Vans')
INSERT [dbo].[Categories] ([ID], [ParentID], [Name]) VALUES (2, 0, N'Bitis hunter')
INSERT [dbo].[Categories] ([ID], [ParentID], [Name]) VALUES (3, 0, N'Balenciaga')
INSERT [dbo].[Categories] ([ID], [ParentID], [Name]) VALUES (4, 0, N'Nike')
INSERT [dbo].[Categories] ([ID], [ParentID], [Name]) VALUES (5, 0, N'Adidas')
INSERT [dbo].[Categories] ([ID], [ParentID], [Name]) VALUES (6, 1, N'Men''s Blue Vault Sk8-hi Lx Pride High-top Sneakers')
INSERT [dbo].[Categories] ([ID], [ParentID], [Name]) VALUES (7, 1, N'Men''s Black Suede/canvas Sk8 Hi-top Sneakers')
INSERT [dbo].[Categories] ([ID], [ParentID], [Name]) VALUES (8, 1, N'Men''s Black Ward Hi Athletic Shoe')
INSERT [dbo].[Categories] ([ID], [ParentID], [Name]) VALUES (9, 2, N'Giày Thể Thao Cao Cấp Nam Biti''s Hunter X Old Kool Black DSMH06500DEN (Đen)')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([ID], [Name], [Email], [Address], [Phone], [Password]) VALUES (1, N'Nguyễn Văn A', N'nva@gmail.com', N'Hà Nội', N'12345', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3')
INSERT [dbo].[Customers] ([ID], [Name], [Email], [Address], [Phone], [Password]) VALUES (2, N'hoa', N'hoang@gmail.com', N'Dinh cong, hoang mai', N'0983396805', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3')
INSERT [dbo].[Customers] ([ID], [Name], [Email], [Address], [Phone], [Password]) VALUES (3, N'Nguyen Van Ea', N'nve@gmail.com', N'Dinh cong, hoang mai', N'0983396805', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3')
INSERT [dbo].[Customers] ([ID], [Name], [Email], [Address], [Phone], [Password]) VALUES (4, N'test', N'ptdo@gmail.com', N'Dinh cong, hoang mai', N'0983396805', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3')
INSERT [dbo].[Customers] ([ID], [Name], [Email], [Address], [Phone], [Password]) VALUES (5, N'test2', N'nvaa@gmail.com', N'Dinh cong, hoang mai', N'0983396805', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3')
INSERT [dbo].[Customers] ([ID], [Name], [Email], [Address], [Phone], [Password]) VALUES (6, N'do hao', N'tiendo@gmail.com', N'Dinh cong, hoang mai', N'0983396805', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3')
INSERT [dbo].[Customers] ([ID], [Name], [Email], [Address], [Phone], [Password]) VALUES (7, N'hoang van a', N'tiendo12@gmail.com', N'Dinh cong, hoang mai', N'0983396805', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3')
INSERT [dbo].[Customers] ([ID], [Name], [Email], [Address], [Phone], [Password]) VALUES (8, N'', N'tiendo12a@gmail.com', N'', N'', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([ID], [Name], [Description], [Content], [Hot], [Photo]) VALUES (2, N'Adidas Falcon nổi bật mùa Hè với phối màu color block', N'<p>&nbsp;Adidas Falcon nổi bật m&ugrave;a H&egrave; với phối m&agrave;u color block</p>', N'<p>&nbsp;Cuối th&aacute;ng 5, adidas Falcon đ&atilde; cho ra mắt nhiều phối m&agrave;u đ&oacute;n ch&agrave;o m&ugrave;a H&egrave; khiến giới trẻ y&ecirc;uth&iacute;ch kh&ocirc;ng th&ocirc;i. Tưởng chừng thương hiệu sẽ tiếp tục&nbsp;cho giới trẻ&nbsp;hiện nay . ch&iacute;nh v&igrave; vậy lựa chọn sẩn phầm n&agrave;y th&igrave; sẽ đem cho bạn 1 cảm gi&aacute;c cool ngầu thực sự&nbsp;</p>', 1, N'132713936553432565_new-1.jpg')
INSERT [dbo].[News] ([ID], [Name], [Description], [Content], [Hot], [Photo]) VALUES (3, N'Saucony hồi sinh mẫu giày chạy bộ cổ điển của mình – Aya Runner', N'<p>&nbsp;Saucony hồi sinh mẫu gi&agrave;y chạy bộ cổ điển của m&igrave;nh &ndash; Aya Runner</p>', N'<p>L&agrave; một trong những đ&ocirc;i gi&agrave;y chạy bộ tốt nhất v&agrave;o những năm 1994, 1995, Saucony Aya Runner vừa c&oacute;&nbsp; m&agrave;n trở lại&nbsp;v&ocirc; c&ugrave;ng ấn tượng v&agrave;o năm 2021 .Ph&ugrave; hợp cho giới trẻ&nbsp;hiện nay . ch&iacute;nh v&igrave; vậy lựa chọn sẩn phầm n&agrave;y th&igrave; sẽ đem cho bạn 1 cảm gi&aacute;c cool ngầu thực sự&nbsp;</p>', 1, N'132713947567249513_new-2.jpg')
INSERT [dbo].[News] ([ID], [Name], [Description], [Content], [Hot], [Photo]) VALUES (4, N'Nike Vapormax Plus trở lại với sắc tím mộng mơ và thiết kế chuyển màu đẹp mắt', N'<p>&nbsp;Nike Vapormax Plus trở lại với sắc t&iacute;m mộng mơ v&agrave; thiết kế chuyển m&agrave;u đẹp mắt</p>', N'<p>&nbsp; L&agrave; một trong những mẫu gi&agrave;y retro c&oacute; nhiều phối m&agrave;u gradient đẹp nhất từ trước đến n&agrave;y, Nike&nbsp;Vapormax Plus vừa c&oacute; m&agrave;n trở lại b&aacute; đạo d&agrave;nh cho giới trẻ&nbsp;hiện nay . ch&iacute;nh v&igrave; vậy lựa chọn sẩn phầm n&agrave;y th&igrave; sẽ đem cho bạn 1 cảm gi&aacute;c cool ngầu thực sự&nbsp;</p>', 1, N'132713948280063976_new-3.jpg')
SET IDENTITY_INSERT [dbo].[News] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([ID], [CustomerID], [Create], [Price], [Status]) VALUES (5, 1, CAST(N'2021-08-01' AS Date), 2400000, 0)
INSERT [dbo].[Orders] ([ID], [CustomerID], [Create], [Price], [Status]) VALUES (6, 1, CAST(N'2021-08-01' AS Date), 2600000, 0)
INSERT [dbo].[Orders] ([ID], [CustomerID], [Create], [Price], [Status]) VALUES (7, 7, CAST(N'2021-08-01' AS Date), 3200000, 1)
INSERT [dbo].[Orders] ([ID], [CustomerID], [Create], [Price], [Status]) VALUES (8, 7, CAST(N'2021-08-01' AS Date), 800000, 0)
INSERT [dbo].[Orders] ([ID], [CustomerID], [Create], [Price], [Status]) VALUES (9, 7, CAST(N'2021-08-01' AS Date), 900000, 0)
INSERT [dbo].[Orders] ([ID], [CustomerID], [Create], [Price], [Status]) VALUES (10, 7, CAST(N'2021-08-03' AS Date), 12000000, 0)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[OrdersDetail] ON 

INSERT [dbo].[OrdersDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price]) VALUES (8, 5, 13, 3, 760000)
INSERT [dbo].[OrdersDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price]) VALUES (9, 6, 9, 1, 2080000)
INSERT [dbo].[OrdersDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price]) VALUES (10, 7, 13, 4, 760000)
INSERT [dbo].[OrdersDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price]) VALUES (11, 8, 13, 1, 760000)
INSERT [dbo].[OrdersDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price]) VALUES (12, 9, 14, 1, 792000)
INSERT [dbo].[OrdersDetail] ([ID], [OrderID], [ProductID], [Quantity], [Price]) VALUES (13, 10, 8, 1, 10800000)
SET IDENTITY_INSERT [dbo].[OrdersDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ID], [CategoryID], [Name], [Description], [Content], [Photo], [Hot], [Price], [Discount]) VALUES (1, 4, N'Nike crr12', N'<p>&nbsp;với thiết kế năng động, hiện đại gi&uacute;p người mang thể hiện phong c&aacute;ch ri&ecirc;ng, đồng thời hỗ trợ vận động tốt cho đ&ocirc;i ch&acirc;n trong mọi hoạt động. Th&acirc;n gi&agrave;y được cấu tạo bởi vật liệu bền bỉ, &ecirc;m &aacute;i gi&uacute;p bạn lu&ocirc;n cảm thấy thoải m&aacute;i khi mang trong thời gian d&agrave;i. Mặt trong đế d&agrave;y mềm mại n&acirc;ng niu l&ograve;ng b&agrave;n ch&acirc;n, c&ograve;n mặt ngo&agrave;i đế gi&agrave;y hạn chế m&agrave;i m&ograve;n, chống trơn trượt đem đến sự an to&agrave;n cho người mang. Form gi&agrave;y &ocirc;m ch&acirc;n c&ugrave;ng chất liệu th&acirc;n gi&agrave;y c&oacute; t&iacute;nh đ&agrave;n hồi theo chiều chuyển động của b&agrave;n ch&acirc;n gi&uacute;p bạn tự do hoạt động.&nbsp;<em>Gi&agrave;y chạy bộ Nike</em>&nbsp;sở hữu những đường n&eacute;t khỏe khoắn c&ugrave;ng gam m&agrave;u tinh tế, trẻ trung sẽ mang đến cho bạn những trải nghiệm tuyệt vời khi tham gia tập luyện thể thao hay c&aacute;c hoạt động kh&aacute;c thường ng&agrave;y. B&ecirc;n cạnh đ&oacute;, với một đ&ocirc;i gi&agrave;y thể thao, bạn c&oacute; thể phối với nhiều kiểu trang phục theo sở th&iacute;ch tạo n&ecirc;n set đồ ấn tượng, c&aacute; t&iacute;nh.</p>', N'<p>Ward Hi Suede Canvas Trainers của Vans đi k&egrave;m với phần đ&oacute;ng ren v&agrave; cổ &aacute;o cao, c&oacute; thương hiệu ở g&oacute;t v&agrave; lưỡi, cũng như cổ &aacute;o v&agrave; lưỡi g&agrave; c&oacute; đệm.&nbsp;C&oacute; m&agrave;u Đen / Trắng, gi&agrave;y thể thao d&agrave;nh cho nam n&agrave;y c&oacute; phần tr&ecirc;n bằng da lộn v&agrave; đế cao su.Ward Hi Suede Canvas Trainers của Vans đi k&egrave;m với phần đ&oacute;ng ren v&agrave; cổ &aacute;o cao, c&oacute; thương hiệu ở g&oacute;t v&agrave; lưỡi, cũng như cổ &aacute;o v&agrave; lưỡi g&agrave; c&oacute; đệm.&nbsp;C&oacute; m&agrave;u Đen / Trắng, gi&agrave;y thể thao d&agrave;nh cho nam n&agrave;y c&oacute; phần tr&ecirc;n bằng da lộn v&agrave; đế cao su.Ward Hi Suede Canvas Trainers của Vans đi k&egrave;m với phần đ&oacute;ng ren v&agrave; cổ &aacute;o cao, c&oacute; thương hiệu ở g&oacute;t v&agrave; lưỡi, cũng như cổ &aacute;o v&agrave; lưỡi g&agrave; c&oacute; đệm.&nbsp;C&oacute; m&agrave;u Đen / Trắng, gi&agrave;y thể thao d&agrave;nh cho nam n&agrave;y c&oacute; phần tr&ecirc;n bằng da lộn v&agrave; đế cao su.Ward Hi Suede Canvas Trainers của Vans đi k&egrave;m với phần đ&oacute;ng ren v&agrave; cổ &aacute;o cao, c&oacute; thương hiệu ở g&oacute;t v&agrave; lưỡi, cũng như cổ &aacute;o v&agrave; lưỡi g&agrave; c&oacute; đệm.&nbsp;C&oacute; m&agrave;u Đen / Trắng, gi&agrave;y thể thao d&agrave;nh cho nam n&agrave;y c&oacute; phần tr&ecirc;n bằng da lộn v&agrave; đế cao su.</p>', N'132712431637765751_gallery_item_1.jpg', 1, 3200000, 10)
INSERT [dbo].[Products] ([ID], [CategoryID], [Name], [Description], [Content], [Photo], [Hot], [Price], [Discount]) VALUES (4, 4, N'Nike s1002', N'<p>H&atilde;ng sản xuất &ocirc; t&ocirc; Nissan Motor Co. Ltd. nổi tiếng của Nhật Bản vừa th&ocirc;ng b&aacute;o thu hồi 394.025 xe tại Mỹ do lỗi ở hệ thống thắng c&oacute; thể dẫn đến r&ograve; rỉ dầu thắng g&acirc;y ch&aacute;y. Trước đ&acirc;y, Nissan đ&atilde; từng gặp tai nạn khi phải d&agrave;n xếp vụ xe c&aacute;n chết người do xe thiếu t&uacute;i kh&iacute; v&agrave; scandal của cựu Chủ tịch Carlos Ghosn.</p>', N'<p>Ward Hi Suede Canvas Trainers của Vans đi k&egrave;m với phần đ&oacute;ng ren v&agrave; cổ &aacute;o cao, c&oacute; thương hiệu ở g&oacute;t v&agrave; lưỡi, cũng như cổ &aacute;o v&agrave; lưỡi g&agrave; c&oacute; đệm.&nbsp;C&oacute; m&agrave;u Đen / Trắng, gi&agrave;y thể thao d&agrave;nh cho nam n&agrave;y c&oacute; phần tr&ecirc;n bằng da lộn v&agrave; đế cao su.Ward Hi Suede Canvas Trainers của Vans đi k&egrave;m với phần đ&oacute;ng ren v&agrave; cổ &aacute;o cao, c&oacute; thương hiệu ở g&oacute;t v&agrave; lưỡi, cũng như cổ &aacute;o v&agrave; lưỡi g&agrave; c&oacute; đệm.&nbsp;C&oacute; m&agrave;u Đen / Trắng, gi&agrave;y thể thao d&agrave;nh cho nam n&agrave;y c&oacute; phần tr&ecirc;n bằng da lộn v&agrave; đế cao su.Ward Hi Suede Canvas Trainers của Vans đi k&egrave;m với phần đ&oacute;ng ren v&agrave; cổ &aacute;o cao, c&oacute; thương hiệu ở g&oacute;t v&agrave; lưỡi, cũng như cổ &aacute;o v&agrave; lưỡi g&agrave; c&oacute; đệm.&nbsp;C&oacute; m&agrave;u Đen / Trắng, gi&agrave;y thể thao d&agrave;nh cho nam n&agrave;y c&oacute; phần tr&ecirc;n bằng da lộn v&agrave; đế cao su.Ward Hi Suede Canvas Trainers của Vans đi k&egrave;m với phần đ&oacute;ng ren v&agrave; cổ &aacute;o cao, c&oacute; thương hiệu ở g&oacute;t v&agrave; lưỡi, cũng như cổ &aacute;o v&agrave; lưỡi g&agrave; c&oacute; đệm.&nbsp;C&oacute; m&agrave;u Đen / Trắng, gi&agrave;y thể thao d&agrave;nh cho nam n&agrave;y c&oacute; phần tr&ecirc;n bằng da lộn v&agrave; đế cao su.</p>', N'132712431132328206_8.jpg', 1, 3100000, 15)
INSERT [dbo].[Products] ([ID], [CategoryID], [Name], [Description], [Content], [Photo], [Hot], [Price], [Discount]) VALUES (5, 4, N'giày Nike122', N'<p>Khi đi sửa chữa chiếc xe m&aacute;y của m&igrave;nh, t&agrave;i xế cần lưu &yacute; những &quot;m&aacute;nh kh&oacute;e&quot; dưới đ&acirc;y để kh&ocirc;ng mắc phải những chi&ecirc;u tr&ograve; &quot;m&oacute;c t&uacute;i&quot; của thợ sửa chữa.</p>', N'<p>Ward Hi Suede Canvas Trainers của Vans đi k&egrave;m với phần đ&oacute;ng ren v&agrave; cổ &aacute;o cao, c&oacute; thương hiệu ở g&oacute;t v&agrave; lưỡi, cũng như cổ &aacute;o v&agrave; lưỡi g&agrave; c&oacute; đệm.&nbsp;C&oacute; m&agrave;u Đen / Trắng, gi&agrave;y thể thao d&agrave;nh cho nam n&agrave;y c&oacute; phần tr&ecirc;n bằng da lộn v&agrave; đế cao su.Ward Hi Suede Canvas Trainers của Vans đi k&egrave;m với phần đ&oacute;ng ren v&agrave; cổ &aacute;o cao, c&oacute; thương hiệu ở g&oacute;t v&agrave; lưỡi, cũng như cổ &aacute;o v&agrave; lưỡi g&agrave; c&oacute; đệm.&nbsp;C&oacute; m&agrave;u Đen / Trắng, gi&agrave;y thể thao d&agrave;nh cho nam n&agrave;y c&oacute; phần tr&ecirc;n bằng da lộn v&agrave; đế cao su.Ward Hi Suede Canvas Trainers của Vans đi k&egrave;m với phần đ&oacute;ng ren v&agrave; cổ &aacute;o cao, c&oacute; thương hiệu ở g&oacute;t v&agrave; lưỡi, cũng như cổ &aacute;o v&agrave; lưỡi g&agrave; c&oacute; đệm.&nbsp;C&oacute; m&agrave;u Đen / Trắng, gi&agrave;y thể thao d&agrave;nh cho nam n&agrave;y c&oacute; phần tr&ecirc;n bằng da lộn v&agrave; đế cao su.Ward Hi Suede Canvas Trainers của Vans đi k&egrave;m với phần đ&oacute;ng ren v&agrave; cổ &aacute;o cao, c&oacute; thương hiệu ở g&oacute;t v&agrave; lưỡi, cũng như cổ &aacute;o v&agrave; lưỡi g&agrave; c&oacute; đệm.&nbsp;C&oacute; m&agrave;u Đen / Trắng, gi&agrave;y thể thao d&agrave;nh cho nam n&agrave;y c&oacute; phần tr&ecirc;n bằng da lộn v&agrave; đế cao su.</p>', N'132712430663318185_3.jpg', 1, 3000000, 20)
INSERT [dbo].[Products] ([ID], [CategoryID], [Name], [Description], [Content], [Photo], [Hot], [Price], [Discount]) VALUES (6, 4, N'utra Nike', N'<p>Thế hệ thứ 12 của Toyota Corolla cuối c&ugrave;ng đ&atilde; mở b&aacute;n tại &Uacute;c, bao gồm 6 biến thể, gi&aacute; từ 23.335 AUD (hơn 366 triệu đồng) cho bản Ascent Sport cơ bản, đến 33.635 AUD (528 triệu đồng) cho biến thể ZR h&agrave;ng đầu với CVT.</p>', N'<p>&nbsp;với thiết kế năng động, hiện đại gi&uacute;p người mang thể hiện phong c&aacute;ch ri&ecirc;ng, đồng thời hỗ trợ vận động tốt cho đ&ocirc;i ch&acirc;n trong mọi hoạt động. Th&acirc;n gi&agrave;y được cấu tạo bởi vật liệu bền bỉ, &ecirc;m &aacute;i gi&uacute;p bạn lu&ocirc;n cảm thấy thoải m&aacute;i khi mang trong thời gian d&agrave;i. Mặt trong đế d&agrave;y mềm mại n&acirc;ng niu l&ograve;ng b&agrave;n ch&acirc;n, c&ograve;n mặt ngo&agrave;i đế gi&agrave;y hạn chế m&agrave;i m&ograve;n, chống trơn trượt đem đến sự an to&agrave;n cho người mang. Form gi&agrave;y &ocirc;m ch&acirc;n c&ugrave;ng chất liệu th&acirc;n gi&agrave;y c&oacute; t&iacute;nh đ&agrave;n hồi theo chiều chuyển động của b&agrave;n ch&acirc;n gi&uacute;p bạn tự do hoạt động.&nbsp;<em>Gi&agrave;y chạy bộ Nike</em>&nbsp;sở hữu những đường n&eacute;t khỏe khoắn c&ugrave;ng gam m&agrave;u tinh tế, trẻ trung sẽ mang đến cho bạn những trải nghiệm tuyệt vời khi tham gia tập luyện thể thao hay c&aacute;c hoạt động kh&aacute;c thường ng&agrave;y. B&ecirc;n cạnh đ&oacute;, với một đ&ocirc;i gi&agrave;y thể thao, bạn c&oacute; thể phối với nhiều kiểu trang phục theo sở th&iacute;ch tạo n&ecirc;n set đồ ấn tượng, c&aacute; t&iacute;nh.</p>', N'132712431897592015_6.jpg', 1, 900000, 13)
INSERT [dbo].[Products] ([ID], [CategoryID], [Name], [Description], [Content], [Photo], [Hot], [Price], [Discount]) VALUES (7, 2, N'Giày Thể Thao Nam Biti''s Hunter Street x VietMax | Arising Vietnam R9 Bold DSMH05600DEN', N'<p><strong>Cảm hứng thiết kế</strong>&nbsp;:&nbsp;Biti&#39;s Hunter Street, đồng s&aacute;ng tạo c&ugrave;ng nghệ sĩ Việt Max, mang đến BST Arising Vietnam - lấy cảm hứng từ kh&aacute;t vọng v&agrave; tiềm lực của thế hệ trẻ Việt, tự h&agrave;o vươn m&igrave;nh c&ugrave;ng đất nước.</p>', N'<p>&nbsp;Lấy cảm hứng từ vị thế &quot;Rồng bay&quot;, BST c&oacute; ng&ocirc;n ngữ thiết kế mạnh mẽ, kỳ c&ocirc;ng v&agrave; độc đ&aacute;o đến từng chi tiết như vảy da, chỉ viền, khoen gi&agrave;y, d&acirc;y gi&agrave;y. Đặc biệt, biểu tượng Rồng tr&ecirc;n lưỡi g&agrave; được s&aacute;ng tạo từ n&eacute;t hoa văn quen thuộc của Trống Đồng, đại diện cho sự song h&agrave;nh của bản sắc Việt v&agrave; s&aacute;ng tạo Việt.<br />
&nbsp; &nbsp; &nbsp;- Phom d&aacute;ng cổ thấp.<br />
&nbsp; &nbsp; &nbsp;- Mũ quai sử dụng chất liệu Simili cao cấp hạn chế b&aacute;m bẩn v&agrave; thấm nước.&nbsp;<br />
&nbsp; &nbsp; &nbsp;- L&oacute;t quai thun c&aacute; sấu kh&aacute;ng khuẩn gi&uacute;p hạn chế m&ugrave;i h&ocirc;i v&agrave; ẩm mốc. Cấu tr&uacute;c l&oacute;t đa lớp kết hợp xốp d&agrave;y v&agrave; &ecirc;m &aacute;i.&nbsp;<br />
&nbsp; &nbsp; &nbsp;- L&oacute;t đế trong (Insole) với chất liệu EVA c&ugrave;ng c&ocirc;ng nghệ &eacute;p khu&ocirc;n 3D theo bi&ecirc;n dạng b&agrave;n ch&acirc;n, &ocirc;m đều &amp; định vị tốt, tr&aacute;nh tuột ch&acirc;n khi vận động mạnh. Kết hợp với chất liệu thun kh&aacute;ng khuẩn, gi&uacute;p thấm h&uacute;t mồ h&ocirc;i, hạn chế m&ugrave;i v&agrave; ẩm mốc.&nbsp;<br />
&nbsp; &nbsp; &nbsp;- Đế (Outsole) với chất liệu EVA cao su R.E với t&iacute;nh năng mềm dẻo v&agrave; nhẹ hơn rất nhiều so với cao su truyền thống, nhưng vẫn đảm bảo khả năng chịu m&agrave;i m&ograve;n v&agrave; va chạm. Độ Shore ph&ugrave; hợp, &ecirc;m v&agrave; nẩy tốt gi&uacute;p bảo vệ v&agrave; n&acirc;ng đỡ b&agrave;n ch&acirc;n.&nbsp;<br />
&nbsp; &nbsp; &nbsp;- Đế hộp cao th&agrave;nh &ocirc;m gọn mũ quai v&agrave; liền lạc với mặt đế th&agrave;nh một khối gi&uacute;p sản phẩm bền bỉ v&agrave; linh hoạt trong mọi t&igrave;nh huống vận động.</p>', N'132712343646827363_12.jpg', 1, 2800000, 12)
INSERT [dbo].[Products] ([ID], [CategoryID], [Name], [Description], [Content], [Photo], [Hot], [Price], [Discount]) VALUES (8, 2, N'Giày Thể Thao Cao Cấp Nam Biti''s Hunter X Old Kool Black', N'<p>Chưa r&otilde; v&igrave; nguy&ecirc;n nh&acirc;n g&igrave;, chiếc xe VinFast Fadil kh&ocirc;ng được sử dụng, m&agrave; để kh&ocirc;ng ngo&agrave;i mưa nắng, khiến cho đĩa phanh han gỉ, khiến nhiều người kh&ocirc;ng khỏi x&oacute;t của.</p>', N'<p>Chỉ sau một thời gian ngắn đăng tải tr&ecirc;n c&aacute;c diễn đ&agrave;n &ocirc; t&ocirc; - xe m&aacute;y, sự quan t&acirc;m của cộng đồng 4 b&aacute;nh d&agrave;nh cho bức h&igrave;nh chiếc VinFast Fadil trắng bị bỏ kh&ocirc;ng li&ecirc;n tục gia tăng.</p>

<p>L&agrave; phương tiện di chuyển v&agrave; t&agrave;i sản c&oacute; gi&aacute; trị, thường được giữ g&igrave;n cẩn thận, vậy n&ecirc;n, nhiều người kh&ocirc;ng khỏi t&ograve; m&ograve; l&iacute; do v&igrave; sao chủ nh&acirc;n lại bỏ chiếc xe ngo&agrave;i trời kh&ocirc;ng sử dụng, mặc mưa nắng v&agrave; l&aacute; rụng b&aacute;m đầy tr&ecirc;n gương, k&iacute;nh chắn gi&oacute; xe.</p>

<p>&nbsp;</p>

<ul>
	<li>&nbsp;</li>
	<li>&nbsp;</li>
	<li>&nbsp;</li>
	<li>&nbsp;</li>
</ul>

<p>Nhiều tranh luận nổ ra xung quanh chiếc Fadil, đa phần đều rất tiếc v&igrave; gi&aacute; trị chiếc xe đang mất dần khi chịu cảnh phơi sương nắng. Số kh&aacute;c lại muốn t&igrave;m chủ nh&acirc;n xe để thương lượng mức gi&aacute; ph&ugrave; hợp mua lại Fadil.</p>

<p>V&igrave; quan t&acirc;m đến chiếc xe kh&ocirc;ng đi l&acirc;u ng&agrave;y, một vị kh&aacute;ch đ&atilde; viết l&ecirc;n lớp bụi trước nắp capo d&ograve;ng tin nhắn, ngỏ &yacute; muốn mua lại chiếc &ocirc; t&ocirc;. Tuy nhi&ecirc;n, chủ nh&acirc;n xe cũng để lại d&ograve;ng trả lời kh&ocirc;ng muốn b&aacute;n xe.</p>

<p>Hiện tại mẫu xe đang c&oacute; gi&aacute; ni&ecirc;m yết từ 395 triệu đồng (cho bản ti&ecirc;u chuẩn) v&agrave; 429 triệu đồng cho bản Plus. Để k&iacute;ch cầu, mới đ&acirc;y, h&atilde;ng xe Việt đ&atilde; tung chương tr&igrave;nh miễn ph&iacute; l&atilde;i vay trong hai năm đầu ti&ecirc;n v&agrave; được vay trong v&ograve;ng 5 năm cho kh&aacute;ch h&agrave;ng vay ng&acirc;n h&agrave;ng mua Fadil, khiến cho chiếc xe đang c&oacute; nhiều ưu thế về gi&aacute; trong ph&acirc;n kh&uacute;c A.</p>', N'132711406445973691_10-10.jpg', 0, 12000000, 10)
INSERT [dbo].[Products] ([ID], [CategoryID], [Name], [Description], [Content], [Photo], [Hot], [Price], [Discount]) VALUES (9, 2, N'Giày Thể Thao Cao Cấp Nam Biti''s Hunter X Old Kool Black  (Đỏ)', N'<p>Lexus RX 350 phi&ecirc;n bản n&acirc;ng cấp sở hữu thiết kế năng động, tho&aacute;t khỏi vẻ trung t&iacute;nh như thường thấy.</p>', N'<p>Trong khu&ocirc;n khổ Vietnam Motor Show 2019 diễn ra v&agrave;o cuối th&aacute;ng 10 vừa qua. Lexus giới thiệu đến 4 phi&ecirc;n bản kh&aacute;c nhau bao gồm RX 300, RX 350, RX 350L v&agrave; RX 450h đi c&ugrave;ng gi&aacute; b&aacute;n từ 3,18 - 4,64 tỷ đồng.</p>

<p><img alt="Chi tiết Lexus RX 350 2020 giá 4,12 tỷ đồng tại Việt Nam - 1" src="https://img.docbao.vn/images/uploads/2019/11/28/kinh-te/lexus-rx350-1.jpg" title="Chi tiết Lexus RX 350 2020 giá 4,12 tỷ đồng tại Việt Nam - 1" /></p>

<p>Trong số 4 phi&ecirc;n bản tr&ecirc;n, người ti&ecirc;u d&ugrave;ng tại Việt Nam thường quen thuộc với RX 350 bởi đ&acirc;y ch&iacute;nh l&agrave; phi&ecirc;n bản RX đang lăn b&aacute;nh nhiều nhất tại Việt Nam</p>

<p><img alt="Chi tiết Lexus RX 350 2020 giá 4,12 tỷ đồng tại Việt Nam - 2" src="https://img.docbao.vn/images/uploads/2019/11/28/kinh-te/lexus-rx350-2.jpg" title="Chi tiết Lexus RX 350 2020 giá 4,12 tỷ đồng tại Việt Nam - 2" /></p>

<p>Về thiết kế, ngoại thất của RX 350 phi&ecirc;n bản 2020 vẫn duy tr&igrave; vẻ mạnh mẽ v&agrave; thể thao trong khi đường g&acirc;n dọc h&ocirc;ng xe sẽ được t&aacute;i thiết kế mang đến cho RX một vẻ ngo&agrave;i mượt m&agrave; v&agrave; thống nhất hơn, nhấn mạnh ng&ocirc;n ngữ thiết kế mới của Lexus.</p>

<p><img alt="Chi tiết Lexus RX 350 2020 giá 4,12 tỷ đồng tại Việt Nam - 3" src="https://img.docbao.vn/images/uploads/2019/11/28/kinh-te/lexus-rx350-3.jpg" title="Chi tiết Lexus RX 350 2020 giá 4,12 tỷ đồng tại Việt Nam - 3" /></p>

<p>M&acirc;m xe của RX 350 phi&ecirc;n bản 2020 với thiết kế c&aacute; t&iacute;nh, trẻ trung, mang lại vẻ thanh lịch v&agrave; quyến rũ trong từng chuyển động.</p>

<p><img alt="Chi tiết Lexus RX 350 2020 giá 4,12 tỷ đồng tại Việt Nam - 4" src="https://img.docbao.vn/images/uploads/2019/11/28/kinh-te/lexus-rx350-4.jpg" title="Chi tiết Lexus RX 350 2020 giá 4,12 tỷ đồng tại Việt Nam - 4" /></p>

<p>C&aacute;c nh&agrave; thiết kế đ&atilde; kết nối phần cản dưới với phần chắn ph&iacute;a sau, đồng bộ với tạo h&igrave;nh cửa sau khu vực cột C tạo n&ecirc;n một diện mạo mới sang trọng, mạnh mẽ v&agrave; kh&aacute;c biệt.</p>

<p><img alt="Chi tiết Lexus RX 350 2020 giá 4,12 tỷ đồng tại Việt Nam - 5" src="https://img.docbao.vn/images/uploads/2019/11/28/kinh-te/lexus-rx350-5.jpg" title="Chi tiết Lexus RX 350 2020 giá 4,12 tỷ đồng tại Việt Nam - 5" /></p>

<p>Lưới tản nhiệt h&igrave;nh con suốt đặc trưng của Lexus được tạo điểm nhấn với c&aacute;c họa tiết h&igrave;nh chữ L c&aacute;ch điệu v&agrave; viền thiết kế mới với cạnh cản trước mang đến một h&igrave;nh d&aacute;ng thống nhất.</p>

<p><img alt="Chi tiết Lexus RX 350 2020 giá 4,12 tỷ đồng tại Việt Nam - 6" src="https://img.docbao.vn/images/uploads/2019/11/28/kinh-te/lexus-rx350-6.jpg" title="Chi tiết Lexus RX 350 2020 giá 4,12 tỷ đồng tại Việt Nam - 6" /></p>

<p>Đặc biệt, Lexus lu&ocirc;n ti&ecirc;n phong trong c&aacute;c c&ocirc;ng nghệ đ&egrave;n &ocirc; t&ocirc; v&agrave; cũng l&agrave; nh&agrave; sản xuất đầu ti&ecirc;n &aacute;p dụng đ&egrave;n LED v&agrave; hệ thống đ&egrave;n pha tự động th&iacute;ch ứng để tăng cường sự an to&agrave;n.</p>

<p><img alt="Chi tiết Lexus RX 350 2020 giá 4,12 tỷ đồng tại Việt Nam - 7" src="https://img.docbao.vn/images/uploads/2019/11/28/kinh-te/lexus-rx350-7.jpg" title="Chi tiết Lexus RX 350 2020 giá 4,12 tỷ đồng tại Việt Nam - 7" /></p>

<p>Nội thất của RX 350 phi&ecirc;n bản 2020 với triết l&yacute; lấy người sử dụng l&agrave;m trung t&acirc;m: bảng t&aacute;p l&ocirc; ốp gỗ shimamoku, ghế bọc da semi-aniline cao cấp với v&ocirc; lăng ba chấu thể thao được trang bị nhiều ph&iacute;m bấm tiện &iacute;ch, m&agrave;n h&igrave;nh trung t&acirc;m 12.3 inch, m&agrave;n h&igrave;nh hiển thị th&ocirc;ng tin tr&ecirc;n k&iacute;nh chắn gi&oacute; HUD k&iacute;ch thước lớn - đường chỉ kh&acirc;u kết hợp với &aacute;nh s&aacute;ng từ hệ thống đ&egrave;n trần cảm ứng tạo n&ecirc;n kh&ocirc;ng gian sang trọng v&agrave;o buổi tối.</p>

<p><img alt="Chi tiết Lexus RX 350 2020 giá 4,12 tỷ đồng tại Việt Nam - 8" src="https://img.docbao.vn/images/uploads/2019/11/28/kinh-te/lexus-rx350-8.jpg" title="Chi tiết Lexus RX 350 2020 giá 4,12 tỷ đồng tại Việt Nam - 8" /></p>

<p><img alt="Chi tiết Lexus RX 350 2020 giá 4,12 tỷ đồng tại Việt Nam - 9" src="https://img.docbao.vn/images/uploads/2019/11/28/kinh-te/lexus-rx350-9.jpg" title="Chi tiết Lexus RX 350 2020 giá 4,12 tỷ đồng tại Việt Nam - 9" /></p>

<p>Lexus RX 350 phi&ecirc;n bản 2020 được trang bị khối động cơ V6 3.5L quen thuộc sản sinh c&ocirc;ng suất tối đa 296 m&atilde; lực tại 6.300 v&ograve;ng/ph&uacute;t v&agrave; m&ocirc;-men xoắn cực đại 370 m&atilde; lực tại 4.600 - 4.700 v/p. Hộp số l&agrave; loại tự động 8 cấp gi&uacute;p xe c&oacute; khả năng tăng tốc từ 0 - 100 km/h trong 7,9 gi&acirc;y, tốc độ tối đa 200 km/h.</p>', N'132711405540011404_9.jpg', 1, 2600000, 20)
INSERT [dbo].[Products] ([ID], [CategoryID], [Name], [Description], [Content], [Photo], [Hot], [Price], [Discount]) VALUES (10, 2, N'Giày Thể Thao Cao Cấp Nam Biti''s Hunter X Old Kool Black DSMH06500DEN (Đen)', N'<p><strong>Gi&agrave;y Thể Thao Nam Biti&#39;s Hunter Street x VietMax - Vietnam Arising R3 Gold DSMH05500NAU</strong></p>

<p><strong>1. Cảm hứng thiết kế</strong>&nbsp;:&nbsp;Biti&#39;s Hunter Street, đồng s&aacute;ng tạo c&ugrave;ng nghệ sĩ Việt Max, mang đến BST Arising Vietnam - lấy cảm hứng từ kh&aacute;t vọng v&agrave; tiềm lực của thế hệ trẻ Việt, tự h&agrave;o vươn m&igrave;nh c&ugrave;ng đất nước.</p>', N'<p>- Lấy cảm hứng từ vị thế &quot;Rồng bay&quot;, BST c&oacute; ng&ocirc;n ngữ thiết kế mạnh mẽ, kỳ c&ocirc;ng v&agrave; độc đ&aacute;o đến từng chi tiết như vảy da, chỉ viền, khoen gi&agrave;y, d&acirc;y gi&agrave;y. Đặc biệt, biểu tượng Rồng tr&ecirc;n lưỡi g&agrave; được s&aacute;ng tạo từ n&eacute;t hoa văn quen thuộc của Trống Đồng, đại diện cho sự song h&agrave;nh của bản sắc Việt v&agrave; s&aacute;ng tạo Việt.<br />
&nbsp; &nbsp; - Phom d&aacute;ng cổ cao đầu ti&ecirc;n từ Biti&#39;s Hunter Street.<br />
&nbsp; &nbsp; - Mũ quai sử dụng chất liệu cao cấp l&agrave; DA B&Ograve; THẬT, kết hợp hoạ tiết trang tr&iacute; Simili.<br />
&nbsp; &nbsp; - L&oacute;t quai thun c&aacute; sấu kh&aacute;ng khuẩn gi&uacute;p hạn chế m&ugrave;i h&ocirc;i v&agrave; ẩm mốc. Cấu tr&uacute;c l&oacute;t đa lớp kết hợp xốp d&agrave;y v&agrave; &ecirc;m &aacute;i.&nbsp;<br />
&nbsp; &nbsp; - L&oacute;t đế trong (Insole) với chất liệu EVA c&ugrave;ng c&ocirc;ng nghệ &eacute;p khu&ocirc;n 3D theo bi&ecirc;n dạng b&agrave;n ch&acirc;n, &ocirc;m đều &amp; định vị tốt, tr&aacute;nh tuột ch&acirc;n khi vận động mạnh. Kết hợp với chất liệu thun kh&aacute;ng khuẩn, gi&uacute;p thấm h&uacute;t mồ h&ocirc;i, hạn chế m&ugrave;i v&agrave; ẩm mốc.&nbsp;<br />
&nbsp; &nbsp; - Đế (Outsole) với chất liệu EVA cao su R.E với t&iacute;nh năng mềm dẻo v&agrave; nhẹ hơn rất nhiều so với cao su truyền thống, nhưng vẫn đảm bảo khả năng chịu m&agrave;i m&ograve;n v&agrave; va chạm. Độ Shore ph&ugrave; hợp, &ecirc;m v&agrave; nẩy tốt gi&uacute;p bảo vệ v&agrave; n&acirc;ng đỡ b&agrave;n ch&acirc;n.&nbsp;<br />
&nbsp; &nbsp; - Đế hộp cao th&agrave;nh &ocirc;m gọn mũ quai v&agrave; liền lạc với mặt đế th&agrave;nh một khối gi&uacute;p sản phẩm bền bỉ v&agrave; linh hoạt trong mọi t&igrave;nh&nbsp;</p>', N'132711404656740378_block_home_category3_grande.jpg', 1, 25000000, 5)
INSERT [dbo].[Products] ([ID], [CategoryID], [Name], [Description], [Content], [Photo], [Hot], [Price], [Discount]) VALUES (11, 4, N'nike', N'<p>&nbsp;với thiết kế năng động, hiện đại gi&uacute;p người mang thể hiện phong c&aacute;ch ri&ecirc;ng, đồng thời hỗ trợ vận động tốt cho đ&ocirc;i ch&acirc;n trong mọi hoạt động. Th&acirc;n gi&agrave;y được cấu tạo bởi vật liệu bền bỉ, &ecirc;m &aacute;i gi&uacute;p bạn lu&ocirc;n cảm thấy thoải m&aacute;i khi mang trong thời gian d&agrave;i. Mặt trong đế d&agrave;y mềm mại n&acirc;ng niu l&ograve;ng b&agrave;n ch&acirc;n, c&ograve;n mặt ngo&agrave;i đế gi&agrave;y hạn chế m&agrave;i m&ograve;n, chống trơn trượt đem đến sự an to&agrave;n cho người mang. Form gi&agrave;y &ocirc;m ch&acirc;n c&ugrave;ng chất liệu th&acirc;n gi&agrave;y c&oacute; t&iacute;nh đ&agrave;n hồi theo chiều chuyển động của b&agrave;n ch&acirc;n gi&uacute;p bạn tự do hoạt động.&nbsp;<em>Gi&agrave;y chạy bộ Nike</em>&nbsp;sở hữu những đường n&eacute;t khỏe khoắn c&ugrave;ng gam m&agrave;u tinh tế, trẻ trung sẽ mang đến cho bạn những trải nghiệm tuyệt vời khi tham gia tập luyện thể thao hay c&aacute;c hoạt động kh&aacute;c thường ng&agrave;y. B&ecirc;n cạnh đ&oacute;, với một đ&ocirc;i gi&agrave;y thể thao, bạn c&oacute; thể phối với nhiều kiểu trang phục theo sở th&iacute;ch tạo n&ecirc;n set đồ ấn tượng, c&aacute; t&iacute;nh.&nbsp;với thiết kế năng động, hiện đại gi&uacute;p người mang thể hiện phong c&aacute;ch ri&ecirc;ng, đồng thời hỗ trợ vận động tốt cho đ&ocirc;i ch&acirc;n trong mọi hoạt động. Th&acirc;n gi&agrave;y được cấu tạo bởi vật liệu bền bỉ, &ecirc;m &aacute;i gi&uacute;p bạn lu&ocirc;n cảm thấy thoải m&aacute;i khi mang trong thời gian d&agrave;i. Mặt trong đế d&agrave;y mềm mại n&acirc;ng niu l&ograve;ng b&agrave;n ch&acirc;n, c&ograve;n mặt ngo&agrave;i đế gi&agrave;y hạn chế m&agrave;i m&ograve;n, chống trơn trượt đem đến sự an to&agrave;n cho người mang. Form gi&agrave;y &ocirc;m ch&acirc;n c&ugrave;ng chất liệu th&acirc;n gi&agrave;y c&oacute; t&iacute;nh đ&agrave;n hồi theo chiều chuyển động của b&agrave;n ch&acirc;n gi&uacute;p bạn tự do hoạt động.&nbsp;<em>Gi&agrave;y chạy bộ Nike</em>&nbsp;sở hữu những đường n&eacute;t khỏe khoắn c&ugrave;ng gam m&agrave;u tinh tế, trẻ trung sẽ mang đến cho bạn những trải nghiệm tuyệt vời khi tham gia tập luyện thể thao hay c&aacute;c hoạt động kh&aacute;c thường ng&agrave;y. B&ecirc;n cạnh đ&oacute;, với một đ&ocirc;i gi&agrave;y thể thao, bạn c&oacute; thể phối với nhiều kiểu trang phục theo sở th&iacute;ch tạo n&ecirc;n set đồ ấn tượng, c&aacute; t&iacute;nh.</p>', N'<p>&nbsp;với thiết kế năng động, hiện đại gi&uacute;p người mang thể hiện phong c&aacute;ch ri&ecirc;ng, đồng thời hỗ trợ vận động tốt cho đ&ocirc;i ch&acirc;n trong mọi hoạt động. Th&acirc;n gi&agrave;y được cấu tạo bởi vật liệu bền bỉ, &ecirc;m &aacute;i gi&uacute;p bạn lu&ocirc;n cảm thấy thoải m&aacute;i khi mang trong thời gian d&agrave;i. Mặt trong đế d&agrave;y mềm mại n&acirc;ng niu l&ograve;ng b&agrave;n ch&acirc;n, c&ograve;n mặt ngo&agrave;i đế gi&agrave;y hạn chế m&agrave;i m&ograve;n, chống trơn trượt đem đến sự an to&agrave;n cho người mang. Form gi&agrave;y &ocirc;m ch&acirc;n c&ugrave;ng chất liệu th&acirc;n gi&agrave;y c&oacute; t&iacute;nh đ&agrave;n hồi theo chiều chuyển động của b&agrave;n ch&acirc;n gi&uacute;p bạn tự do hoạt động.&nbsp;<em>Gi&agrave;y chạy bộ Nike</em>&nbsp;sở hữu những đường n&eacute;t khỏe khoắn c&ugrave;ng gam m&agrave;u tinh tế, trẻ trung sẽ mang đến cho bạn những trải nghiệm tuyệt vời khi tham gia tập luyện thể thao hay c&aacute;c hoạt động kh&aacute;c thường ng&agrave;y. B&ecirc;n cạnh đ&oacute;, với một đ&ocirc;i gi&agrave;y thể thao, bạn c&oacute; thể phối với nhiều kiểu trang phục theo sở th&iacute;ch tạo n&ecirc;n set đồ ấn tượng, c&aacute; t&iacute;nh.</p>', N'132712430831733281_5.jpg', 1, 2600000, 20)
INSERT [dbo].[Products] ([ID], [CategoryID], [Name], [Description], [Content], [Photo], [Hot], [Price], [Discount]) VALUES (12, 4, N'Giày chạy bộ nữ WMNS Nike Revolution 5 BQ3207-003', N'<p>&nbsp;với thiết kế năng động, hiện đại gi&uacute;p người mang thể hiện phong c&aacute;ch ri&ecirc;ng, đồng thời hỗ trợ vận động tốt cho đ&ocirc;i ch&acirc;n trong mọi hoạt động. Th&acirc;n gi&agrave;y được cấu tạo bởi vật liệu bền bỉ, &ecirc;m &aacute;i gi&uacute;p bạn lu&ocirc;n cảm thấy thoải m&aacute;i khi mang trong thời gian d&agrave;i. Mặt trong đế d&agrave;y mềm mại n&acirc;ng niu l&ograve;ng b&agrave;n ch&acirc;n, c&ograve;n mặt ngo&agrave;i đế gi&agrave;y hạn chế m&agrave;i m&ograve;n, chống trơn trượt đem đến sự an to&agrave;n cho người mang. Form gi&agrave;y &ocirc;m ch&acirc;n c&ugrave;ng chất liệu th&acirc;n gi&agrave;y c&oacute; t&iacute;nh đ&agrave;n hồi theo chiều chuyển động của b&agrave;n ch&acirc;n gi&uacute;p bạn tự do hoạt động.&nbsp;<em>Gi&agrave;y chạy bộ Nike</em>&nbsp;sở hữu những đường n&eacute;t khỏe khoắn c&ugrave;ng gam m&agrave;u tinh tế, trẻ trung sẽ mang đến cho bạn những trải nghiệm tuyệt vời khi tham gia tập luyện thể thao hay c&aacute;c hoạt động kh&aacute;c thường ng&agrave;y. B&ecirc;n cạnh đ&oacute;, với một đ&ocirc;i gi&agrave;y thể thao, bạn c&oacute; thể phối với nhiều kiểu trang phục theo sở th&iacute;ch tạo n&ecirc;n set đồ ấn tượng, c&aacute; t&iacute;nh.</p>', N'<p>&nbsp;Thiết kế mang phong c&aacute;ch hiện đại, năng động<br />
- Ph&ugrave; hợp với nhiều độ tuổi v&agrave; d&aacute;ng người<br />
- N&acirc;ng niu b&agrave;n ch&acirc;n tạo cảm gi&aacute;c &ecirc;m &aacute;i, thoải m&aacute;i khi di chuyển<br />
- Form gi&agrave;y &ocirc;m với độ chắc chắn cho to&agrave;n bộ b&agrave;n ch&acirc;n, hỗ trợ vận động tốt<br />
- Th&iacute;ch hợp mang khi chạy bộ hay tham gia c&aacute;c hoạt động thể thao kh&aacute;c</p>', N'132713905645952990_gallery_item_5.jpg', 1, 100000, 12)
INSERT [dbo].[Products] ([ID], [CategoryID], [Name], [Description], [Content], [Photo], [Hot], [Price], [Discount]) VALUES (13, 2, N'Giày thể thao Hunter Liteknit Summer Vibes xanh mi nơ DSM062633XMN', N'<p><strong>Gi&agrave;y thể thao Hunter Liteknit Summer Vibes xanh mi nơ</strong>&nbsp;với ngoại h&igrave;nh đẹp mắt, m&agrave;u sắc rực rỡ c&ugrave;ng phần đế phylon si&ecirc;u nhẹ hiện đang rất được ưa chuộng. Mẫu gi&agrave;y n&agrave;y cực kỳ th&iacute;ch hợp để mang khi tham gia c&aacute;c hoạt động ngo&agrave;i trời, thể thao&hellip; v&agrave; tạo n&ecirc;n vẻ trẻ trung, năng động cho người sử dụng.</p>', N'<h2>Những ưu điểm nổi bật</h2>

<h3>C&ocirc;ng nghệ dệt Liteknit</h3>

<p>Được &aacute;p dụng c&ocirc;ng nghệ dệt Liteknit hiện đại,&nbsp;<strong>gi&agrave;y thể thao Hunter Liteknit Summer Vibes xanh mi nơ</strong>&nbsp;c&oacute; nhiều lỗ tho&aacute;t kh&iacute; tr&ecirc;n th&acirc;n gi&agrave;y gi&uacute;p đ&ocirc;i ch&acirc;n lu&ocirc;n được tho&aacute;ng m&aacute;t trong khi sử dụng. Đồng thời, c&ocirc;ng nghệ dệt n&agrave;y c&ograve;n l&agrave;m cho việc vệ sinh gi&agrave;y dễ d&agrave;ng hơn rất nhiều.</p>

<p><img alt="giay the thao biti''s hunter liteknit xanh mi no 1" src="https://bitishunter.com/wp-content/uploads/2016/06/giay-the-thao-bitis-hunter-liteknit-xanh-mi-no-1.jpg" style="height:800px; width:800px" /></p>

<h3>Phần đế phylon si&ecirc;u nhẹ</h3>

<p>Phần đế của&nbsp;<strong>gi&agrave;y thể thao Hunter Liteknit Summer Vibes xanh mi nơ</strong>&nbsp;được l&agrave;m từ chất liệu phylon si&ecirc;u nhẹ gi&uacute;p người mang lu&ocirc;n cảm thấy nhẹ nh&otilde;m v&agrave; thanh tho&aacute;t, đồng thời kh&ocirc;ng bị mỏi khi vận động trong thời gian d&agrave;i.</p>

<p><img alt="giay-the-thao-biti''s-hunter-liteknit-xanh-mi-no-5" src="https://bitishunter.com/wp-content/uploads/2016/06/giay-the-thao-bitis-hunter-liteknit-xanh-mi-no-5-700x516.jpg" style="height:800px; width:800px" /></p>

<p><img alt="giay-the-thao-biti''s-hunter-liteknit-xanh-mi-no-3" src="https://bitishunter.com/wp-content/uploads/2016/06/giay-the-thao-bitis-hunter-liteknit-xanh-mi-no-3-650x516.jpg" style="height:800px; width:800px" /></p>

<p>&nbsp;</p>

<h3>Thiết kế đẹp mắt, m&agrave;u sắc bắt mắt</h3>

<p>C&ocirc;ng nghệ dệt Liteknit c&ograve;n gi&uacute;p cho đ&ocirc;i gi&agrave;y được phối m&agrave;u bắt mắt hơn v&agrave; tạo n&ecirc;n những hoa văn v&ocirc; c&ugrave;ng đẹp mắt v&agrave; cuốn h&uacute;t. M&agrave;u xanh mi nơ v&ocirc; c&ugrave;ng nổi bật kết hợp với phần đế m&agrave;u trắng v&agrave; xen kẽ với m&agrave;u đen tạo n&ecirc;n một tổng thể h&agrave;i h&ograve;a cho đ&ocirc;i gi&agrave;y.</p>

<p><img alt="giay-the-thao-biti''s-hunter-liteknit-xanh-mi-no-3" src="https://bitishunter.com/wp-content/uploads/2016/06/giay-the-thao-bitis-hunter-liteknit-xanh-mi-no-3-650x516.jpg" style="height:800px; width:800px" /></p>

<p>D&aacute;ng vẻ của đ&ocirc;i gi&agrave;y được thiết kế gọn g&agrave;ng v&agrave; tinh tế hơn, mang đến sự năng động v&agrave; trẻ trung, đồng thời ph&ugrave; hợp đa dạng nhu cầu của người d&ugrave;ng.</p>

<p><img alt="giay the thao biti''s hunter liteknit xanh mi no 6" src="https://bitishunter.com/wp-content/uploads/2016/06/giay-the-thao-bitis-hunter-liteknit-xanh-mi-no-6-700x516.jpg" style="height:516px; width:700px" /></p>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p><img alt="giay-the-thao-biti''s-hunter-liteknit-xanh-mi-no-6" src="https://bitishunter.com/wp-content/uploads/2016/06/giay-the-thao-bitis-hunter-liteknit-xanh-mi-no-6-700x516.jpg" style="height:800px; width:800px" /></p>

<p><a href="https://bitishunter.com/san-pham/giay-nu-bitis-hunter-liteknit-mau-xanh-mi-no-tre-trung-dsw051433xmn/">Gi&agrave;y thể thao Hunter Liteknit Summer Vibes xanh mi nơ</a>&nbsp;nổi bật v&agrave; c&oacute; ngoại h&igrave;nh kh&ocirc;ng thua k&eacute;m những mẫu gi&agrave;y của c&aacute;c thương hiệu quốc tế m&agrave; gi&aacute; cả lại cực phải chăng. H&atilde;y tậu ngay một đ&ocirc;i gi&agrave;y như thế n&agrave;y về v&agrave; h&ograve;a nhịp với cuộc sống s&ocirc;i động n&agrave;y nh&eacute;.</p>', N'132713908820353177_giay-the-thao-bitis-hunter-liteknit-xanh-mi-no-3.jpg', 1, 800000, 5)
INSERT [dbo].[Products] ([ID], [CategoryID], [Name], [Description], [Content], [Photo], [Hot], [Price], [Discount]) VALUES (14, 2, N'Giày thể thao nam Biti’s cao cấp lưới Air Mesh màu cam DSM062133CAM', N'<p><strong>T&iacute;nh năng nổi bật</strong><br />
M&agrave;u cam kết hợp với m&agrave;u đen nổi bật<br />
Chất liệu lưới Air Mesh th&ocirc;ng tho&aacute;ng<br />
Đế cao su c&oacute; r&atilde;nh chống trơn trượt<br />
In logo tr&ecirc;n mặt l&oacute;t v&agrave; sau g&oacute;t</p>

<p><strong>Th&ocirc;ng tin sản phẩm</strong></p>

<p>Thương hiệu: Biti&rsquo;s<br />
Model: DSM062133CAM<br />
M&agrave;u: Cam<br />
Chất liệu mặt tr&ecirc;n: Lưới<br />
Chất liệu đế gi&agrave;y: Cao su<br />
Size: 39, 40, 41, 42, 43, 44</p>', N'<h2>Những ưu điểm vượt trội</h2>

<h3>Chất liệu lưới Air Mesh cao cấp</h3>

<p>Được may từ chất liệu lưới cao cấp c&ugrave;ng c&ocirc;ng nghệ Air Mesh hiện đại,&nbsp;<strong>gi&agrave;y thể thao nam Biti&rsquo;s cao cấp lưới Air Mesh m&agrave;u cam</strong>&nbsp;c&oacute; khả năng tho&aacute;t ẩm rất tốt, gi&uacute;p cho đ&ocirc;i ch&acirc;n lu&ocirc;n th&ocirc;ng tho&aacute;ng, tr&aacute;nh cảm gi&aacute;c ẩm ướt v&agrave; kh&oacute; chịu trong suốt qu&aacute; tr&igrave;nh sử dụng.<br />
<img alt="hinh anh giay the thao bitis cao cap mau cam air mesh 1" src="https://bitishunter.com/wp-content/uploads/2016/07/giay-the-thao-bitis-cao-cap-luoi-air-mesh-mau-cam-dsm062133cam-1.jpg" style="height:800px; width:800px" /></p>

<h3>M&agrave;u sắc nổi bật, thu h&uacute;t</h3>

<p>Sắc cam cực k&igrave; bắt mắt kết hợp c&ugrave;ng phần d&acirc;y đen v&ocirc; c&ugrave;ng h&agrave;i h&ograve;a, nổi bật v&agrave; kh&ocirc;ng k&eacute;m phần sang trọng cũng l&agrave; một điểm thu h&uacute;t của&nbsp;<strong>gi&agrave;y thể thao nam Biti&rsquo;s cao cấp lưới Air Mesh m&agrave;u cam</strong>. Bạn sẽ kh&ocirc;ng bao giờ bị lẫn v&agrave;o đ&aacute;m đ&ocirc;ng khi diện một đ&ocirc;i gi&agrave;y c&aacute; t&iacute;nh như thế n&agrave;y.&nbsp;<img alt="giay the thao bitis cao cap mau cam air mesh 6" src="https://bitishunter.com/wp-content/uploads/2016/07/giay-the-thao-bitis-cao-cap-luoi-air-mesh-mau-cam-dsm062133cam-6.jpg" style="height:800px; width:800px" /></p>

<p><img alt="giay the thao bitis cao cap mau cam air mesh 5" src="https://bitishunter.com/wp-content/uploads/2016/07/giay-the-thao-bitis-cao-cap-luoi-air-mesh-mau-cam-dsm062133cam-5.jpg" style="height:702px; width:702px" /></p>

<h3>Đế cao su &ecirc;m &aacute;i, chống trơn trượt</h3>

<p>Với phần đế cao su d&agrave;y với những gai v&agrave; r&atilde;nh được thiết kế đều đặn tr&ecirc;n bề mặt tiếp đất gi&uacute;p chống trơn trượt, bạn sẽ lu&ocirc;n cảm thấy &ecirc;m &aacute;i v&agrave; an to&agrave;n khi sử dụng đ&ocirc;i gi&agrave;y tr&ecirc;n mọi địa h&igrave;nh.<br />
<img alt="giay the thao bitis cao cap mau cam air mesh 4" src="https://bitishunter.com/wp-content/uploads/2016/07/giay-the-thao-bitis-cao-cap-luoi-air-mesh-mau-cam-dsm062133cam-4.jpg" style="height:702px; width:702px" /></p>

<h3>Thiết kế d&aacute;ng thể thao năng động, logo tinh tế</h3>

<p>Với thiết kế đầy ph&oacute;ng kho&aacute;ng mang phong c&aacute;ch thể thao v&agrave; đường phố, bạn c&oacute; thể dễ d&agrave;ng phối gi&agrave;y trong nhiều trường hợp để sử dụng m&agrave; vẫn lu&ocirc;n c&aacute; t&iacute;nh v&agrave; đẹp mắt. Logo Biti&rsquo;s được in nhỏ gọn, tinh tế tr&ecirc;n th&acirc;n&nbsp;<strong>gi&agrave;y thể thao nam Biti&rsquo;s cao cấp lưới Air Mesh m&agrave;u cam</strong>&nbsp;cũng g&oacute;p phần l&agrave;m tăng sự sang trọng v&agrave; đẳng cấp cho đ&ocirc;i gi&agrave;y cũng như người sử dụng.<img alt="giay the thao bitis cao cap mau cam air mesh 3" src="https://bitishunter.com/wp-content/uploads/2016/07/giay-the-thao-bitis-cao-cap-luoi-air-mesh-mau-cam-dsm062133cam-3.jpg" style="height:702px; width:702px" /></p>

<p><img alt="giay the thao bitis cao cap mau cam air mesh 2" src="https://bitishunter.com/wp-content/uploads/2016/07/giay-the-thao-bitis-cao-cap-luoi-air-mesh-mau-cam-dsm062133cam-2.jpg" style="height:702px; width:702px" /></p>

<p><a href="https://bitishunter.com/san-pham/giay-the-thao-hunter-luoi-air-mesh-mau-xam-vang-dsm062133xam/">Gi&agrave;y thể thao nam Biti&rsquo;s cao cấp lưới Air Mesh m&agrave;u cam</a>&nbsp;ch&iacute;nh l&agrave; một sự khẳng định mạnh mẽ về thương hiệu cũng như đẳng cấp, uy t&iacute;n của Biti&rsquo;s. H&atilde;y chọn cho m&igrave;nh một đ&ocirc;i gi&agrave;y tuyệt vời như thế n&agrave;y để bản th&acirc;n lu&ocirc;n nổi bật v&agrave; thu h&uacute;t c&aacute;c bạn nam nh&eacute;.</p>', N'132713910025019049_giay-the-thao-bitis-cao-cap-luoi-air-mesh-mau-cam-dsm062133cam-1.jpg', 1, 900000, 12)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Rating] ON 

INSERT [dbo].[Rating] ([ID], [ProductID], [Star]) VALUES (1, 13, 3)
INSERT [dbo].[Rating] ([ID], [ProductID], [Star]) VALUES (2, 14, 3)
INSERT [dbo].[Rating] ([ID], [ProductID], [Star]) VALUES (3, 11, 1)
INSERT [dbo].[Rating] ([ID], [ProductID], [Star]) VALUES (4, 12, 5)
INSERT [dbo].[Rating] ([ID], [ProductID], [Star]) VALUES (5, 10, 2)
INSERT [dbo].[Rating] ([ID], [ProductID], [Star]) VALUES (6, 4, 4)
INSERT [dbo].[Rating] ([ID], [ProductID], [Star]) VALUES (7, 6, 2)
INSERT [dbo].[Rating] ([ID], [ProductID], [Star]) VALUES (8, 6, 3)
SET IDENTITY_INSERT [dbo].[Rating] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Name], [Email], [Password]) VALUES (1, N'Nguyễn Văn Nam', N'nvn@gmail.com', N'$2b$10$/MzAsDRud8t1eWA7RoMGqOvdz7TB9lm7DSLTKKT2XbCD76rDeXSNK')
INSERT [dbo].[Users] ([ID], [Name], [Email], [Password]) VALUES (2, N'Phan Tiến Độ', N'ptd@gmail.com', N'$2b$10$/MzAsDRud8t1eWA7RoMGqOvdz7TB9lm7DSLTKKT2XbCD76rDeXSNK')
INSERT [dbo].[Users] ([ID], [Name], [Email], [Password]) VALUES (3, N'Hoàng Lâm Oanh', N'hlo@gmail.com', N'$2b$10$/MzAsDRud8t1eWA7RoMGqOvdz7TB9lm7DSLTKKT2XbCD76rDeXSNK')
INSERT [dbo].[Users] ([ID], [Name], [Email], [Password]) VALUES (4, N'Nguyễn Văn Hải', N'nvh@gmail.com', N'$2b$10$/MzAsDRud8t1eWA7RoMGqOvdz7TB9lm7DSLTKKT2XbCD76rDeXSNK')
INSERT [dbo].[Users] ([ID], [Name], [Email], [Password]) VALUES (5, N'Phan Thanh An', N'pta@gmail.com', N'$2b$10$/MzAsDRud8t1eWA7RoMGqOvdz7TB9lm7DSLTKKT2XbCD76rDeXSNK')
INSERT [dbo].[Users] ([ID], [Name], [Email], [Password]) VALUES (6, N'Phạm Huy Hoàng', N'phh@gmail.com', N'123')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_news_hot]  DEFAULT ((0)) FOR [Hot]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_Discount_1]  DEFAULT ((0)) FOR [Discount]
GO
