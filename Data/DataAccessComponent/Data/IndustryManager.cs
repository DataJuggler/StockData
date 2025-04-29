

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

    #region class IndustryManager
    /// <summary>
    /// This class is used to manage a 'Industry' object.
    /// </summary>
    public class IndustryManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'IndustryManager' object.
        /// </summary>
        public IndustryManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteIndustry()
            /// <summary>
            /// This method deletes a 'Industry' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool DeleteIndustry(DeleteIndustryStoredProcedure deleteIndustryProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = DataHelper.DeleteRecord(deleteIndustryProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllIndustrys()
            /// <summary>
            /// This method fetches a  'List<Industry>' object.
            /// This method uses the 'Industrys_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<Industry>'</returns>
            /// </summary>
            public static List<Industry> FetchAllIndustrys(FetchAllIndustrysStoredProcedure fetchAllIndustrysProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<Industry> industryCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allIndustrysDataSet = DataHelper.LoadDataSet(fetchAllIndustrysProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allIndustrysDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = DataHelper.ReturnFirstTable(allIndustrysDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            industryCollection = IndustryReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return industryCollection;
            }
            #endregion

            #region FindIndustry()
            /// <summary>
            /// This method finds a  'Industry' object.
            /// This method uses the 'Industry_Find' procedure.
            /// </summary>
            /// <returns>A 'Industry' object.</returns>
            /// </summary>
            public static Industry FindIndustry(FindIndustryStoredProcedure findIndustryProc, DataConnector databaseConnector)
            {
                // Initial Value
                Industry industry = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet industryDataSet = DataHelper.LoadDataSet(findIndustryProc, databaseConnector);

                    // Verify DataSet Exists
                    if(industryDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = DataHelper.ReturnFirstRow(industryDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load Industry
                            industry = IndustryReader.Load(row);
                        }
                    }
                }

                // return value
                return industry;
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

            #region InsertIndustry()
            /// <summary>
            /// This method inserts a 'Industry' object.
            /// This method uses the 'Industry_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public static int InsertIndustry(InsertIndustryStoredProcedure insertIndustryProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = DataHelper.InsertRecord(insertIndustryProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateIndustry()
            /// <summary>
            /// This method updates a 'Industry'.
            /// This method uses the 'Industry_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public static bool UpdateIndustry(UpdateIndustryStoredProcedure updateIndustryProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = DataHelper.UpdateRecord(updateIndustryProc, databaseConnector);
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
