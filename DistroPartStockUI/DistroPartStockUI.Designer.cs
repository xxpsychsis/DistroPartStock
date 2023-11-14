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
            scrapeButton = new Button();
            samsungGalaxyS23Fe = new CheckBox();
            browseButton = new Button();
            filePath = new TextBox();
            exportBox = new GroupBox();
            exportButton = new Button();
            LoginPanel.SuspendLayout();
            settingsPanel.SuspendLayout();
            exportBox.SuspendLayout();
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
            settingsPanel.Controls.Add(scrapeButton);
            settingsPanel.Controls.Add(samsungGalaxyS23Fe);
            settingsPanel.Location = new Point(218, 8);
            settingsPanel.Name = "settingsPanel";
            settingsPanel.Size = new Size(189, 426);
            settingsPanel.TabIndex = 7;
            settingsPanel.TabStop = false;
            settingsPanel.Text = "Settings";
            settingsPanel.Visible = false;
            settingsPanel.Enter += settingsPanel_Enter;
            // 
            // scrapeButton
            // 
            scrapeButton.Location = new Point(6, 390);
            scrapeButton.Name = "scrapeButton";
            scrapeButton.Size = new Size(183, 36);
            scrapeButton.TabIndex = 8;
            scrapeButton.Text = "Scrape";
            scrapeButton.UseVisualStyleBackColor = true;
            scrapeButton.Click += ScrapeButton_Click;
            // 
            // samsungGalaxyS23Fe
            // 
            samsungGalaxyS23Fe.AutoSize = true;
            samsungGalaxyS23Fe.Location = new Point(6, 22);
            samsungGalaxyS23Fe.Name = "samsungGalaxyS23Fe";
            samsungGalaxyS23Fe.Size = new Size(143, 19);
            samsungGalaxyS23Fe.TabIndex = 0;
            samsungGalaxyS23Fe.Text = "Samsung GalaxyS23FE";
            samsungGalaxyS23Fe.UseVisualStyleBackColor = true;
            // 
            // browseButton
            // 
            browseButton.Location = new Point(6, 22);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(75, 23);
            browseButton.TabIndex = 1;
            browseButton.Text = "Browse";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += BrowseButton_Click;
            // 
            // filePath
            // 
            filePath.Location = new Point(87, 22);
            filePath.Name = "filePath";
            filePath.Size = new Size(113, 23);
            filePath.TabIndex = 0;
            filePath.Text = "C:\\";
            // 
            // exportBox
            // 
            exportBox.Controls.Add(exportButton);
            exportBox.Controls.Add(filePath);
            exportBox.Controls.Add(browseButton);
            exportBox.Location = new Point(425, 10);
            exportBox.Name = "exportBox";
            exportBox.Size = new Size(200, 101);
            exportBox.TabIndex = 9;
            exportBox.TabStop = false;
            exportBox.Text = "Export";
            exportBox.Visible = false;
            // 
            // exportButton
            // 
            exportButton.Location = new Point(6, 51);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(194, 43);
            exportButton.TabIndex = 2;
            exportButton.Text = "Export";
            exportButton.UseVisualStyleBackColor = true;
            exportButton.Click += ExportButton_Click;
            // 
            // DistroPartStockUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(exportBox);
            Controls.Add(settingsPanel);
            Controls.Add(LoginPanel);
            Name = "DistroPartStockUI";
            Text = "Form1";
            LoginPanel.ResumeLayout(false);
            LoginPanel.PerformLayout();
            settingsPanel.ResumeLayout(false);
            settingsPanel.PerformLayout();
            exportBox.ResumeLayout(false);
            exportBox.PerformLayout();
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
        private CheckBox samsungGalaxyS23Fe;
        private Button browseButton;
        private TextBox filePath;
        private GroupBox exportBox;
        private Button exportButton;
    }
}