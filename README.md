
8.15.2023: StockData is checked into GitHub

# Video for how this project was built

Create a Stock Predictor with C# and ML.NET Part I
https://youtu.be/hF8LkvwOXQY

# Setup Instructions

1. Create a SQL Server database named StockData and execute StockDataDatabase.sql located in the SQL folder.
2. Create a connection string * and set a User level environment variable named StockDataConnString and 
set the connection string as the value.
3. Copy the NASDAQ.txt and NYSE.txt files from the ProcessedFolder, to the Documents folder.
4. If you ever need to rerun the files, repeat step 3 and excecute ResetStocks.sql and 
DropAndCreateDailyPriceDataAndStockStreak.sql, which are both located in the SQL folder of this project.
5. Import Stocks before you process the files.

The site eoddata.com is used to create the NASDAQ.txt and NYSE.txt files. I download the latest two files
every night. 

* DataTier.Net, which built the data tier this project uses, comes with a tool called Connection Builder and
you will probably think it is wortht the price (of free).

# Copied from ExcelerateWinApp

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

To Install ExcelerateWinApp via Nuget and DOT NET CLI, navigate to the folder you wish to create your project in

    cd c:\Projects\ExcelerateWinApp
    dotnet new install DataJuggler.Excelerate
    dotnet new DataJuggler.Excelerate

# Update 8.24.2023

I perform the following query to find stocks that are no longer listed
Change the date to the last date you have data for.

Select * From StockStreak Where CurrentStreak = 1
And StreakEndDate < '2023-08-23' 

I also added a stored procedure to delete the stock from the following tables
Stock, StockStreak, DailyPriceData

Exec RemoveStock @StockId

# How the Stocks were imported

1. The project has two .xlsx files located in Documents\Stocks of this project.
The .xlsx files were created using NASDAQ.com https://www.nasdaq.com/market-activity/stocks/screener 
The two Excel files were created by saving the .csv for NASDAQ and NYSE in Excel as a .xlsx extension.

The C# classes were code generated from

Blazor Excelerate<br>
https://excelerate.datajuggler.com<br>

Use StockData.Objects for the namespace or rename this project to your liking
 
2. Copy the classes created into the Objects folder of StockData (this is already done for this project)

3. Load Excel Worksheet(s) - Example is included Import Stocks button click event.
	
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

