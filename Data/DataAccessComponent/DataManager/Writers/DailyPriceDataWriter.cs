
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
                        fetchAllDailyPriceDatasStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@Symbol", dailyPriceData.Symbol);
                    }
                }
                
                // return value
                return fetchAllDailyPriceDatasStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
