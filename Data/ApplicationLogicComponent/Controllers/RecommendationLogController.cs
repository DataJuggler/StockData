

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

    #region class RecommendationLogController
    /// <summary>
    /// This class controls a(n) 'RecommendationLog' object.
    /// </summary>
    public class RecommendationLogController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'RecommendationLogController' object.
        /// </summary>
        public RecommendationLogController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

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

            #region Delete(RecommendationLog tempRecommendationLog)
            /// <summary>
            /// Deletes a 'RecommendationLog' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'RecommendationLog_Delete'.
            /// </summary>
            /// <param name='recommendationlog'>The 'RecommendationLog' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(RecommendationLog tempRecommendationLog)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteRecommendationLog";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify temprecommendationLog exists before attemptintg to delete
                    if(tempRecommendationLog != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteRecommendationLogMethod = this.AppController.DataBridge.DataOperations.RecommendationLogMethods.DeleteRecommendationLog;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateRecommendationLogParameter(tempRecommendationLog);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteRecommendationLogMethod, parameters);

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
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAll(RecommendationLog tempRecommendationLog)
            /// <summary>
            /// This method fetches a collection of 'RecommendationLog' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'RecommendationLog_FetchAll'.</summary>
            /// <param name='tempRecommendationLog'>A temporary RecommendationLog for passing values.</param>
            /// <returns>A collection of 'RecommendationLog' objects.</returns>
            public List<RecommendationLog> FetchAll(RecommendationLog tempRecommendationLog)
            {
                // Initial value
                List<RecommendationLog> recommendationLogList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.RecommendationLogMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateRecommendationLogParameter(tempRecommendationLog);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<RecommendationLog> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        recommendationLogList = (List<RecommendationLog>) returnObject.ObjectValue;
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
                return recommendationLogList;
            }
            #endregion

            #region Find(RecommendationLog tempRecommendationLog)
            /// <summary>
            /// Finds a 'RecommendationLog' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'RecommendationLog_Find'</param>
            /// </summary>
            /// <param name='tempRecommendationLog'>A temporary RecommendationLog for passing values.</param>
            /// <returns>A 'RecommendationLog' object if found else a null 'RecommendationLog'.</returns>
            public RecommendationLog Find(RecommendationLog tempRecommendationLog)
            {
                // Initial values
                RecommendationLog recommendationLog = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempRecommendationLog != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.RecommendationLogMethods.FindRecommendationLog;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateRecommendationLogParameter(tempRecommendationLog);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

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
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return recommendationLog;
            }
            #endregion

            #region Insert(RecommendationLog recommendationLog)
            /// <summary>
            /// Insert a 'RecommendationLog' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'RecommendationLog_Insert'.</param>
            /// </summary>
            /// <param name='recommendationLog'>The 'RecommendationLog' object to insert.</param>
            /// <returns>The id (int) of the new  'RecommendationLog' object that was inserted.</returns>
            public int Insert(RecommendationLog recommendationLog)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If RecommendationLogexists
                    if(recommendationLog != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.RecommendationLogMethods.InsertRecommendationLog;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateRecommendationLogParameter(recommendationLog);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, insertMethod , parameters);

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
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region Save(ref RecommendationLog recommendationLog)
            /// <summary>
            /// Saves a 'RecommendationLog' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='recommendationLog'>The 'RecommendationLog' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref RecommendationLog recommendationLog)
            {
                // Initial value
                bool saved = false;

                // If the recommendationLog exists.
                if(recommendationLog != null)
                {
                    // Is this a new RecommendationLog
                    if(recommendationLog.IsNew)
                    {
                        // Insert new RecommendationLog
                        int newIdentity = this.Insert(recommendationLog);

                        // if insert was successful
                        if(newIdentity > 0)
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
                        saved = this.Update(recommendationLog);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(RecommendationLog recommendationLog)
            /// <summary>
            /// This method Updates a 'RecommendationLog' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'RecommendationLog_Update'.</param>
            /// </summary>
            /// <param name='recommendationLog'>The 'RecommendationLog' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(RecommendationLog recommendationLog)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(recommendationLog != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.RecommendationLogMethods.UpdateRecommendationLog;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateRecommendationLogParameter(recommendationLog);
                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, updateMethod , parameters);

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
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return saved;
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
