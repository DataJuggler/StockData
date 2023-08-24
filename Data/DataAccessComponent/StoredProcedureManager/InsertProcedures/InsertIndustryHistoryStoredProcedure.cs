

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertIndustryHistoryStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'IndustryHistory' object.
    /// </summary>
    public class InsertIndustryHistoryStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertIndustryHistoryStoredProcedure' object.
        /// </summary>
        public InsertIndustryHistoryStoredProcedure()
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
                this.ProcedureName = "IndustryHistory_Insert";

                // Set tableName
                this.TableName = "IndustryHistory";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
