

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteSectorStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'Sector' object.
    /// </summary>
    public class DeleteSectorStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteSectorStoredProcedure' object.
        /// </summary>
        public DeleteSectorStoredProcedure()
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
                this.ProcedureName = "Sector_Delete";

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
