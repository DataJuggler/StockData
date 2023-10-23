

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllSectorSummarysStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'SectorSummary' objects.
    /// </summary>
    public class FetchAllSectorSummarysStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllSectorSummarysStoredProcedure' object.
        /// </summary>
        public FetchAllSectorSummarysStoredProcedure()
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
                this.ProcedureName = "SectorSummary_FetchAll";

                // Set tableName
                this.TableName = "SectorSummary";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
