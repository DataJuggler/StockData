

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class IndustryLosingStreakView
    [Serializable]
    public partial class IndustryLosingStreakView
    {

        #region Private Variables
        #endregion

        #region Constructor
        public IndustryLosingStreakView()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public IndustryLosingStreakView Clone()
            {
                // Create New Object
                IndustryLosingStreakView newIndustryLosingStreakView = (IndustryLosingStreakView) this.MemberwiseClone();

                // Return Cloned Object
                return newIndustryLosingStreakView;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
