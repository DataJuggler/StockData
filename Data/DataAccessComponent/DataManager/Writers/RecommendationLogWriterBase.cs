

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


namespace DataAccessComponent.DataManager.Writers
{

    #region class RecommendationLogWriterBase
    /// <summary>
    /// This class is used for converting a 'RecommendationLog' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class RecommendationLogWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(RecommendationLog recommendationLog)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='recommendationLog'>The 'RecommendationLog' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(RecommendationLog recommendationLog)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (recommendationLog != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", recommendationLog.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteRecommendationLogStoredProcedure(RecommendationLog recommendationLog)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteRecommendationLog'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'RecommendationLog_Delete'.
            /// </summary>
            /// <param name="recommendationLog">The 'RecommendationLog' to Delete.</param>
            /// <returns>An instance of a 'DeleteRecommendationLogStoredProcedure' object.</returns>
            public static DeleteRecommendationLogStoredProcedure CreateDeleteRecommendationLogStoredProcedure(RecommendationLog recommendationLog)
            {
                // Initial Value
                DeleteRecommendationLogStoredProcedure deleteRecommendationLogStoredProcedure = new DeleteRecommendationLogStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteRecommendationLogStoredProcedure.Parameters = CreatePrimaryKeyParameter(recommendationLog);

                // return value
                return deleteRecommendationLogStoredProcedure;
            }
            #endregion

