

#region using statements

using ApplicationLogicComponent.DataBridge;
using ApplicationLogicComponent.DataOperations;
using ApplicationLogicComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.Controllers
{

    #region class TopLosingStreakStocksController
    /// <summary>
    /// This class controls a(n) 'TopLosingStreakStocks' object.
    /// </summary>
    public class TopLosingStreakStocksController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'TopLosingStreakStocksController' object.
        /// </summary>
        public TopLosingStreakStocksController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateTopLosingStreakStocksParameter
            /// <summary>
            /// This method creates the parameter for a 'TopLosingStreakStocks' data operation.
            /// </summary>
            /// <param name='toplosingstreakstocks'>The 'TopLosingStreakStocks' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateTopLosingStreakStocksParameter(TopLosingStreakStocks topLosingStreakStocks)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = topLosingStreakStocks;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region FetchAll(TopLosingStreakStocks tempTopLosingStreakStocks)
            /// <summary>
            /// This method fetches a collection of 'TopLosingStreakStocks' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'TopLosingStreakStocks_FetchAll'.</summary>
            /// <param name='tempTopLosingStreakStocks'>A temporary TopLosingStreakStocks for passing values.</param>
            /// <returns>A collection of 'TopLosingStreakStocks' objects.</returns>
            public List<TopLosingStreakStocks> FetchAll(TopLosingStreakStocks tempTopLosingStreakStocks)
            {
                // Initial value
                List<TopLosingStreakStocks> topLosingStreakStocksList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.TopLosingStreakStocksMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateTopLosingStreakStocksParameter(tempTopLosingStreakStocks);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<TopLosingStreakStocks> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        topLosingStreakStocksList = (List<TopLosingStreakStocks>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return topLosingStreakStocksList;
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ErrorProcessor
            public ErrorHandler ErrorProcessor
            {
                get { return errorProcessor; }
                set { errorProcessor = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
