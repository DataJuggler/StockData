

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class StockStreakView
    [Serializable]
    public partial class StockStreakView
    {

        #region Private Variables
        #endregion

        #region Constructor
        public StockStreakView()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public StockStreakView Clone()
            {
                // Create New Object
                StockStreakView newStockStreakView = (StockStreakView) this.MemberwiseClone();

                // Return Cloned Object
                return newStockStreakView;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
