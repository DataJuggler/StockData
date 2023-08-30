

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class IndustryView
    public partial class IndustryView
    {

        #region Private Variables
        private double closePrice;
        private int dailyPriceDataId;
        private string industry;
        private bool mostRecent;
        private double percentChange;
        private bool priceUnchanged;
        private DateTime stockDate;
        private int stockId;
        private string stockName;
        private int streak;
        private string symbol;
        private bool track;
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

            #region int DailyPriceDataId
            public int DailyPriceDataId
            {
                get
                {
                    return dailyPriceDataId;
                }
                set
                {
                    dailyPriceDataId = value;
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

        #endregion

    }
    #endregion

}
