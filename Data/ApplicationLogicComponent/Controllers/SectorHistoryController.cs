

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

    #region class SectorHistoryController
    /// <summary>
    /// This class controls a(n) 'SectorHistory' object.
    /// </summary>
    public class SectorHistoryController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'SectorHistoryController' object.
        /// </summary>
        public SectorHistoryController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateSectorHistoryParameter
            /// <summary>
            /// This method creates the parameter for a 'SectorHistory' data operation.
            /// </summary>
            /// <param name='sectorhistory'>The 'SectorHistory' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateSectorHistoryParameter(SectorHistory sectorHistory)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = sectorHistory;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(SectorHistory tempSectorHistory)
            /// <summary>
            /// Deletes a 'SectorHistory' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'SectorHistory_Delete'.
            /// </summary>
            /// <param name='sectorhistory'>The 'SectorHistory' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(SectorHistory tempSectorHistory)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteSectorHistory";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempsectorHistory exists before attemptintg to delete
                    if(tempSectorHistory != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteSectorHistoryMethod = this.AppController.DataBridge.DataOperations.SectorHistoryMethods.DeleteSectorHistory;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateSectorHistoryParameter(tempSectorHistory);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteSectorHistoryMethod, parameters);

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

            #region FetchAll(SectorHistory tempSectorHistory)
            /// <summary>
            /// This method fetches a collection of 'SectorHistory' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'SectorHistory_FetchAll'.</summary>
            /// <param name='tempSectorHistory'>A temporary SectorHistory for passing values.</param>
            /// <returns>A collection of 'SectorHistory' objects.</returns>
            public List<SectorHistory> FetchAll(SectorHistory tempSectorHistory)
            {
                // Initial value
                List<SectorHistory> sectorHistoryList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.SectorHistoryMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateSectorHistoryParameter(tempSectorHistory);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<SectorHistory> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        sectorHistoryList = (List<SectorHistory>) returnObject.ObjectValue;
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
                return sectorHistoryList;
            }
            #endregion

            #region Find(SectorHistory tempSectorHistory)
            /// <summary>
            /// Finds a 'SectorHistory' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'SectorHistory_Find'</param>
            /// </summary>
            /// <param name='tempSectorHistory'>A temporary SectorHistory for passing values.</param>
            /// <returns>A 'SectorHistory' object if found else a null 'SectorHistory'.</returns>
            public SectorHistory Find(SectorHistory tempSectorHistory)
            {
                // Initial values
                SectorHistory sectorHistory = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempSectorHistory != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.SectorHistoryMethods.FindSectorHistory;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateSectorHistoryParameter(tempSectorHistory);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as SectorHistory != null))
                        {
                            // Get ReturnObject
                            sectorHistory = (SectorHistory) returnObject.ObjectValue;
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
                return sectorHistory;
            }
            #endregion

            #region Insert(SectorHistory sectorHistory)
            /// <summary>
            /// Insert a 'SectorHistory' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'SectorHistory_Insert'.</param>
            /// </summary>
            /// <param name='sectorHistory'>The 'SectorHistory' object to insert.</param>
            /// <returns>The id (int) of the new  'SectorHistory' object that was inserted.</returns>
            public int Insert(SectorHistory sectorHistory)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If SectorHistoryexists
                    if(sectorHistory != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.SectorHistoryMethods.InsertSectorHistory;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateSectorHistoryParameter(sectorHistory);

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

            #region Save(ref SectorHistory sectorHistory)
            /// <summary>
            /// Saves a 'SectorHistory' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='sectorHistory'>The 'SectorHistory' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref SectorHistory sectorHistory)
            {
                // Initial value
                bool saved = false;

                // If the sectorHistory exists.
                if(sectorHistory != null)
                {
                    // Is this a new SectorHistory
                    if(sectorHistory.IsNew)
                    {
                        // Insert new SectorHistory
                        int newIdentity = this.Insert(sectorHistory);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            sectorHistory.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update SectorHistory
                        saved = this.Update(sectorHistory);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(SectorHistory sectorHistory)
            /// <summary>
            /// This method Updates a 'SectorHistory' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'SectorHistory_Update'.</param>
            /// </summary>
            /// <param name='sectorHistory'>The 'SectorHistory' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(SectorHistory sectorHistory)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(sectorHistory != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.SectorHistoryMethods.UpdateSectorHistory;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateSectorHistoryParameter(sectorHistory);
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
