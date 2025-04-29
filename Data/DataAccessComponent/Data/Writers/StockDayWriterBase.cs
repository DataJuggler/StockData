

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

    #region class StockDayWriterBase
    /// <summary>
    /// This class is used for converting a 'StockDay' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class StockDayWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(StockDay stockDay)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='stockDay'>The 'StockDay' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(StockDay stockDay)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (stockDay != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", stockDay.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteStockDayStoredProcedure(StockDay stockDay)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteStockDay'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'StockDay_Delete'.
            /// </summary>
            /// <param name="stockDay">The 'StockDay' to Delete.</param>
            /// <returns>An instance of a 'DeleteStockDayStoredProcedure' object.</returns>
            public static DeleteStockDayStoredProcedure CreateDeleteStockDayStoredProcedure(StockDay stockDay)
            {
                // Initial Value
                DeleteStockDayStoredProcedure deleteStockDayStoredProcedure = new DeleteStockDayStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteStockDayStoredProcedure.Parameters = CreatePrimaryKeyParameter(stockDay);

                // return value
                return deleteStockDayStoredProcedure;
            }
            #endregion

            #region CreateFindStockDayStoredProcedure(StockDay stockDay)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindStockDayStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'StockDay_Find'.
            /// </summary>
            /// <param name="stockDay">The 'StockDay' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindStockDayStoredProcedure CreateFindStockDayStoredProcedure(StockDay stockDay)
            {
                // Initial Value
                FindStockDayStoredProcedure findStockDayStoredProcedure = null;

                // verify stockDay exists
                if(stockDay != null)
                {
                    // Instanciate findStockDayStoredProcedure
                    findStockDayStoredProcedure = new FindStockDayStoredProcedure();

                    // Now create parameters for this procedure
                    findStockDayStoredProcedure.Parameters = CreatePrimaryKeyParameter(stockDay);
                }

                // return value
                return findStockDayStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(StockDay stockDay)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new stockDay.
            /// </summary>
            /// <param name="stockDay">The 'StockDay' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(StockDay stockDay)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[3];
                SqlParameter param = null;

                // verify stockDayexists
                if(stockDay != null)
                {
                    // Create [Date] Parameter
                    param = new SqlParameter("@Date", SqlDbType.DateTime);

                    // If stockDay.Date does not exist.
                    if (stockDay.Date.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = stockDay.Date;
                    }
                    // set parameters[0]
                    parameters[0] = param;

                    // Create [IndustryProcessed] parameter
                    param = new SqlParameter("@IndustryProcessed", stockDay.IndustryProcessed);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [SectorProcessed] parameter
                    param = new SqlParameter("@SectorProcessed", stockDay.SectorProcessed);

                    // set parameters[2]
                    parameters[2] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertStockDayStoredProcedure(StockDay stockDay)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertStockDayStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'StockDay_Insert'.
            /// </summary>
            /// <param name="stockDay"The 'StockDay' object to insert</param>
            /// <returns>An instance of a 'InsertStockDayStoredProcedure' object.</returns>
            public static InsertStockDayStoredProcedure CreateInsertStockDayStoredProcedure(StockDay stockDay)
            {
                // Initial Value
                InsertStockDayStoredProcedure insertStockDayStoredProcedure = null;

                // verify stockDay exists
                if(stockDay != null)
                {
                    // Instanciate insertStockDayStoredProcedure
                    insertStockDayStoredProcedure = new InsertStockDayStoredProcedure();

                    // Now create parameters for this procedure
                    insertStockDayStoredProcedure.Parameters = CreateInsertParameters(stockDay);
                }

                // return value
                return insertStockDayStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(StockDay stockDay)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing stockDay.
            /// </summary>
            /// <param name="stockDay">The 'StockDay' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(StockDay stockDay)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[4];
                SqlParameter param = null;

                // verify stockDayexists
                if(stockDay != null)
                {
                    // Create parameter for [Date]
                    // Create [Date] Parameter
                    param = new SqlParameter("@Date", SqlDbType.DateTime);

                    // If stockDay.Date does not exist.
                    if (stockDay.Date.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = stockDay.Date;
                    }

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [IndustryProcessed]
                    param = new SqlParameter("@IndustryProcessed", stockDay.IndustryProcessed);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [SectorProcessed]
                    param = new SqlParameter("@SectorProcessed", stockDay.SectorProcessed);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", stockDay.Id);
                    parameters[3] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateStockDayStoredProcedure(StockDay stockDay)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateStockDayStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'StockDay_Update'.
            /// </summary>
            /// <param name="stockDay"The 'StockDay' object to update</param>
            /// <returns>An instance of a 'UpdateStockDayStoredProcedure</returns>
            public static UpdateStockDayStoredProcedure CreateUpdateStockDayStoredProcedure(StockDay stockDay)
            {
                // Initial Value
                UpdateStockDayStoredProcedure updateStockDayStoredProcedure = null;

                // verify stockDay exists
                if(stockDay != null)
                {
                    // Instanciate updateStockDayStoredProcedure
                    updateStockDayStoredProcedure = new UpdateStockDayStoredProcedure();

                    // Now create parameters for this procedure
                    updateStockDayStoredProcedure.Parameters = CreateUpdateParameters(stockDay);
                }

                // return value
                return updateStockDayStoredProcedure;
            }
            #endregion

            #region CreateFetchAllStockDaysStoredProcedure(StockDay stockDay)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllStockDaysStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'StockDay_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllStockDaysStoredProcedure' object.</returns>
            public static FetchAllStockDaysStoredProcedure CreateFetchAllStockDaysStoredProcedure(StockDay stockDay)
            {
                // Initial value
                FetchAllStockDaysStoredProcedure fetchAllStockDaysStoredProcedure = new FetchAllStockDaysStoredProcedure();

                // return value
                return fetchAllStockDaysStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
