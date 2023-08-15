

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllStocksStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'Stock' objects.
    /// </summary>
    public class FetchAllStocksStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllStocksStoredProcedure' object.
        /// </summary>
        public FetchAllStocksStoredProcedure()
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
                this.ProcedureName = "Stock_FetchAll";

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
