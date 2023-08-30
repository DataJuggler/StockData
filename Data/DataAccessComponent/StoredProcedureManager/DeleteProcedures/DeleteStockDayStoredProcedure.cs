

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteStockDayStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'StockDay' object.
    /// </summary>
    public class DeleteStockDayStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteStockDayStoredProcedure' object.
        /// </summary>
        public DeleteStockDayStoredProcedure()
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
                this.ProcedureName = "StockDay_Delete";

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
