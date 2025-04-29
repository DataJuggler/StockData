
#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using Microsoft.Data.SqlClient;
using ObjectLibrary.BusinessObjects;
using System;
using System.Data;

#endregion

namespace DataAccessComponent.Data.Writers
{

    #region class DoNotTrackWriter
    /// <summary>
    /// This class is used for converting a 'DoNotTrack' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class DoNotTrackWriter : DoNotTrackWriterBase
    {

        #region Static Methods

            #region CreateFindDoNotTrackStoredProcedure(DoNotTrack doNotTrack)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindDoNotTrackStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DoNotTrack_Find'.
            /// </summary>
            /// <param name="doNotTrack">The 'DoNotTrack' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static new FindDoNotTrackStoredProcedure CreateFindDoNotTrackStoredProcedure(DoNotTrack doNotTrack)
            {
                // Initial Value
                FindDoNotTrackStoredProcedure findDoNotTrackStoredProcedure = null;

                // verify doNotTrack exists
                if(doNotTrack != null)
                {
                    // Instanciate findDoNotTrackStoredProcedure
                    findDoNotTrackStoredProcedure = new FindDoNotTrackStoredProcedure();

                    // if doNotTrack.FindBySymbol is true
                    if (doNotTrack.FindBySymbol)
                    {
                            // Change the procedure name
                            findDoNotTrackStoredProcedure.ProcedureName = "DoNotTrack_FindBySymbol";
                            
                            // Create the @Symbol parameter
                            findDoNotTrackStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@Symbol", doNotTrack.Symbol);
                    }
                    else
                    {
                        // Now create parameters for this procedure
                        findDoNotTrackStoredProcedure.Parameters = CreatePrimaryKeyParameter(doNotTrack);
                    }
                }

                // return value
                return findDoNotTrackStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
