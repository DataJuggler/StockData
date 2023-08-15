

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class StockStreak
    [Serializable]
    public partial class StockStreak
    {

        #region Private Variables
        #endregion

        #region Constructor
        public StockStreak()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public StockStreak Clone()
            {
                // Create New Object
                StockStreak newStockStreak = (StockStreak) this.MemberwiseClone();

                // Return Cloned Object
                return newStockStreak;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
