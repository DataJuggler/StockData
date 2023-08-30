

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllStockDaysStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'StockDay' objects.
    /// </summary>
    public class FetchAllStockDaysStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllStockDaysStoredProcedure' object.
        /// </summary>
        public FetchAllStockDaysStoredProcedure()
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
                this.ProcedureName = "StockDay_FetchAll";

                // Set tableName
                this.TableName = "StockDay";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
