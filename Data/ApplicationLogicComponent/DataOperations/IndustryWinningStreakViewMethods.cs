

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

    #region class IndustryWinningStreakViewMethods
    /// <summary>
    /// This class contains methods for modifying a 'IndustryWinningStreakView' object.
    /// </summary>
    public class IndustryWinningStreakViewMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'IndustryWinningStreakViewMethods' object.
        /// </summary>
        public IndustryWinningStreakViewMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'IndustryWinningStreakView' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'IndustryWinningStreakView' to delete.
            /// <returns>A PolymorphicObject object with all  'IndustryWinningStreakViews' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<IndustryWinningStreakView> industryWinningStreakViewListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllIndustryWinningStreakViewsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get IndustryWinningStreakViewParameter
                    // Declare Parameter
                    IndustryWinningStreakView paramIndustryWinningStreakView = null;

                    // verify the first parameters is a(n) 'IndustryWinningStreakView'.
                    if (parameters[0].ObjectValue as IndustryWinningStreakView != null)
                    {
                        // Get IndustryWinningStreakViewParameter
                        paramIndustryWinningStreakView = (IndustryWinningStreakView) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllIndustryWinningStreakViewsProc from IndustryWinningStreakViewWriter
                    fetchAllProc = IndustryWinningStreakViewWriter.CreateFetchAllIndustryWinningStreakViewsStoredProcedure(paramIndustryWinningStreakView);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    industryWinningStreakViewListCollection = this.DataManager.IndustryWinningStreakViewManager.FetchAllIndustryWinningStreakViews(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(industryWinningStreakViewListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = industryWinningStreakViewListCollection;
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
