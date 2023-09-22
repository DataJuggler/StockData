

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllRecommendationLogsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'RecommendationLog' objects.
    /// </summary>
    public class FetchAllRecommendationLogsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllRecommendationLogsStoredProcedure' object.
        /// </summary>
        public FetchAllRecommendationLogsStoredProcedure()
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
                this.ProcedureName = "RecommendationLog_FetchAll";

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
