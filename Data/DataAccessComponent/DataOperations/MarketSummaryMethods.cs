

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

    #region class MarketSummaryMethods
    /// <summary>
    /// This class contains methods for modifying a 'MarketSummary' object.
    /// </summary>
    public static class MarketSummaryMethods
    {

        #region Methods

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'MarketSummary' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'MarketSummary' to delete.
            /// <returns>A PolymorphicObject object with all  'MarketSummarys' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<MarketSummary> marketSummaryListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllMarketSummarysStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get MarketSummaryParameter
                    // Declare Parameter
                    MarketSummary paramMarketSummary = null;

                    // verify the first parameters is a(n) 'MarketSummary'.
                    if (parameters[0].ObjectValue as MarketSummary != null)
                    {
                        // Get MarketSummaryParameter
                        paramMarketSummary = (MarketSummary) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllMarketSummarysProc from MarketSummaryWriter
                    fetchAllProc = MarketSummaryWriter.CreateFetchAllMarketSummarysStoredProcedure(paramMarketSummary);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    marketSummaryListCollection = MarketSummaryManager.FetchAllMarketSummarys(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(marketSummaryListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = marketSummaryListCollection;
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
