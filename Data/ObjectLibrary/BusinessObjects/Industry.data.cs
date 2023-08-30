

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Industry
    public partial class Industry
    {

        #region Private Variables
        private int advancers;
        private double averagePercentChange;
        private int decliners;
        private int id;
        private DateTime lastUpdated;
        private string name;
        private int numberStocks;
        private double score;
        private int streak;
        #endregion

        #region Methods

            #region UpdateIdentity(int id)
            // <summary>
            // This method provides a 'setter'
            // functionality for the Identity field.
            // </summary>
            public void UpdateIdentity(int id)
            {
                // Update The Identity field
                this.id = id;
            }
            #endregion

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

            #region int Id
            public int Id
            {
                get
                {
                    return id;
                }
            }
            #endregion

            #region DateTime LastUpdated
            public DateTime LastUpdated
            {
                get
                {
                    return lastUpdated;
                }
                set
                {
                    lastUpdated = value;
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

            #region int NumberStocks
            public int NumberStocks
            {
                get
                {
                    return numberStocks;
                }
                set
                {
                    numberStocks = value;
                }
            }
            #endregion

            #region double Score
            public double Score
            {
                get
                {
                    return score;
                }
                set
                {
                    score = value;
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

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.Id < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
