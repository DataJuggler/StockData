

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Industry
    [Serializable]
    public partial class Industry
    {

        #region Private Variables
        #endregion

        #region Constructor
        public Industry()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public Industry Clone()
            {
                // Create New Object
                Industry newIndustry = (Industry) this.MemberwiseClone();

                // Return Cloned Object
                return newIndustry;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
