
#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class StockDay
    [Serializable]
    public partial class StockDay
    {

        #region Private Variables
        private bool loadByIndustryProcessedAndSectorProcessed;
        #endregion

        #region Constructor
        public StockDay()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public StockDay Clone()
            {
                // Create New Object
                StockDay newStockDay = (StockDay) this.MemberwiseClone();

                // Return Cloned Object
                return newStockDay;
            }
            #endregion

        #endregion

        #region Properties

            #region LoadByIndustryProcessedAndSectorProcessed
            /// <summary>
            /// This property gets or sets the value for 'LoadByIndustryProcessedAndSectorProcessed'.
            /// </summary>
            public bool LoadByIndustryProcessedAndSectorProcessed
            {
                get { return loadByIndustryProcessedAndSectorProcessed; }
                set { loadByIndustryProcessedAndSectorProcessed = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
