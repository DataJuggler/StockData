

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllIndustryHistorysStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'IndustryHistory' objects.
    /// </summary>
    public class FetchAllIndustryHistorysStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllIndustryHistorysStoredProcedure' object.
        /// </summary>
        public FetchAllIndustryHistorysStoredProcedure()
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
                this.ProcedureName = "IndustryHistory_FetchAll";

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
