

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class DoNotTrackReader
    /// <summary>
    /// This class loads a single 'DoNotTrack' object or a list of type <DoNotTrack>.
    /// </summary>
    public class DoNotTrackReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'DoNotTrack' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'DoNotTrack' DataObject.</returns>
            public static DoNotTrack Load(DataRow dataRow)
            {
                // Initial Value
                DoNotTrack doNotTrack = new DoNotTrack();

                // Create field Integers
                int idfield = 0;
                int symbolfield = 1;

                try
                {
                    // Load Each field
                    doNotTrack.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    doNotTrack.Symbol = DataHelper.ParseString(dataRow.ItemArray[symbolfield]);
                }
                catch
                {
                }

                // return value
                return doNotTrack;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'DoNotTrack' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A DoNotTrack Collection.</returns>
            public static List<DoNotTrack> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<DoNotTrack> doNotTracks = new List<DoNotTrack>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'DoNotTrack' from rows
                        DoNotTrack doNotTrack = Load(row);

                        // Add this object to collection
                        doNotTracks.Add(doNotTrack);
                    }
                }
                catch
                {
                }

                // return value
                return doNotTracks;
            }
            #endregion

        #endregion

    }
    #endregion

}
