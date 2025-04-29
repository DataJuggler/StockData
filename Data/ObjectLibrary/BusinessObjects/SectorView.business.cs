
#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class SectorView
    [Serializable]
    public partial class SectorView
    {

        #region Private Variables
        private bool loadBySectorAndStockDate;
        #endregion

        #region Constructor
        public SectorView()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public SectorView Clone()
            {
                // Create New Object
                SectorView newSectorView = (SectorView) this.MemberwiseClone();

                // Return Cloned Object
                return newSectorView;
            }
            #endregion

        #endregion

        #region Properties

            #region LoadBySectorAndStockDate
            /// <summary>
            /// This property gets or sets the value for 'LoadBySectorAndStockDate'.
            /// </summary>
            public bool LoadBySectorAndStockDate
            {
                get { return loadBySectorAndStockDate; }
                set { loadBySectorAndStockDate = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
