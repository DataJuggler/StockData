

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

    #region class SectorSummaryWriterBase
    /// <summary>
    /// This class is used for converting a 'SectorSummary' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class SectorSummaryWriterBase
    {

        #region Static Methods

            #region CreateFetchAllSectorSummarysStoredProcedure(SectorSummary sectorSummary)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllSectorSummarysStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'SectorSummary_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllSectorSummarysStoredProcedure' object.</returns>
            public static FetchAllSectorSummarysStoredProcedure CreateFetchAllSectorSummarysStoredProcedure(SectorSummary sectorSummary)
            {
                // Initial value
                FetchAllSectorSummarysStoredProcedure fetchAllSectorSummarysStoredProcedure = new FetchAllSectorSummarysStoredProcedure();

                // return value
                return fetchAllSectorSummarysStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
