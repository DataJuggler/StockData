

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

    #region class SectorController
    /// <summary>
    /// This class controls a(n) 'Sector' object.
    /// </summary>
    public class SectorController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'SectorController' object.
        /// </summary>
        public SectorController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateSectorParameter
            /// <summary>
            /// This method creates the parameter for a 'Sector' data operation.
            /// </summary>
            /// <param name='sector'>The 'Sector' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateSectorParameter(Sector sector)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = sector;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(Sector tempSector)
            /// <summary>
            /// Deletes a 'Sector' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'Sector_Delete'.
            /// </summary>
            /// <param name='sector'>The 'Sector' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(Sector tempSector)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteSector";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempsector exists before attemptintg to delete
                    if(tempSector != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteSectorMethod = this.AppController.DataBridge.DataOperations.SectorMethods.DeleteSector;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateSectorParameter(tempSector);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteSectorMethod, parameters);

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

            #region FetchAll(Sector tempSector)
            /// <summary>
            /// This method fetches a collection of 'Sector' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Sector_FetchAll'.</summary>
            /// <param name='tempSector'>A temporary Sector for passing values.</param>
            /// <returns>A collection of 'Sector' objects.</returns>
            public List<Sector> FetchAll(Sector tempSector)
            {
                // Initial value
                List<Sector> sectorList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.SectorMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateSectorParameter(tempSector);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Sector> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        sectorList = (List<Sector>) returnObject.ObjectValue;
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
                return sectorList;
            }
            #endregion

            #region Find(Sector tempSector)
            /// <summary>
            /// Finds a 'Sector' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Sector_Find'</param>
            /// </summary>
            /// <param name='tempSector'>A temporary Sector for passing values.</param>
            /// <returns>A 'Sector' object if found else a null 'Sector'.</returns>
            public Sector Find(Sector tempSector)
            {
                // Initial values
                Sector sector = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempSector != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.SectorMethods.FindSector;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateSectorParameter(tempSector);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as Sector != null))
                        {
                            // Get ReturnObject
                            sector = (Sector) returnObject.ObjectValue;
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
                return sector;
            }
            #endregion

            #region Insert(Sector sector)
            /// <summary>
            /// Insert a 'Sector' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Sector_Insert'.</param>
            /// </summary>
            /// <param name='sector'>The 'Sector' object to insert.</param>
            /// <returns>The id (int) of the new  'Sector' object that was inserted.</returns>
            public int Insert(Sector sector)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If Sectorexists
                    if(sector != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.SectorMethods.InsertSector;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateSectorParameter(sector);

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

            #region Save(ref Sector sector)
            /// <summary>
            /// Saves a 'Sector' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='sector'>The 'Sector' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref Sector sector)
            {
                // Initial value
                bool saved = false;

                // If the sector exists.
                if(sector != null)
                {
                    // Is this a new Sector
                    if(sector.IsNew)
                    {
                        // Insert new Sector
                        int newIdentity = this.Insert(sector);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            sector.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update Sector
                        saved = this.Update(sector);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Sector sector)
            /// <summary>
            /// This method Updates a 'Sector' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Sector_Update'.</param>
            /// </summary>
            /// <param name='sector'>The 'Sector' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(Sector sector)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(sector != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.SectorMethods.UpdateSector;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateSectorParameter(sector);
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
