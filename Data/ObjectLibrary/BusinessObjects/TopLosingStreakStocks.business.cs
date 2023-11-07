

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class TopLosingStreakStocks
    [Serializable]
    public partial class TopLosingStreakStocks
    {

        #region Private Variables
        #endregion

        #region Constructor
        public TopLosingStreakStocks()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public TopLosingStreakStocks Clone()
            {
                // Create New Object
                TopLosingStreakStocks newTopLosingStreakStocks = (TopLosingStreakStocks) this.MemberwiseClone();

                // Return Cloned Object
                return newTopLosingStreakStocks;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
