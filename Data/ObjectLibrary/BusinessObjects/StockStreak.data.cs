

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class StockStreak
    public partial class StockStreak
    {

        #region Private Variables
        private bool currentStreak;
        private int id;
        private double percentChange;
        private bool reverseSplit;
        private int reverseSplitDivisor;
        private int stockId;
        private int streakDays;
        private DateTime streakEndDate;
        private double streakEndPrice;
        private DateTime streakStartDate;
        private double streakStartPrice;
        private StreakTypeEnum streakType;
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

            #region bool CurrentStreak
            public bool CurrentStreak
            {
                get
                {
                    return currentStreak;
                }
                set
                {
                    currentStreak = value;
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

            #region int StreakDays
            public int StreakDays
            {
                get
                {
                    return streakDays;
                }
                set
                {
                    streakDays = value;
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

            #region StreakTypeEnum StreakType
            public StreakTypeEnum StreakType
            {
                get
                {
                    return streakType;
                }
                set
                {
                    streakType = value;
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
