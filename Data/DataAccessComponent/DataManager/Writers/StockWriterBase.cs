

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

    #region class StockWriterBase
    /// <summary>
    /// This class is used for converting a 'Stock' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class StockWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(Stock stock)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='stock'>The 'Stock' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(Stock stock)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (stock != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", stock.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteStockStoredProcedure(Stock stock)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteStock'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Stock_Delete'.
            /// </summary>
            /// <param name="stock">The 'Stock' to Delete.</param>
            /// <returns>An instance of a 'DeleteStockStoredProcedure' object.</returns>
            public static DeleteStockStoredProcedure CreateDeleteStockStoredProcedure(Stock stock)
            {
                // Initial Value
                DeleteStockStoredProcedure deleteStockStoredProcedure = new DeleteStockStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteStockStoredProcedure.Parameters = CreatePrimaryKeyParameter(stock);

                // return value
                return deleteStockStoredProcedure;
            }
            #endregion

            #region CreateFindStockStoredProcedure(Stock stock)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindStockStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Stock_Find'.
            /// </summary>
            /// <param name="stock">The 'Stock' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindStockStoredProcedure CreateFindStockStoredProcedure(Stock stock)
            {
                // Initial Value
                FindStockStoredProcedure findStockStoredProcedure = null;

                // verify stock exists
                if(stock != null)
                {
                    // Instanciate findStockStoredProcedure
                    findStockStoredProcedure = new FindStockStoredProcedure();

                    // Now create parameters for this procedure
                    findStockStoredProcedure.Parameters = CreatePrimaryKeyParameter(stock);
                }

                // return value
                return findStockStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(Stock stock)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new stock.
            /// </summary>
            /// <param name="stock">The 'Stock' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(Stock stock)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[12];
                SqlParameter param = null;

                // verify stockexists
                if(stock != null)
                {
                    // Create [AverageDailyVolume] parameter
                    param = new SqlParameter("@AverageDailyVolume", stock.AverageDailyVolume);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [Country] parameter
                    param = new SqlParameter("@Country", stock.Country);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [DaysBelowMinVolume] parameter
                    param = new SqlParameter("@DaysBelowMinVolume", stock.DaysBelowMinVolume);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [Exchange] parameter
                    param = new SqlParameter("@Exchange", stock.Exchange);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [Industry] parameter
                    param = new SqlParameter("@Industry", stock.Industry);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [IPOYear] parameter
                    param = new SqlParameter("@IPOYear", stock.IPOYear);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [LastClose] parameter
                    param = new SqlParameter("@LastClose", stock.LastClose);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create [Name] parameter
                    param = new SqlParameter("@Name", stock.Name);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create [Sector] parameter
                    param = new SqlParameter("@Sector", stock.Sector);

                    // set parameters[8]
                    parameters[8] = param;

                    // Create [Streak] parameter
                    param = new SqlParameter("@Streak", stock.Streak);

                    // set parameters[9]
                    parameters[9] = param;

                    // Create [Symbol] parameter
                    param = new SqlParameter("@Symbol", stock.Symbol);

                    // set parameters[10]
                    parameters[10] = param;

                    // Create [Track] parameter
                    param = new SqlParameter("@Track", stock.Track);

                    // set parameters[11]
                    parameters[11] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertStockStoredProcedure(Stock stock)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertStockStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Stock_Insert'.
            /// </summary>
            /// <param name="stock"The 'Stock' object to insert</param>
            /// <returns>An instance of a 'InsertStockStoredProcedure' object.</returns>
            public static InsertStockStoredProcedure CreateInsertStockStoredProcedure(Stock stock)
            {
                // Initial Value
                InsertStockStoredProcedure insertStockStoredProcedure = null;

                // verify stock exists
                if(stock != null)
                {
                    // Instanciate insertStockStoredProcedure
                    insertStockStoredProcedure = new InsertStockStoredProcedure();

                    // Now create parameters for this procedure
                    insertStockStoredProcedure.Parameters = CreateInsertParameters(stock);
                }

                // return value
                return insertStockStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(Stock stock)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing stock.
            /// </summary>
            /// <param name="stock">The 'Stock' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(Stock stock)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[13];
                SqlParameter param = null;

                // verify stockexists
                if(stock != null)
                {
                    // Create parameter for [AverageDailyVolume]
                    param = new SqlParameter("@AverageDailyVolume", stock.AverageDailyVolume);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [Country]
                    param = new SqlParameter("@Country", stock.Country);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [DaysBelowMinVolume]
                    param = new SqlParameter("@DaysBelowMinVolume", stock.DaysBelowMinVolume);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [Exchange]
                    param = new SqlParameter("@Exchange", stock.Exchange);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [Industry]
                    param = new SqlParameter("@Industry", stock.Industry);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [IPOYear]
                    param = new SqlParameter("@IPOYear", stock.IPOYear);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [LastClose]
                    param = new SqlParameter("@LastClose", stock.LastClose);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [Name]
                    param = new SqlParameter("@Name", stock.Name);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create parameter for [Sector]
                    param = new SqlParameter("@Sector", stock.Sector);

                    // set parameters[8]
                    parameters[8] = param;

                    // Create parameter for [Streak]
                    param = new SqlParameter("@Streak", stock.Streak);

                    // set parameters[9]
                    parameters[9] = param;

                    // Create parameter for [Symbol]
                    param = new SqlParameter("@Symbol", stock.Symbol);

                    // set parameters[10]
                    parameters[10] = param;

                    // Create parameter for [Track]
                    param = new SqlParameter("@Track", stock.Track);

                    // set parameters[11]
                    parameters[11] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", stock.Id);
                    parameters[12] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateStockStoredProcedure(Stock stock)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateStockStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Stock_Update'.
            /// </summary>
            /// <param name="stock"The 'Stock' object to update</param>
            /// <returns>An instance of a 'UpdateStockStoredProcedure</returns>
            public static UpdateStockStoredProcedure CreateUpdateStockStoredProcedure(Stock stock)
            {
                // Initial Value
                UpdateStockStoredProcedure updateStockStoredProcedure = null;

                // verify stock exists
                if(stock != null)
                {
                    // Instanciate updateStockStoredProcedure
                    updateStockStoredProcedure = new UpdateStockStoredProcedure();

                    // Now create parameters for this procedure
                    updateStockStoredProcedure.Parameters = CreateUpdateParameters(stock);
                }

                // return value
                return updateStockStoredProcedure;
            }
            #endregion

            #region CreateFetchAllStocksStoredProcedure(Stock stock)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllStocksStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Stock_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllStocksStoredProcedure' object.</returns>
            public static FetchAllStocksStoredProcedure CreateFetchAllStocksStoredProcedure(Stock stock)
            {
                // Initial value
                FetchAllStocksStoredProcedure fetchAllStocksStoredProcedure = new FetchAllStocksStoredProcedure();

                // return value
                return fetchAllStocksStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
