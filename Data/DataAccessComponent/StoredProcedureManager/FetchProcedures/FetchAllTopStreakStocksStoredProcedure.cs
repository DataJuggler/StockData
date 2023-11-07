

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllTopStreakStocksStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'TopStreakStocks' objects.
    /// </summary>
    public class FetchAllTopStreakStocksStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllTopStreakStocksStoredProcedure' object.
        /// </summary>
        public FetchAllTopStreakStocksStoredProcedure()
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
                this.ProcedureName = "TopStreakStocks_FetchAll";

                // Set tableName
                this.TableName = "TopStreakStocks";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
