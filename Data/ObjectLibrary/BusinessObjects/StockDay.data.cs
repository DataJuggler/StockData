

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class StockDay
    public partial class StockDay
    {

        #region Private Variables
        private DateTime date;
        private int id;
        private bool industryProcessed;
        private bool sectorProcessed;
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

                // Date

                // If a valid date
                if (Date.Year > 1900)
                {
                    sb.Append(singleQuote);
                    sb.Append(Date.ToString("yyyy-MM-dd HH:mm:ss"));
                    sb.Append(singleQuote);
                }
                else
                {
                    sb.Append("'1900-01-01'");
                }

                // Add a comma
                sb.Append(comma);

                // IndustryProcessed

                // If IndustryProcessed is true
                if (IndustryProcessed)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }

                // Add a comma
                sb.Append(comma);

                // SectorProcessed

                // If SectorProcessed is true
                if (SectorProcessed)
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
                string insertSQL = "INSERT INTO [StockDay] (Date,IndustryProcessed,SectorProcessed) VALUES (" + valuesList + ") " + Environment.NewLine + "SELECT SCOPE_IDENTITY()" + Environment.NewLine;

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

            #region int Id
            public int Id
            {
                get
                {
                    return id;
                }
            }
            #endregion

            #region bool IndustryProcessed
            public bool IndustryProcessed
            {
                get
                {
                    return industryProcessed;
                }
                set
                {
                    industryProcessed = value;
                }
            }
            #endregion

            #region bool SectorProcessed
            public bool SectorProcessed
            {
                get
                {
                    return sectorProcessed;
                }
                set
                {
                    sectorProcessed = value;
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
