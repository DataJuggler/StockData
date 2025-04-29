

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

    #region class SectorHistoryController
    /// <summary>
    /// This class controls a(n) 'SectorHistory' object.
    /// </summary>
    public class SectorHistoryController
    {

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

            #region Delete(SectorHistory tempSectorHistory, DataManager dataManager)
            /// <summary>
            /// Deletes a 'SectorHistory' from the database
            /// This method calls the DataBridgeManager to execute the delete
            /// procedure 'SectorHistory_Delete'.
            /// </summary>
            /// <param name='sectorhistory'>The 'SectorHistory' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public static bool Delete(SectorHistory tempSectorHistory, DataManager dataManager)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteSectorHistory";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempsectorHistory exists before attemptintg to delete
                    if (tempSectorHistory != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteSectorHistoryMethod = SectorHistoryMethods.DeleteSectorHistory;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateSectorHistoryParameter(tempSectorHistory);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteSectorHistoryMethod, parameters, dataManager);

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

            #region FetchAll(SectorHistory tempSectorHistory, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'SectorHistory' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'SectorHistory_FetchAll'.</summary>
            /// <param name='tempSectorHistory'>A temporary SectorHistory for passing values.</param>
            /// <returns>A collection of 'SectorHistory' objects.</returns>
            public static List<SectorHistory> FetchAll(SectorHistory tempSectorHistory, DataManager dataManager)
            {
                // Initial value
                List<SectorHistory> sectorHistoryList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = SectorHistoryMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateSectorHistoryParameter(tempSectorHistory);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<SectorHistory> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        sectorHistoryList = (List<SectorHistory>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return sectorHistoryList;
            }
            #endregion

            #region Find(SectorHistory tempSectorHistory, DataManager dataManager)
            /// <summary>
            /// Finds a 'SectorHistory' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'SectorHistory_Find'</param>
            /// </summary>
            /// <param name='tempSectorHistory'>A temporary SectorHistory for passing values.</param>
            /// <returns>A 'SectorHistory' object if found else a null 'SectorHistory'.</returns>
            public static SectorHistory Find(SectorHistory tempSectorHistory, DataManager dataManager)
            {
                // Initial values
                SectorHistory sectorHistory = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if (tempSectorHistory != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = SectorHistoryMethods.FindSectorHistory;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateSectorHistoryParameter(tempSectorHistory);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, findMethod , parameters, dataManager);

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
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return sectorHistory;
            }
            #endregion

            #region Insert(SectorHistory sectorHistory, DataManager dataManager)
            /// <summary>
            /// Insert a 'SectorHistory' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'SectorHistory_Insert'.</param>
            /// </summary>
            /// <param name='sectorHistory'>The 'SectorHistory' object to insert.</param>
            /// <returns>The id (int) of the new  'SectorHistory' object that was inserted.</returns>
            public static int Insert(SectorHistory sectorHistory, DataManager dataManager)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If SectorHistoryexists
                    if (sectorHistory != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = SectorHistoryMethods.InsertSectorHistory;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateSectorHistoryParameter(sectorHistory);

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

            #region Save(ref SectorHistory sectorHistory, DataManager dataManager)
            /// <summary>
            /// Saves a 'SectorHistory' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='sectorHistory'>The 'SectorHistory' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static bool Save(ref SectorHistory sectorHistory, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // If the sectorHistory exists.
                if (sectorHistory != null)
                {
                    // Is this a new SectorHistory
                    if (sectorHistory.IsNew)
                    {
                        // Insert new SectorHistory
                        int newIdentity = Insert(sectorHistory, dataManager);

                        // if insert was successful
                        if (newIdentity > 0)
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
                        saved = Update(sectorHistory, dataManager);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(SectorHistory sectorHistory, DataManager dataManager)
            /// <summary>
            /// This method Updates a 'SectorHistory' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'SectorHistory_Update'.</param>
            /// </summary>
            /// <param name='sectorHistory'>The 'SectorHistory' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public static bool Update(SectorHistory sectorHistory, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if (sectorHistory != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = SectorHistoryMethods.UpdateSectorHistory;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateSectorHistoryParameter(sectorHistory);
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
