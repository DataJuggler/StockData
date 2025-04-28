

#region using statements

using DataJuggler.Excelerate;
using DataJuggler.NET9;
using DataJuggler.UltimateHelper;
using System;
using System.Collections.Generic;
using DataJuggler.Excelerate.Interfaces;

#endregion

namespace StockData.Objects
{

    #region class Sector : IExcelerateObject
    public class Sector : IExcelerateObject
    {

        #region Private Variables
        private string changedColumns;
        private bool loading;
        private string name;
        private Guid rowId;
        #endregion

        #region Methods

            #region Load(Row row)
            /// <summary>
            /// This method loads a Sector object from a Row.
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
                    Name = row.Columns[0].StringValue;

                    // Turn Loading Off
                    Loading = false;
                }

                // Set RowId
                RowId = row.Id;
            }
            #endregion

            #region Load(Worksheet worksheet)
            /// <summary>
            /// This method loads a list of Sector objects from a Worksheet.
            /// </Summary>
            /// <param name="worksheet">The worksheet which the rows collection will be used to load a list of Sector objects.</param>
            public static List<Sector> Load(Worksheet worksheet)
            {
                // Initial value
                List<Sector> sectorList = new List<Sector>();
                
                // If the worksheet exists and the row's collection exists
                if ((NullHelper.Exists(worksheet)) && (worksheet.HasRows))
                {
                    // Iterate the worksheet.Rows collection
                    foreach (Row row in worksheet.Rows)
                    {
                        // If the row is not a HeaderRow and row's column collection exists
                        if ((!row.IsHeaderRow) && (row.HasColumns))
                        {
                            // Create a new instance of a Sector object.
                            Sector sector = new Sector();
                            
                            // Load this object
                            sector.Load(row);
                            
                            // Add this object to the list
                            sectorList.Add(sector);
                        }
                    }
                }
                
                // return value
                return sectorList;
            }
            #endregion

            #region NewRow(Row row)
            /// <summary>
            /// This method creates the columns for the row to save a new Sector object.
            /// </Summary>
            /// <param name="row">The row which the Columns will be created for.</param>
            public static Row NewRow(int rowNumber)
            {
                // initial value
                Row newRow = new Row();

                // Create Column
                Column nameColumn = new Column("Name", rowNumber, 1, DataManager.DataTypeEnum.String);

                // Add this column
                newRow.Columns.Add(nameColumn);

                // return value
                return newRow;
            }
            #endregion

            #region Save(Row row)
            /// <summary>
            /// This method saves a Sector object back to a Row.
            /// </Summary>
            /// <param name="row">The row which the row.Columns[x].ColumnValue will be set to Save back to Excel.</param>
            public Row Save(Row row)
            {
                // If the row exists and the row's column collection exists and the ChangedColumns string is not null or empty
                if ((NullHelper.Exists(row)) && (row.HasColumns) && (TextHelper.Exists(ChangedColumns)))
                {
                    // Parse the changed column indexes
                    List<int> changedColumnIndexes = ExcelHelper.ParseChangedColumnIndexes(ChangedColumns);

                    row.Columns[0].ColumnValue = Name;
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

            #region string Name
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;

                    if (!Loading)
                    {
                        ChangedColumns += 0 + ",";
                    }
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

        #endregion

    }
    #endregion

}