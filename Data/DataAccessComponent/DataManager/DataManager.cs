

#region using statements

using DataAccessComponent.DataManager.Readers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager
{

    #region class DataManager
    /// <summary>
    /// This class manages data operations for this project.
    /// </summary>
    public class DataManager
    {

        #region Private Variables
        private DataConnector dataConnector;
        private string connectionName;
        private AdminManager adminManager;
        private DailyPriceDataManager dailypricedataManager;
        private DailyPriceDataViewManager dailypricedataviewManager;
        private DoNotTrackManager donottrackManager;
        private IndustryManager industryManager;
        private IndustryHistoryManager industryhistoryManager;
        private IndustrySummaryManager industrysummaryManager;
        private IndustryViewManager industryviewManager;
        private MarketSummaryManager marketsummaryManager;
        private RecommendationLogManager recommendationlogManager;
        private RecommendationViewManager recommendationviewManager;
        private SectorManager sectorManager;
        private SectorHistoryManager sectorhistoryManager;
        private SectorSummaryManager sectorsummaryManager;
        private SectorViewManager sectorviewManager;
        private StockManager stockManager;
        private StockDayManager stockdayManager;
        private StockStreakManager stockstreakManager;
        private StockStreakViewManager stockstreakviewManager;
        private TopLosingStreakStocksManager toplosingstreakstocksManager;
        private TopStreakStocksManager topstreakstocksManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of a(n) 'DataManager' object.
        /// </summary>
        public DataManager(string connectionName = "")
        {
            // Store the ConnectionName arg
            this.ConnectionName = connectionName;

            // Perform Initializations For This Object.
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Perform Initializations For This Object.
            /// Create the DataConnector and the Child Object Managers.
            /// </summary>
            private void Init()
            {
                // Create New DataConnector
                this.DataConnector = new DataConnector();

                // Create Child Object Managers
                this.AdminManager = new AdminManager(this);
                this.DailyPriceDataManager = new DailyPriceDataManager(this);
                this.DailyPriceDataViewManager = new DailyPriceDataViewManager(this);
                this.DoNotTrackManager = new DoNotTrackManager(this);
                this.IndustryManager = new IndustryManager(this);
                this.IndustryHistoryManager = new IndustryHistoryManager(this);
                this.IndustrySummaryManager = new IndustrySummaryManager(this);
                this.IndustryViewManager = new IndustryViewManager(this);
                this.MarketSummaryManager = new MarketSummaryManager(this);
                this.RecommendationLogManager = new RecommendationLogManager(this);
                this.RecommendationViewManager = new RecommendationViewManager(this);
                this.SectorManager = new SectorManager(this);
                this.SectorHistoryManager = new SectorHistoryManager(this);
                this.SectorSummaryManager = new SectorSummaryManager(this);
                this.SectorViewManager = new SectorViewManager(this);
                this.StockManager = new StockManager(this);
                this.StockDayManager = new StockDayManager(this);
                this.StockStreakManager = new StockStreakManager(this);
                this.StockStreakViewManager = new StockStreakViewManager(this);
                this.TopLosingStreakStocksManager = new TopLosingStreakStocksManager(this);
                this.TopStreakStocksManager = new TopStreakStocksManager(this);
            }
            #endregion

        #endregion

        #region Properties

            #region DataConnector
            public DataConnector DataConnector
            {
                get { return dataConnector; }
                set { dataConnector = value; }
            }
            #endregion

            #region ConnectionName
            public string ConnectionName
            {
                get { return connectionName; }
                set { connectionName = value; }
            }
            #endregion

            #region AdminManager
            public AdminManager AdminManager
            {
                get { return adminManager; }
                set { adminManager = value; }
            }
            #endregion

            #region DailyPriceDataManager
            public DailyPriceDataManager DailyPriceDataManager
            {
                get { return dailypricedataManager; }
                set { dailypricedataManager = value; }
            }
            #endregion

            #region DailyPriceDataViewManager
            public DailyPriceDataViewManager DailyPriceDataViewManager
            {
                get { return dailypricedataviewManager; }
                set { dailypricedataviewManager = value; }
            }
            #endregion

            #region DoNotTrackManager
            public DoNotTrackManager DoNotTrackManager
            {
                get { return donottrackManager; }
                set { donottrackManager = value; }
            }
            #endregion

            #region IndustryManager
            public IndustryManager IndustryManager
            {
                get { return industryManager; }
                set { industryManager = value; }
            }
            #endregion

            #region IndustryHistoryManager
            public IndustryHistoryManager IndustryHistoryManager
            {
                get { return industryhistoryManager; }
                set { industryhistoryManager = value; }
            }
            #endregion

            #region IndustrySummaryManager
            public IndustrySummaryManager IndustrySummaryManager
            {
                get { return industrysummaryManager; }
                set { industrysummaryManager = value; }
            }
            #endregion

            #region IndustryViewManager
            public IndustryViewManager IndustryViewManager
            {
                get { return industryviewManager; }
                set { industryviewManager = value; }
            }
            #endregion

            #region MarketSummaryManager
            public MarketSummaryManager MarketSummaryManager
            {
                get { return marketsummaryManager; }
                set { marketsummaryManager = value; }
            }
            #endregion

            #region RecommendationLogManager
            public RecommendationLogManager RecommendationLogManager
            {
                get { return recommendationlogManager; }
                set { recommendationlogManager = value; }
            }
            #endregion

            #region RecommendationViewManager
            public RecommendationViewManager RecommendationViewManager
            {
                get { return recommendationviewManager; }
                set { recommendationviewManager = value; }
            }
            #endregion

            #region SectorManager
            public SectorManager SectorManager
            {
                get { return sectorManager; }
                set { sectorManager = value; }
            }
            #endregion

            #region SectorHistoryManager
            public SectorHistoryManager SectorHistoryManager
            {
                get { return sectorhistoryManager; }
                set { sectorhistoryManager = value; }
            }
            #endregion

            #region SectorSummaryManager
            public SectorSummaryManager SectorSummaryManager
            {
                get { return sectorsummaryManager; }
                set { sectorsummaryManager = value; }
            }
            #endregion

            #region SectorViewManager
            public SectorViewManager SectorViewManager
            {
                get { return sectorviewManager; }
                set { sectorviewManager = value; }
            }
            #endregion

            #region StockManager
            public StockManager StockManager
            {
                get { return stockManager; }
                set { stockManager = value; }
            }
            #endregion

            #region StockDayManager
            public StockDayManager StockDayManager
            {
                get { return stockdayManager; }
                set { stockdayManager = value; }
            }
            #endregion

            #region StockStreakManager
            public StockStreakManager StockStreakManager
            {
                get { return stockstreakManager; }
                set { stockstreakManager = value; }
            }
            #endregion

            #region StockStreakViewManager
            public StockStreakViewManager StockStreakViewManager
            {
                get { return stockstreakviewManager; }
                set { stockstreakviewManager = value; }
            }
            #endregion

            #region TopLosingStreakStocksManager
            public TopLosingStreakStocksManager TopLosingStreakStocksManager
            {
                get { return toplosingstreakstocksManager; }
                set { toplosingstreakstocksManager = value; }
            }
            #endregion

            #region TopStreakStocksManager
            public TopStreakStocksManager TopStreakStocksManager
            {
                get { return topstreakstocksManager; }
                set { topstreakstocksManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
