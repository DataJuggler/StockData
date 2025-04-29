

#region using statements

using DataAccessComponent.Data;
using DataAccessComponent.Data.Writers;
using DataAccessComponent.DataBridge;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace DataAccessComponent.DataOperations
{

    #region class StockStreakViewMethods
    /// <summary>
    /// This class contains methods for modifying a 'StockStreakView' object.
    /// </summary>
    public static class StockStreakViewMethods
    {

        #region Methods

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'StockStreakView' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'StockStreakView' to delete.
            /// <returns>A PolymorphicObject object with all  'StockStreakViews' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<StockStreakView> stockStreakViewListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllStockStreakViewsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get StockStreakViewParameter
                    // Declare Parameter
                    StockStreakView paramStockStreakView = null;

                    // verify the first parameters is a(n) 'StockStreakView'.
                    if (parameters[0].ObjectValue as StockStreakView != null)
                    {
                        // Get StockStreakViewParameter
                        paramStockStreakView = (StockStreakView) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllStockStreakViewsProc from StockStreakViewWriter
                    fetchAllProc = StockStreakViewWriter.CreateFetchAllStockStreakViewsStoredProcedure(paramStockStreakView);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    stockStreakViewListCollection = StockStreakViewManager.FetchAllStockStreakViews(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(stockStreakViewListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = stockStreakViewListCollection;
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

        #endregion

    }
    #endregion

}
