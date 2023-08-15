
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

    #region class StockWriter
    /// <summary>
    /// This class is used for converting a 'Stock' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class StockWriter : StockWriterBase
    {

        #region Static Methods

            #region CreateFindStockStoredProcedure(Stock stock)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindStockStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Stock_Find'.
            /// </summary>
            /// <param name="stock">The 'Stock' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static new FindStockStoredProcedure CreateFindStockStoredProcedure(Stock stock)
            {
                // Initial Value
                FindStockStoredProcedure findStockStoredProcedure = null;

                // verify stock exists
                if(stock != null)
                {
                    // Instanciate findStockStoredProcedure
                    findStockStoredProcedure = new FindStockStoredProcedure();

                    // if stock.FindBySymbol is true
                    if (stock.FindBySymbol)
                    {
                            // Change the procedure name
                            findStockStoredProcedure.ProcedureName = "Stock_FindBySymbol";
                            
                            // Create the @Symbol parameter
                            findStockStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@Symbol", stock.Symbol);
                    }
                    else
                    {
                        // Now create parameters for this procedure
                        findStockStoredProcedure.Parameters = CreatePrimaryKeyParameter(stock);
                    }
                }

                // return value
                return findStockStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
