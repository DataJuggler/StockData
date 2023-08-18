

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class DailyPriceDataViewReader
    /// <summary>
    /// This class loads a single 'DailyPriceDataView' object or a list of type <DailyPriceDataView>.
    /// </summary>
    public class DailyPriceDataViewReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'DailyPriceDataView' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'DailyPriceDataView' DataObject.</returns>
            public static DailyPriceDataView Load(DataRow dataRow)
            {
                // Initial Value
                DailyPriceDataView dailyPriceDataView = new DailyPriceDataView();

                // Create field Integers
                int closePricefield = 0;
                int closeScorefield = 1;
                int highPricefield = 2;
                int idfield = 3;
                int lowPricefield = 4;
                int openPricefield = 5;
                int spreadfield = 6;
                int spreadScorefield = 7;
                int stockDatefield = 8;
                int stockIdfield = 9;
                int streakfield = 10;
                int symbolfield = 11;
                int volumefield = 12;
                int volumeScorefield = 13;

                try
                {
                    // Load Each field
                    dailyPriceDataView.ClosePrice = DataHelper.ParseDouble(dataRow.ItemArray[closePricefield], 0);
                    dailyPriceDataView.CloseScore = DataHelper.ParseDouble(dataRow.ItemArray[closeScorefield], 0);
                    dailyPriceDataView.HighPrice = DataHelper.ParseDouble(dataRow.ItemArray[highPricefield], 0);
                    dailyPriceDataView.Id = DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0);
                    dailyPriceDataView.LowPrice = DataHelper.ParseDouble(dataRow.ItemArray[lowPricefield], 0);
                    dailyPriceDataView.OpenPrice = DataHelper.ParseDouble(dataRow.ItemArray[openPricefield], 0);
                    dailyPriceDataView.Spread = DataHelper.ParseDouble(dataRow.ItemArray[spreadfield], 0);
                    dailyPriceDataView.SpreadScore = DataHelper.ParseDouble(dataRow.ItemArray[spreadScorefield], 0);
                    dailyPriceDataView.StockDate = DataHelper.ParseDate(dataRow.ItemArray[stockDatefield]);
                    dailyPriceDataView.StockId = DataHelper.ParseInteger(dataRow.ItemArray[stockIdfield], 0);
                    dailyPriceDataView.Streak = DataHelper.ParseInteger(dataRow.ItemArray[streakfield], 0);
                    dailyPriceDataView.Symbol = DataHelper.ParseString(dataRow.ItemArray[symbolfield]);
                    dailyPriceDataView.Volume = DataHelper.ParseInteger(dataRow.ItemArray[volumefield], 0);
                    dailyPriceDataView.VolumeScore = DataHelper.ParseDouble(dataRow.ItemArray[volumeScorefield], 0);
                }
                catch
                {
                }

                // return value
                return dailyPriceDataView;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'DailyPriceDataView' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A DailyPriceDataView Collection.</returns>
            public static List<DailyPriceDataView> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<DailyPriceDataView> dailyPriceDataViews = new List<DailyPriceDataView>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'DailyPriceDataView' from rows
                        DailyPriceDataView dailyPriceDataView = Load(row);

                        // Add this object to collection
                        dailyPriceDataViews.Add(dailyPriceDataView);
                    }
                }
                catch
                {
                }

                // return value
                return dailyPriceDataViews;
            }
            #endregion

        #endregion

    }
    #endregion

}
