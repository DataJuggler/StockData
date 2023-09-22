

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class RecommendationView
    [Serializable]
    public partial class RecommendationView
    {

        #region Private Variables
        #endregion

        #region Constructor
        public RecommendationView()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public RecommendationView Clone()
            {
                // Create New Object
                RecommendationView newRecommendationView = (RecommendationView) this.MemberwiseClone();

                // Return Cloned Object
                return newRecommendationView;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
