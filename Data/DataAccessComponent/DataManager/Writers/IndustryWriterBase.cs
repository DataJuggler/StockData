

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

    #region class IndustryWriterBase
    /// <summary>
    /// This class is used for converting a 'Industry' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class IndustryWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(Industry industry)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='industry'>The 'Industry' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(Industry industry)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (industry != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", industry.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteIndustryStoredProcedure(Industry industry)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteIndustry'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Industry_Delete'.
            /// </summary>
            /// <param name="industry">The 'Industry' to Delete.</param>
            /// <returns>An instance of a 'DeleteIndustryStoredProcedure' object.</returns>
            public static DeleteIndustryStoredProcedure CreateDeleteIndustryStoredProcedure(Industry industry)
            {
                // Initial Value
                DeleteIndustryStoredProcedure deleteIndustryStoredProcedure = new DeleteIndustryStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteIndustryStoredProcedure.Parameters = CreatePrimaryKeyParameter(industry);

                // return value
                return deleteIndustryStoredProcedure;
            }
            #endregion

            #region CreateFindIndustryStoredProcedure(Industry industry)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindIndustryStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Industry_Find'.
            /// </summary>
            /// <param name="industry">The 'Industry' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindIndustryStoredProcedure CreateFindIndustryStoredProcedure(Industry industry)
            {
                // Initial Value
                FindIndustryStoredProcedure findIndustryStoredProcedure = null;

                // verify industry exists
                if(industry != null)
                {
                    // Instanciate findIndustryStoredProcedure
                    findIndustryStoredProcedure = new FindIndustryStoredProcedure();

                    // Now create parameters for this procedure
                    findIndustryStoredProcedure.Parameters = CreatePrimaryKeyParameter(industry);
                }

                // return value
                return findIndustryStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(Industry industry)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new industry.
            /// </summary>
            /// <param name="industry">The 'Industry' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(Industry industry)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[8];
                SqlParameter param = null;

                // verify industryexists
                if(industry != null)
                {
                    // Create [Advancers] parameter
                    param = new SqlParameter("@Advancers", industry.Advancers);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [AveragePercentChange] parameter
                    param = new SqlParameter("@AveragePercentChange", industry.AveragePercentChange);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [Decliners] parameter
                    param = new SqlParameter("@Decliners", industry.Decliners);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [LastUpdated] Parameter
                    param = new SqlParameter("@LastUpdated", SqlDbType.DateTime);

                    // If industry.LastUpdated does not exist.
                    if (industry.LastUpdated.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = industry.LastUpdated;
                    }
                    // set parameters[3]
                    parameters[3] = param;

                    // Create [Name] parameter
                    param = new SqlParameter("@Name", industry.Name);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [NumberStocks] parameter
                    param = new SqlParameter("@NumberStocks", industry.NumberStocks);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [Score] parameter
                    param = new SqlParameter("@Score", industry.Score);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create [Streak] parameter
                    param = new SqlParameter("@Streak", industry.Streak);

                    // set parameters[7]
                    parameters[7] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertIndustryStoredProcedure(Industry industry)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertIndustryStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Industry_Insert'.
            /// </summary>
            /// <param name="industry"The 'Industry' object to insert</param>
            /// <returns>An instance of a 'InsertIndustryStoredProcedure' object.</returns>
            public static InsertIndustryStoredProcedure CreateInsertIndustryStoredProcedure(Industry industry)
            {
                // Initial Value
                InsertIndustryStoredProcedure insertIndustryStoredProcedure = null;

                // verify industry exists
                if(industry != null)
                {
                    // Instanciate insertIndustryStoredProcedure
                    insertIndustryStoredProcedure = new InsertIndustryStoredProcedure();

                    // Now create parameters for this procedure
                    insertIndustryStoredProcedure.Parameters = CreateInsertParameters(industry);
                }

                // return value
                return insertIndustryStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(Industry industry)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing industry.
            /// </summary>
            /// <param name="industry">The 'Industry' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(Industry industry)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[9];
                SqlParameter param = null;

                // verify industryexists
                if(industry != null)
                {
                    // Create parameter for [Advancers]
                    param = new SqlParameter("@Advancers", industry.Advancers);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [AveragePercentChange]
                    param = new SqlParameter("@AveragePercentChange", industry.AveragePercentChange);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [Decliners]
                    param = new SqlParameter("@Decliners", industry.Decliners);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [LastUpdated]
                    // Create [LastUpdated] Parameter
                    param = new SqlParameter("@LastUpdated", SqlDbType.DateTime);

                    // If industry.LastUpdated does not exist.
                    if (industry.LastUpdated.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = industry.LastUpdated;
                    }

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [Name]
                    param = new SqlParameter("@Name", industry.Name);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [NumberStocks]
                    param = new SqlParameter("@NumberStocks", industry.NumberStocks);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [Score]
                    param = new SqlParameter("@Score", industry.Score);

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [Streak]
                    param = new SqlParameter("@Streak", industry.Streak);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", industry.Id);
                    parameters[8] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateIndustryStoredProcedure(Industry industry)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateIndustryStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Industry_Update'.
            /// </summary>
            /// <param name="industry"The 'Industry' object to update</param>
            /// <returns>An instance of a 'UpdateIndustryStoredProcedure</returns>
            public static UpdateIndustryStoredProcedure CreateUpdateIndustryStoredProcedure(Industry industry)
            {
                // Initial Value
                UpdateIndustryStoredProcedure updateIndustryStoredProcedure = null;

                // verify industry exists
                if(industry != null)
                {
                    // Instanciate updateIndustryStoredProcedure
                    updateIndustryStoredProcedure = new UpdateIndustryStoredProcedure();

                    // Now create parameters for this procedure
                    updateIndustryStoredProcedure.Parameters = CreateUpdateParameters(industry);
                }

                // return value
                return updateIndustryStoredProcedure;
            }
            #endregion

            #region CreateFetchAllIndustrysStoredProcedure(Industry industry)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllIndustrysStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Industry_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllIndustrysStoredProcedure' object.</returns>
            public static FetchAllIndustrysStoredProcedure CreateFetchAllIndustrysStoredProcedure(Industry industry)
            {
                // Initial value
                FetchAllIndustrysStoredProcedure fetchAllIndustrysStoredProcedure = new FetchAllIndustrysStoredProcedure();

                // return value
                return fetchAllIndustrysStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
