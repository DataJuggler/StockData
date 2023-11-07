

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

    #region class TopLosingStreakStocksMethods
    /// <summary>
    /// This class contains methods for modifying a 'TopLosingStreakStocks' object.
    /// </summary>
    public class TopLosingStreakStocksMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'TopLosingStreakStocksMethods' object.
        /// </summary>
        public TopLosingStreakStocksMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'TopLosingStreakStocks' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'TopLosingStreakStocks' to delete.
            /// <returns>A PolymorphicObject object with all  'TopLosingStreakStocks' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<TopLosingStreakStocks> topLosingStreakStocksListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllTopLosingStreakStocksStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get TopLosingStreakStocksParameter
                    // Declare Parameter
                    TopLosingStreakStocks paramTopLosingStreakStocks = null;

                    // verify the first parameters is a(n) 'TopLosingStreakStocks'.
                    if (parameters[0].ObjectValue as TopLosingStreakStocks != null)
                    {
                        // Get TopLosingStreakStocksParameter
                        paramTopLosingStreakStocks = (TopLosingStreakStocks) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllTopLosingStreakStocksProc from TopLosingStreakStocksWriter
                    fetchAllProc = TopLosingStreakStocksWriter.CreateFetchAllTopLosingStreakStocksStoredProcedure(paramTopLosingStreakStocks);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    topLosingStreakStocksListCollection = this.DataManager.TopLosingStreakStocksManager.FetchAllTopLosingStreakStocks(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(topLosingStreakStocksListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = topLosingStreakStocksListCollection;
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
