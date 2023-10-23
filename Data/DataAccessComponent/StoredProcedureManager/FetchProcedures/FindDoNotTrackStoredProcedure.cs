

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindDoNotTrackStoredProcedure
    /// <summary>
    /// This class is used to Find a 'DoNotTrack' object.
    /// </summary>
    public class FindDoNotTrackStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindDoNotTrackStoredProcedure' object.
        /// </summary>
        public FindDoNotTrackStoredProcedure()
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
                this.ProcedureName = "DoNotTrack_Find";

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
