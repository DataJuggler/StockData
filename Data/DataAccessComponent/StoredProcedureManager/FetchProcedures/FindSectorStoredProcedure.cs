

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindSectorStoredProcedure
    /// <summary>
    /// This class is used to Find a 'Sector' object.
    /// </summary>
    public class FindSectorStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindSectorStoredProcedure' object.
        /// </summary>
        public FindSectorStoredProcedure()
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
                this.ProcedureName = "Sector_Find";

                // Set tableName
                this.TableName = "Sector";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
