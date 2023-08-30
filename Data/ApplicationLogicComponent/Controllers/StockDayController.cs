

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

    #region class StockDayController
    /// <summary>
    /// This class controls a(n) 'StockDay' object.
    /// </summary>
    public class StockDayController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'StockDayController' object.
        /// </summary>
        public StockDayController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateStockDayParameter
            /// <summary>
            /// This method creates the parameter for a 'StockDay' data operation.
            /// </summary>
            /// <param name='stockday'>The 'StockDay' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateStockDayParameter(StockDay stockDay)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = stockDay;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(StockDay tempStockDay)
            /// <summary>
            /// Deletes a 'StockDay' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'StockDay_Delete'.
            /// </summary>
            /// <param name='stockday'>The 'StockDay' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(StockDay tempStockDay)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteStockDay";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempstockDay exists before attemptintg to delete
                    if(tempStockDay != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteStockDayMethod = this.AppController.DataBridge.DataOperations.StockDayMethods.DeleteStockDay;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateStockDayParameter(tempStockDay);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteStockDayMethod, parameters);

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

            #region FetchAll(StockDay tempStockDay)
            /// <summary>
            /// This method fetches a collection of 'StockDay' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'StockDay_FetchAll'.</summary>
            /// <param name='tempStockDay'>A temporary StockDay for passing values.</param>
            /// <returns>A collection of 'StockDay' objects.</returns>
            public List<StockDay> FetchAll(StockDay tempStockDay)
            {
                // Initial value
                List<StockDay> stockDayList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.StockDayMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateStockDayParameter(tempStockDay);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<StockDay> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        stockDayList = (List<StockDay>) returnObject.ObjectValue;
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
                return stockDayList;
            }
            #endregion

            #region Find(StockDay tempStockDay)
            /// <summary>
            /// Finds a 'StockDay' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'StockDay_Find'</param>
            /// </summary>
            /// <param name='tempStockDay'>A temporary StockDay for passing values.</param>
            /// <returns>A 'StockDay' object if found else a null 'StockDay'.</returns>
            public StockDay Find(StockDay tempStockDay)
            {
                // Initial values
                StockDay stockDay = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempStockDay != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.StockDayMethods.FindStockDay;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateStockDayParameter(tempStockDay);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as StockDay != null))
                        {
                            // Get ReturnObject
                            stockDay = (StockDay) returnObject.ObjectValue;
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
                return stockDay;
            }
            #endregion

            #region Insert(StockDay stockDay)
            /// <summary>
            /// Insert a 'StockDay' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'StockDay_Insert'.</param>
            /// </summary>
            /// <param name='stockDay'>The 'StockDay' object to insert.</param>
            /// <returns>The id (int) of the new  'StockDay' object that was inserted.</returns>
            public int Insert(StockDay stockDay)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If StockDayexists
                    if(stockDay != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.StockDayMethods.InsertStockDay;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateStockDayParameter(stockDay);

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

            #region Save(ref StockDay stockDay)
            /// <summary>
            /// Saves a 'StockDay' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='stockDay'>The 'StockDay' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref StockDay stockDay)
            {
                // Initial value
                bool saved = false;

                // If the stockDay exists.
                if(stockDay != null)
                {
                    // Is this a new StockDay
                    if(stockDay.IsNew)
                    {
                        // Insert new StockDay
                        int newIdentity = this.Insert(stockDay);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            stockDay.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update StockDay
                        saved = this.Update(stockDay);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(StockDay stockDay)
            /// <summary>
            /// This method Updates a 'StockDay' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'StockDay_Update'.</param>
            /// </summary>
            /// <param name='stockDay'>The 'StockDay' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(StockDay stockDay)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(stockDay != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.StockDayMethods.UpdateStockDay;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateStockDayParameter(stockDay);
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
