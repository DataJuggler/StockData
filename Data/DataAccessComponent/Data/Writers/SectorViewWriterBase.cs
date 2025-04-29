

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

    #region class SectorViewWriterBase
    /// <summary>
    /// This class is used for converting a 'SectorView' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class SectorViewWriterBase
    {

        #region Static Methods

            #region CreateFetchAllSectorViewsStoredProcedure(SectorView sectorView)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllSectorViewsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'SectorView_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllSectorViewsStoredProcedure' object.</returns>
            public static FetchAllSectorViewsStoredProcedure CreateFetchAllSectorViewsStoredProcedure(SectorView sectorView)
            {
                // Initial value
                FetchAllSectorViewsStoredProcedure fetchAllSectorViewsStoredProcedure = new FetchAllSectorViewsStoredProcedure();

                // return value
                return fetchAllSectorViewsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
