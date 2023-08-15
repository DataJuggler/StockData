

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
