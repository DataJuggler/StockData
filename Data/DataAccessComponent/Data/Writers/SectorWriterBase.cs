

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

    #region class SectorWriterBase
    /// <summary>
    /// This class is used for converting a 'Sector' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class SectorWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(Sector sector)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='sector'>The 'Sector' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(Sector sector)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (sector != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", sector.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteSectorStoredProcedure(Sector sector)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteSector'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Sector_Delete'.
            /// </summary>
            /// <param name="sector">The 'Sector' to Delete.</param>
            /// <returns>An instance of a 'DeleteSectorStoredProcedure' object.</returns>
            public static DeleteSectorStoredProcedure CreateDeleteSectorStoredProcedure(Sector sector)
            {
                // Initial Value
                DeleteSectorStoredProcedure deleteSectorStoredProcedure = new DeleteSectorStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteSectorStoredProcedure.Parameters = CreatePrimaryKeyParameter(sector);

                // return value
                return deleteSectorStoredProcedure;
            }
            #endregion

            #region CreateFindSectorStoredProcedure(Sector sector)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindSectorStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Sector_Find'.
            /// </summary>
            /// <param name="sector">The 'Sector' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindSectorStoredProcedure CreateFindSectorStoredProcedure(Sector sector)
            {
                // Initial Value
                FindSectorStoredProcedure findSectorStoredProcedure = null;

                // verify sector exists
                if(sector != null)
                {
                    // Instanciate findSectorStoredProcedure
                    findSectorStoredProcedure = new FindSectorStoredProcedure();

                    // Now create parameters for this procedure
                    findSectorStoredProcedure.Parameters = CreatePrimaryKeyParameter(sector);
                }

                // return value
                return findSectorStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(Sector sector)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new sector.
            /// </summary>
            /// <param name="sector">The 'Sector' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(Sector sector)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[8];
                SqlParameter param = null;

                // verify sectorexists
                if(sector != null)
                {
                    // Create [Advancers] parameter
                    param = new SqlParameter("@Advancers", sector.Advancers);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [AveragePercentChange] parameter
                    param = new SqlParameter("@AveragePercentChange", sector.AveragePercentChange);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [Decliners] parameter
                    param = new SqlParameter("@Decliners", sector.Decliners);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [LastUpdated] Parameter
                    param = new SqlParameter("@LastUpdated", SqlDbType.DateTime);

                    // If sector.LastUpdated does not exist.
                    if (sector.LastUpdated.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = sector.LastUpdated;
                    }
                    // set parameters[3]
                    parameters[3] = param;

                    // Create [Name] parameter
                    param = new SqlParameter("@Name", sector.Name);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [NumberStocks] parameter
                    param = new SqlParameter("@NumberStocks", sector.NumberStocks);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [Score] parameter
                    param = new SqlParameter("@Score", sector.Score);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create [Streak] parameter
                    param = new SqlParameter("@Streak", sector.Streak);

                    // set parameters[7]
                    parameters[7] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertSectorStoredProcedure(Sector sector)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertSectorStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Sector_Insert'.
            /// </summary>
            /// <param name="sector"The 'Sector' object to insert</param>
            /// <returns>An instance of a 'InsertSectorStoredProcedure' object.</returns>
            public static InsertSectorStoredProcedure CreateInsertSectorStoredProcedure(Sector sector)
            {
                // Initial Value
                InsertSectorStoredProcedure insertSectorStoredProcedure = null;

                // verify sector exists
                if(sector != null)
                {
                    // Instanciate insertSectorStoredProcedure
                    insertSectorStoredProcedure = new InsertSectorStoredProcedure();

                    // Now create parameters for this procedure
                    insertSectorStoredProcedure.Parameters = CreateInsertParameters(sector);
                }

                // return value
                return insertSectorStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(Sector sector)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing sector.
            /// </summary>
            /// <param name="sector">The 'Sector' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(Sector sector)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[9];
                SqlParameter param = null;

                // verify sectorexists
                if(sector != null)
                {
                    // Create parameter for [Advancers]
                    param = new SqlParameter("@Advancers", sector.Advancers);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [AveragePercentChange]
                    param = new SqlParameter("@AveragePercentChange", sector.AveragePercentChange);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [Decliners]
                    param = new SqlParameter("@Decliners", sector.Decliners);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [LastUpdated]
                    // Create [LastUpdated] Parameter
                    param = new SqlParameter("@LastUpdated", SqlDbType.DateTime);

                    // If sector.LastUpdated does not exist.
                    if (sector.LastUpdated.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = sector.LastUpdated;
                    }

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [Name]
                    param = new SqlParameter("@Name", sector.Name);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [NumberStocks]
                    param = new SqlParameter("@NumberStocks", sector.NumberStocks);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [Score]
                    param = new SqlParameter("@Score", sector.Score);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [Streak]
                    param = new SqlParameter("@Streak", sector.Streak);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", sector.Id);
                    parameters[8] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateSectorStoredProcedure(Sector sector)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateSectorStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Sector_Update'.
            /// </summary>
            /// <param name="sector"The 'Sector' object to update</param>
            /// <returns>An instance of a 'UpdateSectorStoredProcedure</returns>
            public static UpdateSectorStoredProcedure CreateUpdateSectorStoredProcedure(Sector sector)
            {
                // Initial Value
                UpdateSectorStoredProcedure updateSectorStoredProcedure = null;

                // verify sector exists
                if(sector != null)
                {
                    // Instanciate updateSectorStoredProcedure
                    updateSectorStoredProcedure = new UpdateSectorStoredProcedure();

                    // Now create parameters for this procedure
                    updateSectorStoredProcedure.Parameters = CreateUpdateParameters(sector);
                }

                // return value
                return updateSectorStoredProcedure;
            }
            #endregion

            #region CreateFetchAllSectorsStoredProcedure(Sector sector)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllSectorsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Sector_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllSectorsStoredProcedure' object.</returns>
            public static FetchAllSectorsStoredProcedure CreateFetchAllSectorsStoredProcedure(Sector sector)
            {
                // Initial value
                FetchAllSectorsStoredProcedure fetchAllSectorsStoredProcedure = new FetchAllSectorsStoredProcedure();

                // return value
                return fetchAllSectorsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
