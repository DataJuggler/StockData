/****** Object:  Table [dbo].[Admin]    Script Date: 8/15/2023 1:19:54 PM ******/
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
/****** Object:  Table [dbo].[DailyPriceData]    Script Date: 8/15/2023 1:19:54 PM ******/
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
 CONSTRAINT [PK_DailyPriceData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 8/15/2023 1:19:54 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockStreak]    Script Date: 8/15/2023 1:19:54 PM ******/
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
 CONSTRAINT [PK_StockStreak] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Admin_Delete]    Script Date: 8/15/2023 1:19:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Admin_FetchAll]    Script Date: 8/15/2023 1:19:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Admin_Find]    Script Date: 8/15/2023 1:19:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Admin_Insert]    Script Date: 8/15/2023 1:19:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Admin_Update]    Script Date: 8/15/2023 1:19:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DailyPriceData_Delete]    Script Date: 8/15/2023 1:19:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DailyPriceData_FetchAll]    Script Date: 8/15/2023 1:19:54 PM ******/
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
    Select [ClosePrice],[HighPrice],[Id],[LowPrice],[OpenPrice],[Spread],[StockDate],[Streak],[Symbol],[Volume]

    -- From tableName
    From [DailyPriceData]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[DailyPriceData_Find]    Script Date: 8/15/2023 1:19:54 PM ******/
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
    Select [ClosePrice],[HighPrice],[Id],[LowPrice],[OpenPrice],[Spread],[StockDate],[Streak],[Symbol],[Volume]

    -- From tableName
    From [DailyPriceData]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[DailyPriceData_Insert]    Script Date: 8/15/2023 1:19:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[DailyPriceData_Insert]

    -- Add the parameters for the stored procedure here
    @ClosePrice float,
    @HighPrice float,
    @LowPrice float,
    @OpenPrice float,
    @Spread float,
    @StockDate datetime,
    @Streak int,
    @Symbol nvarchar(10),
    @Volume int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [DailyPriceData]
    ([ClosePrice],[HighPrice],[LowPrice],[OpenPrice],[Spread],[StockDate],[Streak],[Symbol],[Volume])

    -- Begin Values List
    Values(@ClosePrice, @HighPrice, @LowPrice, @OpenPrice, @Spread, @StockDate, @Streak, @Symbol, @Volume)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[DailyPriceData_Update]    Script Date: 8/15/2023 1:19:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[DailyPriceData_Update]

    -- Add the parameters for the stored procedure here
    @ClosePrice float,
    @HighPrice float,
    @Id int,
    @LowPrice float,
    @OpenPrice float,
    @Spread float,
    @StockDate datetime,
    @Streak int,
    @Symbol nvarchar(10),
    @Volume int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [DailyPriceData]

    -- Update Each field
    Set [ClosePrice] = @ClosePrice,
    [HighPrice] = @HighPrice,
    [LowPrice] = @LowPrice,
    [OpenPrice] = @OpenPrice,
    [Spread] = @Spread,
    [StockDate] = @StockDate,
    [Streak] = @Streak,
    [Symbol] = @Symbol,
    [Volume] = @Volume

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Stock_Delete]    Script Date: 8/15/2023 1:19:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Stock_FetchAll]    Script Date: 8/15/2023 1:19:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Stock_Find]    Script Date: 8/15/2023 1:19:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Stock_FindBySymbol]    Script Date: 8/15/2023 1:19:54 PM ******/
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


-- End Custom Methods

-- Thank you for using DataTier.Net.

GO
/****** Object:  StoredProcedure [dbo].[Stock_Insert]    Script Date: 8/15/2023 1:19:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Stock_Update]    Script Date: 8/15/2023 1:19:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[StockStreak_Delete]    Script Date: 8/15/2023 1:19:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[StockStreak_FetchAll]    Script Date: 8/15/2023 1:19:54 PM ******/
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
    Select [CurrentStreak],[Id],[StockId],[StreakContinuing],[StreakDays],[StreakEndDate],[StreakEndPrice],[StreakStartDate],[StreakStartPrice]

    -- From tableName
    From [StockStreak]

END

-- Begin Custom Methods


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[StockStreak_Find]    Script Date: 8/15/2023 1:19:54 PM ******/
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
    Select [CurrentStreak],[Id],[StockId],[StreakContinuing],[StreakDays],[StreakEndDate],[StreakEndPrice],[StreakStartDate],[StreakStartPrice]

    -- From tableName
    From [StockStreak]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[StockStreak_Insert]    Script Date: 8/15/2023 1:19:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[StockStreak_Insert]

    -- Add the parameters for the stored procedure here
    @CurrentStreak bit,
    @StockId int,
    @StreakContinuing bit,
    @StreakDays int,
    @StreakEndDate datetime,
    @StreakEndPrice float,
    @StreakStartDate datetime,
    @StreakStartPrice float

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [StockStreak]
    ([CurrentStreak],[StockId],[StreakContinuing],[StreakDays],[StreakEndDate],[StreakEndPrice],[StreakStartDate],[StreakStartPrice])

    -- Begin Values List
    Values(@CurrentStreak, @StockId, @StreakContinuing, @StreakDays, @StreakEndDate, @StreakEndPrice, @StreakStartDate, @StreakStartPrice)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[StockStreak_Update]    Script Date: 8/15/2023 1:19:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[StockStreak_Update]

    -- Add the parameters for the stored procedure here
    @CurrentStreak bit,
    @Id int,
    @StockId int,
    @StreakContinuing bit,
    @StreakDays int,
    @StreakEndDate datetime,
    @StreakEndPrice float,
    @StreakStartDate datetime,
    @StreakStartPrice float

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [StockStreak]

    -- Update Each field
    Set [CurrentStreak] = @CurrentStreak,
    [StockId] = @StockId,
    [StreakContinuing] = @StreakContinuing,
    [StreakDays] = @StreakDays,
    [StreakEndDate] = @StreakEndDate,
    [StreakEndPrice] = @StreakEndPrice,
    [StreakStartDate] = @StreakStartDate,
    [StreakStartPrice] = @StreakStartPrice

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
