
#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class DoNotTrack
    [Serializable]
    public partial class DoNotTrack
    {

        #region Private Variables
        private bool findBySymbol;
        #endregion

        #region Constructor
        public DoNotTrack()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public DoNotTrack Clone()
            {
                // Create New Object
                DoNotTrack newDoNotTrack = (DoNotTrack) this.MemberwiseClone();

                // Return Cloned Object
                return newDoNotTrack;
            }
            #endregion

        #endregion

        #region Properties

            #region FindBySymbol
            /// <summary>
            /// This property gets or sets the value for 'FindBySymbol'.
            /// </summary>
            public bool FindBySymbol
            {
                get { return findBySymbol; }
                set { findBySymbol = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
