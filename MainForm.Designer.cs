

#region using statements


#endregion

namespace StockData
{

    #region class MainForm
    /// <summary>
    /// This class is the designer for this form
    /// </summary>
    partial class MainForm
    {

        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        private ProgressBar Graph;
        private Label StatusLabel;
        private DataJuggler.Win.Controls.Button ImportStocksButton;
        private DataJuggler.Win.Controls.Button ProcessFilesButton;
        private DataJuggler.Win.Controls.Button HiddenButton;
        private DataJuggler.Win.Controls.Button ImportIndustryButton;
        private DataJuggler.Win.Controls.Button ImportSectorsButton;
        #endregion

        #region Methods

        #region Dispose(bool disposing)
        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region InitializeComponent()
        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            ImportStocksButton = new DataJuggler.Win.Controls.Button();
            Graph = new ProgressBar();
            StatusLabel = new Label();
            ProcessFilesButton = new DataJuggler.Win.Controls.Button();
            HiddenButton = new DataJuggler.Win.Controls.Button();
            ImportIndustryButton = new DataJuggler.Win.Controls.Button();
            ImportSectorsButton = new DataJuggler.Win.Controls.Button();
            DoNotTrackButton = new DataJuggler.Win.Controls.Button();
            WriteDailyReportButton = new DataJuggler.Win.Controls.Button();
            FixPercentChangeButton = new DataJuggler.Win.Controls.Button();
            SuspendLayout();
            // 
            // ImportStocksButton
            // 
            ImportStocksButton.BackColor = Color.Transparent;
            ImportStocksButton.ButtonText = "Import Stocks";
            ImportStocksButton.FlatStyle = FlatStyle.Flat;
            ImportStocksButton.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ImportStocksButton.ForeColor = Color.LemonChiffon;
            ImportStocksButton.Location = new Point(41, 34);
            ImportStocksButton.Margin = new Padding(6, 4, 6, 4);
            ImportStocksButton.Name = "ImportStocksButton";
            ImportStocksButton.Size = new Size(177, 46);
            ImportStocksButton.TabIndex = 1;
            ImportStocksButton.TextAlign = ContentAlignment.MiddleCenter;
            ImportStocksButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            ImportStocksButton.Click += ImportStocksButton_Click;
            // 
            // Graph
            // 
            Graph.Location = new Point(12, 266);
            Graph.Name = "Graph";
            Graph.Size = new Size(786, 23);
            Graph.TabIndex = 2;
            Graph.Visible = false;
            // 
            // StatusLabel
            // 
            StatusLabel.BackColor = Color.Transparent;
            StatusLabel.ForeColor = Color.LemonChiffon;
            StatusLabel.Location = new Point(13, 221);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(785, 29);
            StatusLabel.TabIndex = 3;
            StatusLabel.Text = "Status:";
            StatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            StatusLabel.Visible = false;
            // 
            // ProcessFilesButton
            // 
            ProcessFilesButton.BackColor = Color.Transparent;
            ProcessFilesButton.ButtonText = "Process Files";
            ProcessFilesButton.FlatStyle = FlatStyle.Flat;
            ProcessFilesButton.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ProcessFilesButton.ForeColor = Color.LemonChiffon;
            ProcessFilesButton.Location = new Point(588, 34);
            ProcessFilesButton.Margin = new Padding(6, 4, 6, 4);
            ProcessFilesButton.Name = "ProcessFilesButton";
            ProcessFilesButton.Size = new Size(177, 46);
            ProcessFilesButton.TabIndex = 4;
            ProcessFilesButton.TextAlign = ContentAlignment.MiddleCenter;
            ProcessFilesButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            ProcessFilesButton.Click += ProcessFilesButton_Click;
            // 
            // HiddenButton
            // 
            HiddenButton.BackColor = Color.Transparent;
            HiddenButton.ButtonText = "Import Stocks";
            HiddenButton.FlatStyle = FlatStyle.Flat;
            HiddenButton.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            HiddenButton.ForeColor = Color.LemonChiffon;
            HiddenButton.Location = new Point(-600, -600);
            HiddenButton.Margin = new Padding(6, 4, 6, 4);
            HiddenButton.Name = "HiddenButton";
            HiddenButton.Size = new Size(177, 46);
            HiddenButton.TabIndex = 5;
            HiddenButton.TextAlign = ContentAlignment.MiddleCenter;
            HiddenButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            // 
            // ImportIndustryButton
            // 
            ImportIndustryButton.BackColor = Color.Transparent;
            ImportIndustryButton.ButtonText = "Import Industries";
            ImportIndustryButton.FlatStyle = FlatStyle.Flat;
            ImportIndustryButton.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ImportIndustryButton.ForeColor = Color.LemonChiffon;
            ImportIndustryButton.Location = new Point(41, 99);
            ImportIndustryButton.Margin = new Padding(6, 4, 6, 4);
            ImportIndustryButton.Name = "ImportIndustryButton";
            ImportIndustryButton.Size = new Size(177, 46);
            ImportIndustryButton.TabIndex = 6;
            ImportIndustryButton.TextAlign = ContentAlignment.MiddleCenter;
            ImportIndustryButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            ImportIndustryButton.Click += ImportIndustryButton_Click;
            // 
            // ImportSectorsButton
            // 
            ImportSectorsButton.BackColor = Color.Transparent;
            ImportSectorsButton.ButtonText = "Import Sectors";
            ImportSectorsButton.FlatStyle = FlatStyle.Flat;
            ImportSectorsButton.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ImportSectorsButton.ForeColor = Color.LemonChiffon;
            ImportSectorsButton.Location = new Point(245, 99);
            ImportSectorsButton.Margin = new Padding(6, 4, 6, 4);
            ImportSectorsButton.Name = "ImportSectorsButton";
            ImportSectorsButton.Size = new Size(177, 46);
            ImportSectorsButton.TabIndex = 7;
            ImportSectorsButton.TextAlign = ContentAlignment.MiddleCenter;
            ImportSectorsButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            ImportSectorsButton.Click += ImportSectorsButton_Click;
            // 
            // DoNotTrackButton
            // 
            DoNotTrackButton.BackColor = Color.Transparent;
            DoNotTrackButton.ButtonText = "Update Do Not Track";
            DoNotTrackButton.FlatStyle = FlatStyle.Flat;
            DoNotTrackButton.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            DoNotTrackButton.ForeColor = Color.LemonChiffon;
            DoNotTrackButton.Location = new Point(245, 34);
            DoNotTrackButton.Margin = new Padding(6, 4, 6, 4);
            DoNotTrackButton.Name = "DoNotTrackButton";
            DoNotTrackButton.Size = new Size(217, 46);
            DoNotTrackButton.TabIndex = 8;
            DoNotTrackButton.TextAlign = ContentAlignment.MiddleCenter;
            DoNotTrackButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            DoNotTrackButton.Click += DoNotTrackButton_Click;
            // 
            // WriteDailyReportButton
            // 
            WriteDailyReportButton.BackColor = Color.Transparent;
            WriteDailyReportButton.ButtonText = "Create Daily Report";
            WriteDailyReportButton.FlatStyle = FlatStyle.Flat;
            WriteDailyReportButton.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            WriteDailyReportButton.ForeColor = Color.LemonChiffon;
            WriteDailyReportButton.Location = new Point(516, 99);
            WriteDailyReportButton.Margin = new Padding(6, 4, 6, 4);
            WriteDailyReportButton.Name = "WriteDailyReportButton";
            WriteDailyReportButton.Size = new Size(249, 46);
            WriteDailyReportButton.TabIndex = 9;
            WriteDailyReportButton.TextAlign = ContentAlignment.MiddleCenter;
            WriteDailyReportButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            WriteDailyReportButton.Click += WriteDailyReportButton_Click;
            // 
            // FixPercentChangeButton
            // 
            FixPercentChangeButton.BackColor = Color.Transparent;
            FixPercentChangeButton.ButtonText = "Fix Percent Change";
            FixPercentChangeButton.FlatStyle = FlatStyle.Flat;
            FixPercentChangeButton.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            FixPercentChangeButton.ForeColor = Color.LemonChiffon;
            FixPercentChangeButton.Location = new Point(41, 167);
            FixPercentChangeButton.Margin = new Padding(6, 4, 6, 4);
            FixPercentChangeButton.Name = "FixPercentChangeButton";
            FixPercentChangeButton.Size = new Size(195, 46);
            FixPercentChangeButton.TabIndex = 10;
            FixPercentChangeButton.TextAlign = ContentAlignment.MiddleCenter;
            FixPercentChangeButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Dark;
            FixPercentChangeButton.Click += FixPercentChangeButton_Click;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.BlackImage;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(838, 312);
            Controls.Add(FixPercentChangeButton);
            Controls.Add(WriteDailyReportButton);
            Controls.Add(DoNotTrackButton);
            Controls.Add(ImportSectorsButton);
            Controls.Add(ImportIndustryButton);
            Controls.Add(HiddenButton);
            Controls.Add(ProcessFilesButton);
            Controls.Add(StatusLabel);
            Controls.Add(Graph);
            Controls.Add(ImportStocksButton);
            DoubleBuffered = true;
            Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stock Data 1.0.0";
            ResumeLayout(false);
        }
        #endregion

        #endregion

        private DataJuggler.Win.Controls.Button DoNotTrackButton;
        private DataJuggler.Win.Controls.Button WriteDailyReportButton;
        private DataJuggler.Win.Controls.Button FixPercentChangeButton;
    }
    #endregion

}
