

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

    #region class MarketSummaryController
    /// <summary>
    /// This class controls a(n) 'MarketSummary' object.
    /// </summary>
    public class MarketSummaryController
    {

        #region Methods

            #region CreateMarketSummaryParameter
            /// <summary>
            /// This method creates the parameter for a 'MarketSummary' data operation.
            /// </summary>
            /// <param name='marketsummary'>The 'MarketSummary' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateMarketSummaryParameter(MarketSummary marketSummary)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = marketSummary;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region FetchAll(MarketSummary tempMarketSummary, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'MarketSummary' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'MarketSummary_FetchAll'.</summary>
            /// <param name='tempMarketSummary'>A temporary MarketSummary for passing values.</param>
            /// <returns>A collection of 'MarketSummary' objects.</returns>
            public static List<MarketSummary> FetchAll(MarketSummary tempMarketSummary, DataManager dataManager)
            {
                // Initial value
                List<MarketSummary> marketSummaryList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = MarketSummaryMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateMarketSummaryParameter(tempMarketSummary);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<MarketSummary> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        marketSummaryList = (List<MarketSummary>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return marketSummaryList;
            }
            #endregion

        #endregion

    }
    #endregion

}
