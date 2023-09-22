

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateRecommendationLogStoredProcedure
    /// <summary>
    /// This class is used to Update a 'RecommendationLog' object.
    /// </summary>
    public class UpdateRecommendationLogStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateRecommendationLogStoredProcedure' object.
        /// </summary>
        public UpdateRecommendationLogStoredProcedure()
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
                this.ProcedureName = "RecommendationLog_Update";

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
