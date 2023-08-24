

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllSectorHistorysStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'SectorHistory' objects.
    /// </summary>
    public class FetchAllSectorHistorysStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllSectorHistorysStoredProcedure' object.
        /// </summary>
        public FetchAllSectorHistorysStoredProcedure()
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
                this.ProcedureName = "SectorHistory_FetchAll";

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
