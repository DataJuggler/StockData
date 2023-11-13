

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllIndustryWinningStreakViewsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'IndustryWinningStreakView' objects.
    /// </summary>
    public class FetchAllIndustryWinningStreakViewsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllIndustryWinningStreakViewsStoredProcedure' object.
        /// </summary>
        public FetchAllIndustryWinningStreakViewsStoredProcedure()
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
                this.ProcedureName = "IndustryWinningStreakView_FetchAll";

                // Set tableName
                this.TableName = "IndustryWinningStreakView";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
