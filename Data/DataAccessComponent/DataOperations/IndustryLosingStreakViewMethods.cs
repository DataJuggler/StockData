

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

    #region class IndustryLosingStreakViewMethods
    /// <summary>
    /// This class contains methods for modifying a 'IndustryLosingStreakView' object.
    /// </summary>
    public static class IndustryLosingStreakViewMethods
    {

        #region Methods

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'IndustryLosingStreakView' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'IndustryLosingStreakView' to delete.
            /// <returns>A PolymorphicObject object with all  'IndustryLosingStreakViews' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<IndustryLosingStreakView> industryLosingStreakViewListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllIndustryLosingStreakViewsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get IndustryLosingStreakViewParameter
                    // Declare Parameter
                    IndustryLosingStreakView paramIndustryLosingStreakView = null;

                    // verify the first parameters is a(n) 'IndustryLosingStreakView'.
                    if (parameters[0].ObjectValue as IndustryLosingStreakView != null)
                    {
                        // Get IndustryLosingStreakViewParameter
                        paramIndustryLosingStreakView = (IndustryLosingStreakView) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllIndustryLosingStreakViewsProc from IndustryLosingStreakViewWriter
                    fetchAllProc = IndustryLosingStreakViewWriter.CreateFetchAllIndustryLosingStreakViewsStoredProcedure(paramIndustryLosingStreakView);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    industryLosingStreakViewListCollection = IndustryLosingStreakViewManager.FetchAllIndustryLosingStreakViews(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(industryLosingStreakViewListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = industryLosingStreakViewListCollection;
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
