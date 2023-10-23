

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class IndustrySummary
    [Serializable]
    public partial class IndustrySummary
    {

        #region Private Variables
        #endregion

        #region Constructor
        public IndustrySummary()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public IndustrySummary Clone()
            {
                // Create New Object
                IndustrySummary newIndustrySummary = (IndustrySummary) this.MemberwiseClone();

                // Return Cloned Object
                return newIndustrySummary;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
