

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

    #region class DoNotTrackController
    /// <summary>
    /// This class controls a(n) 'DoNotTrack' object.
    /// </summary>
    public class DoNotTrackController
    {

        #region Methods

            #region CreateDoNotTrackParameter
            /// <summary>
            /// This method creates the parameter for a 'DoNotTrack' data operation.
            /// </summary>
            /// <param name='donottrack'>The 'DoNotTrack' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateDoNotTrackParameter(DoNotTrack doNotTrack)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = doNotTrack;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(DoNotTrack tempDoNotTrack, DataManager dataManager)
            /// <summary>
            /// Deletes a 'DoNotTrack' from the database
            /// This method calls the DataBridgeManager to execute the delete
            /// procedure 'DoNotTrack_Delete'.
            /// </summary>
            /// <param name='donottrack'>The 'DoNotTrack' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public static bool Delete(DoNotTrack tempDoNotTrack, DataManager dataManager)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteDoNotTrack";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempdoNotTrack exists before attemptintg to delete
                    if (tempDoNotTrack != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteDoNotTrackMethod = DoNotTrackMethods.DeleteDoNotTrack;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDoNotTrackParameter(tempDoNotTrack);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteDoNotTrackMethod, parameters, dataManager);

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

            #region FetchAll(DoNotTrack tempDoNotTrack, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'DoNotTrack' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'DoNotTrack_FetchAll'.</summary>
            /// <param name='tempDoNotTrack'>A temporary DoNotTrack for passing values.</param>
            /// <returns>A collection of 'DoNotTrack' objects.</returns>
            public static List<DoNotTrack> FetchAll(DoNotTrack tempDoNotTrack, DataManager dataManager)
            {
                // Initial value
                List<DoNotTrack> doNotTrackList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = DoNotTrackMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateDoNotTrackParameter(tempDoNotTrack);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<DoNotTrack> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        doNotTrackList = (List<DoNotTrack>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return doNotTrackList;
            }
            #endregion

            #region Find(DoNotTrack tempDoNotTrack, DataManager dataManager)
            /// <summary>
            /// Finds a 'DoNotTrack' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'DoNotTrack_Find'</param>
            /// </summary>
            /// <param name='tempDoNotTrack'>A temporary DoNotTrack for passing values.</param>
            /// <returns>A 'DoNotTrack' object if found else a null 'DoNotTrack'.</returns>
            public static DoNotTrack Find(DoNotTrack tempDoNotTrack, DataManager dataManager)
            {
                // Initial values
                DoNotTrack doNotTrack = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if (tempDoNotTrack != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = DoNotTrackMethods.FindDoNotTrack;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDoNotTrackParameter(tempDoNotTrack);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, findMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as DoNotTrack != null))
                        {
                            // Get ReturnObject
                            doNotTrack = (DoNotTrack) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return doNotTrack;
            }
            #endregion

            #region Insert(DoNotTrack doNotTrack, DataManager dataManager)
            /// <summary>
            /// Insert a 'DoNotTrack' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'DoNotTrack_Insert'.</param>
            /// </summary>
            /// <param name='doNotTrack'>The 'DoNotTrack' object to insert.</param>
            /// <returns>The id (int) of the new  'DoNotTrack' object that was inserted.</returns>
            public static int Insert(DoNotTrack doNotTrack, DataManager dataManager)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If DoNotTrackexists
                    if (doNotTrack != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = DoNotTrackMethods.InsertDoNotTrack;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDoNotTrackParameter(doNotTrack);

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

            #region Save(ref DoNotTrack doNotTrack, DataManager dataManager)
            /// <summary>
            /// Saves a 'DoNotTrack' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='doNotTrack'>The 'DoNotTrack' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static bool Save(ref DoNotTrack doNotTrack, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // If the doNotTrack exists.
                if (doNotTrack != null)
                {
                    // Is this a new DoNotTrack
                    if (doNotTrack.IsNew)
                    {
                        // Insert new DoNotTrack
                        int newIdentity = Insert(doNotTrack, dataManager);

                        // if insert was successful
                        if (newIdentity > 0)
                        {
                            // Update Identity
                            doNotTrack.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update DoNotTrack
                        saved = Update(doNotTrack, dataManager);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(DoNotTrack doNotTrack, DataManager dataManager)
            /// <summary>
            /// This method Updates a 'DoNotTrack' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'DoNotTrack_Update'.</param>
            /// </summary>
            /// <param name='doNotTrack'>The 'DoNotTrack' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public static bool Update(DoNotTrack doNotTrack, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if (doNotTrack != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = DoNotTrackMethods.UpdateDoNotTrack;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDoNotTrackParameter(doNotTrack);
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
