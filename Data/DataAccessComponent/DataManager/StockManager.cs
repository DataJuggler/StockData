

#region using statements

using DataAccessComponent.DataManager.Readers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager
{

    #region class StockManager
    /// <summary>
    /// This class is used to manage a 'Stock' object.
    /// </summary>
    public class StockManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'StockManager' object.
        /// </summary>
        public StockManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteStock()
            /// <summary>
            /// This method deletes a 'Stock' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteStock(DeleteStockStoredProcedure deleteStockProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteStockProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllStocks()
            /// <summary>
            /// This method fetches a  'List<Stock>' object.
            /// This method uses the 'Stocks_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<Stock>'</returns>
            /// </summary>
            public List<Stock> FetchAllStocks(FetchAllStocksStoredProcedure fetchAllStocksProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<Stock> stockCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allStocksDataSet = this.DataHelper.LoadDataSet(fetchAllStocksProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allStocksDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allStocksDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            stockCollection = StockReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return stockCollection;
            }
            #endregion

            #region FindStock()
            /// <summary>
            /// This method finds a  'Stock' object.
            /// This method uses the 'Stock_Find' procedure.
            /// </summary>
            /// <returns>A 'Stock' object.</returns>
            /// </summary>
            public Stock FindStock(FindStockStoredProcedure findStockProc, DataConnector databaseConnector)
            {
                // Initial Value
                Stock stock = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet stockDataSet = this.DataHelper.LoadDataSet(findStockProc, databaseConnector);

                    // Verify DataSet Exists
                    if(stockDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(stockDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load Stock
                            stock = StockReader.Load(row);
                        }
                    }
                }

                // return value
                return stock;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perorm Initialization For This Object
            /// </summary>
            private void Init()
            {
                // Create DataHelper object
                this.DataHelper = new DataHelper();
            }
            #endregion

            #region InsertStock()
            /// <summary>
            /// This method inserts a 'Stock' object.
            /// This method uses the 'Stock_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertStock(InsertStockStoredProcedure insertStockProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertStockProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateStock()
            /// <summary>
            /// This method updates a 'Stock'.
            /// This method uses the 'Stock_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateStock(UpdateStockStoredProcedure updateStockProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateStockProc, databaseConnector);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region DataHelper
            /// <summary>
            /// This object uses the Microsoft Data
            /// Application Block to execute stored
            /// procedures.
            /// </summary>
            internal DataHelper DataHelper
            {
                get { return dataHelper; }
                set { dataHelper = value; }
            }
            #endregion

            #region DataManager
            /// <summary>
            /// A reference to this objects parent.
            /// </summary>
            internal DataManager DataManager
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
