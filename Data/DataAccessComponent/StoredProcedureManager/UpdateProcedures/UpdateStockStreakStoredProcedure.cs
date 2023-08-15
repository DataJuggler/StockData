

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateStockStreakStoredProcedure
    /// <summary>
    /// This class is used to Update a 'StockStreak' object.
    /// </summary>
    public class UpdateStockStreakStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateStockStreakStoredProcedure' object.
        /// </summary>
        public UpdateStockStreakStoredProcedure()
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
                this.ProcedureName = "StockStreak_Update";

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
