

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

    #region class SectorViewMethods
    /// <summary>
    /// This class contains methods for modifying a 'SectorView' object.
    /// </summary>
    public static class SectorViewMethods
    {

        #region Methods

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'SectorView' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'SectorView' to delete.
            /// <returns>A PolymorphicObject object with all  'SectorViews' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<SectorView> sectorViewListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllSectorViewsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get SectorViewParameter
                    // Declare Parameter
                    SectorView paramSectorView = null;

                    // verify the first parameters is a(n) 'SectorView'.
                    if (parameters[0].ObjectValue as SectorView != null)
                    {
                        // Get SectorViewParameter
                        paramSectorView = (SectorView) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllSectorViewsProc from SectorViewWriter
                    fetchAllProc = SectorViewWriter.CreateFetchAllSectorViewsStoredProcedure(paramSectorView);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    sectorViewListCollection = SectorViewManager.FetchAllSectorViews(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(sectorViewListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = sectorViewListCollection;
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

        #endregion

    }
    #endregion

}
