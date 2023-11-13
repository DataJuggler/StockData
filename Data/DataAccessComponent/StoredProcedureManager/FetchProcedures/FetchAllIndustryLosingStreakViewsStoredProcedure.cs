

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllIndustryLosingStreakViewsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'IndustryLosingStreakView' objects.
    /// </summary>
    public class FetchAllIndustryLosingStreakViewsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllIndustryLosingStreakViewsStoredProcedure' object.
        /// </summary>
        public FetchAllIndustryLosingStreakViewsStoredProcedure()
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
                this.ProcedureName = "IndustryLosingStreakView_FetchAll";

                // Set tableName
                this.TableName = "IndustryLosingStreakView";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
