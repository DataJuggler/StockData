

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

    #region class SectorHistoryManager
    /// <summary>
    /// This class is used to manage a 'SectorHistory' object.
    /// </summary>
    public class SectorHistoryManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'SectorHistoryManager' object.
        /// </summary>
        public SectorHistoryManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteSectorHistory()
            /// <summary>
            /// This method deletes a 'SectorHistory' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool DeleteSectorHistory(DeleteSectorHistoryStoredProcedure deleteSectorHistoryProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = DataHelper.DeleteRecord(deleteSectorHistoryProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllSectorHistorys()
            /// <summary>
            /// This method fetches a  'List<SectorHistory>' object.
            /// This method uses the 'SectorHistorys_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<SectorHistory>'</returns>
            /// </summary>
            public static List<SectorHistory> FetchAllSectorHistorys(FetchAllSectorHistorysStoredProcedure fetchAllSectorHistorysProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<SectorHistory> sectorHistoryCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allSectorHistorysDataSet = DataHelper.LoadDataSet(fetchAllSectorHistorysProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allSectorHistorysDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = DataHelper.ReturnFirstTable(allSectorHistorysDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            sectorHistoryCollection = SectorHistoryReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return sectorHistoryCollection;
            }
            #endregion

            #region FindSectorHistory()
            /// <summary>
            /// This method finds a  'SectorHistory' object.
            /// This method uses the 'SectorHistory_Find' procedure.
            /// </summary>
            /// <returns>A 'SectorHistory' object.</returns>
            /// </summary>
            public static SectorHistory FindSectorHistory(FindSectorHistoryStoredProcedure findSectorHistoryProc, DataConnector databaseConnector)
            {
                // Initial Value
                SectorHistory sectorHistory = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet sectorHistoryDataSet = DataHelper.LoadDataSet(findSectorHistoryProc, databaseConnector);

                    // Verify DataSet Exists
                    if(sectorHistoryDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = DataHelper.ReturnFirstRow(sectorHistoryDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load SectorHistory
                            sectorHistory = SectorHistoryReader.Load(row);
                        }
                    }
                }

                // return value
                return sectorHistory;
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

            #region InsertSectorHistory()
            /// <summary>
            /// This method inserts a 'SectorHistory' object.
            /// This method uses the 'SectorHistory_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public static int InsertSectorHistory(InsertSectorHistoryStoredProcedure insertSectorHistoryProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = DataHelper.InsertRecord(insertSectorHistoryProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateSectorHistory()
            /// <summary>
            /// This method updates a 'SectorHistory'.
            /// This method uses the 'SectorHistory_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool UpdateSectorHistory(UpdateSectorHistoryStoredProcedure updateSectorHistoryProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = DataHelper.UpdateRecord(updateSectorHistoryProc, databaseConnector);
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
