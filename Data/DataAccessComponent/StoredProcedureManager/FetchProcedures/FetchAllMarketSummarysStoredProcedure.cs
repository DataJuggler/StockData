

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllMarketSummarysStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'MarketSummary' objects.
    /// </summary>
    public class FetchAllMarketSummarysStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllMarketSummarysStoredProcedure' object.
        /// </summary>
        public FetchAllMarketSummarysStoredProcedure()
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
                this.ProcedureName = "MarketSummary_FetchAll";

                // Set tableName
                this.TableName = "MarketSummary";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
