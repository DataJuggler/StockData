

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertStockStreakStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'StockStreak' object.
    /// </summary>
    public class InsertStockStreakStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertStockStreakStoredProcedure' object.
        /// </summary>
        public InsertStockStreakStoredProcedure()
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
                this.ProcedureName = "StockStreak_Insert";

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
