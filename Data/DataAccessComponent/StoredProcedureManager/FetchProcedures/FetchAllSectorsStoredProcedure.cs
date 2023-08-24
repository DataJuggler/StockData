

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllSectorsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'Sector' objects.
    /// </summary>
    public class FetchAllSectorsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllSectorsStoredProcedure' object.
        /// </summary>
        public FetchAllSectorsStoredProcedure()
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
                this.ProcedureName = "Sector_FetchAll";

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
