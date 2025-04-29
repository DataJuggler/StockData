

#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using Microsoft.Data.SqlClient;
using ObjectLibrary.BusinessObjects;
using System;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Writers
{

    #region class SectorHistoryWriterBase
    /// <summary>
    /// This class is used for converting a 'SectorHistory' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class SectorHistoryWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(SectorHistory sectorHistory)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='sectorHistory'>The 'SectorHistory' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(SectorHistory sectorHistory)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (sectorHistory != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", sectorHistory.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteSectorHistoryStoredProcedure(SectorHistory sectorHistory)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteSectorHistory'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'SectorHistory_Delete'.
            /// </summary>
            /// <param name="sectorHistory">The 'SectorHistory' to Delete.</param>
            /// <returns>An instance of a 'DeleteSectorHistoryStoredProcedure' object.</returns>
            public static DeleteSectorHistoryStoredProcedure CreateDeleteSectorHistoryStoredProcedure(SectorHistory sectorHistory)
            {
                // Initial Value
                DeleteSectorHistoryStoredProcedure deleteSectorHistoryStoredProcedure = new DeleteSectorHistoryStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteSectorHistoryStoredProcedure.Parameters = CreatePrimaryKeyParameter(sectorHistory);

                // return value
                return deleteSectorHistoryStoredProcedure;
            }
            #endregion

            #region CreateFindSectorHistoryStoredProcedure(SectorHistory sectorHistory)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindSectorHistoryStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'SectorHistory_Find'.
            /// </summary>
            /// <param name="sectorHistory">The 'SectorHistory' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindSectorHistoryStoredProcedure CreateFindSectorHistoryStoredProcedure(SectorHistory sectorHistory)
            {
                // Initial Value
                FindSectorHistoryStoredProcedure findSectorHistoryStoredProcedure = null;

                // verify sectorHistory exists
                if(sectorHistory != null)
                {
                    // Instanciate findSectorHistoryStoredProcedure
                    findSectorHistoryStoredProcedure = new FindSectorHistoryStoredProcedure();

                    // Now create parameters for this procedure
                    findSectorHistoryStoredProcedure.Parameters = CreatePrimaryKeyParameter(sectorHistory);
                }

                // return value
                return findSectorHistoryStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(SectorHistory sectorHistory)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new sectorHistory.
            /// </summary>
            /// <param name="sectorHistory">The 'SectorHistory' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(SectorHistory sectorHistory)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[7];
                SqlParameter param = null;

                // verify sectorHistoryexists
                if(sectorHistory != null)
                {
                    // Create [Advancers] parameter
                    param = new SqlParameter("@Advancers", sectorHistory.Advancers);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [AveragePercentChange] parameter
                    param = new SqlParameter("@AveragePercentChange", sectorHistory.AveragePercentChange);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [Date] Parameter
                    param = new SqlParameter("@Date", SqlDbType.DateTime);

                    // If sectorHistory.Date does not exist.
                    if (sectorHistory.Date.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = sectorHistory.Date;
                    }
                    // set parameters[2]
                    parameters[2] = param;

                    // Create [Decliners] parameter
                    param = new SqlParameter("@Decliners", sectorHistory.Decliners);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [Score] parameter
                    param = new SqlParameter("@Score", sectorHistory.Score);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [SectorId] parameter
                    param = new SqlParameter("@SectorId", sectorHistory.SectorId);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [Streak] parameter
                    param = new SqlParameter("@Streak", sectorHistory.Streak);

                    // set parameters[6]
                    parameters[6] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertSectorHistoryStoredProcedure(SectorHistory sectorHistory)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertSectorHistoryStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'SectorHistory_Insert'.
            /// </summary>
            /// <param name="sectorHistory"The 'SectorHistory' object to insert</param>
            /// <returns>An instance of a 'InsertSectorHistoryStoredProcedure' object.</returns>
            public static InsertSectorHistoryStoredProcedure CreateInsertSectorHistoryStoredProcedure(SectorHistory sectorHistory)
            {
                // Initial Value
                InsertSectorHistoryStoredProcedure insertSectorHistoryStoredProcedure = null;

                // verify sectorHistory exists
                if(sectorHistory != null)
                {
                    // Instanciate insertSectorHistoryStoredProcedure
                    insertSectorHistoryStoredProcedure = new InsertSectorHistoryStoredProcedure();

                    // Now create parameters for this procedure
                    insertSectorHistoryStoredProcedure.Parameters = CreateInsertParameters(sectorHistory);
                }

                // return value
                return insertSectorHistoryStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(SectorHistory sectorHistory)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing sectorHistory.
            /// </summary>
            /// <param name="sectorHistory">The 'SectorHistory' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(SectorHistory sectorHistory)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[8];
                SqlParameter param = null;

                // verify sectorHistoryexists
                if(sectorHistory != null)
                {
                    // Create parameter for [Advancers]
                    param = new SqlParameter("@Advancers", sectorHistory.Advancers);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [AveragePercentChange]
                    param = new SqlParameter("@AveragePercentChange", sectorHistory.AveragePercentChange);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [Date]
                    // Create [Date] Parameter
                    param = new SqlParameter("@Date", SqlDbType.DateTime);

                    // If sectorHistory.Date does not exist.
                    if (sectorHistory.Date.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = sectorHistory.Date;
                    }

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [Decliners]
                    param = new SqlParameter("@Decliners", sectorHistory.Decliners);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [Score]
                    param = new SqlParameter("@Score", sectorHistory.Score);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [SectorId]
                    param = new SqlParameter("@SectorId", sectorHistory.SectorId);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [Streak]
                    param = new SqlParameter("@Streak", sectorHistory.Streak);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", sectorHistory.Id);
                    parameters[7] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateSectorHistoryStoredProcedure(SectorHistory sectorHistory)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateSectorHistoryStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'SectorHistory_Update'.
            /// </summary>
            /// <param name="sectorHistory"The 'SectorHistory' object to update</param>
            /// <returns>An instance of a 'UpdateSectorHistoryStoredProcedure</returns>
            public static UpdateSectorHistoryStoredProcedure CreateUpdateSectorHistoryStoredProcedure(SectorHistory sectorHistory)
            {
                // Initial Value
                UpdateSectorHistoryStoredProcedure updateSectorHistoryStoredProcedure = null;

                // verify sectorHistory exists
                if(sectorHistory != null)
                {
                    // Instanciate updateSectorHistoryStoredProcedure
                    updateSectorHistoryStoredProcedure = new UpdateSectorHistoryStoredProcedure();

                    // Now create parameters for this procedure
                    updateSectorHistoryStoredProcedure.Parameters = CreateUpdateParameters(sectorHistory);
                }

                // return value
                return updateSectorHistoryStoredProcedure;
            }
            #endregion

            #region CreateFetchAllSectorHistorysStoredProcedure(SectorHistory sectorHistory)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllSectorHistorysStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'SectorHistory_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllSectorHistorysStoredProcedure' object.</returns>
            public static FetchAllSectorHistorysStoredProcedure CreateFetchAllSectorHistorysStoredProcedure(SectorHistory sectorHistory)
            {
                // Initial value
                FetchAllSectorHistorysStoredProcedure fetchAllSectorHistorysStoredProcedure = new FetchAllSectorHistorysStoredProcedure();

                // return value
                return fetchAllSectorHistorysStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
