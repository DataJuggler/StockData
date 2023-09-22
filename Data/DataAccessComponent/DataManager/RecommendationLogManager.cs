

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

    #region class RecommendationLogManager
    /// <summary>
    /// This class is used to manage a 'RecommendationLog' object.
    /// </summary>
    public class RecommendationLogManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'RecommendationLogManager' object.
        /// </summary>
        public RecommendationLogManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteRecommendationLog()
            /// <summary>
            /// This method deletes a 'RecommendationLog' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteRecommendationLog(DeleteRecommendationLogStoredProcedure deleteRecommendationLogProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteRecommendationLogProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllRecommendationLogs()
            /// <summary>
            /// This method fetches a  'List<RecommendationLog>' object.
            /// This method uses the 'RecommendationLogs_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<RecommendationLog>'</returns>
            /// </summary>
            public List<RecommendationLog> FetchAllRecommendationLogs(FetchAllRecommendationLogsStoredProcedure fetchAllRecommendationLogsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<RecommendationLog> recommendationLogCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allRecommendationLogsDataSet = this.DataHelper.LoadDataSet(fetchAllRecommendationLogsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allRecommendationLogsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allRecommendationLogsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            recommendationLogCollection = RecommendationLogReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return recommendationLogCollection;
            }
            #endregion

            #region FindRecommendationLog()
            /// <summary>
            /// This method finds a  'RecommendationLog' object.
            /// This method uses the 'RecommendationLog_Find' procedure.
            /// </summary>
            /// <returns>A 'RecommendationLog' object.</returns>
            /// </summary>
            public RecommendationLog FindRecommendationLog(FindRecommendationLogStoredProcedure findRecommendationLogProc, DataConnector databaseConnector)
            {
                // Initial Value
                RecommendationLog recommendationLog = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet recommendationLogDataSet = this.DataHelper.LoadDataSet(findRecommendationLogProc, databaseConnector);

                    // Verify DataSet Exists
                    if(recommendationLogDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(recommendationLogDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load RecommendationLog
                            recommendationLog = RecommendationLogReader.Load(row);
                        }
                    }
                }

                // return value
                return recommendationLog;
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

            #region InsertRecommendationLog()
            /// <summary>
            /// This method inserts a 'RecommendationLog' object.
            /// This method uses the 'RecommendationLog_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertRecommendationLog(InsertRecommendationLogStoredProcedure insertRecommendationLogProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertRecommendationLogProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateRecommendationLog()
            /// <summary>
            /// This method updates a 'RecommendationLog'.
            /// This method uses the 'RecommendationLog_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateRecommendationLog(UpdateRecommendationLogStoredProcedure updateRecommendationLogProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateRecommendationLogProc, databaseConnector);
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
