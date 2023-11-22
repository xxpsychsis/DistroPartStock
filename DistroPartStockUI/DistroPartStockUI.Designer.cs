namespace DistroPartStockUI
{
    partial class DistroPartStockUI
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
            loginButton = new Button();
            usernameTextBox = new TextBox();
            passwordTextbox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            LoginPanel = new Panel();
            settingsPanel = new GroupBox();
            settingsFilePath = new TextBox();
            browseSettingsFileButton = new Button();
            scrapeButton = new Button();
            exportBox = new GroupBox();
            dataGridView = new DataGridView();
            progressBar = new ProgressBar();
            LoginPanel.SuspendLayout();
            settingsPanel.SuspendLayout();
            exportBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // loginButton
            // 
            loginButton.Location = new Point(6, 85);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(190, 42);
            loginButton.TabIndex = 0;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += LoginButton_Click;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(83, 3);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(114, 23);
            usernameTextBox.TabIndex = 1;
            // 
            // passwordTextbox
            // 
            passwordTextbox.Location = new Point(83, 47);
            passwordTextbox.Name = "passwordTextbox";
            passwordTextbox.Size = new Size(113, 23);
            passwordTextbox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 3;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 54);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 4;
            label2.Text = "Password:";
            // 
            // LoginPanel
            // 
            LoginPanel.Controls.Add(label1);
            LoginPanel.Controls.Add(label2);
            LoginPanel.Controls.Add(loginButton);
            LoginPanel.Controls.Add(passwordTextbox);
            LoginPanel.Controls.Add(usernameTextBox);
            LoginPanel.Location = new Point(12, 12);
            LoginPanel.Name = "LoginPanel";
            LoginPanel.Size = new Size(200, 136);
            LoginPanel.TabIndex = 6;
            // 
            // settingsPanel
            // 
            settingsPanel.Controls.Add(settingsFilePath);
            settingsPanel.Controls.Add(browseSettingsFileButton);
            settingsPanel.Controls.Add(scrapeButton);
            settingsPanel.Location = new Point(12, 12);
            settingsPanel.Name = "settingsPanel";
            settingsPanel.Size = new Size(189, 88);
            settingsPanel.TabIndex = 7;
            settingsPanel.TabStop = false;
            settingsPanel.Text = "Select Phones.json File";
            settingsPanel.Visible = false;
            settingsPanel.Enter += settingsPanel_Enter;
            // 
            // settingsFilePath
            // 
            settingsFilePath.Location = new Point(78, 21);
            settingsFilePath.Name = "settingsFilePath";
            settingsFilePath.Size = new Size(105, 23);
            settingsFilePath.TabIndex = 9;
            settingsFilePath.Text = "C:\\";
            // 
            // browseSettingsFileButton
            // 
            browseSettingsFileButton.Location = new Point(3, 21);
            browseSettingsFileButton.Name = "browseSettingsFileButton";
            browseSettingsFileButton.Size = new Size(69, 23);
            browseSettingsFileButton.TabIndex = 10;
            browseSettingsFileButton.Text = "Browse";
            browseSettingsFileButton.UseVisualStyleBackColor = true;
            browseSettingsFileButton.Click += browseSettingsFileButton_Click;
            // 
            // scrapeButton
            // 
            scrapeButton.Location = new Point(6, 47);
            scrapeButton.Name = "scrapeButton";
            scrapeButton.Size = new Size(183, 36);
            scrapeButton.TabIndex = 8;
            scrapeButton.Text = "Check Stock";
            scrapeButton.UseVisualStyleBackColor = true;
            scrapeButton.Click += ScrapeButton_Click;
            // 
            // exportBox
            // 
            exportBox.Controls.Add(dataGridView);
            exportBox.Location = new Point(217, 13);
            exportBox.Name = "exportBox";
            exportBox.Size = new Size(1026, 428);
            exportBox.TabIndex = 9;
            exportBox.TabStop = false;
            exportBox.Text = "Export";
            exportBox.Visible = false;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(6, 19);
            dataGridView.Name = "dataGridView";
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(1014, 403);
            dataGridView.TabIndex = 10;
            dataGridView.CellContentClick += dataGridView1_CellContentClick;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(8, 107);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(204, 23);
            progressBar.TabIndex = 10;
            progressBar.Visible = false;
            // 
            // DistroPartStockUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1246, 634);
            Controls.Add(progressBar);
            Controls.Add(exportBox);
            Controls.Add(settingsPanel);
            Controls.Add(LoginPanel);
            Name = "DistroPartStockUI";
            Text = "DistroPartStock";
            LoginPanel.ResumeLayout(false);
            LoginPanel.PerformLayout();
            settingsPanel.ResumeLayout(false);
            settingsPanel.PerformLayout();
            exportBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button loginButton;
        private TextBox usernameTextBox;
        private TextBox passwordTextbox;
        private Label label1;
        private Label label2;
        private Panel LoginPanel;
        private GroupBox settingsPanel;
        private Button scrapeButton;
        private GroupBox exportBox;
        private TextBox settingsFilePath;
        private Button browseSettingsFileButton;
        private DataGridView dataGridView;
        private ProgressBar progressBar;
    }
}