

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class IndustrySummaryReader
    /// <summary>
    /// This class loads a single 'IndustrySummary' object or a list of type <IndustrySummary>.
    /// </summary>
    public class IndustrySummaryReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'IndustrySummary' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'IndustrySummary' DataObject.</returns>
            public static IndustrySummary Load(DataRow dataRow)
            {
                // Initial Value
                IndustrySummary industrySummary = new IndustrySummary();

                // Create field Integers
                int industryAdvancersfield = 0;
                int industryDeclinersfield = 1;

                try
                {
                    // Load Each field
                    industrySummary.IndustryAdvancers = DataHelper.ParseInteger(dataRow.ItemArray[industryAdvancersfield], 0);
                    industrySummary.IndustryDecliners = DataHelper.ParseInteger(dataRow.ItemArray[industryDeclinersfield], 0);
                }
                catch
                {
                }

                // return value
                return industrySummary;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'IndustrySummary' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A IndustrySummary Collection.</returns>
            public static List<IndustrySummary> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<IndustrySummary> industrySummarys = new List<IndustrySummary>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'IndustrySummary' from rows
                        IndustrySummary industrySummary = Load(row);

                        // Add this object to collection
                        industrySummarys.Add(industrySummary);
                    }
                }
                catch
                {
                }

                // return value
                return industrySummarys;
            }
            #endregion

        #endregion

    }
    #endregion

}
