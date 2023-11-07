

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

    #region class TopStreakStocksMethods
    /// <summary>
    /// This class contains methods for modifying a 'TopStreakStocks' object.
    /// </summary>
    public class TopStreakStocksMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'TopStreakStocksMethods' object.
        /// </summary>
        public TopStreakStocksMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'TopStreakStocks' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'TopStreakStocks' to delete.
            /// <returns>A PolymorphicObject object with all  'TopStreakStocks' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<TopStreakStocks> topStreakStocksListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllTopStreakStocksStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get TopStreakStocksParameter
                    // Declare Parameter
                    TopStreakStocks paramTopStreakStocks = null;

                    // verify the first parameters is a(n) 'TopStreakStocks'.
                    if (parameters[0].ObjectValue as TopStreakStocks != null)
                    {
                        // Get TopStreakStocksParameter
                        paramTopStreakStocks = (TopStreakStocks) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllTopStreakStocksProc from TopStreakStocksWriter
                    fetchAllProc = TopStreakStocksWriter.CreateFetchAllTopStreakStocksStoredProcedure(paramTopStreakStocks);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    topStreakStocksListCollection = this.DataManager.TopStreakStocksManager.FetchAllTopStreakStocks(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(topStreakStocksListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = topStreakStocksListCollection;
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
