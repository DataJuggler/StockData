

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateIndustryStoredProcedure
    /// <summary>
    /// This class is used to Update a 'Industry' object.
    /// </summary>
    public class UpdateIndustryStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateIndustryStoredProcedure' object.
        /// </summary>
        public UpdateIndustryStoredProcedure()
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
                this.ProcedureName = "Industry_Update";

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
