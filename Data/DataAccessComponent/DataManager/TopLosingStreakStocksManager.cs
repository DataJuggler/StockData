

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

    #region class TopLosingStreakStocksManager
    /// <summary>
    /// This class is used to manage a 'TopLosingStreakStocks' object.
    /// </summary>
    public class TopLosingStreakStocksManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'TopLosingStreakStocksManager' object.
        /// </summary>
        public TopLosingStreakStocksManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region FetchAllTopLosingStreakStocks()
            /// <summary>
            /// This method fetches a  'List<TopLosingStreakStocks>' object.
            /// This method uses the 'TopLosingStreakStocks_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<TopLosingStreakStocks>'</returns>
            /// </summary>
            public List<TopLosingStreakStocks> FetchAllTopLosingStreakStocks(FetchAllTopLosingStreakStocksStoredProcedure fetchAllTopLosingStreakStocksProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<TopLosingStreakStocks> topLosingStreakStocksCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allTopLosingStreakStocksDataSet = this.DataHelper.LoadDataSet(fetchAllTopLosingStreakStocksProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allTopLosingStreakStocksDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allTopLosingStreakStocksDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            topLosingStreakStocksCollection = TopLosingStreakStocksReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return topLosingStreakStocksCollection;
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
