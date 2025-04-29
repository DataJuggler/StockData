

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

    #region class TopLosingStreakStocksWriterBase
    /// <summary>
    /// This class is used for converting a 'TopLosingStreakStocks' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class TopLosingStreakStocksWriterBase
    {

        #region Static Methods

            #region CreateFetchAllTopLosingStreakStocksStoredProcedure(TopLosingStreakStocks topLosingStreakStocks)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllTopLosingStreakStocksStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'TopLosingStreakStocks_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllTopLosingStreakStocksStoredProcedure' object.</returns>
            public static FetchAllTopLosingStreakStocksStoredProcedure CreateFetchAllTopLosingStreakStocksStoredProcedure(TopLosingStreakStocks topLosingStreakStocks)
            {
                // Initial value
                FetchAllTopLosingStreakStocksStoredProcedure fetchAllTopLosingStreakStocksStoredProcedure = new FetchAllTopLosingStreakStocksStoredProcedure();

                // return value
                return fetchAllTopLosingStreakStocksStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
