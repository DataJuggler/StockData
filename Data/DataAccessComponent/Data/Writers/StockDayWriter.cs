
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

    #region class StockDayWriter
    /// <summary>
    /// This class is used for converting a 'StockDay' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class StockDayWriter : StockDayWriterBase
    {

        #region Static Methods

            #region CreateFetchAllStockDaysStoredProcedure(StockDay stockDay)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllStockDaysStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'StockDay_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllStockDaysStoredProcedure' object.</returns>
            public static new FetchAllStockDaysStoredProcedure CreateFetchAllStockDaysStoredProcedure(StockDay stockDay)
            {
                // Initial value
                FetchAllStockDaysStoredProcedure fetchAllStockDaysStoredProcedure = new FetchAllStockDaysStoredProcedure();

                // if the stockDay object exists
                if (stockDay != null)
                {
                    // if LoadByIndustryProcessedAndSectorProcessed is true
                    if (stockDay.LoadByIndustryProcessedAndSectorProcessed)
                    {
                        // Change the procedure name
                        fetchAllStockDaysStoredProcedure.ProcedureName = "StockDay_FetchAllForNeedsProcessing";
                        
                        // Create the IndustryProcessedAndSectorProcessed field set parameters
                        fetchAllStockDaysStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@IndustryProcessed", stockDay.IndustryProcessed, "@SectorProcessed", stockDay.SectorProcessed);
                    }
                }
                
                // return value
                return fetchAllStockDaysStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
