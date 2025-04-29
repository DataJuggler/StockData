
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

    #region class DailyPriceDataWriter
    /// <summary>
    /// This class is used for converting a 'DailyPriceData' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class DailyPriceDataWriter : DailyPriceDataWriterBase
    {

        #region Static Methods

            #region CreateFetchAllDailyPriceDatasStoredProcedure(DailyPriceData dailyPriceData)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllDailyPriceDatasStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DailyPriceData_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllDailyPriceDatasStoredProcedure' object.</returns>
            public static new FetchAllDailyPriceDatasStoredProcedure CreateFetchAllDailyPriceDatasStoredProcedure(DailyPriceData dailyPriceData)
            {
                // Initial value
                FetchAllDailyPriceDatasStoredProcedure fetchAllDailyPriceDatasStoredProcedure = new FetchAllDailyPriceDatasStoredProcedure();

                // if the dailyPriceData object exists
                if (dailyPriceData != null)
                {
                    // if LoadBySymbol is true
                    if (dailyPriceData.LoadBySymbol)
                    {
                        // Change the procedure name
                        fetchAllDailyPriceDatasStoredProcedure.ProcedureName = "DailyPriceData_FetchAllForSymbol";
                        
                        // Create the @Symbol parameter
                        fetchAllDailyPriceDatasStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@symbol", dailyPriceData.Symbol);
                    }
                }
                
                // return value
                return fetchAllDailyPriceDatasStoredProcedure;
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
            public static new FindDailyPriceDataStoredProcedure CreateFindDailyPriceDataStoredProcedure(DailyPriceData dailyPriceData)
            {
                // Initial Value
                FindDailyPriceDataStoredProcedure findDailyPriceDataStoredProcedure = null;

                // verify dailyPriceData exists
                if(dailyPriceData != null)
                {
                    // Instanciate findDailyPriceDataStoredProcedure
                    findDailyPriceDataStoredProcedure = new FindDailyPriceDataStoredProcedure();
                    // if dailyPriceData.FindMaxStreakBySymbol is true
                    if (dailyPriceData.FindMaxStreakBySymbol)
                    {
                            // Change the procedure name
                            findDailyPriceDataStoredProcedure.ProcedureName = "DailyPriceData_FindMaxStreakBySymbolSymbol";
                            
                            // Create the @Symbol parameter
                            findDailyPriceDataStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@Symbol", dailyPriceData.Symbol);
                    }
                    // if dailyPriceData.FindMaxStreakBySymbol is true
                    else if (dailyPriceData.FindMaxStreakBySymbol)
                    {
                        // Change the procedure name
                        findDailyPriceDataStoredProcedure.ProcedureName = "DailyPriceData_FindMaxStreakBySymbol";
                        
                        // Create the @Symbol parameter
                        findDailyPriceDataStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@Symbol", dailyPriceData.Symbol);
                    }
                    // if dailyPriceData.FindByStockDateAndSymbol is true
                    else if (dailyPriceData.FindByStockDateAndSymbol)
                    {
                        // Change the procedure name
                        findDailyPriceDataStoredProcedure.ProcedureName = "DailyPriceData_FindByStockDateAndSymbol";
                        
                        // Create the StockDateAndSymbol field set parameters
                        findDailyPriceDataStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@StockDate", dailyPriceData.StockDate, "@Symbol", dailyPriceData.Symbol);
                    }
                    // if dailyPriceData.FindBySymbolAndMostRecent is true
                    else if (dailyPriceData.FindBySymbolAndMostRecent)
                    {
                        // Change the procedure name
                        findDailyPriceDataStoredProcedure.ProcedureName = "DailyPriceData_FindBySymbolAndMostRecent";
                        
                        // Create the SymbolAndMostRecent field set parameters
                        findDailyPriceDataStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@MostRecent", dailyPriceData.MostRecent, "@Symbol", dailyPriceData.Symbol);
                    }
                    else
                    {
                        // Now create parameters for this procedure
                        findDailyPriceDataStoredProcedure.Parameters = CreatePrimaryKeyParameter(dailyPriceData);
                    }
                }

                // return value
                return findDailyPriceDataStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
