
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

    #region class IndustryViewWriter
    /// <summary>
    /// This class is used for converting a 'IndustryView' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class IndustryViewWriter : IndustryViewWriterBase
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
            public static new FetchAllIndustryViewsStoredProcedure CreateFetchAllIndustryViewsStoredProcedure(IndustryView industryView)
            {
                // Initial value
                FetchAllIndustryViewsStoredProcedure fetchAllIndustryViewsStoredProcedure = new FetchAllIndustryViewsStoredProcedure();

                if (industryView.LoadByIndustryAndStockDate)
                {
                    // Change the procedure name
                    fetchAllIndustryViewsStoredProcedure.ProcedureName = "IndustryView_FetchAllForIndustryAndStockDate";
                
                    // Create the IndustryAndStockDate field set parameters
                    fetchAllIndustryViewsStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@Industry", industryView.Industry, "@StockDate", industryView.StockDate);
                }

                // return value
                return fetchAllIndustryViewsStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
