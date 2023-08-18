

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class DailyPriceDataView
    public partial class DailyPriceDataView
    {

        #region Private Variables
        private double closePrice;
        private double closeScore;
        private double highPrice;
        private int id;
        private double lowPrice;
        private double openPrice;
        private double spread;
        private double spreadScore;
        private DateTime stockDate;
        private int stockId;
        private int streak;
        private string symbol;
        private int volume;
        private double volumeScore;
        #endregion

        #region Methods


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
                set
                {
                    id = value;
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

        #endregion

    }
    #endregion

}
