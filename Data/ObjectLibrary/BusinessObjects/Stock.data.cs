

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Stock
    public partial class Stock
    {

        #region Private Variables
        private int averageDailyVolume;
        private string country;
        private int daysBelowMinVolume;
        private string exchange;
        private int id;
        private string industry;
        private int iPOYear;
        private double lastClose;
        private string name;
        private string sector;
        private int streak;
        private string symbol;
        private bool track;
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

            #region string Country
            public string Country
            {
                get
                {
                    return country;
                }
                set
                {
                    country = value;
                }
            }
            #endregion

            #region int DaysBelowMinVolume
            public int DaysBelowMinVolume
            {
                get
                {
                    return daysBelowMinVolume;
                }
                set
                {
                    daysBelowMinVolume = value;
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

            #region int IPOYear
            public int IPOYear
            {
                get
                {
                    return iPOYear;
                }
                set
                {
                    iPOYear = value;
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

            #region bool Track
            public bool Track
            {
                get
                {
                    return track;
                }
                set
                {
                    track = value;
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
