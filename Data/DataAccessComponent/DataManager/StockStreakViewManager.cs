

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

    #region class StockStreakViewManager
    /// <summary>
    /// This class is used to manage a 'StockStreakView' object.
    /// </summary>
    public class StockStreakViewManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'StockStreakViewManager' object.
        /// </summary>
        public StockStreakViewManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region FetchAllStockStreakViews()
            /// <summary>
            /// This method fetches a  'List<StockStreakView>' object.
            /// This method uses the 'StockStreakViews_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<StockStreakView>'</returns>
            /// </summary>
            public List<StockStreakView> FetchAllStockStreakViews(FetchAllStockStreakViewsStoredProcedure fetchAllStockStreakViewsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<StockStreakView> stockStreakViewCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allStockStreakViewsDataSet = this.DataHelper.LoadDataSet(fetchAllStockStreakViewsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allStockStreakViewsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allStockStreakViewsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            stockStreakViewCollection = StockStreakViewReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return stockStreakViewCollection;
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
