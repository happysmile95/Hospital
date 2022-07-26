USE [Hospital]
GO
SET IDENTITY_INSERT [dbo].[Parlors] ON 

INSERT [dbo].[Parlors] ([Id], [Number]) VALUES (1, 10)
INSERT [dbo].[Parlors] ([Id], [Number]) VALUES (2, 11)
INSERT [dbo].[Parlors] ([Id], [Number]) VALUES (3, 12)
INSERT [dbo].[Parlors] ([Id], [Number]) VALUES (4, 13)
INSERT [dbo].[Parlors] ([Id], [Number]) VALUES (5, 14)
SET IDENTITY_INSERT [dbo].[Parlors] OFF
GO
SET IDENTITY_INSERT [dbo].[Sites] ON 

INSERT [dbo].[Sites] ([Id], [Number]) VALUES (1, 5)
INSERT [dbo].[Sites] ([Id], [Number]) VALUES (2, 8)
INSERT [dbo].[Sites] ([Id], [Number]) VALUES (3, 14)
INSERT [dbo].[Sites] ([Id], [Number]) VALUES (4, 4)
SET IDENTITY_INSERT [dbo].[Sites] OFF
GO
SET IDENTITY_INSERT [dbo].[Specializations] ON 

INSERT [dbo].[Specializations] ([Id], [Name]) VALUES (1, N'Окушер')
INSERT [dbo].[Specializations] ([Id], [Name]) VALUES (2, N'Лор')
INSERT [dbo].[Specializations] ([Id], [Name]) VALUES (3, N'Терапевт')
INSERT [dbo].[Specializations] ([Id], [Name]) VALUES (4, N'Хирург')
INSERT [dbo].[Specializations] ([Id], [Name]) VALUES (5, N'Ортопед')
SET IDENTITY_INSERT [dbo].[Specializations] OFF
GO
SET IDENTITY_INSERT [dbo].[Doctors] ON 

INSERT [dbo].[Doctors] ([Id], [Name], [ParlorId], [SpecializationId], [SiteId]) VALUES (2, N'Иванов Иван Иванович', 1, 3, 2)
INSERT [dbo].[Doctors] ([Id], [Name], [ParlorId], [SpecializationId], [SiteId]) VALUES (3, N'Михайлов Иван Петрович', 2, 3, 2)
INSERT [dbo].[Doctors] ([Id], [Name], [ParlorId], [SpecializationId], [SiteId]) VALUES (4, N'Иванов Артем Арсенович', 3, 3, 2)
INSERT [dbo].[Doctors] ([Id], [Name], [ParlorId], [SpecializationId], [SiteId]) VALUES (5, N'Рыбин Петр Александрович', 3, 3, 2)
INSERT [dbo].[Doctors] ([Id], [Name], [ParlorId], [SpecializationId], [SiteId]) VALUES (6, N'Смыла Георгий Алексеевич', 2, 2, 1)
INSERT [dbo].[Doctors] ([Id], [Name], [ParlorId], [SpecializationId], [SiteId]) VALUES (7, N'Трупин Иван Иванович', 1, 2, 4)
INSERT [dbo].[Doctors] ([Id], [Name], [ParlorId], [SpecializationId], [SiteId]) VALUES (8, N'Сидоров  Сидр Сидорович', 2, 2, 3)
INSERT [dbo].[Doctors] ([Id], [Name], [ParlorId], [SpecializationId], [SiteId]) VALUES (9, N'Алексеев Роман Александрович', 4, 3, 1)
SET IDENTITY_INSERT [dbo].[Doctors] OFF
GO
SET IDENTITY_INSERT [dbo].[Patients] ON 

INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [Patronymic], [Address], [BirthDay], [Gender], [SiteId]) VALUES (1, N'Иван', N'Иванов', N'Иванович', N'Москва', CAST(N'1991-02-05T00:00:00.0000000' AS DateTime2), 0, NULL)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [Patronymic], [Address], [BirthDay], [Gender], [SiteId]) VALUES (2, N'Сидр', N'Сидоров', N'Сидорович', N'Краснодар', CAST(N'1954-12-12T00:00:00.0000000' AS DateTime2), 0, 2)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [Patronymic], [Address], [BirthDay], [Gender], [SiteId]) VALUES (3, N'Петренко', N'Ольга', N'Радионовна', N'Воронеж', CAST(N'1995-09-01T00:00:00.0000000' AS DateTime2), 1, 3)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [Patronymic], [Address], [BirthDay], [Gender], [SiteId]) VALUES (4, N'Михайлов', N'Михаил', N'Михайлович', N'Москва', CAST(N'2002-04-23T00:00:00.0000000' AS DateTime2), 0, 2)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [Patronymic], [Address], [BirthDay], [Gender], [SiteId]) VALUES (5, N'Петренко', N'Людмила', N'Радионовна', N'Воронеж', CAST(N'1994-09-01T00:00:00.0000000' AS DateTime2), 1, 1)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [Patronymic], [Address], [BirthDay], [Gender], [SiteId]) VALUES (6, N'Петренко', N'Светлана', N'Радионовна', N'Воронеж', CAST(N'1993-09-01T00:00:00.0000000' AS DateTime2), 1, 1)
SET IDENTITY_INSERT [dbo].[Patients] OFF
GO
