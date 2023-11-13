

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class IndustryLosingStreakViewReader
    /// <summary>
    /// This class loads a single 'IndustryLosingStreakView' object or a list of type <IndustryLosingStreakView>.
    /// </summary>
    public class IndustryLosingStreakViewReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'IndustryLosingStreakView' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'IndustryLosingStreakView' DataObject.</returns>
            public static IndustryLosingStreakView Load(DataRow dataRow)
            {
                // Initial Value
                IndustryLosingStreakView industryLosingStreakView = new IndustryLosingStreakView();

                // Create field Integers
                int advancersfield = 0;
                int averagePercentChangefield = 1;
                int declinersfield = 2;
                int namefield = 3;
                int streakfield = 4;

                try
                {
                    // Load Each field
                    industryLosingStreakView.Advancers = DataHelper.ParseInteger(dataRow.ItemArray[advancersfield], 0);
                    industryLosingStreakView.AveragePercentChange = DataHelper.ParseDouble(dataRow.ItemArray[averagePercentChangefield], 0);
                    industryLosingStreakView.Decliners = DataHelper.ParseInteger(dataRow.ItemArray[declinersfield], 0);
                    industryLosingStreakView.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                    industryLosingStreakView.Streak = DataHelper.ParseInteger(dataRow.ItemArray[streakfield], 0);
                }
                catch
                {
                }

                // return value
                return industryLosingStreakView;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'IndustryLosingStreakView' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A IndustryLosingStreakView Collection.</returns>
            public static List<IndustryLosingStreakView> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<IndustryLosingStreakView> industryLosingStreakViews = new List<IndustryLosingStreakView>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'IndustryLosingStreakView' from rows
                        IndustryLosingStreakView industryLosingStreakView = Load(row);

                        // Add this object to collection
                        industryLosingStreakViews.Add(industryLosingStreakView);
                    }
                }
                catch
                {
                }

                // return value
                return industryLosingStreakViews;
            }
            #endregion

        #endregion

    }
    #endregion

}
