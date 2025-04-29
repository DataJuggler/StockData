

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

    #region class SectorSummaryMethods
    /// <summary>
    /// This class contains methods for modifying a 'SectorSummary' object.
    /// </summary>
    public static class SectorSummaryMethods
    {

        #region Methods

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'SectorSummary' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'SectorSummary' to delete.
            /// <returns>A PolymorphicObject object with all  'SectorSummarys' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<SectorSummary> sectorSummaryListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllSectorSummarysStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get SectorSummaryParameter
                    // Declare Parameter
                    SectorSummary paramSectorSummary = null;

                    // verify the first parameters is a(n) 'SectorSummary'.
                    if (parameters[0].ObjectValue as SectorSummary != null)
                    {
                        // Get SectorSummaryParameter
                        paramSectorSummary = (SectorSummary) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllSectorSummarysProc from SectorSummaryWriter
                    fetchAllProc = SectorSummaryWriter.CreateFetchAllSectorSummarysStoredProcedure(paramSectorSummary);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    sectorSummaryListCollection = SectorSummaryManager.FetchAllSectorSummarys(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(sectorSummaryListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = sectorSummaryListCollection;
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
