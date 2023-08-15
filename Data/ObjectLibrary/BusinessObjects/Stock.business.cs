
#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class Stock
    [Serializable]
    public partial class Stock
    {

        #region Private Variables
        private bool findBySymbol;
        #endregion

        #region Constructor
        public Stock()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public Stock Clone()
            {
                // Create New Object
                Stock newStock = (Stock) this.MemberwiseClone();

                // Return Cloned Object
                return newStock;
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
