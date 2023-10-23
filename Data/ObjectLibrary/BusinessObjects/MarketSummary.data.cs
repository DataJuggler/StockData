

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class MarketSummary
    public partial class MarketSummary
    {

        #region Private Variables
        private int advancers;
        private int decliners;
        private int numberStocks;
        private DateTime stockDate;
        #endregion

        #region Methods


        #endregion

        #region Properties

            #region int Advancers
            public int Advancers
            {
                get
                {
                    return advancers;
                }
                set
                {
                    advancers = value;
                }
            }
            #endregion

            #region int Decliners
            public int Decliners
            {
                get
                {
                    return decliners;
                }
                set
                {
                    decliners = value;
                }
            }
            #endregion

            #region int NumberStocks
            public int NumberStocks
            {
                get
                {
                    return numberStocks;
                }
                set
                {
                    numberStocks = value;
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

        #endregion

    }
    #endregion

}
