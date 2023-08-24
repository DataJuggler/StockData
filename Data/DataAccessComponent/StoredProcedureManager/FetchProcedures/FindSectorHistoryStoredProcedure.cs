

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindSectorHistoryStoredProcedure
    /// <summary>
    /// This class is used to Find a 'SectorHistory' object.
    /// </summary>
    public class FindSectorHistoryStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindSectorHistoryStoredProcedure' object.
        /// </summary>
        public FindSectorHistoryStoredProcedure()
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
                this.ProcedureName = "SectorHistory_Find";

                // Set tableName
                this.TableName = "SectorHistory";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
