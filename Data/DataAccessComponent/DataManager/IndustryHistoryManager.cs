

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

    #region class IndustryHistoryManager
    /// <summary>
    /// This class is used to manage a 'IndustryHistory' object.
    /// </summary>
    public class IndustryHistoryManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'IndustryHistoryManager' object.
        /// </summary>
        public IndustryHistoryManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteIndustryHistory()
            /// <summary>
            /// This method deletes a 'IndustryHistory' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteIndustryHistory(DeleteIndustryHistoryStoredProcedure deleteIndustryHistoryProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteIndustryHistoryProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllIndustryHistorys()
            /// <summary>
            /// This method fetches a  'List<IndustryHistory>' object.
            /// This method uses the 'IndustryHistorys_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<IndustryHistory>'</returns>
            /// </summary>
            public List<IndustryHistory> FetchAllIndustryHistorys(FetchAllIndustryHistorysStoredProcedure fetchAllIndustryHistorysProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<IndustryHistory> industryHistoryCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allIndustryHistorysDataSet = this.DataHelper.LoadDataSet(fetchAllIndustryHistorysProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allIndustryHistorysDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allIndustryHistorysDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            industryHistoryCollection = IndustryHistoryReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return industryHistoryCollection;
            }
            #endregion

            #region FindIndustryHistory()
            /// <summary>
            /// This method finds a  'IndustryHistory' object.
            /// This method uses the 'IndustryHistory_Find' procedure.
            /// </summary>
            /// <returns>A 'IndustryHistory' object.</returns>
            /// </summary>
            public IndustryHistory FindIndustryHistory(FindIndustryHistoryStoredProcedure findIndustryHistoryProc, DataConnector databaseConnector)
            {
                // Initial Value
                IndustryHistory industryHistory = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet industryHistoryDataSet = this.DataHelper.LoadDataSet(findIndustryHistoryProc, databaseConnector);

                    // Verify DataSet Exists
                    if(industryHistoryDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(industryHistoryDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load IndustryHistory
                            industryHistory = IndustryHistoryReader.Load(row);
                        }
                    }
                }

                // return value
                return industryHistory;
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

            #region InsertIndustryHistory()
            /// <summary>
            /// This method inserts a 'IndustryHistory' object.
            /// This method uses the 'IndustryHistory_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertIndustryHistory(InsertIndustryHistoryStoredProcedure insertIndustryHistoryProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertIndustryHistoryProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateIndustryHistory()
            /// <summary>
            /// This method updates a 'IndustryHistory'.
            /// This method uses the 'IndustryHistory_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateIndustryHistory(UpdateIndustryHistoryStoredProcedure updateIndustryHistoryProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateIndustryHistoryProc, databaseConnector);
                }

                // return value
                return saved;
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
