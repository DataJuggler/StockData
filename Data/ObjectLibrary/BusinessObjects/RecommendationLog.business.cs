

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class RecommendationLog
    [Serializable]
    public partial class RecommendationLog
    {

        #region Private Variables
        #endregion

        #region Constructor
        public RecommendationLog()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public RecommendationLog Clone()
            {
                // Create New Object
                RecommendationLog newRecommendationLog = (RecommendationLog) this.MemberwiseClone();

                // Return Cloned Object
                return newRecommendationLog;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