            #region CreateFindRecommendationLogStoredProcedure(RecommendationLog recommendationLog)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindRecommendationLogStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'RecommendationLog_Find'.
            /// </summary>
            /// <param name="recommendationLog">The 'RecommendationLog' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindRecommendationLogStoredProcedure CreateFindRecommendationLogStoredProcedure(RecommendationLog recommendationLog)
            {
                // Initial Value
                FindRecommendationLogStoredProcedure findRecommendationLogStoredProcedure = null;

                // verify recommendationLog exists
                if(recommendationLog != null)
                {
                    // Instanciate findRecommendationLogStoredProcedure
                    findRecommendationLogStoredProcedure = new FindRecommendationLogStoredProcedure();

                    // Now create parameters for this procedure
                    findRecommendationLogStoredProcedure.Parameters = CreatePrimaryKeyParameter(recommendationLog);
                }

                // return value
                return findRecommendationLogStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(RecommendationLog recommendationLog)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new recommendationLog.
            /// </summary>
            /// <param name="recommendationLog">The 'RecommendationLog' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(RecommendationLog recommendationLog)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[16];
                SqlParameter param = null;

                // verify recommendationLogexists
                if(recommendationLog != null)
                {
                    // Create [CloseScore] parameter
                    param = new SqlParameter("@CloseScore", recommendationLog.CloseScore);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [Industry] parameter
                    param = new SqlParameter("@Industry", recommendationLog.Industry);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [IndustryScore] parameter
                    param = new SqlParameter("@IndustryScore", recommendationLog.IndustryScore);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [IndustryStreak] parameter
                    param = new SqlParameter("@IndustryStreak", recommendationLog.IndustryStreak);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [LastClose] parameter
                    param = new SqlParameter("@LastClose", recommendationLog.LastClose);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [LastPercentChange] parameter
                    param = new SqlParameter("@LastPercentChange", recommendationLog.LastPercentChange);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [Score] parameter
                    param = new SqlParameter("@Score", recommendationLog.Score);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create [Sector] parameter
                    param = new SqlParameter("@Sector", recommendationLog.Sector);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create [SectorScore] parameter
                    param = new SqlParameter("@SectorScore", recommendationLog.SectorScore);

                    // set parameters[8]
                    parameters[8] = param;

                    // Create [SectorStreak] parameter
                    param = new SqlParameter("@SectorStreak", recommendationLog.SectorStreak);

                    // set parameters[9]
                    parameters[9] = param;

                    // Create [StockDate] Parameter
                    param = new SqlParameter("@StockDate", SqlDbType.DateTime);

                    // If recommendationLog.StockDate does not exist.
                    if (recommendationLog.StockDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = recommendationLog.StockDate;
                    }
                    // set parameters[10]
                    parameters[10] = param;

                    // Create [StockName] parameter
                    param = new SqlParameter("@StockName", recommendationLog.StockName);

                    // set parameters[11]
                    parameters[11] = param;

                    // Create [Streak] parameter
                    param = new SqlParameter("@Streak", recommendationLog.Streak);

                    // set parameters[12]
                    parameters[12] = param;

                    // Create [StreakPercentChange] parameter
                    param = new SqlParameter("@StreakPercentChange", recommendationLog.StreakPercentChange);

                    // set parameters[13]
                    parameters[13] = param;

                    // Create [Symbol] parameter
                    param = new SqlParameter("@Symbol", recommendationLog.Symbol);

                    // set parameters[14]
                    parameters[14] = param;

                    // Create [VolumeScore] parameter
                    param = new SqlParameter("@VolumeScore", recommendationLog.VolumeScore);

                    // set parameters[15]
                    parameters[15] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertRecommendationLogStoredProcedure(RecommendationLog recommendationLog)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertRecommendationLogStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'RecommendationLog_Insert'.
            /// </summary>
            /// <param name="recommendationLog"The 'RecommendationLog' object to insert</param>
            /// <returns>An instance of a 'InsertRecommendationLogStoredProcedure' object.</returns>
            public static InsertRecommendationLogStoredProcedure CreateInsertRecommendationLogStoredProcedure(RecommendationLog recommendationLog)
            {
                // Initial Value
                InsertRecommendationLogStoredProcedure insertRecommendationLogStoredProcedure = null;

                // verify recommendationLog exists
                if(recommendationLog != null)
                {
                    // Instanciate insertRecommendationLogStoredProcedure
                    insertRecommendationLogStoredProcedure = new InsertRecommendationLogStoredProcedure();

                    // Now create parameters for this procedure
                    insertRecommendationLogStoredProcedure.Parameters = CreateInsertParameters(recommendationLog);
                }

                // return value
                return insertRecommendationLogStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(RecommendationLog recommendationLog)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing recommendationLog.
            /// </summary>
            /// <param name="recommendationLog">The 'RecommendationLog' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(RecommendationLog recommendationLog)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[17];
                SqlParameter param = null;

                // verify recommendationLogexists
                if(recommendationLog != null)
                {
                    // Create parameter for [CloseScore]
                    param = new SqlParameter("@CloseScore", recommendationLog.CloseScore);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [Industry]
                    param = new SqlParameter("@Industry", recommendationLog.Industry);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [IndustryScore]
                    param = new SqlParameter("@IndustryScore", recommendationLog.IndustryScore);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [IndustryStreak]
                    param = new SqlParameter("@IndustryStreak", recommendationLog.IndustryStreak);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [LastClose]
                    param = new SqlParameter("@LastClose", recommendationLog.LastClose);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [LastPercentChange]
                    param = new SqlParameter("@LastPercentChange", recommendationLog.LastPercentChange);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [Score]
                    param = new SqlParameter("@Score", recommendationLog.Score);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [Sector]
                    param = new SqlParameter("@Sector", recommendationLog.Sector);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create parameter for [SectorScore]
                    param = new SqlParameter("@SectorScore", recommendationLog.SectorScore);

                    // set parameters[8]
                    parameters[8] = param;

                    // Create parameter for [SectorStreak]
                    param = new SqlParameter("@SectorStreak", recommendationLog.SectorStreak);

                    // set parameters[9]
                    parameters[9] = param;

                    // Create parameter for [StockDate]
                    // Create [StockDate] Parameter
                    param = new SqlParameter("@StockDate", SqlDbType.DateTime);

                    // If recommendationLog.StockDate does not exist.
                    if (recommendationLog.StockDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = recommendationLog.StockDate;
                    }

                    // set parameters[10]
                    parameters[10] = param;

                    // Create parameter for [StockName]
                    param = new SqlParameter("@StockName", recommendationLog.StockName);

                    // set parameters[11]
                    parameters[11] = param;

                    // Create parameter for [Streak]
                    param = new SqlParameter("@Streak", recommendationLog.Streak);

                    // set parameters[12]
                    parameters[12] = param;

                    // Create parameter for [StreakPercentChange]
                    param = new SqlParameter("@StreakPercentChange", recommendationLog.StreakPercentChange);

                    // set parameters[13]
                    parameters[13] = param;

                    // Create parameter for [Symbol]
                    param = new SqlParameter("@Symbol", recommendationLog.Symbol);

                    // set parameters[14]
                    parameters[14] = param;

                    // Create parameter for [VolumeScore]
                    param = new SqlParameter("@VolumeScore", recommendationLog.VolumeScore);

                    // set parameters[15]
                    parameters[15] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", recommendationLog.Id);
                    parameters[16] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateRecommendationLogStoredProcedure(RecommendationLog recommendationLog)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateRecommendationLogStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'RecommendationLog_Update'.
            /// </summary>
            /// <param name="recommendationLog"The 'RecommendationLog' object to update</param>
            /// <returns>An instance of a 'UpdateRecommendationLogStoredProcedure</returns>
            public static UpdateRecommendationLogStoredProcedure CreateUpdateRecommendationLogStoredProcedure(RecommendationLog recommendationLog)
            {
                // Initial Value
                UpdateRecommendationLogStoredProcedure updateRecommendationLogStoredProcedure = null;

                // verify recommendationLog exists
                if(recommendationLog != null)
                {
                    // Instanciate updateRecommendationLogStoredProcedure
                    updateRecommendationLogStoredProcedure = new UpdateRecommendationLogStoredProcedure();

                    // Now create parameters for this procedure
                    updateRecommendationLogStoredProcedure.Parameters = CreateUpdateParameters(recommendationLog);
                }

                // return value
                return updateRecommendationLogStoredProcedure;
            }
            #endregion

            #region CreateFetchAllRecommendationLogsStoredProcedure(RecommendationLog recommendationLog)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllRecommendationLogsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'RecommendationLog_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllRecommendationLogsStoredProcedure' object.</returns>
            public static FetchAllRecommendationLogsStoredProcedure CreateFetchAllRecommendationLogsStoredProcedure(RecommendationLog recommendationLog)
            {
                // Initial value
                FetchAllRecommendationLogsStoredProcedure fetchAllRecommendationLogsStoredProcedure = new FetchAllRecommendationLogsStoredProcedure();

                // return value
                return fetchAllRecommendationLogsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
