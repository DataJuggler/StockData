

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllStockStreakViewsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'StockStreakView' objects.
    /// </summary>
    public class FetchAllStockStreakViewsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllStockStreakViewsStoredProcedure' object.
        /// </summary>
        public FetchAllStockStreakViewsStoredProcedure()
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
                this.ProcedureName = "StockStreakView_FetchAll";

                // Set tableName
                this.TableName = "StockStreakView";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
