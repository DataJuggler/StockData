

#region using statements

using ObjectLibrary.Enumerations;
using System;
using DataJuggler.UltimateHelper;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class MarketSummary
    [Serializable]
    public partial class MarketSummary
    {

        #region Private Variables
        #endregion

        #region Constructor
        public MarketSummary()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public MarketSummary Clone()
            {
                // Create New Object
                MarketSummary newMarketSummary = (MarketSummary) this.MemberwiseClone();

                // Return Cloned Object
                return newMarketSummary;
            }
            #endregion

        #endregion

        #region Properties

            #region Score
            public double Score
            {
                get
                {
                    // Set the return value
                    double score = NumericHelper.DivideDoublesAsDecimals(NumberStocks, Advancers, 2);

                    // return value
                    return score;
                }
            }
            #endregion

        #endregion
    }
    #endregion
}