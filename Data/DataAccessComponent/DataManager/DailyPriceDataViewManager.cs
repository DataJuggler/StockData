

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

    #region class DailyPriceDataViewManager
    /// <summary>
    /// This class is used to manage a 'DailyPriceDataView' object.
    /// </summary>
    public class DailyPriceDataViewManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DailyPriceDataViewManager' object.
        /// </summary>
        public DailyPriceDataViewManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region FetchAllDailyPriceDataViews()
            /// <summary>
            /// This method fetches a  'List<DailyPriceDataView>' object.
            /// This method uses the 'DailyPriceDataViews_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<DailyPriceDataView>'</returns>
            /// </summary>
            public List<DailyPriceDataView> FetchAllDailyPriceDataViews(FetchAllDailyPriceDataViewsStoredProcedure fetchAllDailyPriceDataViewsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<DailyPriceDataView> dailyPriceDataViewCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allDailyPriceDataViewsDataSet = this.DataHelper.LoadDataSet(fetchAllDailyPriceDataViewsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allDailyPriceDataViewsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allDailyPriceDataViewsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            dailyPriceDataViewCollection = DailyPriceDataViewReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return dailyPriceDataViewCollection;
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
