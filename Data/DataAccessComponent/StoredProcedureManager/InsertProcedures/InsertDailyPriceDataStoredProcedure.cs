

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertDailyPriceDataStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'DailyPriceData' object.
    /// </summary>
    public class InsertDailyPriceDataStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertDailyPriceDataStoredProcedure' object.
        /// </summary>
        public InsertDailyPriceDataStoredProcedure()
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
                this.ProcedureName = "DailyPriceData_Insert";

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
