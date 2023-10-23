

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

    #region class DoNotTrackController
    /// <summary>
    /// This class controls a(n) 'DoNotTrack' object.
    /// </summary>
    public class DoNotTrackController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'DoNotTrackController' object.
        /// </summary>
        public DoNotTrackController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

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

            #region Delete(DoNotTrack tempDoNotTrack)
            /// <summary>
            /// Deletes a 'DoNotTrack' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'DoNotTrack_Delete'.
            /// </summary>
            /// <param name='donottrack'>The 'DoNotTrack' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(DoNotTrack tempDoNotTrack)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteDoNotTrack";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempdoNotTrack exists before attemptintg to delete
                    if(tempDoNotTrack != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteDoNotTrackMethod = this.AppController.DataBridge.DataOperations.DoNotTrackMethods.DeleteDoNotTrack;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDoNotTrackParameter(tempDoNotTrack);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteDoNotTrackMethod, parameters);

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

            #region FetchAll(DoNotTrack tempDoNotTrack)
            /// <summary>
            /// This method fetches a collection of 'DoNotTrack' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'DoNotTrack_FetchAll'.</summary>
            /// <param name='tempDoNotTrack'>A temporary DoNotTrack for passing values.</param>
            /// <returns>A collection of 'DoNotTrack' objects.</returns>
            public List<DoNotTrack> FetchAll(DoNotTrack tempDoNotTrack)
            {
                // Initial value
                List<DoNotTrack> doNotTrackList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.DoNotTrackMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateDoNotTrackParameter(tempDoNotTrack);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<DoNotTrack> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        doNotTrackList = (List<DoNotTrack>) returnObject.ObjectValue;
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
                return doNotTrackList;
            }
            #endregion

            #region Find(DoNotTrack tempDoNotTrack)
            /// <summary>
            /// Finds a 'DoNotTrack' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'DoNotTrack_Find'</param>
            /// </summary>
            /// <param name='tempDoNotTrack'>A temporary DoNotTrack for passing values.</param>
            /// <returns>A 'DoNotTrack' object if found else a null 'DoNotTrack'.</returns>
            public DoNotTrack Find(DoNotTrack tempDoNotTrack)
            {
                // Initial values
                DoNotTrack doNotTrack = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempDoNotTrack != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.DoNotTrackMethods.FindDoNotTrack;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDoNotTrackParameter(tempDoNotTrack);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

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
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return doNotTrack;
            }
            #endregion

            #region Insert(DoNotTrack doNotTrack)
            /// <summary>
            /// Insert a 'DoNotTrack' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'DoNotTrack_Insert'.</param>
            /// </summary>
            /// <param name='doNotTrack'>The 'DoNotTrack' object to insert.</param>
            /// <returns>The id (int) of the new  'DoNotTrack' object that was inserted.</returns>
            public int Insert(DoNotTrack doNotTrack)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If DoNotTrackexists
                    if(doNotTrack != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.DoNotTrackMethods.InsertDoNotTrack;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDoNotTrackParameter(doNotTrack);

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

            #region Save(ref DoNotTrack doNotTrack)
            /// <summary>
            /// Saves a 'DoNotTrack' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='doNotTrack'>The 'DoNotTrack' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref DoNotTrack doNotTrack)
            {
                // Initial value
                bool saved = false;

                // If the doNotTrack exists.
                if(doNotTrack != null)
                {
                    // Is this a new DoNotTrack
                    if(doNotTrack.IsNew)
                    {
                        // Insert new DoNotTrack
                        int newIdentity = this.Insert(doNotTrack);

                        // if insert was successful
                        if(newIdentity > 0)
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
                        saved = this.Update(doNotTrack);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(DoNotTrack doNotTrack)
            /// <summary>
            /// This method Updates a 'DoNotTrack' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'DoNotTrack_Update'.</param>
            /// </summary>
            /// <param name='doNotTrack'>The 'DoNotTrack' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(DoNotTrack doNotTrack)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(doNotTrack != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.DoNotTrackMethods.UpdateDoNotTrack;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDoNotTrackParameter(doNotTrack);
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
