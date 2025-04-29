

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class StockStreak
    public partial class StockStreak
    {

        #region Private Variables
        private bool currentStreak;
        private int id;
        private double percentChange;
        private bool reverseSplit;
        private int reverseSplitDivisor;
        private int stockId;
        private int streakDays;
        private DateTime streakEndDate;
        private double streakEndPrice;
        private DateTime streakStartDate;
        private double streakStartPrice;
        private StreakTypeEnum streakType;
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

                // CurrentStreak

                // If CurrentStreak is true
                if (CurrentStreak)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }

                // Add a comma
                sb.Append(comma);

                // PercentChange

                sb.Append(PercentChange);

                // Add a comma
                sb.Append(comma);

                // ReverseSplit

                // If ReverseSplit is true
                if (ReverseSplit)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }

                // Add a comma
                sb.Append(comma);

                // ReverseSplitDivisor

                sb.Append(ReverseSplitDivisor);

                // Add a comma
                sb.Append(comma);

                // StockId

                sb.Append(StockId);

                // Add a comma
                sb.Append(comma);

                // StreakDays

                sb.Append(StreakDays);

                // Add a comma
                sb.Append(comma);

                // StreakEndDate

                // If a valid date
                if (StreakEndDate.Year > 1900)
                {
                    sb.Append(singleQuote);
                    sb.Append(StreakEndDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    sb.Append(singleQuote);
                }
                else
                {
                    sb.Append("'1900-01-01'");
                }

                // Add a comma
                sb.Append(comma);

                // StreakEndPrice

                sb.Append(StreakEndPrice);

                // Add a comma
                sb.Append(comma);

                // StreakStartDate

                // If a valid date
                if (StreakStartDate.Year > 1900)
                {
                    sb.Append(singleQuote);
                    sb.Append(StreakStartDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    sb.Append(singleQuote);
                }
                else
                {
                    sb.Append("'1900-01-01'");
                }

                // Add a comma
                sb.Append(comma);

                // StreakStartPrice

                sb.Append(StreakStartPrice);

                // Add a comma
                sb.Append(comma);

                // StreakType

                sb.Append(StreakType);

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
                string insertSQL = "INSERT INTO [StockStreak] (CurrentStreak,PercentChange,ReverseSplit,ReverseSplitDivisor,StockId,StreakDays,StreakEndDate,StreakEndPrice,StreakStartDate,StreakStartPrice,StreakType) VALUES (" + valuesList + ") " + Environment.NewLine + "SELECT SCOPE_IDENTITY()" + Environment.NewLine;

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

            #region bool CurrentStreak
            public bool CurrentStreak
            {
                get
                {
                    return currentStreak;
                }
                set
                {
                    currentStreak = value;
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

            #region bool ReverseSplit
            public bool ReverseSplit
            {
                get
                {
                    return reverseSplit;
                }
                set
                {
                    reverseSplit = value;
                }
            }
            #endregion

            #region int ReverseSplitDivisor
            public int ReverseSplitDivisor
            {
                get
                {
                    return reverseSplitDivisor;
                }
                set
                {
                    reverseSplitDivisor = value;
                }
            }
            #endregion

            #region int StockId
            public int StockId
            {
                get
                {
                    return stockId;
                }
                set
                {
                    stockId = value;
                }
            }
            #endregion

            #region int StreakDays
            public int StreakDays
            {
                get
                {
                    return streakDays;
                }
                set
                {
                    streakDays = value;
                }
            }
            #endregion

            #region DateTime StreakEndDate
            public DateTime StreakEndDate
            {
                get
                {
                    return streakEndDate;
                }
                set
                {
                    streakEndDate = value;
                }
            }
            #endregion

            #region double StreakEndPrice
            public double StreakEndPrice
            {
                get
                {
                    return streakEndPrice;
                }
                set
                {
                    streakEndPrice = value;
                }
            }
            #endregion

            #region DateTime StreakStartDate
            public DateTime StreakStartDate
            {
                get
                {
                    return streakStartDate;
                }
                set
                {
                    streakStartDate = value;
                }
            }
            #endregion

            #region double StreakStartPrice
            public double StreakStartPrice
            {
                get
                {
                    return streakStartPrice;
                }
                set
                {
                    streakStartPrice = value;
                }
            }
            #endregion

            #region StreakTypeEnum StreakType
            public StreakTypeEnum StreakType
            {
                get
                {
                    return streakType;
                }
                set
                {
                    streakType = value;
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
