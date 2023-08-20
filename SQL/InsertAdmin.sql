Use [StockData]

-- Change the values to where your project was cloned to.
-- My project is in C:\Projects\GitHub\StockData'.

Declare @DocumentsFolder nvarchar(256)
Declare @MinVolume int
Declare @ProcessedFolder nvarchar(256)

-- Set the values
Set @DocumentsFolder = 'C:\Projects\GitHub\StockData\Documents\'
Set @MinVolume = 100000
Set @ProcessedFolder = 'C:\Projects\GitHub\StockData\Documents\Processed\'

Exec Admin_Insert @DocumentsFolder, @MinVolume, @ProcessedFolder




