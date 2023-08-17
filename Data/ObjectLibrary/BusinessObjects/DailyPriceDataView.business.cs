

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class DailyPriceDataView
    [Serializable]
    public partial class DailyPriceDataView
    {

        #region Private Variables
        #endregion

        #region Constructor
        public DailyPriceDataView()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public DailyPriceDataView Clone()
            {
                // Create New Object
                DailyPriceDataView newDailyPriceDataView = (DailyPriceDataView) this.MemberwiseClone();

                // Return Cloned Object
                return newDailyPriceDataView;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
