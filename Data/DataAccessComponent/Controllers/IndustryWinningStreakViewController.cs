

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

    #region class IndustryWinningStreakViewController
    /// <summary>
    /// This class controls a(n) 'IndustryWinningStreakView' object.
    /// </summary>
    public class IndustryWinningStreakViewController
    {

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

            #region FetchAll(IndustryWinningStreakView tempIndustryWinningStreakView, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'IndustryWinningStreakView' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'IndustryWinningStreakView_FetchAll'.</summary>
            /// <param name='tempIndustryWinningStreakView'>A temporary IndustryWinningStreakView for passing values.</param>
            /// <returns>A collection of 'IndustryWinningStreakView' objects.</returns>
            public static List<IndustryWinningStreakView> FetchAll(IndustryWinningStreakView tempIndustryWinningStreakView, DataManager dataManager)
            {
                // Initial value
                List<IndustryWinningStreakView> industryWinningStreakViewList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = IndustryWinningStreakViewMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateIndustryWinningStreakViewParameter(tempIndustryWinningStreakView);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<IndustryWinningStreakView> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        industryWinningStreakViewList = (List<IndustryWinningStreakView>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return industryWinningStreakViewList;
            }
            #endregion

        #endregion

    }
    #endregion

}
