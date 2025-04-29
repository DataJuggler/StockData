

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

    #region class TopStreakStocksWriterBase
    /// <summary>
    /// This class is used for converting a 'TopStreakStocks' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class TopStreakStocksWriterBase
    {

        #region Static Methods

            #region CreateFetchAllTopStreakStocksStoredProcedure(TopStreakStocks topStreakStocks)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllTopStreakStocksStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'TopStreakStocks_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllTopStreakStocksStoredProcedure' object.</returns>
            public static FetchAllTopStreakStocksStoredProcedure CreateFetchAllTopStreakStocksStoredProcedure(TopStreakStocks topStreakStocks)
            {
                // Initial value
                FetchAllTopStreakStocksStoredProcedure fetchAllTopStreakStocksStoredProcedure = new FetchAllTopStreakStocksStoredProcedure();

                // return value
                return fetchAllTopStreakStocksStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
