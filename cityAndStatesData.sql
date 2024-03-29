/****** Object:  Table [dbo].[Cities]    Script Date: 3/31/2023 1:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id] [int] NOT NULL,
	[StateId] [int] NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[States]    Script Date: 3/31/2023 1:58:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (1, 1, N'تهران ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (31, 31, N'كرج ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (41, 2, N'رشت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (51, 3, N'تبريز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (61, 4, N'اهواز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (71, 5, N'شيراز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (81, 6, N'اصفهان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (91, 7, N'مشهد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (331, 1, N'اسلام شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (341, 8, N'قزوين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (351, 9, N'سمنان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (361, 9, N'شاهرود ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (371, 10, N'قم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (381, 11, N'اراك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (391, 11, N'ساوه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (431, 2, N'بندرانزلي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (441, 2, N'لاهيجان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (451, 12, N'زنجان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (461, 13, N'آمل ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (471, 13, N'بابل ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (481, 13, N'ساري ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (491, 14, N'گرگان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (531, 3, N'ميانه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (541, 3, N'مرند ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (551, 3, N'مراغه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (561, 15, N'اردبيل ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (571, 16, N'اروميه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (573, 16, N'سيلوه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (581, 16, N'خوي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (591, 16, N'مهاباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (631, 4, N'آبادان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (641, 4, N'خرمشهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (651, 17, N'همدان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (661, 18, N'سنندج ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (671, 19, N'كرمانشاه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (681, 20, N'خرم آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (691, 20, N'بروجرد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (731, 5, N'كازرون ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (741, 5, N'جهرم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (751, 21, N'بوشهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (761, 22, N'كرمان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (771, 22, N'رفسنجان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (781, 22, N'سيرجان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (791, 23, N'بندرعباس ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (831, 6, N'شاهين شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (841, 6, N'خميني شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (851, 6, N'نجف آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (861, 6, N'شهرضا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (871, 6, N'كاشان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (881, 24, N'شهركرد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (891, 25, N'يزد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (931, 7, N'نيشابور ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (941, 29, N'بجنورد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (951, 7, N'تربت حيدريه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (961, 7, N'سبزوار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (971, 30, N'بیرجند ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (981, 26, N'زاهدان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (991, 26, N'ايرانشهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (1011, 1, N'منطقه 11 پستي تهران ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (1012, 1, N'تجزيه مبادلات لشكر   ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (1013, 1, N'منطقه 13 پستي تهران ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (1014, 1, N'منطقه 14 پستي تهران ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (1015, 1, N'منطقه 15 پستي تهران ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (1016, 1, N'منطقه 16 پستي تهران ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (1017, 1, N'منطقه 17 پستي تهران   ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (1018, 1, N'منطقه 18 پستي تهران   ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (1019, 1, N'منطقه 19 پستي تهران   ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (1813, 1, N'ري ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3331, 31, N'نظرآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3341, 1, N'لواسان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3351, 1, N'شهريار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3361, 31, N'هشتگرد ـ ساوجبلاغ ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3371, 1, N'ورامين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3381, 1, N'پيشوا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3391, 1, N'پاكدشت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3410, 8, N'شهر صنعتي البرز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3431, 8, N'الوند ـ البرز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3441, 8, N'آبيك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3451, 8, N'بوئين زهرا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3461, 8, N'َآوج ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3481, 8, N'تاكستان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3491, 8, N'محمديه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3551, 9, N'سرخه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3561, 9, N'مهدي شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3571, 9, N'شهميرزاد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3581, 9, N'گرمسار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3591, 9, N'ايوانكي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3631, 9, N'ميامي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3641, 9, N'بسطام ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3651, 9, N'مجن ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3661, 9, N'بيارجمند ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3671, 9, N'دامغان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3681, 9, N'اميريه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3731, 10, N'قنوات ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3741, 10, N'دستجرد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3751, 1, N'شهر قدس ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3761, 1, N'رباط كريم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3781, 11, N'محلات ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3791, 11, N'دليجان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3841, 11, N'خنداب ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3851, 11, N'كميجان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3861, 11, N'شازند ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3871, 11, N'آستانه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3881, 11, N'خمين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3941, 11, N'مامونيه ـ زرنديه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3951, 11, N'تفرش ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3961, 11, N'آشتيان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3971, 1, N'دماوند ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3981, 1, N'فيروزكوه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (3991, 11, N'شهرك مهاجران ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4331, 2, N'آبكنار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4341, 2, N'خمام ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4351, 2, N'فومن ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4361, 2, N'صومعه سرا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4371, 2, N'هشتپر ـ طوالش ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4381, 2, N'ماسال ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4391, 2, N'آستارا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4431, 2, N'سياهكل ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4441, 2, N'آستانه اشرفيه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4451, 2, N'منجيل ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4461, 2, N'رودبار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4471, 2, N'لنگرود ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4481, 2, N'رودسر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4491, 2, N'كلاچاي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4531, 12, N'زرين آباد ـ ايجرود ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4541, 12, N'ماهنشان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4551, 12, N'سلطانيه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4561, 12, N'ابهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4571, 12, N'خرمدره ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4581, 12, N'قيدار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4591, 12, N' آب بر ـ طارم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4631, 13, N'محمودآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4641, 13, N'نور ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4651, 13, N'نوشهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4661, 13, N'چالوس ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4671, 13, N'سلمانشهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4681, 13, N'تنكابن ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4691, 13, N'رامسر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4731, 13, N'اميركلا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4741, 13, N'بابلسر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4751, 13, N'فريدون كنار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4761, 13, N'قائم شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4771, 13, N'جويبار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4781, 13, N'زيرآب ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4791, 13, N'پل سفيد ـ سوادكوه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4831, 13, N'كياسر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4841, 13, N'نكاء ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4851, 13, N'بهشهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4861, 13, N'گلوگاه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4871, 14, N'بندر گز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4881, 14, N'كردكوي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4891, 14, N'بندرتركمن ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4931, 14, N'آق قلا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4941, 14, N'علي آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4951, 14, N'راميان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4961, 14, N'آزادشهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4971, 14, N'گنبدكاوس ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4981, 14, N'مينودشت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (4991, 14, N'كلاله ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5321, 3, N'سبلان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5331, 3, N'شهر جديد سهند ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5351, 3, N'اسكو ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5361, 3, N'سردرود ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5371, 3, N'آذرشهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5381, 3, N'شبستر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5391, 3, N'هريس ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5431, 3, N'هاديشهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5441, 3, N'جلفا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5451, 3, N'اهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5461, 3, N'كليبر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5471, 3, N'سراب ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5491, 3, N'بستان آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5541, 3, N'عجب شير ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5551, 3, N'بناب ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5561, 3, N'ملكان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5571, 3, N'هشترود ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5581, 3, N'قره اغاج ـ چاراويماق ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5586, 3, N'اغچه ريش ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5631, 15, N'نمين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5641, 15, N'نير ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5651, 15, N'گرمي  ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5661, 15, N'مشگين شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5671, 15, N'بيله سوار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5681, 15, N'خلخال ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5691, 15, N'پارس آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5751, 16, N'قوشچي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5761, 16, N'نقده ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5771, 16, N'اشنويه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5781, 16, N'پيرانشهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5831, 16, N'ايواوغلي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5837, 16, N'ديزجديز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5851, 16, N'قره ضياء الدين ـ چايپاره ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5861, 16, N'ماكو ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5871, 16, N'سيه چشمه ـ چالدران ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5881, 16, N'سلماس ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5891, 16, N'تازه شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5951, 16, N'بوكان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5961, 16, N'سردشت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5971, 16, N'مياندوآب ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5981, 16, N'شاهين دژ ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (5991, 16, N'تكاب ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6331, 4, N'اروندكنار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6341, 4, N'ملاثاني ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6351, 4, N'ماهشهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6361, 4, N'بهبهان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6371, 4, N'آغاجاري ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6381, 4, N'رامهرمز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6391, 4, N'ايذه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6431, 4, N'شادگان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6441, 4, N'سوسنگرد ـ دشت آزادگان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6451, 4, N'شوشتر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6461, 4, N'دزفول ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6471, 4, N'شوش ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6481, 4, N'انديمشك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6491, 4, N'مسجد سليمان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6531, 17, N'بهار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6541, 17, N'اسدآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6551, 17, N'كبودرآهنگ ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6561, 17, N'فامنين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6571, 17, N'ملاير ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6581, 17, N'تويسركان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6591, 17, N'نهاوند ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6631, 18, N'كامياران ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6641, 18, N'ديواندره ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6651, 18, N'بيجار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6661, 18, N'قروه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6671, 18, N'مريوان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6681, 18, N'سقز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6691, 18, N'بانه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6731, 19, N'هرسين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6741, 19, N'كنگاور ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6751, 19, N'سنقر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6761, 19, N'اسلام آباد غرب ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6771, 19, N'سرپل ذهاب ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6781, 19, N'قصرشيرين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6791, 19, N'پاوه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6831, 20, N'نورآباد ـ دلفان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6841, 20, N'كوهدشت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6851, 20, N'پل دختر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6861, 20, N'اليگودرز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6871, 20, N'ازنا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6881, 20, N'دورود ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6891, 20, N'الشتر ـ سلسله ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6931, 27, N'ايلام ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6941, 27, N'ايوان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6951, 27, N'سرابله ـ شيروان و چرداول ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6961, 27, N'دره شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6971, 27, N'آبدانان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6981, 27, N'دهلران ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (6991, 27, N'مهران ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7331, 5, N'قائميه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7341, 5, N'زرقان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7351, 5, N'نورآباد ـ ممسني ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7361, 5, N'اردكان ـ سپيدان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7371, 5, N'مرودشت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7381, 5, N'اقليد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7391, 5, N'آباده ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7431, 5, N'لار ـ لارستان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7441, 5, N'گراش ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7451, 5, N'استهبان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7461, 5, N'فسا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7471, 5, N'فيروزآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7481, 5, N'داراب ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7491, 5, N'ني ريز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7531, 21, N'بندرگناوه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7541, 21, N'خورموج ـ دشتي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7551, 21, N'اهرم ـ تنگستان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7561, 21, N'برازجان ـ دشتستان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7571, 28, N'دهدشت ـ كهگيلويه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7581, 28, N'دوگنبدان ـ گچساران ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7591, 28, N'ياسوج ـ 7591 ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7631, 22, N'ماهان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7641, 22, N'گلباف ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7651, 22, N'راور ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7661, 22, N'بم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7681, 22, N'راين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7691, 22, N'محمدآباد ـ ريگان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7731, 22, N'سرچشمه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7741, 22, N'انار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7751, 22, N'شهربابك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7761, 22, N'زرند ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7771, 22, N'كيان شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7781, 22, N'كوهبنان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7791, 22, N'چترود ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7831, 22, N'پاريز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7841, 22, N'بردسير ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7851, 22, N'بافت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7861, 22, N'جيرفت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7871, 22, N'عنبرآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7881, 22, N'كهنوج ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7891, 22, N'منوجان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7931, 23, N'بندرخمير ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7941, 23, N'كيش ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7951, 23, N'قشم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7961, 23, N'بستك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7971, 23, N'بندرلنگه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7981, 23, N'ميناب ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (7991, 23, N'دهبارز ـ رودان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8161, 6, N'شهرک صنعتي محمودآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8331, 6, N'مورچه خورت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8341, 6, N'دولت آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8351, 6, N'ميمه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8361, 6, N'خور ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8371, 6, N'كوهپايه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8381, 6, N'اردستان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8391, 6, N'نائين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8431, 6, N'درچه پياز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8441, 6, N'زواره ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8451, 6, N'فلاورجان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8461, 6, N'قهد ريجان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8471, 6, N'زرين شهر ـ لنجان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8481, 6, N'مباركه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8491, 6, N'فولادشهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8531, 6, N'تيران ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8541, 6, N'دهق ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8551, 6, N'علويچه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8561, 6, N'داران ـ فريدن ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8571, 6, N'چادگان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8581, 6, N'ویلاشهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8591, 6, N'فريدون شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8631, 6, N'شهرك مجلسي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8641, 6, N'دهاقان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8651, 6, N'اسفرجان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8661, 6, N'سميرم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8741, 6, N'آران وبيدگل ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8761, 6, N'نطنز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8771, 6, N'گلپايگان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8781, 6, N'گوگد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8791, 6, N'خوانسار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8831, 24, N'فرخ شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8834, 24, N'دزك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8841, 24, N'هفشجان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8844, 24, N'هاروني ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8851, 24, N'سامان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8861, 24, N'فارسان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8871, 24, N'بروجن ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8881, 24, N'اردل ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8891, 24, N'لردگان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8931, 25, N'ابركوه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8941, 25, N'صدوق ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8951, 25, N'اردكان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8961, 25, N'ميبد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8971, 25, N'بافق ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8981, 25, N'مهريز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (8991, 25, N'تفت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9331, 7, N'فيروزه ـ تخت جلگه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9351, 7, N'طرقبه ـ بينالود ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9361, 7, N'چناران ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9371, 7, N'كلات ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9381, 7, N'سرخس ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9391, 7, N'فريمان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9431, 29, N'گرمه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9441, 29, N'جاجرم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9451, 29, N'آشخانه ـ مانه و سلمقان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9461, 29, N'شيروان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9471, 7, N'قوچان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9481, 29, N'فاروج ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9491, 7, N'درگز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9531, 7, N'فيض آباد ـ مه ولات ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9541, 7, N'رشتخوار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9561, 7, N'خواف ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9571, 7, N'تربت جام ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9581, 7, N'صالح آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9591, 7, N'تايباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9631, 7, N'داورزن ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9641, 7, N'جغتاي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9661, 29, N'اسفراين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9671, 7, N'كاشمر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9681, 7, N'بردسكن ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9691, 7, N'گناباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9741, 30, N'سر بیشه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9751, 30, N'نهبندان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9761, 30, N'قائن ـ قائنات ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9771, 30, N'فردوس ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9781, 30, N'بشرويه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9791, 25, N'طبس ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9831, 26, N'نصرت آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9841, 26, N'ميرجاوه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9851, 26, N'دوست محمد ـ هيرمند ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9861, 26, N'زابل ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9871, 26, N'زهك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9891, 26, N'خاش ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9931, 26, N'سرباز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9941, 26, N'بمپور ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9951, 26, N'سراوان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9961, 26, N'سوران ـ سيب سوران ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9971, 26, N'چابهار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9981, 26, N'كنارك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (9991, 26, N'نيك شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (16531, 1, N'جاجرود ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (16551, 1, N'بومهن ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (16561, 1, N'شهرجديدپرديس ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (16571, 1, N'خرمدشت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (16581, 1, N'پرديس ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (18131, 1, N'باقر شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (18161, 1, N'كهريزك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (18331, 1, N'حسن آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (18341, 1, N'شمس آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (18361, 1, N'چرمسازي سالاريه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (18381, 1, N'فرودگاه امام خميني ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (18391, 1, N'وهن آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (18471, 1, N'فرون آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (18641, 1, N'اسلام آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (18661, 1, N'قيام دشت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (18686, 1, N'قرچك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (19561, 1, N'سوهانك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (19731, 1, N'پس قلعه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (19841, 1, N'دركه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (31541, 1, N'ادران ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (31551, 31, N'آسارا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (31638, 31, N'گرمدره ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (31641, 1, N'صفادشت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (31686, 1, N'انديشه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (31691, 1, N'ملارد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (31776, 31, N'مشکين دشت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (31778, 31, N'محمدشهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (31849, 31, N'ماهدشت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (31871, 31, N'اشتهارد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (31991, 31, N'كمال شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33131, 1, N'احمدآبادمستوفي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33141, 1, N'مروزبهرام ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33151, 1, N'گلدسته ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33171, 1, N'صالح آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33176, 1, N'واوان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33191, 1, N'چهاردانگه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33361, 1, N'سعيدآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33411, 1, N'حومه گلندوك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33431, 1, N'اوشان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33451, 1, N'فشم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33461, 1, N'لوسان بزرگ ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33511, 1, N'شهرياربردآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33541, 1, N'باغستان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33551, 1, N'شهرآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33561, 1, N'شاهدشهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33581, 1, N'وحيديه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33611, 31, N'سيف آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33618, 31, N'شهر جديد هشتگرد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33631, 1, N'برغان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33651, 31, N'كوهسار ـ چندار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33661, 31, N'چهارباغ ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33691, 31, N'طالقان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33841, 1, N'خاوه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33941, 1, N'شريف آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33971, 1, N'پارچين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (33991, 1, N'خاتون آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (34131, 8, N'محمود آباد نمونه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (34151, 8, N'بیدستان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (34171, 8, N'اقباليه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (34481, 8, N'خاكعلي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (34491, 8, N'ليا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (34561, 8, N'اسفرورين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (34571, 8, N'شال ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (34581, 8, N'دانسفهان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (34641, 8, N'آبگرم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (34671, 8, N'ارداق ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (34691, 8, N'حصاروليعصر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (34741, 8, N'سيردان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (34791, 8, N'آقابابا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (34811, 8, N'نرجه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (34831, 8, N'خرم دشت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (34851, 8, N'ضياآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (34931, 8, N'معلم كلايه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (35331, 9, N'خيرآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (35631, 9, N'درجزين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (35861, 9, N'ارادان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (36441, 9, N'ميغان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (37351, 10, N'كهك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (37441, 10, N'شهر جعفریه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (37461, 10, N'سلفچگان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (37511, 1, N'مويز) ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (37541, 1, N'مارليك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (37551, 1, N'نصيرآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (37561, 1, N'رزگان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (37571, 1, N'بهارستان) ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (37611, 1, N'پرند ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (37631, 1, N'سلطان آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (37651, 1, N'بهارستان) ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (37671, 1, N'اكبرآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (37761, 11, N'خشك رود ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (38451, 11, N'جاورسيان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (38541, 11, N'خسروبيك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (38551, 11, N'ميلاجرد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (38661, 11, N'توره ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (38761, 11, N'هندودر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (38941, 11, N'ريحان عليا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (39441, 11, N'زاويه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (39531, 11, N'فرمهين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (39541, 11, N'شهراب ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (39711, 1, N'گيلاوند ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (39731, 1, N'رودهن ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (39741, 1, N'آبعلي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (39751, 1, N'كيلان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (39761, 1, N'آبسرد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (39861, 1, N'اميريه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43331, 2, N'كپورچال ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43361, 2, N'سنگر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43371, 2, N'اسلام آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43381, 2, N'سراوان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43391, 2, N'خشك بيجار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43431, 2, N'لشت نشا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43441, 2, N'پيربست لولمان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43451, 2, N'خاچكين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43461, 2, N'كوچصفهان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43471, 2, N'بلسبنه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43481, 2, N'چاپارخانه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43531, 2, N'لولمان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43541, 2, N'شفت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43561, 2, N'چوبر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43571, 2, N'ماسوله ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43581, 2, N'گشت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43591, 2, N'احمد سرگوراب ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43651, 2, N'طاهر گوداب ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43731, 2, N'بازاراسالم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43751, 2, N'جوكندان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43761, 2, N'ليسار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43771, 2, N'خطبه سرا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43791, 2, N'پلاسي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43811, 2, N'بازارجمعه شاندرمن ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43841, 2, N'رضوان شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43851, 2, N'شاندرمن ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43861, 2, N'پرهسر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43891, 2, N'اسالم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (43961, 2, N'لوندويل ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (44331, 2, N'پاشاكي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (44391, 2, N'ديلمان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (44471, 2, N'كياشهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (44531, 2, N'لوشان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (44551, 2, N'جيرنده ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (44561, 2, N'برهسر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (44641, 2, N'رستم آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (44651, 2, N'توتكابن ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (44681, 2, N'اسكلك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (44761, 2, N'كومله ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (44791, 2, N'اطاقور ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (44831, 2, N'قاسم آبادسفلي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (44851, 2, N'طوللات ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (44861, 2, N'رانكوه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (44871, 2, N'چابكسر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (44891, 2, N'واجارگاه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (44931, 2, N'رحيم آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (44941, 2, N'بلترك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (44951, 2, N'املش ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (44992, 2, N'پونل ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (45331, 12, N'همايون ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (45371, 12, N'اسفجين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (45431, 12, N'پري ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (45471, 12, N'دندي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (45731, 12, N'هيدج ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (45741, 12, N'صائين قلعه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (45871, 12, N'گرماب ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (45881, 12, N'زرين رود ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (45931, 12, N'گيلوان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (45941, 12, N'دستجرده ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (45971, 12, N'حلب ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (46341, 13, N'سرخرود ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (46371, 13, N'سوا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (46391, 13, N'گزنك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (46411, 13, N'ايزدشهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (46431, 13, N'چمستان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (46471, 13, N'بلده ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (46561, 13, N'رويانشهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (46641, 13, N'مرزن آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (46661, 13, N'كلاردشت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (46731, 13, N'كلارآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (46741, 13, N'عباس آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (46831, 13, N'نشتارود ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (46851, 13, N'خرم آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (46861, 13, N'شيرود ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (46931, 13, N'سادات محله ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (47331, 13, N'خوشرودپی ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (47341, 13, N'آهنگركلا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (47441, 13, N'بهنمير ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (47561, 13, N'مرزي كلا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (47581, 13, N'زرگر محله ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (47731, 13, N'كيا كلا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (47871, 13, N'شيرگاه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (48351, 13, N'سنگده ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (48441, 13, N'سورك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (48451, 13, N'اسلام آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (48461, 13, N'گهرباران ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (48541, 13, N'زاغمرز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (48561, 13, N'رستم كلا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (48733, 14, N'مراوه تپه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (48961, 14, N'گميش تپه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (48971, 14, N'سيمين شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (49351, 14, N'جلين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (49391, 14, N'انبار آلوم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (49431, 14, N'فاضل آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (49531, 14, N'خان ببين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (49751, 14, N'اينچه برون ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (49831, 14, N'گاليكش ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (53331, 3, N'ترك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (53551, 3, N'خسروشهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (53581, 3, N'ايلخچي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (53641, 3, N'خلجان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (53661, 3, N'باسمنج ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (53671, 3, N'شادبادمشايخ ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (53681, 3, N'كندرود ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (53751, 3, N'ممقان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (53761, 3, N'گوگان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (53841, 3, N'خامنه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (53851, 3, N'سيس ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (53861, 3, N'صوفيان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (53881, 3, N'تسوج ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (53891, 3, N'شرفخانه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (53951, 3, N'بخشايش ـ كلوانق ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (54351, 3, N'بناب جديد ـ مرند ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (54491, 3, N'هوراند ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (54561, 3, N'اذغان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (54581, 3, N'ورزقان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (54671, 3, N'ابشاحمد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (54683, 3, N'خداآفرين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (54685, 3, N'كندوان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (54731, 3, N'اسب فروشان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (54751, 3, N'شربيان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (54941, 3, N'قره بابا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (54971, 3, N'كردكندي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (55441, 3, N'خضرلو ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (55541, 3, N'القو ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (55661, 3, N'اقمنار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (56331, 15, N'ابي بيگلو ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (56391, 15, N'سرعين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (56431, 15, N'كوارئيم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (56581, 15, N'تازه كند انگوت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (56653, 15, N'لاهرود ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (56751, 15, N'جعفرآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (56851, 15, N'گيوي ـ كوثر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (56871, 15, N'هشتجين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (56891, 15, N'كلور ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (56971, 15, N'شهرك شهيد غفاري ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (56981, 15, N'اصلاندوز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (57351, 16, N'مياوق ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (57381, 16, N'نوشين شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (57411, 16, N'سيلوانا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (57451, 16, N'ديزج ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (57461, 16, N'زيوه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (57661, 16, N'محمد يار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (57951, 16, N'پسوه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (58671, 16, N'بازرگان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (58751, 16, N'شوط ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (58771, 16, N'پلدشت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (59671, 16, N'ميرآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (59691, 16, N'ربط ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (59731, 16, N'اقبال) ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (59771, 16, N'چهاربرج قديم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (59861, 16, N'محمودآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (61481, 4, N'شيبان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (61491, 4, N'ويس ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (63441, 4, N'حميديه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (63541, 4, N'چمران ـ شهرك طالقاني  ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (63551, 4, N'سربندر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (63561, 4, N'بندرامام خميني ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (63591, 4, N'هنديجان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (63661, 4, N'كردستان بزرگ ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (63681, 4, N'سردشت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (63731, 4, N'اميديه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (63751, 4, N'ميانكوه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (63871, 4, N'رامشير ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (63881, 4, N'جايزان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (63951, 4, N'باغ ملك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (63991, 4, N'دهدز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (64451, 4, N'هويزه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (64511, 4, N'شرافت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (64541, 4, N'جنت مكان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (64551, 4, N'گتوند ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (64561, 4, N'سماله ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (64651, 4, N'دزآب ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (64791, 4, N'صالح مشطت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (64941, 4, N'لالي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (64961, 4, N'هفتگل ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (65331, 17, N'لالجين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (65361, 17, N'صالح آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (65571, 17, N'شيرين سو ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (65631, 17, N'قهاوند ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (65671, 17, N'دمق ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (65681, 17, N'رزن ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (65691, 17, N'قروه درجزين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (65761, 17, N'سامن ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (65791, 17, N'اسلام آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (65841, 17, N'سركان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (65961, 17, N'گيان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (65992, 17, N'پايگاه نوژه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (65995, 17, N'ازندريان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (66391, 18, N'موچش ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (66631, 18, N'دلبران ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (66661, 18, N'بلبان آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (66671, 18, N'دهگلان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (66691, 18, N'سريش آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (66781, 18, N'سروآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (66791, 18, N'اورامانتخت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (67341, 19, N'هلشي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (67371, 19, N'بيستون ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (67431, 19, N'فش ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (67441, 19, N'فرامان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (67461, 19, N'صحنه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (67651, 19, N'ريجاب ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (67741, 19, N'سراب ذهاب ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (67771, 19, N'تازه آباد ـ ثلاث باباجاني ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (67871, 19, N'گيلانغرب ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (67931, 19, N'باينگان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (67951, 19, N'نودشه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (67961, 19, N'روانسر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (67981, 19, N'جوانرود ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (68181, 20, N'چغلوندی ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (68331, 20, N'برخوردار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (68391, 20, N'تقي آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (68451, 20, N'چقابل ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (68471, 20, N'كوناني ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (68541, 20, N'واشيان نصيرتپه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (68571, 20, N'معمولان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (68671, 20, N'شول آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (68761, 20, N'زاغه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (68861, 20, N'سپيددشت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (69361, 27, N'چوار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (69511, 27, N'شباب  ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (69531, 27, N'توحيد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (69551, 27, N'لومار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (69561, 27, N'آسمان آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (69641, 27, N'ارمو ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (69661, 27, N'چشمه شيرين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (69671, 27, N'بدره ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (69841, 27, N'موسيان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (69861, 27, N'ميمه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (69931, 27, N'شهرك اسلاميه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (69971, 27, N'اركواز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (71451, 5, N'خيرآبادتوللي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (71461, 5, N'داريان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (71641, 5, N'طسوج ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (71651, 5, N'اكبرآبادكوار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (71661, 5, N'مظفري ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (71991, 5, N'شهر جديد صدرا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (73141, 5, N'كلاني ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (73171, 5, N'وراوي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (73331, 5, N'كنارتخته ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (73341, 5, N'خشت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (73391, 5, N'بالاده ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (73431, 5, N'كام فيروز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (73441, 5, N'خرامه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (73451, 5, N'سروستان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (73461, 5, N'كوار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (73491, 5, N'گويم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (73571, 5, N'مصيري ـ رستم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (73631, 5, N' بيضا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (73681, 5, N'بانش ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (73741, 5, N'سعادت شهر ـ پاسارگاد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (73751, 5, N'قادرآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (73761, 5, N'ارسنجان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (73771, 5, N'سيدان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (73841, 5, N'حسن آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (73911, 5, N'بهمن ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (73931, 5, N'صغاد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (73941, 5, N'بوانات ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (73951, 5, N'صفاشهر ـ خرم بيد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (73971, 5, N'سوريان) ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (73991, 5, N'ايزدخواست ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74311, 5, N'فيشور ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74331, 5, N'اوز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74341, 5, N'لامرد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74351, 5, N'جويم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74361, 5, N'بنارويه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74381, 5, N'بيرم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74391, 5, N'اشكنان ـ اهل ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74431, 5, N'خنج ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74441, 5, N'علاءمرودشت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74451, 5, N'مهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74461, 5, N'رونيز  ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74551, 5, N'قطب آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74651, 5, N'ششده ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74671, 5, N'زاهدشهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74731, 5, N'مبارك آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74741, 5, N'ميمند ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74761, 5, N'قير و كارزين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74771, 5, N'فراشبند ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74781, 5, N'دهرم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74861, 5, N'حاجي آباد ـ زرين دشت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74871, 5, N'فدامي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74891, 5, N'دهخير) ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74931, 5, N'آباده طشك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74971, 5, N'مشكان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74981, 5, N'قطرويه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (74998, 5, N'خرمی ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75111, 21, N'نخل تقي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75196, 21, N'عالی شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75331, 21, N'بندرريگ ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75351, 21, N'شول ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75361, 21, N'بندرديلم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75381, 21, N'چغارك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75391, 21, N'عسلويه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75431, 21, N'بادوله ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75441, 21, N'شنبه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75451, 21, N'كاكي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75461, 21, N'جزيره خارك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75471, 21, N'دلوار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75491, 21, N'آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75531, 21, N'بردخون ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75541, 21, N'بندردير ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75551, 21, N'ابدان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75561, 21, N'ريز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75571, 21, N'بندركنگان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75581, 21, N'جم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75641, 21, N'شبانكاره ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75651, 21, N'آبپخش ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75661, 21, N'سعدآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75671, 21, N'وحدتيه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75681, 21, N'تنگ ارم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75691, 21, N'كلمه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75731, 28, N'سوق ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75741, 28, N'لنده ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75751, 28, N'ليكك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75761, 28, N'چرام ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75771, 28, N'ديشموك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75781, 28, N'قلعه رئيسي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75881, 28, N'باشت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75911, 28, N'مادوان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75931, 28, N'سپيدار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75981, 28, N'پاتاوه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (75991, 28, N'سي سخت ـ دنا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (76371, 22, N'باغين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (76381, 22, N'اختيارآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (76391, 22, N'زنگي آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (76431, 22, N'جوشان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (76741, 22, N'فهرج ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (76761, 22, N'ريگان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (76891, 22, N'محي آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (77391, 22, N'صفائيه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (77431, 22, N'امين شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (77461, 22, N'بهرمان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (77471, 22, N'جواديه فلاح ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (77751, 22, N'سريز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (77761, 22, N'خانوك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (77941, 22, N' مغزآباد) ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (77951, 22, N'كاظم آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (78151, 22, N'نجف شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (78431, 22, N'نگار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (78561, 22, N'رابر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (78591, 22, N'ارزوئیه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (78771, 22, N'دوساري ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (78791, 22, N'بلوك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (78831, 22, N'رودبار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (78841, 22, N'قلعه گنج ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (78871, 22, N'فارياب ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79331, 23, N'ايسين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79341, 23, N'پل شرقي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79351, 23, N'فين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79371, 23, N'فارغان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79391, 23, N'حاجي آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79461, 23, N'سيريك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79531, 23, N'درگهان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79561, 23, N'جزيرهلارك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79571, 23, N'جزيره هنگام ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79581, 23, N'جزيره سيري ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79591, 23, N'ابوموسي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79611, 23, N'جناح ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79631, 23, N'پدل ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79641, 23, N'كنگ ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79661, 23, N'رويدر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79751, 23, N'چارك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79761, 23, N'دشتي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79771, 23, N'پارسيان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79781, 23, N'جزيره لاوان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79791, 23, N'جاسك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79841, 23, N'سندرك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79881, 23, N'سردشت ـ بشاگرد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79941, 23, N'زيارت علي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79971, 23, N'تياب ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (79981, 23, N'بندزك كهنه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (81351, 6, N'تودشك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (81431, 6, N'بهارستان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (81561, 6, N'خوراسگان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (81681, 6, N'زيار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (81751, 6, N'نصر آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (81789, 6, N'ابريشم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (81879, 6, N'رهنان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (83331, 6, N'شهرك صنعتي مورچ ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (83431, 6, N'دستگردوبرخوار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (83441, 6, N'گز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (83451, 6, N'خورزوق ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (83591, 6, N'كمشچه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (83631, 6, N'جندق ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (83641, 6, N'فرخي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (83741, 6, N'هرند ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (83751, 6, N'ورزنه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (83771, 6, N'نيك آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (83781, 6, N'اژيه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (83791, 6, N'حسن اباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (84351, 6, N'اصغرآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (84381, 6, N'جعفرآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (84431, 6, N'مهاباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (84531, 6, N'خوانسارك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (84541, 6, N'پيربكران ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (84561, 6, N'كليشادوسودرجان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (84651, 6, N'ايمان شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (84691, 6, N'جوجيل ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (84731, 6, N'ورنامخواست ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (84741, 6, N'سده لنجان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (84751, 6, N'چرمهين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (84761, 6, N'باغ بهادران ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (84781, 6, N'چمگردان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (84831, 6, N'ديزيچه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (84841, 6, N'زيبا شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (84881, 6, N'فولادمباركه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (84931, 6, N'زاينده رود ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (84981, 6, N'طالخونچه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (85331, 6, N'رضوان شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (85351, 6, N'عسگران ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (85451, 6, N'اشن ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (85631, 6, N'غرغن ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (85651, 6, N'بوئين ومياندشت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (85761, 6, N'رزوه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (85831, 6, N'گلدشت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (86481, 6, N'اسلام آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (86531, 6, N'امين آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (87481, 6, N'ابوزيدآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (87641, 6, N'اريسمان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (87661, 6, N'بادرود ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (87671, 6, N'خالدآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (87841, 6, N'گلشهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (87992, 6, N'سپاهان شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (88139, 24, N'كیان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (88361, 24, N'دستنائ ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (88371, 24, N'شلمزار ـ كيار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (88381, 24, N'گهرو ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (88431, 24, N'سورشجان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (88461, 24, N'سودجان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (88471, 24, N'چالشتر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (88571, 24, N'وردنجان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (88581, 24, N'بن ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (88631, 24, N'باباحيدر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (88651, 24, N'چلگرد ـ كوهرنگ ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (88671, 24, N'جونقان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (88741, 24, N'فرادنبه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (88761, 24, N'بلداجي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (88781, 24, N'گندمان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (88831, 24, N'ناغان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (88881, 24, N'دشتك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (88941, 24, N'آلوني ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (88951, 24, N'مال خليفه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (89331, 25, N'فراغه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (89418, 25, N'زارچ ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (89431, 25, N'شاهديه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (89491, 25, N'حميديا ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (89531, 25, N'احمدآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (89631, 25, N'بفروئيه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (89761, 25, N'بهاباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (89871, 25, N'مروست ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (89881, 25, N'هرات ـ خاتم ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (89961, 25, N'نير ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (91671, 7, N'رضويه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (93461, 7, N'قدمگاه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (93561, 7, N'شانديز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (93571, 7, N'طوس سفلي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (93631, 7, N'رادكان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (93651, 7, N'گلبهار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (93871, 7, N'بزنگان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (94311, 29, N'درق ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (94331, 29, N'ايور ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (94471, 29, N'شوقان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (94561, 29, N'راز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (94861, 7, N'باجگيران ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (94941, 7, N'لطف آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (95471, 7, N'جنگل ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (95481, 7, N'باسفر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (95491, 7, N'دولت آباد ـ زاوه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (95631, 7, N'نشتيفان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (95641, 7, N'سنگان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (95661, 7, N'قاسم آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (95671, 7, N'چمن آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (95751, 7, N'نيل شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (95781, 7, N'ابدال آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (95961, 7, N'مشهدريزه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (95971, 7, N'باخرز ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (96441, 7, N'ازادوار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (96471, 7, N'نقاب ـ جوين ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (96561, 7, N'سلطان آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (96741, 7, N'كوهسرخ) ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (96771, 7, N'خليل آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (96791, 7, N'بند قرائ ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (96941, 7, N'بيدخت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (96961, 7, N'كاخك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (96981, 7, N'بجستان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (97311, 30, N'مود ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (97351, 30, N'خوسف ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (97441, 30, N'اسديه ـ درميان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (97443, 30, N'نیمبلوك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (97461, 30, N'گزيک ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (97631, 30, N'آرين شهر ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (97661, 30, N'خضري دشت بياض ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (97671, 30, N'حاجي آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (97691, 30, N'زهان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (97741, 7, N'برون ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (97761, 7, N'مصعبي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (97771, 30, N'سرايان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (97791, 30, N'آيسك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (97831, 30, N'ارسك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (97891, 30, N'سه قلعه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (97981, 25, N'عشق آباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (98641, 26, N'تيموراباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (98681, 26, N'محمدآباد ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (98691, 26, N'بنجار ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (98931, 26, N'گوهركوه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (98971, 26, N'سنگان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (99361, 26, N'راسك ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (99431, 26, N'اسپكه ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (99451, 26, N'بنت ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (99461, 26, N'فنوج ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (99471, 26, N'گلمورتي ـ دلگان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (99491, 26, N'بزمان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (99561, 26, N'جالق ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (99571, 26, N'سيركان ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (99641, 26, N'پسكو ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (99661, 26, N'زابلي ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (99671, 26, N'هيدوچ ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (99761, 26, N'نگور ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (99881, 26, N'كيتج ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (99961, 26, N'قصرقند ')
GO
INSERT [dbo].[Cities] ([Id], [StateId], [Name]) VALUES (99991, 26, N'ساربوك ')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (1, N'تهران')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (2, N'گیلان')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (3, N'آذربایجان شرقی')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (4, N'خوزستان')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (5, N'فارس')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (6, N'اصفهان')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (7, N'خراسان رضوی')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (8, N'قزوین')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (9, N'سمنان')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (10, N'قم')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (11, N'مرکزی')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (12, N'زنجان')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (13, N'مازندران')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (14, N'گلستان')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (15, N'اردبیل')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (16, N'آذربایجان غربی')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (17, N'همدان')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (18, N'کردستان')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (19, N'کرمانشاه')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (20, N'لرستان')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (21, N'بوشهر')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (22, N'کرمان')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (23, N'هرمزگان')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (24, N'چهارمحال و بختیاری')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (25, N'یزد')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (26, N'سیستان و بلوچستان')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (27, N'ایلام')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (28, N'کهگلویه و بویراحمد')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (29, N'خراسان شمالی')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (30, N'خراسان جنوبی')
GO
INSERT [dbo].[States] ([Id], [Name]) VALUES (31, N'البرز')
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [FK_Cities_States] FOREIGN KEY([StateId])
REFERENCES [dbo].[States] ([Id])
GO
ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [FK_Cities_States]
GO
