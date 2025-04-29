

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

    #region class IndustryHistoryMethods
    /// <summary>
    /// This class contains methods for modifying a 'IndustryHistory' object.
    /// </summary>
    public static class IndustryHistoryMethods
    {

        #region Methods

            #region DeleteIndustryHistory(IndustryHistory)
            /// <summary>
            /// This method deletes a 'IndustryHistory' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'IndustryHistory' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject DeleteIndustryHistory(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteIndustryHistoryStoredProcedure deleteIndustryHistoryProc = null;

                    // verify the first parameters is a(n) 'IndustryHistory'.
                    if (parameters[0].ObjectValue as IndustryHistory != null)
                    {
                        // Create IndustryHistory
                        IndustryHistory industryHistory = (IndustryHistory) parameters[0].ObjectValue;

                        // verify industryHistory exists
                        if(industryHistory != null)
                        {
                            // Now create deleteIndustryHistoryProc from IndustryHistoryWriter
                            // The DataWriter converts the 'IndustryHistory'
                            // to the SqlParameter[] array needed to delete a 'IndustryHistory'.
                            deleteIndustryHistoryProc = IndustryHistoryWriter.CreateDeleteIndustryHistoryStoredProcedure(industryHistory);
                        }
                    }

                    // Verify deleteIndustryHistoryProc exists
                    if(deleteIndustryHistoryProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = IndustryHistoryManager.DeleteIndustryHistory(deleteIndustryHistoryProc, dataConnector);

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
            /// This method fetches all 'IndustryHistory' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'IndustryHistory' to delete.
            /// <returns>A PolymorphicObject object with all  'IndustryHistorys' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<IndustryHistory> industryHistoryListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllIndustryHistorysStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get IndustryHistoryParameter
                    // Declare Parameter
                    IndustryHistory paramIndustryHistory = null;

                    // verify the first parameters is a(n) 'IndustryHistory'.
                    if (parameters[0].ObjectValue as IndustryHistory != null)
                    {
                        // Get IndustryHistoryParameter
                        paramIndustryHistory = (IndustryHistory) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllIndustryHistorysProc from IndustryHistoryWriter
                    fetchAllProc = IndustryHistoryWriter.CreateFetchAllIndustryHistorysStoredProcedure(paramIndustryHistory);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    industryHistoryListCollection = IndustryHistoryManager.FetchAllIndustryHistorys(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(industryHistoryListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = industryHistoryListCollection;
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

            #region FindIndustryHistory(IndustryHistory)
            /// <summary>
            /// This method finds a 'IndustryHistory' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'IndustryHistory' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject FindIndustryHistory(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                IndustryHistory industryHistory = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindIndustryHistoryStoredProcedure findIndustryHistoryProc = null;

                    // verify the first parameters is a 'IndustryHistory'.
                    if (parameters[0].ObjectValue as IndustryHistory != null)
                    {
                        // Get IndustryHistoryParameter
                        IndustryHistory paramIndustryHistory = (IndustryHistory) parameters[0].ObjectValue;

                        // verify paramIndustryHistory exists
                        if(paramIndustryHistory != null)
                        {
                            // Now create findIndustryHistoryProc from IndustryHistoryWriter
                            // The DataWriter converts the 'IndustryHistory'
                            // to the SqlParameter[] array needed to find a 'IndustryHistory'.
                            findIndustryHistoryProc = IndustryHistoryWriter.CreateFindIndustryHistoryStoredProcedure(paramIndustryHistory);
                        }

                        // Verify findIndustryHistoryProc exists
                        if(findIndustryHistoryProc != null)
                        {
                            // Execute Find Stored Procedure
                            industryHistory = IndustryHistoryManager.FindIndustryHistory(findIndustryHistoryProc, dataConnector);

                            // if dataObject exists
                            if(industryHistory != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = industryHistory;
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

            #region InsertIndustryHistory (IndustryHistory)
            /// <summary>
            /// This method inserts a 'IndustryHistory' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'IndustryHistory' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject InsertIndustryHistory(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                IndustryHistory industryHistory = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertIndustryHistoryStoredProcedure insertIndustryHistoryProc = null;

                    // verify the first parameters is a(n) 'IndustryHistory'.
                    if (parameters[0].ObjectValue as IndustryHistory != null)
                    {
                        // Create IndustryHistory Parameter
                        industryHistory = (IndustryHistory) parameters[0].ObjectValue;

                        // verify industryHistory exists
                        if(industryHistory != null)
                        {
                            // Now create insertIndustryHistoryProc from IndustryHistoryWriter
                            // The DataWriter converts the 'IndustryHistory'
                            // to the SqlParameter[] array needed to insert a 'IndustryHistory'.
                            insertIndustryHistoryProc = IndustryHistoryWriter.CreateInsertIndustryHistoryStoredProcedure(industryHistory);
                        }

                        // Verify insertIndustryHistoryProc exists
                        if(insertIndustryHistoryProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = IndustryHistoryManager.InsertIndustryHistory(insertIndustryHistoryProc, dataConnector);
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

            #region UpdateIndustryHistory (IndustryHistory)
            /// <summary>
            /// This method updates a 'IndustryHistory' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'IndustryHistory' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal static PolymorphicObject UpdateIndustryHistory(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                IndustryHistory industryHistory = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateIndustryHistoryStoredProcedure updateIndustryHistoryProc = null;

                    // verify the first parameters is a(n) 'IndustryHistory'.
                    if (parameters[0].ObjectValue as IndustryHistory != null)
                    {
                        // Create IndustryHistory Parameter
                        industryHistory = (IndustryHistory) parameters[0].ObjectValue;

                        // verify industryHistory exists
                        if(industryHistory != null)
                        {
                            // Now create updateIndustryHistoryProc from IndustryHistoryWriter
                            // The DataWriter converts the 'IndustryHistory'
                            // to the SqlParameter[] array needed to update a 'IndustryHistory'.
                            updateIndustryHistoryProc = IndustryHistoryWriter.CreateUpdateIndustryHistoryStoredProcedure(industryHistory);
                        }

                        // Verify updateIndustryHistoryProc exists
                        if(updateIndustryHistoryProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = IndustryHistoryManager.UpdateIndustryHistory(updateIndustryHistoryProc, dataConnector);

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
