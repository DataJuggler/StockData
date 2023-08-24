

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

    #region class SectorManager
    /// <summary>
    /// This class is used to manage a 'Sector' object.
    /// </summary>
    public class SectorManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'SectorManager' object.
        /// </summary>
        public SectorManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteSector()
            /// <summary>
            /// This method deletes a 'Sector' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteSector(DeleteSectorStoredProcedure deleteSectorProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteSectorProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllSectors()
            /// <summary>
            /// This method fetches a  'List<Sector>' object.
            /// This method uses the 'Sectors_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<Sector>'</returns>
            /// </summary>
            public List<Sector> FetchAllSectors(FetchAllSectorsStoredProcedure fetchAllSectorsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<Sector> sectorCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allSectorsDataSet = this.DataHelper.LoadDataSet(fetchAllSectorsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allSectorsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allSectorsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            sectorCollection = SectorReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return sectorCollection;
            }
            #endregion

            #region FindSector()
            /// <summary>
            /// This method finds a  'Sector' object.
            /// This method uses the 'Sector_Find' procedure.
            /// </summary>
            /// <returns>A 'Sector' object.</returns>
            /// </summary>
            public Sector FindSector(FindSectorStoredProcedure findSectorProc, DataConnector databaseConnector)
            {
                // Initial Value
                Sector sector = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet sectorDataSet = this.DataHelper.LoadDataSet(findSectorProc, databaseConnector);

                    // Verify DataSet Exists
                    if(sectorDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(sectorDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load Sector
                            sector = SectorReader.Load(row);
                        }
                    }
                }

                // return value
                return sector;
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

            #region InsertSector()
            /// <summary>
            /// This method inserts a 'Sector' object.
            /// This method uses the 'Sector_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertSector(InsertSectorStoredProcedure insertSectorProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertSectorProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateSector()
            /// <summary>
            /// This method updates a 'Sector'.
            /// This method uses the 'Sector_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateSector(UpdateSectorStoredProcedure updateSectorProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateSectorProc, databaseConnector);
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
