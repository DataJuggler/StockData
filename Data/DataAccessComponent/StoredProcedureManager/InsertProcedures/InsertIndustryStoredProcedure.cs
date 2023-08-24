

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertIndustryStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'Industry' object.
    /// </summary>
    public class InsertIndustryStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertIndustryStoredProcedure' object.
        /// </summary>
        public InsertIndustryStoredProcedure()
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
                this.ProcedureName = "Industry_Insert";

                // Set tableName
                this.TableName = "Industry";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
