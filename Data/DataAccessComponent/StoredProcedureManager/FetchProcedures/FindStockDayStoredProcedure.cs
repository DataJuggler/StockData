

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindStockDayStoredProcedure
    /// <summary>
    /// This class is used to Find a 'StockDay' object.
    /// </summary>
    public class FindStockDayStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindStockDayStoredProcedure' object.
        /// </summary>
        public FindStockDayStoredProcedure()
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
                this.ProcedureName = "StockDay_Find";

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
