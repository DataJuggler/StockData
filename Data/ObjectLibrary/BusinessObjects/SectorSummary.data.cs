

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class SectorSummary
    public partial class SectorSummary
    {

        #region Private Variables
        private int sectorAdvancers;
        private int sectorDecliners;
        #endregion

        #region Methods


        #endregion

        #region Properties

            #region int SectorAdvancers
            public int SectorAdvancers
            {
                get
                {
                    return sectorAdvancers;
                }
                set
                {
                    sectorAdvancers = value;
                }
            }
            #endregion

            #region int SectorDecliners
            public int SectorDecliners
            {
                get
                {
                    return sectorDecliners;
                }
                set
                {
                    sectorDecliners = value;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
