

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Stock
    public partial class Stock
    {

        #region Private Variables
        private int averageDailyVolume;
        private string country;
        private int daysBelowMinVolume;
        private string exchange;
        private int id;
        private string industry;
        private int iPOYear;
        private double lastClose;
        private DateTime lastUpdated;
        private string name;
        private string sector;
        private int streak;
        private string symbol;
        private bool track;
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

                // AverageDailyVolume

                sb.Append(AverageDailyVolume);

                // Add a comma
                sb.Append(comma);

                // Country

                sb.Append(singleQuote);
                sb.Append(Country);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // DaysBelowMinVolume

                sb.Append(DaysBelowMinVolume);

                // Add a comma
                sb.Append(comma);

                // Exchange

                sb.Append(singleQuote);
                sb.Append(Exchange);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // Industry

                sb.Append(singleQuote);
                sb.Append(Industry);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // IPOYear

                sb.Append(IPOYear);

                // Add a comma
                sb.Append(comma);

                // LastClose

                sb.Append(LastClose);

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

                // Sector

                sb.Append(singleQuote);
                sb.Append(Sector);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // Streak

                sb.Append(Streak);

                // Add a comma
                sb.Append(comma);

                // Symbol

                sb.Append(singleQuote);
                sb.Append(Symbol);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // Track

                // If Track is true
                if (Track)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }

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
                string insertSQL = "INSERT INTO [Stock] (AverageDailyVolume,Country,DaysBelowMinVolume,Exchange,Industry,IPOYear,LastClose,LastUpdated,Name,Sector,Streak,Symbol,Track) VALUES (" + valuesList + ") " + Environment.NewLine + "SELECT SCOPE_IDENTITY()" + Environment.NewLine;

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

            #region int AverageDailyVolume
            public int AverageDailyVolume
            {
                get
                {
                    return averageDailyVolume;
                }
                set
                {
                    averageDailyVolume = value;
                }
            }
            #endregion

            #region string Country
            public string Country
            {
                get
                {
                    return country;
                }
                set
                {
                    country = value;
                }
            }
            #endregion

            #region int DaysBelowMinVolume
            public int DaysBelowMinVolume
            {
                get
                {
                    return daysBelowMinVolume;
                }
                set
                {
                    daysBelowMinVolume = value;
                }
            }
            #endregion

            #region string Exchange
            public string Exchange
            {
                get
                {
                    return exchange;
                }
                set
                {
                    exchange = value;
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

            #region string Industry
            public string Industry
            {
                get
                {
                    return industry;
                }
                set
                {
                    industry = value;
                }
            }
            #endregion

            #region int IPOYear
            public int IPOYear
            {
                get
                {
                    return iPOYear;
                }
                set
                {
                    iPOYear = value;
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

            #region string Sector
            public string Sector
            {
                get
                {
                    return sector;
                }
                set
                {
                    sector = value;
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

            #region bool Track
            public bool Track
            {
                get
                {
                    return track;
                }
                set
                {
                    track = value;
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
