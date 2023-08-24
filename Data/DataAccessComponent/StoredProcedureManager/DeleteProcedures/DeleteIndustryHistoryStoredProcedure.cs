

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteIndustryHistoryStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'IndustryHistory' object.
    /// </summary>
    public class DeleteIndustryHistoryStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteIndustryHistoryStoredProcedure' object.
        /// </summary>
        public DeleteIndustryHistoryStoredProcedure()
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
                this.ProcedureName = "IndustryHistory_Delete";

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
