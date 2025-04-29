

#region using statements

using DataAccessComponent.Data;
using DataAccessComponent.Data.Writers;
using DataAccessComponent.DataBridge;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace DataAccessComponent.DataOperations
{

    #region class StockMethods
    /// <summary>
    /// This class contains methods for modifying a 'Stock' object.
    /// </summary>
    public static class StockMethods
    {

        #region Methods

            #region DeleteStock(Stock)
            /// <summary>
            /// This method deletes a 'Stock' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Stock' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject DeleteStock(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteStockStoredProcedure deleteStockProc = null;

                    // verify the first parameters is a(n) 'Stock'.
                    if (parameters[0].ObjectValue as Stock != null)
                    {
                        // Create Stock
                        Stock stock = (Stock) parameters[0].ObjectValue;

                        // verify stock exists
                        if(stock != null)
                        {
                            // Now create deleteStockProc from StockWriter
                            // The DataWriter converts the 'Stock'
                            // to the SqlParameter[] array needed to delete a 'Stock'.
                            deleteStockProc = StockWriter.CreateDeleteStockStoredProcedure(stock);
                        }
                    }

                    // Verify deleteStockProc exists
                    if(deleteStockProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = StockManager.DeleteStock(deleteStockProc, dataConnector);

                        // Create returnObject.Boolean
                        returnObject.Boolean = new NullableBoolean();

                        // If delete was successful
                        if(deleted)
                        {
                            // Set returnObject.Boolean.Value to true
                            returnObject.Boolean.Value = NullableBooleanEnum.True;
                        }
                        else
                        {
                            // Set returnObject.Boolean.Value to false
                            returnObject.Boolean.Value = NullableBooleanEnum.False;
                        }
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'Stock' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Stock' to delete.
            /// <returns>A PolymorphicObject object with all  'Stocks' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<Stock> stockListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllStocksStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get StockParameter
                    // Declare Parameter
                    Stock paramStock = null;

                    // verify the first parameters is a(n) 'Stock'.
                    if (parameters[0].ObjectValue as Stock != null)
                    {
                        // Get StockParameter
                        paramStock = (Stock) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllStocksProc from StockWriter
                    fetchAllProc = StockWriter.CreateFetchAllStocksStoredProcedure(paramStock);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    stockListCollection = StockManager.FetchAllStocks(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(stockListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = stockListCollection;
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FindStock(Stock)
            /// <summary>
            /// This method finds a 'Stock' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Stock' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject FindStock(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Stock stock = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindStockStoredProcedure findStockProc = null;

                    // verify the first parameters is a 'Stock'.
                    if (parameters[0].ObjectValue as Stock != null)
                    {
                        // Get StockParameter
                        Stock paramStock = (Stock) parameters[0].ObjectValue;

                        // verify paramStock exists
                        if(paramStock != null)
                        {
                            // Now create findStockProc from StockWriter
                            // The DataWriter converts the 'Stock'
                            // to the SqlParameter[] array needed to find a 'Stock'.
                            findStockProc = StockWriter.CreateFindStockStoredProcedure(paramStock);
                        }

                        // Verify findStockProc exists
                        if(findStockProc != null)
                        {
                            // Execute Find Stored Procedure
                            stock = StockManager.FindStock(findStockProc, dataConnector);

                            // if dataObject exists
                            if(stock != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = stock;
                            }
                        }
                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region InsertStock (Stock)
            /// <summary>
            /// This method inserts a 'Stock' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Stock' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject InsertStock(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Stock stock = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertStockStoredProcedure insertStockProc = null;

                    // verify the first parameters is a(n) 'Stock'.
                    if (parameters[0].ObjectValue as Stock != null)
                    {
                        // Create Stock Parameter
                        stock = (Stock) parameters[0].ObjectValue;

                        // verify stock exists
                        if(stock != null)
                        {
                            // Now create insertStockProc from StockWriter
                            // The DataWriter converts the 'Stock'
                            // to the SqlParameter[] array needed to insert a 'Stock'.
                            insertStockProc = StockWriter.CreateInsertStockStoredProcedure(stock);
                        }

                        // Verify insertStockProc exists
                        if(insertStockProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = StockManager.InsertStock(insertStockProc, dataConnector);
                        }

                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region UpdateStock (Stock)
            /// <summary>
            /// This method updates a 'Stock' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Stock' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal static PolymorphicObject UpdateStock(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Stock stock = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateStockStoredProcedure updateStockProc = null;

                    // verify the first parameters is a(n) 'Stock'.
                    if (parameters[0].ObjectValue as Stock != null)
                    {
                        // Create Stock Parameter
                        stock = (Stock) parameters[0].ObjectValue;

                        // verify stock exists
                        if(stock != null)
                        {
                            // Now create updateStockProc from StockWriter
                            // The DataWriter converts the 'Stock'
                            // to the SqlParameter[] array needed to update a 'Stock'.
                            updateStockProc = StockWriter.CreateUpdateStockStoredProcedure(stock);
                        }

                        // Verify updateStockProc exists
                        if(updateStockProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = StockManager.UpdateStock(updateStockProc, dataConnector);

                            // Create returnObject.Boolean
                            returnObject.Boolean = new NullableBoolean();

                            // If save was successful
                            if(saved)
                            {
                                // Set returnObject.Boolean.Value to true
                                returnObject.Boolean.Value = NullableBooleanEnum.True;
                            }
                            else
                            {
                                // Set returnObject.Boolean.Value to false
                                returnObject.Boolean.Value = NullableBooleanEnum.False;
                            }
                        }
                        else
                        {
                            // Raise Error Data Connection Not Available
                            throw new Exception("The database connection is not available.");
                        }
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

        #endregion

    }
    #endregion

}
