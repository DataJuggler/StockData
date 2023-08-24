

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Sector
    [Serializable]
    public partial class Sector
    {

        #region Private Variables
        #endregion

        #region Constructor
        public Sector()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public Sector Clone()
            {
                // Create New Object
                Sector newSector = (Sector) this.MemberwiseClone();

                // Return Cloned Object
                return newSector;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
