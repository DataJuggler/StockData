

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

    #region class StockStreakViewWriterBase
    /// <summary>
    /// This class is used for converting a 'StockStreakView' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class StockStreakViewWriterBase
    {

        #region Static Methods

            #region CreateFetchAllStockStreakViewsStoredProcedure(StockStreakView stockStreakView)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllStockStreakViewsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'StockStreakView_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllStockStreakViewsStoredProcedure' object.</returns>
            public static FetchAllStockStreakViewsStoredProcedure CreateFetchAllStockStreakViewsStoredProcedure(StockStreakView stockStreakView)
            {
                // Initial value
                FetchAllStockStreakViewsStoredProcedure fetchAllStockStreakViewsStoredProcedure = new FetchAllStockStreakViewsStoredProcedure();

                // return value
                return fetchAllStockStreakViewsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
