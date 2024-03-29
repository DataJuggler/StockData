
#region using statements

using ApplicationLogicComponent.Controllers;
using ApplicationLogicComponent.DataOperations;
using DataAccessComponent.DataManager;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

#endregion

namespace DataGateway
{

    #region class Gateway
    /// <summary>
    /// This class is used to manage DataOperations
    /// between the client and the DataAccessComponent.
    /// Do not change the method name or the parameters for the
    /// code generated methods or they will be recreated the next 
    /// time you code generate with DataTier.Net. If you need additional
    /// parameters passed to a method either create an override or
    /// add or set properties to the temp object that is passed in.
    /// </summary>
    public class Gateway
    {

        #region Private Variables
        private ApplicationController appController;
        private string connectionName;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a Gateway object.
        /// </summary>
        public Gateway(string connectionName = "")
        {
            // store the ConnectionName
            this.ConnectionName = connectionName;

            // Perform Initializations for this object
            Init();
        }
        #endregion

        #region Methods
        
            #region DeleteAdmin(int id, Admin tempAdmin = null)
            /// <summary>
            /// This method is used to delete Admin objects.
            /// </summary>
            /// <param name="id">Delete the Admin with this id</param>
            /// <param name="tempAdmin">Pass in a tempAdmin to perform a custom delete.</param>
            public bool DeleteAdmin(int id, Admin tempAdmin = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempAdmin does not exist
                    if (tempAdmin == null)
                    {
                        // create a temp Admin
                        tempAdmin = new Admin();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempAdmin.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.AdminController.Delete(tempAdmin);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteDailyPriceData(int id, DailyPriceData tempDailyPriceData = null)
            /// <summary>
            /// This method is used to delete DailyPriceData objects.
            /// </summary>
            /// <param name="id">Delete the DailyPriceData with this id</param>
            /// <param name="tempDailyPriceData">Pass in a tempDailyPriceData to perform a custom delete.</param>
            public bool DeleteDailyPriceData(int id, DailyPriceData tempDailyPriceData = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempDailyPriceData does not exist
                    if (tempDailyPriceData == null)
                    {
                        // create a temp DailyPriceData
                        tempDailyPriceData = new DailyPriceData();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempDailyPriceData.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.DailyPriceDataController.Delete(tempDailyPriceData);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteDoNotTrack(int id, DoNotTrack tempDoNotTrack = null)
            /// <summary>
            /// This method is used to delete DoNotTrack objects.
            /// </summary>
            /// <param name="id">Delete the DoNotTrack with this id</param>
            /// <param name="tempDoNotTrack">Pass in a tempDoNotTrack to perform a custom delete.</param>
            public bool DeleteDoNotTrack(int id, DoNotTrack tempDoNotTrack = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempDoNotTrack does not exist
                    if (tempDoNotTrack == null)
                    {
                        // create a temp DoNotTrack
                        tempDoNotTrack = new DoNotTrack();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempDoNotTrack.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.DoNotTrackController.Delete(tempDoNotTrack);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteIndustry(int id, Industry tempIndustry = null)
            /// <summary>
            /// This method is used to delete Industry objects.
            /// </summary>
            /// <param name="id">Delete the Industry with this id</param>
            /// <param name="tempIndustry">Pass in a tempIndustry to perform a custom delete.</param>
            public bool DeleteIndustry(int id, Industry tempIndustry = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempIndustry does not exist
                    if (tempIndustry == null)
                    {
                        // create a temp Industry
                        tempIndustry = new Industry();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempIndustry.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.IndustryController.Delete(tempIndustry);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteIndustryHistory(int id, IndustryHistory tempIndustryHistory = null)
            /// <summary>
            /// This method is used to delete IndustryHistory objects.
            /// </summary>
            /// <param name="id">Delete the IndustryHistory with this id</param>
            /// <param name="tempIndustryHistory">Pass in a tempIndustryHistory to perform a custom delete.</param>
            public bool DeleteIndustryHistory(int id, IndustryHistory tempIndustryHistory = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempIndustryHistory does not exist
                    if (tempIndustryHistory == null)
                    {
                        // create a temp IndustryHistory
                        tempIndustryHistory = new IndustryHistory();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempIndustryHistory.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.IndustryHistoryController.Delete(tempIndustryHistory);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteRecommendationLog(int id, RecommendationLog tempRecommendationLog = null)
            /// <summary>
            /// This method is used to delete RecommendationLog objects.
            /// </summary>
            /// <param name="id">Delete the RecommendationLog with this id</param>
            /// <param name="tempRecommendationLog">Pass in a tempRecommendationLog to perform a custom delete.</param>
            public bool DeleteRecommendationLog(int id, RecommendationLog tempRecommendationLog = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempRecommendationLog does not exist
                    if (tempRecommendationLog == null)
                    {
                        // create a temp RecommendationLog
                        tempRecommendationLog = new RecommendationLog();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempRecommendationLog.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.RecommendationLogController.Delete(tempRecommendationLog);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteSector(int id, Sector tempSector = null)
            /// <summary>
            /// This method is used to delete Sector objects.
            /// </summary>
            /// <param name="id">Delete the Sector with this id</param>
            /// <param name="tempSector">Pass in a tempSector to perform a custom delete.</param>
            public bool DeleteSector(int id, Sector tempSector = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempSector does not exist
                    if (tempSector == null)
                    {
                        // create a temp Sector
                        tempSector = new Sector();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempSector.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.SectorController.Delete(tempSector);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteSectorHistory(int id, SectorHistory tempSectorHistory = null)
            /// <summary>
            /// This method is used to delete SectorHistory objects.
            /// </summary>
            /// <param name="id">Delete the SectorHistory with this id</param>
            /// <param name="tempSectorHistory">Pass in a tempSectorHistory to perform a custom delete.</param>
            public bool DeleteSectorHistory(int id, SectorHistory tempSectorHistory = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempSectorHistory does not exist
                    if (tempSectorHistory == null)
                    {
                        // create a temp SectorHistory
                        tempSectorHistory = new SectorHistory();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempSectorHistory.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.SectorHistoryController.Delete(tempSectorHistory);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteStock(int id, Stock tempStock = null)
            /// <summary>
            /// This method is used to delete Stock objects.
            /// </summary>
            /// <param name="id">Delete the Stock with this id</param>
            /// <param name="tempStock">Pass in a tempStock to perform a custom delete.</param>
            public bool DeleteStock(int id, Stock tempStock = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempStock does not exist
                    if (tempStock == null)
                    {
                        // create a temp Stock
                        tempStock = new Stock();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempStock.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.StockController.Delete(tempStock);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteStockDay(int id, StockDay tempStockDay = null)
            /// <summary>
            /// This method is used to delete StockDay objects.
            /// </summary>
            /// <param name="id">Delete the StockDay with this id</param>
            /// <param name="tempStockDay">Pass in a tempStockDay to perform a custom delete.</param>
            public bool DeleteStockDay(int id, StockDay tempStockDay = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempStockDay does not exist
                    if (tempStockDay == null)
                    {
                        // create a temp StockDay
                        tempStockDay = new StockDay();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempStockDay.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.StockDayController.Delete(tempStockDay);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteStockStreak(int id, StockStreak tempStockStreak = null)
            /// <summary>
            /// This method is used to delete StockStreak objects.
            /// </summary>
            /// <param name="id">Delete the StockStreak with this id</param>
            /// <param name="tempStockStreak">Pass in a tempStockStreak to perform a custom delete.</param>
            public bool DeleteStockStreak(int id, StockStreak tempStockStreak = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempStockStreak does not exist
                    if (tempStockStreak == null)
                    {
                        // create a temp StockStreak
                        tempStockStreak = new StockStreak();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempStockStreak.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.StockStreakController.Delete(tempStockStreak);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region ExecuteNonQuery(string procedureName, SqlParameter[] sqlParameters)
            /// <summary>
            /// This method Executes a Non Query StoredProcedure
            /// </summary>
            public PolymorphicObject ExecuteNonQuery(string procedureName, SqlParameter[] sqlParameters)
            {
                // initial value
                PolymorphicObject returnValue = new PolymorphicObject();

                // locals
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // create the parameters
                PolymorphicObject procedureNameParameter = new PolymorphicObject();
                PolymorphicObject sqlParametersParameter = new PolymorphicObject();

                // if the procedureName exists
                if (!String.IsNullOrEmpty(procedureName))
                {
                    // Create an instance of the SystemMethods object
                    SystemMethods systemMethods = new SystemMethods();

                    // setup procedureNameParameter
                    procedureNameParameter.Name = "ProcedureName";
                    procedureNameParameter.Text = procedureName;

                    // setup sqlParametersParameter
                    sqlParametersParameter.Name = "SqlParameters";
                    sqlParametersParameter.ObjectValue = sqlParameters;

                    // Add these parameters to the parameters
                    parameters.Add(procedureNameParameter);
                    parameters.Add(sqlParametersParameter);

                    // get the dataConnector
                    DataAccessComponent.DataManager.DataConnector dataConnector = GetDataConnector();

                    // Execute the query
                    returnValue = systemMethods.ExecuteNonQuery(parameters, dataConnector);
                }

                // return value
                return returnValue;
            }
            #endregion

            #region FindAdmin(int id, Admin tempAdmin = null)
            /// <summary>
            /// This method is used to find 'Admin' objects.
            /// </summary>
            /// <param name="id">Find the Admin with this id</param>
            /// <param name="tempAdmin">Pass in a tempAdmin to perform a custom find.</param>
            public Admin FindAdmin(int id, Admin tempAdmin = null)
            {
                // initial value
                Admin admin = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempAdmin does not exist
                    if (tempAdmin == null)
                    {
                        // create a temp Admin
                        tempAdmin = new Admin();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempAdmin.UpdateIdentity(id);
                    }

                    // perform the find
                    admin = this.AppController.ControllerManager.AdminController.Find(tempAdmin);
                }

                // return value
                return admin;
            }
            #endregion

            #region FindDailyPriceData(int id, DailyPriceData tempDailyPriceData = null)
            /// <summary>
            /// This method is used to find 'DailyPriceData' objects.
            /// </summary>
            /// <param name="id">Find the DailyPriceData with this id</param>
            /// <param name="tempDailyPriceData">Pass in a tempDailyPriceData to perform a custom find.</param>
            public DailyPriceData FindDailyPriceData(int id, DailyPriceData tempDailyPriceData = null)
            {
                // initial value
                DailyPriceData dailyPriceData = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempDailyPriceData does not exist
                    if (tempDailyPriceData == null)
                    {
                        // create a temp DailyPriceData
                        tempDailyPriceData = new DailyPriceData();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempDailyPriceData.UpdateIdentity(id);
                    }

                    // perform the find
                    dailyPriceData = this.AppController.ControllerManager.DailyPriceDataController.Find(tempDailyPriceData);
                }

                // return value
                return dailyPriceData;
            }
            #endregion

                #region FindDailyPriceDataByStockDateAndSymbol(DateTime stockDate, string symbol)
                /// <summary>
                /// This method is used to find 'DailyPriceData' objects by StockDateAndSymbol
                /// </summary>
                public DailyPriceData FindDailyPriceDataByStockDateAndSymbol(DateTime stockDate, string symbol)
                {
                    // initial value
                    DailyPriceData dailyPriceData = null;
                    
                    // Create a temp DailyPriceData object
                    DailyPriceData tempDailyPriceData = new DailyPriceData();
                    
                    // Set the value for FindByStockDateAndSymbol to true
                    tempDailyPriceData.FindByStockDateAndSymbol = true;
                    
                    // Set the value for StockDate
                    tempDailyPriceData.StockDate = stockDate;
                    
                    // Set the value for Symbol
                    tempDailyPriceData.Symbol = symbol;
                    
                    // Perform the find
                    dailyPriceData = FindDailyPriceData(0, tempDailyPriceData);
                    
                    // return value
                    return dailyPriceData;
                }
                #endregion
                
            #region FindDailyPriceDataBySymbolAndMostRecent(bool mostRecent, string symbol)
            /// <summary>
            /// This method is used to find 'DailyPriceData' objects by SymbolAndMostRecent
            /// </summary>
            public DailyPriceData FindDailyPriceDataBySymbolAndMostRecent(bool mostRecent, string symbol)
            {
                // initial value
                DailyPriceData dailyPriceData = null;
                    
                // Create a temp DailyPriceData object
                DailyPriceData tempDailyPriceData = new DailyPriceData();
                    
                // Set the value for FindBySymbolAndMostRecent to true
                tempDailyPriceData.FindBySymbolAndMostRecent = true;
                    
                // Set the value for MostRecent
                tempDailyPriceData.MostRecent = mostRecent;
                    
                // Set the value for Symbol
                tempDailyPriceData.Symbol = symbol;
                    
                // Perform the find
                dailyPriceData = FindDailyPriceData(0, tempDailyPriceData);
                    
                // return value
                return dailyPriceData;
            }
            #endregion
                
                #region FindDailyPriceDataMaxStreakBySymbol(string symbol)
                /// <summary>
                /// This method is used to find 'DailyPriceData' objects for the Symbol given.
                /// </summary>
                public DailyPriceData FindDailyPriceDataMaxStreakBySymbol(string symbol)
                {
                    // initial value
                    DailyPriceData dailyPriceData = null;
                    
                    // Create a temp DailyPriceData object
                    DailyPriceData tempDailyPriceData = new DailyPriceData();
                    
                    // Set the value for FindMaxStreakBySymbol to true
                    tempDailyPriceData.FindMaxStreakBySymbol = true;
                    
                    // Set the value for Symbol
                    tempDailyPriceData.Symbol = symbol;
                    
                    // Perform the find
                    dailyPriceData = FindDailyPriceData(0, tempDailyPriceData);
                    
                    // return value
                    return dailyPriceData;
                }
                #endregion
                
            #region FindDoNotTrack(int id, DoNotTrack tempDoNotTrack = null)
            /// <summary>
            /// This method is used to find 'DoNotTrack' objects.
            /// </summary>
            /// <param name="id">Find the DoNotTrack with this id</param>
            /// <param name="tempDoNotTrack">Pass in a tempDoNotTrack to perform a custom find.</param>
            public DoNotTrack FindDoNotTrack(int id, DoNotTrack tempDoNotTrack = null)
            {
                // initial value
                DoNotTrack doNotTrack = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempDoNotTrack does not exist
                    if (tempDoNotTrack == null)
                    {
                        // create a temp DoNotTrack
                        tempDoNotTrack = new DoNotTrack();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempDoNotTrack.UpdateIdentity(id);
                    }

                    // perform the find
                    doNotTrack = this.AppController.ControllerManager.DoNotTrackController.Find(tempDoNotTrack);
                }

                // return value
                return doNotTrack;
            }
            #endregion

            #region FindDoNotTrackBySymbol(string symbol)
            /// <summary>
            /// This method is used to find 'DoNotTrack' objects for the Symbol given.
            /// </summary>
            public DoNotTrack FindDoNotTrackBySymbol(string symbol)
            {
                // initial value
                DoNotTrack doNotTrack = null;
                    
                // Create a temp DoNotTrack object
                DoNotTrack tempDoNotTrack = new DoNotTrack();
                    
                // Set the value for FindBySymbol to true
                tempDoNotTrack.FindBySymbol = true;
                    
                // Set the value for Symbol
                tempDoNotTrack.Symbol = symbol;
                    
                // Perform the find
                doNotTrack = FindDoNotTrack(0, tempDoNotTrack);
                    
                // return value
                return doNotTrack;
            }
            #endregion
                
            #region FindIndustry(int id, Industry tempIndustry = null)
            /// <summary>
            /// This method is used to find 'Industry' objects.
            /// </summary>
            /// <param name="id">Find the Industry with this id</param>
            /// <param name="tempIndustry">Pass in a tempIndustry to perform a custom find.</param>
            public Industry FindIndustry(int id, Industry tempIndustry = null)
            {
                // initial value
                Industry industry = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempIndustry does not exist
                    if (tempIndustry == null)
                    {
                        // create a temp Industry
                        tempIndustry = new Industry();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempIndustry.UpdateIdentity(id);
                    }

                    // perform the find
                    industry = this.AppController.ControllerManager.IndustryController.Find(tempIndustry);
                }

                // return value
                return industry;
            }
            #endregion

            #region FindIndustryHistory(int id, IndustryHistory tempIndustryHistory = null)
            /// <summary>
            /// This method is used to find 'IndustryHistory' objects.
            /// </summary>
            /// <param name="id">Find the IndustryHistory with this id</param>
            /// <param name="tempIndustryHistory">Pass in a tempIndustryHistory to perform a custom find.</param>
            public IndustryHistory FindIndustryHistory(int id, IndustryHistory tempIndustryHistory = null)
            {
                // initial value
                IndustryHistory industryHistory = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempIndustryHistory does not exist
                    if (tempIndustryHistory == null)
                    {
                        // create a temp IndustryHistory
                        tempIndustryHistory = new IndustryHistory();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempIndustryHistory.UpdateIdentity(id);
                    }

                    // perform the find
                    industryHistory = this.AppController.ControllerManager.IndustryHistoryController.Find(tempIndustryHistory);
                }

                // return value
                return industryHistory;
            }
            #endregion

            #region FindRecommendationLog(int id, RecommendationLog tempRecommendationLog = null)
            /// <summary>
            /// This method is used to find 'RecommendationLog' objects.
            /// </summary>
            /// <param name="id">Find the RecommendationLog with this id</param>
            /// <param name="tempRecommendationLog">Pass in a tempRecommendationLog to perform a custom find.</param>
            public RecommendationLog FindRecommendationLog(int id, RecommendationLog tempRecommendationLog = null)
            {
                // initial value
                RecommendationLog recommendationLog = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempRecommendationLog does not exist
                    if (tempRecommendationLog == null)
                    {
                        // create a temp RecommendationLog
                        tempRecommendationLog = new RecommendationLog();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempRecommendationLog.UpdateIdentity(id);
                    }

                    // perform the find
                    recommendationLog = this.AppController.ControllerManager.RecommendationLogController.Find(tempRecommendationLog);
                }

                // return value
                return recommendationLog;
            }
            #endregion

            #region FindSector(int id, Sector tempSector = null)
            /// <summary>
            /// This method is used to find 'Sector' objects.
            /// </summary>
            /// <param name="id">Find the Sector with this id</param>
            /// <param name="tempSector">Pass in a tempSector to perform a custom find.</param>
            public Sector FindSector(int id, Sector tempSector = null)
            {
                // initial value
                Sector sector = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempSector does not exist
                    if (tempSector == null)
                    {
                        // create a temp Sector
                        tempSector = new Sector();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempSector.UpdateIdentity(id);
                    }

                    // perform the find
                    sector = this.AppController.ControllerManager.SectorController.Find(tempSector);
                }

                // return value
                return sector;
            }
            #endregion

            #region FindSectorHistory(int id, SectorHistory tempSectorHistory = null)
            /// <summary>
            /// This method is used to find 'SectorHistory' objects.
            /// </summary>
            /// <param name="id">Find the SectorHistory with this id</param>
            /// <param name="tempSectorHistory">Pass in a tempSectorHistory to perform a custom find.</param>
            public SectorHistory FindSectorHistory(int id, SectorHistory tempSectorHistory = null)
            {
                // initial value
                SectorHistory sectorHistory = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempSectorHistory does not exist
                    if (tempSectorHistory == null)
                    {
                        // create a temp SectorHistory
                        tempSectorHistory = new SectorHistory();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempSectorHistory.UpdateIdentity(id);
                    }

                    // perform the find
                    sectorHistory = this.AppController.ControllerManager.SectorHistoryController.Find(tempSectorHistory);
                }

                // return value
                return sectorHistory;
            }
            #endregion

            #region FindStock(int id, Stock tempStock = null)
            /// <summary>
            /// This method is used to find 'Stock' objects.
            /// </summary>
            /// <param name="id">Find the Stock with this id</param>
            /// <param name="tempStock">Pass in a tempStock to perform a custom find.</param>
            public Stock FindStock(int id, Stock tempStock = null)
            {
                // initial value
                Stock stock = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempStock does not exist
                    if (tempStock == null)
                    {
                        // create a temp Stock
                        tempStock = new Stock();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempStock.UpdateIdentity(id);
                    }

                    // perform the find
                    stock = this.AppController.ControllerManager.StockController.Find(tempStock);
                }

                // return value
                return stock;
            }
            #endregion

            #region FindStockBySymbol(string symbol)
            /// <summary>
            /// This method is used to find 'Stock' objects for the Symbol given.
            /// </summary>
            public Stock FindStockBySymbol(string symbol)
            {
                // initial value
                Stock stock = null;
                    
                // Create a temp Stock object
                Stock tempStock = new Stock();
                    
                // Set the value for FindBySymbol to true
                tempStock.FindBySymbol = true;
                    
                // Set the value for Symbol
                tempStock.Symbol = symbol;
                    
                // Perform the find
                stock = FindStock(0, tempStock);
                    
                // return value
                return stock;
            }
            #endregion
                
            #region FindStockDay(int id, StockDay tempStockDay = null)
            /// <summary>
            /// This method is used to find 'StockDay' objects.
            /// </summary>
            /// <param name="id">Find the StockDay with this id</param>
            /// <param name="tempStockDay">Pass in a tempStockDay to perform a custom find.</param>
            public StockDay FindStockDay(int id, StockDay tempStockDay = null)
            {
                // initial value
                StockDay stockDay = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempStockDay does not exist
                    if (tempStockDay == null)
                    {
                        // create a temp StockDay
                        tempStockDay = new StockDay();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempStockDay.UpdateIdentity(id);
                    }

                    // perform the find
                    stockDay = this.AppController.ControllerManager.StockDayController.Find(tempStockDay);
                }

                // return value
                return stockDay;
            }
            #endregion

            #region FindStockStreak(int id, StockStreak tempStockStreak = null)
            /// <summary>
            /// This method is used to find 'StockStreak' objects.
            /// </summary>
            /// <param name="id">Find the StockStreak with this id</param>
            /// <param name="tempStockStreak">Pass in a tempStockStreak to perform a custom find.</param>
            public StockStreak FindStockStreak(int id, StockStreak tempStockStreak = null)
            {
                // initial value
                StockStreak stockStreak = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempStockStreak does not exist
                    if (tempStockStreak == null)
                    {
                        // create a temp StockStreak
                        tempStockStreak = new StockStreak();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempStockStreak.UpdateIdentity(id);
                    }

                    // perform the find
                    stockStreak = this.AppController.ControllerManager.StockStreakController.Find(tempStockStreak);
                }

                // return value
                return stockStreak;
            }
            #endregion
                
            #region FindStockStreakByStockIdAndCurrentStreak(bool currentStreak, int stockId)
            /// <summary>
            /// This method is used to find 'StockStreak' objects by StockIdAndCurrentStreak
            /// </summary>
            public StockStreak FindStockStreakByStockIdAndCurrentStreak(bool currentStreak, int stockId)
            {
                // initial value
                StockStreak stockStreak = null;
                        
                // Create a temp StockStreak object
                StockStreak tempStockStreak = new StockStreak();
                        
                // Set the value for FindByStockIdAndCurrentStreak to true
                tempStockStreak.FindByStockIdAndCurrentStreak = true;
                        
                // Set the value for CurrentStreak
                tempStockStreak.CurrentStreak = currentStreak;
                        
                // Set the value for StockId
                tempStockStreak.StockId = stockId;
                        
                // Perform the find
                stockStreak = FindStockStreak(0, tempStockStreak);
                        
                // return value
                return stockStreak;
            }
            #endregion
                
            #region GetDataConnector()
            /// <summary>
            /// This method (safely) returns the Data Connector from the
            /// AppController.DataBridget.DataManager.DataConnector
            /// </summary>
            private DataConnector GetDataConnector()
            {
                // initial value
                DataConnector dataConnector = null;

                // if the AppController exists
                if (this.AppController != null)
                {
                    // return the DataConnector from the AppController
                    dataConnector = this.AppController.GetDataConnector();
                }

                // return value
                return dataConnector;
            }
            #endregion

            #region GetLastException()
            /// <summary>
            /// This method returns the last Exception from the AppController if one exists.
            /// Always test for null before refeferencing the Exception returned as it will be null 
            /// if no errors were encountered.
            /// </summary>
            /// <returns></returns>
            public Exception GetLastException()
            {
                // initial value
                Exception exception = null;

                // If the AppController object exists
                if (this.HasAppController)
                {
                    // return the Exception from the AppController
                    exception = this.AppController.Exception;

                    // Set to null after the exception is retrieved so it does not return again
                    this.AppController.Exception = null;
                }

                // return value
                return exception;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perform Initializations for this object.
            /// </summary>
            private void Init()
            {
                // Create Application Controller
                this.AppController = new ApplicationController(ConnectionName);
            }
            #endregion

            #region LoadAdmins(Admin tempAdmin = null)
            /// <summary>
            /// This method loads a collection of 'Admin' objects.
            /// </summary>
            public List<Admin> LoadAdmins(Admin tempAdmin = null)
            {
                // initial value
                List<Admin> admins = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    admins = this.AppController.ControllerManager.AdminController.FetchAll(tempAdmin);
                }

                // return value
                return admins;
            }
            #endregion

                #region LoadAllDailyPriceDatasForSymbol(string symbol)
                /// <summary>
                /// This method is used to load 'DailyPriceData' objects for the Symbol given.
                /// </summary>
                public List<DailyPriceData> LoadAllDailyPriceDatasForSymbol(string symbol)
                {
                    // initial value
                    List<DailyPriceData> dailyPriceDatas = null;
                    
                    // Create a temp DailyPriceData object
                    DailyPriceData tempDailyPriceData = new DailyPriceData();
                    
                    // Set the value for LoadCompleteListBySymbol to true
                    tempDailyPriceData.LoadCompleteListBySymbol = true;
                    
                    // Set the value for Symbol
                    tempDailyPriceData.Symbol = symbol;
                    
                    // Perform the load
                    dailyPriceDatas = LoadDailyPriceDatas(tempDailyPriceData);
                    
                    // return value
                    return dailyPriceDatas;
                }
                #endregion
                
            #region LoadDailyPriceDatas(DailyPriceData tempDailyPriceData = null)
            /// <summary>
            /// This method loads a collection of 'DailyPriceData' objects.
            /// </summary>
            public List<DailyPriceData> LoadDailyPriceDatas(DailyPriceData tempDailyPriceData = null)
            {
                // initial value
                List<DailyPriceData> dailyPriceDatas = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    dailyPriceDatas = this.AppController.ControllerManager.DailyPriceDataController.FetchAll(tempDailyPriceData);
                }

                // return value
                return dailyPriceDatas;
            }
            #endregion

            #region LoadDailyPriceDatasForSymbol(string symbol)
            /// <summary>
            /// This method is used to load 'DailyPriceData' objects for the Symbol given.
            /// </summary>
            public List<DailyPriceData> LoadDailyPriceDatasForSymbol(string symbol)
            {
                // initial value
                List<DailyPriceData> dailyPriceDatas = null;
                    
                // Create a temp DailyPriceData object
                DailyPriceData tempDailyPriceData = new DailyPriceData();
                    
                // Set the value for LoadBySymbol to true
                tempDailyPriceData.LoadBySymbol = true;
                    
                // Set the value for Symbol
                tempDailyPriceData.Symbol = symbol;
                    
                // Perform the load
                dailyPriceDatas = LoadDailyPriceDatas(tempDailyPriceData);
                    
                // return value
                return dailyPriceDatas;
            }
            #endregion
                
            #region LoadDailyPriceDataViews(DailyPriceDataView tempDailyPriceDataView = null)
            /// <summary>
            /// This method loads a collection of 'DailyPriceDataView' objects.
            /// </summary>
            public List<DailyPriceDataView> LoadDailyPriceDataViews(DailyPriceDataView tempDailyPriceDataView = null)
            {
                // initial value
                List<DailyPriceDataView> dailyPriceDataViews = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    dailyPriceDataViews = this.AppController.ControllerManager.DailyPriceDataViewController.FetchAll(tempDailyPriceDataView);
                }

                // return value
                return dailyPriceDataViews;
            }
            #endregion

            #region LoadDoNotTracks(DoNotTrack tempDoNotTrack = null)
            /// <summary>
            /// This method loads a collection of 'DoNotTrack' objects.
            /// </summary>
            public List<DoNotTrack> LoadDoNotTracks(DoNotTrack tempDoNotTrack = null)
            {
                // initial value
                List<DoNotTrack> doNotTracks = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    doNotTracks = this.AppController.ControllerManager.DoNotTrackController.FetchAll(tempDoNotTrack);
                }

                // return value
                return doNotTracks;
            }
            #endregion

            #region LoadIndustryHistorys(IndustryHistory tempIndustryHistory = null)
            /// <summary>
            /// This method loads a collection of 'IndustryHistory' objects.
            /// </summary>
            public List<IndustryHistory> LoadIndustryHistorys(IndustryHistory tempIndustryHistory = null)
            {
                // initial value
                List<IndustryHistory> industryHistorys = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    industryHistorys = this.AppController.ControllerManager.IndustryHistoryController.FetchAll(tempIndustryHistory);
                }

                // return value
                return industryHistorys;
            }
            #endregion

            #region LoadIndustryLosingStreakViews(IndustryLosingStreakView tempIndustryLosingStreakView = null)
            /// <summary>
            /// This method loads a collection of 'IndustryLosingStreakView' objects.
            /// </summary>
            public List<IndustryLosingStreakView> LoadIndustryLosingStreakViews(IndustryLosingStreakView tempIndustryLosingStreakView = null)
            {
                // initial value
                List<IndustryLosingStreakView> industryLosingStreakViews = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    industryLosingStreakViews = this.AppController.ControllerManager.IndustryLosingStreakViewController.FetchAll(tempIndustryLosingStreakView);
                }

                // return value
                return industryLosingStreakViews;
            }
            #endregion

            #region LoadIndustrys(Industry tempIndustry = null)
            /// <summary>
            /// This method loads a collection of 'Industry' objects.
            /// </summary>
            public List<Industry> LoadIndustrys(Industry tempIndustry = null)
            {
                // initial value
                List<Industry> industrys = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    industrys = this.AppController.ControllerManager.IndustryController.FetchAll(tempIndustry);
                }

                // return value
                return industrys;
            }
            #endregion

            #region LoadIndustrySummarys(IndustrySummary tempIndustrySummary = null)
            /// <summary>
            /// This method loads a collection of 'IndustrySummary' objects.
            /// </summary>
            public List<IndustrySummary> LoadIndustrySummarys(IndustrySummary tempIndustrySummary = null)
            {
                // initial value
                List<IndustrySummary> industrySummarys = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    industrySummarys = this.AppController.ControllerManager.IndustrySummaryController.FetchAll(tempIndustrySummary);
                }

                // return value
                return industrySummarys;
            }
            #endregion
                
            #region LoadIndustryViews(IndustryView tempIndustryView = null)
            /// <summary>
            /// This method loads a collection of 'IndustryView' objects.
            /// </summary>
            public List<IndustryView> LoadIndustryViews(IndustryView tempIndustryView = null)
            {
                // initial value
                List<IndustryView> industryViews = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    industryViews = this.AppController.ControllerManager.IndustryViewController.FetchAll(tempIndustryView);
                }

                // return value
                return industryViews;
            }
            #endregion

            #region LoadIndustryViewsForIndustryAndStockDate(string industry, DateTime stockDate)
            /// <summary>
            /// This method is used to load 'IndustryView' objects by IndustryAndStockDate
            /// </summary>
            public List<IndustryView> LoadIndustryViewsForIndustryAndStockDate(string industry, DateTime stockDate)
            {
                // initial value
                List<IndustryView> industryViews = null;
                    
                // Create a temp IndustryView object
                IndustryView tempIndustryView = new IndustryView();
                    
                // Set the value for LoadByIndustryAndStockDate to true
                tempIndustryView.LoadByIndustryAndStockDate = true;
                    
                // Set the value for Industry
                tempIndustryView.Industry = industry;
                    
                // Set the value for StockDate
                tempIndustryView.StockDate = stockDate;
                    
                // Perform the load
                industryViews = LoadIndustryViews(tempIndustryView);
                    
                // return value
                return industryViews;
            }
            #endregion

            #region LoadIndustryWinningStreakViews(IndustryWinningStreakView tempIndustryWinningStreakView = null)
            /// <summary>
            /// This method loads a collection of 'IndustryWinningStreakView' objects.
            /// </summary>
            public List<IndustryWinningStreakView> LoadIndustryWinningStreakViews(IndustryWinningStreakView tempIndustryWinningStreakView = null)
            {
                // initial value
                List<IndustryWinningStreakView> industryWinningStreakViews = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    industryWinningStreakViews = this.AppController.ControllerManager.IndustryWinningStreakViewController.FetchAll(tempIndustryWinningStreakView);
                }

                // return value
                return industryWinningStreakViews;
            }
            #endregion

            #region LoadMarketSummarys(MarketSummary tempMarketSummary = null)
            /// <summary>
            /// This method loads a collection of 'MarketSummary' objects.
            /// </summary>
            public List<MarketSummary> LoadMarketSummarys(MarketSummary tempMarketSummary = null)
            {
                // initial value
                List<MarketSummary> marketSummarys = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    marketSummarys = this.AppController.ControllerManager.MarketSummaryController.FetchAll(tempMarketSummary);
                }

                // return value
                return marketSummarys;
            }
            #endregion

            #region LoadRecommendationLogs(RecommendationLog tempRecommendationLog = null)
            /// <summary>
            /// This method loads a collection of 'RecommendationLog' objects.
            /// </summary>
            public List<RecommendationLog> LoadRecommendationLogs(RecommendationLog tempRecommendationLog = null)
            {
                // initial value
                List<RecommendationLog> recommendationLogs = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    recommendationLogs = this.AppController.ControllerManager.RecommendationLogController.FetchAll(tempRecommendationLog);
                }

                // return value
                return recommendationLogs;
            }
            #endregion

