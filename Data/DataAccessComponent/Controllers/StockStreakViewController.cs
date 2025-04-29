

#region using statements

using DataAccessComponent.Data;
using DataAccessComponent.DataBridge;
using DataAccessComponent.DataOperations;
using DataAccessComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace DataAccessComponent.Controllers
{

    #region class StockStreakViewController
    /// <summary>
    /// This class controls a(n) 'StockStreakView' object.
    /// </summary>
    public class StockStreakViewController
    {

        #region Methods

            #region CreateStockStreakViewParameter
            /// <summary>
            /// This method creates the parameter for a 'StockStreakView' data operation.
            /// </summary>
            /// <param name='stockstreakview'>The 'StockStreakView' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateStockStreakViewParameter(StockStreakView stockStreakView)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = stockStreakView;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region FetchAll(StockStreakView tempStockStreakView, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'StockStreakView' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'StockStreakView_FetchAll'.</summary>
            /// <param name='tempStockStreakView'>A temporary StockStreakView for passing values.</param>
            /// <returns>A collection of 'StockStreakView' objects.</returns>
            public static List<StockStreakView> FetchAll(StockStreakView tempStockStreakView, DataManager dataManager)
            {
                // Initial value
                List<StockStreakView> stockStreakViewList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = StockStreakViewMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateStockStreakViewParameter(tempStockStreakView);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<StockStreakView> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        stockStreakViewList = (List<StockStreakView>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return stockStreakViewList;
            }
            #endregion

        #endregion

    }
    #endregion

}
