

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

    #region class IndustrySummaryController
    /// <summary>
    /// This class controls a(n) 'IndustrySummary' object.
    /// </summary>
    public class IndustrySummaryController
    {

        #region Methods

            #region CreateIndustrySummaryParameter
            /// <summary>
            /// This method creates the parameter for a 'IndustrySummary' data operation.
            /// </summary>
            /// <param name='industrysummary'>The 'IndustrySummary' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateIndustrySummaryParameter(IndustrySummary industrySummary)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = industrySummary;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region FetchAll(IndustrySummary tempIndustrySummary, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'IndustrySummary' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'IndustrySummary_FetchAll'.</summary>
            /// <param name='tempIndustrySummary'>A temporary IndustrySummary for passing values.</param>
            /// <returns>A collection of 'IndustrySummary' objects.</returns>
            public static List<IndustrySummary> FetchAll(IndustrySummary tempIndustrySummary, DataManager dataManager)
            {
                // Initial value
                List<IndustrySummary> industrySummaryList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = IndustrySummaryMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateIndustrySummaryParameter(tempIndustrySummary);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<IndustrySummary> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        industrySummaryList = (List<IndustrySummary>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return industrySummaryList;
            }
            #endregion

        #endregion

    }
    #endregion

}
