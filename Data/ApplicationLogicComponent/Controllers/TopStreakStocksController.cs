

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

    #region class TopStreakStocksController
    /// <summary>
    /// This class controls a(n) 'TopStreakStocks' object.
    /// </summary>
    public class TopStreakStocksController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'TopStreakStocksController' object.
        /// </summary>
        public TopStreakStocksController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

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

            #region FetchAll(TopStreakStocks tempTopStreakStocks)
            /// <summary>
            /// This method fetches a collection of 'TopStreakStocks' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'TopStreakStocks_FetchAll'.</summary>
            /// <param name='tempTopStreakStocks'>A temporary TopStreakStocks for passing values.</param>
            /// <returns>A collection of 'TopStreakStocks' objects.</returns>
            public List<TopStreakStocks> FetchAll(TopStreakStocks tempTopStreakStocks)
            {
                // Initial value
                List<TopStreakStocks> topStreakStocksList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.TopStreakStocksMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateTopStreakStocksParameter(tempTopStreakStocks);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<TopStreakStocks> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        topStreakStocksList = (List<TopStreakStocks>) returnObject.ObjectValue;
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
                return topStreakStocksList;
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
