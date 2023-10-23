

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

    #region class IndustrySummaryManager
    /// <summary>
    /// This class is used to manage a 'IndustrySummary' object.
    /// </summary>
    public class IndustrySummaryManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'IndustrySummaryManager' object.
        /// </summary>
        public IndustrySummaryManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region FetchAllIndustrySummarys()
            /// <summary>
            /// This method fetches a  'List<IndustrySummary>' object.
            /// This method uses the 'IndustrySummarys_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<IndustrySummary>'</returns>
            /// </summary>
            public List<IndustrySummary> FetchAllIndustrySummarys(FetchAllIndustrySummarysStoredProcedure fetchAllIndustrySummarysProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<IndustrySummary> industrySummaryCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allIndustrySummarysDataSet = this.DataHelper.LoadDataSet(fetchAllIndustrySummarysProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allIndustrySummarysDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allIndustrySummarysDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            industrySummaryCollection = IndustrySummaryReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return industrySummaryCollection;
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
