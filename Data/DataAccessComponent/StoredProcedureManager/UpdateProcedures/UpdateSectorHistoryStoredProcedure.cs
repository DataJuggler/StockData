

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateSectorHistoryStoredProcedure
    /// <summary>
    /// This class is used to Update a 'SectorHistory' object.
    /// </summary>
    public class UpdateSectorHistoryStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateSectorHistoryStoredProcedure' object.
        /// </summary>
        public UpdateSectorHistoryStoredProcedure()
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
                this.ProcedureName = "SectorHistory_Update";

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
