

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

    #region class SectorSummaryController
    /// <summary>
    /// This class controls a(n) 'SectorSummary' object.
    /// </summary>
    public class SectorSummaryController
    {

        #region Methods

            #region CreateSectorSummaryParameter
            /// <summary>
            /// This method creates the parameter for a 'SectorSummary' data operation.
            /// </summary>
            /// <param name='sectorsummary'>The 'SectorSummary' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateSectorSummaryParameter(SectorSummary sectorSummary)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = sectorSummary;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region FetchAll(SectorSummary tempSectorSummary, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'SectorSummary' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'SectorSummary_FetchAll'.</summary>
            /// <param name='tempSectorSummary'>A temporary SectorSummary for passing values.</param>
            /// <returns>A collection of 'SectorSummary' objects.</returns>
            public static List<SectorSummary> FetchAll(SectorSummary tempSectorSummary, DataManager dataManager)
            {
                // Initial value
                List<SectorSummary> sectorSummaryList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = SectorSummaryMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateSectorSummaryParameter(tempSectorSummary);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<SectorSummary> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        sectorSummaryList = (List<SectorSummary>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return sectorSummaryList;
            }
            #endregion

        #endregion

    }
    #endregion

}
