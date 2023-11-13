

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

    #region class IndustryLosingStreakViewManager
    /// <summary>
    /// This class is used to manage a 'IndustryLosingStreakView' object.
    /// </summary>
    public class IndustryLosingStreakViewManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'IndustryLosingStreakViewManager' object.
        /// </summary>
        public IndustryLosingStreakViewManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region FetchAllIndustryLosingStreakViews()
            /// <summary>
            /// This method fetches a  'List<IndustryLosingStreakView>' object.
            /// This method uses the 'IndustryLosingStreakViews_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<IndustryLosingStreakView>'</returns>
            /// </summary>
            public List<IndustryLosingStreakView> FetchAllIndustryLosingStreakViews(FetchAllIndustryLosingStreakViewsStoredProcedure fetchAllIndustryLosingStreakViewsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<IndustryLosingStreakView> industryLosingStreakViewCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allIndustryLosingStreakViewsDataSet = this.DataHelper.LoadDataSet(fetchAllIndustryLosingStreakViewsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allIndustryLosingStreakViewsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allIndustryLosingStreakViewsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            industryLosingStreakViewCollection = IndustryLosingStreakViewReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return industryLosingStreakViewCollection;
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
