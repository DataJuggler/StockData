

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

    #region class MarketSummaryWriterBase
    /// <summary>
    /// This class is used for converting a 'MarketSummary' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class MarketSummaryWriterBase
    {

        #region Static Methods

            #region CreateFetchAllMarketSummarysStoredProcedure(MarketSummary marketSummary)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllMarketSummarysStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'MarketSummary_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllMarketSummarysStoredProcedure' object.</returns>
            public static FetchAllMarketSummarysStoredProcedure CreateFetchAllMarketSummarysStoredProcedure(MarketSummary marketSummary)
            {
                // Initial value
                FetchAllMarketSummarysStoredProcedure fetchAllMarketSummarysStoredProcedure = new FetchAllMarketSummarysStoredProcedure();

                // return value
                return fetchAllMarketSummarysStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
