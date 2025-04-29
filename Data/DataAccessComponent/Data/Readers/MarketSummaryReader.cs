

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class MarketSummaryReader
    /// <summary>
    /// This class loads a single 'MarketSummary' object or a list of type <MarketSummary>.
    /// </summary>
    public class MarketSummaryReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'MarketSummary' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'MarketSummary' DataObject.</returns>
            public static MarketSummary Load(DataRow dataRow)
            {
                // Initial Value
                MarketSummary marketSummary = new MarketSummary();

                // Create field Integers
                int advancersfield = 0;
                int declinersfield = 1;
                int numberStocksfield = 2;
                int stockDatefield = 3;

                try
                {
                    // Load Each field
                    marketSummary.Advancers = DataHelper.ParseInteger(dataRow.ItemArray[advancersfield], 0);
                    marketSummary.Decliners = DataHelper.ParseInteger(dataRow.ItemArray[declinersfield], 0);
                    marketSummary.NumberStocks = DataHelper.ParseInteger(dataRow.ItemArray[numberStocksfield], 0);
                    marketSummary.StockDate = DataHelper.ParseDate(dataRow.ItemArray[stockDatefield]);
                }
                catch
                {
                }

                // return value
                return marketSummary;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'MarketSummary' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A MarketSummary Collection.</returns>
            public static List<MarketSummary> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<MarketSummary> marketSummarys = new List<MarketSummary>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'MarketSummary' from rows
                        MarketSummary marketSummary = Load(row);

                        // Add this object to collection
                        marketSummarys.Add(marketSummary);
                    }
                }
                catch
                {
                }

                // return value
                return marketSummarys;
            }
            #endregion

        #endregion

    }
    #endregion

}
