/****** Object:  Table [dbo].[Stock]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Symbol] [nvarchar](10) NOT NULL,
	[Exchange] [nvarchar](10) NOT NULL,
	[Industry] [nvarchar](80) NOT NULL,
	[Sector] [nvarchar](80) NOT NULL,
	[AverageDailyVolume] [int] NOT NULL,
	[Streak] [int] NOT NULL,
	[LastClose] [money] NOT NULL,
	[Track] [bit] NOT NULL,
	[IPOYear] [int] NOT NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_Stock_Symbol] UNIQUE NONCLUSTERED 
(
	[Symbol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DailyPriceData]    Script Date: 8/30/2023 9:08:35 PM ******/
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
/****** Object:  View [dbo].[IndustryView]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [dbo].[IndustryView]
AS
SELECT dbo.DailyPriceData.Id AS DailyPriceDataId, dbo.DailyPriceData.PercentChange, dbo.DailyPriceData.Symbol, dbo.DailyPriceData.StockDate, dbo.DailyPriceData.ClosePrice, dbo.DailyPriceData.Streak, dbo.DailyPriceData.MostRecent, dbo.DailyPriceData.PriceUnchanged ,dbo.Stock.Id AS StockId, dbo.Stock.Name as StockName, dbo.Stock.Industry, dbo.Stock.Track
FROM  dbo.DailyPriceData INNER JOIN
        dbo.Stock ON dbo.DailyPriceData.Symbol = dbo.Stock.Symbol
GO
/****** Object:  View [dbo].[SectorView]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE VIEW [dbo].[SectorView]
AS
SELECT dbo.DailyPriceData.Id AS DailyPriceDataId, dbo.DailyPriceData.PercentChange, dbo.DailyPriceData.Symbol, dbo.DailyPriceData.StockDate, dbo.DailyPriceData.ClosePrice, dbo.DailyPriceData.Streak, dbo.DailyPriceData.MostRecent, dbo.DailyPriceData.PriceUnchanged, dbo.Stock.Id AS StockId, dbo.Stock.Name as StockName, dbo.Stock.Sector, dbo.Stock.Track
FROM  dbo.DailyPriceData INNER JOIN
        dbo.Stock ON dbo.DailyPriceData.Symbol = dbo.Stock.Symbol
GO
/****** Object:  Table [dbo].[StockStreak]    Script Date: 8/30/2023 9:08:35 PM ******/
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
/****** Object:  View [dbo].[StockStreakView]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[StockStreakView]
AS
SELECT s.Id AS StockId, s.Name, s.Symbol, s.Exchange, s.Industry, s.Sector, s.AverageDailyVolume, s.Streak, s.LastClose, ss.StreakStartDate, ss.StreakEndDate, ss.StreakStartPrice, ss.StreakEndPrice, ss.PercentChange, ss.ReverseSplit, ss.ReverseSplitDivisor
FROM  dbo.Stock AS s INNER JOIN
        dbo.StockStreak AS ss ON s.Id = ss.StockId
WHERE (ss.CurrentStreak = 1) AND (s.Track = 1)
GO
/****** Object:  View [dbo].[DailyPriceDataView]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





Create View [dbo].[DailyPriceDataView] As
SELECT d.Id, d.Symbol, s.Name, d.StockDate, d.Volume, d.VolumeScore, d.ClosePrice, d.OpenPrice, d.LowPrice,d.HighPrice, d.Streak, d.Spread, ss.StockId, d.SpreadScore, d.CloseScore
FROM  dbo.DailyPriceData d Inner Join StockStreakView ss on d.Symbol = ss.Symbol
And d.StockDate >= ss.StreakStartDate Inner Join Stock s on ss.StockId = s.Id

GO
/****** Object:  Table [dbo].[Admin]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MinVolume] [int] NOT NULL,
	[DocumentsFolder] [nvarchar](256) NULL,
	[ProcessedFolder] [nvarchar](256) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Industry]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Industry](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[NumberStocks] [int] NOT NULL,
	[Advancers] [int] NOT NULL,
	[Decliners] [int] NOT NULL,
	[Score] [decimal](6, 2) NOT NULL,
	[AveragePercentChange] [decimal](6, 2) NOT NULL,
	[Streak] [int] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_Industry] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IndustryHistory]    Script Date: 8/30/2023 9:08:35 PM ******/
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
/****** Object:  Table [dbo].[Sector]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sector](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[NumberStocks] [int] NOT NULL,
	[Advancers] [int] NOT NULL,
	[Decliners] [int] NOT NULL,
	[Score] [decimal](6, 2) NOT NULL,
	[AveragePercentChange] [decimal](6, 2) NOT NULL,
	[Streak] [int] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_Sector] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SectorHistory]    Script Date: 8/30/2023 9:08:35 PM ******/
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
/****** Object:  Table [dbo].[StockDay]    Script Date: 8/30/2023 9:08:35 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Admin_Delete]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Admin_Delete]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Admin]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Admin_FetchAll]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Admin_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [DocumentsFolder],[Id],[MinVolume],[ProcessedFolder]

    -- From tableName
    From [Admin]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Admin_Find]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Admin_Find]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [DocumentsFolder],[Id],[MinVolume],[ProcessedFolder]

    -- From tableName
    From [Admin]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Admin_Insert]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Admin_Insert]

    -- Add the parameters for the stored procedure here
    @DocumentsFolder nvarchar(256),
    @MinVolume int,
    @ProcessedFolder nvarchar(256)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Admin]
    ([DocumentsFolder],[MinVolume],[ProcessedFolder])

    -- Begin Values List
    Values(@DocumentsFolder, @MinVolume, @ProcessedFolder)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Admin_Update]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Admin_Update]

    -- Add the parameters for the stored procedure here
    @DocumentsFolder nvarchar(256),
    @Id int,
    @MinVolume int,
    @ProcessedFolder nvarchar(256)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Admin]

    -- Update Each field
    Set [DocumentsFolder] = @DocumentsFolder,
    [MinVolume] = @MinVolume,
    [ProcessedFolder] = @ProcessedFolder

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[DailyPriceData_Delete]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[DailyPriceData_Delete]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [DailyPriceData]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[DailyPriceData_FetchAll]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[DailyPriceData_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ClosePrice],[CloseScore],[HighPrice],[Id],[LowPrice],[MostRecent],[OpenPrice],[PercentChange],[PriceUnchanged],[Spread],[SpreadScore],[StockDate],[Streak],[Symbol],[Volume],[VolumeScore]

    -- From tableName
    From [DailyPriceData]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[DailyPriceData_FetchAllForSymbol]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[DailyPriceData_FetchAllForSymbol]

    -- Create @Symbol Paramater
    @Symbol nvarchar(10)


AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select Top 50 [ClosePrice],[CloseScore],[HighPrice],[Id],[LowPrice],[MostRecent],[OpenPrice],[PercentChange],[PriceUnchanged],[Spread],[SpreadScore],[StockDate],[Streak],[Symbol],[Volume],[VolumeScore]

    -- From tableName
    From [DailyPriceData]

    -- Load Matching Records
    Where [Symbol] = @Symbol

    -- Order by Id in descending order
    Order By [Id] desc

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[DailyPriceData_Find]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[DailyPriceData_Find]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ClosePrice],[CloseScore],[HighPrice],[Id],[LowPrice],[MostRecent],[OpenPrice],[PercentChange],[PriceUnchanged],[Spread],[SpreadScore],[StockDate],[Streak],[Symbol],[Volume],[VolumeScore]

    -- From tableName
    From [DailyPriceData]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[DailyPriceData_FindBySymbolAndMostRecent]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[DailyPriceData_FindBySymbolAndMostRecent]

    -- Create @MostRecent Paramater
    @MostRecent bit,


    -- Create @Symbol Paramater
    @Symbol nvarchar(10)


AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ClosePrice],[CloseScore],[HighPrice],[Id],[LowPrice],[MostRecent],[OpenPrice],[PercentChange],[PriceUnchanged],[Spread],[SpreadScore],[StockDate],[Streak],[Symbol],[Volume],[VolumeScore]

    -- From tableName
    From [DailyPriceData]

    -- Find Matching Record
    Where [MostRecent] = @MostRecent And [Symbol] = @Symbol

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[DailyPriceData_Insert]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[DailyPriceData_Insert]

    -- Add the parameters for the stored procedure here
    @ClosePrice float,
    @CloseScore float,
    @HighPrice float,
    @LowPrice float,
    @MostRecent bit,
    @OpenPrice float,
    @PercentChange float,
    @PriceUnchanged bit,
    @Spread float,
    @SpreadScore float,
    @StockDate datetime,
    @Streak int,
    @Symbol nvarchar(10),
    @Volume int,
    @VolumeScore float

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [DailyPriceData]
    ([ClosePrice],[CloseScore],[HighPrice],[LowPrice],[MostRecent],[OpenPrice],[PercentChange],[PriceUnchanged],[Spread],[SpreadScore],[StockDate],[Streak],[Symbol],[Volume],[VolumeScore])

    -- Begin Values List
    Values(@ClosePrice, @CloseScore, @HighPrice, @LowPrice, @MostRecent, @OpenPrice, @PercentChange, @PriceUnchanged, @Spread, @SpreadScore, @StockDate, @Streak, @Symbol, @Volume, @VolumeScore)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[DailyPriceData_Update]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[DailyPriceData_Update]

    -- Add the parameters for the stored procedure here
    @ClosePrice float,
    @CloseScore float,
    @HighPrice float,
    @Id int,
    @LowPrice float,
    @MostRecent bit,
    @OpenPrice float,
    @PercentChange float,
    @PriceUnchanged bit,
    @Spread float,
    @SpreadScore float,
    @StockDate datetime,
    @Streak int,
    @Symbol nvarchar(10),
    @Volume int,
    @VolumeScore float

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [DailyPriceData]

    -- Update Each field
    Set [ClosePrice] = @ClosePrice,
    [CloseScore] = @CloseScore,
    [HighPrice] = @HighPrice,
    [LowPrice] = @LowPrice,
    [MostRecent] = @MostRecent,
    [OpenPrice] = @OpenPrice,
    [PercentChange] = @PercentChange,
    [PriceUnchanged] = @PriceUnchanged,
    [Spread] = @Spread,
    [SpreadScore] = @SpreadScore,
    [StockDate] = @StockDate,
    [Streak] = @Streak,
    [Symbol] = @Symbol,
    [Volume] = @Volume,
    [VolumeScore] = @VolumeScore

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[DailyPriceDataView_FetchAll]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[DailyPriceDataView_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ClosePrice],[CloseScore],[HighPrice],[Id],[LowPrice],[Name],[OpenPrice],[Spread],[SpreadScore],[StockDate],[StockId],[Streak],[Symbol],[Volume],[VolumeScore]

    -- From tableName
    From [DailyPriceDataView]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Industry_Delete]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Industry_Delete]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Industry]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Industry_FetchAll]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Industry_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Advancers],[AveragePercentChange],[Decliners],[Id],[LastUpdated],[Name],[NumberStocks],[Score],[Streak]

    -- From tableName
    From [Industry]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Industry_Find]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Industry_Find]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Advancers],[AveragePercentChange],[Decliners],[Id],[LastUpdated],[Name],[NumberStocks],[Score],[Streak]

    -- From tableName
    From [Industry]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Industry_Insert]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Industry_Insert]

    -- Add the parameters for the stored procedure here
    @Advancers int,
    @AveragePercentChange float,
    @Decliners int,
    @LastUpdated datetime,
    @Name nvarchar(128),
    @NumberStocks int,
    @Score float,
    @Streak int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Industry]
    ([Advancers],[AveragePercentChange],[Decliners],[LastUpdated],[Name],[NumberStocks],[Score],[Streak])

    -- Begin Values List
    Values(@Advancers, @AveragePercentChange, @Decliners, @LastUpdated, @Name, @NumberStocks, @Score, @Streak)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Industry_Update]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Industry_Update]

    -- Add the parameters for the stored procedure here
    @Advancers int,
    @AveragePercentChange float,
    @Decliners int,
    @Id int,
    @LastUpdated datetime,
    @Name nvarchar(128),
    @NumberStocks int,
    @Score float,
    @Streak int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Industry]

    -- Update Each field
    Set [Advancers] = @Advancers,
    [AveragePercentChange] = @AveragePercentChange,
    [Decliners] = @Decliners,
    [LastUpdated] = @LastUpdated,
    [Name] = @Name,
    [NumberStocks] = @NumberStocks,
    [Score] = @Score,
    [Streak] = @Streak

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[IndustryHistory_Delete]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[IndustryHistory_Delete]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [IndustryHistory]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[IndustryHistory_FetchAll]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[IndustryHistory_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Advancers],[AveragePercentChange],[Date],[Decliners],[Id],[IndustryId],[Score],[Streak]

    -- From tableName
    From [IndustryHistory]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[IndustryHistory_Find]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[IndustryHistory_Find]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Advancers],[AveragePercentChange],[Date],[Decliners],[Id],[IndustryId],[Score],[Streak]

    -- From tableName
    From [IndustryHistory]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[IndustryHistory_Insert]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[IndustryHistory_Insert]

    -- Add the parameters for the stored procedure here
    @Advancers int,
    @AveragePercentChange float,
    @Date datetime,
    @Decliners int,
    @IndustryId int,
    @Score float,
    @Streak int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [IndustryHistory]
    ([Advancers],[AveragePercentChange],[Date],[Decliners],[IndustryId],[Score],[Streak])

    -- Begin Values List
    Values(@Advancers, @AveragePercentChange, @Date, @Decliners, @IndustryId, @Score, @Streak)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[IndustryHistory_Update]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[IndustryHistory_Update]

    -- Add the parameters for the stored procedure here
    @Advancers int,
    @AveragePercentChange float,
    @Date datetime,
    @Decliners int,
    @Id int,
    @IndustryId int,
    @Score float,
    @Streak int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [IndustryHistory]

    -- Update Each field
    Set [Advancers] = @Advancers,
    [AveragePercentChange] = @AveragePercentChange,
    [Date] = @Date,
    [Decliners] = @Decliners,
    [IndustryId] = @IndustryId,
    [Score] = @Score,
    [Streak] = @Streak

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[IndustryView_FetchAll]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[IndustryView_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ClosePrice],[DailyPriceDataId],[Industry],[MostRecent],[PercentChange],[PriceUnchanged],[StockDate],[StockId],[StockName],[Streak],[Symbol],[Track]

    -- From tableName
    From [IndustryView]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[IndustryView_FetchAllForIndustry]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[IndustryView_FetchAllForIndustry]

    -- Create @Industry Paramater
    @Industry nvarchar(80)


AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ClosePrice],[DailyPriceDataId],[Industry],[MostRecent],[PercentChange],[StockDate],[StockId],[StockName],[Streak],[Symbol],[Track]

    -- From tableName
    From [IndustryView]

    -- Load Matching Records
    Where [Industry] = @Industry

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[IndustryView_FetchAllForIndustryAndStockDate]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[IndustryView_FetchAllForIndustryAndStockDate]

    -- Create @Industry Paramater
    @Industry nvarchar(80),


    -- Create @StockDate Paramater
    @StockDate datetime


AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ClosePrice],[DailyPriceDataId],[Industry],[MostRecent],[PercentChange],[PriceUnchanged],[StockDate],[StockId],[StockName],[Streak],[Symbol],[Track]

    -- From tableName
    From [IndustryView]

    -- Load Matching Records
    Where [Industry] = @Industry And [StockDate] = @StockDate

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[IndustryView_FetchAllForStockDateAndSymbol]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[IndustryView_FetchAllForStockDateAndSymbol]

    -- Create @StockDate Paramater
    @StockDate datetime,

    -- Create @Symbol Paramater
    @Symbol nvarchar(10)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ClosePrice],[DailyPriceDataId],[Industry],[MostRecent],[PercentChange],[StockDate],[StockId],[StockName],[Streak],[Symbol],[Track]

    -- From tableName
    From [IndustryView]

    -- Load Matching Records
    Where [StockDate] = @StockDate And [Symbol] = @Symbol

END
GO
/****** Object:  StoredProcedure [dbo].[RemoveStock]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[RemoveStock]

    -- Stock Id Parameter
    @StockId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

	Declare @Symbol nvarchar(10)
	
	Set @Symbol = (Select Symbol From Stock Where Id = @StockId)

	-- Delete the Stock
    Delete From Stock Where Id = @StockId

	-- Delete From DailyPriceData
	Delete From DailyPriceData Where Symbol = @Symbol

	-- Delete From StockStreak
	Delete From StockStreak Where StockId = @StockId

END
GO
/****** Object:  StoredProcedure [dbo].[Sector_Delete]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Sector_Delete]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Sector]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Sector_FetchAll]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Sector_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Advancers],[AveragePercentChange],[Decliners],[Id],[LastUpdated],[Name],[NumberStocks],[Score],[Streak]

    -- From tableName
    From [Sector]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Sector_Find]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Sector_Find]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Advancers],[AveragePercentChange],[Decliners],[Id],[LastUpdated],[Name],[NumberStocks],[Score],[Streak]

    -- From tableName
    From [Sector]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Sector_Insert]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Sector_Insert]

    -- Add the parameters for the stored procedure here
    @Advancers int,
    @AveragePercentChange float,
    @Decliners int,
    @LastUpdated datetime,
    @Name nvarchar(50),
    @NumberStocks int,
    @Score float,
    @Streak int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Sector]
    ([Advancers],[AveragePercentChange],[Decliners],[LastUpdated],[Name],[NumberStocks],[Score],[Streak])

    -- Begin Values List
    Values(@Advancers, @AveragePercentChange, @Decliners, @LastUpdated, @Name, @NumberStocks, @Score, @Streak)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Sector_Update]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Sector_Update]

    -- Add the parameters for the stored procedure here
    @Advancers int,
    @AveragePercentChange float,
    @Decliners int,
    @Id int,
    @LastUpdated datetime,
    @Name nvarchar(50),
    @NumberStocks int,
    @Score float,
    @Streak int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Sector]

    -- Update Each field
    Set [Advancers] = @Advancers,
    [AveragePercentChange] = @AveragePercentChange,
    [Decliners] = @Decliners,
    [LastUpdated] = @LastUpdated,
    [Name] = @Name,
    [NumberStocks] = @NumberStocks,
    [Score] = @Score,
    [Streak] = @Streak

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[SectorHistory_Delete]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[SectorHistory_Delete]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [SectorHistory]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[SectorHistory_FetchAll]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[SectorHistory_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Advancers],[AveragePercentChange],[Date],[Decliners],[Id],[Score],[SectorId],[Streak]

    -- From tableName
    From [SectorHistory]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[SectorHistory_Find]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[SectorHistory_Find]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Advancers],[AveragePercentChange],[Date],[Decliners],[Id],[Score],[SectorId],[Streak]

    -- From tableName
    From [SectorHistory]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[SectorHistory_Insert]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[SectorHistory_Insert]

    -- Add the parameters for the stored procedure here
    @Advancers int,
    @AveragePercentChange float,
    @Date datetime,
    @Decliners int,
    @Score float,
    @SectorId int,
    @Streak int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [SectorHistory]
    ([Advancers],[AveragePercentChange],[Date],[Decliners],[Score],[SectorId],[Streak])

    -- Begin Values List
    Values(@Advancers, @AveragePercentChange, @Date, @Decliners, @Score, @SectorId, @Streak)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[SectorHistory_Update]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[SectorHistory_Update]

    -- Add the parameters for the stored procedure here
    @Advancers int,
    @AveragePercentChange float,
    @Date datetime,
    @Decliners int,
    @Id int,
    @Score float,
    @SectorId int,
    @Streak int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [SectorHistory]

    -- Update Each field
    Set [Advancers] = @Advancers,
    [AveragePercentChange] = @AveragePercentChange,
    [Date] = @Date,
    [Decliners] = @Decliners,
    [Score] = @Score,
    [SectorId] = @SectorId,
    [Streak] = @Streak

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[SectorView_FetchAll]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[SectorView_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ClosePrice],[DailyPriceDataId],[MostRecent],[PercentChange],[PriceUnchanged],[Sector],[StockDate],[StockId],[StockName],[Streak],[Symbol],[Track]

    -- From tableName
    From [SectorView]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[SectorView_FetchAllForSector]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[SectorView_FetchAllForSector]

    -- Create @Sector Paramater
    @Sector nvarchar(80)


AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ClosePrice],[DailyPriceDataId],[MostRecent],[Name],[PercentChange],[Sector],[StockDate],[StockId],[Streak],[Symbol],[Track]

    -- From tableName
    From [SectorView]

    -- Load Matching Records
    Where [Sector] = @Sector

END


-- End Custom Methods

-- Thank you for using DataTier.Net.

GO
/****** Object:  StoredProcedure [dbo].[SectorView_FetchAllForSectorAndStockDate]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[SectorView_FetchAllForSectorAndStockDate]

    -- Create @Sector Paramater
    @Sector nvarchar(80),


    -- Create @StockDate Paramater
    @StockDate datetime


AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [ClosePrice],[DailyPriceDataId],[MostRecent],[PercentChange],[PriceUnchanged],[Sector],[StockDate],[StockId],[StockName],[Streak],[Symbol],[Track]

    -- From tableName
    From [SectorView]

    -- Load Matching Records
    Where [Sector] = @Sector And [StockDate] = @StockDate

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Stock_Delete]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Stock_Delete]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Stock]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Stock_FetchAll]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Stock_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [AverageDailyVolume],[Exchange],[Id],[Industry],[IPOYear],[LastClose],[Name],[Sector],[Streak],[Symbol],[Track]

    -- From tableName
    From [Stock]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Stock_Find]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Stock_Find]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [AverageDailyVolume],[Exchange],[Id],[Industry],[IPOYear],[LastClose],[Name],[Sector],[Streak],[Symbol],[Track]

    -- From tableName
    From [Stock]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Stock_FindBySymbol]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Stock_FindBySymbol]

    -- Create @Symbol Paramater
    @Symbol nvarchar(10)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [AverageDailyVolume],[Exchange],[Id],[Industry],[IPOYear],[LastClose],[Name],[Sector],[Streak],[Symbol],[Track]

    -- From tableName
    From [Stock]

    -- Find Matching Record
    Where [Symbol] = @Symbol

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Stock_Insert]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Stock_Insert]

    -- Add the parameters for the stored procedure here
    @AverageDailyVolume int,
    @Exchange nvarchar(10),
    @Industry nvarchar(80),
    @IPOYear int,
    @LastClose float,
    @Name nvarchar(50),
    @Sector nvarchar(80),
    @Streak int,
    @Symbol nvarchar(10),
    @Track bit

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Stock]
    ([AverageDailyVolume],[Exchange],[Industry],[IPOYear],[LastClose],[Name],[Sector],[Streak],[Symbol],[Track])

    -- Begin Values List
    Values(@AverageDailyVolume, @Exchange, @Industry, @IPOYear, @LastClose, @Name, @Sector, @Streak, @Symbol, @Track)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Stock_Update]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Stock_Update]

    -- Add the parameters for the stored procedure here
    @AverageDailyVolume int,
    @Exchange nvarchar(10),
    @Id int,
    @Industry nvarchar(80),
    @IPOYear int,
    @LastClose float,
    @Name nvarchar(50),
    @Sector nvarchar(80),
    @Streak int,
    @Symbol nvarchar(10),
    @Track bit

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Stock]

    -- Update Each field
    Set [AverageDailyVolume] = @AverageDailyVolume,
    [Exchange] = @Exchange,
    [Industry] = @Industry,
    [IPOYear] = @IPOYear,
    [LastClose] = @LastClose,
    [Name] = @Name,
    [Sector] = @Sector,
    [Streak] = @Streak,
    [Symbol] = @Symbol,
    [Track] = @Track

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[StockDay_Delete]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[StockDay_Delete]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [StockDay]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[StockDay_FetchAll]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[StockDay_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Date],[Id],[IndustryProcessed],[SectorProcessed]

    -- From tableName
    From [StockDay]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[StockDay_FetchAllForNeedsProcessing]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[StockDay_FetchAllForNeedsProcessing]

    -- Create @IndustryProcessed Paramater
    @IndustryProcessed bit,


    -- Create @SectorProcessed Paramater
    @SectorProcessed bit


AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Date],[Id],[IndustryProcessed],[SectorProcessed]

    -- From tableName
    From [StockDay]

    -- Load Matching Records
    Where [IndustryProcessed] = @IndustryProcessed And [SectorProcessed] = @SectorProcessed

END


-- End Custom Methods

-- Thank you for using DataTier.Net.

GO
/****** Object:  StoredProcedure [dbo].[StockDay_Find]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[StockDay_Find]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Date],[Id],[IndustryProcessed],[SectorProcessed]

    -- From tableName
    From [StockDay]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[StockDay_Insert]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[StockDay_Insert]

    -- Add the parameters for the stored procedure here
    @Date datetime,
    @IndustryProcessed bit,
    @SectorProcessed bit

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [StockDay]
    ([Date],[IndustryProcessed],[SectorProcessed])

    -- Begin Values List
    Values(@Date, @IndustryProcessed, @SectorProcessed)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[StockDay_Update]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[StockDay_Update]

    -- Add the parameters for the stored procedure here
    @Date datetime,
    @Id int,
    @IndustryProcessed bit,
    @SectorProcessed bit

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [StockDay]

    -- Update Each field
    Set [Date] = @Date,
    [IndustryProcessed] = @IndustryProcessed,
    [SectorProcessed] = @SectorProcessed

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[StockStreak_Delete]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[StockStreak_Delete]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [StockStreak]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[StockStreak_FetchAll]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[StockStreak_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [CurrentStreak],[Id],[PercentChange],[ReverseSplit],[ReverseSplitDivisor],[StockId],[StreakDays],[StreakEndDate],[StreakEndPrice],[StreakStartDate],[StreakStartPrice],[StreakType]

    -- From tableName
    From [StockStreak]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[StockStreak_Find]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[StockStreak_Find]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [CurrentStreak],[Id],[PercentChange],[ReverseSplit],[ReverseSplitDivisor],[StockId],[StreakDays],[StreakEndDate],[StreakEndPrice],[StreakStartDate],[StreakStartPrice],[StreakType]

    -- From tableName
    From [StockStreak]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[StockStreak_FindByStockIdAndCurrentStreak]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[StockStreak_FindByStockIdAndCurrentStreak]

    -- Create @CurrentStreak Paramater
    @CurrentStreak bit,


    -- Create @StockId Paramater
    @StockId int


AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [CurrentStreak],[Id],[PercentChange],[ReverseSplit],[ReverseSplitDivisor],[StockId],[StreakDays],[StreakEndDate],[StreakEndPrice],[StreakStartDate],[StreakStartPrice],[StreakType]

    -- From tableName
    From [StockStreak]

    -- Find Matching Record
    Where [CurrentStreak] = @CurrentStreak And [StockId] = @StockId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[StockStreak_Insert]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[StockStreak_Insert]

    -- Add the parameters for the stored procedure here
    @CurrentStreak bit,
    @PercentChange float,
    @ReverseSplit bit,
    @ReverseSplitDivisor int,
    @StockId int,
    @StreakDays int,
    @StreakEndDate datetime,
    @StreakEndPrice float,
    @StreakStartDate datetime,
    @StreakStartPrice float,
    @StreakType int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [StockStreak]
    ([CurrentStreak],[PercentChange],[ReverseSplit],[ReverseSplitDivisor],[StockId],[StreakDays],[StreakEndDate],[StreakEndPrice],[StreakStartDate],[StreakStartPrice],[StreakType])

    -- Begin Values List
    Values(@CurrentStreak, @PercentChange, @ReverseSplit, @ReverseSplitDivisor, @StockId, @StreakDays, @StreakEndDate, @StreakEndPrice, @StreakStartDate, @StreakStartPrice, @StreakType)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[StockStreak_Update]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[StockStreak_Update]

    -- Add the parameters for the stored procedure here
    @CurrentStreak bit,
    @Id int,
    @PercentChange float,
    @ReverseSplit bit,
    @ReverseSplitDivisor int,
    @StockId int,
    @StreakDays int,
    @StreakEndDate datetime,
    @StreakEndPrice float,
    @StreakStartDate datetime,
    @StreakStartPrice float,
    @StreakType int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [StockStreak]

    -- Update Each field
    Set [CurrentStreak] = @CurrentStreak,
    [PercentChange] = @PercentChange,
    [ReverseSplit] = @ReverseSplit,
    [ReverseSplitDivisor] = @ReverseSplitDivisor,
    [StockId] = @StockId,
    [StreakDays] = @StreakDays,
    [StreakEndDate] = @StreakEndDate,
    [StreakEndPrice] = @StreakEndPrice,
    [StreakStartDate] = @StreakStartDate,
    [StreakStartPrice] = @StreakStartPrice,
    [StreakType] = @StreakType

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[StockStreakView_FetchAll]    Script Date: 8/30/2023 9:08:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[StockStreakView_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [AverageDailyVolume],[Exchange],[Industry],[LastClose],[Name],[PercentChange],[ReverseSplit],[ReverseSplitDivisor],[Sector],[StockId],[Streak],[StreakEndDate],[StreakEndPrice],[StreakStartDate],[StreakStartPrice],[Symbol]

    -- From tableName
    From [StockStreakView]

END

-- Begin Custom Methods


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
