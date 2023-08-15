

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertStockStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'Stock' object.
    /// </summary>
    public class InsertStockStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertStockStoredProcedure' object.
        /// </summary>
        public InsertStockStoredProcedure()
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
                this.ProcedureName = "Stock_Insert";

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
