

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

    #region class DailyPriceDataMethods
    /// <summary>
    /// This class contains methods for modifying a 'DailyPriceData' object.
    /// </summary>
    public static class DailyPriceDataMethods
    {

        #region Methods

            #region DeleteDailyPriceData(DailyPriceData)
            /// <summary>
            /// This method deletes a 'DailyPriceData' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DailyPriceData' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject DeleteDailyPriceData(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteDailyPriceDataStoredProcedure deleteDailyPriceDataProc = null;

                    // verify the first parameters is a(n) 'DailyPriceData'.
                    if (parameters[0].ObjectValue as DailyPriceData != null)
                    {
                        // Create DailyPriceData
                        DailyPriceData dailyPriceData = (DailyPriceData) parameters[0].ObjectValue;

                        // verify dailyPriceData exists
                        if(dailyPriceData != null)
                        {
                            // Now create deleteDailyPriceDataProc from DailyPriceDataWriter
                            // The DataWriter converts the 'DailyPriceData'
                            // to the SqlParameter[] array needed to delete a 'DailyPriceData'.
                            deleteDailyPriceDataProc = DailyPriceDataWriter.CreateDeleteDailyPriceDataStoredProcedure(dailyPriceData);
                        }
                    }

                    // Verify deleteDailyPriceDataProc exists
                    if(deleteDailyPriceDataProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = DailyPriceDataManager.DeleteDailyPriceData(deleteDailyPriceDataProc, dataConnector);

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
            /// This method fetches all 'DailyPriceData' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DailyPriceData' to delete.
            /// <returns>A PolymorphicObject object with all  'DailyPriceDatas' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<DailyPriceData> dailyPriceDataListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllDailyPriceDatasStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get DailyPriceDataParameter
                    // Declare Parameter
                    DailyPriceData paramDailyPriceData = null;

                    // verify the first parameters is a(n) 'DailyPriceData'.
                    if (parameters[0].ObjectValue as DailyPriceData != null)
                    {
                        // Get DailyPriceDataParameter
                        paramDailyPriceData = (DailyPriceData) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllDailyPriceDatasProc from DailyPriceDataWriter
                    fetchAllProc = DailyPriceDataWriter.CreateFetchAllDailyPriceDatasStoredProcedure(paramDailyPriceData);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    dailyPriceDataListCollection = DailyPriceDataManager.FetchAllDailyPriceDatas(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(dailyPriceDataListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = dailyPriceDataListCollection;
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

            #region FindDailyPriceData(DailyPriceData)
            /// <summary>
            /// This method finds a 'DailyPriceData' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DailyPriceData' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject FindDailyPriceData(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                DailyPriceData dailyPriceData = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindDailyPriceDataStoredProcedure findDailyPriceDataProc = null;

                    // verify the first parameters is a 'DailyPriceData'.
                    if (parameters[0].ObjectValue as DailyPriceData != null)
                    {
                        // Get DailyPriceDataParameter
                        DailyPriceData paramDailyPriceData = (DailyPriceData) parameters[0].ObjectValue;

                        // verify paramDailyPriceData exists
                        if(paramDailyPriceData != null)
                        {
                            // Now create findDailyPriceDataProc from DailyPriceDataWriter
                            // The DataWriter converts the 'DailyPriceData'
                            // to the SqlParameter[] array needed to find a 'DailyPriceData'.
                            findDailyPriceDataProc = DailyPriceDataWriter.CreateFindDailyPriceDataStoredProcedure(paramDailyPriceData);
                        }

                        // Verify findDailyPriceDataProc exists
                        if(findDailyPriceDataProc != null)
                        {
                            // Execute Find Stored Procedure
                            dailyPriceData = DailyPriceDataManager.FindDailyPriceData(findDailyPriceDataProc, dataConnector);

                            // if dataObject exists
                            if(dailyPriceData != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = dailyPriceData;
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

            #region InsertDailyPriceData (DailyPriceData)
            /// <summary>
            /// This method inserts a 'DailyPriceData' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DailyPriceData' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject InsertDailyPriceData(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                DailyPriceData dailyPriceData = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertDailyPriceDataStoredProcedure insertDailyPriceDataProc = null;

                    // verify the first parameters is a(n) 'DailyPriceData'.
                    if (parameters[0].ObjectValue as DailyPriceData != null)
                    {
                        // Create DailyPriceData Parameter
                        dailyPriceData = (DailyPriceData) parameters[0].ObjectValue;

                        // verify dailyPriceData exists
                        if(dailyPriceData != null)
                        {
                            // Now create insertDailyPriceDataProc from DailyPriceDataWriter
                            // The DataWriter converts the 'DailyPriceData'
                            // to the SqlParameter[] array needed to insert a 'DailyPriceData'.
                            insertDailyPriceDataProc = DailyPriceDataWriter.CreateInsertDailyPriceDataStoredProcedure(dailyPriceData);
                        }

                        // Verify insertDailyPriceDataProc exists
                        if(insertDailyPriceDataProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = DailyPriceDataManager.InsertDailyPriceData(insertDailyPriceDataProc, dataConnector);
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

            #region UpdateDailyPriceData (DailyPriceData)
            /// <summary>
            /// This method updates a 'DailyPriceData' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DailyPriceData' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal static PolymorphicObject UpdateDailyPriceData(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                DailyPriceData dailyPriceData = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateDailyPriceDataStoredProcedure updateDailyPriceDataProc = null;

                    // verify the first parameters is a(n) 'DailyPriceData'.
                    if (parameters[0].ObjectValue as DailyPriceData != null)
                    {
                        // Create DailyPriceData Parameter
                        dailyPriceData = (DailyPriceData) parameters[0].ObjectValue;

                        // verify dailyPriceData exists
                        if(dailyPriceData != null)
                        {
                            // Now create updateDailyPriceDataProc from DailyPriceDataWriter
                            // The DataWriter converts the 'DailyPriceData'
                            // to the SqlParameter[] array needed to update a 'DailyPriceData'.
                            updateDailyPriceDataProc = DailyPriceDataWriter.CreateUpdateDailyPriceDataStoredProcedure(dailyPriceData);
                        }

                        // Verify updateDailyPriceDataProc exists
                        if(updateDailyPriceDataProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = DailyPriceDataManager.UpdateDailyPriceData(updateDailyPriceDataProc, dataConnector);

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
