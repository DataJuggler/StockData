

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class StockStreakView
    public partial class StockStreakView
    {

        #region Private Variables
        private int averageDailyVolume;
        private double closeScore;
        private string exchange;
        private string industry;
        private double industryScore;
        private int industryStreak;
        private double lastClose;
        private double lastPercentChange;
        private string name;
        private bool reverseSplit;
        private int reverseSplitDivisor;
        private string sector;
        private double sectorScore;
        private int sectorStreak;
        private DateTime stockDate;
        private int stockId;
        private int streak;
        private DateTime streakEndDate;
        private double streakEndPrice;
        private double streakPercentChange;
        private DateTime streakStartDate;
        private double streakStartPrice;
        private string symbol;
        private double volumeScore;
        #endregion

        #region Methods


        #endregion

        #region Properties

            #region int AverageDailyVolume
            public int AverageDailyVolume
            {
                get
                {
                    return averageDailyVolume;
                }
                set
                {
                    averageDailyVolume = value;
                }
            }
            #endregion

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

            #region string Exchange
            public string Exchange
            {
                get
                {
                    return exchange;
                }
                set
                {
                    exchange = value;
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

            #region string Name
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            #endregion

            #region bool ReverseSplit
            public bool ReverseSplit
            {
                get
                {
                    return reverseSplit;
                }
                set
                {
                    reverseSplit = value;
                }
            }
            #endregion

            #region int ReverseSplitDivisor
            public int ReverseSplitDivisor
            {
                get
                {
                    return reverseSplitDivisor;
                }
                set
                {
                    reverseSplitDivisor = value;
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

            #region int StockId
            public int StockId
            {
                get
                {
                    return stockId;
                }
                set
                {
                    stockId = value;
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

            #region DateTime StreakEndDate
            public DateTime StreakEndDate
            {
                get
                {
                    return streakEndDate;
                }
                set
                {
                    streakEndDate = value;
                }
            }
            #endregion

            #region double StreakEndPrice
            public double StreakEndPrice
            {
                get
                {
                    return streakEndPrice;
                }
                set
                {
                    streakEndPrice = value;
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

            #region DateTime StreakStartDate
            public DateTime StreakStartDate
            {
                get
                {
                    return streakStartDate;
                }
                set
                {
                    streakStartDate = value;
                }
            }
            #endregion

            #region double StreakStartPrice
            public double StreakStartPrice
            {
                get
                {
                    return streakStartPrice;
                }
                set
                {
                    streakStartPrice = value;
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

        #endregion

    }
    #endregion

}
