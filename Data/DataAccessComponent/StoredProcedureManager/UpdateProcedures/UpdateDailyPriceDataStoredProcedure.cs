

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateDailyPriceDataStoredProcedure
    /// <summary>
    /// This class is used to Update a 'DailyPriceData' object.
    /// </summary>
    public class UpdateDailyPriceDataStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateDailyPriceDataStoredProcedure' object.
        /// </summary>
        public UpdateDailyPriceDataStoredProcedure()
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
                this.ProcedureName = "DailyPriceData_Update";

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
