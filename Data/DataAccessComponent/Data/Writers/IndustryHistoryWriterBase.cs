

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

    #region class IndustryHistoryWriterBase
    /// <summary>
    /// This class is used for converting a 'IndustryHistory' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class IndustryHistoryWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(IndustryHistory industryHistory)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='industryHistory'>The 'IndustryHistory' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(IndustryHistory industryHistory)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (industryHistory != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", industryHistory.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteIndustryHistoryStoredProcedure(IndustryHistory industryHistory)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteIndustryHistory'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'IndustryHistory_Delete'.
            /// </summary>
            /// <param name="industryHistory">The 'IndustryHistory' to Delete.</param>
            /// <returns>An instance of a 'DeleteIndustryHistoryStoredProcedure' object.</returns>
            public static DeleteIndustryHistoryStoredProcedure CreateDeleteIndustryHistoryStoredProcedure(IndustryHistory industryHistory)
            {
                // Initial Value
                DeleteIndustryHistoryStoredProcedure deleteIndustryHistoryStoredProcedure = new DeleteIndustryHistoryStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteIndustryHistoryStoredProcedure.Parameters = CreatePrimaryKeyParameter(industryHistory);

                // return value
                return deleteIndustryHistoryStoredProcedure;
            }
            #endregion

            #region CreateFindIndustryHistoryStoredProcedure(IndustryHistory industryHistory)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindIndustryHistoryStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'IndustryHistory_Find'.
            /// </summary>
            /// <param name="industryHistory">The 'IndustryHistory' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindIndustryHistoryStoredProcedure CreateFindIndustryHistoryStoredProcedure(IndustryHistory industryHistory)
            {
                // Initial Value
                FindIndustryHistoryStoredProcedure findIndustryHistoryStoredProcedure = null;

                // verify industryHistory exists
                if(industryHistory != null)
                {
                    // Instanciate findIndustryHistoryStoredProcedure
                    findIndustryHistoryStoredProcedure = new FindIndustryHistoryStoredProcedure();

                    // Now create parameters for this procedure
                    findIndustryHistoryStoredProcedure.Parameters = CreatePrimaryKeyParameter(industryHistory);
                }

                // return value
                return findIndustryHistoryStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(IndustryHistory industryHistory)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new industryHistory.
            /// </summary>
            /// <param name="industryHistory">The 'IndustryHistory' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(IndustryHistory industryHistory)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[7];
                SqlParameter param = null;

                // verify industryHistoryexists
                if(industryHistory != null)
                {
                    // Create [Advancers] parameter
                    param = new SqlParameter("@Advancers", industryHistory.Advancers);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [AveragePercentChange] parameter
                    param = new SqlParameter("@AveragePercentChange", industryHistory.AveragePercentChange);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [Date] Parameter
                    param = new SqlParameter("@Date", SqlDbType.DateTime);

                    // If industryHistory.Date does not exist.
                    if (industryHistory.Date.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = industryHistory.Date;
                    }
                    // set parameters[2]
                    parameters[2] = param;

                    // Create [Decliners] parameter
                    param = new SqlParameter("@Decliners", industryHistory.Decliners);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [IndustryId] parameter
                    param = new SqlParameter("@IndustryId", industryHistory.IndustryId);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [Score] parameter
                    param = new SqlParameter("@Score", industryHistory.Score);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [Streak] parameter
                    param = new SqlParameter("@Streak", industryHistory.Streak);

                    // set parameters[6]
                    parameters[6] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertIndustryHistoryStoredProcedure(IndustryHistory industryHistory)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertIndustryHistoryStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'IndustryHistory_Insert'.
            /// </summary>
            /// <param name="industryHistory"The 'IndustryHistory' object to insert</param>
            /// <returns>An instance of a 'InsertIndustryHistoryStoredProcedure' object.</returns>
            public static InsertIndustryHistoryStoredProcedure CreateInsertIndustryHistoryStoredProcedure(IndustryHistory industryHistory)
            {
                // Initial Value
                InsertIndustryHistoryStoredProcedure insertIndustryHistoryStoredProcedure = null;

                // verify industryHistory exists
                if(industryHistory != null)
                {
                    // Instanciate insertIndustryHistoryStoredProcedure
                    insertIndustryHistoryStoredProcedure = new InsertIndustryHistoryStoredProcedure();

                    // Now create parameters for this procedure
                    insertIndustryHistoryStoredProcedure.Parameters = CreateInsertParameters(industryHistory);
                }

                // return value
                return insertIndustryHistoryStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(IndustryHistory industryHistory)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing industryHistory.
            /// </summary>
            /// <param name="industryHistory">The 'IndustryHistory' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(IndustryHistory industryHistory)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[8];
                SqlParameter param = null;

                // verify industryHistoryexists
                if(industryHistory != null)
                {
                    // Create parameter for [Advancers]
                    param = new SqlParameter("@Advancers", industryHistory.Advancers);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [AveragePercentChange]
                    param = new SqlParameter("@AveragePercentChange", industryHistory.AveragePercentChange);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [Date]
                    // Create [Date] Parameter
                    param = new SqlParameter("@Date", SqlDbType.DateTime);

                    // If industryHistory.Date does not exist.
                    if (industryHistory.Date.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = industryHistory.Date;
                    }

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [Decliners]
                    param = new SqlParameter("@Decliners", industryHistory.Decliners);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [IndustryId]
                    param = new SqlParameter("@IndustryId", industryHistory.IndustryId);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [Score]
                    param = new SqlParameter("@Score", industryHistory.Score);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [Streak]
                    param = new SqlParameter("@Streak", industryHistory.Streak);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", industryHistory.Id);
                    parameters[7] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateIndustryHistoryStoredProcedure(IndustryHistory industryHistory)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateIndustryHistoryStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'IndustryHistory_Update'.
            /// </summary>
            /// <param name="industryHistory"The 'IndustryHistory' object to update</param>
            /// <returns>An instance of a 'UpdateIndustryHistoryStoredProcedure</returns>
            public static UpdateIndustryHistoryStoredProcedure CreateUpdateIndustryHistoryStoredProcedure(IndustryHistory industryHistory)
            {
                // Initial Value
                UpdateIndustryHistoryStoredProcedure updateIndustryHistoryStoredProcedure = null;

                // verify industryHistory exists
                if(industryHistory != null)
                {
                    // Instanciate updateIndustryHistoryStoredProcedure
                    updateIndustryHistoryStoredProcedure = new UpdateIndustryHistoryStoredProcedure();

                    // Now create parameters for this procedure
                    updateIndustryHistoryStoredProcedure.Parameters = CreateUpdateParameters(industryHistory);
                }

                // return value
                return updateIndustryHistoryStoredProcedure;
            }
            #endregion

            #region CreateFetchAllIndustryHistorysStoredProcedure(IndustryHistory industryHistory)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllIndustryHistorysStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'IndustryHistory_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllIndustryHistorysStoredProcedure' object.</returns>
            public static FetchAllIndustryHistorysStoredProcedure CreateFetchAllIndustryHistorysStoredProcedure(IndustryHistory industryHistory)
            {
                // Initial value
                FetchAllIndustryHistorysStoredProcedure fetchAllIndustryHistorysStoredProcedure = new FetchAllIndustryHistorysStoredProcedure();

                // return value
                return fetchAllIndustryHistorysStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
