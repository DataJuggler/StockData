

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

    #region class StockDayMethods
    /// <summary>
    /// This class contains methods for modifying a 'StockDay' object.
    /// </summary>
    public static class StockDayMethods
    {

        #region Methods

            #region DeleteStockDay(StockDay)
            /// <summary>
            /// This method deletes a 'StockDay' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'StockDay' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject DeleteStockDay(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteStockDayStoredProcedure deleteStockDayProc = null;

                    // verify the first parameters is a(n) 'StockDay'.
                    if (parameters[0].ObjectValue as StockDay != null)
                    {
                        // Create StockDay
                        StockDay stockDay = (StockDay) parameters[0].ObjectValue;

                        // verify stockDay exists
                        if(stockDay != null)
                        {
                            // Now create deleteStockDayProc from StockDayWriter
                            // The DataWriter converts the 'StockDay'
                            // to the SqlParameter[] array needed to delete a 'StockDay'.
                            deleteStockDayProc = StockDayWriter.CreateDeleteStockDayStoredProcedure(stockDay);
                        }
                    }

                    // Verify deleteStockDayProc exists
                    if(deleteStockDayProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = StockDayManager.DeleteStockDay(deleteStockDayProc, dataConnector);

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
            /// This method fetches all 'StockDay' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'StockDay' to delete.
            /// <returns>A PolymorphicObject object with all  'StockDays' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<StockDay> stockDayListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllStockDaysStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get StockDayParameter
                    // Declare Parameter
                    StockDay paramStockDay = null;

                    // verify the first parameters is a(n) 'StockDay'.
                    if (parameters[0].ObjectValue as StockDay != null)
                    {
                        // Get StockDayParameter
                        paramStockDay = (StockDay) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllStockDaysProc from StockDayWriter
                    fetchAllProc = StockDayWriter.CreateFetchAllStockDaysStoredProcedure(paramStockDay);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    stockDayListCollection = StockDayManager.FetchAllStockDays(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(stockDayListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = stockDayListCollection;
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

            #region FindStockDay(StockDay)
            /// <summary>
            /// This method finds a 'StockDay' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'StockDay' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject FindStockDay(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                StockDay stockDay = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindStockDayStoredProcedure findStockDayProc = null;

                    // verify the first parameters is a 'StockDay'.
                    if (parameters[0].ObjectValue as StockDay != null)
                    {
                        // Get StockDayParameter
                        StockDay paramStockDay = (StockDay) parameters[0].ObjectValue;

                        // verify paramStockDay exists
                        if(paramStockDay != null)
                        {
                            // Now create findStockDayProc from StockDayWriter
                            // The DataWriter converts the 'StockDay'
                            // to the SqlParameter[] array needed to find a 'StockDay'.
                            findStockDayProc = StockDayWriter.CreateFindStockDayStoredProcedure(paramStockDay);
                        }

                        // Verify findStockDayProc exists
                        if(findStockDayProc != null)
                        {
                            // Execute Find Stored Procedure
                            stockDay = StockDayManager.FindStockDay(findStockDayProc, dataConnector);

                            // if dataObject exists
                            if(stockDay != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = stockDay;
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

            #region InsertStockDay (StockDay)
            /// <summary>
            /// This method inserts a 'StockDay' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'StockDay' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject InsertStockDay(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                StockDay stockDay = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertStockDayStoredProcedure insertStockDayProc = null;

                    // verify the first parameters is a(n) 'StockDay'.
                    if (parameters[0].ObjectValue as StockDay != null)
                    {
                        // Create StockDay Parameter
                        stockDay = (StockDay) parameters[0].ObjectValue;

                        // verify stockDay exists
                        if(stockDay != null)
                        {
                            // Now create insertStockDayProc from StockDayWriter
                            // The DataWriter converts the 'StockDay'
                            // to the SqlParameter[] array needed to insert a 'StockDay'.
                            insertStockDayProc = StockDayWriter.CreateInsertStockDayStoredProcedure(stockDay);
                        }

                        // Verify insertStockDayProc exists
                        if(insertStockDayProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = StockDayManager.InsertStockDay(insertStockDayProc, dataConnector);
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

            #region UpdateStockDay (StockDay)
            /// <summary>
            /// This method updates a 'StockDay' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'StockDay' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal static PolymorphicObject UpdateStockDay(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                StockDay stockDay = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateStockDayStoredProcedure updateStockDayProc = null;

                    // verify the first parameters is a(n) 'StockDay'.
                    if (parameters[0].ObjectValue as StockDay != null)
                    {
                        // Create StockDay Parameter
                        stockDay = (StockDay) parameters[0].ObjectValue;

                        // verify stockDay exists
                        if(stockDay != null)
                        {
                            // Now create updateStockDayProc from StockDayWriter
                            // The DataWriter converts the 'StockDay'
                            // to the SqlParameter[] array needed to update a 'StockDay'.
                            updateStockDayProc = StockDayWriter.CreateUpdateStockDayStoredProcedure(stockDay);
                        }

                        // Verify updateStockDayProc exists
                        if(updateStockDayProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = StockDayManager.UpdateStockDay(updateStockDayProc, dataConnector);

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
