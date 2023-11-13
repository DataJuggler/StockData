

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

    #region class IndustryWinningStreakViewManager
    /// <summary>
    /// This class is used to manage a 'IndustryWinningStreakView' object.
    /// </summary>
    public class IndustryWinningStreakViewManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'IndustryWinningStreakViewManager' object.
        /// </summary>
        public IndustryWinningStreakViewManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region FetchAllIndustryWinningStreakViews()
            /// <summary>
            /// This method fetches a  'List<IndustryWinningStreakView>' object.
            /// This method uses the 'IndustryWinningStreakViews_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<IndustryWinningStreakView>'</returns>
            /// </summary>
            public List<IndustryWinningStreakView> FetchAllIndustryWinningStreakViews(FetchAllIndustryWinningStreakViewsStoredProcedure fetchAllIndustryWinningStreakViewsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<IndustryWinningStreakView> industryWinningStreakViewCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allIndustryWinningStreakViewsDataSet = this.DataHelper.LoadDataSet(fetchAllIndustryWinningStreakViewsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allIndustryWinningStreakViewsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allIndustryWinningStreakViewsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            industryWinningStreakViewCollection = IndustryWinningStreakViewReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return industryWinningStreakViewCollection;
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
