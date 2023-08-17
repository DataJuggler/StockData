

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

    #region class DailyPriceDataViewMethods
    /// <summary>
    /// This class contains methods for modifying a 'DailyPriceDataView' object.
    /// </summary>
    public class DailyPriceDataViewMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'DailyPriceDataViewMethods' object.
        /// </summary>
        public DailyPriceDataViewMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'DailyPriceDataView' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DailyPriceDataView' to delete.
            /// <returns>A PolymorphicObject object with all  'DailyPriceDataViews' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<DailyPriceDataView> dailyPriceDataViewListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllDailyPriceDataViewsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get DailyPriceDataViewParameter
                    // Declare Parameter
                    DailyPriceDataView paramDailyPriceDataView = null;

                    // verify the first parameters is a(n) 'DailyPriceDataView'.
                    if (parameters[0].ObjectValue as DailyPriceDataView != null)
                    {
                        // Get DailyPriceDataViewParameter
                        paramDailyPriceDataView = (DailyPriceDataView) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllDailyPriceDataViewsProc from DailyPriceDataViewWriter
                    fetchAllProc = DailyPriceDataViewWriter.CreateFetchAllDailyPriceDataViewsStoredProcedure(paramDailyPriceDataView);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    dailyPriceDataViewListCollection = this.DataManager.DailyPriceDataViewManager.FetchAllDailyPriceDataViews(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(dailyPriceDataViewListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = dailyPriceDataViewListCollection;
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
