

#region using statements

using ApplicationLogicComponent.DataBridge;
using DataAccessComponent.DataManager;
using DataAccessComponent.DataManager.Writers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.DataOperations
{

    #region class RecommendationLogMethods
    /// <summary>
    /// This class contains methods for modifying a 'RecommendationLog' object.
    /// </summary>
    public class RecommendationLogMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'RecommendationLogMethods' object.
        /// </summary>
        public RecommendationLogMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteRecommendationLog(RecommendationLog)
            /// <summary>
            /// This method deletes a 'RecommendationLog' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'RecommendationLog' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteRecommendationLog(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteRecommendationLogStoredProcedure deleteRecommendationLogProc = null;

                    // verify the first parameters is a(n) 'RecommendationLog'.
                    if (parameters[0].ObjectValue as RecommendationLog != null)
                    {
                        // Create RecommendationLog
                        RecommendationLog recommendationLog = (RecommendationLog) parameters[0].ObjectValue;

                        // verify recommendationLog exists
                        if(recommendationLog != null)
                        {
                            // Now create deleteRecommendationLogProc from RecommendationLogWriter
                            // The DataWriter converts the 'RecommendationLog'
                            // to the SqlParameter[] array needed to delete a 'RecommendationLog'.
                            deleteRecommendationLogProc = RecommendationLogWriter.CreateDeleteRecommendationLogStoredProcedure(recommendationLog);
                        }
                    }

                    // Verify deleteRecommendationLogProc exists
                    if(deleteRecommendationLogProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.RecommendationLogManager.DeleteRecommendationLog(deleteRecommendationLogProc, dataConnector);

                        // Create returnObject.Boolean
                        returnObject.Boolean = new NullableBoolean();

                        // If delete was successful
                        if(deleted)
                        {
                            // Set returnObject.Boolean.Value to true
                            returnObject.Boolean.Value = NullableBooleanEnum.True;
                        }
                        else
                        {
                            // Set returnObject.Boolean.Value to false
                            returnObject.Boolean.Value = NullableBooleanEnum.False;
                        }
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'RecommendationLog' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'RecommendationLog' to delete.
            /// <returns>A PolymorphicObject object with all  'RecommendationLogs' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<RecommendationLog> recommendationLogListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllRecommendationLogsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get RecommendationLogParameter
                    // Declare Parameter
                    RecommendationLog paramRecommendationLog = null;

                    // verify the first parameters is a(n) 'RecommendationLog'.
                    if (parameters[0].ObjectValue as RecommendationLog != null)
                    {
                        // Get RecommendationLogParameter
                        paramRecommendationLog = (RecommendationLog) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllRecommendationLogsProc from RecommendationLogWriter
                    fetchAllProc = RecommendationLogWriter.CreateFetchAllRecommendationLogsStoredProcedure(paramRecommendationLog);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    recommendationLogListCollection = this.DataManager.RecommendationLogManager.FetchAllRecommendationLogs(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(recommendationLogListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = recommendationLogListCollection;
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FindRecommendationLog(RecommendationLog)
            /// <summary>
            /// This method finds a 'RecommendationLog' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'RecommendationLog' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindRecommendationLog(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                RecommendationLog recommendationLog = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindRecommendationLogStoredProcedure findRecommendationLogProc = null;

                    // verify the first parameters is a 'RecommendationLog'.
                    if (parameters[0].ObjectValue as RecommendationLog != null)
                    {
                        // Get RecommendationLogParameter
                        RecommendationLog paramRecommendationLog = (RecommendationLog) parameters[0].ObjectValue;

                        // verify paramRecommendationLog exists
                        if(paramRecommendationLog != null)
                        {
                            // Now create findRecommendationLogProc from RecommendationLogWriter
                            // The DataWriter converts the 'RecommendationLog'
                            // to the SqlParameter[] array needed to find a 'RecommendationLog'.
                            findRecommendationLogProc = RecommendationLogWriter.CreateFindRecommendationLogStoredProcedure(paramRecommendationLog);
                        }

                        // Verify findRecommendationLogProc exists
                        if(findRecommendationLogProc != null)
                        {
                            // Execute Find Stored Procedure
                            recommendationLog = this.DataManager.RecommendationLogManager.FindRecommendationLog(findRecommendationLogProc, dataConnector);

                            // if dataObject exists
                            if(recommendationLog != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = recommendationLog;
                            }
                        }
                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region InsertRecommendationLog (RecommendationLog)
            /// <summary>
            /// This method inserts a 'RecommendationLog' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'RecommendationLog' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertRecommendationLog(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                RecommendationLog recommendationLog = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertRecommendationLogStoredProcedure insertRecommendationLogProc = null;

                    // verify the first parameters is a(n) 'RecommendationLog'.
                    if (parameters[0].ObjectValue as RecommendationLog != null)
                    {
                        // Create RecommendationLog Parameter
                        recommendationLog = (RecommendationLog) parameters[0].ObjectValue;

                        // verify recommendationLog exists
                        if(recommendationLog != null)
                        {
                            // Now create insertRecommendationLogProc from RecommendationLogWriter
                            // The DataWriter converts the 'RecommendationLog'
                            // to the SqlParameter[] array needed to insert a 'RecommendationLog'.
                            insertRecommendationLogProc = RecommendationLogWriter.CreateInsertRecommendationLogStoredProcedure(recommendationLog);
                        }

                        // Verify insertRecommendationLogProc exists
                        if(insertRecommendationLogProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.RecommendationLogManager.InsertRecommendationLog(insertRecommendationLogProc, dataConnector);
                        }

                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region UpdateRecommendationLog (RecommendationLog)
            /// <summary>
            /// This method updates a 'RecommendationLog' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'RecommendationLog' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateRecommendationLog(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                RecommendationLog recommendationLog = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateRecommendationLogStoredProcedure updateRecommendationLogProc = null;

                    // verify the first parameters is a(n) 'RecommendationLog'.
                    if (parameters[0].ObjectValue as RecommendationLog != null)
                    {
                        // Create RecommendationLog Parameter
                        recommendationLog = (RecommendationLog) parameters[0].ObjectValue;

                        // verify recommendationLog exists
                        if(recommendationLog != null)
                        {
                            // Now create updateRecommendationLogProc from RecommendationLogWriter
                            // The DataWriter converts the 'RecommendationLog'
                            // to the SqlParameter[] array needed to update a 'RecommendationLog'.
                            updateRecommendationLogProc = RecommendationLogWriter.CreateUpdateRecommendationLogStoredProcedure(recommendationLog);
                        }

                        // Verify updateRecommendationLogProc exists
                        if(updateRecommendationLogProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.RecommendationLogManager.UpdateRecommendationLog(updateRecommendationLogProc, dataConnector);

                            // Create returnObject.Boolean
                            returnObject.Boolean = new NullableBoolean();

                            // If save was successful
                            if(saved)
                            {
                                // Set returnObject.Boolean.Value to true
                                returnObject.Boolean.Value = NullableBooleanEnum.True;
                            }
                            else
                            {
                                // Set returnObject.Boolean.Value to false
                                returnObject.Boolean.Value = NullableBooleanEnum.False;
                            }
                        }
                        else
                        {
                            // Raise Error Data Connection Not Available
                            throw new Exception("The database connection is not available.");
                        }
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

        #endregion

        #region Properties

            #region DataManager 
            public DataManager DataManager 
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
