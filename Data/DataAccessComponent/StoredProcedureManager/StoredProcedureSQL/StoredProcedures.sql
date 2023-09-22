Use [StockData]

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Admin_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Insert a new Admin
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Admin_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Admin_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Admin_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Admin_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Admin_Insert >>>'

    End

GO

Create PROCEDURE Admin_Insert

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
Go
-- =========================================================
-- Procure Name: Admin_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Update an existing Admin
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Admin_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Admin_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Admin_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Admin_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Admin_Update >>>'

    End

GO

Create PROCEDURE Admin_Update

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
Go
-- =========================================================
-- Procure Name: Admin_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Find an existing Admin
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Admin_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Admin_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Admin_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Admin_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Admin_Find >>>'

    End

GO

Create PROCEDURE Admin_Find

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
Go
-- =========================================================
-- Procure Name: Admin_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Delete an existing Admin
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Admin_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Admin_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Admin_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Admin_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Admin_Delete >>>'

    End

GO

Create PROCEDURE Admin_Delete

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
Go
-- =========================================================
-- Procure Name: Admin_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Returns all Admin objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Admin_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Admin_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Admin_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Admin_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Admin_FetchAll >>>'

    End

GO

Create PROCEDURE Admin_FetchAll

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
Go
-- =========================================================
-- Procure Name: DailyPriceData_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Insert a new DailyPriceData
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('DailyPriceData_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure DailyPriceData_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.DailyPriceData_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure DailyPriceData_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure DailyPriceData_Insert >>>'

    End

GO

Create PROCEDURE DailyPriceData_Insert

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
Go
-- =========================================================
-- Procure Name: DailyPriceData_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Update an existing DailyPriceData
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('DailyPriceData_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure DailyPriceData_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.DailyPriceData_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure DailyPriceData_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure DailyPriceData_Update >>>'

    End

GO

Create PROCEDURE DailyPriceData_Update

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
Go
-- =========================================================
-- Procure Name: DailyPriceData_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Find an existing DailyPriceData
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('DailyPriceData_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure DailyPriceData_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.DailyPriceData_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure DailyPriceData_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure DailyPriceData_Find >>>'

    End

GO

Create PROCEDURE DailyPriceData_Find

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
Go
-- =========================================================
-- Procure Name: DailyPriceData_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Delete an existing DailyPriceData
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('DailyPriceData_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure DailyPriceData_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.DailyPriceData_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure DailyPriceData_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure DailyPriceData_Delete >>>'

    End

GO

Create PROCEDURE DailyPriceData_Delete

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
Go
-- =========================================================
-- Procure Name: DailyPriceData_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Returns all DailyPriceData objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('DailyPriceData_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure DailyPriceData_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.DailyPriceData_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure DailyPriceData_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure DailyPriceData_FetchAll >>>'

    End

GO

Create PROCEDURE DailyPriceData_FetchAll

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
Go
-- =========================================================
-- Procure Name: DailyPriceDataView_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Returns all DailyPriceDataView objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('DailyPriceDataView_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure DailyPriceDataView_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.DailyPriceDataView_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure DailyPriceDataView_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure DailyPriceDataView_FetchAll >>>'

    End

GO

Create PROCEDURE DailyPriceDataView_FetchAll

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
Go
-- =========================================================
-- Procure Name: Industry_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Insert a new Industry
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Industry_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Industry_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Industry_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Industry_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Industry_Insert >>>'

    End

GO

Create PROCEDURE Industry_Insert

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
Go
-- =========================================================
-- Procure Name: Industry_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Update an existing Industry
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Industry_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Industry_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Industry_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Industry_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Industry_Update >>>'

    End

GO

Create PROCEDURE Industry_Update

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
Go
-- =========================================================
-- Procure Name: Industry_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Find an existing Industry
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Industry_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Industry_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Industry_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Industry_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Industry_Find >>>'

    End

GO

Create PROCEDURE Industry_Find

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
Go
-- =========================================================
-- Procure Name: Industry_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Delete an existing Industry
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Industry_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Industry_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Industry_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Industry_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Industry_Delete >>>'

    End

GO

Create PROCEDURE Industry_Delete

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
Go
-- =========================================================
-- Procure Name: Industry_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Returns all Industry objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Industry_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Industry_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Industry_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Industry_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Industry_FetchAll >>>'

    End

GO

Create PROCEDURE Industry_FetchAll

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
Go
-- =========================================================
-- Procure Name: IndustryHistory_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Insert a new IndustryHistory
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('IndustryHistory_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure IndustryHistory_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.IndustryHistory_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure IndustryHistory_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure IndustryHistory_Insert >>>'

    End

GO

Create PROCEDURE IndustryHistory_Insert

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
Go
-- =========================================================
-- Procure Name: IndustryHistory_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Update an existing IndustryHistory
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('IndustryHistory_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure IndustryHistory_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.IndustryHistory_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure IndustryHistory_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure IndustryHistory_Update >>>'

    End

GO

Create PROCEDURE IndustryHistory_Update

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
Go
-- =========================================================
-- Procure Name: IndustryHistory_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Find an existing IndustryHistory
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('IndustryHistory_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure IndustryHistory_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.IndustryHistory_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure IndustryHistory_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure IndustryHistory_Find >>>'

    End

GO

Create PROCEDURE IndustryHistory_Find

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
Go
-- =========================================================
-- Procure Name: IndustryHistory_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Delete an existing IndustryHistory
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('IndustryHistory_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure IndustryHistory_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.IndustryHistory_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure IndustryHistory_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure IndustryHistory_Delete >>>'

    End

GO

Create PROCEDURE IndustryHistory_Delete

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
Go
-- =========================================================
-- Procure Name: IndustryHistory_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Returns all IndustryHistory objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('IndustryHistory_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure IndustryHistory_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.IndustryHistory_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure IndustryHistory_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure IndustryHistory_FetchAll >>>'

    End

GO

Create PROCEDURE IndustryHistory_FetchAll

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
Go
-- =========================================================
-- Procure Name: IndustryView_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Returns all IndustryView objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('IndustryView_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure IndustryView_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.IndustryView_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure IndustryView_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure IndustryView_FetchAll >>>'

    End

GO

Create PROCEDURE IndustryView_FetchAll

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
Go
-- =========================================================
-- Procure Name: RecommendationLog_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Insert a new RecommendationLog
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('RecommendationLog_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure RecommendationLog_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.RecommendationLog_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure RecommendationLog_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure RecommendationLog_Insert >>>'

    End

GO

Create PROCEDURE RecommendationLog_Insert

    -- Add the parameters for the stored procedure here
    @CloseScore float,
    @Industry nvarchar(80),
    @IndustryScore float,
    @IndustryStreak int,
    @LastClose float,
    @LastPercentChange float,
    @Score float,
    @Sector nvarchar(80),
    @SectorScore float,
    @SectorStreak int,
    @StockDate datetime,
    @StockName nvarchar(50),
    @Streak int,
    @StreakPercentChange float,
    @Symbol nvarchar(10),
    @VolumeScore float

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [RecommendationLog]
    ([CloseScore],[Industry],[IndustryScore],[IndustryStreak],[LastClose],[LastPercentChange],[Score],[Sector],[SectorScore],[SectorStreak],[StockDate],[StockName],[Streak],[StreakPercentChange],[Symbol],[VolumeScore])

    -- Begin Values List
    Values(@CloseScore, @Industry, @IndustryScore, @IndustryStreak, @LastClose, @LastPercentChange, @Score, @Sector, @SectorScore, @SectorStreak, @StockDate, @StockName, @Streak, @StreakPercentChange, @Symbol, @VolumeScore)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: RecommendationLog_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Update an existing RecommendationLog
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('RecommendationLog_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure RecommendationLog_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.RecommendationLog_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure RecommendationLog_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure RecommendationLog_Update >>>'

    End

GO

Create PROCEDURE RecommendationLog_Update

    -- Add the parameters for the stored procedure here
    @CloseScore float,
    @Id int,
    @Industry nvarchar(80),
    @IndustryScore float,
    @IndustryStreak int,
    @LastClose float,
    @LastPercentChange float,
    @Score float,
    @Sector nvarchar(80),
    @SectorScore float,
    @SectorStreak int,
    @StockDate datetime,
    @StockName nvarchar(50),
    @Streak int,
    @StreakPercentChange float,
    @Symbol nvarchar(10),
    @VolumeScore float

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [RecommendationLog]

    -- Update Each field
    Set [CloseScore] = @CloseScore,
    [Industry] = @Industry,
    [IndustryScore] = @IndustryScore,
    [IndustryStreak] = @IndustryStreak,
    [LastClose] = @LastClose,
    [LastPercentChange] = @LastPercentChange,
    [Score] = @Score,
    [Sector] = @Sector,
    [SectorScore] = @SectorScore,
    [SectorStreak] = @SectorStreak,
    [StockDate] = @StockDate,
    [StockName] = @StockName,
    [Streak] = @Streak,
    [StreakPercentChange] = @StreakPercentChange,
    [Symbol] = @Symbol,
    [VolumeScore] = @VolumeScore

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: RecommendationLog_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Find an existing RecommendationLog
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('RecommendationLog_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure RecommendationLog_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.RecommendationLog_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure RecommendationLog_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure RecommendationLog_Find >>>'

    End

GO

Create PROCEDURE RecommendationLog_Find

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [CloseScore],[Id],[Industry],[IndustryScore],[IndustryStreak],[LastClose],[LastPercentChange],[Score],[Sector],[SectorScore],[SectorStreak],[StockDate],[StockName],[Streak],[StreakPercentChange],[Symbol],[VolumeScore]

    -- From tableName
    From [RecommendationLog]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: RecommendationLog_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Delete an existing RecommendationLog
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('RecommendationLog_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure RecommendationLog_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.RecommendationLog_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure RecommendationLog_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure RecommendationLog_Delete >>>'

    End

GO

Create PROCEDURE RecommendationLog_Delete

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [RecommendationLog]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: RecommendationLog_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Returns all RecommendationLog objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('RecommendationLog_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure RecommendationLog_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.RecommendationLog_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure RecommendationLog_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure RecommendationLog_FetchAll >>>'

    End

GO

Create PROCEDURE RecommendationLog_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [CloseScore],[Id],[Industry],[IndustryScore],[IndustryStreak],[LastClose],[LastPercentChange],[Score],[Sector],[SectorScore],[SectorStreak],[StockDate],[StockName],[Streak],[StreakPercentChange],[Symbol],[VolumeScore]

    -- From tableName
    From [RecommendationLog]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: RecommendationView_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Returns all RecommendationView objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('RecommendationView_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure RecommendationView_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.RecommendationView_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure RecommendationView_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure RecommendationView_FetchAll >>>'

    End

GO

Create PROCEDURE RecommendationView_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [CloseScore],[Industry],[IndustryScore],[IndustryStreak],[LastClose],[LastPercentChange],[Score],[Sector],[SectorScore],[SectorStreak],[StockDate],[StockID],[StockName],[Streak],[StreakPercentChange],[Symbol],[VolumeScore]

    -- From tableName
    From [RecommendationView]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Sector_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Insert a new Sector
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Sector_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Sector_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Sector_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Sector_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Sector_Insert >>>'

    End

GO

Create PROCEDURE Sector_Insert

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
Go
-- =========================================================
-- Procure Name: Sector_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Update an existing Sector
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Sector_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Sector_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Sector_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Sector_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Sector_Update >>>'

    End

GO

Create PROCEDURE Sector_Update

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
Go
-- =========================================================
-- Procure Name: Sector_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Find an existing Sector
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Sector_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Sector_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Sector_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Sector_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Sector_Find >>>'

    End

GO

Create PROCEDURE Sector_Find

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
Go
-- =========================================================
-- Procure Name: Sector_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Delete an existing Sector
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Sector_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Sector_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Sector_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Sector_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Sector_Delete >>>'

    End

GO

Create PROCEDURE Sector_Delete

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
Go
-- =========================================================
-- Procure Name: Sector_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Returns all Sector objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Sector_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Sector_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Sector_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Sector_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Sector_FetchAll >>>'

    End

GO

Create PROCEDURE Sector_FetchAll

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
Go
-- =========================================================
-- Procure Name: SectorHistory_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Insert a new SectorHistory
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('SectorHistory_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure SectorHistory_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.SectorHistory_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure SectorHistory_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure SectorHistory_Insert >>>'

    End

GO

Create PROCEDURE SectorHistory_Insert

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
Go
-- =========================================================
-- Procure Name: SectorHistory_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Update an existing SectorHistory
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('SectorHistory_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure SectorHistory_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.SectorHistory_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure SectorHistory_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure SectorHistory_Update >>>'

    End

GO

Create PROCEDURE SectorHistory_Update

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
Go
-- =========================================================
-- Procure Name: SectorHistory_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Find an existing SectorHistory
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('SectorHistory_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure SectorHistory_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.SectorHistory_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure SectorHistory_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure SectorHistory_Find >>>'

    End

GO

Create PROCEDURE SectorHistory_Find

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
Go
-- =========================================================
-- Procure Name: SectorHistory_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Delete an existing SectorHistory
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('SectorHistory_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure SectorHistory_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.SectorHistory_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure SectorHistory_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure SectorHistory_Delete >>>'

    End

GO

Create PROCEDURE SectorHistory_Delete

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
Go
-- =========================================================
-- Procure Name: SectorHistory_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Returns all SectorHistory objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('SectorHistory_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure SectorHistory_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.SectorHistory_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure SectorHistory_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure SectorHistory_FetchAll >>>'

    End

GO

Create PROCEDURE SectorHistory_FetchAll

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
Go
-- =========================================================
-- Procure Name: SectorView_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Returns all SectorView objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('SectorView_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure SectorView_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.SectorView_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure SectorView_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure SectorView_FetchAll >>>'

    End

GO

Create PROCEDURE SectorView_FetchAll

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
Go
-- =========================================================
-- Procure Name: Stock_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Insert a new Stock
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Stock_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Stock_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Stock_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Stock_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Stock_Insert >>>'

    End

GO

Create PROCEDURE Stock_Insert

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
Go
-- =========================================================
-- Procure Name: Stock_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Update an existing Stock
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Stock_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Stock_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Stock_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Stock_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Stock_Update >>>'

    End

GO

Create PROCEDURE Stock_Update

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
Go
-- =========================================================
-- Procure Name: Stock_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Find an existing Stock
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Stock_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Stock_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Stock_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Stock_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Stock_Find >>>'

    End

GO

Create PROCEDURE Stock_Find

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
Go
-- =========================================================
-- Procure Name: Stock_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Delete an existing Stock
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Stock_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Stock_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Stock_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Stock_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Stock_Delete >>>'

    End

GO

Create PROCEDURE Stock_Delete

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
Go
-- =========================================================
-- Procure Name: Stock_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Returns all Stock objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Stock_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Stock_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Stock_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Stock_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Stock_FetchAll >>>'

    End

GO

Create PROCEDURE Stock_FetchAll

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
Go
-- =========================================================
-- Procure Name: StockDay_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Insert a new StockDay
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('StockDay_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure StockDay_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.StockDay_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure StockDay_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure StockDay_Insert >>>'

    End

GO

Create PROCEDURE StockDay_Insert

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
Go
-- =========================================================
-- Procure Name: StockDay_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Update an existing StockDay
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('StockDay_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure StockDay_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.StockDay_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure StockDay_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure StockDay_Update >>>'

    End

GO

Create PROCEDURE StockDay_Update

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
Go
-- =========================================================
-- Procure Name: StockDay_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Find an existing StockDay
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('StockDay_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure StockDay_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.StockDay_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure StockDay_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure StockDay_Find >>>'

    End

GO

Create PROCEDURE StockDay_Find

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
Go
-- =========================================================
-- Procure Name: StockDay_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Delete an existing StockDay
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('StockDay_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure StockDay_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.StockDay_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure StockDay_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure StockDay_Delete >>>'

    End

GO

Create PROCEDURE StockDay_Delete

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
Go
-- =========================================================
-- Procure Name: StockDay_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Returns all StockDay objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('StockDay_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure StockDay_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.StockDay_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure StockDay_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure StockDay_FetchAll >>>'

    End

GO

Create PROCEDURE StockDay_FetchAll

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
Go
-- =========================================================
-- Procure Name: StockStreak_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Insert a new StockStreak
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('StockStreak_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure StockStreak_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.StockStreak_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure StockStreak_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure StockStreak_Insert >>>'

    End

GO

Create PROCEDURE StockStreak_Insert

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
Go
-- =========================================================
-- Procure Name: StockStreak_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Update an existing StockStreak
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('StockStreak_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure StockStreak_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.StockStreak_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure StockStreak_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure StockStreak_Update >>>'

    End

GO

Create PROCEDURE StockStreak_Update

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
Go
-- =========================================================
-- Procure Name: StockStreak_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Find an existing StockStreak
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('StockStreak_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure StockStreak_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.StockStreak_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure StockStreak_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure StockStreak_Find >>>'

    End

GO

Create PROCEDURE StockStreak_Find

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
Go
-- =========================================================
-- Procure Name: StockStreak_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Delete an existing StockStreak
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('StockStreak_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure StockStreak_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.StockStreak_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure StockStreak_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure StockStreak_Delete >>>'

    End

GO

Create PROCEDURE StockStreak_Delete

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
Go
-- =========================================================
-- Procure Name: StockStreak_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Returns all StockStreak objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('StockStreak_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure StockStreak_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.StockStreak_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure StockStreak_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure StockStreak_FetchAll >>>'

    End

GO

Create PROCEDURE StockStreak_FetchAll

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
Go
-- =========================================================
-- Procure Name: StockStreakView_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Returns all StockStreakView objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('StockStreakView_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure StockStreakView_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.StockStreakView_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure StockStreakView_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure StockStreakView_FetchAll >>>'

    End

GO

Create PROCEDURE StockStreakView_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [AverageDailyVolume],[CloseScore],[Exchange],[Industry],[IndustryScore],[IndustryStreak],[LastClose],[LastPercentChange],[Name],[PercentChange],[ReverseSplit],[ReverseSplitDivisor],[Sector],[SectorScore],[SectorStreak],[StockDate],[StockId],[Streak],[StreakEndDate],[StreakEndPrice],[StreakPercentChange],[StreakStartDate],[StreakStartPrice],[Symbol],[VolumeScore]

    -- From tableName
    From [StockStreakView]

END

-- Begin Custom Methods


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: DailyPriceData_FindBySymbolAndMostRecent
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Find an existing DailyPriceData by
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('DailyPriceData_FindBySymbolAndMostRecent'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure DailyPriceData_FindBySymbolAndMostRecent

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.DailyPriceData_FindBySymbolAndMostRecent') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure DailyPriceData_FindBySymbolAndMostRecent >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure DailyPriceData_FindBySymbolAndMostRecent >>>'

    End

GO

Create PROCEDURE DailyPriceData_FindBySymbolAndMostRecent

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
Go
-- =========================================================
-- Procure Name: Stock_FindBySymbol
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Find an existing Stock for the Symbol given.
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Stock_FindBySymbol'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Stock_FindBySymbol

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Stock_FindBySymbol') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Stock_FindBySymbol >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Stock_FindBySymbol >>>'

    End

GO

Create PROCEDURE Stock_FindBySymbol

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
Go
-- =========================================================
-- Procure Name: StockStreak_FindByStockIdAndCurrentStreak
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Find an existing StockStreak by
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('StockStreak_FindByStockIdAndCurrentStreak'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure StockStreak_FindByStockIdAndCurrentStreak

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.StockStreak_FindByStockIdAndCurrentStreak') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure StockStreak_FindByStockIdAndCurrentStreak >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure StockStreak_FindByStockIdAndCurrentStreak >>>'

    End

GO

Create PROCEDURE StockStreak_FindByStockIdAndCurrentStreak

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
Go
-- =========================================================
-- Procure Name: DailyPriceData_FetchAllForSymbol
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Returns all DailyPriceData objects for the Symbol given.
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('DailyPriceData_FetchAllForSymbol'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure DailyPriceData_FetchAllForSymbol

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.DailyPriceData_FetchAllForSymbol') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure DailyPriceData_FetchAllForSymbol >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure DailyPriceData_FetchAllForSymbol >>>'

    End

GO

Create PROCEDURE DailyPriceData_FetchAllForSymbol

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
Go
-- =========================================================
-- Procure Name: IndustryView_FetchAllForIndustryAndStockDate
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Returns all IndustryView objects by
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('IndustryView_FetchAllForIndustryAndStockDate'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure IndustryView_FetchAllForIndustryAndStockDate

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.IndustryView_FetchAllForIndustryAndStockDate') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure IndustryView_FetchAllForIndustryAndStockDate >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure IndustryView_FetchAllForIndustryAndStockDate >>>'

    End

GO

Create PROCEDURE IndustryView_FetchAllForIndustryAndStockDate

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
Go
-- =========================================================
-- Procure Name: SectorView_FetchAllForSectorAndStockDate
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Returns all SectorView objects by
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('SectorView_FetchAllForSectorAndStockDate'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure SectorView_FetchAllForSectorAndStockDate

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.SectorView_FetchAllForSectorAndStockDate') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure SectorView_FetchAllForSectorAndStockDate >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure SectorView_FetchAllForSectorAndStockDate >>>'

    End

GO

Create PROCEDURE SectorView_FetchAllForSectorAndStockDate

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
Go
-- =========================================================
-- Procure Name: StockDay_FetchAllForNeedsProcessing
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   9/21/2023
-- Description:    Returns all StockDay objects by
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('StockDay_FetchAllForNeedsProcessing'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure StockDay_FetchAllForNeedsProcessing

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.StockDay_FetchAllForNeedsProcessing') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure StockDay_FetchAllForNeedsProcessing >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure StockDay_FetchAllForNeedsProcessing >>>'

    End

GO

Create PROCEDURE StockDay_FetchAllForNeedsProcessing

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

