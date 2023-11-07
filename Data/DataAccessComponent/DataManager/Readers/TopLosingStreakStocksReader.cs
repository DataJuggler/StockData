

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class TopLosingStreakStocksReader
    /// <summary>
    /// This class loads a single 'TopLosingStreakStocks' object or a list of type <TopLosingStreakStocks>.
    /// </summary>
    public class TopLosingStreakStocksReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'TopLosingStreakStocks' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'TopLosingStreakStocks' DataObject.</returns>
            public static TopLosingStreakStocks Load(DataRow dataRow)
            {
                // Initial Value
                TopLosingStreakStocks topLosingStreakStocks = new TopLosingStreakStocks();

                // Create field Integers
                int idfield = 0;
                int lastClosefield = 1;
                int namefield = 2;
                int streakfield = 3;
                int symbolfield = 4;

                try
                {
                    // Load Each field
                    topLosingStreakStocks.Id = DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0);
                    topLosingStreakStocks.LastClose = DataHelper.ParseDouble(dataRow.ItemArray[lastClosefield], 0);
                    topLosingStreakStocks.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                    topLosingStreakStocks.Streak = DataHelper.ParseInteger(dataRow.ItemArray[streakfield], 0);
                    topLosingStreakStocks.Symbol = DataHelper.ParseString(dataRow.ItemArray[symbolfield]);
                }
                catch
                {
                }

                // return value
                return topLosingStreakStocks;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'TopLosingStreakStocks' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A TopLosingStreakStocks Collection.</returns>
            public static List<TopLosingStreakStocks> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<TopLosingStreakStocks> topLosingStreakStocks = new List<TopLosingStreakStocks>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'TopLosingStreakStocks' from rows
                        TopLosingStreakStocks topLosingStreakStock = Load(row);

                        // Add this object to collection
                        topLosingStreakStocks.Add(topLosingStreakStock);
                    }
                }
                catch
                {
                }

                // return value
                return topLosingStreakStocks;
            }
            #endregion

        #endregion

    }
    #endregion

}
