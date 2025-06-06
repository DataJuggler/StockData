

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

    #region class RecommendationViewController
    /// <summary>
    /// This class controls a(n) 'RecommendationView' object.
    /// </summary>
    public class RecommendationViewController
    {

        #region Methods

            #region CreateRecommendationViewParameter
            /// <summary>
            /// This method creates the parameter for a 'RecommendationView' data operation.
            /// </summary>
            /// <param name='recommendationview'>The 'RecommendationView' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateRecommendationViewParameter(RecommendationView recommendationView)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = recommendationView;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region FetchAll(RecommendationView tempRecommendationView, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'RecommendationView' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'RecommendationView_FetchAll'.</summary>
            /// <param name='tempRecommendationView'>A temporary RecommendationView for passing values.</param>
            /// <returns>A collection of 'RecommendationView' objects.</returns>
            public static List<RecommendationView> FetchAll(RecommendationView tempRecommendationView, DataManager dataManager)
            {
                // Initial value
                List<RecommendationView> recommendationViewList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = RecommendationViewMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateRecommendationViewParameter(tempRecommendationView);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<RecommendationView> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        recommendationViewList = (List<RecommendationView>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return recommendationViewList;
            }
            #endregion

        #endregion

    }
    #endregion

}
