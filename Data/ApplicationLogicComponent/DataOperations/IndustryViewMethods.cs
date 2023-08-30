

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

    #region class IndustryViewMethods
    /// <summary>
    /// This class contains methods for modifying a 'IndustryView' object.
    /// </summary>
    public class IndustryViewMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'IndustryViewMethods' object.
        /// </summary>
        public IndustryViewMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'IndustryView' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'IndustryView' to delete.
            /// <returns>A PolymorphicObject object with all  'IndustryViews' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<IndustryView> industryViewListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllIndustryViewsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get IndustryViewParameter
                    // Declare Parameter
                    IndustryView paramIndustryView = null;

                    // verify the first parameters is a(n) 'IndustryView'.
                    if (parameters[0].ObjectValue as IndustryView != null)
                    {
                        // Get IndustryViewParameter
                        paramIndustryView = (IndustryView) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllIndustryViewsProc from IndustryViewWriter
                    fetchAllProc = IndustryViewWriter.CreateFetchAllIndustryViewsStoredProcedure(paramIndustryView);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    industryViewListCollection = this.DataManager.IndustryViewManager.FetchAllIndustryViews(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(industryViewListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = industryViewListCollection;
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
