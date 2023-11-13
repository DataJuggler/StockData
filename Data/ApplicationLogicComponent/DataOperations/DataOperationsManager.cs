

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

    #region class DataOperationsManager
    /// <summary>
    /// This class manages DataOperations for this project.
    /// </summary>
    public class DataOperationsManager
    {

        #region Private Variables
        private DataManager dataManager;
        private SystemMethods systemMethods;
        private AdminMethods adminMethods;
        private DailyPriceDataMethods dailypricedataMethods;
        private DailyPriceDataViewMethods dailypricedataviewMethods;
        private DoNotTrackMethods donottrackMethods;
        private IndustryMethods industryMethods;
        private IndustryHistoryMethods industryhistoryMethods;
        private IndustryLosingStreakViewMethods industrylosingstreakviewMethods;
        private IndustrySummaryMethods industrysummaryMethods;
        private IndustryViewMethods industryviewMethods;
        private IndustryWinningStreakViewMethods industrywinningstreakviewMethods;
        private MarketSummaryMethods marketsummaryMethods;
        private RecommendationLogMethods recommendationlogMethods;
        private RecommendationViewMethods recommendationviewMethods;
        private SectorMethods sectorMethods;
        private SectorHistoryMethods sectorhistoryMethods;
        private SectorSummaryMethods sectorsummaryMethods;
        private SectorViewMethods sectorviewMethods;
        private StockMethods stockMethods;
        private StockDayMethods stockdayMethods;
        private StockStreakMethods stockstreakMethods;
        private StockStreakViewMethods stockstreakviewMethods;
        private TopLosingStreakStocksMethods toplosingstreakstocksMethods;
        private TopStreakStocksMethods topstreakstocksMethods;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'DataOperationsManager' object.
        /// </summary>
        public DataOperationsManager(DataManager dataManagerArg)
        {
            // Save Arguments
            this.DataManager = dataManagerArg;

            // Create Child DataOperationMethods
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Create Child DataOperationMethods
            /// </summary>
            private void Init()
            {
                // Create Child DataOperatonMethods
                this.SystemMethods = new SystemMethods();
                this.AdminMethods = new AdminMethods(this.DataManager);
                this.DailyPriceDataMethods = new DailyPriceDataMethods(this.DataManager);
                this.DailyPriceDataViewMethods = new DailyPriceDataViewMethods(this.DataManager);
                this.DoNotTrackMethods = new DoNotTrackMethods(this.DataManager);
                this.IndustryMethods = new IndustryMethods(this.DataManager);
                this.IndustryHistoryMethods = new IndustryHistoryMethods(this.DataManager);
                this.IndustryLosingStreakViewMethods = new IndustryLosingStreakViewMethods(this.DataManager);
                this.IndustrySummaryMethods = new IndustrySummaryMethods(this.DataManager);
                this.IndustryViewMethods = new IndustryViewMethods(this.DataManager);
                this.IndustryWinningStreakViewMethods = new IndustryWinningStreakViewMethods(this.DataManager);
                this.MarketSummaryMethods = new MarketSummaryMethods(this.DataManager);
                this.RecommendationLogMethods = new RecommendationLogMethods(this.DataManager);
                this.RecommendationViewMethods = new RecommendationViewMethods(this.DataManager);
                this.SectorMethods = new SectorMethods(this.DataManager);
                this.SectorHistoryMethods = new SectorHistoryMethods(this.DataManager);
                this.SectorSummaryMethods = new SectorSummaryMethods(this.DataManager);
                this.SectorViewMethods = new SectorViewMethods(this.DataManager);
                this.StockMethods = new StockMethods(this.DataManager);
                this.StockDayMethods = new StockDayMethods(this.DataManager);
                this.StockStreakMethods = new StockStreakMethods(this.DataManager);
                this.StockStreakViewMethods = new StockStreakViewMethods(this.DataManager);
                this.TopLosingStreakStocksMethods = new TopLosingStreakStocksMethods(this.DataManager);
                this.TopStreakStocksMethods = new TopStreakStocksMethods(this.DataManager);
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

            #region SystemMethods
            public SystemMethods SystemMethods
            {
                get { return systemMethods; }
                set { systemMethods = value; }
            }
            #endregion

            #region AdminMethods
            public AdminMethods AdminMethods
            {
                get { return adminMethods; }
                set { adminMethods = value; }
            }
            #endregion

            #region DailyPriceDataMethods
            public DailyPriceDataMethods DailyPriceDataMethods
            {
                get { return dailypricedataMethods; }
                set { dailypricedataMethods = value; }
            }
            #endregion

            #region DailyPriceDataViewMethods
            public DailyPriceDataViewMethods DailyPriceDataViewMethods
            {
                get { return dailypricedataviewMethods; }
                set { dailypricedataviewMethods = value; }
            }
            #endregion

            #region DoNotTrackMethods
            public DoNotTrackMethods DoNotTrackMethods
            {
                get { return donottrackMethods; }
                set { donottrackMethods = value; }
            }
            #endregion

            #region IndustryMethods
            public IndustryMethods IndustryMethods
            {
                get { return industryMethods; }
                set { industryMethods = value; }
            }
            #endregion

            #region IndustryHistoryMethods
            public IndustryHistoryMethods IndustryHistoryMethods
            {
                get { return industryhistoryMethods; }
                set { industryhistoryMethods = value; }
            }
            #endregion

            #region IndustryLosingStreakViewMethods
            public IndustryLosingStreakViewMethods IndustryLosingStreakViewMethods
            {
                get { return industrylosingstreakviewMethods; }
                set { industrylosingstreakviewMethods = value; }
            }
            #endregion

            #region IndustrySummaryMethods
            public IndustrySummaryMethods IndustrySummaryMethods
            {
                get { return industrysummaryMethods; }
                set { industrysummaryMethods = value; }
            }
            #endregion

            #region IndustryViewMethods
            public IndustryViewMethods IndustryViewMethods
            {
                get { return industryviewMethods; }
                set { industryviewMethods = value; }
            }
            #endregion

            #region IndustryWinningStreakViewMethods
            public IndustryWinningStreakViewMethods IndustryWinningStreakViewMethods
            {
                get { return industrywinningstreakviewMethods; }
                set { industrywinningstreakviewMethods = value; }
            }
            #endregion

            #region MarketSummaryMethods
            public MarketSummaryMethods MarketSummaryMethods
            {
                get { return marketsummaryMethods; }
                set { marketsummaryMethods = value; }
            }
            #endregion

            #region RecommendationLogMethods
            public RecommendationLogMethods RecommendationLogMethods
            {
                get { return recommendationlogMethods; }
                set { recommendationlogMethods = value; }
            }
            #endregion

            #region RecommendationViewMethods
            public RecommendationViewMethods RecommendationViewMethods
            {
                get { return recommendationviewMethods; }
                set { recommendationviewMethods = value; }
            }
            #endregion

            #region SectorMethods
            public SectorMethods SectorMethods
            {
                get { return sectorMethods; }
                set { sectorMethods = value; }
            }
            #endregion

            #region SectorHistoryMethods
            public SectorHistoryMethods SectorHistoryMethods
            {
                get { return sectorhistoryMethods; }
                set { sectorhistoryMethods = value; }
            }
            #endregion

            #region SectorSummaryMethods
            public SectorSummaryMethods SectorSummaryMethods
            {
                get { return sectorsummaryMethods; }
                set { sectorsummaryMethods = value; }
            }
            #endregion

            #region SectorViewMethods
            public SectorViewMethods SectorViewMethods
            {
                get { return sectorviewMethods; }
                set { sectorviewMethods = value; }
            }
            #endregion

            #region StockMethods
            public StockMethods StockMethods
            {
                get { return stockMethods; }
                set { stockMethods = value; }
            }
            #endregion

            #region StockDayMethods
            public StockDayMethods StockDayMethods
            {
                get { return stockdayMethods; }
                set { stockdayMethods = value; }
            }
            #endregion

            #region StockStreakMethods
            public StockStreakMethods StockStreakMethods
            {
                get { return stockstreakMethods; }
                set { stockstreakMethods = value; }
            }
            #endregion

            #region StockStreakViewMethods
            public StockStreakViewMethods StockStreakViewMethods
            {
                get { return stockstreakviewMethods; }
                set { stockstreakviewMethods = value; }
            }
            #endregion

            #region TopLosingStreakStocksMethods
            public TopLosingStreakStocksMethods TopLosingStreakStocksMethods
            {
                get { return toplosingstreakstocksMethods; }
                set { toplosingstreakstocksMethods = value; }
            }
            #endregion

            #region TopStreakStocksMethods
            public TopStreakStocksMethods TopStreakStocksMethods
            {
                get { return topstreakstocksMethods; }
                set { topstreakstocksMethods = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
