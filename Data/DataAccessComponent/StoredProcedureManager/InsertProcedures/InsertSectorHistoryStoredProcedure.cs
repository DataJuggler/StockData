

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertSectorHistoryStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'SectorHistory' object.
    /// </summary>
    public class InsertSectorHistoryStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertSectorHistoryStoredProcedure' object.
        /// </summary>
        public InsertSectorHistoryStoredProcedure()
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
                this.ProcedureName = "SectorHistory_Insert";

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
