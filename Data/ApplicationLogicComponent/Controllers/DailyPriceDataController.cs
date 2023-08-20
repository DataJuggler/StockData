

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

    #region class DailyPriceDataController
    /// <summary>
    /// This class controls a(n) 'DailyPriceData' object.
    /// </summary>
    public class DailyPriceDataController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'DailyPriceDataController' object.
        /// </summary>
        public DailyPriceDataController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateDailyPriceDataParameter
            /// <summary>
            /// This method creates the parameter for a 'DailyPriceData' data operation.
            /// </summary>
            /// <param name='dailypricedata'>The 'DailyPriceData' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateDailyPriceDataParameter(DailyPriceData dailyPriceData)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = dailyPriceData;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(DailyPriceData tempDailyPriceData)
            /// <summary>
            /// Deletes a 'DailyPriceData' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'DailyPriceData_Delete'.
            /// </summary>
            /// <param name='dailypricedata'>The 'DailyPriceData' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(DailyPriceData tempDailyPriceData)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteDailyPriceData";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempdailyPriceData exists before attemptintg to delete
                    if(tempDailyPriceData != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteDailyPriceDataMethod = this.AppController.DataBridge.DataOperations.DailyPriceDataMethods.DeleteDailyPriceData;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDailyPriceDataParameter(tempDailyPriceData);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteDailyPriceDataMethod, parameters);

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

            #region FetchAll(DailyPriceData tempDailyPriceData)
            /// <summary>
            /// This method fetches a collection of 'DailyPriceData' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'DailyPriceData_FetchAll'.</summary>
            /// <param name='tempDailyPriceData'>A temporary DailyPriceData for passing values.</param>
            /// <returns>A collection of 'DailyPriceData' objects.</returns>
            public List<DailyPriceData> FetchAll(DailyPriceData tempDailyPriceData)
            {
                // Initial value
                List<DailyPriceData> dailyPriceDataList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.DailyPriceDataMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateDailyPriceDataParameter(tempDailyPriceData);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<DailyPriceData> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        dailyPriceDataList = (List<DailyPriceData>) returnObject.ObjectValue;
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
                return dailyPriceDataList;
            }
            #endregion

            #region Find(DailyPriceData tempDailyPriceData)
            /// <summary>
            /// Finds a 'DailyPriceData' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'DailyPriceData_Find'</param>
            /// </summary>
            /// <param name='tempDailyPriceData'>A temporary DailyPriceData for passing values.</param>
            /// <returns>A 'DailyPriceData' object if found else a null 'DailyPriceData'.</returns>
            public DailyPriceData Find(DailyPriceData tempDailyPriceData)
            {
                // Initial values
                DailyPriceData dailyPriceData = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempDailyPriceData != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.DailyPriceDataMethods.FindDailyPriceData;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDailyPriceDataParameter(tempDailyPriceData);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as DailyPriceData != null))
                        {
                            // Get ReturnObject
                            dailyPriceData = (DailyPriceData) returnObject.ObjectValue;
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
                return dailyPriceData;
            }
            #endregion

            #region Insert(DailyPriceData dailyPriceData)
            /// <summary>
            /// Insert a 'DailyPriceData' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'DailyPriceData_Insert'.</param>
            /// </summary>
            /// <param name='dailyPriceData'>The 'DailyPriceData' object to insert.</param>
            /// <returns>The id (int) of the new  'DailyPriceData' object that was inserted.</returns>
            public int Insert(DailyPriceData dailyPriceData)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If DailyPriceDataexists
                    if(dailyPriceData != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.DailyPriceDataMethods.InsertDailyPriceData;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDailyPriceDataParameter(dailyPriceData);

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

            #region Save(ref DailyPriceData dailyPriceData)
            /// <summary>
            /// Saves a 'DailyPriceData' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='dailyPriceData'>The 'DailyPriceData' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref DailyPriceData dailyPriceData)
            {
                // Initial value
                bool saved = false;

                // If the dailyPriceData exists.
                if(dailyPriceData != null)
                {
                    // Is this a new DailyPriceData
                    if(dailyPriceData.IsNew)
                    {
                        // Insert new DailyPriceData
                        int newIdentity = this.Insert(dailyPriceData);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            dailyPriceData.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update DailyPriceData
                        saved = this.Update(dailyPriceData);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(DailyPriceData dailyPriceData)
            /// <summary>
            /// This method Updates a 'DailyPriceData' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'DailyPriceData_Update'.</param>
            /// </summary>
            /// <param name='dailyPriceData'>The 'DailyPriceData' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(DailyPriceData dailyPriceData)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(dailyPriceData != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.DailyPriceDataMethods.UpdateDailyPriceData;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDailyPriceDataParameter(dailyPriceData);
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
