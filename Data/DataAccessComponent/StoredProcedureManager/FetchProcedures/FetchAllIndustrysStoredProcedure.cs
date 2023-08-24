

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllIndustrysStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'Industry' objects.
    /// </summary>
    public class FetchAllIndustrysStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllIndustrysStoredProcedure' object.
        /// </summary>
        public FetchAllIndustrysStoredProcedure()
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
                this.ProcedureName = "Industry_FetchAll";

                // Set tableName
                this.TableName = "Industry";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
