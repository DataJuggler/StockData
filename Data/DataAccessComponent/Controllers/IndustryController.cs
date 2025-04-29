

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

    #region class IndustryController
    /// <summary>
    /// This class controls a(n) 'Industry' object.
    /// </summary>
    public class IndustryController
    {

        #region Methods

            #region CreateIndustryParameter
            /// <summary>
            /// This method creates the parameter for a 'Industry' data operation.
            /// </summary>
            /// <param name='industry'>The 'Industry' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateIndustryParameter(Industry industry)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = industry;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(Industry tempIndustry, DataManager dataManager)
            /// <summary>
            /// Deletes a 'Industry' from the database
            /// This method calls the DataBridgeManager to execute the delete
            /// procedure 'Industry_Delete'.
            /// </summary>
            /// <param name='industry'>The 'Industry' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public static bool Delete(Industry tempIndustry, DataManager dataManager)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteIndustry";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempindustry exists before attemptintg to delete
                    if (tempIndustry != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteIndustryMethod = IndustryMethods.DeleteIndustry;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateIndustryParameter(tempIndustry);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteIndustryMethod, parameters, dataManager);

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

            #region FetchAll(Industry tempIndustry, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'Industry' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Industry_FetchAll'.</summary>
            /// <param name='tempIndustry'>A temporary Industry for passing values.</param>
            /// <returns>A collection of 'Industry' objects.</returns>
            public static List<Industry> FetchAll(Industry tempIndustry, DataManager dataManager)
            {
                // Initial value
                List<Industry> industryList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = IndustryMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateIndustryParameter(tempIndustry);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Industry> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        industryList = (List<Industry>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return industryList;
            }
            #endregion

            #region Find(Industry tempIndustry, DataManager dataManager)
            /// <summary>
            /// Finds a 'Industry' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Industry_Find'</param>
            /// </summary>
            /// <param name='tempIndustry'>A temporary Industry for passing values.</param>
            /// <returns>A 'Industry' object if found else a null 'Industry'.</returns>
            public static Industry Find(Industry tempIndustry, DataManager dataManager)
            {
                // Initial values
                Industry industry = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if (tempIndustry != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = IndustryMethods.FindIndustry;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateIndustryParameter(tempIndustry);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, findMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as Industry != null))
                        {
                            // Get ReturnObject
                            industry = (Industry) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return industry;
            }
            #endregion

            #region Insert(Industry industry, DataManager dataManager)
            /// <summary>
            /// Insert a 'Industry' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Industry_Insert'.</param>
            /// </summary>
            /// <param name='industry'>The 'Industry' object to insert.</param>
            /// <returns>The id (int) of the new  'Industry' object that was inserted.</returns>
            public static int Insert(Industry industry, DataManager dataManager)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If Industryexists
                    if (industry != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = IndustryMethods.InsertIndustry;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateIndustryParameter(industry);

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

            #region Save(ref Industry industry, DataManager dataManager)
            /// <summary>
            /// Saves a 'Industry' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='industry'>The 'Industry' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static bool Save(ref Industry industry, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // If the industry exists.
                if (industry != null)
                {
                    // Is this a new Industry
                    if (industry.IsNew)
                    {
                        // Insert new Industry
                        int newIdentity = Insert(industry, dataManager);

                        // if insert was successful
                        if (newIdentity > 0)
                        {
                            // Update Identity
                            industry.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update Industry
                        saved = Update(industry, dataManager);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Industry industry, DataManager dataManager)
            /// <summary>
            /// This method Updates a 'Industry' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Industry_Update'.</param>
            /// </summary>
            /// <param name='industry'>The 'Industry' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public static bool Update(Industry industry, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if (industry != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = IndustryMethods.UpdateIndustry;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateIndustryParameter(industry);
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
