

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteDoNotTrackStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'DoNotTrack' object.
    /// </summary>
    public class DeleteDoNotTrackStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteDoNotTrackStoredProcedure' object.
        /// </summary>
        public DeleteDoNotTrackStoredProcedure()
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
                this.ProcedureName = "DoNotTrack_Delete";

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
