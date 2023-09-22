

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertRecommendationLogStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'RecommendationLog' object.
    /// </summary>
    public class InsertRecommendationLogStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertRecommendationLogStoredProcedure' object.
        /// </summary>
        public InsertRecommendationLogStoredProcedure()
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
                this.ProcedureName = "RecommendationLog_Insert";

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
