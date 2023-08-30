

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

    #region class StockDayManager
    /// <summary>
    /// This class is used to manage a 'StockDay' object.
    /// </summary>
    public class StockDayManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'StockDayManager' object.
        /// </summary>
        public StockDayManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteStockDay()
            /// <summary>
            /// This method deletes a 'StockDay' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteStockDay(DeleteStockDayStoredProcedure deleteStockDayProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteStockDayProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllStockDays()
            /// <summary>
            /// This method fetches a  'List<StockDay>' object.
            /// This method uses the 'StockDays_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<StockDay>'</returns>
            /// </summary>
            public List<StockDay> FetchAllStockDays(FetchAllStockDaysStoredProcedure fetchAllStockDaysProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<StockDay> stockDayCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allStockDaysDataSet = this.DataHelper.LoadDataSet(fetchAllStockDaysProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allStockDaysDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allStockDaysDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            stockDayCollection = StockDayReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return stockDayCollection;
            }
            #endregion

            #region FindStockDay()
            /// <summary>
            /// This method finds a  'StockDay' object.
            /// This method uses the 'StockDay_Find' procedure.
            /// </summary>
            /// <returns>A 'StockDay' object.</returns>
            /// </summary>
            public StockDay FindStockDay(FindStockDayStoredProcedure findStockDayProc, DataConnector databaseConnector)
            {
                // Initial Value
                StockDay stockDay = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet stockDayDataSet = this.DataHelper.LoadDataSet(findStockDayProc, databaseConnector);

                    // Verify DataSet Exists
                    if(stockDayDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(stockDayDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load StockDay
                            stockDay = StockDayReader.Load(row);
                        }
                    }
                }

                // return value
                return stockDay;
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

            #region InsertStockDay()
            /// <summary>
            /// This method inserts a 'StockDay' object.
            /// This method uses the 'StockDay_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertStockDay(InsertStockDayStoredProcedure insertStockDayProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertStockDayProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateStockDay()
            /// <summary>
            /// This method updates a 'StockDay'.
            /// This method uses the 'StockDay_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateStockDay(UpdateStockDayStoredProcedure updateStockDayProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateStockDayProc, databaseConnector);
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
