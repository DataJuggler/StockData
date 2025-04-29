

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

    #region class IndustryMethods
    /// <summary>
    /// This class contains methods for modifying a 'Industry' object.
    /// </summary>
    public static class IndustryMethods
    {

        #region Methods

            #region DeleteIndustry(Industry)
            /// <summary>
            /// This method deletes a 'Industry' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Industry' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject DeleteIndustry(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteIndustryStoredProcedure deleteIndustryProc = null;

                    // verify the first parameters is a(n) 'Industry'.
                    if (parameters[0].ObjectValue as Industry != null)
                    {
                        // Create Industry
                        Industry industry = (Industry) parameters[0].ObjectValue;

                        // verify industry exists
                        if(industry != null)
                        {
                            // Now create deleteIndustryProc from IndustryWriter
                            // The DataWriter converts the 'Industry'
                            // to the SqlParameter[] array needed to delete a 'Industry'.
                            deleteIndustryProc = IndustryWriter.CreateDeleteIndustryStoredProcedure(industry);
                        }
                    }

                    // Verify deleteIndustryProc exists
                    if(deleteIndustryProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = IndustryManager.DeleteIndustry(deleteIndustryProc, dataConnector);

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
            /// This method fetches all 'Industry' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Industry' to delete.
            /// <returns>A PolymorphicObject object with all  'Industrys' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<Industry> industryListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllIndustrysStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get IndustryParameter
                    // Declare Parameter
                    Industry paramIndustry = null;

                    // verify the first parameters is a(n) 'Industry'.
                    if (parameters[0].ObjectValue as Industry != null)
                    {
                        // Get IndustryParameter
                        paramIndustry = (Industry) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllIndustrysProc from IndustryWriter
                    fetchAllProc = IndustryWriter.CreateFetchAllIndustrysStoredProcedure(paramIndustry);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    industryListCollection = IndustryManager.FetchAllIndustrys(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(industryListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = industryListCollection;
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

            #region FindIndustry(Industry)
            /// <summary>
            /// This method finds a 'Industry' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Industry' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject FindIndustry(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Industry industry = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindIndustryStoredProcedure findIndustryProc = null;

                    // verify the first parameters is a 'Industry'.
                    if (parameters[0].ObjectValue as Industry != null)
                    {
                        // Get IndustryParameter
                        Industry paramIndustry = (Industry) parameters[0].ObjectValue;

                        // verify paramIndustry exists
                        if(paramIndustry != null)
                        {
                            // Now create findIndustryProc from IndustryWriter
                            // The DataWriter converts the 'Industry'
                            // to the SqlParameter[] array needed to find a 'Industry'.
                            findIndustryProc = IndustryWriter.CreateFindIndustryStoredProcedure(paramIndustry);
                        }

                        // Verify findIndustryProc exists
                        if(findIndustryProc != null)
                        {
                            // Execute Find Stored Procedure
                            industry = IndustryManager.FindIndustry(findIndustryProc, dataConnector);

                            // if dataObject exists
                            if(industry != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = industry;
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

            #region InsertIndustry (Industry)
            /// <summary>
            /// This method inserts a 'Industry' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Industry' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject InsertIndustry(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Industry industry = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertIndustryStoredProcedure insertIndustryProc = null;

                    // verify the first parameters is a(n) 'Industry'.
                    if (parameters[0].ObjectValue as Industry != null)
                    {
                        // Create Industry Parameter
                        industry = (Industry) parameters[0].ObjectValue;

                        // verify industry exists
                        if(industry != null)
                        {
                            // Now create insertIndustryProc from IndustryWriter
                            // The DataWriter converts the 'Industry'
                            // to the SqlParameter[] array needed to insert a 'Industry'.
                            insertIndustryProc = IndustryWriter.CreateInsertIndustryStoredProcedure(industry);
                        }

                        // Verify insertIndustryProc exists
                        if(insertIndustryProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = IndustryManager.InsertIndustry(insertIndustryProc, dataConnector);
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

            #region UpdateIndustry (Industry)
            /// <summary>
            /// This method updates a 'Industry' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Industry' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal static PolymorphicObject UpdateIndustry(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Industry industry = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateIndustryStoredProcedure updateIndustryProc = null;

                    // verify the first parameters is a(n) 'Industry'.
                    if (parameters[0].ObjectValue as Industry != null)
                    {
                        // Create Industry Parameter
                        industry = (Industry) parameters[0].ObjectValue;

                        // verify industry exists
                        if(industry != null)
                        {
                            // Now create updateIndustryProc from IndustryWriter
                            // The DataWriter converts the 'Industry'
                            // to the SqlParameter[] array needed to update a 'Industry'.
                            updateIndustryProc = IndustryWriter.CreateUpdateIndustryStoredProcedure(industry);
                        }

                        // Verify updateIndustryProc exists
                        if(updateIndustryProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = IndustryManager.UpdateIndustry(updateIndustryProc, dataConnector);

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
