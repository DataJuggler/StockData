

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class TopStreakStocks
    public partial class TopStreakStocks
    {

        #region Private Variables
        private int id;
        private double lastClose;
        private string name;
        private int streak;
        private string symbol;
        #endregion

        #region Methods


        #endregion

        #region Properties

            #region int Id
            public int Id
            {
                get
                {
                    return id;
                }
                set
                {
                    id = value;
                }
            }
            #endregion

            #region double LastClose
            public double LastClose
            {
                get
                {
                    return lastClose;
                }
                set
                {
                    lastClose = value;
                }
            }
            #endregion

            #region string Name
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            #endregion

            #region int Streak
            public int Streak
            {
                get
                {
                    return streak;
                }
                set
                {
                    streak = value;
                }
            }
            #endregion

            #region string Symbol
            public string Symbol
            {
                get
                {
                    return symbol;
                }
                set
                {
                    symbol = value;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
