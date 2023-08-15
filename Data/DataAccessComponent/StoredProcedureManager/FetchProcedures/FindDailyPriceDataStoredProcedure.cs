

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindDailyPriceDataStoredProcedure
    /// <summary>
    /// This class is used to Find a 'DailyPriceData' object.
    /// </summary>
    public class FindDailyPriceDataStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindDailyPriceDataStoredProcedure' object.
        /// </summary>
        public FindDailyPriceDataStoredProcedure()
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
                this.ProcedureName = "DailyPriceData_Find";

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
