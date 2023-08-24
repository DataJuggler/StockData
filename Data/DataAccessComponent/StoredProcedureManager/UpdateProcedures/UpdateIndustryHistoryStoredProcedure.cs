

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateIndustryHistoryStoredProcedure
    /// <summary>
    /// This class is used to Update a 'IndustryHistory' object.
    /// </summary>
    public class UpdateIndustryHistoryStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateIndustryHistoryStoredProcedure' object.
        /// </summary>
        public UpdateIndustryHistoryStoredProcedure()
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
                this.ProcedureName = "IndustryHistory_Update";

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
