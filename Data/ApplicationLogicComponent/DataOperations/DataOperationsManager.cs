

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
        private IndustryMethods industryMethods;
        private IndustryHistoryMethods industryhistoryMethods;
        private SectorMethods sectorMethods;
        private SectorHistoryMethods sectorhistoryMethods;
        private StockMethods stockMethods;
        private StockStreakMethods stockstreakMethods;
        private StockStreakViewMethods stockstreakviewMethods;
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
                this.IndustryMethods = new IndustryMethods(this.DataManager);
                this.IndustryHistoryMethods = new IndustryHistoryMethods(this.DataManager);
                this.SectorMethods = new SectorMethods(this.DataManager);
                this.SectorHistoryMethods = new SectorHistoryMethods(this.DataManager);
                this.StockMethods = new StockMethods(this.DataManager);
                this.StockStreakMethods = new StockStreakMethods(this.DataManager);
                this.StockStreakViewMethods = new StockStreakViewMethods(this.DataManager);
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

            #region StockMethods
            public StockMethods StockMethods
            {
                get { return stockMethods; }
                set { stockMethods = value; }
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

        #endregion

    }
    #endregion

}
