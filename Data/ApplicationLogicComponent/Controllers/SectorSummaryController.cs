

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

    #region class SectorSummaryController
    /// <summary>
    /// This class controls a(n) 'SectorSummary' object.
    /// </summary>
    public class SectorSummaryController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'SectorSummaryController' object.
        /// </summary>
        public SectorSummaryController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateSectorSummaryParameter
            /// <summary>
            /// This method creates the parameter for a 'SectorSummary' data operation.
            /// </summary>
            /// <param name='sectorsummary'>The 'SectorSummary' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateSectorSummaryParameter(SectorSummary sectorSummary)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = sectorSummary;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region FetchAll(SectorSummary tempSectorSummary)
            /// <summary>
            /// This method fetches a collection of 'SectorSummary' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'SectorSummary_FetchAll'.</summary>
            /// <param name='tempSectorSummary'>A temporary SectorSummary for passing values.</param>
            /// <returns>A collection of 'SectorSummary' objects.</returns>
            public List<SectorSummary> FetchAll(SectorSummary tempSectorSummary)
            {
                // Initial value
                List<SectorSummary> sectorSummaryList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.SectorSummaryMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateSectorSummaryParameter(tempSectorSummary);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<SectorSummary> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        sectorSummaryList = (List<SectorSummary>) returnObject.ObjectValue;
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
                return sectorSummaryList;
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
