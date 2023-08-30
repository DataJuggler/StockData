

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class SectorReader
    /// <summary>
    /// This class loads a single 'Sector' object or a list of type <Sector>.
    /// </summary>
    public class SectorReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'Sector' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'Sector' DataObject.</returns>
            public static Sector Load(DataRow dataRow)
            {
                // Initial Value
                Sector sector = new Sector();

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
                    sector.Advancers = DataHelper.ParseInteger(dataRow.ItemArray[advancersfield], 0);
                    sector.AveragePercentChange = DataHelper.ParseDouble(dataRow.ItemArray[averagePercentChangefield], 0);
                    sector.Decliners = DataHelper.ParseInteger(dataRow.ItemArray[declinersfield], 0);
                    sector.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    sector.LastUpdated = DataHelper.ParseDate(dataRow.ItemArray[lastUpdatedfield]);
                    sector.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                    sector.NumberStocks = DataHelper.ParseInteger(dataRow.ItemArray[numberStocksfield], 0);
                    sector.Score = DataHelper.ParseDouble(dataRow.ItemArray[scorefield], 0);
                    sector.Streak = DataHelper.ParseInteger(dataRow.ItemArray[streakfield], 0);
                }
                catch
                {
                }

                // return value
                return sector;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'Sector' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A Sector Collection.</returns>
            public static List<Sector> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<Sector> sectors = new List<Sector>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'Sector' from rows
                        Sector sector = Load(row);

                        // Add this object to collection
                        sectors.Add(sector);
                    }
                }
                catch
                {
                }

                // return value
                return sectors;
            }
            #endregion

        #endregion

    }
    #endregion

}
