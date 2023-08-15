

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

    #region class DailyPriceDataManager
    /// <summary>
    /// This class is used to manage a 'DailyPriceData' object.
    /// </summary>
    public class DailyPriceDataManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DailyPriceDataManager' object.
        /// </summary>
        public DailyPriceDataManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteDailyPriceData()
            /// <summary>
            /// This method deletes a 'DailyPriceData' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteDailyPriceData(DeleteDailyPriceDataStoredProcedure deleteDailyPriceDataProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteDailyPriceDataProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllDailyPriceDatas()
            /// <summary>
            /// This method fetches a  'List<DailyPriceData>' object.
            /// This method uses the 'DailyPriceDatas_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<DailyPriceData>'</returns>
            /// </summary>
            public List<DailyPriceData> FetchAllDailyPriceDatas(FetchAllDailyPriceDatasStoredProcedure fetchAllDailyPriceDatasProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<DailyPriceData> dailyPriceDataCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allDailyPriceDatasDataSet = this.DataHelper.LoadDataSet(fetchAllDailyPriceDatasProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allDailyPriceDatasDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allDailyPriceDatasDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            dailyPriceDataCollection = DailyPriceDataReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return dailyPriceDataCollection;
            }
            #endregion

            #region FindDailyPriceData()
            /// <summary>
            /// This method finds a  'DailyPriceData' object.
            /// This method uses the 'DailyPriceData_Find' procedure.
            /// </summary>
            /// <returns>A 'DailyPriceData' object.</returns>
            /// </summary>
            public DailyPriceData FindDailyPriceData(FindDailyPriceDataStoredProcedure findDailyPriceDataProc, DataConnector databaseConnector)
            {
                // Initial Value
                DailyPriceData dailyPriceData = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet dailyPriceDataDataSet = this.DataHelper.LoadDataSet(findDailyPriceDataProc, databaseConnector);

                    // Verify DataSet Exists
                    if(dailyPriceDataDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(dailyPriceDataDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load DailyPriceData
                            dailyPriceData = DailyPriceDataReader.Load(row);
                        }
                    }
                }

                // return value
                return dailyPriceData;
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

            #region InsertDailyPriceData()
            /// <summary>
            /// This method inserts a 'DailyPriceData' object.
            /// This method uses the 'DailyPriceData_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertDailyPriceData(InsertDailyPriceDataStoredProcedure insertDailyPriceDataProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertDailyPriceDataProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateDailyPriceData()
            /// <summary>
            /// This method updates a 'DailyPriceData'.
            /// This method uses the 'DailyPriceData_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateDailyPriceData(UpdateDailyPriceDataStoredProcedure updateDailyPriceDataProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateDailyPriceDataProc, databaseConnector);
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
