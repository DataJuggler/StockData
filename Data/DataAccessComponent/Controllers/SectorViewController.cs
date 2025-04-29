

#region using statements

using DataAccessComponent.Data;
using DataAccessComponent.DataBridge;
using DataAccessComponent.DataOperations;
using DataAccessComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace DataAccessComponent.Controllers
{

    #region class SectorViewController
    /// <summary>
    /// This class controls a(n) 'SectorView' object.
    /// </summary>
    public class SectorViewController
    {

        #region Methods

            #region CreateSectorViewParameter
            /// <summary>
            /// This method creates the parameter for a 'SectorView' data operation.
            /// </summary>
            /// <param name='sectorview'>The 'SectorView' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateSectorViewParameter(SectorView sectorView)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = sectorView;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region FetchAll(SectorView tempSectorView, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'SectorView' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'SectorView_FetchAll'.</summary>
            /// <param name='tempSectorView'>A temporary SectorView for passing values.</param>
            /// <returns>A collection of 'SectorView' objects.</returns>
            public static List<SectorView> FetchAll(SectorView tempSectorView, DataManager dataManager)
            {
                // Initial value
                List<SectorView> sectorViewList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = SectorViewMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateSectorViewParameter(tempSectorView);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<SectorView> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        sectorViewList = (List<SectorView>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return sectorViewList;
            }
            #endregion

        #endregion

    }
    #endregion

}
