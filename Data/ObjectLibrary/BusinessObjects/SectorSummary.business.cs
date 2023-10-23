

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class SectorSummary
    [Serializable]
    public partial class SectorSummary
    {

        #region Private Variables
        #endregion

        #region Constructor
        public SectorSummary()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public SectorSummary Clone()
            {
                // Create New Object
                SectorSummary newSectorSummary = (SectorSummary) this.MemberwiseClone();

                // Return Cloned Object
                return newSectorSummary;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
