

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class AdminReader
    /// <summary>
    /// This class loads a single 'Admin' object or a list of type <Admin>.
    /// </summary>
    public class AdminReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'Admin' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'Admin' DataObject.</returns>
            public static Admin Load(DataRow dataRow)
            {
                // Initial Value
                Admin admin = new Admin();

                // Create field Integers
                int documentsFolderfield = 0;
                int idfield = 1;
                int minVolumefield = 2;
                int processedFolderfield = 3;

                try
                {
                    // Load Each field
                    admin.DocumentsFolder = DataHelper.ParseString(dataRow.ItemArray[documentsFolderfield]);
                    admin.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    admin.MinVolume = DataHelper.ParseInteger(dataRow.ItemArray[minVolumefield], 0);
                    admin.ProcessedFolder = DataHelper.ParseString(dataRow.ItemArray[processedFolderfield]);
                }
                catch
                {
                }

                // return value
                return admin;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'Admin' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A Admin Collection.</returns>
            public static List<Admin> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<Admin> admins = new List<Admin>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'Admin' from rows
                        Admin admin = Load(row);

                        // Add this object to collection
                        admins.Add(admin);
                    }
                }
                catch
                {
                }

                // return value
                return admins;
            }
            #endregion

        #endregion

    }
    #endregion

}
