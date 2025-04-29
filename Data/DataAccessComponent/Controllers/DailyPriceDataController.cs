

#region using statements

using DataAccessComponent.Data;
using DataAccessComponent.DataBridge;
using DataAccessComponent.DataOperations;
using DataAccessComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace DataAccessComponent.Controllers
{

    #region class DailyPriceDataController
    /// <summary>
    /// This class controls a(n) 'DailyPriceData' object.
    /// </summary>
    public class DailyPriceDataController
    {

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

            #region Delete(DailyPriceData tempDailyPriceData, DataManager dataManager)
            /// <summary>
            /// Deletes a 'DailyPriceData' from the database
            /// This method calls the DataBridgeManager to execute the delete
            /// procedure 'DailyPriceData_Delete'.
            /// </summary>
            /// <param name='dailypricedata'>The 'DailyPriceData' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public static bool Delete(DailyPriceData tempDailyPriceData, DataManager dataManager)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteDailyPriceData";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempdailyPriceData exists before attemptintg to delete
                    if (tempDailyPriceData != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteDailyPriceDataMethod = DailyPriceDataMethods.DeleteDailyPriceData;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDailyPriceDataParameter(tempDailyPriceData);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteDailyPriceDataMethod, parameters, dataManager);

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
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAll(DailyPriceData tempDailyPriceData, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'DailyPriceData' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'DailyPriceData_FetchAll'.</summary>
            /// <param name='tempDailyPriceData'>A temporary DailyPriceData for passing values.</param>
            /// <returns>A collection of 'DailyPriceData' objects.</returns>
            public static List<DailyPriceData> FetchAll(DailyPriceData tempDailyPriceData, DataManager dataManager)
            {
                // Initial value
                List<DailyPriceData> dailyPriceDataList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = DailyPriceDataMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateDailyPriceDataParameter(tempDailyPriceData);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<DailyPriceData> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        dailyPriceDataList = (List<DailyPriceData>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return dailyPriceDataList;
            }
            #endregion

            #region Find(DailyPriceData tempDailyPriceData, DataManager dataManager)
            /// <summary>
            /// Finds a 'DailyPriceData' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'DailyPriceData_Find'</param>
            /// </summary>
            /// <param name='tempDailyPriceData'>A temporary DailyPriceData for passing values.</param>
            /// <returns>A 'DailyPriceData' object if found else a null 'DailyPriceData'.</returns>
            public static DailyPriceData Find(DailyPriceData tempDailyPriceData, DataManager dataManager)
            {
                // Initial values
                DailyPriceData dailyPriceData = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if (tempDailyPriceData != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = DailyPriceDataMethods.FindDailyPriceData;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDailyPriceDataParameter(tempDailyPriceData);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, findMethod , parameters, dataManager);

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
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return dailyPriceData;
            }
            #endregion

            #region Insert(DailyPriceData dailyPriceData, DataManager dataManager)
            /// <summary>
            /// Insert a 'DailyPriceData' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'DailyPriceData_Insert'.</param>
            /// </summary>
            /// <param name='dailyPriceData'>The 'DailyPriceData' object to insert.</param>
            /// <returns>The id (int) of the new  'DailyPriceData' object that was inserted.</returns>
            public static int Insert(DailyPriceData dailyPriceData, DataManager dataManager)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If DailyPriceDataexists
                    if (dailyPriceData != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = DailyPriceDataMethods.InsertDailyPriceData;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDailyPriceDataParameter(dailyPriceData);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, insertMethod , parameters, dataManager);

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
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region Save(ref DailyPriceData dailyPriceData, DataManager dataManager)
            /// <summary>
            /// Saves a 'DailyPriceData' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='dailyPriceData'>The 'DailyPriceData' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static bool Save(ref DailyPriceData dailyPriceData, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // If the dailyPriceData exists.
                if (dailyPriceData != null)
                {
                    // Is this a new DailyPriceData
                    if (dailyPriceData.IsNew)
                    {
                        // Insert new DailyPriceData
                        int newIdentity = Insert(dailyPriceData, dataManager);

                        // if insert was successful
                        if (newIdentity > 0)
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
                        saved = Update(dailyPriceData, dataManager);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(DailyPriceData dailyPriceData, DataManager dataManager)
            /// <summary>
            /// This method Updates a 'DailyPriceData' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'DailyPriceData_Update'.</param>
            /// </summary>
            /// <param name='dailyPriceData'>The 'DailyPriceData' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public static bool Update(DailyPriceData dailyPriceData, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if (dailyPriceData != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = DailyPriceDataMethods.UpdateDailyPriceData;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDailyPriceDataParameter(dailyPriceData);
                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, updateMethod , parameters, dataManager);

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
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

    }
    #endregion

}
