

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

            #region CreateValuesList
            // <summary>
            // This method creates the ValuesList for an Insert SQL Statement.'
            // </summary>
            public string CreateValuesList()
            {
                // initial value
                string valuesList = "";

                // locals
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                string comma = ",";
                string singleQuote = "'";

                // Advancers

                sb.Append(Advancers);

                // Add a comma
                sb.Append(comma);

                // AveragePercentChange

                sb.Append(AveragePercentChange);

                // Add a comma
                sb.Append(comma);

                // Decliners

                sb.Append(Decliners);

                // Add a comma
                sb.Append(comma);

                // LastUpdated

                // If a valid date
                if (LastUpdated.Year > 1900)
                {
                    sb.Append(singleQuote);
                    sb.Append(LastUpdated.ToString("yyyy-MM-dd HH:mm:ss"));
                    sb.Append(singleQuote);
                }
                else
                {
                    sb.Append("'1900-01-01'");
                }

                // Add a comma
                sb.Append(comma);

                // Name

                sb.Append(singleQuote);
                sb.Append(Name);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // NumberStocks

                sb.Append(NumberStocks);

                // Add a comma
                sb.Append(comma);

                // Score

                sb.Append(Score);

                // Add a comma
                sb.Append(comma);

                // Streak

                sb.Append(Streak);

                // Set the return value
                valuesList = sb.ToString();

                // Return Value
                return valuesList;
            }
            #endregion

            #region GenerateInsertSQL
            // <summary>
            // This method generates a SQL Insert statement for ah object loaded.'
            // </summary>
            public string GenerateInsertSQL()
            {
                // local
                string valuesList = CreateValuesList();

                // Set the return Value
                string insertSQL = "INSERT INTO [Industry] (Advancers,AveragePercentChange,Decliners,LastUpdated,Name,NumberStocks,Score,Streak) VALUES (" + valuesList + ") " + Environment.NewLine + "SELECT SCOPE_IDENTITY()" + Environment.NewLine;

                // Return Value
                return insertSQL;
            }
            #endregion

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
