

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class SectorHistory
    public partial class SectorHistory
    {

        #region Private Variables
        private int advancers;
        private double averagePercentChange;
        private DateTime date;
        private int decliners;
        private int id;
        private double score;
        private int sectorId;
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

            #region DateTime Date
            public DateTime Date
            {
                get
                {
                    return date;
                }
                set
                {
                    date = value;
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

            #region int SectorId
            public int SectorId
            {
                get
                {
                    return sectorId;
                }
                set
                {
                    sectorId = value;
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
