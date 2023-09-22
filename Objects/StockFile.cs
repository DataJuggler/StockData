

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace StockData.Objects
{

    #region class StockFile
    /// <summary>
    /// This class [Enter Class Description]
    /// </summary>
    public class StockFile
    {
        
        #region Private Variables
        private DateTime date;
        private string name;
        private string path;
        #endregion

         #region Properties

            #region Date
            /// <summary>
            /// This property gets or sets the value for 'Date'.
            /// </summary>
            public DateTime Date
            {
                get { return date; }
                set { date = value; }
            }
            #endregion
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for 'Name'.
            /// </summary>
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            #endregion
            
            #region Path
            /// <summary>
            /// This property gets or sets the value for 'Path'.
            /// </summary>
            public string Path
            {
                get { return path; }
                set { path = value; }
            }
            #endregion
            
         #endregion
        
    }
    #endregion

}
