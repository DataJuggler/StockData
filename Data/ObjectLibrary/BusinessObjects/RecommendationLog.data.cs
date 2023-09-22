

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class RecommendationLog
    public partial class RecommendationLog
    {

        #region Private Variables
        private double closeScore;
        private int id;
        private string industry;
        private double industryScore;
        private int industryStreak;
        private double lastClose;
        private double lastPercentChange;
        private double score;
        private string sector;
        private double sectorScore;
        private int sectorStreak;
        private DateTime stockDate;
        private string stockName;
        private int streak;
        private double streakPercentChange;
        private string symbol;
        private double volumeScore;
        #endregion

        #region Methods

            #region UpdateIdentity(int id)
            // <summary>
            // This method provides a 'setter'
            // functionality for the Identity field.
            // </summary>
            public void UpdateIdentity(int id)
            {
                // Update The Identity field
                this.id = id;
            }
            #endregion

        #endregion

        #region Properties

            #region double CloseScore
            public double CloseScore
            {
                get
                {
                    return closeScore;
                }
                set
                {
                    closeScore = value;
                }
            }
            #endregion

            #region int Id
            public int Id
            {
                get
                {
                    return id;
                }
            }
            #endregion

            #region string Industry
            public string Industry
            {
                get
                {
                    return industry;
                }
                set
                {
                    industry = value;
                }
            }
            #endregion

            #region double IndustryScore
            public double IndustryScore
            {
                get
                {
                    return industryScore;
                }
                set
                {
                    industryScore = value;
                }
            }
            #endregion

            #region int IndustryStreak
            public int IndustryStreak
            {
                get
                {
                    return industryStreak;
                }
                set
                {
                    industryStreak = value;
                }
            }
            #endregion

            #region double LastClose
            public double LastClose
            {
                get
                {
                    return lastClose;
                }
                set
                {
                    lastClose = value;
                }
            }
            #endregion

            #region double LastPercentChange
            public double LastPercentChange
            {
                get
                {
                    return lastPercentChange;
                }
                set
                {
                    lastPercentChange = value;
                }
            }
            #endregion

            #region double Score
            public double Score
            {
                get
                {
                    return score;
                }
                set
                {
                    score = value;
                }
            }
            #endregion

            #region string Sector
            public string Sector
            {
                get
                {
                    return sector;
                }
                set
                {
                    sector = value;
                }
            }
            #endregion

            #region double SectorScore
            public double SectorScore
            {
                get
                {
                    return sectorScore;
                }
                set
                {
                    sectorScore = value;
                }
            }
            #endregion

            #region int SectorStreak
            public int SectorStreak
            {
                get
                {
                    return sectorStreak;
                }
                set
                {
                    sectorStreak = value;
                }
            }
            #endregion

            #region DateTime StockDate
            public DateTime StockDate
            {
                get
                {
                    return stockDate;
                }
                set
                {
                    stockDate = value;
                }
            }
            #endregion

            #region string StockName
            public string StockName
            {
                get
                {
                    return stockName;
                }
                set
                {
                    stockName = value;
                }
            }
            #endregion

            #region int Streak
            public int Streak
            {
                get
                {
                    return streak;
                }
                set
                {
                    streak = value;
                }
            }
            #endregion

            #region double StreakPercentChange
            public double StreakPercentChange
            {
                get
                {
                    return streakPercentChange;
                }
                set
                {
                    streakPercentChange = value;
                }
            }
            #endregion

            #region string Symbol
            public string Symbol
            {
                get
                {
                    return symbol;
                }
                set
                {
                    symbol = value;
                }
            }
            #endregion

            #region double VolumeScore
            public double VolumeScore
            {
                get
                {
                    return volumeScore;
                }
                set
                {
                    volumeScore = value;
                }
            }
            #endregion

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.Id < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
