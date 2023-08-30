

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class DailyPriceData
    public partial class DailyPriceData
    {

        #region Private Variables
        private double closePrice;
        private double closeScore;
        private double highPrice;
        private int id;
        private double lowPrice;
        private bool mostRecent;
        private double openPrice;
        private double percentChange;
        private bool priceUnchanged;
        private double spread;
        private double spreadScore;
        private DateTime stockDate;
        private int streak;
        private string symbol;
        private int volume;
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

            #region double ClosePrice
            public double ClosePrice
            {
                get
                {
                    return closePrice;
                }
                set
                {
                    closePrice = value;
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

            #region double HighPrice
            public double HighPrice
            {
                get
                {
                    return highPrice;
                }
                set
                {
                    highPrice = value;
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

            #region double LowPrice
            public double LowPrice
            {
                get
                {
                    return lowPrice;
                }
                set
                {
                    lowPrice = value;
                }
            }
            #endregion

            #region bool MostRecent
            public bool MostRecent
            {
                get
                {
                    return mostRecent;
                }
                set
                {
                    mostRecent = value;
                }
            }
            #endregion

            #region double OpenPrice
            public double OpenPrice
            {
                get
                {
                    return openPrice;
                }
                set
                {
                    openPrice = value;
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

            #region bool PriceUnchanged
            public bool PriceUnchanged
            {
                get
                {
                    return priceUnchanged;
                }
                set
                {
                    priceUnchanged = value;
                }
            }
            #endregion

            #region double Spread
            public double Spread
            {
                get
                {
                    return spread;
                }
                set
                {
                    spread = value;
                }
            }
            #endregion

            #region double SpreadScore
            public double SpreadScore
            {
                get
                {
                    return spreadScore;
                }
                set
                {
                    spreadScore = value;
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

            #region int Volume
            public int Volume
            {
                get
                {
                    return volume;
                }
                set
                {
                    volume = value;
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
