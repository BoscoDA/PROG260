USE [PROG260FA23]
GO
ALTER TABLE [dbo].[Game_Stats] DROP CONSTRAINT [FK_Game_Stats_Game]
GO
/****** Object:  Table [dbo].[Game_Stats]    Script Date: 10/19/2023 5:10:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Game_Stats]') AND type in (N'U'))
DROP TABLE [dbo].[Game_Stats]
GO
/****** Object:  Table [dbo].[Game]    Script Date: 10/19/2023 5:10:22 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Game]') AND type in (N'U'))
DROP TABLE [dbo].[Game]
GO
/****** Object:  Table [dbo].[Game]    Script Date: 10/19/2023 5:10:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Publisher] [nvarchar](50) NOT NULL,
	[Release_Date] [datetime2](7) NULL,
 CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Game_Stats]    Script Date: 10/19/2023 5:10:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game_Stats](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GameID] [int] NOT NULL,
	[Sold] [int] NULL,
	[Rating] [float] NULL,
 CONSTRAINT [PK_Game_Stats] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Game] ON 

INSERT [dbo].[Game] ([ID], [Name], [Publisher], [Release_Date]) VALUES (1, N'The Secret of Monkey Island', N'Lucasfilm Games', CAST(N'1990-10-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Game] ([ID], [Name], [Publisher], [Release_Date]) VALUES (2, N'Monkey Island 2: LeChuck''s Revenge', N'LucasArts', CAST(N'1991-12-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Game] ([ID], [Name], [Publisher], [Release_Date]) VALUES (3, N'The Curse of Monkey Island', N'LucasArts', CAST(N'1997-11-11T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Game] ([ID], [Name], [Publisher], [Release_Date]) VALUES (4, N'Escape From Monkey Island', N'LucasArts', CAST(N'2000-11-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Game] ([ID], [Name], [Publisher], [Release_Date]) VALUES (5, N'Tales of Monkey Island', N'Telltale Games', CAST(N'2010-06-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Game] ([ID], [Name], [Publisher], [Release_Date]) VALUES (6, N'Return to Monkey Island', N'Devolver Digital', CAST(N'2022-09-19T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Game] ([ID], [Name], [Publisher], [Release_Date]) VALUES (7, N'Pokemon Violet', N'Nintendo', CAST(N'2023-10-19T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Game] OFF
GO
SET IDENTITY_INSERT [dbo].[Game_Stats] ON 

INSERT [dbo].[Game_Stats] ([ID], [GameID], [Sold], [Rating]) VALUES (1, 1, 100000, 94)
INSERT [dbo].[Game_Stats] ([ID], [GameID], [Sold], [Rating]) VALUES (2, 2, 250000, 90.1)
INSERT [dbo].[Game_Stats] ([ID], [GameID], [Sold], [Rating]) VALUES (3, 3, 800000, 89.3)
INSERT [dbo].[Game_Stats] ([ID], [GameID], [Sold], [Rating]) VALUES (4, 4, 300000, 83.5)
INSERT [dbo].[Game_Stats] ([ID], [GameID], [Sold], [Rating]) VALUES (5, 5, 400000, 81)
INSERT [dbo].[Game_Stats] ([ID], [GameID], [Sold], [Rating]) VALUES (6, 6, 250000, 87)
SET IDENTITY_INSERT [dbo].[Game_Stats] OFF
GO
ALTER TABLE [dbo].[Game_Stats]  WITH CHECK ADD  CONSTRAINT [FK_Game_Stats_Game] FOREIGN KEY([GameID])
REFERENCES [dbo].[Game] ([ID])
GO
ALTER TABLE [dbo].[Game_Stats] CHECK CONSTRAINT [FK_Game_Stats_Game]
GO
