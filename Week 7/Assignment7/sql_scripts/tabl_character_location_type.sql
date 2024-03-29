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
/****** Object:  Table [dbo].[Type]    Script Date: 10/22/2023 12:12:32 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Type]') AND type in (N'U'))
DROP TABLE [dbo].[Type]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 10/22/2023 12:12:32 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Location]') AND type in (N'U'))
DROP TABLE [dbo].[Location]
GO
/****** Object:  Table [dbo].[Character]    Script Date: 10/22/2023 12:12:32 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Character]') AND type in (N'U'))
DROP TABLE [dbo].[Character]
GO
/****** Object:  Table [dbo].[Character]    Script Date: 10/22/2023 12:12:32 PM ******/
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
/****** Object:  Table [dbo].[Location]    Script Date: 10/22/2023 12:12:32 PM ******/
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
/****** Object:  Table [dbo].[Type]    Script Date: 10/22/2023 12:12:32 PM ******/
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
