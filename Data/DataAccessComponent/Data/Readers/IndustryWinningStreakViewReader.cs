

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class IndustryWinningStreakViewReader
    /// <summary>
    /// This class loads a single 'IndustryWinningStreakView' object or a list of type <IndustryWinningStreakView>.
    /// </summary>
    public class IndustryWinningStreakViewReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'IndustryWinningStreakView' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'IndustryWinningStreakView' DataObject.</returns>
            public static IndustryWinningStreakView Load(DataRow dataRow)
            {
                // Initial Value
                IndustryWinningStreakView industryWinningStreakView = new IndustryWinningStreakView();

                // Create field Integers
                int advancersfield = 0;
                int averagePercentChangefield = 1;
                int declinersfield = 2;
                int namefield = 3;
                int streakfield = 4;

                try
                {
                    // Load Each field
                    industryWinningStreakView.Advancers = DataHelper.ParseInteger(dataRow.ItemArray[advancersfield], 0);
                    industryWinningStreakView.AveragePercentChange = DataHelper.ParseDouble(dataRow.ItemArray[averagePercentChangefield], 0);
                    industryWinningStreakView.Decliners = DataHelper.ParseInteger(dataRow.ItemArray[declinersfield], 0);
                    industryWinningStreakView.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                    industryWinningStreakView.Streak = DataHelper.ParseInteger(dataRow.ItemArray[streakfield], 0);
                }
                catch
                {
                }

                // return value
                return industryWinningStreakView;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'IndustryWinningStreakView' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A IndustryWinningStreakView Collection.</returns>
            public static List<IndustryWinningStreakView> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<IndustryWinningStreakView> industryWinningStreakViews = new List<IndustryWinningStreakView>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'IndustryWinningStreakView' from rows
                        IndustryWinningStreakView industryWinningStreakView = Load(row);

                        // Add this object to collection
                        industryWinningStreakViews.Add(industryWinningStreakView);
                    }
                }
                catch
                {
                }

                // return value
                return industryWinningStreakViews;
            }
            #endregion

        #endregion

    }
    #endregion

}
