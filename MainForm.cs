

#region using statements

using DataJuggler.Win.Controls;
using DataJuggler.Win.Controls.Interfaces;
using DataJuggler.Excelerate;
using DataJuggler.UltimateHelper;
using StockData.Objects;
using DataJuggler.UltimateHelper.Objects;
using ApplicationLogicComponent.Connection;
using ObjectLibrary.BusinessObjects;
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
                        // reset
                        count = 0;

                        // Get the textLines from this file
                        List<TextLine> lines = TextHelper.GetTextLinesFromFile(file, true, delimiter);

                        // If the lines collection exists and has one or more items
                        if (ListHelper.HasOneOrMoreItems(lines))
                        {
                            // Iterate the collection of TextLine objects
                            foreach (TextLine line in lines)
                            {
                                // Increment the value for count
                                count++;

                                // skip the header row
                                if (count > 1)
                                {
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

                                        // find this stock
                                        Stock stock = Gateway.FindStockBySymbol(data.Symbol);

                                        // If the stock object exists
                                        if (NullHelper.Exists(stock))
                                        {
                                            // if Track is true
                                            if (stock.Track)
                                            {
                                                // if less than 100,000 shares
                                                if (data.Volume < MinVolume)
                                                {
                                                    // set this to false
                                                    stock.Track = false;

                                                    // perform the save
                                                    saved = Gateway.SaveStock(ref stock);
                                                }
                                                else
                                                {
                                                    // if the price went down
                                                    if (stock.LastClose < data.ClosePrice)
                                                    {
                                                        
                                                    }
                                                    else if (stock.LastClose > data.ClosePrice)
                                                    {
                                                        
                                                    }

                                                    // perform the save
                                                    saved = Gateway.SaveDailyPriceData(ref data);
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
