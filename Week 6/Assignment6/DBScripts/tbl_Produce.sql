USE [PROG260FA23]
GO
/****** Object:  Table [dbo].[Produce]    Script Date: 10/12/2023 5:36:50 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Produce]') AND type in (N'U'))
DROP TABLE [dbo].[Produce]
GO
/****** Object:  Table [dbo].[Produce]    Script Date: 10/12/2023 5:36:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produce](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Location] [nvarchar](50) NOT NULL,
	[Price] [money] NOT NULL,
	[UoM] [nvarchar](50) NOT NULL,
	[Sell_by_Date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Produce] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
