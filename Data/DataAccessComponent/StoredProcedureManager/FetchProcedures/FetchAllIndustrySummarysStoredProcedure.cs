

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllIndustrySummarysStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'IndustrySummary' objects.
    /// </summary>
    public class FetchAllIndustrySummarysStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllIndustrySummarysStoredProcedure' object.
        /// </summary>
        public FetchAllIndustrySummarysStoredProcedure()
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
                this.ProcedureName = "IndustrySummary_FetchAll";

                // Set tableName
                this.TableName = "IndustrySummary";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
