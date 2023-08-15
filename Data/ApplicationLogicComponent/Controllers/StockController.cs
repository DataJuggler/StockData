

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

    #region class StockController
    /// <summary>
    /// This class controls a(n) 'Stock' object.
    /// </summary>
    public class StockController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'StockController' object.
        /// </summary>
        public StockController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateStockParameter
            /// <summary>
            /// This method creates the parameter for a 'Stock' data operation.
            /// </summary>
            /// <param name='stock'>The 'Stock' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateStockParameter(Stock stock)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = stock;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(Stock tempStock)
            /// <summary>
            /// Deletes a 'Stock' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'Stock_Delete'.
            /// </summary>
            /// <param name='stock'>The 'Stock' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(Stock tempStock)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteStock";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempstock exists before attemptintg to delete
                    if(tempStock != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteStockMethod = this.AppController.DataBridge.DataOperations.StockMethods.DeleteStock;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateStockParameter(tempStock);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteStockMethod, parameters);

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

            #region FetchAll(Stock tempStock)
            /// <summary>
            /// This method fetches a collection of 'Stock' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Stock_FetchAll'.</summary>
            /// <param name='tempStock'>A temporary Stock for passing values.</param>
            /// <returns>A collection of 'Stock' objects.</returns>
            public List<Stock> FetchAll(Stock tempStock)
            {
                // Initial value
                List<Stock> stockList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.StockMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateStockParameter(tempStock);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Stock> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        stockList = (List<Stock>) returnObject.ObjectValue;
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
                return stockList;
            }
            #endregion

            #region Find(Stock tempStock)
            /// <summary>
            /// Finds a 'Stock' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Stock_Find'</param>
            /// </summary>
            /// <param name='tempStock'>A temporary Stock for passing values.</param>
            /// <returns>A 'Stock' object if found else a null 'Stock'.</returns>
            public Stock Find(Stock tempStock)
            {
                // Initial values
                Stock stock = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempStock != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.StockMethods.FindStock;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateStockParameter(tempStock);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as Stock != null))
                        {
                            // Get ReturnObject
                            stock = (Stock) returnObject.ObjectValue;
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
                return stock;
            }
            #endregion

            #region Insert(Stock stock)
            /// <summary>
            /// Insert a 'Stock' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Stock_Insert'.</param>
            /// </summary>
            /// <param name='stock'>The 'Stock' object to insert.</param>
            /// <returns>The id (int) of the new  'Stock' object that was inserted.</returns>
            public int Insert(Stock stock)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If Stockexists
                    if(stock != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.StockMethods.InsertStock;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateStockParameter(stock);

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

            #region Save(ref Stock stock)
            /// <summary>
            /// Saves a 'Stock' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='stock'>The 'Stock' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref Stock stock)
            {
                // Initial value
                bool saved = false;

                // If the stock exists.
                if(stock != null)
                {
                    // Is this a new Stock
                    if(stock.IsNew)
                    {
                        // Insert new Stock
                        int newIdentity = this.Insert(stock);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            stock.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update Stock
                        saved = this.Update(stock);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Stock stock)
            /// <summary>
            /// This method Updates a 'Stock' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Stock_Update'.</param>
            /// </summary>
            /// <param name='stock'>The 'Stock' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(Stock stock)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(stock != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.StockMethods.UpdateStock;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateStockParameter(stock);
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
