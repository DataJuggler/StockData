

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindIndustryHistoryStoredProcedure
    /// <summary>
    /// This class is used to Find a 'IndustryHistory' object.
    /// </summary>
    public class FindIndustryHistoryStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindIndustryHistoryStoredProcedure' object.
        /// </summary>
        public FindIndustryHistoryStoredProcedure()
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
                this.ProcedureName = "IndustryHistory_Find";

                // Set tableName
                this.TableName = "IndustryHistory";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
