

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

    #region class MarketSummaryMethods
    /// <summary>
    /// This class contains methods for modifying a 'MarketSummary' object.
    /// </summary>
    public class MarketSummaryMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'MarketSummaryMethods' object.
        /// </summary>
        public MarketSummaryMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'MarketSummary' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'MarketSummary' to delete.
            /// <returns>A PolymorphicObject object with all  'MarketSummarys' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
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
                    marketSummaryListCollection = this.DataManager.MarketSummaryManager.FetchAllMarketSummarys(fetchAllProc, dataConnector);

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
