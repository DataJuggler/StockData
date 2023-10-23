

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class IndustrySummary
    public partial class IndustrySummary
    {

        #region Private Variables
        private int industryAdvancers;
        private int industryDecliners;
        #endregion

        #region Methods


        #endregion

        #region Properties

            #region int IndustryAdvancers
            public int IndustryAdvancers
            {
                get
                {
                    return industryAdvancers;
                }
                set
                {
                    industryAdvancers = value;
                }
            }
            #endregion

            #region int IndustryDecliners
            public int IndustryDecliners
            {
                get
                {
                    return industryDecliners;
                }
                set
                {
                    industryDecliners = value;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
