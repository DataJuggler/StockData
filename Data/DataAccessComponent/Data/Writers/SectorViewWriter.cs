
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

    #region class SectorViewWriter
    /// <summary>
    /// This class is used for converting a 'SectorView' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class SectorViewWriter : SectorViewWriterBase
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
            public static new FetchAllSectorViewsStoredProcedure CreateFetchAllSectorViewsStoredProcedure(SectorView sectorView)
            {
                // Initial value
                FetchAllSectorViewsStoredProcedure fetchAllSectorViewsStoredProcedure = new FetchAllSectorViewsStoredProcedure();

                // if the sectorView object exists
                if (sectorView != null)
                {
                    // if LoadBySectorAndStockDate is true
                    if (sectorView.LoadBySectorAndStockDate)
                    {
                        // Change the procedure name
                        fetchAllSectorViewsStoredProcedure.ProcedureName = "SectorView_FetchAllForSectorAndStockDate";
                        
                        // Create the SectorAndStockDate field set parameters
                        fetchAllSectorViewsStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@Sector", sectorView.Sector, "@StockDate", sectorView.StockDate);
                    }
                }
                
                // return value
                return fetchAllSectorViewsStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
