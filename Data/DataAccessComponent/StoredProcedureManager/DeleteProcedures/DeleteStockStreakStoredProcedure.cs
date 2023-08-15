

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteStockStreakStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'StockStreak' object.
    /// </summary>
    public class DeleteStockStreakStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteStockStreakStoredProcedure' object.
        /// </summary>
        public DeleteStockStreakStoredProcedure()
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
                this.ProcedureName = "StockStreak_Delete";

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
