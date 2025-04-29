

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class StockReader
    /// <summary>
    /// This class loads a single 'Stock' object or a list of type <Stock>.
    /// </summary>
    public class StockReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'Stock' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'Stock' DataObject.</returns>
            public static Stock Load(DataRow dataRow)
            {
                // Initial Value
                Stock stock = new Stock();

                // Create field Integers
                int averageDailyVolumefield = 0;
                int countryfield = 1;
                int daysBelowMinVolumefield = 2;
                int exchangefield = 3;
                int idfield = 4;
                int industryfield = 5;
                int iPOYearfield = 6;
                int lastClosefield = 7;
                int lastUpdatedfield = 8;
                int namefield = 9;
                int sectorfield = 10;
                int streakfield = 11;
                int symbolfield = 12;
                int trackfield = 13;

                try
                {
                    // Load Each field
                    stock.AverageDailyVolume = DataHelper.ParseInteger(dataRow.ItemArray[averageDailyVolumefield], 0);
                    stock.Country = DataHelper.ParseString(dataRow.ItemArray[countryfield]);
                    stock.DaysBelowMinVolume = DataHelper.ParseInteger(dataRow.ItemArray[daysBelowMinVolumefield], 0);
                    stock.Exchange = DataHelper.ParseString(dataRow.ItemArray[exchangefield]);
                    stock.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    stock.Industry = DataHelper.ParseString(dataRow.ItemArray[industryfield]);
                    stock.IPOYear = DataHelper.ParseInteger(dataRow.ItemArray[iPOYearfield], 0);
                    stock.LastClose = DataHelper.ParseDouble(dataRow.ItemArray[lastClosefield], 0);
                    stock.LastUpdated = DataHelper.ParseDate(dataRow.ItemArray[lastUpdatedfield]);
                    stock.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                    stock.Sector = DataHelper.ParseString(dataRow.ItemArray[sectorfield]);
                    stock.Streak = DataHelper.ParseInteger(dataRow.ItemArray[streakfield], 0);
                    stock.Symbol = DataHelper.ParseString(dataRow.ItemArray[symbolfield]);
                    stock.Track = DataHelper.ParseBoolean(dataRow.ItemArray[trackfield], false);
                }
                catch
                {
                }

                // return value
                return stock;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'Stock' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A Stock Collection.</returns>
            public static List<Stock> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<Stock> stocks = new List<Stock>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'Stock' from rows
                        Stock stock = Load(row);

                        // Add this object to collection
                        stocks.Add(stock);
                    }
                }
                catch
                {
                }

                // return value
                return stocks;
            }
            #endregion

        #endregion

    }
    #endregion

}
