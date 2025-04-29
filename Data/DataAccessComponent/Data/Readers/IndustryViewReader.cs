

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class IndustryViewReader
    /// <summary>
    /// This class loads a single 'IndustryView' object or a list of type <IndustryView>.
    /// </summary>
    public class IndustryViewReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'IndustryView' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'IndustryView' DataObject.</returns>
            public static IndustryView Load(DataRow dataRow)
            {
                // Initial Value
                IndustryView industryView = new IndustryView();

                // Create field Integers
                int closePricefield = 0;
                int dailyPriceDataIdfield = 1;
                int industryfield = 2;
                int mostRecentfield = 3;
                int percentChangefield = 4;
                int priceUnchangedfield = 5;
                int stockDatefield = 6;
                int stockIdfield = 7;
                int stockNamefield = 8;
                int streakfield = 9;
                int symbolfield = 10;
                int trackfield = 11;

                try
                {
                    // Load Each field
                    industryView.ClosePrice = DataHelper.ParseDouble(dataRow.ItemArray[closePricefield], 0);
                    industryView.DailyPriceDataId = DataHelper.ParseInteger(dataRow.ItemArray[dailyPriceDataIdfield], 0);
                    industryView.Industry = DataHelper.ParseString(dataRow.ItemArray[industryfield]);
                    industryView.MostRecent = DataHelper.ParseBoolean(dataRow.ItemArray[mostRecentfield], false);
                    industryView.PercentChange = DataHelper.ParseDouble(dataRow.ItemArray[percentChangefield], 0);
                    industryView.PriceUnchanged = DataHelper.ParseBoolean(dataRow.ItemArray[priceUnchangedfield], false);
                    industryView.StockDate = DataHelper.ParseDate(dataRow.ItemArray[stockDatefield]);
                    industryView.StockId = DataHelper.ParseInteger(dataRow.ItemArray[stockIdfield], 0);
                    industryView.StockName = DataHelper.ParseString(dataRow.ItemArray[stockNamefield]);
                    industryView.Streak = DataHelper.ParseInteger(dataRow.ItemArray[streakfield], 0);
                    industryView.Symbol = DataHelper.ParseString(dataRow.ItemArray[symbolfield]);
                    industryView.Track = DataHelper.ParseBoolean(dataRow.ItemArray[trackfield], false);
                }
                catch
                {
                }

                // return value
                return industryView;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'IndustryView' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A IndustryView Collection.</returns>
            public static List<IndustryView> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<IndustryView> industryViews = new List<IndustryView>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'IndustryView' from rows
                        IndustryView industryView = Load(row);

                        // Add this object to collection
                        industryViews.Add(industryView);
                    }
                }
                catch
                {
                }

                // return value
                return industryViews;
            }
            #endregion

        #endregion

    }
    #endregion

}
