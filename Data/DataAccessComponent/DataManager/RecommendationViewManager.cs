

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

    #region class RecommendationViewManager
    /// <summary>
    /// This class is used to manage a 'RecommendationView' object.
    /// </summary>
    public class RecommendationViewManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'RecommendationViewManager' object.
        /// </summary>
        public RecommendationViewManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region FetchAllRecommendationViews()
            /// <summary>
            /// This method fetches a  'List<RecommendationView>' object.
            /// This method uses the 'RecommendationViews_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<RecommendationView>'</returns>
            /// </summary>
            public List<RecommendationView> FetchAllRecommendationViews(FetchAllRecommendationViewsStoredProcedure fetchAllRecommendationViewsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<RecommendationView> recommendationViewCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allRecommendationViewsDataSet = this.DataHelper.LoadDataSet(fetchAllRecommendationViewsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allRecommendationViewsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allRecommendationViewsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            recommendationViewCollection = RecommendationViewReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return recommendationViewCollection;
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
