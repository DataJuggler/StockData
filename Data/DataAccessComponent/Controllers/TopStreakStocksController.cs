

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

    #region class TopStreakStocksController
    /// <summary>
    /// This class controls a(n) 'TopStreakStocks' object.
    /// </summary>
    public class TopStreakStocksController
    {

        #region Methods

            #region CreateTopStreakStocksParameter
            /// <summary>
            /// This method creates the parameter for a 'TopStreakStocks' data operation.
            /// </summary>
            /// <param name='topstreakstocks'>The 'TopStreakStocks' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateTopStreakStocksParameter(TopStreakStocks topStreakStocks)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = topStreakStocks;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region FetchAll(TopStreakStocks tempTopStreakStocks, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'TopStreakStocks' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'TopStreakStocks_FetchAll'.</summary>
            /// <param name='tempTopStreakStocks'>A temporary TopStreakStocks for passing values.</param>
            /// <returns>A collection of 'TopStreakStocks' objects.</returns>
            public static List<TopStreakStocks> FetchAll(TopStreakStocks tempTopStreakStocks, DataManager dataManager)
            {
                // Initial value
                List<TopStreakStocks> topStreakStocksList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = TopStreakStocksMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateTopStreakStocksParameter(tempTopStreakStocks);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<TopStreakStocks> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        topStreakStocksList = (List<TopStreakStocks>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return topStreakStocksList;
            }
            #endregion

        #endregion

    }
    #endregion

}
