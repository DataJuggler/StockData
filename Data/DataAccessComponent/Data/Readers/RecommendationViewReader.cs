

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class RecommendationViewReader
    /// <summary>
    /// This class loads a single 'RecommendationView' object or a list of type <RecommendationView>.
    /// </summary>
    public class RecommendationViewReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'RecommendationView' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'RecommendationView' DataObject.</returns>
            public static RecommendationView Load(DataRow dataRow)
            {
                // Initial Value
                RecommendationView recommendationView = new RecommendationView();

                // Create field Integers
                int closeScorefield = 0;
                int industryfield = 1;
                int industryScorefield = 2;
                int industryStreakfield = 3;
                int lastClosefield = 4;
                int lastPercentChangefield = 5;
                int scorefield = 6;
                int sectorfield = 7;
                int sectorScorefield = 8;
                int sectorStreakfield = 9;
                int stockDatefield = 10;
                int stockIDfield = 11;
                int stockNamefield = 12;
                int streakfield = 13;
                int streakPercentChangefield = 14;
                int symbolfield = 15;
                int volumeScorefield = 16;

                try
                {
                    // Load Each field
                    recommendationView.CloseScore = DataHelper.ParseDouble(dataRow.ItemArray[closeScorefield], 0);
                    recommendationView.Industry = DataHelper.ParseString(dataRow.ItemArray[industryfield]);
                    recommendationView.IndustryScore = DataHelper.ParseDouble(dataRow.ItemArray[industryScorefield], 0);
                    recommendationView.IndustryStreak = DataHelper.ParseInteger(dataRow.ItemArray[industryStreakfield], 0);
                    recommendationView.LastClose = DataHelper.ParseDouble(dataRow.ItemArray[lastClosefield], 0);
                    recommendationView.LastPercentChange = DataHelper.ParseDouble(dataRow.ItemArray[lastPercentChangefield], 0);
                    recommendationView.Score = DataHelper.ParseDouble(dataRow.ItemArray[scorefield], 0);
                    recommendationView.Sector = DataHelper.ParseString(dataRow.ItemArray[sectorfield]);
                    recommendationView.SectorScore = DataHelper.ParseDouble(dataRow.ItemArray[sectorScorefield], 0);
                    recommendationView.SectorStreak = DataHelper.ParseInteger(dataRow.ItemArray[sectorStreakfield], 0);
                    recommendationView.StockDate = DataHelper.ParseDate(dataRow.ItemArray[stockDatefield]);
                    recommendationView.StockID = DataHelper.ParseInteger(dataRow.ItemArray[stockIDfield], 0);
                    recommendationView.StockName = DataHelper.ParseString(dataRow.ItemArray[stockNamefield]);
                    recommendationView.Streak = DataHelper.ParseInteger(dataRow.ItemArray[streakfield], 0);
                    recommendationView.StreakPercentChange = DataHelper.ParseDouble(dataRow.ItemArray[streakPercentChangefield], 0);
                    recommendationView.Symbol = DataHelper.ParseString(dataRow.ItemArray[symbolfield]);
                    recommendationView.VolumeScore = DataHelper.ParseDouble(dataRow.ItemArray[volumeScorefield], 0);
                }
                catch
                {
                }

                // return value
                return recommendationView;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'RecommendationView' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A RecommendationView Collection.</returns>
            public static List<RecommendationView> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<RecommendationView> recommendationViews = new List<RecommendationView>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'RecommendationView' from rows
                        RecommendationView recommendationView = Load(row);

                        // Add this object to collection
                        recommendationViews.Add(recommendationView);
                    }
                }
                catch
                {
                }

                // return value
                return recommendationViews;
            }
            #endregion

        #endregion

    }
    #endregion

}
