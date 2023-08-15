

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class DailyPriceDataReader
    /// <summary>
    /// This class loads a single 'DailyPriceData' object or a list of type <DailyPriceData>.
    /// </summary>
    public class DailyPriceDataReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'DailyPriceData' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'DailyPriceData' DataObject.</returns>
            public static DailyPriceData Load(DataRow dataRow)
            {
                // Initial Value
                DailyPriceData dailyPriceData = new DailyPriceData();

                // Create field Integers
                int closePricefield = 0;
                int highPricefield = 1;
                int idfield = 2;
                int lowPricefield = 3;
                int openPricefield = 4;
                int spreadfield = 5;
                int stockDatefield = 6;
                int streakfield = 7;
                int symbolfield = 8;
                int volumefield = 9;

                try
                {
                    // Load Each field
                    dailyPriceData.ClosePrice = DataHelper.ParseDouble(dataRow.ItemArray[closePricefield], 0);
                    dailyPriceData.HighPrice = DataHelper.ParseDouble(dataRow.ItemArray[highPricefield], 0);
                    dailyPriceData.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    dailyPriceData.LowPrice = DataHelper.ParseDouble(dataRow.ItemArray[lowPricefield], 0);
                    dailyPriceData.OpenPrice = DataHelper.ParseDouble(dataRow.ItemArray[openPricefield], 0);
                    dailyPriceData.Spread = DataHelper.ParseDouble(dataRow.ItemArray[spreadfield], 0);
                    dailyPriceData.StockDate = DataHelper.ParseDate(dataRow.ItemArray[stockDatefield]);
                    dailyPriceData.Streak = DataHelper.ParseInteger(dataRow.ItemArray[streakfield], 0);
                    dailyPriceData.Symbol = DataHelper.ParseString(dataRow.ItemArray[symbolfield]);
                    dailyPriceData.Volume = DataHelper.ParseInteger(dataRow.ItemArray[volumefield], 0);
                }
                catch
                {
                }

                // return value
                return dailyPriceData;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'DailyPriceData' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A DailyPriceData Collection.</returns>
            public static List<DailyPriceData> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<DailyPriceData> dailyPriceDatas = new List<DailyPriceData>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'DailyPriceData' from rows
                        DailyPriceData dailyPriceData = Load(row);

                        // Add this object to collection
                        dailyPriceDatas.Add(dailyPriceData);
                    }
                }
                catch
                {
                }

                // return value
                return dailyPriceDatas;
            }
            #endregion

        #endregion

    }
    #endregion

}
