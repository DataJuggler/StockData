

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class SectorViewReader
    /// <summary>
    /// This class loads a single 'SectorView' object or a list of type <SectorView>.
    /// </summary>
    public class SectorViewReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'SectorView' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'SectorView' DataObject.</returns>
            public static SectorView Load(DataRow dataRow)
            {
                // Initial Value
                SectorView sectorView = new SectorView();

                // Create field Integers
                int closePricefield = 0;
                int dailyPriceDataIdfield = 1;
                int mostRecentfield = 2;
                int percentChangefield = 3;
                int priceUnchangedfield = 4;
                int sectorfield = 5;
                int stockDatefield = 6;
                int stockIdfield = 7;
                int stockNamefield = 8;
                int streakfield = 9;
                int symbolfield = 10;
                int trackfield = 11;

                try
                {
                    // Load Each field
                    sectorView.ClosePrice = DataHelper.ParseDouble(dataRow.ItemArray[closePricefield], 0);
                    sectorView.DailyPriceDataId = DataHelper.ParseInteger(dataRow.ItemArray[dailyPriceDataIdfield], 0);
                    sectorView.MostRecent = DataHelper.ParseBoolean(dataRow.ItemArray[mostRecentfield], false);
                    sectorView.PercentChange = DataHelper.ParseDouble(dataRow.ItemArray[percentChangefield], 0);
                    sectorView.PriceUnchanged = DataHelper.ParseBoolean(dataRow.ItemArray[priceUnchangedfield], false);
                    sectorView.Sector = DataHelper.ParseString(dataRow.ItemArray[sectorfield]);
                    sectorView.StockDate = DataHelper.ParseDate(dataRow.ItemArray[stockDatefield]);
                    sectorView.StockId = DataHelper.ParseInteger(dataRow.ItemArray[stockIdfield], 0);
                    sectorView.StockName = DataHelper.ParseString(dataRow.ItemArray[stockNamefield]);
                    sectorView.Streak = DataHelper.ParseInteger(dataRow.ItemArray[streakfield], 0);
                    sectorView.Symbol = DataHelper.ParseString(dataRow.ItemArray[symbolfield]);
                    sectorView.Track = DataHelper.ParseBoolean(dataRow.ItemArray[trackfield], false);
                }
                catch
                {
                }

                // return value
                return sectorView;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'SectorView' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A SectorView Collection.</returns>
            public static List<SectorView> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<SectorView> sectorViews = new List<SectorView>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'SectorView' from rows
                        SectorView sectorView = Load(row);

                        // Add this object to collection
                        sectorViews.Add(sectorView);
                    }
                }
                catch
                {
                }

                // return value
                return sectorViews;
            }
            #endregion

        #endregion

    }
    #endregion

}
