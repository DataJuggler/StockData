

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

    #region class IndustrySummaryWriterBase
    /// <summary>
    /// This class is used for converting a 'IndustrySummary' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class IndustrySummaryWriterBase
    {

        #region Static Methods

            #region CreateFetchAllIndustrySummarysStoredProcedure(IndustrySummary industrySummary)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllIndustrySummarysStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'IndustrySummary_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllIndustrySummarysStoredProcedure' object.</returns>
            public static FetchAllIndustrySummarysStoredProcedure CreateFetchAllIndustrySummarysStoredProcedure(IndustrySummary industrySummary)
            {
                // Initial value
                FetchAllIndustrySummarysStoredProcedure fetchAllIndustrySummarysStoredProcedure = new FetchAllIndustrySummarysStoredProcedure();

                // return value
                return fetchAllIndustrySummarysStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
