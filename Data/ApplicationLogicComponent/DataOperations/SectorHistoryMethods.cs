

#region using statements

using ApplicationLogicComponent.DataBridge;
using DataAccessComponent.DataManager;
using DataAccessComponent.DataManager.Writers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.DataOperations
{

    #region class SectorHistoryMethods
    /// <summary>
    /// This class contains methods for modifying a 'SectorHistory' object.
    /// </summary>
    public class SectorHistoryMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'SectorHistoryMethods' object.
        /// </summary>
        public SectorHistoryMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteSectorHistory(SectorHistory)
            /// <summary>
            /// This method deletes a 'SectorHistory' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'SectorHistory' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteSectorHistory(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteSectorHistoryStoredProcedure deleteSectorHistoryProc = null;

                    // verify the first parameters is a(n) 'SectorHistory'.
                    if (parameters[0].ObjectValue as SectorHistory != null)
                    {
                        // Create SectorHistory
                        SectorHistory sectorHistory = (SectorHistory) parameters[0].ObjectValue;

                        // verify sectorHistory exists
                        if(sectorHistory != null)
                        {
                            // Now create deleteSectorHistoryProc from SectorHistoryWriter
                            // The DataWriter converts the 'SectorHistory'
                            // to the SqlParameter[] array needed to delete a 'SectorHistory'.
                            deleteSectorHistoryProc = SectorHistoryWriter.CreateDeleteSectorHistoryStoredProcedure(sectorHistory);
                        }
                    }

                    // Verify deleteSectorHistoryProc exists
                    if(deleteSectorHistoryProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.SectorHistoryManager.DeleteSectorHistory(deleteSectorHistoryProc, dataConnector);

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
            /// This method fetches all 'SectorHistory' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'SectorHistory' to delete.
            /// <returns>A PolymorphicObject object with all  'SectorHistorys' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<SectorHistory> sectorHistoryListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllSectorHistorysStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get SectorHistoryParameter
                    // Declare Parameter
                    SectorHistory paramSectorHistory = null;

                    // verify the first parameters is a(n) 'SectorHistory'.
                    if (parameters[0].ObjectValue as SectorHistory != null)
                    {
                        // Get SectorHistoryParameter
                        paramSectorHistory = (SectorHistory) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllSectorHistorysProc from SectorHistoryWriter
                    fetchAllProc = SectorHistoryWriter.CreateFetchAllSectorHistorysStoredProcedure(paramSectorHistory);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    sectorHistoryListCollection = this.DataManager.SectorHistoryManager.FetchAllSectorHistorys(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(sectorHistoryListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = sectorHistoryListCollection;
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

            #region FindSectorHistory(SectorHistory)
            /// <summary>
            /// This method finds a 'SectorHistory' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'SectorHistory' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindSectorHistory(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                SectorHistory sectorHistory = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindSectorHistoryStoredProcedure findSectorHistoryProc = null;

                    // verify the first parameters is a 'SectorHistory'.
                    if (parameters[0].ObjectValue as SectorHistory != null)
                    {
                        // Get SectorHistoryParameter
                        SectorHistory paramSectorHistory = (SectorHistory) parameters[0].ObjectValue;

                        // verify paramSectorHistory exists
                        if(paramSectorHistory != null)
                        {
                            // Now create findSectorHistoryProc from SectorHistoryWriter
                            // The DataWriter converts the 'SectorHistory'
                            // to the SqlParameter[] array needed to find a 'SectorHistory'.
                            findSectorHistoryProc = SectorHistoryWriter.CreateFindSectorHistoryStoredProcedure(paramSectorHistory);
                        }

                        // Verify findSectorHistoryProc exists
                        if(findSectorHistoryProc != null)
                        {
                            // Execute Find Stored Procedure
                            sectorHistory = this.DataManager.SectorHistoryManager.FindSectorHistory(findSectorHistoryProc, dataConnector);

                            // if dataObject exists
                            if(sectorHistory != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = sectorHistory;
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

            #region InsertSectorHistory (SectorHistory)
            /// <summary>
            /// This method inserts a 'SectorHistory' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'SectorHistory' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertSectorHistory(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                SectorHistory sectorHistory = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertSectorHistoryStoredProcedure insertSectorHistoryProc = null;

                    // verify the first parameters is a(n) 'SectorHistory'.
                    if (parameters[0].ObjectValue as SectorHistory != null)
                    {
                        // Create SectorHistory Parameter
                        sectorHistory = (SectorHistory) parameters[0].ObjectValue;

                        // verify sectorHistory exists
                        if(sectorHistory != null)
                        {
                            // Now create insertSectorHistoryProc from SectorHistoryWriter
                            // The DataWriter converts the 'SectorHistory'
                            // to the SqlParameter[] array needed to insert a 'SectorHistory'.
                            insertSectorHistoryProc = SectorHistoryWriter.CreateInsertSectorHistoryStoredProcedure(sectorHistory);
                        }

                        // Verify insertSectorHistoryProc exists
                        if(insertSectorHistoryProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.SectorHistoryManager.InsertSectorHistory(insertSectorHistoryProc, dataConnector);
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

            #region UpdateSectorHistory (SectorHistory)
            /// <summary>
            /// This method updates a 'SectorHistory' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'SectorHistory' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateSectorHistory(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                SectorHistory sectorHistory = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateSectorHistoryStoredProcedure updateSectorHistoryProc = null;

                    // verify the first parameters is a(n) 'SectorHistory'.
                    if (parameters[0].ObjectValue as SectorHistory != null)
                    {
                        // Create SectorHistory Parameter
                        sectorHistory = (SectorHistory) parameters[0].ObjectValue;

                        // verify sectorHistory exists
                        if(sectorHistory != null)
                        {
                            // Now create updateSectorHistoryProc from SectorHistoryWriter
                            // The DataWriter converts the 'SectorHistory'
                            // to the SqlParameter[] array needed to update a 'SectorHistory'.
                            updateSectorHistoryProc = SectorHistoryWriter.CreateUpdateSectorHistoryStoredProcedure(sectorHistory);
                        }

                        // Verify updateSectorHistoryProc exists
                        if(updateSectorHistoryProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.SectorHistoryManager.UpdateSectorHistory(updateSectorHistoryProc, dataConnector);

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

        #region Properties

            #region DataManager 
            public DataManager DataManager 
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
