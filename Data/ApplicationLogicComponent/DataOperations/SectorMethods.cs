

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

    #region class SectorMethods
    /// <summary>
    /// This class contains methods for modifying a 'Sector' object.
    /// </summary>
    public class SectorMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'SectorMethods' object.
        /// </summary>
        public SectorMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteSector(Sector)
            /// <summary>
            /// This method deletes a 'Sector' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Sector' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteSector(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteSectorStoredProcedure deleteSectorProc = null;

                    // verify the first parameters is a(n) 'Sector'.
                    if (parameters[0].ObjectValue as Sector != null)
                    {
                        // Create Sector
                        Sector sector = (Sector) parameters[0].ObjectValue;

                        // verify sector exists
                        if(sector != null)
                        {
                            // Now create deleteSectorProc from SectorWriter
                            // The DataWriter converts the 'Sector'
                            // to the SqlParameter[] array needed to delete a 'Sector'.
                            deleteSectorProc = SectorWriter.CreateDeleteSectorStoredProcedure(sector);
                        }
                    }

                    // Verify deleteSectorProc exists
                    if(deleteSectorProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.SectorManager.DeleteSector(deleteSectorProc, dataConnector);

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
            /// This method fetches all 'Sector' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Sector' to delete.
            /// <returns>A PolymorphicObject object with all  'Sectors' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<Sector> sectorListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllSectorsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get SectorParameter
                    // Declare Parameter
                    Sector paramSector = null;

                    // verify the first parameters is a(n) 'Sector'.
                    if (parameters[0].ObjectValue as Sector != null)
                    {
                        // Get SectorParameter
                        paramSector = (Sector) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllSectorsProc from SectorWriter
                    fetchAllProc = SectorWriter.CreateFetchAllSectorsStoredProcedure(paramSector);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    sectorListCollection = this.DataManager.SectorManager.FetchAllSectors(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(sectorListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = sectorListCollection;
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

            #region FindSector(Sector)
            /// <summary>
            /// This method finds a 'Sector' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Sector' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindSector(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Sector sector = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindSectorStoredProcedure findSectorProc = null;

                    // verify the first parameters is a 'Sector'.
                    if (parameters[0].ObjectValue as Sector != null)
                    {
                        // Get SectorParameter
                        Sector paramSector = (Sector) parameters[0].ObjectValue;

                        // verify paramSector exists
                        if(paramSector != null)
                        {
                            // Now create findSectorProc from SectorWriter
                            // The DataWriter converts the 'Sector'
                            // to the SqlParameter[] array needed to find a 'Sector'.
                            findSectorProc = SectorWriter.CreateFindSectorStoredProcedure(paramSector);
                        }

                        // Verify findSectorProc exists
                        if(findSectorProc != null)
                        {
                            // Execute Find Stored Procedure
                            sector = this.DataManager.SectorManager.FindSector(findSectorProc, dataConnector);

                            // if dataObject exists
                            if(sector != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = sector;
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

            #region InsertSector (Sector)
            /// <summary>
            /// This method inserts a 'Sector' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Sector' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertSector(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Sector sector = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertSectorStoredProcedure insertSectorProc = null;

                    // verify the first parameters is a(n) 'Sector'.
                    if (parameters[0].ObjectValue as Sector != null)
                    {
                        // Create Sector Parameter
                        sector = (Sector) parameters[0].ObjectValue;

                        // verify sector exists
                        if(sector != null)
                        {
                            // Now create insertSectorProc from SectorWriter
                            // The DataWriter converts the 'Sector'
                            // to the SqlParameter[] array needed to insert a 'Sector'.
                            insertSectorProc = SectorWriter.CreateInsertSectorStoredProcedure(sector);
                        }

                        // Verify insertSectorProc exists
                        if(insertSectorProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.SectorManager.InsertSector(insertSectorProc, dataConnector);
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

            #region UpdateSector (Sector)
            /// <summary>
            /// This method updates a 'Sector' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Sector' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateSector(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Sector sector = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateSectorStoredProcedure updateSectorProc = null;

                    // verify the first parameters is a(n) 'Sector'.
                    if (parameters[0].ObjectValue as Sector != null)
                    {
                        // Create Sector Parameter
                        sector = (Sector) parameters[0].ObjectValue;

                        // verify sector exists
                        if(sector != null)
                        {
                            // Now create updateSectorProc from SectorWriter
                            // The DataWriter converts the 'Sector'
                            // to the SqlParameter[] array needed to update a 'Sector'.
                            updateSectorProc = SectorWriter.CreateUpdateSectorStoredProcedure(sector);
                        }

                        // Verify updateSectorProc exists
                        if(updateSectorProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.SectorManager.UpdateSector(updateSectorProc, dataConnector);

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
