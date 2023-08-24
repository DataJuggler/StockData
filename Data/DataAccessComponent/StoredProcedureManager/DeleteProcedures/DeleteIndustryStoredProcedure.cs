

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteIndustryStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'Industry' object.
    /// </summary>
    public class DeleteIndustryStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteIndustryStoredProcedure' object.
        /// </summary>
        public DeleteIndustryStoredProcedure()
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
                this.ProcedureName = "Industry_Delete";

                // Set tableName
                this.TableName = "Industry";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
