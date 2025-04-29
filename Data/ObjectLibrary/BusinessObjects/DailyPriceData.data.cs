

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class DailyPriceData
    public partial class DailyPriceData
    {

        #region Private Variables
        private double closePrice;
        private double closeScore;
        private double highPrice;
        private int id;
        private double lowPrice;
        private bool mostRecent;
        private double openPrice;
        private double percentChange;
        private bool priceUnchanged;
        private double spread;
        private double spreadScore;
        private DateTime stockDate;
        private int streak;
        private string symbol;
        private int volume;
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

                // ClosePrice

                sb.Append(ClosePrice);

                // Add a comma
                sb.Append(comma);

                // CloseScore

                sb.Append(CloseScore);

                // Add a comma
                sb.Append(comma);

                // HighPrice

                sb.Append(HighPrice);

                // Add a comma
                sb.Append(comma);

                // LowPrice

                sb.Append(LowPrice);

                // Add a comma
                sb.Append(comma);

                // MostRecent

                // If MostRecent is true
                if (MostRecent)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }

                // Add a comma
                sb.Append(comma);

                // OpenPrice

                sb.Append(OpenPrice);

                // Add a comma
                sb.Append(comma);

                // PercentChange

                sb.Append(PercentChange);

                // Add a comma
                sb.Append(comma);

                // PriceUnchanged

                // If PriceUnchanged is true
                if (PriceUnchanged)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }

                // Add a comma
                sb.Append(comma);

                // Spread

                sb.Append(Spread);

                // Add a comma
                sb.Append(comma);

                // SpreadScore

                sb.Append(SpreadScore);

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

                // Volume

                sb.Append(Volume);

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
                string insertSQL = "INSERT INTO [DailyPriceData] (ClosePrice,CloseScore,HighPrice,LowPrice,MostRecent,OpenPrice,PercentChange,PriceUnchanged,Spread,SpreadScore,StockDate,Streak,Symbol,Volume,VolumeScore) VALUES (" + valuesList + ") " + Environment.NewLine + "SELECT SCOPE_IDENTITY()" + Environment.NewLine;

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

            #region double ClosePrice
            public double ClosePrice
            {
                get
                {
                    return closePrice;
                }
                set
                {
                    closePrice = value;
                }
            }
            #endregion

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

            #region double HighPrice
            public double HighPrice
            {
                get
                {
                    return highPrice;
                }
                set
                {
                    highPrice = value;
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

            #region double LowPrice
            public double LowPrice
            {
                get
                {
                    return lowPrice;
                }
                set
                {
                    lowPrice = value;
                }
            }
            #endregion

            #region bool MostRecent
            public bool MostRecent
            {
                get
                {
                    return mostRecent;
                }
                set
                {
                    mostRecent = value;
                }
            }
            #endregion

            #region double OpenPrice
            public double OpenPrice
            {
                get
                {
                    return openPrice;
                }
                set
                {
                    openPrice = value;
                }
            }
            #endregion

            #region double PercentChange
            public double PercentChange
            {
                get
                {
                    return percentChange;
                }
                set
                {
                    percentChange = value;
                }
            }
            #endregion

            #region bool PriceUnchanged
            public bool PriceUnchanged
            {
                get
                {
                    return priceUnchanged;
                }
                set
                {
                    priceUnchanged = value;
                }
            }
            #endregion

            #region double Spread
            public double Spread
            {
                get
                {
                    return spread;
                }
                set
                {
                    spread = value;
                }
            }
            #endregion

            #region double SpreadScore
            public double SpreadScore
            {
                get
                {
                    return spreadScore;
                }
                set
                {
                    spreadScore = value;
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

            #region int Volume
            public int Volume
            {
                get
                {
                    return volume;
                }
                set
                {
                    volume = value;
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
