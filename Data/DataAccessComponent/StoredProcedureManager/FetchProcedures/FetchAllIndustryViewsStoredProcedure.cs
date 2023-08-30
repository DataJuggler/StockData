

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllIndustryViewsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'IndustryView' objects.
    /// </summary>
    public class FetchAllIndustryViewsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllIndustryViewsStoredProcedure' object.
        /// </summary>
        public FetchAllIndustryViewsStoredProcedure()
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
                this.ProcedureName = "IndustryView_FetchAll";

                // Set tableName
                this.TableName = "IndustryView";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
