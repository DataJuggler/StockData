

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class IndustryWinningStreakView
    [Serializable]
    public partial class IndustryWinningStreakView
    {

        #region Private Variables
        #endregion

        #region Constructor
        public IndustryWinningStreakView()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public IndustryWinningStreakView Clone()
            {
                // Create New Object
                IndustryWinningStreakView newIndustryWinningStreakView = (IndustryWinningStreakView) this.MemberwiseClone();

                // Return Cloned Object
                return newIndustryWinningStreakView;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
