

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteRecommendationLogStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'RecommendationLog' object.
    /// </summary>
    public class DeleteRecommendationLogStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteRecommendationLogStoredProcedure' object.
        /// </summary>
        public DeleteRecommendationLogStoredProcedure()
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
                this.ProcedureName = "RecommendationLog_Delete";

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
