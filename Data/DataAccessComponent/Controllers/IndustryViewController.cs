

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

    #region class IndustryViewController
    /// <summary>
    /// This class controls a(n) 'IndustryView' object.
    /// </summary>
    public class IndustryViewController
    {

        #region Methods

            #region CreateIndustryViewParameter
            /// <summary>
            /// This method creates the parameter for a 'IndustryView' data operation.
            /// </summary>
            /// <param name='industryview'>The 'IndustryView' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateIndustryViewParameter(IndustryView industryView)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = industryView;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region FetchAll(IndustryView tempIndustryView, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'IndustryView' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'IndustryView_FetchAll'.</summary>
            /// <param name='tempIndustryView'>A temporary IndustryView for passing values.</param>
            /// <returns>A collection of 'IndustryView' objects.</returns>
            public static List<IndustryView> FetchAll(IndustryView tempIndustryView, DataManager dataManager)
            {
                // Initial value
                List<IndustryView> industryViewList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = IndustryViewMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateIndustryViewParameter(tempIndustryView);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<IndustryView> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        industryViewList = (List<IndustryView>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return industryViewList;
            }
            #endregion

        #endregion

    }
    #endregion

}
