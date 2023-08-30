

#region using statements

using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using DataJuggler.Excelerate;
using DataJuggler.UltimateHelper;
using StockData.Objects;
using DataJuggler.UltimateHelper.Objects;
using ApplicationLogicComponent.Connection;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using DataGateway;

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
            worksheetInfo.Path = "C:\\Temp\\Industry And Sector.xlsx";

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
            worksheetInfo.Path = "C:\\Temp\\Industry And Sector.xlsx";

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

            // Create a new instance of a 'WorksheetInfo' object.
            WorksheetInfo worksheetInfo = new WorksheetInfo();

            // set the properties
            worksheetInfo.SheetName = "NASDAQ";
            worksheetInfo.LoadColumnOptions = LoadColumnOptionsEnum.LoadAllColumnsExceptExcluded;
            worksheetInfo.Path = "C:\\Projects\\GitHub\\StockData\\Documents\\Stocks\\NASDAQ.xlsx";

            // load the worksheet
            Worksheet worksheet = ExcelDataLoader.LoadWorksheet(worksheetInfo.Path, worksheetInfo);

            // Load the NASDAQ entries
            List<NASDAQ> nasdaqEntries = NASDAQ.Load(worksheet);

            // Create a new instance of a 'WorksheetInfo' object.
            WorksheetInfo worksheetInfo2 = new WorksheetInfo();

            // set the properties
            worksheetInfo2.SheetName = "NYSE";
            worksheetInfo2.LoadColumnOptions = LoadColumnOptionsEnum.LoadAllColumnsExceptExcluded;
            worksheetInfo2.Path = "C:\\Projects\\GitHub\\StockData\\Documents\\Stocks\\NYSE.xlsx";

            // load the worksheet
            Worksheet worksheet2 = ExcelDataLoader.LoadWorksheet(worksheetInfo2.Path, worksheetInfo2);

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

                    // if the value for saved is true
                    if (saved)
                    {
                        // Increment the value for Graph
                        Graph.Value++;
                    }
                }

                // Setup our graph
                SetupGraph("Saving NYSE Stocks", nyseEntries.Count, true);

                // Iterate the collection of NYSE objects
                foreach (NYSE entry in nyseEntries)
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

                    // if the value for saved is true
                    if (saved)
                    {
                        // Increment the value for Graph
                        Graph.Value++;
                    }
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
                    // Setup the graph
                    SetupGraph("Processing Files In Documents Folder", files.Count, true);

                    // Iterate the collection of string objects
                    foreach (string file in files)
                    {
                        try
                        {
                            // Get the textLines from this file
                            List<TextLine> lines = TextHelper.GetTextLinesFromFile(file, true, delimiter);

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
                                                        if (data.Volume < MinVolume)
                                                        {
                                                            // set this to false
                                                            stock.Track = false;

                                                            // perform the save
                                                            saved = Gateway.SaveStock(ref stock);
                                                        }
                                                        else
                                                        {
                                                            // if the LastClose has been set
                                                            if (stock.LastClose > 0)
                                                            {
                                                                // set the percent change                                                                
                                                                data.PercentChange = NumericHelper.DivideDoublesAsDecimals(100, stock.LastClose, 2) * data.ClosePrice - 100;
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
                                                                // Set the VolumeScore
                                                                data.VolumeScore = NumericHelper.DivideDoublesAsDecimals(100, stock.AverageDailyVolume, 2) - 100;                                                                                                                                                                                                
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

                            // Create a new instance of a 'FileInfo' object.
                            FileInfo fileInfo = new FileInfo(file);

                            // set the destinationPath
                            string destinationPath = Path.Combine(ProcessedFolder, fileInfo.Name);

                            // move the file to the processed folder
                            File.Move(file, destinationPath);

                            // increment the graph
                            Graph.Value++;

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

        #endregion

        #region Methods

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
                    averageDailyVolume = (int) temp;

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
                decimal totalPercentChange = (decimal) industryViews.Where(x => x.Track == true).Sum(x => x.PercentChange);
                decimal numberStocks = (decimal) industryViews.Where(x => x.Track == true).Count();
                decimal averagePercentChange = totalPercentChange / numberStocks;

                // if the number of stocks has been set
                if ((numberStocks > 0) && (averagePercentChange > 0))
                {
                    averagePercentChange = Math.Round(averagePercentChange, 2);
                    industryAveragePercentChange = (double) averagePercentChange;
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
                decimal totalPercentChange = (decimal) sectorViews.Where(x => x.Track == true).Sum(x => x.PercentChange);
                decimal numberStocks = (decimal) sectorViews.Where(x => x.Track == true).Count();
                decimal averagePercentChange = totalPercentChange / numberStocks;

                // if the number of stocks has been set
                if ((numberStocks > 0) && (averagePercentChange > 0))
                {
                    averagePercentChange = Math.Round(averagePercentChange, 2);
                    sectorAveragePercentChange = (double) averagePercentChange;
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
