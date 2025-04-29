

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class RecommendationLog
    public partial class RecommendationLog
    {

        #region Private Variables
        private double closeScore;
        private int id;
        private string industry;
        private double industryScore;
        private int industryStreak;
        private double lastClose;
        private double lastPercentChange;
        private double score;
        private string sector;
        private double sectorScore;
        private int sectorStreak;
        private DateTime stockDate;
        private string stockName;
        private int streak;
        private double streakPercentChange;
        private string symbol;
        private double volumeScore;
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

                // CloseScore

                sb.Append(CloseScore);

                // Add a comma
                sb.Append(comma);

                // Industry

                sb.Append(singleQuote);
                sb.Append(Industry);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // IndustryScore

                sb.Append(IndustryScore);

                // Add a comma
                sb.Append(comma);

                // IndustryStreak

                sb.Append(IndustryStreak);

                // Add a comma
                sb.Append(comma);

                // LastClose

                sb.Append(LastClose);

                // Add a comma
                sb.Append(comma);

                // LastPercentChange

                sb.Append(LastPercentChange);

                // Add a comma
                sb.Append(comma);

                // Score

                sb.Append(Score);

                // Add a comma
                sb.Append(comma);

                // Sector

                sb.Append(singleQuote);
                sb.Append(Sector);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // SectorScore

                sb.Append(SectorScore);

                // Add a comma
                sb.Append(comma);

                // SectorStreak

                sb.Append(SectorStreak);

                // Add a comma
                sb.Append(comma);

                // StockDate

                // If a valid date
                if (StockDate.Year > 1900)
                {
                    sb.Append(singleQuote);
                    sb.Append(StockDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    sb.Append(singleQuote);
                }
                else
                {
                    sb.Append("'1900-01-01'");
                }

                // Add a comma
                sb.Append(comma);

                // StockName

                sb.Append(singleQuote);
                sb.Append(StockName);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // Streak

                sb.Append(Streak);

                // Add a comma
                sb.Append(comma);

                // StreakPercentChange

                sb.Append(StreakPercentChange);

                // Add a comma
                sb.Append(comma);

                // Symbol

                sb.Append(singleQuote);
                sb.Append(Symbol);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // VolumeScore

                sb.Append(VolumeScore);

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
                string insertSQL = "INSERT INTO [RecommendationLog] (CloseScore,Industry,IndustryScore,IndustryStreak,LastClose,LastPercentChange,Score,Sector,SectorScore,SectorStreak,StockDate,StockName,Streak,StreakPercentChange,Symbol,VolumeScore) VALUES (" + valuesList + ") " + Environment.NewLine + "SELECT SCOPE_IDENTITY()" + Environment.NewLine;

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

            #region double CloseScore
            public double CloseScore
            {
                get
                {
                    return closeScore;
                }
                set
                {
                    closeScore = value;
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

            #region double IndustryScore
            public double IndustryScore
            {
                get
                {
                    return industryScore;
                }
                set
                {
                    industryScore = value;
                }
            }
            #endregion

            #region int IndustryStreak
            public int IndustryStreak
            {
                get
                {
                    return industryStreak;
                }
                set
                {
                    industryStreak = value;
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

            #region double LastPercentChange
            public double LastPercentChange
            {
                get
                {
                    return lastPercentChange;
                }
                set
                {
                    lastPercentChange = value;
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

            #region double SectorScore
            public double SectorScore
            {
                get
                {
                    return sectorScore;
                }
                set
                {
                    sectorScore = value;
                }
            }
            #endregion

            #region int SectorStreak
            public int SectorStreak
            {
                get
                {
                    return sectorStreak;
                }
                set
                {
                    sectorStreak = value;
                }
            }
            #endregion

            #region DateTime StockDate
            public DateTime StockDate
            {
                get
                {
                    return stockDate;
                }
                set
                {
                    stockDate = value;
                }
            }
            #endregion

            #region string StockName
            public string StockName
            {
                get
                {
                    return stockName;
                }
                set
                {
                    stockName = value;
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

            #region double StreakPercentChange
            public double StreakPercentChange
            {
                get
                {
                    return streakPercentChange;
                }
                set
                {
                    streakPercentChange = value;
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

            #region double VolumeScore
            public double VolumeScore
            {
                get
                {
                    return volumeScore;
                }
                set
                {
                    volumeScore = value;
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
