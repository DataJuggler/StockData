

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

    #region class SectorSummaryManager
    /// <summary>
    /// This class is used to manage a 'SectorSummary' object.
    /// </summary>
    public class SectorSummaryManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'SectorSummaryManager' object.
        /// </summary>
        public SectorSummaryManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region FetchAllSectorSummarys()
            /// <summary>
            /// This method fetches a  'List<SectorSummary>' object.
            /// This method uses the 'SectorSummarys_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<SectorSummary>'</returns>
            /// </summary>
            public List<SectorSummary> FetchAllSectorSummarys(FetchAllSectorSummarysStoredProcedure fetchAllSectorSummarysProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<SectorSummary> sectorSummaryCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allSectorSummarysDataSet = this.DataHelper.LoadDataSet(fetchAllSectorSummarysProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allSectorSummarysDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allSectorSummarysDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            sectorSummaryCollection = SectorSummaryReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return sectorSummaryCollection;
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
