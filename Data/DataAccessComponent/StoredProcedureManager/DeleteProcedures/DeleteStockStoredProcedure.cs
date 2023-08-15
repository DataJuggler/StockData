

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteStockStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'Stock' object.
    /// </summary>
    public class DeleteStockStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteStockStoredProcedure' object.
        /// </summary>
        public DeleteStockStoredProcedure()
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
                this.ProcedureName = "Stock_Delete";

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
