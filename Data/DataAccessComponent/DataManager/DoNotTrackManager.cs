

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

    #region class DoNotTrackManager
    /// <summary>
    /// This class is used to manage a 'DoNotTrack' object.
    /// </summary>
    public class DoNotTrackManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DoNotTrackManager' object.
        /// </summary>
        public DoNotTrackManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteDoNotTrack()
            /// <summary>
            /// This method deletes a 'DoNotTrack' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteDoNotTrack(DeleteDoNotTrackStoredProcedure deleteDoNotTrackProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteDoNotTrackProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllDoNotTracks()
            /// <summary>
            /// This method fetches a  'List<DoNotTrack>' object.
            /// This method uses the 'DoNotTracks_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<DoNotTrack>'</returns>
            /// </summary>
            public List<DoNotTrack> FetchAllDoNotTracks(FetchAllDoNotTracksStoredProcedure fetchAllDoNotTracksProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<DoNotTrack> doNotTrackCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allDoNotTracksDataSet = this.DataHelper.LoadDataSet(fetchAllDoNotTracksProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allDoNotTracksDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allDoNotTracksDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            doNotTrackCollection = DoNotTrackReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return doNotTrackCollection;
            }
            #endregion

            #region FindDoNotTrack()
            /// <summary>
            /// This method finds a  'DoNotTrack' object.
            /// This method uses the 'DoNotTrack_Find' procedure.
            /// </summary>
            /// <returns>A 'DoNotTrack' object.</returns>
            /// </summary>
            public DoNotTrack FindDoNotTrack(FindDoNotTrackStoredProcedure findDoNotTrackProc, DataConnector databaseConnector)
            {
                // Initial Value
                DoNotTrack doNotTrack = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet doNotTrackDataSet = this.DataHelper.LoadDataSet(findDoNotTrackProc, databaseConnector);

                    // Verify DataSet Exists
                    if(doNotTrackDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(doNotTrackDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load DoNotTrack
                            doNotTrack = DoNotTrackReader.Load(row);
                        }
                    }
                }

                // return value
                return doNotTrack;
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

            #region InsertDoNotTrack()
            /// <summary>
            /// This method inserts a 'DoNotTrack' object.
            /// This method uses the 'DoNotTrack_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertDoNotTrack(InsertDoNotTrackStoredProcedure insertDoNotTrackProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertDoNotTrackProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateDoNotTrack()
            /// <summary>
            /// This method updates a 'DoNotTrack'.
            /// This method uses the 'DoNotTrack_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateDoNotTrack(UpdateDoNotTrackStoredProcedure updateDoNotTrackProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateDoNotTrackProc, databaseConnector);
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
