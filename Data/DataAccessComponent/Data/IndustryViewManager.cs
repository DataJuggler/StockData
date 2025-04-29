

#region using statements

using DataAccessComponent.Data.Readers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data
{

    #region class IndustryViewManager
    /// <summary>
    /// This class is used to manage a 'IndustryView' object.
    /// </summary>
    public class IndustryViewManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'IndustryViewManager' object.
        /// </summary>
        public IndustryViewManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region FetchAllIndustryViews()
            /// <summary>
            /// This method fetches a  'List<IndustryView>' object.
            /// This method uses the 'IndustryViews_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<IndustryView>'</returns>
            /// </summary>
            public static List<IndustryView> FetchAllIndustryViews(FetchAllIndustryViewsStoredProcedure fetchAllIndustryViewsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<IndustryView> industryViewCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allIndustryViewsDataSet = DataHelper.LoadDataSet(fetchAllIndustryViewsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allIndustryViewsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = DataHelper.ReturnFirstTable(allIndustryViewsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            industryViewCollection = IndustryViewReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return industryViewCollection;
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
