

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

    #region class StockStreakManager
    /// <summary>
    /// This class is used to manage a 'StockStreak' object.
    /// </summary>
    public class StockStreakManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'StockStreakManager' object.
        /// </summary>
        public StockStreakManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteStockStreak()
            /// <summary>
            /// This method deletes a 'StockStreak' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteStockStreak(DeleteStockStreakStoredProcedure deleteStockStreakProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteStockStreakProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllStockStreaks()
            /// <summary>
            /// This method fetches a  'List<StockStreak>' object.
            /// This method uses the 'StockStreaks_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<StockStreak>'</returns>
            /// </summary>
            public List<StockStreak> FetchAllStockStreaks(FetchAllStockStreaksStoredProcedure fetchAllStockStreaksProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<StockStreak> stockStreakCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allStockStreaksDataSet = this.DataHelper.LoadDataSet(fetchAllStockStreaksProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allStockStreaksDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allStockStreaksDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            stockStreakCollection = StockStreakReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return stockStreakCollection;
            }
            #endregion

            #region FindStockStreak()
            /// <summary>
            /// This method finds a  'StockStreak' object.
            /// This method uses the 'StockStreak_Find' procedure.
            /// </summary>
            /// <returns>A 'StockStreak' object.</returns>
            /// </summary>
            public StockStreak FindStockStreak(FindStockStreakStoredProcedure findStockStreakProc, DataConnector databaseConnector)
            {
                // Initial Value
                StockStreak stockStreak = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet stockStreakDataSet = this.DataHelper.LoadDataSet(findStockStreakProc, databaseConnector);

                    // Verify DataSet Exists
                    if(stockStreakDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(stockStreakDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load StockStreak
                            stockStreak = StockStreakReader.Load(row);
                        }
                    }
                }

                // return value
                return stockStreak;
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

            #region InsertStockStreak()
            /// <summary>
            /// This method inserts a 'StockStreak' object.
            /// This method uses the 'StockStreak_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertStockStreak(InsertStockStreakStoredProcedure insertStockStreakProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertStockStreakProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateStockStreak()
            /// <summary>
            /// This method updates a 'StockStreak'.
            /// This method uses the 'StockStreak_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateStockStreak(UpdateStockStreakStoredProcedure updateStockStreakProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateStockStreakProc, databaseConnector);
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
