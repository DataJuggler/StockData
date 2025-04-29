

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

    #region class StockStreakMethods
    /// <summary>
    /// This class contains methods for modifying a 'StockStreak' object.
    /// </summary>
    public static class StockStreakMethods
    {

        #region Methods

            #region DeleteStockStreak(StockStreak)
            /// <summary>
            /// This method deletes a 'StockStreak' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'StockStreak' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject DeleteStockStreak(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteStockStreakStoredProcedure deleteStockStreakProc = null;

                    // verify the first parameters is a(n) 'StockStreak'.
                    if (parameters[0].ObjectValue as StockStreak != null)
                    {
                        // Create StockStreak
                        StockStreak stockStreak = (StockStreak) parameters[0].ObjectValue;

                        // verify stockStreak exists
                        if(stockStreak != null)
                        {
                            // Now create deleteStockStreakProc from StockStreakWriter
                            // The DataWriter converts the 'StockStreak'
                            // to the SqlParameter[] array needed to delete a 'StockStreak'.
                            deleteStockStreakProc = StockStreakWriter.CreateDeleteStockStreakStoredProcedure(stockStreak);
                        }
                    }

                    // Verify deleteStockStreakProc exists
                    if(deleteStockStreakProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = StockStreakManager.DeleteStockStreak(deleteStockStreakProc, dataConnector);

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
            /// This method fetches all 'StockStreak' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'StockStreak' to delete.
            /// <returns>A PolymorphicObject object with all  'StockStreaks' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<StockStreak> stockStreakListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllStockStreaksStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get StockStreakParameter
                    // Declare Parameter
                    StockStreak paramStockStreak = null;

                    // verify the first parameters is a(n) 'StockStreak'.
                    if (parameters[0].ObjectValue as StockStreak != null)
                    {
                        // Get StockStreakParameter
                        paramStockStreak = (StockStreak) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllStockStreaksProc from StockStreakWriter
                    fetchAllProc = StockStreakWriter.CreateFetchAllStockStreaksStoredProcedure(paramStockStreak);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    stockStreakListCollection = StockStreakManager.FetchAllStockStreaks(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(stockStreakListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = stockStreakListCollection;
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

            #region FindStockStreak(StockStreak)
            /// <summary>
            /// This method finds a 'StockStreak' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'StockStreak' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject FindStockStreak(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                StockStreak stockStreak = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindStockStreakStoredProcedure findStockStreakProc = null;

                    // verify the first parameters is a 'StockStreak'.
                    if (parameters[0].ObjectValue as StockStreak != null)
                    {
                        // Get StockStreakParameter
                        StockStreak paramStockStreak = (StockStreak) parameters[0].ObjectValue;

                        // verify paramStockStreak exists
                        if(paramStockStreak != null)
                        {
                            // Now create findStockStreakProc from StockStreakWriter
                            // The DataWriter converts the 'StockStreak'
                            // to the SqlParameter[] array needed to find a 'StockStreak'.
                            findStockStreakProc = StockStreakWriter.CreateFindStockStreakStoredProcedure(paramStockStreak);
                        }

                        // Verify findStockStreakProc exists
                        if(findStockStreakProc != null)
                        {
                            // Execute Find Stored Procedure
                            stockStreak = StockStreakManager.FindStockStreak(findStockStreakProc, dataConnector);

                            // if dataObject exists
                            if(stockStreak != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = stockStreak;
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

            #region InsertStockStreak (StockStreak)
            /// <summary>
            /// This method inserts a 'StockStreak' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'StockStreak' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject InsertStockStreak(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                StockStreak stockStreak = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertStockStreakStoredProcedure insertStockStreakProc = null;

                    // verify the first parameters is a(n) 'StockStreak'.
                    if (parameters[0].ObjectValue as StockStreak != null)
                    {
                        // Create StockStreak Parameter
                        stockStreak = (StockStreak) parameters[0].ObjectValue;

                        // verify stockStreak exists
                        if(stockStreak != null)
                        {
                            // Now create insertStockStreakProc from StockStreakWriter
                            // The DataWriter converts the 'StockStreak'
                            // to the SqlParameter[] array needed to insert a 'StockStreak'.
                            insertStockStreakProc = StockStreakWriter.CreateInsertStockStreakStoredProcedure(stockStreak);
                        }

                        // Verify insertStockStreakProc exists
                        if(insertStockStreakProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = StockStreakManager.InsertStockStreak(insertStockStreakProc, dataConnector);
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

            #region UpdateStockStreak (StockStreak)
            /// <summary>
            /// This method updates a 'StockStreak' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'StockStreak' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal static PolymorphicObject UpdateStockStreak(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                StockStreak stockStreak = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateStockStreakStoredProcedure updateStockStreakProc = null;

                    // verify the first parameters is a(n) 'StockStreak'.
                    if (parameters[0].ObjectValue as StockStreak != null)
                    {
                        // Create StockStreak Parameter
                        stockStreak = (StockStreak) parameters[0].ObjectValue;

                        // verify stockStreak exists
                        if(stockStreak != null)
                        {
                            // Now create updateStockStreakProc from StockStreakWriter
                            // The DataWriter converts the 'StockStreak'
                            // to the SqlParameter[] array needed to update a 'StockStreak'.
                            updateStockStreakProc = StockStreakWriter.CreateUpdateStockStreakStoredProcedure(stockStreak);
                        }

                        // Verify updateStockStreakProc exists
                        if(updateStockStreakProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = StockStreakManager.UpdateStockStreak(updateStockStreakProc, dataConnector);

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
