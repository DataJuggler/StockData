

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindStockStreakStoredProcedure
    /// <summary>
    /// This class is used to Find a 'StockStreak' object.
    /// </summary>
    public class FindStockStreakStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindStockStreakStoredProcedure' object.
        /// </summary>
        public FindStockStreakStoredProcedure()
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
                this.ProcedureName = "StockStreak_Find";

                // Set tableName
                this.TableName = "StockStreak";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
