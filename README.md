
7.24.2023: New Video

The Best C# Excel Library In The Galaxy
https://youtu.be/uWXiz52cqlg

# DataJuggler.StockData
StockData is a WinForms app designed to make it easy to load and save Excel objects 
that were created using<br><br>

Blazor Excelerate<br>

https://excelerate.datajuggler.com<br>
Code Generate C# Classes From Excel Header Rows

# Instructions to run this project:

To Install Via Nuget and DOT NET CLI, navigate to the folder you wish to create your project in

    cd c:\Projects\StockData
    dotnet new install DataJuggler.StockData
    dotnet new DataJuggler.StockData

or

Clone this project from GitHub https://github.com/DataJuggler/StockData

# Setup Instructions

1. Create one or more classes from Excel Header Rows at<br><br>

Blazor Excelerate<br>
https://excelerate.datajuggler.com<br>

Download the file MemberData.xlsx from the above site to see an example.
Use StockData.Objects for the namespace or rename this project to your liking
 
2. Copy the classes created into the Objects folder of StockData

3. Load Excel Worksheet(s) - Example is included in the UpdateButton_Click event
	
       // load your object(s)
       string workbookPath = FileSelector.Text;

       // Example WorksheetInfo objects           
       WorksheetInfo info = new WorksheetInfo();
       info.LoadColumnOptions = LoadColumnOptionsEnum.LoadAllColumnsExceptExcluded;
       info.Path = workbookPath;	

       // Set your SheetName
       info.SheetName = "Address";

       // Example WorksheetInfo objects           
       WorksheetInfo info2 = new WorksheetInfo();
       info2.LoadColumnOptions = LoadColumnOptionsEnum.LoadAllColumnsExceptExcluded;
       info2.Path = workbookPath;

       // Set the SheetName for info2
       info2.SheetName = 'States";

       // Example load Worksheets
       Worksheet addressWorksheet = ExcelDataLoader.LoadWorksheet(workbookPath, info);
       Worksheet statesWorksheet = ExcelDataLoader.LoadWorksheet(workbookPath, info2);

5. Load your list of objects
 
        // Examples loading the Address and States sheet from MemberData.xlsx
        List<Address> addresses = Address.Load(addressWorksheet);
        List<States> states = States.Load(statesWorksheet);

6. Perform updates on your List of objects

   For this example, I inserted a column StateName into the Address sheet in Excel and
   added a few state names manually. You must add a few entries so the data type can be
   attempted to be determined. Then I code generated Address and States classes using
   Blazor Excelerate<br>
   https://excelerate.datajuggler.com

   This method set the Address.StateName for each row by looking up the State Name by StateId
	
       /// <summary>
       /// Lookup the StateName for each Address object by StateId
       /// </summary>
       public void FixStateNames(ref List<Address> addresses, List<States> states)
       {
           // verify both lists exists and have at least one item
           if (ListHelper.HasOneOrMoreItems(addresses, states))
           {
              // Iterate the collection of Address objects
              foreach (Address address in addresses)
              {
                  // get a local copy
                  int stateId = address.StateId;

                  // set the stateName
                  address.StateName = states.Where(x => x.Id == stateId).FirstOrDefault().Name;

                  // Increment the value for Graph
                  Graph.Value++;

                  // update the UI every 100
                  if (Graph.Value % 100 == 0)
                  {
                      Refresh();
                      Application.DoEvents();
                   }
              }
           }
        }
	
7. Save your worksheet back to Excel

       // resetup the graph                    
       Graph.Maximum = addresses.Count;
       Graph.Value = 0;

       // change the text
       StatusLabel.Text = "Saving Addresses please wait...";

       // you must convert the list objects to List<IExcelerateObject> before it can be saved
       List<IExcelerateObject> excelerateObjectList = addresses.Cast<IExcelerateObject>().ToList();

       // Now save the worksheet
       SaveWorksheetResponse response = ExcelHelper.SaveWorksheet(excelerateObjectList, addressWorksheet, info, SaveWorksheetCallback, 500);

8. (Optional) Leave a Star on DataJuggler.Excelerate, Blazor Excelerate or this project on GitHub

    DataJuggler.Excelerate
    https://github.com/DataJuggler/Excelerate

    Blazor Excelerate
    https://github.com/DataJuggler/Blazor.Excelerate
	
    Excelerate Win App
    https://github.com/DataJuggler/StockData

9. (Optional) Subscribe to my YouTube channel
    https://youtube.com/DataJuggler

# News

1.0.5:
7.24.203: Some bug fixes were found when I made this video. The project seems pretty stable.

7.24.2023: New Video

The Best C# Excel Library In The Galaxy
https://youtu.be/uWXiz52cqlg

Also, NuGet package DataJuggler.Excelerate was updated with links to this project.

1.0.0
7.23.2023: First Working Version Released

