

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class IndustryLosingStreakView
    public partial class IndustryLosingStreakView
    {

        #region Private Variables
        private int advancers;
        private double averagePercentChange;
        private int decliners;
        private string name;
        private int streak;
        #endregion

        #region Methods


        #endregion

        #region Properties

            #region int Advancers
            public int Advancers
            {
                get
                {
                    return advancers;
                }
                set
                {
                    advancers = value;
                }
            }
            #endregion

            #region double AveragePercentChange
            public double AveragePercentChange
            {
                get
                {
                    return averagePercentChange;
                }
                set
                {
                    averagePercentChange = value;
                }
            }
            #endregion

            #region int Decliners
            public int Decliners
            {
                get
                {
                    return decliners;
                }
                set
                {
                    decliners = value;
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

        #endregion

    }
    #endregion

}
