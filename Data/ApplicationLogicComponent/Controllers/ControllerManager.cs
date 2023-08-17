

#region using statements

using ApplicationLogicComponent.DataBridge;
using ApplicationLogicComponent.DataOperations;
using ApplicationLogicComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.Controllers
{

    #region class ControllerManager
    /// <summary>
    /// This class manages the child controllers for this application.
    /// </summary>
    public class ControllerManager
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        private AdminController adminController;
        private DailyPriceDataController dailypricedataController;
        private StockController stockController;
        private StockStreakController stockstreakController;
        private StockStreakViewController stockstreakviewController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'ControllerManager' object.
        /// </summary>
        public ControllerManager(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;

            // Create Child Controllers
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Create Child Controllers
            /// </summary>
            private void Init()
            {
                // Create Child Controllers
                this.AdminController = new AdminController(this.ErrorProcessor, this.AppController);
                this.DailyPriceDataController = new DailyPriceDataController(this.ErrorProcessor, this.AppController);
                this.StockController = new StockController(this.ErrorProcessor, this.AppController);
                this.StockStreakController = new StockStreakController(this.ErrorProcessor, this.AppController);
                this.StockStreakViewController = new StockStreakViewController(this.ErrorProcessor, this.AppController);
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ErrorProcessor
            public ErrorHandler ErrorProcessor
            {
                get { return errorProcessor; }
                set { errorProcessor = value; }
            }
            #endregion

            #region AdminController
            public AdminController AdminController
            {
                get { return adminController; }
                set { adminController = value; }
            }
            #endregion

            #region DailyPriceDataController
            public DailyPriceDataController DailyPriceDataController
            {
                get { return dailypricedataController; }
                set { dailypricedataController = value; }
            }
            #endregion

            #region StockController
            public StockController StockController
            {
                get { return stockController; }
                set { stockController = value; }
            }
            #endregion

            #region StockStreakController
            public StockStreakController StockStreakController
            {
                get { return stockstreakController; }
                set { stockstreakController = value; }
            }
            #endregion

            #region StockStreakViewController
            public StockStreakViewController StockStreakViewController
            {
                get { return stockstreakviewController; }
                set { stockstreakviewController = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
