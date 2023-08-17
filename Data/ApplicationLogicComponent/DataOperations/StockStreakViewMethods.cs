

#region using statements

using ApplicationLogicComponent.DataBridge;
using DataAccessComponent.DataManager;
using DataAccessComponent.DataManager.Writers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.DataOperations
{

    #region class StockStreakViewMethods
    /// <summary>
    /// This class contains methods for modifying a 'StockStreakView' object.
    /// </summary>
    public class StockStreakViewMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'StockStreakViewMethods' object.
        /// </summary>
        public StockStreakViewMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'StockStreakView' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'StockStreakView' to delete.
            /// <returns>A PolymorphicObject object with all  'StockStreakViews' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
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
                    stockStreakViewListCollection = this.DataManager.StockStreakViewManager.FetchAllStockStreakViews(fetchAllProc, dataConnector);

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

        #region Properties

            #region DataManager 
            public DataManager DataManager 
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
