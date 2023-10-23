

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllDoNotTracksStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'DoNotTrack' objects.
    /// </summary>
    public class FetchAllDoNotTracksStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllDoNotTracksStoredProcedure' object.
        /// </summary>
        public FetchAllDoNotTracksStoredProcedure()
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
                this.ProcedureName = "DoNotTrack_FetchAll";

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
