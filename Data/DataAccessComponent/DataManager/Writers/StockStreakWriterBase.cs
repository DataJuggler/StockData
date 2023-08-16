

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

    #region class StockStreakWriterBase
    /// <summary>
    /// This class is used for converting a 'StockStreak' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class StockStreakWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(StockStreak stockStreak)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='stockStreak'>The 'StockStreak' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(StockStreak stockStreak)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (stockStreak != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", stockStreak.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteStockStreakStoredProcedure(StockStreak stockStreak)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteStockStreak'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'StockStreak_Delete'.
            /// </summary>
            /// <param name="stockStreak">The 'StockStreak' to Delete.</param>
            /// <returns>An instance of a 'DeleteStockStreakStoredProcedure' object.</returns>
            public static DeleteStockStreakStoredProcedure CreateDeleteStockStreakStoredProcedure(StockStreak stockStreak)
            {
                // Initial Value
                DeleteStockStreakStoredProcedure deleteStockStreakStoredProcedure = new DeleteStockStreakStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteStockStreakStoredProcedure.Parameters = CreatePrimaryKeyParameter(stockStreak);

                // return value
                return deleteStockStreakStoredProcedure;
            }
            #endregion

            #region CreateFindStockStreakStoredProcedure(StockStreak stockStreak)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindStockStreakStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'StockStreak_Find'.
            /// </summary>
            /// <param name="stockStreak">The 'StockStreak' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindStockStreakStoredProcedure CreateFindStockStreakStoredProcedure(StockStreak stockStreak)
            {
                // Initial Value
                FindStockStreakStoredProcedure findStockStreakStoredProcedure = null;

                // verify stockStreak exists
                if(stockStreak != null)
                {
                    // Instanciate findStockStreakStoredProcedure
                    findStockStreakStoredProcedure = new FindStockStreakStoredProcedure();

                    // Now create parameters for this procedure
                    findStockStreakStoredProcedure.Parameters = CreatePrimaryKeyParameter(stockStreak);
                }

                // return value
                return findStockStreakStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(StockStreak stockStreak)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new stockStreak.
            /// </summary>
            /// <param name="stockStreak">The 'StockStreak' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(StockStreak stockStreak)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[9];
                SqlParameter param = null;

                // verify stockStreakexists
                if(stockStreak != null)
                {
                    // Create [CurrentStreak] parameter
                    param = new SqlParameter("@CurrentStreak", stockStreak.CurrentStreak);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [StockId] parameter
                    param = new SqlParameter("@StockId", stockStreak.StockId);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [StreakContinuing] parameter
                    param = new SqlParameter("@StreakContinuing", stockStreak.StreakContinuing);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [StreakDays] parameter
                    param = new SqlParameter("@StreakDays", stockStreak.StreakDays);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [StreakEndDate] Parameter
                    param = new SqlParameter("@StreakEndDate", SqlDbType.DateTime);

                    // If stockStreak.StreakEndDate does not exist.
                    if (stockStreak.StreakEndDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = stockStreak.StreakEndDate;
                    }
                    // set parameters[4]
                    parameters[4] = param;

                    // Create [StreakEndPrice] parameter
                    param = new SqlParameter("@StreakEndPrice", stockStreak.StreakEndPrice);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [StreakStartDate] Parameter
                    param = new SqlParameter("@StreakStartDate", SqlDbType.DateTime);

                    // If stockStreak.StreakStartDate does not exist.
                    if (stockStreak.StreakStartDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = stockStreak.StreakStartDate;
                    }
                    // set parameters[6]
                    parameters[6] = param;

                    // Create [StreakStartPrice] parameter
                    param = new SqlParameter("@StreakStartPrice", stockStreak.StreakStartPrice);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create [StreakType] parameter
                    param = new SqlParameter("@StreakType", stockStreak.StreakType);

                    // set parameters[8]
                    parameters[8] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertStockStreakStoredProcedure(StockStreak stockStreak)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertStockStreakStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'StockStreak_Insert'.
            /// </summary>
            /// <param name="stockStreak"The 'StockStreak' object to insert</param>
            /// <returns>An instance of a 'InsertStockStreakStoredProcedure' object.</returns>
            public static InsertStockStreakStoredProcedure CreateInsertStockStreakStoredProcedure(StockStreak stockStreak)
            {
                // Initial Value
                InsertStockStreakStoredProcedure insertStockStreakStoredProcedure = null;

                // verify stockStreak exists
                if(stockStreak != null)
                {
                    // Instanciate insertStockStreakStoredProcedure
                    insertStockStreakStoredProcedure = new InsertStockStreakStoredProcedure();

                    // Now create parameters for this procedure
                    insertStockStreakStoredProcedure.Parameters = CreateInsertParameters(stockStreak);
                }

                // return value
                return insertStockStreakStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(StockStreak stockStreak)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing stockStreak.
            /// </summary>
            /// <param name="stockStreak">The 'StockStreak' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(StockStreak stockStreak)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[10];
                SqlParameter param = null;

                // verify stockStreakexists
                if(stockStreak != null)
                {
                    // Create parameter for [CurrentStreak]
                    param = new SqlParameter("@CurrentStreak", stockStreak.CurrentStreak);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [StockId]
                    param = new SqlParameter("@StockId", stockStreak.StockId);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [StreakContinuing]
                    param = new SqlParameter("@StreakContinuing", stockStreak.StreakContinuing);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [StreakDays]
                    param = new SqlParameter("@StreakDays", stockStreak.StreakDays);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [StreakEndDate]
                    // Create [StreakEndDate] Parameter
                    param = new SqlParameter("@StreakEndDate", SqlDbType.DateTime);

                    // If stockStreak.StreakEndDate does not exist.
                    if (stockStreak.StreakEndDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = stockStreak.StreakEndDate;
                    }

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [StreakEndPrice]
                    param = new SqlParameter("@StreakEndPrice", stockStreak.StreakEndPrice);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [StreakStartDate]
                    // Create [StreakStartDate] Parameter
                    param = new SqlParameter("@StreakStartDate", SqlDbType.DateTime);

                    // If stockStreak.StreakStartDate does not exist.
                    if (stockStreak.StreakStartDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = stockStreak.StreakStartDate;
                    }

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [StreakStartPrice]
                    param = new SqlParameter("@StreakStartPrice", stockStreak.StreakStartPrice);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create parameter for [StreakType]
                    param = new SqlParameter("@StreakType", stockStreak.StreakType);

                    // set parameters[8]
                    parameters[8] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", stockStreak.Id);
                    parameters[9] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateStockStreakStoredProcedure(StockStreak stockStreak)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateStockStreakStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'StockStreak_Update'.
            /// </summary>
            /// <param name="stockStreak"The 'StockStreak' object to update</param>
            /// <returns>An instance of a 'UpdateStockStreakStoredProcedure</returns>
            public static UpdateStockStreakStoredProcedure CreateUpdateStockStreakStoredProcedure(StockStreak stockStreak)
            {
                // Initial Value
                UpdateStockStreakStoredProcedure updateStockStreakStoredProcedure = null;

                // verify stockStreak exists
                if(stockStreak != null)
                {
                    // Instanciate updateStockStreakStoredProcedure
                    updateStockStreakStoredProcedure = new UpdateStockStreakStoredProcedure();

                    // Now create parameters for this procedure
                    updateStockStreakStoredProcedure.Parameters = CreateUpdateParameters(stockStreak);
                }

                // return value
                return updateStockStreakStoredProcedure;
            }
            #endregion

            #region CreateFetchAllStockStreaksStoredProcedure(StockStreak stockStreak)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllStockStreaksStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'StockStreak_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllStockStreaksStoredProcedure' object.</returns>
            public static FetchAllStockStreaksStoredProcedure CreateFetchAllStockStreaksStoredProcedure(StockStreak stockStreak)
            {
                // Initial value
                FetchAllStockStreaksStoredProcedure fetchAllStockStreaksStoredProcedure = new FetchAllStockStreaksStoredProcedure();

                // return value
                return fetchAllStockStreaksStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
