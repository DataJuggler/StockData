

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class IndustryHistory
    [Serializable]
    public partial class IndustryHistory
    {

        #region Private Variables
        #endregion

        #region Constructor
        public IndustryHistory()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public IndustryHistory Clone()
            {
                // Create New Object
                IndustryHistory newIndustryHistory = (IndustryHistory) this.MemberwiseClone();

                // Return Cloned Object
                return newIndustryHistory;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
