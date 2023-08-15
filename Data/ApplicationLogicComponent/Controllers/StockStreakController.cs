

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

    #region class StockStreakController
    /// <summary>
    /// This class controls a(n) 'StockStreak' object.
    /// </summary>
    public class StockStreakController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'StockStreakController' object.
        /// </summary>
        public StockStreakController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateStockStreakParameter
            /// <summary>
            /// This method creates the parameter for a 'StockStreak' data operation.
            /// </summary>
            /// <param name='stockstreak'>The 'StockStreak' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateStockStreakParameter(StockStreak stockStreak)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = stockStreak;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(StockStreak tempStockStreak)
            /// <summary>
            /// Deletes a 'StockStreak' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'StockStreak_Delete'.
            /// </summary>
            /// <param name='stockstreak'>The 'StockStreak' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(StockStreak tempStockStreak)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteStockStreak";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempstockStreak exists before attemptintg to delete
                    if(tempStockStreak != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteStockStreakMethod = this.AppController.DataBridge.DataOperations.StockStreakMethods.DeleteStockStreak;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateStockStreakParameter(tempStockStreak);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteStockStreakMethod, parameters);

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

            #region FetchAll(StockStreak tempStockStreak)
            /// <summary>
            /// This method fetches a collection of 'StockStreak' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'StockStreak_FetchAll'.</summary>
            /// <param name='tempStockStreak'>A temporary StockStreak for passing values.</param>
            /// <returns>A collection of 'StockStreak' objects.</returns>
            public List<StockStreak> FetchAll(StockStreak tempStockStreak)
            {
                // Initial value
                List<StockStreak> stockStreakList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.StockStreakMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateStockStreakParameter(tempStockStreak);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<StockStreak> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        stockStreakList = (List<StockStreak>) returnObject.ObjectValue;
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
                return stockStreakList;
            }
            #endregion

            #region Find(StockStreak tempStockStreak)
            /// <summary>
            /// Finds a 'StockStreak' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'StockStreak_Find'</param>
            /// </summary>
            /// <param name='tempStockStreak'>A temporary StockStreak for passing values.</param>
            /// <returns>A 'StockStreak' object if found else a null 'StockStreak'.</returns>
            public StockStreak Find(StockStreak tempStockStreak)
            {
                // Initial values
                StockStreak stockStreak = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempStockStreak != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.StockStreakMethods.FindStockStreak;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateStockStreakParameter(tempStockStreak);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as StockStreak != null))
                        {
                            // Get ReturnObject
                            stockStreak = (StockStreak) returnObject.ObjectValue;
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
                return stockStreak;
            }
            #endregion

            #region Insert(StockStreak stockStreak)
            /// <summary>
            /// Insert a 'StockStreak' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'StockStreak_Insert'.</param>
            /// </summary>
            /// <param name='stockStreak'>The 'StockStreak' object to insert.</param>
            /// <returns>The id (int) of the new  'StockStreak' object that was inserted.</returns>
            public int Insert(StockStreak stockStreak)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If StockStreakexists
                    if(stockStreak != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.StockStreakMethods.InsertStockStreak;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateStockStreakParameter(stockStreak);

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

            #region Save(ref StockStreak stockStreak)
            /// <summary>
            /// Saves a 'StockStreak' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='stockStreak'>The 'StockStreak' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref StockStreak stockStreak)
            {
                // Initial value
                bool saved = false;

                // If the stockStreak exists.
                if(stockStreak != null)
                {
                    // Is this a new StockStreak
                    if(stockStreak.IsNew)
                    {
                        // Insert new StockStreak
                        int newIdentity = this.Insert(stockStreak);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            stockStreak.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update StockStreak
                        saved = this.Update(stockStreak);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(StockStreak stockStreak)
            /// <summary>
            /// This method Updates a 'StockStreak' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'StockStreak_Update'.</param>
            /// </summary>
            /// <param name='stockStreak'>The 'StockStreak' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(StockStreak stockStreak)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(stockStreak != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.StockStreakMethods.UpdateStockStreak;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateStockStreakParameter(stockStreak);
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
