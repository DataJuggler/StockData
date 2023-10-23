

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


namespace DataAccessComponent.DataManager.Writers
{

    #region class DoNotTrackWriterBase
    /// <summary>
    /// This class is used for converting a 'DoNotTrack' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class DoNotTrackWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(DoNotTrack doNotTrack)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='doNotTrack'>The 'DoNotTrack' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(DoNotTrack doNotTrack)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (doNotTrack != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", doNotTrack.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteDoNotTrackStoredProcedure(DoNotTrack doNotTrack)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteDoNotTrack'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DoNotTrack_Delete'.
            /// </summary>
            /// <param name="doNotTrack">The 'DoNotTrack' to Delete.</param>
            /// <returns>An instance of a 'DeleteDoNotTrackStoredProcedure' object.</returns>
            public static DeleteDoNotTrackStoredProcedure CreateDeleteDoNotTrackStoredProcedure(DoNotTrack doNotTrack)
            {
                // Initial Value
                DeleteDoNotTrackStoredProcedure deleteDoNotTrackStoredProcedure = new DeleteDoNotTrackStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteDoNotTrackStoredProcedure.Parameters = CreatePrimaryKeyParameter(doNotTrack);

                // return value
                return deleteDoNotTrackStoredProcedure;
            }
            #endregion

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
            public static FindDoNotTrackStoredProcedure CreateFindDoNotTrackStoredProcedure(DoNotTrack doNotTrack)
            {
                // Initial Value
                FindDoNotTrackStoredProcedure findDoNotTrackStoredProcedure = null;

                // verify doNotTrack exists
                if(doNotTrack != null)
                {
                    // Instanciate findDoNotTrackStoredProcedure
                    findDoNotTrackStoredProcedure = new FindDoNotTrackStoredProcedure();

                    // Now create parameters for this procedure
                    findDoNotTrackStoredProcedure.Parameters = CreatePrimaryKeyParameter(doNotTrack);
                }

                // return value
                return findDoNotTrackStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(DoNotTrack doNotTrack)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new doNotTrack.
            /// </summary>
            /// <param name="doNotTrack">The 'DoNotTrack' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(DoNotTrack doNotTrack)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[1];
                SqlParameter param = null;

                // verify doNotTrackexists
                if(doNotTrack != null)
                {
                    // Create [Symbol] parameter
                    param = new SqlParameter("@Symbol", doNotTrack.Symbol);

                    // set parameters[0]
                    parameters[0] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertDoNotTrackStoredProcedure(DoNotTrack doNotTrack)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertDoNotTrackStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DoNotTrack_Insert'.
            /// </summary>
            /// <param name="doNotTrack"The 'DoNotTrack' object to insert</param>
            /// <returns>An instance of a 'InsertDoNotTrackStoredProcedure' object.</returns>
            public static InsertDoNotTrackStoredProcedure CreateInsertDoNotTrackStoredProcedure(DoNotTrack doNotTrack)
            {
                // Initial Value
                InsertDoNotTrackStoredProcedure insertDoNotTrackStoredProcedure = null;

                // verify doNotTrack exists
                if(doNotTrack != null)
                {
                    // Instanciate insertDoNotTrackStoredProcedure
                    insertDoNotTrackStoredProcedure = new InsertDoNotTrackStoredProcedure();

                    // Now create parameters for this procedure
                    insertDoNotTrackStoredProcedure.Parameters = CreateInsertParameters(doNotTrack);
                }

                // return value
                return insertDoNotTrackStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(DoNotTrack doNotTrack)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing doNotTrack.
            /// </summary>
            /// <param name="doNotTrack">The 'DoNotTrack' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(DoNotTrack doNotTrack)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[2];
                SqlParameter param = null;

                // verify doNotTrackexists
                if(doNotTrack != null)
                {
                    // Create parameter for [Symbol]
                    param = new SqlParameter("@Symbol", doNotTrack.Symbol);

                    // set parameters[0]
                    parameters[0] = param;
                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", doNotTrack.Id);
                    parameters[1] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateDoNotTrackStoredProcedure(DoNotTrack doNotTrack)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateDoNotTrackStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DoNotTrack_Update'.
            /// </summary>
            /// <param name="doNotTrack"The 'DoNotTrack' object to update</param>
            /// <returns>An instance of a 'UpdateDoNotTrackStoredProcedure</returns>
            public static UpdateDoNotTrackStoredProcedure CreateUpdateDoNotTrackStoredProcedure(DoNotTrack doNotTrack)
            {
                // Initial Value
                UpdateDoNotTrackStoredProcedure updateDoNotTrackStoredProcedure = null;

                // verify doNotTrack exists
                if(doNotTrack != null)
                {
                    // Instanciate updateDoNotTrackStoredProcedure
                    updateDoNotTrackStoredProcedure = new UpdateDoNotTrackStoredProcedure();

                    // Now create parameters for this procedure
                    updateDoNotTrackStoredProcedure.Parameters = CreateUpdateParameters(doNotTrack);
                }

                // return value
                return updateDoNotTrackStoredProcedure;
            }
            #endregion

            #region CreateFetchAllDoNotTracksStoredProcedure(DoNotTrack doNotTrack)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllDoNotTracksStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'DoNotTrack_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllDoNotTracksStoredProcedure' object.</returns>
            public static FetchAllDoNotTracksStoredProcedure CreateFetchAllDoNotTracksStoredProcedure(DoNotTrack doNotTrack)
            {
                // Initial value
                FetchAllDoNotTracksStoredProcedure fetchAllDoNotTracksStoredProcedure = new FetchAllDoNotTracksStoredProcedure();

                // return value
                return fetchAllDoNotTracksStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
