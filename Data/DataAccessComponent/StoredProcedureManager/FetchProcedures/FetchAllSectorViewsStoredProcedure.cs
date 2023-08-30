

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllSectorViewsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'SectorView' objects.
    /// </summary>
    public class FetchAllSectorViewsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllSectorViewsStoredProcedure' object.
        /// </summary>
        public FetchAllSectorViewsStoredProcedure()
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
                this.ProcedureName = "SectorView_FetchAll";

                // Set tableName
                this.TableName = "SectorView";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
