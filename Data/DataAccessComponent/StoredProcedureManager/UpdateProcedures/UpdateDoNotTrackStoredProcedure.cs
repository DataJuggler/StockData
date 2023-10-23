

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateDoNotTrackStoredProcedure
    /// <summary>
    /// This class is used to Update a 'DoNotTrack' object.
    /// </summary>
    public class UpdateDoNotTrackStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateDoNotTrackStoredProcedure' object.
        /// </summary>
        public UpdateDoNotTrackStoredProcedure()
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
                this.ProcedureName = "DoNotTrack_Update";

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
