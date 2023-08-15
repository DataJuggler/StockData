
#region using statements

using ApplicationLogicComponent.Controllers;
using ApplicationLogicComponent.DataOperations;
using DataAccessComponent.DataManager;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

#endregion

namespace DataGateway
{

    #region class Gateway
    /// <summary>
    /// This class is used to manage DataOperations
    /// between the client and the DataAccessComponent.
    /// Do not change the method name or the parameters for the
    /// code generated methods or they will be recreated the next 
    /// time you code generate with DataTier.Net. If you need additional
    /// parameters passed to a method either create an override or
    /// add or set properties to the temp object that is passed in.
    /// </summary>
    public class Gateway
    {

        #region Private Variables
        private ApplicationController appController;
        private string connectionName;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a Gateway object.
        /// </summary>
        public Gateway(string connectionName = "")
        {
            // store the ConnectionName
            this.ConnectionName = connectionName;

            // Perform Initializations for this object
            Init();
        }
        #endregion

        #region Methods
        
            #region DeleteAdmin(int id, Admin tempAdmin = null)
            /// <summary>
            /// This method is used to delete Admin objects.
            /// </summary>
            /// <param name="id">Delete the Admin with this id</param>
            /// <param name="tempAdmin">Pass in a tempAdmin to perform a custom delete.</param>
            public bool DeleteAdmin(int id, Admin tempAdmin = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempAdmin does not exist
                    if (tempAdmin == null)
                    {
                        // create a temp Admin
                        tempAdmin = new Admin();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempAdmin.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.AdminController.Delete(tempAdmin);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteDailyPriceData(int id, DailyPriceData tempDailyPriceData = null)
            /// <summary>
            /// This method is used to delete DailyPriceData objects.
            /// </summary>
            /// <param name="id">Delete the DailyPriceData with this id</param>
            /// <param name="tempDailyPriceData">Pass in a tempDailyPriceData to perform a custom delete.</param>
            public bool DeleteDailyPriceData(int id, DailyPriceData tempDailyPriceData = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempDailyPriceData does not exist
                    if (tempDailyPriceData == null)
                    {
                        // create a temp DailyPriceData
                        tempDailyPriceData = new DailyPriceData();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempDailyPriceData.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.DailyPriceDataController.Delete(tempDailyPriceData);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteStock(int id, Stock tempStock = null)
            /// <summary>
            /// This method is used to delete Stock objects.
            /// </summary>
            /// <param name="id">Delete the Stock with this id</param>
            /// <param name="tempStock">Pass in a tempStock to perform a custom delete.</param>
            public bool DeleteStock(int id, Stock tempStock = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempStock does not exist
                    if (tempStock == null)
                    {
                        // create a temp Stock
                        tempStock = new Stock();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempStock.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.StockController.Delete(tempStock);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteStockStreak(int id, StockStreak tempStockStreak = null)
            /// <summary>
            /// This method is used to delete StockStreak objects.
            /// </summary>
            /// <param name="id">Delete the StockStreak with this id</param>
            /// <param name="tempStockStreak">Pass in a tempStockStreak to perform a custom delete.</param>
            public bool DeleteStockStreak(int id, StockStreak tempStockStreak = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempStockStreak does not exist
                    if (tempStockStreak == null)
                    {
                        // create a temp StockStreak
                        tempStockStreak = new StockStreak();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempStockStreak.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.StockStreakController.Delete(tempStockStreak);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region ExecuteNonQuery(string procedureName, SqlParameter[] sqlParameters)
            /// <summary>
            /// This method Executes a Non Query StoredProcedure
            /// </summary>
            public PolymorphicObject ExecuteNonQuery(string procedureName, SqlParameter[] sqlParameters)
            {
                // initial value
                PolymorphicObject returnValue = new PolymorphicObject();

                // locals
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // create the parameters
                PolymorphicObject procedureNameParameter = new PolymorphicObject();
                PolymorphicObject sqlParametersParameter = new PolymorphicObject();

                // if the procedureName exists
                if (!String.IsNullOrEmpty(procedureName))
                {
                    // Create an instance of the SystemMethods object
                    SystemMethods systemMethods = new SystemMethods();

                    // setup procedureNameParameter
                    procedureNameParameter.Name = "ProcedureName";
                    procedureNameParameter.Text = procedureName;

                    // setup sqlParametersParameter
                    sqlParametersParameter.Name = "SqlParameters";
                    sqlParametersParameter.ObjectValue = sqlParameters;

                    // Add these parameters to the parameters
                    parameters.Add(procedureNameParameter);
                    parameters.Add(sqlParametersParameter);

                    // get the dataConnector
                    DataAccessComponent.DataManager.DataConnector dataConnector = GetDataConnector();

                    // Execute the query
                    returnValue = systemMethods.ExecuteNonQuery(parameters, dataConnector);
                }

                // return value
                return returnValue;
            }
            #endregion

            #region FindAdmin(int id, Admin tempAdmin = null)
            /// <summary>
            /// This method is used to find 'Admin' objects.
            /// </summary>
            /// <param name="id">Find the Admin with this id</param>
            /// <param name="tempAdmin">Pass in a tempAdmin to perform a custom find.</param>
            public Admin FindAdmin(int id, Admin tempAdmin = null)
            {
                // initial value
                Admin admin = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempAdmin does not exist
                    if (tempAdmin == null)
                    {
                        // create a temp Admin
                        tempAdmin = new Admin();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempAdmin.UpdateIdentity(id);
                    }

                    // perform the find
                    admin = this.AppController.ControllerManager.AdminController.Find(tempAdmin);
                }

                // return value
                return admin;
            }
            #endregion

            #region FindDailyPriceData(int id, DailyPriceData tempDailyPriceData = null)
            /// <summary>
            /// This method is used to find 'DailyPriceData' objects.
            /// </summary>
            /// <param name="id">Find the DailyPriceData with this id</param>
            /// <param name="tempDailyPriceData">Pass in a tempDailyPriceData to perform a custom find.</param>
            public DailyPriceData FindDailyPriceData(int id, DailyPriceData tempDailyPriceData = null)
            {
                // initial value
                DailyPriceData dailyPriceData = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempDailyPriceData does not exist
                    if (tempDailyPriceData == null)
                    {
                        // create a temp DailyPriceData
                        tempDailyPriceData = new DailyPriceData();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempDailyPriceData.UpdateIdentity(id);
                    }

                    // perform the find
                    dailyPriceData = this.AppController.ControllerManager.DailyPriceDataController.Find(tempDailyPriceData);
                }

                // return value
                return dailyPriceData;
            }
            #endregion

            #region FindStock(int id, Stock tempStock = null)
            /// <summary>
            /// This method is used to find 'Stock' objects.
            /// </summary>
            /// <param name="id">Find the Stock with this id</param>
            /// <param name="tempStock">Pass in a tempStock to perform a custom find.</param>
            public Stock FindStock(int id, Stock tempStock = null)
            {
                // initial value
                Stock stock = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempStock does not exist
                    if (tempStock == null)
                    {
                        // create a temp Stock
                        tempStock = new Stock();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempStock.UpdateIdentity(id);
                    }

                    // perform the find
                    stock = this.AppController.ControllerManager.StockController.Find(tempStock);
                }

                // return value
                return stock;
            }
            #endregion

                #region FindStockBySymbol(string symbol)
                /// <summary>
                /// This method is used to find 'Stock' objects for the Symbol given.
                /// </summary>
                public Stock FindStockBySymbol(string symbol)
                {
                    // initial value
                    Stock stock = null;
                    
                    // Create a temp Stock object
                    Stock tempStock = new Stock();
                    
                    // Set the value for FindBySymbol to true
                    tempStock.FindBySymbol = true;
                    
                    // Set the value for Symbol
                    tempStock.Symbol = symbol;
                    
                    // Perform the find
                    stock = FindStock(0, tempStock);
                    
                    // return value
                    return stock;
                }
                #endregion
                
            #region FindStockStreak(int id, StockStreak tempStockStreak = null)
            /// <summary>
            /// This method is used to find 'StockStreak' objects.
            /// </summary>
            /// <param name="id">Find the StockStreak with this id</param>
            /// <param name="tempStockStreak">Pass in a tempStockStreak to perform a custom find.</param>
            public StockStreak FindStockStreak(int id, StockStreak tempStockStreak = null)
            {
                // initial value
                StockStreak stockStreak = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempStockStreak does not exist
                    if (tempStockStreak == null)
                    {
                        // create a temp StockStreak
                        tempStockStreak = new StockStreak();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempStockStreak.UpdateIdentity(id);
                    }

                    // perform the find
                    stockStreak = this.AppController.ControllerManager.StockStreakController.Find(tempStockStreak);
                }

                // return value
                return stockStreak;
            }
            #endregion

            #region GetDataConnector()
            /// <summary>
            /// This method (safely) returns the Data Connector from the
            /// AppController.DataBridget.DataManager.DataConnector
            /// </summary>
            private DataConnector GetDataConnector()
            {
                // initial value
                DataConnector dataConnector = null;

                // if the AppController exists
                if (this.AppController != null)
                {
                    // return the DataConnector from the AppController
                    dataConnector = this.AppController.GetDataConnector();
                }

                // return value
                return dataConnector;
            }
            #endregion

            #region GetLastException()
            /// <summary>
            /// This method returns the last Exception from the AppController if one exists.
            /// Always test for null before refeferencing the Exception returned as it will be null 
            /// if no errors were encountered.
            /// </summary>
            /// <returns></returns>
            public Exception GetLastException()
            {
                // initial value
                Exception exception = null;

                // If the AppController object exists
                if (this.HasAppController)
                {
                    // return the Exception from the AppController
                    exception = this.AppController.Exception;

                    // Set to null after the exception is retrieved so it does not return again
                    this.AppController.Exception = null;
                }

                // return value
                return exception;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perform Initializations for this object.
            /// </summary>
            private void Init()
            {
                // Create Application Controller
                this.AppController = new ApplicationController(ConnectionName);
            }
            #endregion

            #region LoadAdmins(Admin tempAdmin = null)
            /// <summary>
            /// This method loads a collection of 'Admin' objects.
            /// </summary>
            public List<Admin> LoadAdmins(Admin tempAdmin = null)
            {
                // initial value
                List<Admin> admins = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    admins = this.AppController.ControllerManager.AdminController.FetchAll(tempAdmin);
                }

                // return value
                return admins;
            }
            #endregion

            #region LoadDailyPriceDatas(DailyPriceData tempDailyPriceData = null)
            /// <summary>
            /// This method loads a collection of 'DailyPriceData' objects.
            /// </summary>
            public List<DailyPriceData> LoadDailyPriceDatas(DailyPriceData tempDailyPriceData = null)
            {
                // initial value
                List<DailyPriceData> dailyPriceDatas = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    dailyPriceDatas = this.AppController.ControllerManager.DailyPriceDataController.FetchAll(tempDailyPriceData);
                }

                // return value
                return dailyPriceDatas;
            }
            #endregion

            #region LoadStocks(Stock tempStock = null)
            /// <summary>
            /// This method loads a collection of 'Stock' objects.
            /// </summary>
            public List<Stock> LoadStocks(Stock tempStock = null)
            {
                // initial value
                List<Stock> stocks = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    stocks = this.AppController.ControllerManager.StockController.FetchAll(tempStock);
                }

                // return value
                return stocks;
            }
            #endregion

            #region LoadStockStreaks(StockStreak tempStockStreak = null)
            /// <summary>
            /// This method loads a collection of 'StockStreak' objects.
            /// </summary>
            public List<StockStreak> LoadStockStreaks(StockStreak tempStockStreak = null)
            {
                // initial value
                List<StockStreak> stockStreaks = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    stockStreaks = this.AppController.ControllerManager.StockStreakController.FetchAll(tempStockStreak);
                }

                // return value
                return stockStreaks;
            }
            #endregion

            #region SaveAdmin(ref Admin admin)
            /// <summary>
            /// This method is used to save 'Admin' objects.
            /// </summary>
            /// <param name="admin">The Admin to save.</param>
            public bool SaveAdmin(ref Admin admin)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.AdminController.Save(ref admin);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveDailyPriceData(ref DailyPriceData dailyPriceData)
            /// <summary>
            /// This method is used to save 'DailyPriceData' objects.
            /// </summary>
            /// <param name="dailyPriceData">The DailyPriceData to save.</param>
            public bool SaveDailyPriceData(ref DailyPriceData dailyPriceData)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.DailyPriceDataController.Save(ref dailyPriceData);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveStock(ref Stock stock)
            /// <summary>
            /// This method is used to save 'Stock' objects.
            /// </summary>
            /// <param name="stock">The Stock to save.</param>
            public bool SaveStock(ref Stock stock)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.StockController.Save(ref stock);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveStockStreak(ref StockStreak stockStreak)
            /// <summary>
            /// This method is used to save 'StockStreak' objects.
            /// </summary>
            /// <param name="stockStreak">The StockStreak to save.</param>
            public bool SaveStockStreak(ref StockStreak stockStreak)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.StockStreakController.Save(ref stockStreak);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            /// <summary>
            /// This property gets or sets the value for 'AppController'.
            /// </summary>
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ConnectionName
            /// <summary>
            /// This property gets or sets the value for 'ConnectionName'.
            /// </summary>
            public string ConnectionName
            {
                get { return connectionName; }
                set { connectionName = value; }
            }
            #endregion
            
            #region HasAppController
            /// <summary>
            /// This property returns true if this object has an 'AppController'.
            /// </summary>
            public bool HasAppController
            {
                get
                {
                    // initial value
                    bool hasAppController = (this.AppController != null);

                    // return value
                    return hasAppController;
                }
            }
            #endregion

            #region HasConnectionName
            /// <summary>
            /// This property returns true if the 'ConnectionName' exists.
            /// </summary>
            public bool HasConnectionName
            {
                get
                {
                    // initial value
                    bool hasConnectionName = (!String.IsNullOrEmpty(this.ConnectionName));
                    
                    // return value
                    return hasConnectionName;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}

