

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

    #region class IndustryLosingStreakViewWriterBase
    /// <summary>
    /// This class is used for converting a 'IndustryLosingStreakView' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class IndustryLosingStreakViewWriterBase
    {

        #region Static Methods

            #region CreateFetchAllIndustryLosingStreakViewsStoredProcedure(IndustryLosingStreakView industryLosingStreakView)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllIndustryLosingStreakViewsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'IndustryLosingStreakView_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllIndustryLosingStreakViewsStoredProcedure' object.</returns>
            public static FetchAllIndustryLosingStreakViewsStoredProcedure CreateFetchAllIndustryLosingStreakViewsStoredProcedure(IndustryLosingStreakView industryLosingStreakView)
            {
                // Initial value
                FetchAllIndustryLosingStreakViewsStoredProcedure fetchAllIndustryLosingStreakViewsStoredProcedure = new FetchAllIndustryLosingStreakViewsStoredProcedure();

                // return value
                return fetchAllIndustryLosingStreakViewsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
