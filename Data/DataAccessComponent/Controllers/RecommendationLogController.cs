

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

    #region class RecommendationLogController
    /// <summary>
    /// This class controls a(n) 'RecommendationLog' object.
    /// </summary>
    public class RecommendationLogController
    {

        #region Methods

            #region CreateRecommendationLogParameter
            /// <summary>
            /// This method creates the parameter for a 'RecommendationLog' data operation.
            /// </summary>
            /// <param name='recommendationlog'>The 'RecommendationLog' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateRecommendationLogParameter(RecommendationLog recommendationLog)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = recommendationLog;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(RecommendationLog tempRecommendationLog, DataManager dataManager)
            /// <summary>
            /// Deletes a 'RecommendationLog' from the database
            /// This method calls the DataBridgeManager to execute the delete
            /// procedure 'RecommendationLog_Delete'.
            /// </summary>
            /// <param name='recommendationlog'>The 'RecommendationLog' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public static bool Delete(RecommendationLog tempRecommendationLog, DataManager dataManager)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteRecommendationLog";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify temprecommendationLog exists before attemptintg to delete
                    if (tempRecommendationLog != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteRecommendationLogMethod = RecommendationLogMethods.DeleteRecommendationLog;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateRecommendationLogParameter(tempRecommendationLog);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteRecommendationLogMethod, parameters, dataManager);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Test For True
                            if (returnObject.Boolean.Value == NullableBooleanEnum.True)
                            {
                                // Set Deleted To True
                                deleted = true;
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAll(RecommendationLog tempRecommendationLog, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'RecommendationLog' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'RecommendationLog_FetchAll'.</summary>
            /// <param name='tempRecommendationLog'>A temporary RecommendationLog for passing values.</param>
            /// <returns>A collection of 'RecommendationLog' objects.</returns>
            public static List<RecommendationLog> FetchAll(RecommendationLog tempRecommendationLog, DataManager dataManager)
            {
                // Initial value
                List<RecommendationLog> recommendationLogList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = RecommendationLogMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateRecommendationLogParameter(tempRecommendationLog);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<RecommendationLog> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        recommendationLogList = (List<RecommendationLog>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return recommendationLogList;
            }
            #endregion

            #region Find(RecommendationLog tempRecommendationLog, DataManager dataManager)
            /// <summary>
            /// Finds a 'RecommendationLog' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'RecommendationLog_Find'</param>
            /// </summary>
            /// <param name='tempRecommendationLog'>A temporary RecommendationLog for passing values.</param>
            /// <returns>A 'RecommendationLog' object if found else a null 'RecommendationLog'.</returns>
            public static RecommendationLog Find(RecommendationLog tempRecommendationLog, DataManager dataManager)
            {
                // Initial values
                RecommendationLog recommendationLog = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if (tempRecommendationLog != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = RecommendationLogMethods.FindRecommendationLog;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateRecommendationLogParameter(tempRecommendationLog);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, findMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as RecommendationLog != null))
                        {
                            // Get ReturnObject
                            recommendationLog = (RecommendationLog) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return recommendationLog;
            }
            #endregion

            #region Insert(RecommendationLog recommendationLog, DataManager dataManager)
            /// <summary>
            /// Insert a 'RecommendationLog' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'RecommendationLog_Insert'.</param>
            /// </summary>
            /// <param name='recommendationLog'>The 'RecommendationLog' object to insert.</param>
            /// <returns>The id (int) of the new  'RecommendationLog' object that was inserted.</returns>
            public static int Insert(RecommendationLog recommendationLog, DataManager dataManager)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If RecommendationLogexists
                    if (recommendationLog != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = RecommendationLogMethods.InsertRecommendationLog;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateRecommendationLogParameter(recommendationLog);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, insertMethod , parameters, dataManager);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Set return value
                            newIdentity = returnObject.IntegerValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region Save(ref RecommendationLog recommendationLog, DataManager dataManager)
            /// <summary>
            /// Saves a 'RecommendationLog' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='recommendationLog'>The 'RecommendationLog' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static bool Save(ref RecommendationLog recommendationLog, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // If the recommendationLog exists.
                if (recommendationLog != null)
                {
                    // Is this a new RecommendationLog
                    if (recommendationLog.IsNew)
                    {
                        // Insert new RecommendationLog
                        int newIdentity = Insert(recommendationLog, dataManager);

                        // if insert was successful
                        if (newIdentity > 0)
                        {
                            // Update Identity
                            recommendationLog.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update RecommendationLog
                        saved = Update(recommendationLog, dataManager);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(RecommendationLog recommendationLog, DataManager dataManager)
            /// <summary>
            /// This method Updates a 'RecommendationLog' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'RecommendationLog_Update'.</param>
            /// </summary>
            /// <param name='recommendationLog'>The 'RecommendationLog' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public static bool Update(RecommendationLog recommendationLog, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if (recommendationLog != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = RecommendationLogMethods.UpdateRecommendationLog;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateRecommendationLogParameter(recommendationLog);
                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, updateMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.Boolean != null) && (returnObject.Boolean.Value == NullableBooleanEnum.True))
                        {
                            // Set saved to true
                            saved = true;
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

    }
    #endregion

}
