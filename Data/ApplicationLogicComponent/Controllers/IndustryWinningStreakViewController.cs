

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

    #region class IndustryWinningStreakViewController
    /// <summary>
    /// This class controls a(n) 'IndustryWinningStreakView' object.
    /// </summary>
    public class IndustryWinningStreakViewController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'IndustryWinningStreakViewController' object.
        /// </summary>
        public IndustryWinningStreakViewController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateIndustryWinningStreakViewParameter
            /// <summary>
            /// This method creates the parameter for a 'IndustryWinningStreakView' data operation.
            /// </summary>
            /// <param name='industrywinningstreakview'>The 'IndustryWinningStreakView' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateIndustryWinningStreakViewParameter(IndustryWinningStreakView industryWinningStreakView)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = industryWinningStreakView;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region FetchAll(IndustryWinningStreakView tempIndustryWinningStreakView)
            /// <summary>
            /// This method fetches a collection of 'IndustryWinningStreakView' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'IndustryWinningStreakView_FetchAll'.</summary>
            /// <param name='tempIndustryWinningStreakView'>A temporary IndustryWinningStreakView for passing values.</param>
            /// <returns>A collection of 'IndustryWinningStreakView' objects.</returns>
            public List<IndustryWinningStreakView> FetchAll(IndustryWinningStreakView tempIndustryWinningStreakView)
            {
                // Initial value
                List<IndustryWinningStreakView> industryWinningStreakViewList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.IndustryWinningStreakViewMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateIndustryWinningStreakViewParameter(tempIndustryWinningStreakView);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<IndustryWinningStreakView> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        industryWinningStreakViewList = (List<IndustryWinningStreakView>) returnObject.ObjectValue;
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
                return industryWinningStreakViewList;
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
