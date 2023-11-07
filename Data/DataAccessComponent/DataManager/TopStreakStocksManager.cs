

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

    #region class TopStreakStocksManager
    /// <summary>
    /// This class is used to manage a 'TopStreakStocks' object.
    /// </summary>
    public class TopStreakStocksManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'TopStreakStocksManager' object.
        /// </summary>
        public TopStreakStocksManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region FetchAllTopStreakStocks()
            /// <summary>
            /// This method fetches a  'List<TopStreakStocks>' object.
            /// This method uses the 'TopStreakStocks_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<TopStreakStocks>'</returns>
            /// </summary>
            public List<TopStreakStocks> FetchAllTopStreakStocks(FetchAllTopStreakStocksStoredProcedure fetchAllTopStreakStocksProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<TopStreakStocks> topStreakStocksCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allTopStreakStocksDataSet = this.DataHelper.LoadDataSet(fetchAllTopStreakStocksProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allTopStreakStocksDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allTopStreakStocksDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            topStreakStocksCollection = TopStreakStocksReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return topStreakStocksCollection;
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
