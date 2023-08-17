

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

        #region ImportStocksButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'ImportStocksButton' is clicked.
        /// </summary>
        private void ImportStocksButton_Click(object sender, EventArgs e)
        {
            // local
            bool saved = false;

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
                        // Get the textLines from this file
                        List<TextLine> lines = TextHelper.GetTextLinesFromFile(file, true, delimiter);

                        // If the lines collection exists and has one or more items
                        if (ListHelper.HasOneOrMoreItems(lines))
                        {
                            // reset
                            count = 0;

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

                                        // if the Spread is set
                                        if ((data.Spread > 0) && (data.SpreadScore > 0))
                                        {
                                            // Set the SpreadScore
                                            data.CloseScore = 100 / data.Spread * data.SpreadScore;
                                        }
                                        else if (data.HighPrice == data.ClosePrice)
                                        {
                                            // if it closes at the high
                                            data.CloseScore = 100;
                                        }
                                        else if (data.LowPrice == data.ClosePrice)
                                        {
                                            // if it closes at the low
                                            data.CloseScore = 0;
                                        }

                                        // round to 2 digits
                                        data.CloseScore = Math.Round(data.CloseScore, 2);

                                        // find this stock
                                        Stock stock = Gateway.FindStockBySymbol(data.Symbol);

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
                                                    else if (stock.LastClose == 0)
                                                    {
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
                                                        // if the streak is continueing
                                                        if (continueType == ContinueTypeEnum.ContinueStreakAdvancing)
                                                        {
                                                            // continue the streak
                                                            streak.StreakDays = stock.Streak;

                                                            // Set the StreakEndDate, in case it ends
                                                            streak.StreakEndDate = data.StockDate;
                                                            streak.StreakEndPrice = data.ClosePrice;
                                                        }
                                                        else if (continueType == ContinueTypeEnum.ContinueStreakDeclining)
                                                        {
                                                            // continue the streak
                                                            streak.StreakDays = stock.Streak;

                                                            // Set the StreakEndDate, in case it ends
                                                            streak.StreakEndDate = data.StockDate;
                                                            streak.StreakEndPrice = data.ClosePrice;
                                                        }
                                                        else
                                                        {
                                                            // close the old streak and start a new oone

                                                            // no longer the current
                                                            streak.CurrentStreak = false;

                                                            // Save this stock streak
                                                            saved = Gateway.SaveStockStreak(ref streak);

                                                            // create a new streak
                                                            streak = new StockStreak();

                                                            // Start a new streak
                                                            streak.StreakStartDate = data.StockDate;
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

                                                    // perform the save
                                                    saved = Gateway.SaveDailyPriceData(ref data);

                                                    // Set the LastClose at the stock level
                                                    stock.LastClose = data.ClosePrice;

                                                    // Set the AverageDailyVolume (in 1,000's)
                                                    stock.AverageDailyVolume = SetAverageDailyVolume(data.Symbol);
                                                    
                                                    // Save the Stock
                                                    saved = Gateway.SaveStock(ref stock);

                                                    // Set the StreakDays
                                                    streak.StreakDays = stock.Streak;

                                                    // Save the stockStreak
                                                    saved = Gateway.SaveStockStreak(ref streak);

                                                    // I am leaving this here, to show you how to get the last exception.
                                                    // I had dropped a column from StockStreak and forgot to execute
                                                    // the stored procedures when I rebuilt with DataTier.Net. This method
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

                        // Create a new instance of a 'FileInfo' object.
                        FileInfo fileInfo = new FileInfo(file);

                        // set the destinationPath
                        string destinationPath = Path.Combine(ProcessedFolder, fileInfo.Name);

                        // move the file to the processed folder
                        File.Move(file, destinationPath);

                        // increment the graph
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
                        sumVolume += (int) (data.Volume * .001);
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

        #endregion
    }
    #endregion

}
