

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
