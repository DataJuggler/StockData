

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class StockStreakViewReader
    /// <summary>
    /// This class loads a single 'StockStreakView' object or a list of type <StockStreakView>.
    /// </summary>
    public class StockStreakViewReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'StockStreakView' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'StockStreakView' DataObject.</returns>
            public static StockStreakView Load(DataRow dataRow)
            {
                // Initial Value
                StockStreakView stockStreakView = new StockStreakView();

                // Create field Integers
                int averageDailyVolumefield = 0;
                int exchangefield = 1;
                int industryfield = 2;
                int lastClosefield = 3;
                int namefield = 4;
                int percentChangefield = 5;
                int reverseSplitfield = 6;
                int reverseSplitDivisorfield = 7;
                int sectorfield = 8;
                int stockIdfield = 9;
                int streakfield = 10;
                int streakEndDatefield = 11;
                int streakEndPricefield = 12;
                int streakStartDatefield = 13;
                int streakStartPricefield = 14;
                int symbolfield = 15;

                try
                {
                    // Load Each field
                    stockStreakView.AverageDailyVolume = DataHelper.ParseInteger(dataRow.ItemArray[averageDailyVolumefield], 0);
                    stockStreakView.Exchange = DataHelper.ParseString(dataRow.ItemArray[exchangefield]);
                    stockStreakView.Industry = DataHelper.ParseString(dataRow.ItemArray[industryfield]);
                    stockStreakView.LastClose = DataHelper.ParseDouble(dataRow.ItemArray[lastClosefield], 0);
                    stockStreakView.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                    stockStreakView.PercentChange = DataHelper.ParseDouble(dataRow.ItemArray[percentChangefield], 0);
                    stockStreakView.ReverseSplit = DataHelper.ParseBoolean(dataRow.ItemArray[reverseSplitfield], false);
                    stockStreakView.ReverseSplitDivisor = DataHelper.ParseInteger(dataRow.ItemArray[reverseSplitDivisorfield], 0);
                    stockStreakView.Sector = DataHelper.ParseString(dataRow.ItemArray[sectorfield]);
                    stockStreakView.StockId = DataHelper.ParseInteger(dataRow.ItemArray[stockIdfield], 0);
                    stockStreakView.Streak = DataHelper.ParseInteger(dataRow.ItemArray[streakfield], 0);
                    stockStreakView.StreakEndDate = DataHelper.ParseDate(dataRow.ItemArray[streakEndDatefield]);
                    stockStreakView.StreakEndPrice = DataHelper.ParseDouble(dataRow.ItemArray[streakEndPricefield], 0);
                    stockStreakView.StreakStartDate = DataHelper.ParseDate(dataRow.ItemArray[streakStartDatefield]);
                    stockStreakView.StreakStartPrice = DataHelper.ParseDouble(dataRow.ItemArray[streakStartPricefield], 0);
                    stockStreakView.Symbol = DataHelper.ParseString(dataRow.ItemArray[symbolfield]);
                }
                catch
                {
                }

                // return value
                return stockStreakView;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'StockStreakView' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A StockStreakView Collection.</returns>
            public static List<StockStreakView> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<StockStreakView> stockStreakViews = new List<StockStreakView>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'StockStreakView' from rows
                        StockStreakView stockStreakView = Load(row);

                        // Add this object to collection
                        stockStreakViews.Add(stockStreakView);
                    }
                }
                catch
                {
                }

                // return value
                return stockStreakViews;
            }
            #endregion

        #endregion

    }
    #endregion

}
