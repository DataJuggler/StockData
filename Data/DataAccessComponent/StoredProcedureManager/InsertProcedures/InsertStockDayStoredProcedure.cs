

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertStockDayStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'StockDay' object.
    /// </summary>
    public class InsertStockDayStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertStockDayStoredProcedure' object.
        /// </summary>
        public InsertStockDayStoredProcedure()
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
                this.ProcedureName = "StockDay_Insert";

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
