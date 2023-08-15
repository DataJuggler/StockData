

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
        #endregion

    }
    #endregion

}
