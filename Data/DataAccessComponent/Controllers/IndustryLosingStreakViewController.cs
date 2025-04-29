

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

    #region class IndustryLosingStreakViewController
    /// <summary>
    /// This class controls a(n) 'IndustryLosingStreakView' object.
    /// </summary>
    public class IndustryLosingStreakViewController
    {

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

            #region FetchAll(IndustryLosingStreakView tempIndustryLosingStreakView, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'IndustryLosingStreakView' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'IndustryLosingStreakView_FetchAll'.</summary>
            /// <param name='tempIndustryLosingStreakView'>A temporary IndustryLosingStreakView for passing values.</param>
            /// <returns>A collection of 'IndustryLosingStreakView' objects.</returns>
            public static List<IndustryLosingStreakView> FetchAll(IndustryLosingStreakView tempIndustryLosingStreakView, DataManager dataManager)
            {
                // Initial value
                List<IndustryLosingStreakView> industryLosingStreakViewList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = IndustryLosingStreakViewMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateIndustryLosingStreakViewParameter(tempIndustryLosingStreakView);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<IndustryLosingStreakView> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        industryLosingStreakViewList = (List<IndustryLosingStreakView>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return industryLosingStreakViewList;
            }
            #endregion

        #endregion

    }
    #endregion

}
