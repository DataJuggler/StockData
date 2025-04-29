

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class IndustryReader
    /// <summary>
    /// This class loads a single 'Industry' object or a list of type <Industry>.
    /// </summary>
    public class IndustryReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'Industry' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'Industry' DataObject.</returns>
            public static Industry Load(DataRow dataRow)
            {
                // Initial Value
                Industry industry = new Industry();

                // Create field Integers
                int advancersfield = 0;
                int averagePercentChangefield = 1;
                int declinersfield = 2;
                int idfield = 3;
                int lastUpdatedfield = 4;
                int namefield = 5;
                int numberStocksfield = 6;
                int scorefield = 7;
                int streakfield = 8;

                try
                {
                    // Load Each field
                    industry.Advancers = DataHelper.ParseInteger(dataRow.ItemArray[advancersfield], 0);
                    industry.AveragePercentChange = DataHelper.ParseDouble(dataRow.ItemArray[averagePercentChangefield], 0);
                    industry.Decliners = DataHelper.ParseInteger(dataRow.ItemArray[declinersfield], 0);
                    industry.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    industry.LastUpdated = DataHelper.ParseDate(dataRow.ItemArray[lastUpdatedfield]);
                    industry.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                    industry.NumberStocks = DataHelper.ParseInteger(dataRow.ItemArray[numberStocksfield], 0);
                    industry.Score = DataHelper.ParseDouble(dataRow.ItemArray[scorefield], 0);
                    industry.Streak = DataHelper.ParseInteger(dataRow.ItemArray[streakfield], 0);
                }
                catch
                {
                }

                // return value
                return industry;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'Industry' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A Industry Collection.</returns>
            public static List<Industry> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<Industry> industrys = new List<Industry>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'Industry' from rows
                        Industry industry = Load(row);

                        // Add this object to collection
                        industrys.Add(industry);
                    }
                }
                catch
                {
                }

                // return value
                return industrys;
            }
            #endregion

        #endregion

    }
    #endregion

}
