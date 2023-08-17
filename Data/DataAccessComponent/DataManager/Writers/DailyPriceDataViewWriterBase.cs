

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

    #region class DailyPriceDataViewWriterBase
    /// <summary>
    /// This class is used for converting a 'DailyPriceDataView' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class DailyPriceDataViewWriterBase
    {

        #region Static Methods

            #region CreateFetchAllDailyPriceDataViewsStoredProcedure(DailyPriceDataView dailyPriceDataView)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllDailyPriceDataViewsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DailyPriceDataView_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllDailyPriceDataViewsStoredProcedure' object.</returns>
            public static FetchAllDailyPriceDataViewsStoredProcedure CreateFetchAllDailyPriceDataViewsStoredProcedure(DailyPriceDataView dailyPriceDataView)
            {
                // Initial value
                FetchAllDailyPriceDataViewsStoredProcedure fetchAllDailyPriceDataViewsStoredProcedure = new FetchAllDailyPriceDataViewsStoredProcedure();

                // return value
                return fetchAllDailyPriceDataViewsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
