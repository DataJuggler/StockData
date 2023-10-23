

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

    #region class MarketSummaryManager
    /// <summary>
    /// This class is used to manage a 'MarketSummary' object.
    /// </summary>
    public class MarketSummaryManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'MarketSummaryManager' object.
        /// </summary>
        public MarketSummaryManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region FetchAllMarketSummarys()
            /// <summary>
            /// This method fetches a  'List<MarketSummary>' object.
            /// This method uses the 'MarketSummarys_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<MarketSummary>'</returns>
            /// </summary>
            public List<MarketSummary> FetchAllMarketSummarys(FetchAllMarketSummarysStoredProcedure fetchAllMarketSummarysProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<MarketSummary> marketSummaryCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allMarketSummarysDataSet = this.DataHelper.LoadDataSet(fetchAllMarketSummarysProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allMarketSummarysDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allMarketSummarysDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            marketSummaryCollection = MarketSummaryReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return marketSummaryCollection;
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
