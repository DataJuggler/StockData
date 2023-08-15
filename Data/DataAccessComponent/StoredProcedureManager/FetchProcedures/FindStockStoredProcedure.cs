

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindStockStoredProcedure
    /// <summary>
    /// This class is used to Find a 'Stock' object.
    /// </summary>
    public class FindStockStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindStockStoredProcedure' object.
        /// </summary>
        public FindStockStoredProcedure()
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
                this.ProcedureName = "Stock_Find";

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
