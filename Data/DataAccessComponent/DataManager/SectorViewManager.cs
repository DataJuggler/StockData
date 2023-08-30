

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

    #region class SectorViewManager
    /// <summary>
    /// This class is used to manage a 'SectorView' object.
    /// </summary>
    public class SectorViewManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'SectorViewManager' object.
        /// </summary>
        public SectorViewManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region FetchAllSectorViews()
            /// <summary>
            /// This method fetches a  'List<SectorView>' object.
            /// This method uses the 'SectorViews_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<SectorView>'</returns>
            /// </summary>
            public List<SectorView> FetchAllSectorViews(FetchAllSectorViewsStoredProcedure fetchAllSectorViewsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<SectorView> sectorViewCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allSectorViewsDataSet = this.DataHelper.LoadDataSet(fetchAllSectorViewsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allSectorViewsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allSectorViewsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            sectorViewCollection = SectorViewReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return sectorViewCollection;
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
