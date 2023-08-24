

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteSectorHistoryStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'SectorHistory' object.
    /// </summary>
    public class DeleteSectorHistoryStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteSectorHistoryStoredProcedure' object.
        /// </summary>
        public DeleteSectorHistoryStoredProcedure()
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
                this.ProcedureName = "SectorHistory_Delete";

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
