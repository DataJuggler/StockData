

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllRecommendationViewsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'RecommendationView' objects.
    /// </summary>
    public class FetchAllRecommendationViewsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllRecommendationViewsStoredProcedure' object.
        /// </summary>
        public FetchAllRecommendationViewsStoredProcedure()
        {
            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Set Procedure Properties
            /// </summary>
            private void Init()
            {
                // Set Properties For This Proc

                // Set ProcedureName
                this.ProcedureName = "RecommendationView_FetchAll";

                // Set tableName
                this.TableName = "RecommendationView";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
