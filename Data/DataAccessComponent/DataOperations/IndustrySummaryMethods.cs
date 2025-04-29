

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

    #region class IndustrySummaryMethods
    /// <summary>
    /// This class contains methods for modifying a 'IndustrySummary' object.
    /// </summary>
    public static class IndustrySummaryMethods
    {

        #region Methods

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'IndustrySummary' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'IndustrySummary' to delete.
            /// <returns>A PolymorphicObject object with all  'IndustrySummarys' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<IndustrySummary> industrySummaryListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllIndustrySummarysStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get IndustrySummaryParameter
                    // Declare Parameter
                    IndustrySummary paramIndustrySummary = null;

                    // verify the first parameters is a(n) 'IndustrySummary'.
                    if (parameters[0].ObjectValue as IndustrySummary != null)
                    {
                        // Get IndustrySummaryParameter
                        paramIndustrySummary = (IndustrySummary) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllIndustrySummarysProc from IndustrySummaryWriter
                    fetchAllProc = IndustrySummaryWriter.CreateFetchAllIndustrySummarysStoredProcedure(paramIndustrySummary);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    industrySummaryListCollection = IndustrySummaryManager.FetchAllIndustrySummarys(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(industrySummaryListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = industrySummaryListCollection;
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
