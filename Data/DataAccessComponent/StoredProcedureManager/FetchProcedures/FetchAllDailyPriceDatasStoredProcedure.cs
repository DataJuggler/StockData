

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllDailyPriceDatasStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'DailyPriceData' objects.
    /// </summary>
    public class FetchAllDailyPriceDatasStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllDailyPriceDatasStoredProcedure' object.
        /// </summary>
        public FetchAllDailyPriceDatasStoredProcedure()
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
                this.ProcedureName = "DailyPriceData_FetchAll";

                // Set tableName
                this.TableName = "DailyPriceData";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
