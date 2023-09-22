

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

    #region class RecommendationViewMethods
    /// <summary>
    /// This class contains methods for modifying a 'RecommendationView' object.
    /// </summary>
    public class RecommendationViewMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'RecommendationViewMethods' object.
        /// </summary>
        public RecommendationViewMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'RecommendationView' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'RecommendationView' to delete.
            /// <returns>A PolymorphicObject object with all  'RecommendationViews' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<RecommendationView> recommendationViewListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllRecommendationViewsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get RecommendationViewParameter
                    // Declare Parameter
                    RecommendationView paramRecommendationView = null;

                    // verify the first parameters is a(n) 'RecommendationView'.
                    if (parameters[0].ObjectValue as RecommendationView != null)
                    {
                        // Get RecommendationViewParameter
                        paramRecommendationView = (RecommendationView) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllRecommendationViewsProc from RecommendationViewWriter
                    fetchAllProc = RecommendationViewWriter.CreateFetchAllRecommendationViewsStoredProcedure(paramRecommendationView);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    recommendationViewListCollection = this.DataManager.RecommendationViewManager.FetchAllRecommendationViews(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(recommendationViewListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = recommendationViewListCollection;
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
