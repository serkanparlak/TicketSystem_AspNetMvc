USE [TicketSystems]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 15.06.2019 00:38:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NOT NULL,
	[Oncelik] [nvarchar](50) NULL,
	[Konu] [nvarchar](150) NULL,
	[Icerik] [nvarchar](max) NULL,
	[ResimYol] [nvarchar](200) NULL,
	[Durum] [bit] NULL,
	[OkunduMu] [bit] NULL,
	[Tarih] [datetime] NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 15.06.2019 00:38:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAdi] [nvarchar](100) NULL,
	[Ad_Soyad] [nvarchar](30) NULL,
	[Sifre] [nvarchar](20) NULL,
	[Mail] [nvarchar](100) NULL,
	[Dogum] [nvarchar](50) NULL,
	[Rol] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yorum]    Script Date: 15.06.2019 00:38:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yorum](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ticket_ID] [int] NOT NULL,
	[User_ID] [int] NOT NULL,
	[Tarih] [datetime] NULL,
	[Icerik_Yorum] [nvarchar](max) NULL,
 CONSTRAINT [PK_Yorum] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Ticket] ON 
GO
INSERT [dbo].[Ticket] ([ID], [User_ID], [Oncelik], [Konu], [Icerik], [ResimYol], [Durum], [OkunduMu], [Tarih]) VALUES (44, 12, N'Düşük', N'Düşük öncelik', N'sadkjf', N'/Content/img/Ticket/137358fb08ff495bb6f91c6ea857e7c8.jpg', 0, 1, CAST(N'2016-08-11T11:17:03.540' AS DateTime))
GO
INSERT [dbo].[Ticket] ([ID], [User_ID], [Oncelik], [Konu], [Icerik], [ResimYol], [Durum], [OkunduMu], [Tarih]) VALUES (45, 12, N'Orta', N'Orta Öncelik', N'sdlkfjadfasdf', N'/Content/img/Ticket/49032a7fceae4829808bf21ac7bf785f.jpg', 0, 0, CAST(N'2016-08-11T11:17:19.927' AS DateTime))
GO
INSERT [dbo].[Ticket] ([ID], [User_ID], [Oncelik], [Konu], [Icerik], [ResimYol], [Durum], [OkunduMu], [Tarih]) VALUES (46, 12, N'Yüksek', N'Yüksek öncelik', N'sadkjfhoasdfasdfasdfasdfdafvg', N'/Content/img/Ticket/3b4c29946d5d491785859d2b587e7b78.jpg', 1, 1, CAST(N'2016-08-11T11:18:14.473' AS DateTime))
GO
INSERT [dbo].[Ticket] ([ID], [User_ID], [Oncelik], [Konu], [Icerik], [ResimYol], [Durum], [OkunduMu], [Tarih]) VALUES (47, 12, N'Orta', N'Resim yok', N'sdlkfjadsomgidsfg', NULL, 0, 0, CAST(N'2016-08-11T11:18:35.170' AS DateTime))
GO
INSERT [dbo].[Ticket] ([ID], [User_ID], [Oncelik], [Konu], [Icerik], [ResimYol], [Durum], [OkunduMu], [Tarih]) VALUES (50, 8, N'Orta', N'qwerew', N'ertew', NULL, 1, 1, CAST(N'2016-08-11T11:31:17.323' AS DateTime))
GO
INSERT [dbo].[Ticket] ([ID], [User_ID], [Oncelik], [Konu], [Icerik], [ResimYol], [Durum], [OkunduMu], [Tarih]) VALUES (51, 8, N'Orta', N'adgsfg', N'sdfgsd', NULL, 1, 0, CAST(N'2016-08-11T11:31:29.717' AS DateTime))
GO
INSERT [dbo].[Ticket] ([ID], [User_ID], [Oncelik], [Konu], [Icerik], [ResimYol], [Durum], [OkunduMu], [Tarih]) VALUES (54, 8, N'Yüksek', N'sadfsdf', N'asdfasdf', N'/Content/img/Ticket/50356273c2db436392e83709482372b1.jpg', 1, 1, CAST(N'2016-08-11T15:40:43.840' AS DateTime))
GO
INSERT [dbo].[Ticket] ([ID], [User_ID], [Oncelik], [Konu], [Icerik], [ResimYol], [Durum], [OkunduMu], [Tarih]) VALUES (55, 12, N'Düşük', N'dasgsdfg', N'sdfgsdfg', NULL, 1, 1, CAST(N'2016-08-11T15:41:41.033' AS DateTime))
GO
INSERT [dbo].[Ticket] ([ID], [User_ID], [Oncelik], [Konu], [Icerik], [ResimYol], [Durum], [OkunduMu], [Tarih]) VALUES (56, 8, N'Yüksek', N'dffcg', N'dfgf', N'/Content/img/Ticket/db028e130cdc4d5bb25ab1c296e81e2b.jpg', 1, 1, CAST(N'2016-08-11T15:45:09.407' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Ticket] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([ID], [KullaniciAdi], [Ad_Soyad], [Sifre], [Mail], [Dogum], [Rol]) VALUES (1, N'Serkanparlak81', N'Serkan Parlak', N'1234', N'serkanparlak27108@hotmail.com', N'', N'Admin')
GO
INSERT [dbo].[User] ([ID], [KullaniciAdi], [Ad_Soyad], [Sifre], [Mail], [Dogum], [Rol]) VALUES (2, N'Ahmetungor42', N'Ahmet Üngören', N'1234', N'ahmetungor421@hotmail.com', NULL, N'Kullanıcı')
GO
INSERT [dbo].[User] ([ID], [KullaniciAdi], [Ad_Soyad], [Sifre], [Mail], [Dogum], [Rol]) VALUES (3, N'Selcukbayramm', N'Selçuk Bayram', N'selcuk42', N'selcukbayramm@gmail.com', NULL, N'Kullanıcı')
GO
INSERT [dbo].[User] ([ID], [KullaniciAdi], [Ad_Soyad], [Sifre], [Mail], [Dogum], [Rol]) VALUES (4, N'Yusufprlkk', N'Yusuf Parlak', N'ysfprlk', N'yusufprlk@windowslive.com', NULL, N'Kullanıcı')
GO
INSERT [dbo].[User] ([ID], [KullaniciAdi], [Ad_Soyad], [Sifre], [Mail], [Dogum], [Rol]) VALUES (5, N'Veliyigit34', N'Veli Yiğit', N'veli34', N'veliyigit34@gmail.com', NULL, N'Kullanıcı')
GO
INSERT [dbo].[User] ([ID], [KullaniciAdi], [Ad_Soyad], [Sifre], [Mail], [Dogum], [Rol]) VALUES (7, N'asd', N'Oktay', N'asd', N'saldmf@hotmail.com', N'13.6.1938', N'Admin')
GO
INSERT [dbo].[User] ([ID], [KullaniciAdi], [Ad_Soyad], [Sifre], [Mail], [Dogum], [Rol]) VALUES (8, N'zxc', N'Ahmet Kerim', N'zxc', N'klasfn@hotma', N'2.4.1929', N'Kullanıcı')
GO
INSERT [dbo].[User] ([ID], [KullaniciAdi], [Ad_Soyad], [Sifre], [Mail], [Dogum], [Rol]) VALUES (9, N'asdkjnc', N'Ahmet', N'asd', N'klasfn@hotmae', N'2.4.1929', N'Kullanıcı')
GO
INSERT [dbo].[User] ([ID], [KullaniciAdi], [Ad_Soyad], [Sifre], [Mail], [Dogum], [Rol]) VALUES (10, N'abdi', N'Abdi Şakrak', N'qwer', N'adbi@gmail', N'16.11.1936', N'Kullanıcı')
GO
INSERT [dbo].[User] ([ID], [KullaniciAdi], [Ad_Soyad], [Sifre], [Mail], [Dogum], [Rol]) VALUES (11, N'mikail42', N'mikail', N'1234', N'adbi@gmaild', N'13.5.1931', N'Kullanıcı')
GO
INSERT [dbo].[User] ([ID], [KullaniciAdi], [Ad_Soyad], [Sifre], [Mail], [Dogum], [Rol]) VALUES (12, N'qwe', N'qwe ewq', N'qwe', N'qwe@htm.com', NULL, N'Kullanıcı')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Yorum] ON 
GO
INSERT [dbo].[Yorum] ([ID], [Ticket_ID], [User_ID], [Tarih], [Icerik_Yorum]) VALUES (51, 51, 7, CAST(N'2016-08-11T11:38:14.337' AS DateTime), N'konuş')
GO
INSERT [dbo].[Yorum] ([ID], [Ticket_ID], [User_ID], [Tarih], [Icerik_Yorum]) VALUES (52, 51, 8, CAST(N'2016-08-11T11:43:09.107' AS DateTime), N'sa dostıum')
GO
INSERT [dbo].[Yorum] ([ID], [Ticket_ID], [User_ID], [Tarih], [Icerik_Yorum]) VALUES (53, 51, 8, CAST(N'2016-08-11T11:43:51.497' AS DateTime), N'asdfsd')
GO
INSERT [dbo].[Yorum] ([ID], [Ticket_ID], [User_ID], [Tarih], [Icerik_Yorum]) VALUES (54, 51, 8, CAST(N'2016-08-11T11:44:18.530' AS DateTime), N'sadfasdf')
GO
INSERT [dbo].[Yorum] ([ID], [Ticket_ID], [User_ID], [Tarih], [Icerik_Yorum]) VALUES (55, 51, 7, CAST(N'2016-08-11T11:44:34.987' AS DateTime), N'asdfsd')
GO
INSERT [dbo].[Yorum] ([ID], [Ticket_ID], [User_ID], [Tarih], [Icerik_Yorum]) VALUES (56, 51, 8, CAST(N'2016-08-11T15:34:46.973' AS DateTime), N'selam yiğen')
GO
INSERT [dbo].[Yorum] ([ID], [Ticket_ID], [User_ID], [Tarih], [Icerik_Yorum]) VALUES (57, 50, 8, CAST(N'2016-08-11T15:35:01.623' AS DateTime), N'saşls')
GO
INSERT [dbo].[Yorum] ([ID], [Ticket_ID], [User_ID], [Tarih], [Icerik_Yorum]) VALUES (58, 47, 12, CAST(N'2016-08-11T15:35:35.803' AS DateTime), N'asdfasd')
GO
INSERT [dbo].[Yorum] ([ID], [Ticket_ID], [User_ID], [Tarih], [Icerik_Yorum]) VALUES (59, 46, 12, CAST(N'2016-08-11T15:35:44.903' AS DateTime), N'asdf')
GO
INSERT [dbo].[Yorum] ([ID], [Ticket_ID], [User_ID], [Tarih], [Icerik_Yorum]) VALUES (60, 45, 12, CAST(N'2016-08-11T15:35:50.673' AS DateTime), N'asdfa')
GO
INSERT [dbo].[Yorum] ([ID], [Ticket_ID], [User_ID], [Tarih], [Icerik_Yorum]) VALUES (61, 44, 12, CAST(N'2016-08-11T15:35:56.033' AS DateTime), N'asdfsd')
GO
INSERT [dbo].[Yorum] ([ID], [Ticket_ID], [User_ID], [Tarih], [Icerik_Yorum]) VALUES (64, 46, 7, CAST(N'2016-08-11T15:39:33.063' AS DateTime), N'haşslkdmsdflkm')
GO
INSERT [dbo].[Yorum] ([ID], [Ticket_ID], [User_ID], [Tarih], [Icerik_Yorum]) VALUES (65, 56, 8, CAST(N'2016-08-11T15:46:26.977' AS DateTime), N'sdfsdfs')
GO
INSERT [dbo].[Yorum] ([ID], [Ticket_ID], [User_ID], [Tarih], [Icerik_Yorum]) VALUES (66, 56, 7, CAST(N'2016-08-12T10:00:54.657' AS DateTime), N'asdasd')
GO
INSERT [dbo].[Yorum] ([ID], [Ticket_ID], [User_ID], [Tarih], [Icerik_Yorum]) VALUES (67, 55, 7, CAST(N'2016-08-12T10:11:58.667' AS DateTime), N'1')
GO
INSERT [dbo].[Yorum] ([ID], [Ticket_ID], [User_ID], [Tarih], [Icerik_Yorum]) VALUES (68, 54, 7, CAST(N'2016-08-12T10:12:05.447' AS DateTime), N'2')
GO
INSERT [dbo].[Yorum] ([ID], [Ticket_ID], [User_ID], [Tarih], [Icerik_Yorum]) VALUES (69, 50, 7, CAST(N'2016-08-12T10:12:12.620' AS DateTime), N'3')
GO
INSERT [dbo].[Yorum] ([ID], [Ticket_ID], [User_ID], [Tarih], [Icerik_Yorum]) VALUES (70, 44, 7, CAST(N'2016-08-12T10:19:37.317' AS DateTime), N'asdasdasdasd')
GO
SET IDENTITY_INSERT [dbo].[Yorum] OFF
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Rol]  DEFAULT ('Kullanıcı') FOR [Rol]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_User] FOREIGN KEY([User_ID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_User]
GO
ALTER TABLE [dbo].[Yorum]  WITH CHECK ADD  CONSTRAINT [FK_Yorum_Ticket] FOREIGN KEY([Ticket_ID])
REFERENCES [dbo].[Ticket] ([ID])
GO
ALTER TABLE [dbo].[Yorum] CHECK CONSTRAINT [FK_Yorum_Ticket]
GO
ALTER TABLE [dbo].[Yorum]  WITH CHECK ADD  CONSTRAINT [FK_Yorum_User] FOREIGN KEY([User_ID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Yorum] CHECK CONSTRAINT [FK_Yorum_User]
GO
