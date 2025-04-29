

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

    #region class IndustryWinningStreakViewWriterBase
    /// <summary>
    /// This class is used for converting a 'IndustryWinningStreakView' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class IndustryWinningStreakViewWriterBase
    {

        #region Static Methods

            #region CreateFetchAllIndustryWinningStreakViewsStoredProcedure(IndustryWinningStreakView industryWinningStreakView)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllIndustryWinningStreakViewsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'IndustryWinningStreakView_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllIndustryWinningStreakViewsStoredProcedure' object.</returns>
            public static FetchAllIndustryWinningStreakViewsStoredProcedure CreateFetchAllIndustryWinningStreakViewsStoredProcedure(IndustryWinningStreakView industryWinningStreakView)
            {
                // Initial value
                FetchAllIndustryWinningStreakViewsStoredProcedure fetchAllIndustryWinningStreakViewsStoredProcedure = new FetchAllIndustryWinningStreakViewsStoredProcedure();

                // return value
                return fetchAllIndustryWinningStreakViewsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
