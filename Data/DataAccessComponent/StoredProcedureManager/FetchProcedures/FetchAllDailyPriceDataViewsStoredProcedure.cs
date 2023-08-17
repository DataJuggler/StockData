

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllDailyPriceDataViewsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'DailyPriceDataView' objects.
    /// </summary>
    public class FetchAllDailyPriceDataViewsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllDailyPriceDataViewsStoredProcedure' object.
        /// </summary>
        public FetchAllDailyPriceDataViewsStoredProcedure()
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
                this.ProcedureName = "DailyPriceDataView_FetchAll";

                // Set tableName
                this.TableName = "DailyPriceDataView";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
