

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateStockDayStoredProcedure
    /// <summary>
    /// This class is used to Update a 'StockDay' object.
    /// </summary>
    public class UpdateStockDayStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateStockDayStoredProcedure' object.
        /// </summary>
        public UpdateStockDayStoredProcedure()
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
                this.ProcedureName = "StockDay_Update";

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
