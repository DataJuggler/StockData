

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
        private string exchange;
        private string industry;
        private double lastClose;
        private string name;
        private double percentChange;
        private bool reverseSplit;
        private int reverseSplitDivisor;
        private string sector;
        private int stockId;
        private int streak;
        private DateTime streakEndDate;
        private double streakEndPrice;
        private DateTime streakStartDate;
        private double streakStartPrice;
        private string symbol;
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

            #region double PercentChange
            public double PercentChange
            {
                get
                {
                    return percentChange;
                }
                set
                {
                    percentChange = value;
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

        #endregion

    }
    #endregion

}
