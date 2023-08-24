

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class SectorHistoryReader
    /// <summary>
    /// This class loads a single 'SectorHistory' object or a list of type <SectorHistory>.
    /// </summary>
    public class SectorHistoryReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'SectorHistory' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'SectorHistory' DataObject.</returns>
            public static SectorHistory Load(DataRow dataRow)
            {
                // Initial Value
                SectorHistory sectorHistory = new SectorHistory();

                // Create field Integers
                int advancersfield = 0;
                int averagePercentChangefield = 1;
                int datefield = 2;
                int declinersfield = 3;
                int idfield = 4;
                int scorefield = 5;
                int sectorIdfield = 6;
                int streakfield = 7;

                try
                {
                    // Load Each field
                    sectorHistory.Advancers = DataHelper.ParseInteger(dataRow.ItemArray[advancersfield], 0);
                    sectorHistory.AveragePercentChange = DataHelper.ParseDouble(dataRow.ItemArray[averagePercentChangefield], 0);
                    sectorHistory.Date = DataHelper.ParseDate(dataRow.ItemArray[datefield]);
                    sectorHistory.Decliners = DataHelper.ParseInteger(dataRow.ItemArray[declinersfield], 0);
                    sectorHistory.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    sectorHistory.Score = DataHelper.ParseDouble(dataRow.ItemArray[scorefield], 0);
                    sectorHistory.SectorId = DataHelper.ParseInteger(dataRow.ItemArray[sectorIdfield], 0);
                    sectorHistory.Streak = DataHelper.ParseInteger(dataRow.ItemArray[streakfield], 0);
                }
                catch
                {
                }

                // return value
                return sectorHistory;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'SectorHistory' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A SectorHistory Collection.</returns>
            public static List<SectorHistory> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<SectorHistory> sectorHistorys = new List<SectorHistory>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'SectorHistory' from rows
                        SectorHistory sectorHistory = Load(row);

                        // Add this object to collection
                        sectorHistorys.Add(sectorHistory);
                    }
                }
                catch
                {
                }

                // return value
                return sectorHistorys;
            }
            #endregion

        #endregion

    }
    #endregion

}
