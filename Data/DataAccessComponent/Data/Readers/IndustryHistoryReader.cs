

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class IndustryHistoryReader
    /// <summary>
    /// This class loads a single 'IndustryHistory' object or a list of type <IndustryHistory>.
    /// </summary>
    public class IndustryHistoryReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'IndustryHistory' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'IndustryHistory' DataObject.</returns>
            public static IndustryHistory Load(DataRow dataRow)
            {
                // Initial Value
                IndustryHistory industryHistory = new IndustryHistory();

                // Create field Integers
                int advancersfield = 0;
                int averagePercentChangefield = 1;
                int datefield = 2;
                int declinersfield = 3;
                int idfield = 4;
                int industryIdfield = 5;
                int scorefield = 6;
                int streakfield = 7;

                try
                {
                    // Load Each field
                    industryHistory.Advancers = DataHelper.ParseInteger(dataRow.ItemArray[advancersfield], 0);
                    industryHistory.AveragePercentChange = DataHelper.ParseDouble(dataRow.ItemArray[averagePercentChangefield], 0);
                    industryHistory.Date = DataHelper.ParseDate(dataRow.ItemArray[datefield]);
                    industryHistory.Decliners = DataHelper.ParseInteger(dataRow.ItemArray[declinersfield], 0);
                    industryHistory.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    industryHistory.IndustryId = DataHelper.ParseInteger(dataRow.ItemArray[industryIdfield], 0);
                    industryHistory.Score = DataHelper.ParseDouble(dataRow.ItemArray[scorefield], 0);
                    industryHistory.Streak = DataHelper.ParseInteger(dataRow.ItemArray[streakfield], 0);
                }
                catch
                {
                }

                // return value
                return industryHistory;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'IndustryHistory' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A IndustryHistory Collection.</returns>
            public static List<IndustryHistory> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<IndustryHistory> industryHistorys = new List<IndustryHistory>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'IndustryHistory' from rows
                        IndustryHistory industryHistory = Load(row);

                        // Add this object to collection
                        industryHistorys.Add(industryHistory);
                    }
                }
                catch
                {
                }

                // return value
                return industryHistorys;
            }
            #endregion

        #endregion

    }
    #endregion

}
