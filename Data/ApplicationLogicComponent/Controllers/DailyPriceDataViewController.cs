

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

    #region class DailyPriceDataViewController
    /// <summary>
    /// This class controls a(n) 'DailyPriceDataView' object.
    /// </summary>
    public class DailyPriceDataViewController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'DailyPriceDataViewController' object.
        /// </summary>
        public DailyPriceDataViewController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateDailyPriceDataViewParameter
            /// <summary>
            /// This method creates the parameter for a 'DailyPriceDataView' data operation.
            /// </summary>
            /// <param name='dailypricedataview'>The 'DailyPriceDataView' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateDailyPriceDataViewParameter(DailyPriceDataView dailyPriceDataView)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = dailyPriceDataView;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region FetchAll(DailyPriceDataView tempDailyPriceDataView)
            /// <summary>
            /// This method fetches a collection of 'DailyPriceDataView' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'DailyPriceDataView_FetchAll'.</summary>
            /// <param name='tempDailyPriceDataView'>A temporary DailyPriceDataView for passing values.</param>
            /// <returns>A collection of 'DailyPriceDataView' objects.</returns>
            public List<DailyPriceDataView> FetchAll(DailyPriceDataView tempDailyPriceDataView)
            {
                // Initial value
                List<DailyPriceDataView> dailyPriceDataViewList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.DailyPriceDataViewMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateDailyPriceDataViewParameter(tempDailyPriceDataView);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<DailyPriceDataView> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        dailyPriceDataViewList = (List<DailyPriceDataView>) returnObject.ObjectValue;
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
                return dailyPriceDataViewList;
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
