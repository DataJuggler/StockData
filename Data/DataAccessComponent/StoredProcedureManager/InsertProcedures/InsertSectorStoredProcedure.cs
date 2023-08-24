

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertSectorStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'Sector' object.
    /// </summary>
    public class InsertSectorStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertSectorStoredProcedure' object.
        /// </summary>
        public InsertSectorStoredProcedure()
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
                this.ProcedureName = "Sector_Insert";

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
