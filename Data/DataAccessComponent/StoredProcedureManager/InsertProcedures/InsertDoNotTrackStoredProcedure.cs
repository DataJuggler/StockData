

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertDoNotTrackStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'DoNotTrack' object.
    /// </summary>
    public class InsertDoNotTrackStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertDoNotTrackStoredProcedure' object.
        /// </summary>
        public InsertDoNotTrackStoredProcedure()
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
                this.ProcedureName = "DoNotTrack_Insert";

                // Set tableName
                this.TableName = "DoNotTrack";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
