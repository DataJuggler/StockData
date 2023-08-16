/****** Object:  Table [dbo].[StockStreak]    Script Date: 8/15/2023 9:27:05 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StockStreak]') AND type in (N'U'))
DROP TABLE [dbo].[StockStreak]
GO

/****** Object:  Table [dbo].[DailyPriceData]    Script Date: 8/15/2023 9:27:05 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DailyPriceData]') AND type in (N'U'))
DROP TABLE [dbo].[DailyPriceData]
GO

/****** Object:  Table [dbo].[DailyPriceData]    Script Date: 8/15/2023 9:27:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DailyPriceData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Symbol] [nvarchar](10) NOT NULL,
	[StockDate] [date] NOT NULL,
	[Volume] [int] NOT NULL,
	[OpenPrice] [money] NOT NULL,
	[LowPrice] [money] NOT NULL,
	[HighPrice] [money] NOT NULL,
	[ClosePrice] [money] NOT NULL,
	[Streak] [int] NOT NULL,
	[Spread] [money] NOT NULL,
	[SpreadScore] [money] NOT NULL,
	[CloseScore] [decimal](6, 2) NOT NULL,
 CONSTRAINT [PK_DailyPriceData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[StockStreak]    Script Date: 8/15/2023 9:27:05 PM ******/
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
	[StreakContinuing] [bit] NOT NULL,
	[StreakDays] [int] NOT NULL,
	[CurrentStreak] [bit] NOT NULL,
	[StreakType] [int] NOT NULL,
 CONSTRAINT [PK_StockStreak] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


