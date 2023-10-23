

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

    #region class DoNotTrackMethods
    /// <summary>
    /// This class contains methods for modifying a 'DoNotTrack' object.
    /// </summary>
    public class DoNotTrackMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'DoNotTrackMethods' object.
        /// </summary>
        public DoNotTrackMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteDoNotTrack(DoNotTrack)
            /// <summary>
            /// This method deletes a 'DoNotTrack' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DoNotTrack' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteDoNotTrack(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteDoNotTrackStoredProcedure deleteDoNotTrackProc = null;

                    // verify the first parameters is a(n) 'DoNotTrack'.
                    if (parameters[0].ObjectValue as DoNotTrack != null)
                    {
                        // Create DoNotTrack
                        DoNotTrack doNotTrack = (DoNotTrack) parameters[0].ObjectValue;

                        // verify doNotTrack exists
                        if(doNotTrack != null)
                        {
                            // Now create deleteDoNotTrackProc from DoNotTrackWriter
                            // The DataWriter converts the 'DoNotTrack'
                            // to the SqlParameter[] array needed to delete a 'DoNotTrack'.
                            deleteDoNotTrackProc = DoNotTrackWriter.CreateDeleteDoNotTrackStoredProcedure(doNotTrack);
                        }
                    }

                    // Verify deleteDoNotTrackProc exists
                    if(deleteDoNotTrackProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.DoNotTrackManager.DeleteDoNotTrack(deleteDoNotTrackProc, dataConnector);

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
            /// This method fetches all 'DoNotTrack' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DoNotTrack' to delete.
            /// <returns>A PolymorphicObject object with all  'DoNotTracks' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<DoNotTrack> doNotTrackListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllDoNotTracksStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get DoNotTrackParameter
                    // Declare Parameter
                    DoNotTrack paramDoNotTrack = null;

                    // verify the first parameters is a(n) 'DoNotTrack'.
                    if (parameters[0].ObjectValue as DoNotTrack != null)
                    {
                        // Get DoNotTrackParameter
                        paramDoNotTrack = (DoNotTrack) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllDoNotTracksProc from DoNotTrackWriter
                    fetchAllProc = DoNotTrackWriter.CreateFetchAllDoNotTracksStoredProcedure(paramDoNotTrack);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    doNotTrackListCollection = this.DataManager.DoNotTrackManager.FetchAllDoNotTracks(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(doNotTrackListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = doNotTrackListCollection;
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

            #region FindDoNotTrack(DoNotTrack)
            /// <summary>
            /// This method finds a 'DoNotTrack' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DoNotTrack' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindDoNotTrack(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                DoNotTrack doNotTrack = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindDoNotTrackStoredProcedure findDoNotTrackProc = null;

                    // verify the first parameters is a 'DoNotTrack'.
                    if (parameters[0].ObjectValue as DoNotTrack != null)
                    {
                        // Get DoNotTrackParameter
                        DoNotTrack paramDoNotTrack = (DoNotTrack) parameters[0].ObjectValue;

                        // verify paramDoNotTrack exists
                        if(paramDoNotTrack != null)
                        {
                            // Now create findDoNotTrackProc from DoNotTrackWriter
                            // The DataWriter converts the 'DoNotTrack'
                            // to the SqlParameter[] array needed to find a 'DoNotTrack'.
                            findDoNotTrackProc = DoNotTrackWriter.CreateFindDoNotTrackStoredProcedure(paramDoNotTrack);
                        }

                        // Verify findDoNotTrackProc exists
                        if(findDoNotTrackProc != null)
                        {
                            // Execute Find Stored Procedure
                            doNotTrack = this.DataManager.DoNotTrackManager.FindDoNotTrack(findDoNotTrackProc, dataConnector);

                            // if dataObject exists
                            if(doNotTrack != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = doNotTrack;
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

            #region InsertDoNotTrack (DoNotTrack)
            /// <summary>
            /// This method inserts a 'DoNotTrack' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DoNotTrack' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertDoNotTrack(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                DoNotTrack doNotTrack = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertDoNotTrackStoredProcedure insertDoNotTrackProc = null;

                    // verify the first parameters is a(n) 'DoNotTrack'.
                    if (parameters[0].ObjectValue as DoNotTrack != null)
                    {
                        // Create DoNotTrack Parameter
                        doNotTrack = (DoNotTrack) parameters[0].ObjectValue;

                        // verify doNotTrack exists
                        if(doNotTrack != null)
                        {
                            // Now create insertDoNotTrackProc from DoNotTrackWriter
                            // The DataWriter converts the 'DoNotTrack'
                            // to the SqlParameter[] array needed to insert a 'DoNotTrack'.
                            insertDoNotTrackProc = DoNotTrackWriter.CreateInsertDoNotTrackStoredProcedure(doNotTrack);
                        }

                        // Verify insertDoNotTrackProc exists
                        if(insertDoNotTrackProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.DoNotTrackManager.InsertDoNotTrack(insertDoNotTrackProc, dataConnector);
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

            #region UpdateDoNotTrack (DoNotTrack)
            /// <summary>
            /// This method updates a 'DoNotTrack' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DoNotTrack' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateDoNotTrack(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                DoNotTrack doNotTrack = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateDoNotTrackStoredProcedure updateDoNotTrackProc = null;

                    // verify the first parameters is a(n) 'DoNotTrack'.
                    if (parameters[0].ObjectValue as DoNotTrack != null)
                    {
                        // Create DoNotTrack Parameter
                        doNotTrack = (DoNotTrack) parameters[0].ObjectValue;

                        // verify doNotTrack exists
                        if(doNotTrack != null)
                        {
                            // Now create updateDoNotTrackProc from DoNotTrackWriter
                            // The DataWriter converts the 'DoNotTrack'
                            // to the SqlParameter[] array needed to update a 'DoNotTrack'.
                            updateDoNotTrackProc = DoNotTrackWriter.CreateUpdateDoNotTrackStoredProcedure(doNotTrack);
                        }

                        // Verify updateDoNotTrackProc exists
                        if(updateDoNotTrackProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.DoNotTrackManager.UpdateDoNotTrack(updateDoNotTrackProc, dataConnector);

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
