

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

    #region class IndustryViewWriterBase
    /// <summary>
    /// This class is used for converting a 'IndustryView' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class IndustryViewWriterBase
    {

        #region Static Methods

            #region CreateFetchAllIndustryViewsStoredProcedure(IndustryView industryView)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllIndustryViewsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'IndustryView_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllIndustryViewsStoredProcedure' object.</returns>
            public static FetchAllIndustryViewsStoredProcedure CreateFetchAllIndustryViewsStoredProcedure(IndustryView industryView)
            {
                // Initial value
                FetchAllIndustryViewsStoredProcedure fetchAllIndustryViewsStoredProcedure = new FetchAllIndustryViewsStoredProcedure();

                // return value
                return fetchAllIndustryViewsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
