

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

    #region class RecommendationViewWriterBase
    /// <summary>
    /// This class is used for converting a 'RecommendationView' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class RecommendationViewWriterBase
    {

        #region Static Methods

            #region CreateFetchAllRecommendationViewsStoredProcedure(RecommendationView recommendationView)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllRecommendationViewsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'RecommendationView_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllRecommendationViewsStoredProcedure' object.</returns>
            public static FetchAllRecommendationViewsStoredProcedure CreateFetchAllRecommendationViewsStoredProcedure(RecommendationView recommendationView)
            {
                // Initial value
                FetchAllRecommendationViewsStoredProcedure fetchAllRecommendationViewsStoredProcedure = new FetchAllRecommendationViewsStoredProcedure();

                // return value
                return fetchAllRecommendationViewsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
