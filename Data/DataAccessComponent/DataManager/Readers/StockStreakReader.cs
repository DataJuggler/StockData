

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class StockStreakReader
    /// <summary>
    /// This class loads a single 'StockStreak' object or a list of type <StockStreak>.
    /// </summary>
    public class StockStreakReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'StockStreak' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'StockStreak' DataObject.</returns>
            public static StockStreak Load(DataRow dataRow)
            {
                // Initial Value
                StockStreak stockStreak = new StockStreak();

                // Create field Integers
                int currentStreakfield = 0;
                int idfield = 1;
                int stockIdfield = 2;
                int streakContinuingfield = 3;
                int streakDaysfield = 4;
                int streakEndDatefield = 5;
                int streakEndPricefield = 6;
                int streakStartDatefield = 7;
                int streakStartPricefield = 8;

                try
                {
                    // Load Each field
                    stockStreak.CurrentStreak = DataHelper.ParseBoolean(dataRow.ItemArray[currentStreakfield], false);
                    stockStreak.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    stockStreak.StockId = DataHelper.ParseInteger(dataRow.ItemArray[stockIdfield], 0);
                    stockStreak.StreakContinuing = DataHelper.ParseBoolean(dataRow.ItemArray[streakContinuingfield], false);
                    stockStreak.StreakDays = DataHelper.ParseInteger(dataRow.ItemArray[streakDaysfield], 0);
                    stockStreak.StreakEndDate = DataHelper.ParseDate(dataRow.ItemArray[streakEndDatefield]);
                    stockStreak.StreakEndPrice = DataHelper.ParseDouble(dataRow.ItemArray[streakEndPricefield], 0);
                    stockStreak.StreakStartDate = DataHelper.ParseDate(dataRow.ItemArray[streakStartDatefield]);
                    stockStreak.StreakStartPrice = DataHelper.ParseDouble(dataRow.ItemArray[streakStartPricefield], 0);
                }
                catch
                {
                }

                // return value
                return stockStreak;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'StockStreak' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A StockStreak Collection.</returns>
            public static List<StockStreak> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<StockStreak> stockStreaks = new List<StockStreak>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'StockStreak' from rows
                        StockStreak stockStreak = Load(row);

                        // Add this object to collection
                        stockStreaks.Add(stockStreak);
                    }
                }
                catch
                {
                }

                // return value
                return stockStreaks;
            }
            #endregion

        #endregion

    }
    #endregion

}
