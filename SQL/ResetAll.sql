Use StockData

/****** Object:  Table [dbo].[StockStreak]    Script Date: 8/30/2023 1:24:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StockStreak]') AND type in (N'U'))
DROP TABLE [dbo].[StockStreak]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RecommendationLog]') AND type in (N'U'))
DROP TABLE [dbo].[RecommendationLog]
GO

/****** Object:  Table [dbo].[StockDay]    Script Date: 8/30/2023 1:24:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StockDay]') AND type in (N'U'))
DROP TABLE [dbo].[StockDay]
GO

/****** Object:  Table [dbo].[SectorHistory]    Script Date: 8/30/2023 1:24:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SectorHistory]') AND type in (N'U'))
DROP TABLE [dbo].[SectorHistory]
GO

/****** Object:  Table [dbo].[IndustryHistory]    Script Date: 8/30/2023 1:24:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IndustryHistory]') AND type in (N'U'))
DROP TABLE [dbo].[IndustryHistory]
GO

/****** Object:  Table [dbo].[DailyPriceData]    Script Date: 8/30/2023 1:24:44 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DailyPriceData]') AND type in (N'U'))
DROP TABLE [dbo].[DailyPriceData]
GO

/****** Object:  Table [dbo].[DailyPriceData]    Script Date: 8/30/2023 1:24:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DailyPriceData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Symbol] [nvarchar](10) NOT NULL,
	[StockDate] [date] NOT NULL,
	[Volume] [int] NOT NULL,
	[VolumeScore] [decimal](6, 2) NOT NULL,
	[OpenPrice] [money] NOT NULL,
	[LowPrice] [money] NOT NULL,
	[HighPrice] [money] NOT NULL,
	[ClosePrice] [money] NOT NULL,
	[PercentChange] [decimal](6, 2) NOT NULL,
	[Streak] [int] NOT NULL,
	[PriceUnchanged] [bit] NOT NULL,
	[Spread] [money] NOT NULL,
	[SpreadScore] [money] NOT NULL,
	[CloseScore] [decimal](6, 2) NOT NULL,
	[MostRecent] [bit] NOT NULL,
 CONSTRAINT [PK_DailyPriceData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[IndustryHistory]    Script Date: 8/30/2023 1:24:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[IndustryHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IndustryId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Advancers] [int] NOT NULL,
	[Decliners] [int] NOT NULL,
	[Score] [decimal](6, 2) NOT NULL,
	[AveragePercentChange] [decimal](6, 2) NOT NULL,
	[Streak] [int] NOT NULL,
 CONSTRAINT [PK_IndustryHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SectorHistory]    Script Date: 8/30/2023 1:24:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SectorHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SectorId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Advancers] [int] NOT NULL,
	[Decliners] [int] NOT NULL,
	[Score] [decimal](6, 2) NOT NULL,
	[AveragePercentChange] [decimal](6, 2) NOT NULL,
	[Streak] [int] NOT NULL,
 CONSTRAINT [PK_SectorHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[StockDay]    Script Date: 8/30/2023 1:24:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StockDay](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[IndustryProcessed] [bit] NOT NULL,
	[SectorProcessed] [bit] NOT NULL,
 CONSTRAINT [PK_StockDay] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[StockStreak]    Script Date: 8/30/2023 1:24:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StockStreak](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StockId] [int] NOT NULL,
	[StreakStartDate] [datetime] NOT NULL,
	[StreakEndDate] [datetime] NOT NULL,
	[StreakStartPrice] [money] NOT NULL,
	[StreakEndPrice] [money] NOT NULL,
	[PercentChange] [decimal](6, 2) NOT NULL,
	[StreakDays] [int] NOT NULL,
	[CurrentStreak] [bit] NOT NULL,
	[StreakType] [int] NOT NULL,
	[ReverseSplit] [bit] NOT NULL,
	[ReverseSplitDivisor] [int] NOT NULL,
 CONSTRAINT [PK_StockStreak] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[RecommendationLog]    Script Date: 9/22/2023 1:46:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RecommendationLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Score] [decimal](8, 3) NOT NULL,
	[StockName] [nvarchar](50) NOT NULL,
	[Symbol] [nvarchar](10) NOT NULL,
	[StockDate] [datetime] NOT NULL,
	[LastClose] [money] NOT NULL,
	[CloseScore] [decimal](6, 2) NOT NULL,
	[VolumeScore] [decimal](6, 2) NOT NULL,
	[Streak] [int] NOT NULL,
	[LastPercentChange] [decimal](6, 2) NOT NULL,
	[StreakPercentChange] [decimal](6, 2) NOT NULL,
	[Industry] [nvarchar](80) NOT NULL,
	[IndustryScore] [decimal](6, 2) NOT NULL,
	[IndustryStreak] [int] NOT NULL,
	[Sector] [nvarchar](80) NOT NULL,
	[SectorScore] [decimal](6, 2) NOT NULL,
	[SectorStreak] [int] NOT NULL,
 CONSTRAINT [PK_RecommendationLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


