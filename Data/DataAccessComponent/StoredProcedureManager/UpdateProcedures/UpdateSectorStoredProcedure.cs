

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateSectorStoredProcedure
    /// <summary>
    /// This class is used to Update a 'Sector' object.
    /// </summary>
    public class UpdateSectorStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateSectorStoredProcedure' object.
        /// </summary>
        public UpdateSectorStoredProcedure()
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
                this.ProcedureName = "Sector_Update";

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
