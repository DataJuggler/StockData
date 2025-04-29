

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Admin
    public partial class Admin
    {

        #region Private Variables
        private string documentsFolder;
        private int id;
        private int minVolume;
        private string processedFolder;
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

                // DocumentsFolder

                sb.Append(singleQuote);
                sb.Append(DocumentsFolder);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // MinVolume

                sb.Append(MinVolume);

                // Add a comma
                sb.Append(comma);

                // ProcessedFolder

                sb.Append(singleQuote);
                sb.Append(ProcessedFolder);
                sb.Append(singleQuote);

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
                string insertSQL = "INSERT INTO [Admin] (DocumentsFolder,MinVolume,ProcessedFolder) VALUES (" + valuesList + ") " + Environment.NewLine + "SELECT SCOPE_IDENTITY()" + Environment.NewLine;

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

            #region string DocumentsFolder
            public string DocumentsFolder
            {
                get
                {
                    return documentsFolder;
                }
                set
                {
                    documentsFolder = value;
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

            #region int MinVolume
            public int MinVolume
            {
                get
                {
                    return minVolume;
                }
                set
                {
                    minVolume = value;
                }
            }
            #endregion

            #region string ProcessedFolder
            public string ProcessedFolder
            {
                get
                {
                    return processedFolder;
                }
                set
                {
                    processedFolder = value;
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
