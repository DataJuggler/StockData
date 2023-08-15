

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

    #region class DailyPriceDataWriterBase
    /// <summary>
    /// This class is used for converting a 'DailyPriceData' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class DailyPriceDataWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(DailyPriceData dailyPriceData)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='dailyPriceData'>The 'DailyPriceData' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(DailyPriceData dailyPriceData)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (dailyPriceData != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", dailyPriceData.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteDailyPriceDataStoredProcedure(DailyPriceData dailyPriceData)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteDailyPriceData'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DailyPriceData_Delete'.
            /// </summary>
            /// <param name="dailyPriceData">The 'DailyPriceData' to Delete.</param>
            /// <returns>An instance of a 'DeleteDailyPriceDataStoredProcedure' object.</returns>
            public static DeleteDailyPriceDataStoredProcedure CreateDeleteDailyPriceDataStoredProcedure(DailyPriceData dailyPriceData)
            {
                // Initial Value
                DeleteDailyPriceDataStoredProcedure deleteDailyPriceDataStoredProcedure = new DeleteDailyPriceDataStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteDailyPriceDataStoredProcedure.Parameters = CreatePrimaryKeyParameter(dailyPriceData);

                // return value
                return deleteDailyPriceDataStoredProcedure;
            }
            #endregion

            #region CreateFindDailyPriceDataStoredProcedure(DailyPriceData dailyPriceData)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindDailyPriceDataStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DailyPriceData_Find'.
            /// </summary>
            /// <param name="dailyPriceData">The 'DailyPriceData' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindDailyPriceDataStoredProcedure CreateFindDailyPriceDataStoredProcedure(DailyPriceData dailyPriceData)
            {
                // Initial Value
                FindDailyPriceDataStoredProcedure findDailyPriceDataStoredProcedure = null;

                // verify dailyPriceData exists
                if(dailyPriceData != null)
                {
                    // Instanciate findDailyPriceDataStoredProcedure
                    findDailyPriceDataStoredProcedure = new FindDailyPriceDataStoredProcedure();

                    // Now create parameters for this procedure
                    findDailyPriceDataStoredProcedure.Parameters = CreatePrimaryKeyParameter(dailyPriceData);
                }

                // return value
                return findDailyPriceDataStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(DailyPriceData dailyPriceData)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new dailyPriceData.
            /// </summary>
            /// <param name="dailyPriceData">The 'DailyPriceData' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(DailyPriceData dailyPriceData)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[12];
                SqlParameter param = null;

                // verify dailyPriceDataexists
                if(dailyPriceData != null)
                {
                    // Create [ClosePrice] parameter
                    param = new SqlParameter("@ClosePrice", dailyPriceData.ClosePrice);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [CloseScore] parameter
                    param = new SqlParameter("@CloseScore", dailyPriceData.CloseScore);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [HighPrice] parameter
                    param = new SqlParameter("@HighPrice", dailyPriceData.HighPrice);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [LastCloseOpenSpread] parameter
                    param = new SqlParameter("@LastCloseOpenSpread", dailyPriceData.LastCloseOpenSpread);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [LastCloseOpenStreak] parameter
                    param = new SqlParameter("@LastCloseOpenStreak", dailyPriceData.LastCloseOpenStreak);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [LowPrice] parameter
                    param = new SqlParameter("@LowPrice", dailyPriceData.LowPrice);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [OpenPrice] parameter
                    param = new SqlParameter("@OpenPrice", dailyPriceData.OpenPrice);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create [Spread] parameter
                    param = new SqlParameter("@Spread", dailyPriceData.Spread);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create [StockDate] Parameter
                    param = new SqlParameter("@StockDate", SqlDbType.DateTime);

                    // If dailyPriceData.StockDate does not exist.
                    if (dailyPriceData.StockDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = dailyPriceData.StockDate;
                    }
                    // set parameters[8]
                    parameters[8] = param;

                    // Create [Streak] parameter
                    param = new SqlParameter("@Streak", dailyPriceData.Streak);

                    // set parameters[9]
                    parameters[9] = param;

                    // Create [Symbol] parameter
                    param = new SqlParameter("@Symbol", dailyPriceData.Symbol);

                    // set parameters[10]
                    parameters[10] = param;

                    // Create [Volume] parameter
                    param = new SqlParameter("@Volume", dailyPriceData.Volume);

                    // set parameters[11]
                    parameters[11] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertDailyPriceDataStoredProcedure(DailyPriceData dailyPriceData)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertDailyPriceDataStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DailyPriceData_Insert'.
            /// </summary>
            /// <param name="dailyPriceData"The 'DailyPriceData' object to insert</param>
            /// <returns>An instance of a 'InsertDailyPriceDataStoredProcedure' object.</returns>
            public static InsertDailyPriceDataStoredProcedure CreateInsertDailyPriceDataStoredProcedure(DailyPriceData dailyPriceData)
            {
                // Initial Value
                InsertDailyPriceDataStoredProcedure insertDailyPriceDataStoredProcedure = null;

                // verify dailyPriceData exists
                if(dailyPriceData != null)
                {
                    // Instanciate insertDailyPriceDataStoredProcedure
                    insertDailyPriceDataStoredProcedure = new InsertDailyPriceDataStoredProcedure();

                    // Now create parameters for this procedure
                    insertDailyPriceDataStoredProcedure.Parameters = CreateInsertParameters(dailyPriceData);
                }

                // return value
                return insertDailyPriceDataStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(DailyPriceData dailyPriceData)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing dailyPriceData.
            /// </summary>
            /// <param name="dailyPriceData">The 'DailyPriceData' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(DailyPriceData dailyPriceData)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[13];
                SqlParameter param = null;

                // verify dailyPriceDataexists
                if(dailyPriceData != null)
                {
                    // Create parameter for [ClosePrice]
                    param = new SqlParameter("@ClosePrice", dailyPriceData.ClosePrice);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [CloseScore]
                    param = new SqlParameter("@CloseScore", dailyPriceData.CloseScore);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [HighPrice]
                    param = new SqlParameter("@HighPrice", dailyPriceData.HighPrice);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [LastCloseOpenSpread]
                    param = new SqlParameter("@LastCloseOpenSpread", dailyPriceData.LastCloseOpenSpread);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [LastCloseOpenStreak]
                    param = new SqlParameter("@LastCloseOpenStreak", dailyPriceData.LastCloseOpenStreak);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [LowPrice]
                    param = new SqlParameter("@LowPrice", dailyPriceData.LowPrice);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [OpenPrice]
                    param = new SqlParameter("@OpenPrice", dailyPriceData.OpenPrice);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [Spread]
                    param = new SqlParameter("@Spread", dailyPriceData.Spread);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create parameter for [StockDate]
                    // Create [StockDate] Parameter
                    param = new SqlParameter("@StockDate", SqlDbType.DateTime);

                    // If dailyPriceData.StockDate does not exist.
                    if (dailyPriceData.StockDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = dailyPriceData.StockDate;
                    }

                    // set parameters[8]
                    parameters[8] = param;

                    // Create parameter for [Streak]
                    param = new SqlParameter("@Streak", dailyPriceData.Streak);

                    // set parameters[9]
                    parameters[9] = param;

                    // Create parameter for [Symbol]
                    param = new SqlParameter("@Symbol", dailyPriceData.Symbol);

                    // set parameters[10]
                    parameters[10] = param;

                    // Create parameter for [Volume]
                    param = new SqlParameter("@Volume", dailyPriceData.Volume);

                    // set parameters[11]
                    parameters[11] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", dailyPriceData.Id);
                    parameters[12] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateDailyPriceDataStoredProcedure(DailyPriceData dailyPriceData)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateDailyPriceDataStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DailyPriceData_Update'.
            /// </summary>
            /// <param name="dailyPriceData"The 'DailyPriceData' object to update</param>
            /// <returns>An instance of a 'UpdateDailyPriceDataStoredProcedure</returns>
            public static UpdateDailyPriceDataStoredProcedure CreateUpdateDailyPriceDataStoredProcedure(DailyPriceData dailyPriceData)
            {
                // Initial Value
                UpdateDailyPriceDataStoredProcedure updateDailyPriceDataStoredProcedure = null;

                // verify dailyPriceData exists
                if(dailyPriceData != null)
                {
                    // Instanciate updateDailyPriceDataStoredProcedure
                    updateDailyPriceDataStoredProcedure = new UpdateDailyPriceDataStoredProcedure();

                    // Now create parameters for this procedure
                    updateDailyPriceDataStoredProcedure.Parameters = CreateUpdateParameters(dailyPriceData);
                }

                // return value
                return updateDailyPriceDataStoredProcedure;
            }
            #endregion

            #region CreateFetchAllDailyPriceDatasStoredProcedure(DailyPriceData dailyPriceData)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllDailyPriceDatasStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DailyPriceData_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllDailyPriceDatasStoredProcedure' object.</returns>
            public static FetchAllDailyPriceDatasStoredProcedure CreateFetchAllDailyPriceDatasStoredProcedure(DailyPriceData dailyPriceData)
            {
                // Initial value
                FetchAllDailyPriceDatasStoredProcedure fetchAllDailyPriceDatasStoredProcedure = new FetchAllDailyPriceDatasStoredProcedure();

                // return value
                return fetchAllDailyPriceDatasStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
