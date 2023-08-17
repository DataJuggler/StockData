namespace StockData
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

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
            SuspendLayout();
            // 
            // ImportStocksButton
            // 
            ImportStocksButton.BackColor = Color.Transparent;
            ImportStocksButton.ButtonText = "Import Stocks";
            ImportStocksButton.FlatStyle = FlatStyle.Flat;
            ImportStocksButton.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ImportStocksButton.ForeColor = Color.LemonChiffon;
            ImportStocksButton.Location = new Point(189, 59);
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
            Graph.Location = new Point(12, 198);
            Graph.Name = "Graph";
            Graph.Size = new Size(786, 23);
            Graph.TabIndex = 2;
            Graph.Visible = false;
            // 
            // StatusLabel
            // 
            StatusLabel.BackColor = Color.Transparent;
            StatusLabel.ForeColor = Color.LemonChiffon;
            StatusLabel.Location = new Point(13, 153);
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
            ProcessFilesButton.Location = new Point(427, 59);
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
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.BlackImage;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(838, 262);
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

        private DataJuggler.Win.Controls.LabelTextBoxBrowserControl FileSelector;
        private DataJuggler.Win.Controls.Button ImportStocksButton;
        private ProgressBar Graph;
        private Label StatusLabel;
        private DataJuggler.Win.Controls.Button ProcessFilesButton;
        private Label ExtensionLabel;
        private DataJuggler.Win.Controls.Button HiddenButton;
    }
}