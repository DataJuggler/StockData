
#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class DailyPriceData
    [Serializable]
    public partial class DailyPriceData
    {

        #region Private Variables
        private bool loadBySymbol;
        private bool findBySymbolAndMostRecent;
        private bool loadCompleteListBySymbol;        
        private bool findMaxStreakBySymbol;
        private bool findByStockDateAndSymbol;
        #endregion

        #region Constructor
        public DailyPriceData()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public DailyPriceData Clone()
            {
                // Create New Object
                DailyPriceData newDailyPriceData = (DailyPriceData) this.MemberwiseClone();

                // Return Cloned Object
                return newDailyPriceData;
            }
            #endregion

        #endregion

        #region Properties

            #region FindByStockDateAndSymbol
            /// <summary>
            /// This property gets or sets the value for 'FindByStockDateAndSymbol'.
            /// </summary>
            public bool FindByStockDateAndSymbol
            {
                get { return findByStockDateAndSymbol; }
                set { findByStockDateAndSymbol = value; }
            }
            #endregion

            #region FindBySymbolAndMostRecent
            /// <summary>
            /// This property gets or sets the value for 'FindBySymbolAndMostRecent'.
            /// </summary>
            public bool FindBySymbolAndMostRecent
            {
                get { return findBySymbolAndMostRecent; }
                set { findBySymbolAndMostRecent = value; }
            }
            #endregion

            #region FindMaxStreakBySymbol
            /// <summary>
            /// This property gets or sets the value for 'FindMaxStreakBySymbol'.
            /// </summary>
            public bool FindMaxStreakBySymbol
            {
                get { return findMaxStreakBySymbol; }
                set { findMaxStreakBySymbol = value; }
            }
            #endregion

            #region LoadBySymbol
            /// <summary>
            /// This property gets or sets the value for 'LoadBySymbol'.
            /// </summary>
            public bool LoadBySymbol
            {
                get { return loadBySymbol; }
                set { loadBySymbol = value; }
            }
            #endregion

            #region LoadCompleteListBySymbol
            /// <summary>
            /// This property gets or sets the value for 'LoadCompleteListBySymbol'.
            /// </summary>
            public bool LoadCompleteListBySymbol
            {
                get { return loadCompleteListBySymbol; }
                set { loadCompleteListBySymbol = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
