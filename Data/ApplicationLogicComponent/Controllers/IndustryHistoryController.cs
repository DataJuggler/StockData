

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

    #region class IndustryHistoryController
    /// <summary>
    /// This class controls a(n) 'IndustryHistory' object.
    /// </summary>
    public class IndustryHistoryController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'IndustryHistoryController' object.
        /// </summary>
        public IndustryHistoryController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateIndustryHistoryParameter
            /// <summary>
            /// This method creates the parameter for a 'IndustryHistory' data operation.
            /// </summary>
            /// <param name='industryhistory'>The 'IndustryHistory' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateIndustryHistoryParameter(IndustryHistory industryHistory)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = industryHistory;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(IndustryHistory tempIndustryHistory)
            /// <summary>
            /// Deletes a 'IndustryHistory' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'IndustryHistory_Delete'.
            /// </summary>
            /// <param name='industryhistory'>The 'IndustryHistory' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(IndustryHistory tempIndustryHistory)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteIndustryHistory";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempindustryHistory exists before attemptintg to delete
                    if(tempIndustryHistory != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteIndustryHistoryMethod = this.AppController.DataBridge.DataOperations.IndustryHistoryMethods.DeleteIndustryHistory;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateIndustryHistoryParameter(tempIndustryHistory);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteIndustryHistoryMethod, parameters);

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

            #region FetchAll(IndustryHistory tempIndustryHistory)
            /// <summary>
            /// This method fetches a collection of 'IndustryHistory' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'IndustryHistory_FetchAll'.</summary>
            /// <param name='tempIndustryHistory'>A temporary IndustryHistory for passing values.</param>
            /// <returns>A collection of 'IndustryHistory' objects.</returns>
            public List<IndustryHistory> FetchAll(IndustryHistory tempIndustryHistory)
            {
                // Initial value
                List<IndustryHistory> industryHistoryList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.IndustryHistoryMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateIndustryHistoryParameter(tempIndustryHistory);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<IndustryHistory> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        industryHistoryList = (List<IndustryHistory>) returnObject.ObjectValue;
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
                return industryHistoryList;
            }
            #endregion

            #region Find(IndustryHistory tempIndustryHistory)
            /// <summary>
            /// Finds a 'IndustryHistory' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'IndustryHistory_Find'</param>
            /// </summary>
            /// <param name='tempIndustryHistory'>A temporary IndustryHistory for passing values.</param>
            /// <returns>A 'IndustryHistory' object if found else a null 'IndustryHistory'.</returns>
            public IndustryHistory Find(IndustryHistory tempIndustryHistory)
            {
                // Initial values
                IndustryHistory industryHistory = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempIndustryHistory != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.IndustryHistoryMethods.FindIndustryHistory;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateIndustryHistoryParameter(tempIndustryHistory);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as IndustryHistory != null))
                        {
                            // Get ReturnObject
                            industryHistory = (IndustryHistory) returnObject.ObjectValue;
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
                return industryHistory;
            }
            #endregion

            #region Insert(IndustryHistory industryHistory)
            /// <summary>
            /// Insert a 'IndustryHistory' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'IndustryHistory_Insert'.</param>
            /// </summary>
            /// <param name='industryHistory'>The 'IndustryHistory' object to insert.</param>
            /// <returns>The id (int) of the new  'IndustryHistory' object that was inserted.</returns>
            public int Insert(IndustryHistory industryHistory)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If IndustryHistoryexists
                    if(industryHistory != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.IndustryHistoryMethods.InsertIndustryHistory;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateIndustryHistoryParameter(industryHistory);

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

            #region Save(ref IndustryHistory industryHistory)
            /// <summary>
            /// Saves a 'IndustryHistory' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='industryHistory'>The 'IndustryHistory' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref IndustryHistory industryHistory)
            {
                // Initial value
                bool saved = false;

                // If the industryHistory exists.
                if(industryHistory != null)
                {
                    // Is this a new IndustryHistory
                    if(industryHistory.IsNew)
                    {
                        // Insert new IndustryHistory
                        int newIdentity = this.Insert(industryHistory);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            industryHistory.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update IndustryHistory
                        saved = this.Update(industryHistory);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(IndustryHistory industryHistory)
            /// <summary>
            /// This method Updates a 'IndustryHistory' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'IndustryHistory_Update'.</param>
            /// </summary>
            /// <param name='industryHistory'>The 'IndustryHistory' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(IndustryHistory industryHistory)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(industryHistory != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.IndustryHistoryMethods.UpdateIndustryHistory;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateIndustryHistoryParameter(industryHistory);
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
