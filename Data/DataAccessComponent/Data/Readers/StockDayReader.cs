

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class StockDayReader
    /// <summary>
    /// This class loads a single 'StockDay' object or a list of type <StockDay>.
    /// </summary>
    public class StockDayReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'StockDay' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'StockDay' DataObject.</returns>
            public static StockDay Load(DataRow dataRow)
            {
                // Initial Value
                StockDay stockDay = new StockDay();

                // Create field Integers
                int datefield = 0;
                int idfield = 1;
                int industryProcessedfield = 2;
                int sectorProcessedfield = 3;

                try
                {
                    // Load Each field
                    stockDay.Date = DataHelper.ParseDate(dataRow.ItemArray[datefield]);
                    stockDay.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    stockDay.IndustryProcessed = DataHelper.ParseBoolean(dataRow.ItemArray[industryProcessedfield], false);
                    stockDay.SectorProcessed = DataHelper.ParseBoolean(dataRow.ItemArray[sectorProcessedfield], false);
                }
                catch
                {
                }

                // return value
                return stockDay;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'StockDay' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A StockDay Collection.</returns>
            public static List<StockDay> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<StockDay> stockDays = new List<StockDay>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'StockDay' from rows
                        StockDay stockDay = Load(row);

                        // Add this object to collection
                        stockDays.Add(stockDay);
                    }
                }
                catch
                {
                }

                // return value
                return stockDays;
            }
            #endregion

        #endregion

    }
    #endregion

}
