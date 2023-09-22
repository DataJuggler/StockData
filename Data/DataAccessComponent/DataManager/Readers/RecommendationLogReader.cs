

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class RecommendationLogReader
    /// <summary>
    /// This class loads a single 'RecommendationLog' object or a list of type <RecommendationLog>.
    /// </summary>
    public class RecommendationLogReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'RecommendationLog' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'RecommendationLog' DataObject.</returns>
            public static RecommendationLog Load(DataRow dataRow)
            {
                // Initial Value
                RecommendationLog recommendationLog = new RecommendationLog();

                // Create field Integers
                int closeScorefield = 0;
                int idfield = 1;
                int industryfield = 2;
                int industryScorefield = 3;
                int industryStreakfield = 4;
                int lastClosefield = 5;
                int lastPercentChangefield = 6;
                int scorefield = 7;
                int sectorfield = 8;
                int sectorScorefield = 9;
                int sectorStreakfield = 10;
                int stockDatefield = 11;
                int stockNamefield = 12;
                int streakfield = 13;
                int streakPercentChangefield = 14;
                int symbolfield = 15;
                int volumeScorefield = 16;

                try
                {
                    // Load Each field
                    recommendationLog.CloseScore = DataHelper.ParseDouble(dataRow.ItemArray[closeScorefield], 0);
                    recommendationLog.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    recommendationLog.Industry = DataHelper.ParseString(dataRow.ItemArray[industryfield]);
                    recommendationLog.IndustryScore = DataHelper.ParseDouble(dataRow.ItemArray[industryScorefield], 0);
                    recommendationLog.IndustryStreak = DataHelper.ParseInteger(dataRow.ItemArray[industryStreakfield], 0);
                    recommendationLog.LastClose = DataHelper.ParseDouble(dataRow.ItemArray[lastClosefield], 0);
                    recommendationLog.LastPercentChange = DataHelper.ParseDouble(dataRow.ItemArray[lastPercentChangefield], 0);
                    recommendationLog.Score = DataHelper.ParseDouble(dataRow.ItemArray[scorefield], 0);
                    recommendationLog.Sector = DataHelper.ParseString(dataRow.ItemArray[sectorfield]);
                    recommendationLog.SectorScore = DataHelper.ParseDouble(dataRow.ItemArray[sectorScorefield], 0);
                    recommendationLog.SectorStreak = DataHelper.ParseInteger(dataRow.ItemArray[sectorStreakfield], 0);
                    recommendationLog.StockDate = DataHelper.ParseDate(dataRow.ItemArray[stockDatefield]);
                    recommendationLog.StockName = DataHelper.ParseString(dataRow.ItemArray[stockNamefield]);
                    recommendationLog.Streak = DataHelper.ParseInteger(dataRow.ItemArray[streakfield], 0);
                    recommendationLog.StreakPercentChange = DataHelper.ParseDouble(dataRow.ItemArray[streakPercentChangefield], 0);
                    recommendationLog.Symbol = DataHelper.ParseString(dataRow.ItemArray[symbolfield]);
                    recommendationLog.VolumeScore = DataHelper.ParseDouble(dataRow.ItemArray[volumeScorefield], 0);
                }
                catch
                {
                }

                // return value
                return recommendationLog;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'RecommendationLog' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A RecommendationLog Collection.</returns>
            public static List<RecommendationLog> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<RecommendationLog> recommendationLogs = new List<RecommendationLog>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'RecommendationLog' from rows
                        RecommendationLog recommendationLog = Load(row);

                        // Add this object to collection
                        recommendationLogs.Add(recommendationLog);
                    }
                }
                catch
                {
                }

                // return value
                return recommendationLogs;
            }
            #endregion

        #endregion

    }
    #endregion

}
