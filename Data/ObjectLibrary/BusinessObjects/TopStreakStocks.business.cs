

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class TopStreakStocks
    [Serializable]
    public partial class TopStreakStocks
    {

        #region Private Variables
        #endregion

        #region Constructor
        public TopStreakStocks()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public TopStreakStocks Clone()
            {
                // Create New Object
                TopStreakStocks newTopStreakStocks = (TopStreakStocks) this.MemberwiseClone();

                // Return Cloned Object
                return newTopStreakStocks;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
