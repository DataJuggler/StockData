

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllStockStreaksStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'StockStreak' objects.
    /// </summary>
    public class FetchAllStockStreaksStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllStockStreaksStoredProcedure' object.
        /// </summary>
        public FetchAllStockStreaksStoredProcedure()
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
                this.ProcedureName = "StockStreak_FetchAll";

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
