

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class TopStreakStocksReader
    /// <summary>
    /// This class loads a single 'TopStreakStocks' object or a list of type <TopStreakStocks>.
    /// </summary>
    public class TopStreakStocksReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'TopStreakStocks' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'TopStreakStocks' DataObject.</returns>
            public static TopStreakStocks Load(DataRow dataRow)
            {
                // Initial Value
                TopStreakStocks topStreakStocks = new TopStreakStocks();

                // Create field Integers
                int idfield = 0;
                int lastClosefield = 1;
                int namefield = 2;
                int streakfield = 3;
                int symbolfield = 4;

                try
                {
                    // Load Each field
                    topStreakStocks.Id = DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0);
                    topStreakStocks.LastClose = DataHelper.ParseDouble(dataRow.ItemArray[lastClosefield], 0);
                    topStreakStocks.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                    topStreakStocks.Streak = DataHelper.ParseInteger(dataRow.ItemArray[streakfield], 0);
                    topStreakStocks.Symbol = DataHelper.ParseString(dataRow.ItemArray[symbolfield]);
                }
                catch
                {
                }

                // return value
                return topStreakStocks;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'TopStreakStocks' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A TopStreakStocks Collection.</returns>
            public static List<TopStreakStocks> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<TopStreakStocks> topStreakStocks = new List<TopStreakStocks>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'TopStreakStocks' from rows
                        TopStreakStocks topStreakStock = Load(row);

                        // Add this object to collection
                        topStreakStocks.Add(topStreakStock);
                    }
                }
                catch
                {
                }

                // return value
                return topStreakStocks;
            }
            #endregion

        #endregion

    }
    #endregion

}
