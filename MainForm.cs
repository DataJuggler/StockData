

#region using statements

using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using DataJuggler.Excelerate;
using DataJuggler.UltimateHelper;
using StockData.Objects;
using DataJuggler.UltimateHelper.Objects;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using ApplicationLogicComponent.Connection;
using DataGateway;
using System.Xml.Schema;
using System.Text;

#endregion

namespace StockData
{

    #region class MainForm
    /// <summary>
    /// This class is the MainForm for this app.
    /// </summary>
    public partial class MainForm : Form
    {

        #region Private Variables
        private Gateway gateway;
        private Admin admin;
        private bool stockDayProcessed;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'MainForm' object.
        /// </summary>
        public MainForm()
        {
            // Create Controls
            InitializeComponent();

            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events

        #region DoNotTrackButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'DoNotTrackButton' is clicked.
        /// </summary>
        private void DoNotTrackButton_Click(object sender, EventArgs e)
        {
            // set this path (fix for your location or set to relative if you feel like it)
            string path = "C:\\Projects\\GitHub\\StockData\\Documents\\Stocks\\DoNotTrackSymbols.xlsx";

            // Create a new instance of a 'WorksheetInfo' object.
            WorksheetInfo worksheetInfo = new WorksheetInfo();

            // set the properties
            worksheetInfo.SheetName = "DoNotTrack";
            worksheetInfo.LoadColumnOptions = LoadColumnOptionsEnum.LoadAllColumnsExceptExcluded;
            worksheetInfo.Path = path;

            // load the worksheet
            Worksheet worksheet = ExcelDataLoader.LoadWorksheet(worksheetInfo);

            // load the list of Symbols
            List<AddToDoNotTrack> doNotTrackList = AddToDoNotTrack.Load(worksheet);

            // If the doNotTrackList collection exists and has one or more items
            if (ListHelper.HasOneOrMoreItems(doNotTrackList))
            {
                // Setup the Graph
                SetupGraph("Adding missing items to Do Not Track table", doNotTrackList.Count, true);

                // Iterate the collection of AddToDoNotTrack objects
                foreach (AddToDoNotTrack addToDoNotTrack in doNotTrackList)
                {
                    // Create a new instance of a 'DoNotTrack' object.
                    DoNotTrack doNotTrack = new DoNotTrack();

                    // Set the Symbol
                    doNotTrack.Symbol = addToDoNotTrack.Symbol;

                    // perform the save
                    bool saved = Gateway.SaveDoNotTrack(ref doNotTrack);

                    // if the value for saved is true
                    if (saved)
                    {
                        // Increment the value for Graph
                        Graph.Value++;
                    }
                }

                // Show a finished method
                SetupGraph("Finished Updating Do Not Track", 0, false);
            }
        }
        #endregion

        #region FindMaxStreakButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'FindMaxStreakButton' is clicked.
        /// </summary>
        private void FindMaxStreakButton_Click(object sender, EventArgs e)
        {
            // locals
            int advanced = 0;
            int declined = 0;

            // load all stocks
            List<Stock> stocks = Gateway.LoadStocks();

            if (ListHelper.HasOneOrMoreItems(stocks))
            {
                Graph.Value = 0;
                Graph.Maximum = stocks.Count;
                Graph.Visible = true;
                StatusLabel.Text = "Processiing 4 Weeks After Max Streak Results";

                // Iterate the collection of Stock objects
                foreach (Stock stock in stocks)
                {
                    // find the max streak for this stock
                    DailyPriceData maxStreak = Gateway.FindDailyPriceDataMaxStreakBySymbol(stock.Symbol);

                    // If the maxStreak object exists
                    if (NullHelper.Exists(maxStreak))
                    {
                        DateTime monthOut = maxStreak.StockDate.AddDays(28);

                        DailyPriceData monthAfterMaxStreak = Gateway.FindDailyPriceDataByStockDateAndSymbol(monthOut, stock.Symbol);

                        // If the monthAfterMaxStreak object exists
                        if (NullHelper.Exists(monthAfterMaxStreak))
                        {
                            if (monthAfterMaxStreak.ClosePrice > maxStreak.ClosePrice)
                            {
                                // Increment the value for advanced
                                advanced++;
                            }
                            else if (monthAfterMaxStreak.ClosePrice < maxStreak.ClosePrice)
                            {
                                // Increment the value for declined
                                declined++;
                            }
                        }
                    }

                    // Update the graph
                    Graph.Value++;

                    // Refresh
                    Refresh();
                    Application.DoEvents();
                }

                MessageBox.Show("Advanced: " + advanced + Environment.NewLine + "Declined: " + declined, "Results");
            }
        }
        #endregion
            
        #region FixPercentChangeButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'FixPercentChangeButton' is clicked.
        /// </summary>
        private void FixPercentChangeButton_Click(object sender, EventArgs e)
        {
            // Load all the stocks
            List<Stock> stocks = Gateway.LoadStocks();

            // local
            DailyPriceData prevData = null;

            // If the stocks collection exists and has one or more items
            if (ListHelper.HasOneOrMoreItems(stocks))
            {
                // Setup the Progress Bar
                SetupGraph("Fixing Percent Change", stocks.Count, true);

                // Iterate the collection of Stock objects
                foreach (Stock stock in stocks)
                {
                    // reset for each stock
                    prevData = null;

                    // Load the DailyPriceData for this symbol
                    List<DailyPriceData> dailyPriceData = Gateway.LoadAllDailyPriceDatasForSymbol(stock.Symbol);

                    // If the dailyPriceData collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(dailyPriceData))
                    {
                        // Iterate the collection of DailyPriceData objects
                        foreach (DailyPriceData data in dailyPriceData)
                        {
                            // if not the first stock, since we do not have data for the first stock
                            if (NullHelper.Exists(prevData))
                            {
                                // Set the PercentChange
                                data.PercentChange = SetDailyPriceDataPercentChange(prevData.ClosePrice, data.ClosePrice);

                                // Clone this so it can be saved
                                DailyPriceData clone = data.Clone();

                                // test only
                                int id = clone.Id;

                                // perform the save
                                bool saved = Gateway.SaveDailyPriceData(ref clone);
                            }

                            // set the value for prevData
                            prevData = data;
                        }
                    }

                    // Increment the value for Graph
                    Graph.Value++;
                }
            }

            // udpate the label
            StatusLabel.Text = "Done.";
        }
        #endregion

        #region ImportIndustryButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'ImportIndustryButton' is clicked.
        /// </summary>
        private void ImportIndustryButton_Click(object sender, EventArgs e)
        {
            // local
            bool saved = false;

            // Create a new instance of a 'WorksheetInfo' object.
            WorksheetInfo worksheetInfo = new WorksheetInfo();

            // set the properties
            worksheetInfo.SheetName = "Industry";
            worksheetInfo.LoadColumnOptions = LoadColumnOptionsEnum.LoadAllColumnsExceptExcluded;
            worksheetInfo.Path = "C:\\Projects\\GitHub\\StockData\\Documents\\Stocks\\Industry And Sector.xlsx";

            // load the worksheet
            Worksheet worksheet = ExcelDataLoader.LoadWorksheet(worksheetInfo);

            // Load the NASDAQ entries
            List<StockData.Objects.Industry> industries = StockData.Objects.Industry.Load(worksheet);

            // If the industries collection exists and has one or more items
            if (ListHelper.HasOneOrMoreItems(industries))
            {
                // Setup the Graph
                SetupGraph("Importing Industries", industries.Count, true);

                // iterate the industries
                foreach (StockData.Objects.Industry industry in industries)
                {
                    // perofrm the save
                    ObjectLibrary.BusinessObjects.Industry dataIndustry = new ObjectLibrary.BusinessObjects.Industry();
                    dataIndustry.Name = industry.Name;

                    // perform the save
                    saved = Gateway.SaveIndustry(ref dataIndustry);

                    // if the value for saved is true
                    if (saved)
                    {
                        // Increment the value for Graph
                        Graph.Value++;
                    }
                }

                // Setup the Graph
                SetupGraph("Finished Importing Industries", 0, false);
            }
        }
        #endregion

        #region ImportSectorsButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'ImportSectorsButton' is clicked.
        /// </summary>
        private void ImportSectorsButton_Click(object sender, EventArgs e)
        {
            // local
            bool saved = false;

            // Create a new instance of a 'WorksheetInfo' object.
            WorksheetInfo worksheetInfo = new WorksheetInfo();

            // set the properties
            worksheetInfo.SheetName = "Sector";
            worksheetInfo.LoadColumnOptions = LoadColumnOptionsEnum.LoadAllColumnsExceptExcluded;
            worksheetInfo.Path = "C:\\Projects\\GitHub\\StockData\\Documents\\Stocks\\Industry And Sector.xlsx";

            // load the worksheet
            Worksheet worksheet = ExcelDataLoader.LoadWorksheet(worksheetInfo);

            // Load the NASDAQ entries
            List<StockData.Objects.Sector> sectors = StockData.Objects.Sector.Load(worksheet);

            // If the sectors collection exists and has one or more items
            if (ListHelper.HasOneOrMoreItems(sectors))
            {
                // Setup the Graph
                SetupGraph("Importing Sectors", sectors.Count, true);

                // iterate the industries
                foreach (StockData.Objects.Sector sector in sectors)
                {
                    // perofrm the save
                    ObjectLibrary.BusinessObjects.Sector dataSector = new ObjectLibrary.BusinessObjects.Sector();
                    dataSector.Name = sector.Name;

                    // perform the save
                    saved = Gateway.SaveSector(ref dataSector);

                    // if the value for saved is true
                    if (saved)
                    {
                        // Increment the value for Graph
                        Graph.Value++;
                    }
                }

                // Setup the Graph
                SetupGraph("Finished Importing Sectors", 0, false);
            }
        }
        #endregion

        #region ImportStocksButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'ImportStocksButton' is clicked.
        /// </summary>
        private void ImportStocksButton_Click(object sender, EventArgs e)
        {
            // local
            bool saved = false;

            // Remove focus from this buttton
            HiddenButton.Focus();

            // locals
            string worksheetPath = "C:\\Projects\\GitHub\\StockData\\Documents\\Stocks\\NASDAQ.xlsx";
            string worksheetPath2 = "C:\\Projects\\GitHub\\StockData\\Documents\\Stocks\\NYSE.xlsx";

            // Create a new instance of a 'WorksheetInfo' object.
            WorksheetInfo worksheetInfo = new WorksheetInfo();

            // set the properties
            worksheetInfo.SheetName = "NASDAQ";
            worksheetInfo.LoadColumnOptions = LoadColumnOptionsEnum.LoadAllColumnsExceptExcluded;
            worksheetInfo.Path = worksheetPath;

            // load the worksheet
            Worksheet worksheet = ExcelDataLoader.LoadWorksheet(worksheetInfo.Path, worksheetInfo);

            // Create a new instance of a 'WorksheetInfo' object.
            WorksheetInfo worksheetInfo2 = new WorksheetInfo();

            // set the properties
            worksheetInfo2.SheetName = "NYSE";
            worksheetInfo2.LoadColumnOptions = LoadColumnOptionsEnum.LoadAllColumnsExceptExcluded;
            worksheetInfo2.Path = worksheetPath2;

            // Load the NASDAQ entries
            List<NASDAQ> nasdaqEntries = NASDAQ.Load(worksheet);

            // load the worksheet
            Worksheet worksheet2 = ExcelDataLoader.LoadWorksheet(worksheetInfo2);

            // Load the NYSE entries
            List<NYSE> nyseEntries = NYSE.Load(worksheet2);

            // If the nasdaqEntries collection and the nyseEntries collection both exist and each have one or more items
            if (ListHelper.HasOneOrMoreItems(nasdaqEntries, nyseEntries))
            {
                // Setup our graph
                SetupGraph("Saving NASDAQ Stocks", nasdaqEntries.Count, true);

                // Iterate the collection of NASDAQ objects
                foreach (NASDAQ entry in nasdaqEntries)
                {
                    // Check for symbols like carot or slashes
                    bool doesStockContainSymbol = DoesStockContainSymbol(entry.Symbol);

                    // if the value for doesStockContainSymbol is false
                    if (!doesStockContainSymbol)
                    {
                        // We have to determine if this stock is in the list
                        Stock tempStock = Gateway.FindStockBySymbol(entry.Symbol);

                        // If the tempStock object does not exist
                        if (NullHelper.IsNull(tempStock))
                        {
                            // Create a new instance of a 'Stock' object.
                            Stock stock = new Stock();

                            // set the properties of the stock object
                            stock.IPOYear = entry.IPOYear;
                            stock.LastClose = 0;
                            stock.Track = true;
                            stock.AverageDailyVolume = 0;
                            stock.Exchange = "NASDAQ";
                            stock.Industry = entry.Industry;
                            stock.Sector = entry.Sector;
                            stock.Streak = 0;
                            stock.Symbol = entry.Symbol;
                            stock.Name = entry.Name;

                            // perform the stock
                            saved = Gateway.SaveStock(ref stock);
                        }
                    }

                    // Increment the value for Graph
                    Graph.Value++;
                }

                // Setup our graph
                SetupGraph("Saving NYSE Stocks", nyseEntries.Count, true);

                // Iterate the collection of NYSE objects
                foreach (NYSE entry in nyseEntries)
                {
                    // Check for symbols like carot or slashes
                    bool doesStockContainSymbol = DoesStockContainSymbol(entry.Symbol);

                    // if the value for doesStockContainSymbol is false
                    if (!doesStockContainSymbol)
                    {
                        // We have to determine if this stock is in the list
                        Stock tempStock = Gateway.FindStockBySymbol(entry.Symbol);

                        // If the tempStock object does not exist
                        if (NullHelper.IsNull(tempStock))
                        {
                            // Create a new instance of a 'Stock' object.
                            Stock stock = new Stock();

                            // set the properties of the stock object
                            stock.IPOYear = entry.IPOYear;
                            stock.LastClose = 0;
                            stock.Track = true;
                            stock.AverageDailyVolume = 0;
                            stock.Exchange = "NYSE";
                            stock.Industry = entry.Industry;
                            stock.Sector = entry.Sector;
                            stock.Streak = 0;
                            stock.Symbol = entry.Symbol;
                            stock.Name = entry.Name;

                            // perform the stock
                            saved = Gateway.SaveStock(ref stock);
                        }
                    }

                    // Increment the value for Graph
                    Graph.Value++;
                }
            }

            // Setup Graph
            SetupGraph("Finished", 0, false);
        }
        #endregion

        #region ProcessFilesButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'ProcessFilesButton' is clicked.
        /// </summary>
        private void ProcessFilesButton_Click(object sender, EventArgs e)
        {
            // use this delimiter
            char[] delimiter = { ',' };

            // Remove focus from this buttton
            HiddenButton.Focus();

            // locals
            int count = 0;
            bool saved = false;
            ContinueTypeEnum continueType = ContinueTypeEnum.Even;
            StockStreak streak = null;

            // <ticker>,<per>,<date>,<open>,<high>,<low>,<close>,<vol>

            // if the Directory Exists
            if (Directory.Exists(DocumentsFolder))
            {
                // get the files in the directory
                List<string> files = FileHelper.GetFiles(DocumentsFolder, ".txt", false);

                // If the files collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(files))
                {
                    // Convert the files to StockFile
                    List<StockFile> stockFiles = ConvertFilesToStockFiles(files);

                    // Setup the graph
                    SetupGraph("Processing Files In Documents Folder", stockFiles.Count, true);

                    // Iterate the collection of string objects
                    foreach (StockFile file in stockFiles)
                    {
                        try
                        {
                            // Get the textLines from this file
                            List<TextLine> lines = TextHelper.GetTextLinesFromFile(file.Path, true, delimiter);

                            // If the lines collection exists and has one or more items
                            if (ListHelper.HasOneOrMoreItems(lines))
                            {
                                // reset
                                count = 0;
                                StockDayProcessed = false;

                                // Iterate the collection of TextLine objects
                                foreach (TextLine line in lines)
                                {
                                    // Increment the value for count
                                    count++;

                                    // skip the header row
                                    if (count > 1)
                                    {
                                        // reset
                                        continueType = ContinueTypeEnum.Even;

                                        // if the words exist and have exactly 8 words
                                        if ((line.HasWords) && (line.Words.Count == 8))
                                        {
                                            // Create a new instance of a 'DailyPriceData' object.
                                            DailyPriceData data = new DailyPriceData();

                                            // Set the properties for this DailyPriceData
                                            data.Symbol = line.Words[0].Text;
                                            data.StockDate = DateHelper.ParseEightDigitDate(line.Words[2].Text);
                                            data.OpenPrice = NumericHelper.ParseDouble(line.Words[3].Text, 0, 0);
                                            data.HighPrice = NumericHelper.ParseDouble(line.Words[4].Text, 0, 0);
                                            data.LowPrice = NumericHelper.ParseDouble(line.Words[5].Text, 0, 0);
                                            data.ClosePrice = NumericHelper.ParseDouble(line.Words[6].Text, 0, 0);
                                            data.Volume = NumericHelper.ParseInteger(line.Words[7].Text, 0, 0);
                                            data.Spread = Math.Round(data.HighPrice - data.LowPrice, 2);
                                            data.SpreadScore = Math.Round(data.ClosePrice - data.LowPrice, 2);

                                            // find this stock
                                            Stock stock = Gateway.FindStockBySymbol(data.Symbol);

                                            // if this stock should be tracked
                                            if ((NullHelper.Exists(stock)) && (stock.Track))
                                            {
                                                // set the current date
                                                if (!StockDayProcessed)
                                                {
                                                    // process the stock day entry
                                                    ProcessStockDay(stock, data.StockDate);
                                                }

                                                // Find the most recent DailyPriceData
                                                DailyPriceData previous = Gateway.FindDailyPriceDataBySymbolAndMostRecent(true, data.Symbol);

                                                // If the previous object exists
                                                if (NullHelper.Exists(previous))
                                                {
                                                    // no longer the most recent
                                                    previous.MostRecent = false;

                                                    // update the database
                                                    saved = Gateway.SaveDailyPriceData(ref previous);
                                                }

                                                // Set this as the most recent
                                                data.MostRecent = true;

                                                if (data.HighPrice == data.ClosePrice)
                                                {
                                                    // if it closes at the high
                                                    data.CloseScore = 100;
                                                }
                                                else if (data.LowPrice == data.ClosePrice)
                                                {
                                                    // if it closes at the low
                                                    data.CloseScore = 0;
                                                }
                                                // if the Spread is set
                                                else if ((data.Spread > 0) && (data.SpreadScore > 0))
                                                {
                                                    // Set the SpreadScore
                                                    data.CloseScore = 100 / data.Spread * data.SpreadScore;
                                                }

                                                // round to 2 digits
                                                data.CloseScore = Math.Round(data.CloseScore, 2);

                                                // If the stock object exists
                                                if (NullHelper.Exists(stock))
                                                {
                                                    // if Track is true
                                                    if (stock.Track)
                                                    {
                                                        // if less than 100,000 shares, or whatever value Admin.MinVolume is set to.
                                                        // And this is the 3rd day in a row below the MinVolume
                                                        if ((data.Volume < MinVolume) && (stock.DaysBelowMinVolume > 2))
                                                        {
                                                            // set this to false
                                                            stock.Track = false;

                                                            // perform the save
                                                            saved = Gateway.SaveStock(ref stock);

                                                            // Adding to a new table DoNotTrack
                                                            DoNotTrack doNotTrack = Gateway.FindDoNotTrackBySymbol(stock.Symbol);

                                                            // if the stock is not already in DoNotTrack
                                                            if (NullHelper.IsNull(doNotTrack))
                                                            {
                                                                // Create a new instance of a 'DoNotTrack' object.
                                                                doNotTrack = new DoNotTrack();

                                                                // Set the Symbol
                                                                doNotTrack.Symbol = stock.Symbol;

                                                                // perform the Save
                                                                saved = Gateway.SaveDoNotTrack(ref doNotTrack);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            // if the Volume greater than MinVolume
                                                            if (data.Volume < MinVolume)
                                                            {
                                                                // increment the value for DaysBelowMinVolume
                                                                stock.DaysBelowMinVolume++;
                                                            }
                                                            else
                                                            {
                                                                // reset the value for DaysBelowMinVolume
                                                                stock.DaysBelowMinVolume = 0;
                                                            }

                                                            // if the LastClose has been set
                                                            if (stock.LastClose > 0)
                                                            {
                                                                // set the percent change                                                                
                                                                data.PercentChange = SetDailyPriceDataPercentChange(stock.LastClose, data.ClosePrice);
                                                            }

                                                            // if the price went up
                                                            if ((stock.LastClose < data.ClosePrice) && (stock.LastClose > 0))
                                                            {
                                                                // the price went up

                                                                // if on a winning streak
                                                                if (stock.Streak > 0)
                                                                {
                                                                    // still on a streak
                                                                    continueType = ContinueTypeEnum.ContinueStreakAdvancing;

                                                                    // continue the streak                                                            
                                                                    stock.Streak++;
                                                                }
                                                                else
                                                                {
                                                                    // set to NewStreakAdvancing
                                                                    continueType = ContinueTypeEnum.NewStreakAdvancing;

                                                                    // reset to 1
                                                                    stock.Streak = 1;
                                                                }
                                                            }
                                                            else if (stock.LastClose > data.ClosePrice)
                                                            {
                                                                // the price went down

                                                                // if on a losing streak
                                                                if (stock.Streak < 0)
                                                                {
                                                                    // continue the streak
                                                                    continueType = ContinueTypeEnum.ContinueStreakDeclining;

                                                                    // continue the streak                                                            
                                                                    stock.Streak--;
                                                                }
                                                                else
                                                                {
                                                                    // set to false
                                                                    continueType = ContinueTypeEnum.NewStreakDeclining;

                                                                    // reset to -1
                                                                    stock.Streak = -1;
                                                                }
                                                            }
                                                            else if (stock.LastClose == data.ClosePrice)
                                                            {
                                                                // Set to Even
                                                                continueType = ContinueTypeEnum.Even;

                                                                // The price did not change (needed to set IndustryScore and SectorScore
                                                                data.PriceUnchanged = true;
                                                            }
                                                            else if (stock.LastClose == 0)
                                                            {
                                                                // only the first time

                                                                // set to NewStreakAdvancing
                                                                continueType = ContinueTypeEnum.NewStreakAdvancing;

                                                                // reset to 1
                                                                stock.Streak = 1;
                                                            }

                                                            // find the current streak for this stock
                                                            streak = Gateway.FindStockStreakByStockIdAndCurrentStreak(true, stock.Id);

                                                            // if the streak exists
                                                            if (NullHelper.Exists(streak))
                                                            {
                                                                // if the streak is continueing advancing, continueing declining or even. 
                                                                if ((continueType == ContinueTypeEnum.ContinueStreakAdvancing) || (continueType == ContinueTypeEnum.ContinueStreakDeclining) || (continueType == ContinueTypeEnum.Even))
                                                                {
                                                                    // continue the streak
                                                                    streak.StreakDays = stock.Streak;

                                                                    // Set the StreakEndDate, in case it ends
                                                                    streak.StreakEndDate = data.StockDate;
                                                                    streak.StreakEndPrice = data.ClosePrice;

                                                                    // Set the PercentChange
                                                                    streak.PercentChange = SetStreakPercentChange(streak);
                                                                }
                                                                else
                                                                {
                                                                    // close the old streak and start a new oone

                                                                    // no longer the current
                                                                    streak.CurrentStreak = false;

                                                                    // Set the percent change
                                                                    streak.PercentChange = SetStreakPercentChange(streak);

                                                                    // Save this stock streak
                                                                    saved = Gateway.SaveStockStreak(ref streak);

                                                                    // create a new streak
                                                                    streak = new StockStreak();

                                                                    // Start a new streak
                                                                    streak.StreakStartDate = data.StockDate;
                                                                    streak.StreakEndDate = data.StockDate;
                                                                    streak.StockId = stock.Id;
                                                                    streak.CurrentStreak = true;
                                                                    streak.StreakStartPrice = stock.LastClose;
                                                                    streak.StreakEndPrice = data.ClosePrice;

                                                                    // if this is a streak going up
                                                                    if (stock.Streak > 0)
                                                                    {
                                                                        // This is a winning streak
                                                                        streak.StreakType = StreakTypeEnum.PriceIncreasing;
                                                                    }
                                                                    else
                                                                    {
                                                                        // This is a losing streak
                                                                        streak.StreakType = StreakTypeEnum.PriceDecreasing;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                // start a new streak

                                                                // create the streak
                                                                streak = new StockStreak();

                                                                // Start a new streak
                                                                streak.StreakStartDate = data.StockDate;
                                                                streak.StreakEndDate = data.StockDate;
                                                                streak.StockId = stock.Id;
                                                                streak.CurrentStreak = true;
                                                                streak.StreakStartPrice = data.OpenPrice;
                                                                streak.StreakEndPrice = data.ClosePrice;

                                                                // if this is a streak going up
                                                                if (stock.Streak > 0)
                                                                {
                                                                    // This is a winning streak
                                                                    streak.StreakType = StreakTypeEnum.PriceIncreasing;
                                                                }
                                                                else if (stock.Streak < 0)
                                                                {
                                                                    // This is a losing streak
                                                                    streak.StreakType = StreakTypeEnum.PriceDecreasing;
                                                                }
                                                            }

                                                            // Set the streak from the stock
                                                            data.Streak = stock.Streak;

                                                            // Set the LastClose at the stock level
                                                            stock.LastClose = data.ClosePrice;

                                                            // perform the save
                                                            saved = Gateway.SaveDailyPriceData(ref data);

                                                            // Set the AverageDailyVolume (in 1,000's)
                                                            stock.AverageDailyVolume = SetAverageDailyVolume(data.Symbol);

                                                            // Get a comparision of the average volume for the last 50 trading days vs this day's volume
                                                            if (stock.AverageDailyVolume > 0)
                                                            {
                                                                decimal oneHundred = 100;
                                                                decimal averageDailyVolume = stock.AverageDailyVolume;
                                                                decimal temp = oneHundred / averageDailyVolume;
                                                                decimal temp2 = Math.Round(temp * data.Volume, 2);
                                                                decimal volumeScore = temp2 - oneHundred;
                                                                data.VolumeScore = (double)volumeScore;
                                                            }

                                                            // perform the save again now that VolumeScore is set
                                                            saved = Gateway.SaveDailyPriceData(ref data);

                                                            // Save the Stock
                                                            saved = Gateway.SaveStock(ref stock);

                                                            // Set the StreakDays
                                                            streak.StreakDays = stock.Streak;

                                                            // since this is a new streak,
                                                            streak.PercentChange = SetStreakPercentChange(streak);

                                                            // Save the stockStreak
                                                            saved = Gateway.SaveStockStreak(ref streak);

                                                            // I am leaving this here, to show you how to get the last exception.
                                                            // I had dropped a column from StockStreak and forgot to execute
                                                            // the stored procedures when I rebuilt with DataTier.Net. This 
                                                            // Showed me the error.

                                                            // if not saved
                                                            if (!saved)
                                                            {
                                                                // Get the last error
                                                                Exception error = Gateway.GetLastException();

                                                                // If the error object exists
                                                                if (NullHelper.Exists(error))
                                                                {
                                                                    // set the error
                                                                    string err = error.ToString();
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            // increment the graph
                            Graph.Value++;

                            // only update the RecommendationLog every other file
                            if (Graph.Value % 2 == 0)
                            {
                                // 9.21.2023 Adding RecommendationLog
                                List<RecommendationView> recommendationView = Gateway.LoadRecommendationViews();

                                // If the recommendationView collection exists and has one or more items
                                if (ListHelper.HasOneOrMoreItems(recommendationView))
                                {
                                    // Iterate the collection of RecommendationView objects
                                    foreach (RecommendationView recommendation in recommendationView)
                                    {
                                        // Create a new instance of a 'RecommendationLog' object.
                                        RecommendationLog log = new RecommendationLog();

                                        // store each property
                                        log.Score = recommendation.Score;
                                        log.StockName = recommendation.StockName;
                                        log.Symbol = recommendation.Symbol;
                                        log.StockDate = recommendation.StockDate;
                                        log.LastClose = recommendation.LastClose;
                                        log.CloseScore = recommendation.CloseScore;
                                        log.VolumeScore = recommendation.VolumeScore;
                                        log.Streak = recommendation.Streak;
                                        log.LastPercentChange = recommendation.LastPercentChange;
                                        log.StreakPercentChange = recommendation.StreakPercentChange;
                                        log.Industry = recommendation.Industry;
                                        log.IndustryScore = recommendation.IndustryScore;
                                        log.IndustryStreak = recommendation.IndustryStreak;
                                        log.Sector = recommendation.Sector;
                                        log.SectorScore = recommendation.SectorScore;
                                        log.SectorStreak = recommendation.SectorStreak;

                                        // Store
                                        saved = Gateway.SaveRecommendationLog(ref log);
                                    }
                                }
                            }

                            // Create a new instance of a 'FileInfo' object.
                            FileInfo fileInfo = new FileInfo(file.Path);

                            // set the destinationPath
                            string destinationPath = Path.Combine(ProcessedFolder, fileInfo.Name);

                            // move the file to the processed folder
                            File.Move(file.Path, destinationPath);

                            // Update everything
                            Refresh();
                            Application.DoEvents();
                        }
                        catch (Exception error)
                        {
                            // for debugging only
                            DebugHelper.WriteDebugError("ProcessFilesButton_Click", "MainForm.cs", error);
                        }
                    }

                    // Now Process Industries & Sectors
                    List<StockDay> stockDays = Gateway.LoadStockDaysThatNeedsProcessing(false, false);

                    // If the stockDays collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(stockDays))
                    {
                        // Setup the graph for Industries
                        SetupGraph("Updating Industries", stockDays.Count, true);

                        // Iterate the collection of StockDay objects
                        foreach (StockDay stockDay in stockDays)
                        {
                            // Process the industry for this date
                            if (!stockDay.IndustryProcessed)
                            {
                                // Set the values for Advancers, Decliners. AveragePercentage and Streaks
                                UpdateIndustries(stockDay.Date);
                            }

                            // This industry has been processed
                            stockDay.IndustryProcessed = true;

                            // Get a copy so this can be saved
                            StockDay clone = stockDay.Clone();

                            // perform the save
                            saved = Gateway.SaveStockDay(ref clone);

                            // Increment the value for Graph
                            Graph.Value++;
                        }
                    }

                    // Setup the graph for Sectors
                    SetupGraph("Updating Sectors", stockDays.Count, true);

                    // Iterate the collection of StockDay objects
                    foreach (StockDay stockDay in stockDays)
                    {
                        // Process the industry for this date
                        if (!stockDay.SectorProcessed)
                        {
                            // Set the values for Advancers, Decliners. AveragePercentage and Streaks
                            UpdateSectors(stockDay.Date);
                        }

                        // This industry has been processed
                        stockDay.SectorProcessed = true;

                        // Get a copy so this can be saved
                        StockDay clone = stockDay.Clone();

                        // perform the save
                        saved = Gateway.SaveStockDay(ref clone);

                        // Increment the value for Graph
                        Graph.Value++;
                    }
                }

                // Show finished
                SetupGraph("Finished", 0, false);
            }
        }
        #endregion

        #region WriteDailyReportButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'WriteDailyReportButton' is clicked.
        /// </summary>
        private void WriteDailyReportButton_Click(object sender, EventArgs e)
        {
            // remove focus from this button
            HiddenButton.Focus();

            // Create a StringBUilder
            StringBuilder sb = new StringBuilder("Good morning, today is ");
            sb.Append(DateTime.Now.ToShortDateString());
            sb.Append(". ");

            sb.Append(" My name is Lucas, and welcome to the Bubble Report.");

            MarketSummary summary = Gateway.LoadMarketSummarys().FirstOrDefault();

            // If the summary object exists
            if (NullHelper.Exists(summary))
            {
                sb.Append(" This report is for ");
                string monthName = DateHelper.GetMonthName(summary.StockDate);
                sb.Append(monthName);
                sb.Append("[Pause.2]");
                string dayText = GetDayText(summary.StockDate.Day);
                sb.Append(dayText);
                sb.Append(". ");

                double score = summary.Score;

                string summaryScore = "";

                if (score >= 75)
                {
                    // Set the summaryScore text
                    summaryScore = " Stocks were mostly up.";
                }
                else if (score >= 55)
                {
                    // Set the summaryScore text
                    summaryScore = " Advancers outnumbered decliners.";
                }
                else if (score <= 25)
                {
                    // Set the summaryScore text
                    summaryScore = " Stocks took a beating, and were mostly down.";
                }
                else if (score <= 45)
                {
                    // Set the summaryScore text
                    summaryScore = " Decliners outnumbered advancers.";
                }
                else if (NumericHelper.IsInRange(score, 50.01, 54.99))
                {
                    // Set the summaryScore text
                    summaryScore = " Stocks were about even today, with a little more advancers than decliners.";
                }
                else if (NumericHelper.IsInRange(score, 45.01, 49.99))
                {
                    // Set the summaryScore text
                    summaryScore = " Stocks were about even today, with a little more decliners than advancers.";
                }

                // Append the summary score
                sb.Append(summaryScore);

                // set Summary2
                string summary2 = " [Pause.5]There were " + summary.Advancers.ToString("N0") + " advancers and " + summary.Decliners.ToString("N0") + " decliners.";

                // Append Summary2
                sb.Append(summary2);

                string summary3 = GetTopStreakStocksSummary();

                // Append Summary3
                sb.Append(summary3);

                // Set the report
                string report = sb.ToString();

                // set the report
                Clipboard.SetText(report);

                // Report Created
                MessageBox.Show("Done", "Finished");
            }
        }
        #endregion

        #endregion

        #region Methods

        #region ConvertFilesToStockFiles(List<string> files)
        /// <summary>
        /// returns a list of Files To Stock Files
        /// </summary>
        public static List<StockFile> ConvertFilesToStockFiles(List<string> files)
        {
            // initial value
            List<StockFile> stockFiles = null;

            // If the files collection exists and has one or more items
            if (ListHelper.HasOneOrMoreItems(files))
            {
                // Create a new collection of 'StockFile' objects.
                stockFiles = new List<StockFile>();

                // Iterate the collection of string objects
                foreach (string file in files)
                {
                    // Create a new instance of a 'StockFile' object.
                    StockFile stockFile = new StockFile();

                    // Create a new instance of a 'FileInfo' object.
                    FileInfo fileInfo = new FileInfo(file);

                    // Set the Name
                    stockFile.Name = fileInfo.Name;
                    stockFile.Path = file;
                    stockFile.Date = ParseDateFromFileName(stockFile.Name);

                    // Add this file
                    stockFiles.Add(stockFile);
                }

                // now sort the list
                stockFiles = stockFiles.OrderBy(x => x.Date).ToList();
            }

            // return value
            return stockFiles;
        }
        #endregion

        #region DoesStockContainSymbol(string symbol)
        /// <summary>
        /// returns the Stock Contain Symbol
        /// </summary>
        public static bool DoesStockContainSymbol(string symbol)
        {
            // initial value
            bool doesStockContainSymbol = false;

            // If the symbol string exists
            if (TextHelper.Exists(symbol))
            {
                foreach (char c in symbol)
                {
                    // set the return value
                    doesStockContainSymbol = char.IsSymbol(c);

                    // if the value for doesStockContainSymbol is true
                    if (doesStockContainSymbol)
                    {
                        // stop looking
                        break;
                    }
                }
            }

            // return value
            return doesStockContainSymbol;
        }
        #endregion

        #region GetDayText(int day)
        /// <summary>
        /// returns the Day Text
        /// </summary>
        public static string GetDayText(int day)
        {
            // initial value
            string dayText = "";

            switch (day)
            {
                case 1:

                    // set the return value
                    dayText = "first";

                    // required 
                    break;

                case 2:

                    // set the return value
                    dayText = "second";

                    // required 
                    break;

                case 3:

                    // set the return value
                    dayText = "third";

                    // required 
                    break;

                case 4:

                    // set the return value
                    dayText = "fourth";

                    // required 
                    break;

                case 5:

                    // set the return value
                    dayText = "fifth";

                    // required 
                    break;

                case 6:

                    // set the return value
                    dayText = "sixth";

                    // required 
                    break;

                case 7:

                    // set the return value
                    dayText = "seventh";

                    // required 
                    break;

                case 8:

                    // set the return value
                    dayText = "eighth";

                    // required 
                    break;

                case 9:

                    // set the return value
                    dayText = "ninth";

                    // required 
                    break;

                case 10:

                    // set the return value
                    dayText = "tenth";

                    // required 
                    break;

                case 11:

                    // set the return value
                    dayText = "eleventh";

                    // required 
                    break;

                case 12:

                    // set the return value
                    dayText = "twelfth";

                    // required 
                    break;

                case 13:

                    // set the return value
                    dayText = "thirteenth";

                    // required 
                    break;

                case 14:

                    // set the return value
                    dayText = "fourteenth";

                    // required 
                    break;

                case 15:

                    // set the return value
                    dayText = "fifteenth";

                    // required 
                    break;

                case 16:

                    // set the return value
                    dayText = "sixteenth";

                    // required 
                    break;

                case 17:

                    // set the return value
                    dayText = "seventeenth";

                    // required 
                    break;

                case 18:

                    // set the return value
                    dayText = "eighteenth";

                    // required 
                    break;

                case 19:

                    // set the return value
                    dayText = "nineteenth";

                    // required 
                    break;

                case 20:

                    // set the return value
                    dayText = "twentieth";

                    // required 
                    break;

                case 21:

                    // set the return value
                    dayText = "twenty first";

                    // required 
                    break;

                case 22:

                    // set the return value
                    dayText = "twenty second";

                    // required 
                    break;

                case 23:

                    // set the return value
                    dayText = "twenty third";

                    // required 
                    break;

                case 24:

                    // set the return value
                    dayText = "twenty fourth";

                    // required 
                    break;

                case 25:

                    // set the return value
                    dayText = "twenty fifth";

                    // required 
                    break;

                case 26:

                    // set the return value
                    dayText = "twenty sixth";

                    // required 
                    break;

                case 27:

                    // set the return value
                    dayText = "twenty seventh";

                    // required 
                    break;

                case 28:

                    // set the return value
                    dayText = "twenty eighth";

                    // required 
                    break;

                case 29:

                    // set the return value
                    dayText = "twenty nineth";

                    // required 
                    break;

                case 30:

                    // set the return value
                    dayText = "thirtieth";

                    // required 
                    break;

                case 31:

                    // set the return value
                    dayText = "thirty first";

                    // required 
                    break;
            }

            // return value
            return dayText;
        }
        #endregion

        #region GetTopStreakAStockSummary()
        /// <summary>
        /// returns the Top Streak A Stock Summary
        /// </summary>
        public string GetTopStreakStocksSummary()
        {
            // initial value
            string summary3 = "";

            // load the top streak stocks
            List<TopStreakStocks> topStreakStocks = Gateway.LoadTopStreakStocks().Take(3).ToList();

            // if there are 3 or more stocks
            if (ListHelper.HasXOrMoreItems(topStreakStocks, 3))
            {
                // set the summary3
                summary3 = "The top streak stocks are as follows. ";

                // Top Streak Stocks
                TopStreakStocks topStreakStocks1 = topStreakStocks[0];
                TopStreakStocks topStreakStocks2 = topStreakStocks[1];
                TopStreakStocks topStreakStocks3 = topStreakStocks[2];

                // set the summary3
                summary3 += "[Pause.5]The top streak stock is symbol " + topStreakStocks1.Symbol + " which has gone up for the last " + topStreakStocks1.Streak + " sessions.";

                // if tied
                if (topStreakStocks1.Streak == topStreakStocks2.Streak)
                {
                    // append the second one
                    summary3 += "[Pause.5] Tied for the top streak at " + topStreakStocks2.Streak + " gaining sessions is symbol " + topStreakStocks2.Symbol;

                    // if stopStreakStock1 and 3 also match
                    if (topStreakStocks1.Streak == topStreakStocks3.Streak)
                    {
                        // append the second one
                        summary3 += "[Pause.8] Also tied for the top streak at " + topStreakStocks2.Streak + " gaining sessions is symbol " + topStreakStocks3.Symbol;
                    }
                }
                else
                {
                    summary3 += "[Pause.8] The second highest streak at " + topStreakStocks2.Streak + " gaining sessions is symbol " + topStreakStocks2.Symbol;

                    // if the second and third are a tie.
                    if (topStreakStocks2.Streak == topStreakStocks3.Streak)
                    {
                        // if a tie for second
                        summary3 += "[Pause.8] Tied for the second highest streak of " + topStreakStocks2.Streak + " gaining sessions is symbol " + topStreakStocks3.Symbol;
                    }
                    else
                    {
                        // if a tie for second
                        summary3 += "[Pause.8] And for the third highest streak of " + topStreakStocks2.Streak + " gaining sessions is symbol " + topStreakStocks3.Symbol;
                    }
                }
            }

            // return value
            return summary3;
        }
        #endregion

        #region Init()
        /// <summary>
        ///  This method performs initializations for this object.
        /// </summary>
        public void Init()
        {
            // Create a new instance of a 'Gateway' object.
            Gateway = new Gateway(Connection.Name);

            // Load the Admin
            Admin = Gateway.LoadAdmins().FirstOrDefault();
        }
        #endregion

        #region ParseDateFromFileName(string fileName)
        /// <summary>
        /// returns the Date From File Name
        /// </summary>
        public static DateTime ParseDateFromFileName(string fileName)
        {
            // initial value
            DateTime date = new DateTime();

            // If the fileName string exists
            if (TextHelper.Exists(fileName))
            {
                // get the fileName without the extension
                string temp = FileHelper.GetFileNameWithoutExtension(fileName);

                // get the index of the underscore
                int index = temp.IndexOf('_');

                // if the index was found
                if (index >= 0)
                {
                    // Get the date portion of the fileName
                    string temp2 = temp.Substring(index + 1);

                    // parse the date
                    date = DateHelper.ParseEightDigitDate(temp2);
                }
            }

            // return value
            return date;
        }
        #endregion

        #region ProcessStockDay()
        /// <summary>
        /// Process Stock Day
        /// </summary>
        public void ProcessStockDay(Stock stock, DateTime currentDate)
        {
            // if the stock exists and this is the first stock for this date (NASDAQ is before NYSE).                                                )
            if (stock.Exchange == "NASDAQ")
            {
                // Create a new instance of a 'StockDay' object.
                StockDay stockDay = new StockDay();

                // Set the properties
                stockDay.Date = currentDate;
                stockDay.IndustryProcessed = false;
                stockDay.SectorProcessed = false;

                // Save this value
                bool saved = Gateway.SaveStockDay(ref stockDay);

                // if the value for saved is true
                if (saved)
                {
                    // stockDay has been processed
                    StockDayProcessed = true;
                }
            }
            else
            {
                // stockDay has been processed
                StockDayProcessed = true;
            }
        }
        #endregion

        #region SaveWorksheetCallback(SaveWorksheetResponse resonse)
        /// <summary>
        /// Save Worksheet Callback
        /// </summary>
        public void SaveWorksheetCallback(SaveWorksheetResponse response)
        {
            // If the response object exists
            if (NullHelper.Exists(response))
            {
                // Update the graph
                Graph.Value = response.RowsSaved;
                StatusLabel.Text = "Saved " + response.CurrentRowNumber + " of " + response.TotalRows;

                // update the UI
                Refresh();
                Application.DoEvents();
            }
        }
        #endregion

        #region SetAverageDailyVolume(string symbol)
        /// <summary>
        /// returns the Average Daily Volume
        /// </summary>
        public int SetAverageDailyVolume(string symbol)
        {
            // initial value
            int averageDailyVolume = 0;

            // local
            int sumVolume = 0;

            try
            {
                // Load the daily price data
                List<DailyPriceData> dailyPriceData = Gateway.LoadDailyPriceDatasForSymbol(symbol);

                // If the dailyPriceData collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(dailyPriceData))
                {
                    // Iterate the collection of DailyPriceData objects
                    foreach (DailyPriceData data in dailyPriceData)
                    {
                        // Take the value for volume, and multiply by .001 so the number is smal
                        sumVolume += (int)(data.Volume * .001);
                    }

                    // temp value
                    double temp = sumVolume / dailyPriceData.Count;

                    // Set the AverageDailyVolume
                    averageDailyVolume = (int)temp;

                    // now put back the three digits
                    averageDailyVolume = averageDailyVolume * 1000;
                }
            }
            catch (Exception error)
            {
                // for debugging only
                DebugHelper.WriteDebugError("SetAverageDailyVolume", "MainForm", error);
            }

            // return value
            return averageDailyVolume;
        }
        #endregion

        #region SetDailyPriceDataPercentChange(double prevClosePrice, double closePrice)
        /// <summary>
        /// returns the Daily Price Data Percent Change
        /// </summary>
        public static double SetDailyPriceDataPercentChange(double prevClosePrice, double closePrice)
        {
            // initial value
            double percentChange = 0;

            try
            {
                // Needs to be a decimal also
                Decimal oneHundred = 100;

                // cast the values as Decimal
                Decimal closePrice2 = (Decimal)closePrice;
                Decimal prevClosePrice2 = (Decimal)prevClosePrice;

                // Get the value as a Decimal
                Decimal percentChangeDecimal = oneHundred / prevClosePrice2 * closePrice2 - oneHundred;
                percentChange = (double)percentChangeDecimal;

                // Round to two decimal places
                percentChange = Math.Round(percentChange, 2);
            }
            catch (Exception error)
            {
                // for debugging only for now
                DebugHelper.WriteDebugError("SetDailyPriceDataPercentChange", "MainForm.cs", error);
            }

            // return value
            return percentChange;
        }
        #endregion

        #region SetIndustryAveragePercentChange()
        /// <summary>
        /// returns the Industry Average Percent Change
        /// </summary>
        public static double SetIndustryAveragePercentChange(List<IndustryView> industryViews)
        {
            // initial value
            double industryAveragePercentChange = 0;

            // If the industryViews collection exists and has one or more items
            if (ListHelper.HasOneOrMoreItems(industryViews))
            {
                // reload
                industryViews = industryViews.Where(x => x.Track == true).ToList();

                // cast the percentChange total as a decimal so divisiion works
                decimal totalPercentChange = (decimal)industryViews.Where(x => x.Track == true).Sum(x => x.PercentChange);
                decimal numberStocks = (decimal)industryViews.Where(x => x.Track == true).Count();
                decimal averagePercentChange = totalPercentChange / numberStocks;

                // if the number of stocks has been set
                if ((numberStocks > 0) && (averagePercentChange > 0))
                {
                    averagePercentChange = Math.Round(averagePercentChange, 2);
                    industryAveragePercentChange = (double)averagePercentChange;
                }
            }

            // return value
            return industryAveragePercentChange;
        }
        #endregion

        #region SetSectorAveragePercentChange()
        /// <summary>
        /// returns the Sector Average Percent Change
        /// </summary>
        public static double SetSectorAveragePercentChange(List<SectorView> sectorViews)
        {
            // initial value
            double sectorAveragePercentChange = 0;

            // If the sectorViews collection exists and has one or more items
            if (ListHelper.HasOneOrMoreItems(sectorViews))
            {
                // reload
                sectorViews = sectorViews.Where(x => x.Track == true).ToList();

                // cast the percentChange total as a decimal so divisiion works
                decimal totalPercentChange = (decimal)sectorViews.Where(x => x.Track == true).Sum(x => x.PercentChange);
                decimal numberStocks = (decimal)sectorViews.Where(x => x.Track == true).Count();
                decimal averagePercentChange = totalPercentChange / numberStocks;

                // if the number of stocks has been set
                if ((numberStocks > 0) && (averagePercentChange > 0))
                {
                    averagePercentChange = Math.Round(averagePercentChange, 2);
                    sectorAveragePercentChange = (double)averagePercentChange;
                }
            }

            // return value
            return sectorAveragePercentChange;
        }
        #endregion

        #region SetStreakPercentChange(StockStreak currentStreak)
        /// <summary>
        /// returns the Streak Percent Change
        /// </summary>
        public static double SetStreakPercentChange(StockStreak streak)
        {
            // initial value
            double streakPercentChange = 0;

            // If the currentStreak object exists
            if (NullHelper.Exists(streak))
            {
                // get the values needed
                decimal streakStartPrice = (decimal)streak.StreakStartPrice;
                decimal currentStreakEndPrice = (decimal)streak.StreakEndPrice;
                decimal oneHundred = 100;

                // if the prevStreakClosePrice is set
                if (streakStartPrice > 0)
                {
                    // Set the percentChange
                    decimal returnValue = Math.Round(oneHundred / streakStartPrice * currentStreakEndPrice, 2) - 100;
                    streakPercentChange = (double)returnValue;
                }
            }

            // return value
            return streakPercentChange;
        }
        #endregion

        #region SetupGraph()
        /// <summary>
        /// Setup Graph
        /// </summary>
        public void SetupGraph(string statusText, int graphMaxium, bool showGraph)
        {
            // Show or hide
            StatusLabel.Text = statusText;
            StatusLabel.Visible = true;
            Graph.Maximum = graphMaxium;
            Graph.Visible = showGraph;
            Graph.Value = 0;

            // refresh everything
            Refresh();
            Application.DoEvents();
        }
        #endregion

        #region UpdateIndustries(DateTime stockDate)
        /// <summary>
        /// Update Industries
        /// </summary>
        public void UpdateIndustries(DateTime stockDate)
        {
            // load aall the industries
            List<ObjectLibrary.BusinessObjects.Industry> industries = Gateway.LoadIndustrys();

            // local
            bool saved = false;

            // If the industries collection exists and has one or more items
            if (ListHelper.HasOneOrMoreItems(industries))
            {
                // iterate the industries
                foreach (ObjectLibrary.BusinessObjects.Industry industry in industries)
                {
                    // if there is data
                    if ((industry.Advancers > 0) || (industry.Decliners > 0))
                    {
                        // save the history entry
                        IndustryHistory history = new IndustryHistory();

                        // Store the current industry values as history
                        history.Advancers = industry.Advancers;
                        history.IndustryId = industry.Id;
                        history.AveragePercentChange = industry.AveragePercentChange;
                        history.Date = industry.LastUpdated;
                        history.Decliners = industry.Decliners;
                        history.Score = industry.Score;
                        history.Streak = industry.Streak;

                        // Save the history
                        saved = Gateway.SaveIndustryHistory(ref history);
                    }

                    // Now update the Industry object
                    List<IndustryView> industryViews = Gateway.LoadIndustryViewsForIndustryAndStockDate(industry.Name, stockDate);

                    // If the industryViews collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(industryViews))
                    {
                        // reset
                        industry.Advancers = 0;
                        industry.Decliners = 0;

                        // Get the count of IndustryViews that the price did not change (so advancers and decliners has the right values


                        // if there are one or more items
                        foreach (IndustryView view in industryViews)
                        {
                            if ((view.Streak > 0) && (!view.PriceUnchanged))
                            {
                                // Increment the value for industry
                                industry.Advancers++;
                            }
                            else if ((view.Streak < 0) && (!view.PriceUnchanged))
                            {
                                // Increment the value for industry
                                industry.Decliners++;
                            }

                            // Set the LastUpdated
                            industry.LastUpdated = stockDate;
                        }

                        // if there are more advancers
                        if (industry.Advancers > industry.Decliners)
                        {
                            // if the streak is continueing
                            if (industry.Streak > 0)
                            {
                                // Increment the value for industry
                                industry.Streak++;
                            }
                            else
                            {
                                // start a new streak
                                industry.Streak = 1;
                            }
                        }
                        else if (industry.Decliners > industry.Advancers)
                        {
                            // if the streak is continueing
                            if (industry.Streak < 0)
                            {
                                // Increment the value for industry
                                industry.Streak--;
                            }
                            else
                            {
                                // start a new streak
                                industry.Streak = -1;
                            }
                        }

                        // Set the number of stocks
                        industry.NumberStocks = industryViews.Where(x => x.Track == true).Count();

                        // Set the Score
                        if (industry.NumberStocks > 0)
                        {
                            // if numbers match exactly
                            if (industry.Advancers == industry.Decliners)
                            {
                                // break point only
                                industry.Score = 50.0;
                            }
                            else if (industry.Advancers == industry.NumberStocks)
                            {
                                // if all advance
                                industry.Score = 100.0;
                            }
                            else if (industry.Advancers == 0)
                            {
                                // All declined is 0
                                industry.Score = 0;
                            }
                            else
                            {
                                // Set the Score
                                industry.Score = NumericHelper.DivideDoublesAsDecimals(100, industry.NumberStocks, 2) * industry.Advancers;
                            }

                            // Set the AveragePercentChange
                            industry.AveragePercentChange = SetIndustryAveragePercentChange(industryViews);
                            industry.AveragePercentChange = Math.Round(industry.AveragePercentChange, 2);

                            // Set the LastUpdated
                            industry.LastUpdated = stockDate;

                            // Perform a clone
                            ObjectLibrary.BusinessObjects.Industry clone = industry.Clone();

                            // Perform the save
                            saved = Gateway.SaveIndustry(ref clone);
                        }
                    }
                }
            }
        }
        #endregion

        #region UpdateSectors(DateTime stockDate)
        /// <summary>
        /// Update Sectors
        /// </summary>
        public void UpdateSectors(DateTime stockDate)
        {
            // load aall the industries
            List<ObjectLibrary.BusinessObjects.Sector> sectors = Gateway.LoadSectors();

            // local
            bool saved = false;

            // If the sectors collection exists and has one or more items
            if (ListHelper.HasOneOrMoreItems(sectors))
            {
                // iterate the industries
                foreach (ObjectLibrary.BusinessObjects.Sector sector in sectors)
                {
                    // if there is data
                    if ((sector.Advancers > 0) || (sector.Decliners > 0))
                    {
                        // save the history entry
                        SectorHistory history = new SectorHistory();

                        // Store the current sector values as history
                        history.Advancers = sector.Advancers;
                        history.SectorId = sector.Id;
                        history.AveragePercentChange = sector.AveragePercentChange;
                        history.Date = sector.LastUpdated;
                        history.Decliners = sector.Decliners;
                        history.Score = sector.Score;
                        history.Streak = sector.Streak;

                        // Save the history
                        saved = Gateway.SaveSectorHistory(ref history);
                    }

                    // Now update the Sector object
                    List<SectorView> sectorViews = Gateway.LoadSectorViewsForSectorAndStockDate(sector.Name, stockDate);

                    // If the sectorsViews collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(sectorViews))
                    {
                        // reset
                        sector.Advancers = 0;
                        sector.Decliners = 0;

                        // if there are one or more items
                        foreach (SectorView view in sectorViews)
                        {
                            if (view.Streak > 0)
                            {
                                // Increment the value for industry
                                sector.Advancers++;
                            }
                            else if (view.Streak < 0)
                            {
                                // Increment the value for industry
                                sector.Decliners++;
                            }

                            // Set the LastUpdated
                            sector.LastUpdated = stockDate;
                        }

                        // if there are more advancers
                        if (sector.Advancers > sector.Decliners)
                        {
                            // if the streak is continueing
                            if (sector.Streak > 0)
                            {
                                // Increment the value for sector.Streak
                                sector.Streak++;
                            }
                            else
                            {
                                // start a new streak
                                sector.Streak = 1;
                            }
                        }
                        else if (sector.Decliners > sector.Advancers)
                        {
                            // if the streak is continueing
                            if (sector.Streak < 0)
                            {
                                // Decrement the value for sector.Streak
                                sector.Streak--;
                            }
                            else
                            {
                                // start a new streak
                                sector.Streak = -1;
                            }
                        }

                        // Set the number of stocks
                        sector.NumberStocks = sectorViews.Where(x => x.Track == true).Count();

                        // Set the Score
                        if (sector.NumberStocks > 0)
                        {
                            // if numbers match exactly
                            if (sector.Advancers == sector.Decliners)
                            {
                                // break point only
                                sector.Score = 50.0;
                            }
                            else if (sector.Advancers == sector.NumberStocks)
                            {
                                // if all advance
                                sector.Score = 100.0;
                            }
                            else if (sector.Advancers == 0)
                            {
                                // All declined is 0
                                sector.Score = 0;
                            }
                            else
                            {
                                // Set the Score
                                sector.Score = NumericHelper.DivideDoublesAsDecimals(100, sector.NumberStocks, 2) * sector.Advancers;
                            }

                            // Set the AveragePercentChange
                            sector.AveragePercentChange = SetSectorAveragePercentChange(sectorViews);
                            sector.AveragePercentChange = Math.Round(sector.AveragePercentChange, 2);

                            // Set the LastUpdated
                            sector.LastUpdated = stockDate;

                            // Perform a clone
                            ObjectLibrary.BusinessObjects.Sector clone = sector.Clone();

                            // Perform the save
                            saved = Gateway.SaveSector(ref clone);
                        }
                    }
                }
            }
        }
        #endregion

        #endregion

        #region Properties

        #region Admin
        /// <summary>
        /// This property gets or sets the value for 'Admin'.
        /// </summary>
        public Admin Admin
        {
            get { return admin; }
            set { admin = value; }
        }
        #endregion

        #region DocumentsFolder
        /// <summary>
        /// This read only property returns the value of DocumentsFolder from the object Admin.
        /// </summary>
        public string DocumentsFolder
        {

            get
            {
                // initial value
                string documentsFolder = "";

                // if Admin exists
                if (Admin != null)
                {
                    // set the return value
                    documentsFolder = Admin.DocumentsFolder;
                }

                // return value
                return documentsFolder;
            }
        }
        #endregion

        #region Gateway
        /// <summary>
        /// This property gets or sets the value for 'Gateway'.
        /// </summary>
        public Gateway Gateway
        {
            get { return gateway; }
            set { gateway = value; }
        }
        #endregion

        #region HasAdmin
        /// <summary>
        /// This property returns true if this object has an 'Admin'.
        /// </summary>
        public bool HasAdmin
        {
            get
            {
                // initial value
                bool hasAdmin = (this.Admin != null);

                // return value
                return hasAdmin;
            }
        }
        #endregion

        #region HasGateway
        /// <summary>
        /// This property returns true if this object has a 'Gateway'.
        /// </summary>
        public bool HasGateway
        {
            get
            {
                // initial value
                bool hasGateway = (this.Gateway != null);

                // return value
                return hasGateway;
            }
        }
        #endregion

        #region MinVolume
        /// <summary>
        /// This read only property returns the value of MinVolume from the object Admin.
        /// </summary>
        public int MinVolume
        {

            get
            {
                // initial value
                int minVolume = 0;

                // if Admin exists
                if (Admin != null)
                {
                    // set the return value
                    minVolume = Admin.MinVolume;
                }

                // return value
                return minVolume;
            }
        }
        #endregion

        #region ProcessedFolder
        /// <summary>
        /// This read only property returns the value of ProcessedFolder from the object Admin.
        /// </summary>
        public string ProcessedFolder
        {

            get
            {
                // initial value
                string processedFolder = "";

                // if Admin exists
                if (Admin != null)
                {
                    // set the return value
                    processedFolder = Admin.ProcessedFolder;
                }

                // return value
                return processedFolder;
            }
        }
        #endregion

        #region StockDayProcessed
        /// <summary>
        /// This property gets or sets the value for 'StockDayProcessed'.
        /// </summary>
        public bool StockDayProcessed
        {
            get { return stockDayProcessed; }
            set { stockDayProcessed = value; }
        }
        #endregion

        #endregion

    }
    #endregion

}
