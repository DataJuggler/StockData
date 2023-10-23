

#region using statements

using DataJuggler.Excelerate;
using DataJuggler.Net7;
using DataJuggler.UltimateHelper;
using System;
using System.Collections.Generic;
using DataJuggler.Excelerate.Interfaces;

#endregion

namespace StockData.Objects
{

    #region class AddToDoNotTrack : IExcelerateObject
    public class AddToDoNotTrack : IExcelerateObject
    {

        #region Private Variables
        private string changedColumns;
        private bool loading;
        private Guid rowId;
        private string symbol;
        #endregion

        #region Methods

            #region Load(Row row)
            /// <summary>
            /// This method loads a DoNotTrack object from a Row.
            /// </Summary>
            /// <param name="row">The row which the row.Columns[x].ColumnValue will be used to load this object.</param>
            public void Load(Row row)
            {
                // If the row exists and the row's column collection exists
                if ((NullHelper.Exists(row)) && (row.HasColumns))
                {
                    // Turn Loading On
                    Loading = true;

                    // set values
                    Symbol = row.Columns[0].StringValue;

                    // Turn Loading Off
                    Loading = false;
                }

                // Set RowId
                RowId = row.Id;
            }
            #endregion

            #region Load(Worksheet worksheet)
            /// <summary>
            /// This method loads a list of DoNotTrack objects from a Worksheet.
            /// </Summary>
            /// <param name="worksheet">The worksheet which the rows collection will be used to load a list of DoNotTrack objects.</param>
            public static List<AddToDoNotTrack> Load(Worksheet worksheet)
            {
                // Initial value
                List<AddToDoNotTrack> doNotTrackList = new List<AddToDoNotTrack>();
                
                // If the worksheet exists and the row's collection exists
                if ((NullHelper.Exists(worksheet)) && (worksheet.HasRows))
                {
                    // Iterate the worksheet.Rows collection
                    foreach (Row row in worksheet.Rows)
                    {
                        // If the row is not a HeaderRow and row's column collection exists
                        if ((!row.IsHeaderRow) && (row.HasColumns))
                        {
                            // Create a new instance of a DoNotTrack object.
                            AddToDoNotTrack doNotTrack = new AddToDoNotTrack();
                            
                            // Load this object
                            doNotTrack.Load(row);
                            
                            // Add this object to the list
                            doNotTrackList.Add(doNotTrack);
                        }
                    }
                }
                
                // return value
                return doNotTrackList;
            }
            #endregion

            #region NewRow(Row row)
            /// <summary>
            /// This method creates the columns for the row to save a new DoNotTrack object.
            /// </Summary>
            /// <param name="row">The row which the Columns will be created for.</param>
            public static Row NewRow(int rowNumber)
            {
                // initial value
                Row newRow = new Row();

                // Create Column
                Column symbolColumn = new Column("Symbol", rowNumber, 1, DataManager.DataTypeEnum.String);

                // Add this column
                newRow.Columns.Add(symbolColumn);

                // return value
                return newRow;
            }
            #endregion

            #region Save(Row row)
            /// <summary>
            /// This method saves a DoNotTrack object back to a Row.
            /// </Summary>
            /// <param name="row">The row which the row.Columns[x].ColumnValue will be set to Save back to Excel.</param>
            public Row Save(Row row)
            {
                // If the row exists and the row's column collection exists and the ChangedColumns string is not null or empty
                if ((NullHelper.Exists(row)) && (row.HasColumns) && (TextHelper.Exists(ChangedColumns)))
                {
                    // Parse the changed column indexes
                    List<int> changedColumnIndexes = ExcelHelper.ParseChangedColumnIndexes(ChangedColumns);

                    row.Columns[0].ColumnValue = Symbol;
                    row.Columns[0].HasChanges = changedColumnIndexes.Contains(0);
                }

                // return value
                return row;
            }
            #endregion

        #endregion

        #region Properties

            #region string ChangedColumns
            public string ChangedColumns
            {
                get
                {
                    return changedColumns;
                }
                set
                {
                    changedColumns = value;
                }
            }
            #endregion

            #region bool Loading
            public bool Loading
            {
                get
                {
                    return loading;
                }
                set
                {
                    loading = value;
                }
            }
            #endregion

            #region Guid RowId
            public Guid RowId
            {
                get
                {
                    return rowId;
                }
                set
                {
                    rowId = value;

                    if (!Loading)
                    {
                        ChangedColumns += 1 + ",";
                    }
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

                    if (!Loading)
                    {
                        ChangedColumns += 0 + ",";
                    }
                }
            }
            #endregion

        #endregion

    }
    #endregion

}