USE [PROG260FA23]
GO
ALTER TABLE [dbo].[Type] DROP CONSTRAINT [FK_Type_Type]
GO
ALTER TABLE [dbo].[Location] DROP CONSTRAINT [FK_Location_Location]
GO
ALTER TABLE [dbo].[Character] DROP CONSTRAINT [FK_Character_Type]
GO
ALTER TABLE [dbo].[Character] DROP CONSTRAINT [FK_Character_Location]
GO
/****** Object:  Table [dbo].[Type]    Script Date: 10/19/2023 6:16:54 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Type]') AND type in (N'U'))
DROP TABLE [dbo].[Type]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 10/19/2023 6:16:54 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Location]') AND type in (N'U'))
DROP TABLE [dbo].[Location]
GO
/****** Object:  Table [dbo].[Character]    Script Date: 10/19/2023 6:16:54 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Character]') AND type in (N'U'))
DROP TABLE [dbo].[Character]
GO
/****** Object:  Table [dbo].[Character]    Script Date: 10/19/2023 6:16:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Character](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[Type_ID] [int] NULL,
	[Original_Character] [bit] NOT NULL,
	[Sword_Fighter] [bit] NULL,
	[Magic_User] [bit] NULL,
	[Map_ID] [int] NULL,
 CONSTRAINT [PK_Character] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 10/19/2023 6:16:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Location_Name] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type]    Script Date: 10/19/2023 6:16:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type_Name] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Character] ON 

INSERT [dbo].[Character] ([ID], [Name], [Type_ID], [Original_Character], [Sword_Fighter], [Magic_User], [Map_ID]) VALUES (5, N'Murray', 1, 1, 0, 0, NULL)
INSERT [dbo].[Character] ([ID], [Name], [Type_ID], [Original_Character], [Sword_Fighter], [Magic_User], [Map_ID]) VALUES (6, N'Locke Smith', 2, 0, 0, 0, 1)
INSERT [dbo].[Character] ([ID], [Name], [Type_ID], [Original_Character], [Sword_Fighter], [Magic_User], [Map_ID]) VALUES (7, N'Herman Toothrot', NULL, 0, 0, NULL, 2)
INSERT [dbo].[Character] ([ID], [Name], [Type_ID], [Original_Character], [Sword_Fighter], [Magic_User], [Map_ID]) VALUES (8, N'Voodoo Lady', NULL, 1, 0, 1, 1)
INSERT [dbo].[Character] ([ID], [Name], [Type_ID], [Original_Character], [Sword_Fighter], [Magic_User], [Map_ID]) VALUES (9, N'Otis', 4, 1, 1, 0, 1)
INSERT [dbo].[Character] ([ID], [Name], [Type_ID], [Original_Character], [Sword_Fighter], [Magic_User], [Map_ID]) VALUES (10, N'Clara', 5, 1, 1, 0, 1)
INSERT [dbo].[Character] ([ID], [Name], [Type_ID], [Original_Character], [Sword_Fighter], [Magic_User], [Map_ID]) VALUES (11, N'Captain Madison', 5, 0, 1, 0, 1)
INSERT [dbo].[Character] ([ID], [Name], [Type_ID], [Original_Character], [Sword_Fighter], [Magic_User], [Map_ID]) VALUES (12, N'Judge Planke', 6, 0, 0, 0, 4)
SET IDENTITY_INSERT [dbo].[Character] OFF
GO
SET IDENTITY_INSERT [dbo].[Location] ON 

INSERT [dbo].[Location] ([ID], [Location_Name]) VALUES (1, N'Melee Island')
INSERT [dbo].[Location] ([ID], [Location_Name]) VALUES (2, N'Terror Island')
INSERT [dbo].[Location] ([ID], [Location_Name]) VALUES (3, N'Brrrmuda')
INSERT [dbo].[Location] ([ID], [Location_Name]) VALUES (4, N'Scurvy Island')
INSERT [dbo].[Location] ([ID], [Location_Name]) VALUES (5, N'LeChuck''s Ship')
SET IDENTITY_INSERT [dbo].[Location] OFF
GO
SET IDENTITY_INSERT [dbo].[Type] ON 

INSERT [dbo].[Type] ([ID], [Type_Name]) VALUES (1, N'Ghost')
INSERT [dbo].[Type] ([ID], [Type_Name]) VALUES (2, N'Human')
INSERT [dbo].[Type] ([ID], [Type_Name]) VALUES (3, N'Inmate')
INSERT [dbo].[Type] ([ID], [Type_Name]) VALUES (4, N'Pirate')
INSERT [dbo].[Type] ([ID], [Type_Name]) VALUES (5, N'NPC')
INSERT [dbo].[Type] ([ID], [Type_Name]) VALUES (6, N'Mighty Pirate')
INSERT [dbo].[Type] ([ID], [Type_Name]) VALUES (7, N'Politician')
INSERT [dbo].[Type] ([ID], [Type_Name]) VALUES (8, N'Ghost Cook')
INSERT [dbo].[Type] ([ID], [Type_Name]) VALUES (9, N'Ghost Pirate')
INSERT [dbo].[Type] ([ID], [Type_Name]) VALUES (10, N'Fire Ghost')
SET IDENTITY_INSERT [dbo].[Type] OFF
GO
ALTER TABLE [dbo].[Character]  WITH CHECK ADD  CONSTRAINT [FK_Character_Location] FOREIGN KEY([Map_ID])
REFERENCES [dbo].[Location] ([ID])
GO
ALTER TABLE [dbo].[Character] CHECK CONSTRAINT [FK_Character_Location]
GO
ALTER TABLE [dbo].[Character]  WITH CHECK ADD  CONSTRAINT [FK_Character_Type] FOREIGN KEY([Type_ID])
REFERENCES [dbo].[Type] ([ID])
GO
ALTER TABLE [dbo].[Character] CHECK CONSTRAINT [FK_Character_Type]
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_Location] FOREIGN KEY([ID])
REFERENCES [dbo].[Location] ([ID])
GO
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_Location]
GO
ALTER TABLE [dbo].[Type]  WITH CHECK ADD  CONSTRAINT [FK_Type_Type] FOREIGN KEY([ID])
REFERENCES [dbo].[Type] ([ID])
GO
ALTER TABLE [dbo].[Type] CHECK CONSTRAINT [FK_Type_Type]
GO
