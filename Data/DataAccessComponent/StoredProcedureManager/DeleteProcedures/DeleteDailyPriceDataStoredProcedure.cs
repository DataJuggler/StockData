

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteDailyPriceDataStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'DailyPriceData' object.
    /// </summary>
    public class DeleteDailyPriceDataStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteDailyPriceDataStoredProcedure' object.
        /// </summary>
        public DeleteDailyPriceDataStoredProcedure()
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
                this.ProcedureName = "DailyPriceData_Delete";

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
