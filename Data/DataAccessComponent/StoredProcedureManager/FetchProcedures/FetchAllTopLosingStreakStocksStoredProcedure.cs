

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllTopLosingStreakStocksStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'TopLosingStreakStocks' objects.
    /// </summary>
    public class FetchAllTopLosingStreakStocksStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllTopLosingStreakStocksStoredProcedure' object.
        /// </summary>
        public FetchAllTopLosingStreakStocksStoredProcedure()
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
                this.ProcedureName = "TopLosingStreakStocks_FetchAll";

                // Set tableName
                this.TableName = "TopLosingStreakStocks";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