            #region LoadRecommendationViews(RecommendationView tempRecommendationView = null)
            /// <summary>
            /// This method loads a collection of 'RecommendationView' objects.
            /// </summary>
            public List<RecommendationView> LoadRecommendationViews(RecommendationView tempRecommendationView = null)
            {
                // initial value
                List<RecommendationView> recommendationViews = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    recommendationViews = this.AppController.ControllerManager.RecommendationViewController.FetchAll(tempRecommendationView);
                }

                // return value
                return recommendationViews;
            }
            #endregion

            #region LoadSectorHistorys(SectorHistory tempSectorHistory = null)
            /// <summary>
            /// This method loads a collection of 'SectorHistory' objects.
            /// </summary>
            public List<SectorHistory> LoadSectorHistorys(SectorHistory tempSectorHistory = null)
            {
                // initial value
                List<SectorHistory> sectorHistorys = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    sectorHistorys = this.AppController.ControllerManager.SectorHistoryController.FetchAll(tempSectorHistory);
                }

                // return value
                return sectorHistorys;
            }
            #endregion

            #region LoadSectors(Sector tempSector = null)
            /// <summary>
            /// This method loads a collection of 'Sector' objects.
            /// </summary>
            public List<Sector> LoadSectors(Sector tempSector = null)
            {
                // initial value
                List<Sector> sectors = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    sectors = this.AppController.ControllerManager.SectorController.FetchAll(tempSector);
                }

                // return value
                return sectors;
            }
            #endregion

            #region LoadSectorSummarys(SectorSummary tempSectorSummary = null)
            /// <summary>
            /// This method loads a collection of 'SectorSummary' objects.
            /// </summary>
            public List<SectorSummary> LoadSectorSummarys(SectorSummary tempSectorSummary = null)
            {
                // initial value
                List<SectorSummary> sectorSummarys = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    sectorSummarys = this.AppController.ControllerManager.SectorSummaryController.FetchAll(tempSectorSummary);
                }

                // return value
                return sectorSummarys;
            }
            #endregion
                
            #region LoadSectorViews(SectorView tempSectorView = null)
            /// <summary>
            /// This method loads a collection of 'SectorView' objects.
            /// </summary>
            public List<SectorView> LoadSectorViews(SectorView tempSectorView = null)
            {
                // initial value
                List<SectorView> sectorViews = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    sectorViews = this.AppController.ControllerManager.SectorViewController.FetchAll(tempSectorView);
                }

                // return value
                return sectorViews;
            }
            #endregion

            #region LoadSectorViewsForSectorAndStockDate(string sector, DateTime stockDate)
            /// <summary>
            /// This method is used to load 'SectorView' objects by SectorAndStockDate
            /// </summary>
            public List<SectorView> LoadSectorViewsForSectorAndStockDate(string sector, DateTime stockDate)
            {
                // initial value
                List<SectorView> sectorViews = null;
                    
                // Create a temp SectorView object
                SectorView tempSectorView = new SectorView();
                    
                // Set the value for LoadBySectorAndStockDate to true
                tempSectorView.LoadBySectorAndStockDate = true;
                    
                // Set the value for Sector
                tempSectorView.Sector = sector;
                    
                // Set the value for StockDate
                tempSectorView.StockDate = stockDate;
                    
                // Perform the load
                sectorViews = LoadSectorViews(tempSectorView);
                    
                // return value
                return sectorViews;
            }
            #endregion
                
            #region LoadStockDays(StockDay tempStockDay = null)
            /// <summary>
            /// This method loads a collection of 'StockDay' objects.
            /// </summary>
            public List<StockDay> LoadStockDays(StockDay tempStockDay = null)
            {
                // initial value
                List<StockDay> stockDays = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    stockDays = this.AppController.ControllerManager.StockDayController.FetchAll(tempStockDay);
                }

                // return value
                return stockDays;
            }
            #endregion

            #region LoadStockDaysThatNeedsProcessing(bool industryProcessed, bool sectorProcessed)
            /// <summary>
            /// This method is used to load 'StockDay' objects by NeedsProcessing
            /// </summary>
            public List<StockDay> LoadStockDaysThatNeedsProcessing(bool industryProcessed, bool sectorProcessed)
            {
                // initial value
                List<StockDay> stockDays = null;
                    
                // Create a temp StockDay object
                StockDay tempStockDay = new StockDay();
                    
                // Set the value for LoadByNeedsProcessing to true
                tempStockDay.LoadByNeedsProcessing = true;
                    
                // Set the value for IndustryProcessed
                tempStockDay.IndustryProcessed = industryProcessed;
                    
                // Set the value for SectorProcessed
                tempStockDay.SectorProcessed = sectorProcessed;
                    
                // Perform the load
                stockDays = LoadStockDays(tempStockDay);
                    
                // return value
                return stockDays;
            }
            #endregion
                
            #region LoadStocks(Stock tempStock = null)
            /// <summary>
            /// This method loads a collection of 'Stock' objects.
            /// </summary>
            public List<Stock> LoadStocks(Stock tempStock = null)
            {
                // initial value
                List<Stock> stocks = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    stocks = this.AppController.ControllerManager.StockController.FetchAll(tempStock);
                }

                // return value
                return stocks;
            }
            #endregion

            #region LoadStockStreaks(StockStreak tempStockStreak = null)
            /// <summary>
            /// This method loads a collection of 'StockStreak' objects.
            /// </summary>
            public List<StockStreak> LoadStockStreaks(StockStreak tempStockStreak = null)
            {
                // initial value
                List<StockStreak> stockStreaks = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    stockStreaks = this.AppController.ControllerManager.StockStreakController.FetchAll(tempStockStreak);
                }

                // return value
                return stockStreaks;
            }
            #endregion

            #region LoadStockStreakViews(StockStreakView tempStockStreakView = null)
            /// <summary>
            /// This method loads a collection of 'StockStreakView' objects.
            /// </summary>
            public List<StockStreakView> LoadStockStreakViews(StockStreakView tempStockStreakView = null)
            {
                // initial value
                List<StockStreakView> stockStreakViews = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    stockStreakViews = this.AppController.ControllerManager.StockStreakViewController.FetchAll(tempStockStreakView);
                }

                // return value
                return stockStreakViews;
            }
            #endregion

            #region LoadTopLosingStreakStocks(TopLosingStreakStocks tempTopLosingStreakStocks = null)
            /// <summary>
            /// This method loads a collection of 'TopLosingStreakStocks' objects.
            /// </summary>
            public List<TopLosingStreakStocks> LoadTopLosingStreakStocks(TopLosingStreakStocks tempTopLosingStreakStocks = null)
            {
                // initial value
                List<TopLosingStreakStocks> topLosingStreakStocks = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    topLosingStreakStocks = this.AppController.ControllerManager.TopLosingStreakStocksController.FetchAll(tempTopLosingStreakStocks);
                }

                // return value
                return topLosingStreakStocks;
            }
            #endregion

            #region LoadTopStreakStocks(TopStreakStocks tempTopStreakStocks = null)
            /// <summary>
            /// This method loads a collection of 'TopStreakStocks' objects.
            /// </summary>
            public List<TopStreakStocks> LoadTopStreakStocks(TopStreakStocks tempTopStreakStocks = null)
            {
                // initial value
                List<TopStreakStocks> topStreakStocks = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    topStreakStocks = this.AppController.ControllerManager.TopStreakStocksController.FetchAll(tempTopStreakStocks);
                }

                // return value
                return topStreakStocks;
            }
            #endregion

            #region SaveAdmin(ref Admin admin)
            /// <summary>
            /// This method is used to save 'Admin' objects.
            /// </summary>
            /// <param name="admin">The Admin to save.</param>
            public bool SaveAdmin(ref Admin admin)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.AdminController.Save(ref admin);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveDailyPriceData(ref DailyPriceData dailyPriceData)
            /// <summary>
            /// This method is used to save 'DailyPriceData' objects.
            /// </summary>
            /// <param name="dailyPriceData">The DailyPriceData to save.</param>
            public bool SaveDailyPriceData(ref DailyPriceData dailyPriceData)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.DailyPriceDataController.Save(ref dailyPriceData);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveDoNotTrack(ref DoNotTrack doNotTrack)
            /// <summary>
            /// This method is used to save 'DoNotTrack' objects.
            /// </summary>
            /// <param name="doNotTrack">The DoNotTrack to save.</param>
            public bool SaveDoNotTrack(ref DoNotTrack doNotTrack)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.DoNotTrackController.Save(ref doNotTrack);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveIndustry(ref Industry industry)
            /// <summary>
            /// This method is used to save 'Industry' objects.
            /// </summary>
            /// <param name="industry">The Industry to save.</param>
            public bool SaveIndustry(ref Industry industry)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.IndustryController.Save(ref industry);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveIndustryHistory(ref IndustryHistory industryHistory)
            /// <summary>
            /// This method is used to save 'IndustryHistory' objects.
            /// </summary>
            /// <param name="industryHistory">The IndustryHistory to save.</param>
            public bool SaveIndustryHistory(ref IndustryHistory industryHistory)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.IndustryHistoryController.Save(ref industryHistory);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveRecommendationLog(ref RecommendationLog recommendationLog)
            /// <summary>
            /// This method is used to save 'RecommendationLog' objects.
            /// </summary>
            /// <param name="recommendationLog">The RecommendationLog to save.</param>
            public bool SaveRecommendationLog(ref RecommendationLog recommendationLog)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.RecommendationLogController.Save(ref recommendationLog);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveSector(ref Sector sector)
            /// <summary>
            /// This method is used to save 'Sector' objects.
            /// </summary>
            /// <param name="sector">The Sector to save.</param>
            public bool SaveSector(ref Sector sector)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.SectorController.Save(ref sector);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveSectorHistory(ref SectorHistory sectorHistory)
            /// <summary>
            /// This method is used to save 'SectorHistory' objects.
            /// </summary>
            /// <param name="sectorHistory">The SectorHistory to save.</param>
            public bool SaveSectorHistory(ref SectorHistory sectorHistory)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.SectorHistoryController.Save(ref sectorHistory);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveStock(ref Stock stock)
            /// <summary>
            /// This method is used to save 'Stock' objects.
            /// </summary>
            /// <param name="stock">The Stock to save.</param>
            public bool SaveStock(ref Stock stock)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.StockController.Save(ref stock);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveStockDay(ref StockDay stockDay)
            /// <summary>
            /// This method is used to save 'StockDay' objects.
            /// </summary>
            /// <param name="stockDay">The StockDay to save.</param>
            public bool SaveStockDay(ref StockDay stockDay)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.StockDayController.Save(ref stockDay);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveStockStreak(ref StockStreak stockStreak)
            /// <summary>
            /// This method is used to save 'StockStreak' objects.
            /// </summary>
            /// <param name="stockStreak">The StockStreak to save.</param>
            public bool SaveStockStreak(ref StockStreak stockStreak)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.StockStreakController.Save(ref stockStreak);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            /// <summary>
            /// This property gets or sets the value for 'AppController'.
            /// </summary>
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ConnectionName
            /// <summary>
            /// This property gets or sets the value for 'ConnectionName'.
            /// </summary>
            public string ConnectionName
            {
                get { return connectionName; }
                set { connectionName = value; }
            }
            #endregion
            
            #region HasAppController
            /// <summary>
            /// This property returns true if this object has an 'AppController'.
            /// </summary>
            public bool HasAppController
            {
                get
                {
                    // initial value
                    bool hasAppController = (this.AppController != null);

                    // return value
                    return hasAppController;
                }
            }
            #endregion

            #region HasConnectionName
            /// <summary>
            /// This property returns true if the 'ConnectionName' exists.
            /// </summary>
            public bool HasConnectionName
            {
                get
                {
                    // initial value
                    bool hasConnectionName = (!String.IsNullOrEmpty(this.ConnectionName));
                    
                    // return value
                    return hasConnectionName;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
