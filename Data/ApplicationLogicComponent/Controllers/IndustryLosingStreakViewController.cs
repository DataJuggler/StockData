

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

    #region class IndustryLosingStreakViewController
    /// <summary>
    /// This class controls a(n) 'IndustryLosingStreakView' object.
    /// </summary>
    public class IndustryLosingStreakViewController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'IndustryLosingStreakViewController' object.
        /// </summary>
        public IndustryLosingStreakViewController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateIndustryLosingStreakViewParameter
            /// <summary>
            /// This method creates the parameter for a 'IndustryLosingStreakView' data operation.
            /// </summary>
            /// <param name='industrylosingstreakview'>The 'IndustryLosingStreakView' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateIndustryLosingStreakViewParameter(IndustryLosingStreakView industryLosingStreakView)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = industryLosingStreakView;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region FetchAll(IndustryLosingStreakView tempIndustryLosingStreakView)
            /// <summary>
            /// This method fetches a collection of 'IndustryLosingStreakView' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'IndustryLosingStreakView_FetchAll'.</summary>
            /// <param name='tempIndustryLosingStreakView'>A temporary IndustryLosingStreakView for passing values.</param>
            /// <returns>A collection of 'IndustryLosingStreakView' objects.</returns>
            public List<IndustryLosingStreakView> FetchAll(IndustryLosingStreakView tempIndustryLosingStreakView)
            {
                // Initial value
                List<IndustryLosingStreakView> industryLosingStreakViewList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.IndustryLosingStreakViewMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateIndustryLosingStreakViewParameter(tempIndustryLosingStreakView);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<IndustryLosingStreakView> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        industryLosingStreakViewList = (List<IndustryLosingStreakView>) returnObject.ObjectValue;
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
                return industryLosingStreakViewList;
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
