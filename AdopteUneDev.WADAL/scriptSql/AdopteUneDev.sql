/****** Object:  ForeignKey [FK_ClientEndorseDev_Client]    Script Date: 11/27/2014 16:38:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClientEndorseDev_Client]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClientEndorseDev]'))
ALTER TABLE [dbo].[ClientEndorseDev] DROP CONSTRAINT [FK_ClientEndorseDev_Client]
GO
/****** Object:  ForeignKey [FK_ClientEndorseDev_Developer]    Script Date: 11/27/2014 16:38:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClientEndorseDev_Developer]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClientEndorseDev]'))
ALTER TABLE [dbo].[ClientEndorseDev] DROP CONSTRAINT [FK_ClientEndorseDev_Developer]
GO
/****** Object:  ForeignKey [FK_DevLang_Developer]    Script Date: 11/27/2014 16:38:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DevLang_Developer]') AND parent_object_id = OBJECT_ID(N'[dbo].[DevLang]'))
ALTER TABLE [dbo].[DevLang] DROP CONSTRAINT [FK_DevLang_Developer]
GO
/****** Object:  ForeignKey [FK_DevLang_ITLang]    Script Date: 11/27/2014 16:38:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DevLang_ITLang]') AND parent_object_id = OBJECT_ID(N'[dbo].[DevLang]'))
ALTER TABLE [dbo].[DevLang] DROP CONSTRAINT [FK_DevLang_ITLang]
GO
/****** Object:  ForeignKey [FK_LangCateg_Categories]    Script Date: 11/27/2014 16:38:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LangCateg_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[LangCateg]'))
ALTER TABLE [dbo].[LangCateg] DROP CONSTRAINT [FK_LangCateg_Categories]
GO
/****** Object:  ForeignKey [FK_LangCateg_ITLang]    Script Date: 11/27/2014 16:38:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LangCateg_ITLang]') AND parent_object_id = OBJECT_ID(N'[dbo].[LangCateg]'))
ALTER TABLE [dbo].[LangCateg] DROP CONSTRAINT [FK_LangCateg_ITLang]
GO
/****** Object:  Table [dbo].[ClientEndorseDev]    Script Date: 11/27/2014 16:38:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClientEndorseDev]') AND type in (N'U'))
DROP TABLE [dbo].[ClientEndorseDev]
GO
/****** Object:  Table [dbo].[DevLang]    Script Date: 11/27/2014 16:38:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DevLang]') AND type in (N'U'))
DROP TABLE [dbo].[DevLang]
GO
/****** Object:  Table [dbo].[LangCateg]    Script Date: 11/27/2014 16:38:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LangCateg]') AND type in (N'U'))
DROP TABLE [dbo].[LangCateg]
GO
/****** Object:  Table [dbo].[ITLang]    Script Date: 11/27/2014 16:38:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ITLang]') AND type in (N'U'))
DROP TABLE [dbo].[ITLang]
GO
/****** Object:  Table [dbo].[Developer]    Script Date: 11/27/2014 16:38:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Developer]') AND type in (N'U'))
DROP TABLE [dbo].[Developer]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 11/27/2014 16:38:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories]') AND type in (N'U'))
DROP TABLE [dbo].[Categories]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 11/27/2014 16:38:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Client]') AND type in (N'U'))
DROP TABLE [dbo].[Client]
GO
/****** Object:  Default [DF_ClientEndorseDev_EndorseNumber]    Script Date: 11/27/2014 16:38:44 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ClientEndorseDev_EndorseNumber]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClientEndorseDev]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ClientEndorseDev_EndorseNumber]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ClientEndorseDev] DROP CONSTRAINT [DF_ClientEndorseDev_EndorseNumber]
END


End
GO
/****** Object:  Table [dbo].[Client]    Script Date: 11/27/2014 16:38:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Client]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Client](
	[idClient] [int] IDENTITY(1,1) NOT NULL,
	[CliName] [nvarchar](50) COLLATE French_CI_AS NOT NULL,
	[CliFirstName] [nvarchar](50) COLLATE French_CI_AS NOT NULL,
	[CliMail] [nvarchar](250) COLLATE French_CI_AS NOT NULL,
	[CliCompany] [nvarchar](50) COLLATE French_CI_AS NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[idClient] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[Client] ON
INSERT [dbo].[Client] ([idClient], [CliName], [CliFirstName], [CliMail], [CliCompany]) VALUES (1, N'Berkam', N'Dav', N'dav@zeboite.com', N'ZeBoite')
SET IDENTITY_INSERT [dbo].[Client] OFF
/****** Object:  Table [dbo].[Categories]    Script Date: 11/27/2014 16:38:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Categories](
	[idCategory] [int] NOT NULL,
	[CategLabel] [nvarchar](50) COLLATE French_CI_AS NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[idCategory] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[Categories] ([idCategory], [CategLabel]) VALUES (1, N'WEB')
INSERT [dbo].[Categories] ([idCategory], [CategLabel]) VALUES (2, N'ANALYSE')
INSERT [dbo].[Categories] ([idCategory], [CategLabel]) VALUES (3, N'WEBAPP')
INSERT [dbo].[Categories] ([idCategory], [CategLabel]) VALUES (4, N'GEEK')
INSERT [dbo].[Categories] ([idCategory], [CategLabel]) VALUES (5, N'WPF')
/****** Object:  Table [dbo].[Developer]    Script Date: 11/27/2014 16:38:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Developer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Developer](
	[idDev] [int] IDENTITY(1,1) NOT NULL,
	[DevName] [nvarchar](50) COLLATE French_CI_AS NOT NULL,
	[DevFirstName] [nvarchar](50) COLLATE French_CI_AS NOT NULL,
	[DevBirthDate] [datetime] NOT NULL,
	[DevPicture] [nvarchar](50) COLLATE French_CI_AS NULL,
	[DevHourCost] [float] NOT NULL,
	[DevDayCost] [float] NOT NULL,
	[DevMonthCost] [float] NOT NULL,
	[DevMail] [nvarchar](250) COLLATE French_CI_AS NOT NULL,
 CONSTRAINT [PK_Developer] PRIMARY KEY CLUSTERED 
(
	[idDev] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[Developer] ON
INSERT [dbo].[Developer] ([idDev], [DevName], [DevFirstName], [DevBirthDate], [DevPicture], [DevHourCost], [DevDayCost], [DevMonthCost], [DevMail]) VALUES (1, N'Person', N'Mike', CAST(0x0000754900000000 AS DateTime), NULL, 65, 560, 2000, N'michael.person@cognitic.be')
SET IDENTITY_INSERT [dbo].[Developer] OFF
/****** Object:  Table [dbo].[ITLang]    Script Date: 11/27/2014 16:38:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ITLang]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ITLang](
	[idIT] [int] NOT NULL,
	[ITLabel] [nvarchar](50) COLLATE French_CI_AS NOT NULL,
 CONSTRAINT [PK_ITLang] PRIMARY KEY CLUSTERED 
(
	[idIT] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[ITLang] ([idIT], [ITLabel]) VALUES (1, N'C#')
INSERT [dbo].[ITLang] ([idIT], [ITLabel]) VALUES (2, N'ASP MVC')
INSERT [dbo].[ITLang] ([idIT], [ITLabel]) VALUES (3, N'JAVA')
INSERT [dbo].[ITLang] ([idIT], [ITLabel]) VALUES (4, N'UML')
/****** Object:  Table [dbo].[LangCateg]    Script Date: 11/27/2014 16:38:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LangCateg]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LangCateg](
	[idIT] [int] NOT NULL,
	[idCategory] [int] NOT NULL,
 CONSTRAINT [PK_LangCateg] PRIMARY KEY CLUSTERED 
(
	[idIT] ASC,
	[idCategory] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[LangCateg] ([idIT], [idCategory]) VALUES (1, 1)
INSERT [dbo].[LangCateg] ([idIT], [idCategory]) VALUES (1, 5)
INSERT [dbo].[LangCateg] ([idIT], [idCategory]) VALUES (2, 1)
INSERT [dbo].[LangCateg] ([idIT], [idCategory]) VALUES (2, 3)
INSERT [dbo].[LangCateg] ([idIT], [idCategory]) VALUES (3, 1)
INSERT [dbo].[LangCateg] ([idIT], [idCategory]) VALUES (3, 4)
INSERT [dbo].[LangCateg] ([idIT], [idCategory]) VALUES (3, 5)
INSERT [dbo].[LangCateg] ([idIT], [idCategory]) VALUES (4, 2)
/****** Object:  Table [dbo].[DevLang]    Script Date: 11/27/2014 16:38:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DevLang]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DevLang](
	[idDev] [int] NOT NULL,
	[idIT] [int] NOT NULL,
	[Since] [datetime] NULL,
 CONSTRAINT [PK_DevLang] PRIMARY KEY CLUSTERED 
(
	[idDev] ASC,
	[idIT] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[ClientEndorseDev]    Script Date: 11/27/2014 16:38:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClientEndorseDev]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ClientEndorseDev](
	[idClient] [int] NOT NULL,
	[idDev] [int] NOT NULL,
	[BeginDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[EndorseNumber] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ClientEndorseDev] PRIMARY KEY CLUSTERED 
(
	[EndorseNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[ClientEndorseDev] ([idClient], [idDev], [BeginDate], [EndDate], [EndorseNumber]) VALUES (1, 1, CAST(0x0000A45900000000 AS DateTime), CAST(0x0000A56D00000000 AS DateTime), N'70723641-6973-4a34-8c29-4407fa3929ba')
/****** Object:  Default [DF_ClientEndorseDev_EndorseNumber]    Script Date: 11/27/2014 16:38:44 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ClientEndorseDev_EndorseNumber]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClientEndorseDev]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ClientEndorseDev_EndorseNumber]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ClientEndorseDev] ADD  CONSTRAINT [DF_ClientEndorseDev_EndorseNumber]  DEFAULT (newid()) FOR [EndorseNumber]
END


End
GO
/****** Object:  ForeignKey [FK_ClientEndorseDev_Client]    Script Date: 11/27/2014 16:38:44 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClientEndorseDev_Client]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClientEndorseDev]'))
ALTER TABLE [dbo].[ClientEndorseDev]  WITH CHECK ADD  CONSTRAINT [FK_ClientEndorseDev_Client] FOREIGN KEY([idClient])
REFERENCES [dbo].[Client] ([idClient])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClientEndorseDev_Client]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClientEndorseDev]'))
ALTER TABLE [dbo].[ClientEndorseDev] CHECK CONSTRAINT [FK_ClientEndorseDev_Client]
GO
/****** Object:  ForeignKey [FK_ClientEndorseDev_Developer]    Script Date: 11/27/2014 16:38:44 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClientEndorseDev_Developer]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClientEndorseDev]'))
ALTER TABLE [dbo].[ClientEndorseDev]  WITH CHECK ADD  CONSTRAINT [FK_ClientEndorseDev_Developer] FOREIGN KEY([idDev])
REFERENCES [dbo].[Developer] ([idDev])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClientEndorseDev_Developer]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClientEndorseDev]'))
ALTER TABLE [dbo].[ClientEndorseDev] CHECK CONSTRAINT [FK_ClientEndorseDev_Developer]
GO
/****** Object:  ForeignKey [FK_DevLang_Developer]    Script Date: 11/27/2014 16:38:44 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DevLang_Developer]') AND parent_object_id = OBJECT_ID(N'[dbo].[DevLang]'))
ALTER TABLE [dbo].[DevLang]  WITH CHECK ADD  CONSTRAINT [FK_DevLang_Developer] FOREIGN KEY([idDev])
REFERENCES [dbo].[Developer] ([idDev])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DevLang_Developer]') AND parent_object_id = OBJECT_ID(N'[dbo].[DevLang]'))
ALTER TABLE [dbo].[DevLang] CHECK CONSTRAINT [FK_DevLang_Developer]
GO
/****** Object:  ForeignKey [FK_DevLang_ITLang]    Script Date: 11/27/2014 16:38:44 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DevLang_ITLang]') AND parent_object_id = OBJECT_ID(N'[dbo].[DevLang]'))
ALTER TABLE [dbo].[DevLang]  WITH CHECK ADD  CONSTRAINT [FK_DevLang_ITLang] FOREIGN KEY([idIT])
REFERENCES [dbo].[ITLang] ([idIT])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DevLang_ITLang]') AND parent_object_id = OBJECT_ID(N'[dbo].[DevLang]'))
ALTER TABLE [dbo].[DevLang] CHECK CONSTRAINT [FK_DevLang_ITLang]
GO
/****** Object:  ForeignKey [FK_LangCateg_Categories]    Script Date: 11/27/2014 16:38:44 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LangCateg_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[LangCateg]'))
ALTER TABLE [dbo].[LangCateg]  WITH CHECK ADD  CONSTRAINT [FK_LangCateg_Categories] FOREIGN KEY([idCategory])
REFERENCES [dbo].[Categories] ([idCategory])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LangCateg_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[LangCateg]'))
ALTER TABLE [dbo].[LangCateg] CHECK CONSTRAINT [FK_LangCateg_Categories]
GO
/****** Object:  ForeignKey [FK_LangCateg_ITLang]    Script Date: 11/27/2014 16:38:44 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LangCateg_ITLang]') AND parent_object_id = OBJECT_ID(N'[dbo].[LangCateg]'))
ALTER TABLE [dbo].[LangCateg]  WITH CHECK ADD  CONSTRAINT [FK_LangCateg_ITLang] FOREIGN KEY([idIT])
REFERENCES [dbo].[ITLang] ([idIT])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LangCateg_ITLang]') AND parent_object_id = OBJECT_ID(N'[dbo].[LangCateg]'))
ALTER TABLE [dbo].[LangCateg] CHECK CONSTRAINT [FK_LangCateg_ITLang]
GO
