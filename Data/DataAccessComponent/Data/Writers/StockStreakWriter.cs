
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

    #region class StockStreakWriter
    /// <summary>
    /// This class is used for converting a 'StockStreak' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class StockStreakWriter : StockStreakWriterBase
    {

        #region Static Methods

            #region CreateFindStockStreakStoredProcedure(StockStreak stockStreak)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindStockStreakStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'StockStreak_Find'.
            /// </summary>
            /// <param name="stockStreak">The 'StockStreak' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static new FindStockStreakStoredProcedure CreateFindStockStreakStoredProcedure(StockStreak stockStreak)
            {
                // Initial Value
                FindStockStreakStoredProcedure findStockStreakStoredProcedure = null;

                // verify stockStreak exists
                if(stockStreak != null)
                {
                    // Instanciate findStockStreakStoredProcedure
                    findStockStreakStoredProcedure = new FindStockStreakStoredProcedure();

                    // if stockStreak.FindByStockIdAndCurrentStreak is true
                    if (stockStreak.FindByStockIdAndCurrentStreak)
                    {
                            // Change the procedure name
                            findStockStreakStoredProcedure.ProcedureName = "StockStreak_FindByStockIdAndCurrentStreak";
                            
                            // Create the StockIdAndCurrentStreak field set parameters
                            findStockStreakStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@CurrentStreak", stockStreak.CurrentStreak, "@StockId", stockStreak.StockId);
                    }
                    else
                    {
                        // Now create parameters for this procedure
                        findStockStreakStoredProcedure.Parameters = CreatePrimaryKeyParameter(stockStreak);
                    }
                }

                // return value
                return findStockStreakStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
