

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindRecommendationLogStoredProcedure
    /// <summary>
    /// This class is used to Find a 'RecommendationLog' object.
    /// </summary>
    public class FindRecommendationLogStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindRecommendationLogStoredProcedure' object.
        /// </summary>
        public FindRecommendationLogStoredProcedure()
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
                this.ProcedureName = "RecommendationLog_Find";

                // Set tableName
                this.TableName = "RecommendationLog";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
