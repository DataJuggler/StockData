

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class SectorSummaryReader
    /// <summary>
    /// This class loads a single 'SectorSummary' object or a list of type <SectorSummary>.
    /// </summary>
    public class SectorSummaryReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'SectorSummary' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'SectorSummary' DataObject.</returns>
            public static SectorSummary Load(DataRow dataRow)
            {
                // Initial Value
                SectorSummary sectorSummary = new SectorSummary();

                // Create field Integers
                int sectorAdvancersfield = 0;
                int sectorDeclinersfield = 1;

                try
                {
                    // Load Each field
                    sectorSummary.SectorAdvancers = DataHelper.ParseInteger(dataRow.ItemArray[sectorAdvancersfield], 0);
                    sectorSummary.SectorDecliners = DataHelper.ParseInteger(dataRow.ItemArray[sectorDeclinersfield], 0);
                }
                catch
                {
                }

                // return value
                return sectorSummary;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'SectorSummary' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A SectorSummary Collection.</returns>
            public static List<SectorSummary> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<SectorSummary> sectorSummarys = new List<SectorSummary>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'SectorSummary' from rows
                        SectorSummary sectorSummary = Load(row);

                        // Add this object to collection
                        sectorSummarys.Add(sectorSummary);
                    }
                }
                catch
                {
                }

                // return value
                return sectorSummarys;
            }
            #endregion

        #endregion

    }
    #endregion

}
