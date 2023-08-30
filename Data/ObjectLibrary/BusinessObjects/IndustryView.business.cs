
#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class IndustryView
    [Serializable]
    public partial class IndustryView
    {

        #region Private Variables        
        
        private bool loadByIndustryAndStockDate;
        #endregion

        #region Constructor
        public IndustryView()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public IndustryView Clone()
            {
                // Create New Object
                IndustryView newIndustryView = (IndustryView) this.MemberwiseClone();

                // Return Cloned Object
                return newIndustryView;
            }
            #endregion

        #endregion

        #region Properties

            #region LoadByIndustryAndStockDate
            /// <summary>
            /// This property gets or sets the value for 'LoadByIndustryAndStockDate'.
            /// </summary>
            public bool LoadByIndustryAndStockDate
            {
                get { return loadByIndustryAndStockDate; }
                set { loadByIndustryAndStockDate = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
