

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateStockStoredProcedure
    /// <summary>
    /// This class is used to Update a 'Stock' object.
    /// </summary>
    public class UpdateStockStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateStockStoredProcedure' object.
        /// </summary>
        public UpdateStockStoredProcedure()
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
                this.ProcedureName = "Stock_Update";

                // Set tableName
                this.TableName = "Stock";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
