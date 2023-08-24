

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

    #region class IndustryController
    /// <summary>
    /// This class controls a(n) 'Industry' object.
    /// </summary>
    public class IndustryController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'IndustryController' object.
        /// </summary>
        public IndustryController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

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

            #region Delete(Industry tempIndustry)
            /// <summary>
            /// Deletes a 'Industry' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'Industry_Delete'.
            /// </summary>
            /// <param name='industry'>The 'Industry' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(Industry tempIndustry)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteIndustry";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempindustry exists before attemptintg to delete
                    if(tempIndustry != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteIndustryMethod = this.AppController.DataBridge.DataOperations.IndustryMethods.DeleteIndustry;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateIndustryParameter(tempIndustry);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteIndustryMethod, parameters);

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

            #region FetchAll(Industry tempIndustry)
            /// <summary>
            /// This method fetches a collection of 'Industry' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Industry_FetchAll'.</summary>
            /// <param name='tempIndustry'>A temporary Industry for passing values.</param>
            /// <returns>A collection of 'Industry' objects.</returns>
            public List<Industry> FetchAll(Industry tempIndustry)
            {
                // Initial value
                List<Industry> industryList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.IndustryMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateIndustryParameter(tempIndustry);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Industry> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        industryList = (List<Industry>) returnObject.ObjectValue;
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
                return industryList;
            }
            #endregion

            #region Find(Industry tempIndustry)
            /// <summary>
            /// Finds a 'Industry' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Industry_Find'</param>
            /// </summary>
            /// <param name='tempIndustry'>A temporary Industry for passing values.</param>
            /// <returns>A 'Industry' object if found else a null 'Industry'.</returns>
            public Industry Find(Industry tempIndustry)
            {
                // Initial values
                Industry industry = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempIndustry != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.IndustryMethods.FindIndustry;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateIndustryParameter(tempIndustry);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

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
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return industry;
            }
            #endregion

            #region Insert(Industry industry)
            /// <summary>
            /// Insert a 'Industry' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Industry_Insert'.</param>
            /// </summary>
            /// <param name='industry'>The 'Industry' object to insert.</param>
            /// <returns>The id (int) of the new  'Industry' object that was inserted.</returns>
            public int Insert(Industry industry)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If Industryexists
                    if(industry != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.IndustryMethods.InsertIndustry;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateIndustryParameter(industry);

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

            #region Save(ref Industry industry)
            /// <summary>
            /// Saves a 'Industry' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='industry'>The 'Industry' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref Industry industry)
            {
                // Initial value
                bool saved = false;

                // If the industry exists.
                if(industry != null)
                {
                    // Is this a new Industry
                    if(industry.IsNew)
                    {
                        // Insert new Industry
                        int newIdentity = this.Insert(industry);

                        // if insert was successful
                        if(newIdentity > 0)
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
                        saved = this.Update(industry);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Industry industry)
            /// <summary>
            /// This method Updates a 'Industry' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Industry_Update'.</param>
            /// </summary>
            /// <param name='industry'>The 'Industry' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(Industry industry)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(industry != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.IndustryMethods.UpdateIndustry;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateIndustryParameter(industry);
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
