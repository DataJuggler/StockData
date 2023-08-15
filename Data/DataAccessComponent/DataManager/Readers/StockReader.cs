

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
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
                int exchangefield = 1;
                int idfield = 2;
                int industryfield = 3;
                int iPOYearfield = 4;
                int lastClosefield = 5;
                int namefield = 6;
                int sectorfield = 7;
                int streakfield = 8;
                int symbolfield = 9;
                int trackfield = 10;

                try
                {
                    // Load Each field
                    stock.AverageDailyVolume = DataHelper.ParseInteger(dataRow.ItemArray[averageDailyVolumefield], 0);
                    stock.Exchange = DataHelper.ParseString(dataRow.ItemArray[exchangefield]);
                    stock.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    stock.Industry = DataHelper.ParseString(dataRow.ItemArray[industryfield]);
                    stock.IPOYear = DataHelper.ParseInteger(dataRow.ItemArray[iPOYearfield], 0);
                    stock.LastClose = DataHelper.ParseDouble(dataRow.ItemArray[lastClosefield], 0);
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
