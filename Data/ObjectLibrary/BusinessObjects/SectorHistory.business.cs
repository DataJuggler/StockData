

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class SectorHistory
    [Serializable]
    public partial class SectorHistory
    {

        #region Private Variables
        #endregion

        #region Constructor
        public SectorHistory()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public SectorHistory Clone()
            {
                // Create New Object
                SectorHistory newSectorHistory = (SectorHistory) this.MemberwiseClone();

                // Return Cloned Object
                return newSectorHistory;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
