

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindIndustryStoredProcedure
    /// <summary>
    /// This class is used to Find a 'Industry' object.
    /// </summary>
    public class FindIndustryStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindIndustryStoredProcedure' object.
        /// </summary>
        public FindIndustryStoredProcedure()
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
                this.ProcedureName = "Industry_Find";

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
