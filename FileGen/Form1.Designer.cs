namespace FileGen
{
    partial class Form1
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label4 = new Label();
            restrictionType = new ComboBox();
            tabPage2 = new TabPage();
            onlyShowWindowed = new CheckBox();
            addSelectedToBlackList = new Button();
            addSelectedToWhitelist = new Button();
            label1 = new Label();
            RefreshProcessList = new Button();
            allProcesses = new CheckedListBox();
            tabPage6 = new TabPage();
            refreshWhiteAndBlacklistButton = new Button();
            addToBlacklistFromInput = new Button();
            addToBlacklistInputBox = new TextBox();
            removeSelectedFromBlacklist = new Button();
            blacklistDisplay = new CheckedListBox();
            label3 = new Label();
            addToWhitelistFromInput = new Button();
            addToWhitelistInputBox = new TextBox();
            removeSelectedFromWhitelist = new Button();
            whitelistDisplay = new CheckedListBox();
            label2 = new Label();
            tabPage3 = new TabPage();
            label5 = new Label();
            checkBox1 = new CheckBox();
            tabPage4 = new TabPage();
            allowSystemProcesses = new CheckBox();
            storeTimeInAppdataCheckbox = new CheckBox();
            restrictBgProcesses = new CheckBox();
            tabPage5 = new TabPage();
            linkLabel1 = new LinkLabel();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            saveFileButton = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage6.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage5.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage6);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1191, 613);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(restrictionType);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1183, 575);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Main";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 17);
            label4.Name = "label4";
            label4.Size = new Size(136, 25);
            label4.TabIndex = 1;
            label4.Text = "Restriction Type";
            // 
            // restrictionType
            // 
            restrictionType.FormattingEnabled = true;
            restrictionType.Items.AddRange(new object[] { "Whitelist", "Blacklist", "Both" });
            restrictionType.Location = new Point(8, 45);
            restrictionType.Name = "restrictionType";
            restrictionType.Size = new Size(182, 33);
            restrictionType.TabIndex = 0;
            restrictionType.SelectedIndexChanged += restrictionType_SelectedIndexChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(onlyShowWindowed);
            tabPage2.Controls.Add(addSelectedToBlackList);
            tabPage2.Controls.Add(addSelectedToWhitelist);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(RefreshProcessList);
            tabPage2.Controls.Add(allProcesses);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1183, 575);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Processes";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // onlyShowWindowed
            // 
            onlyShowWindowed.AutoSize = true;
            onlyShowWindowed.Checked = true;
            onlyShowWindowed.CheckState = CheckState.Checked;
            onlyShowWindowed.Location = new Point(824, 6);
            onlyShowWindowed.Name = "onlyShowWindowed";
            onlyShowWindowed.Size = new Size(215, 29);
            onlyShowWindowed.TabIndex = 5;
            onlyShowWindowed.Text = "Only Show Windowed";
            onlyShowWindowed.UseVisualStyleBackColor = true;
            onlyShowWindowed.CheckedChanged += onlyShowWindowed_CheckedChanged;
            // 
            // addSelectedToBlackList
            // 
            addSelectedToBlackList.Location = new Point(8, 501);
            addSelectedToBlackList.Name = "addSelectedToBlackList";
            addSelectedToBlackList.Size = new Size(528, 71);
            addSelectedToBlackList.TabIndex = 4;
            addSelectedToBlackList.Text = "Add selected to blacklist";
            addSelectedToBlackList.UseVisualStyleBackColor = true;
            addSelectedToBlackList.Click += addSelectedToBlackList_Click;
            // 
            // addSelectedToWhitelist
            // 
            addSelectedToWhitelist.Location = new Point(625, 501);
            addSelectedToWhitelist.Name = "addSelectedToWhitelist";
            addSelectedToWhitelist.Size = new Size(552, 71);
            addSelectedToWhitelist.TabIndex = 3;
            addSelectedToWhitelist.Text = "Add selected to whitelist";
            addSelectedToWhitelist.UseVisualStyleBackColor = true;
            addSelectedToWhitelist.Click += addSelectedToWhitelist_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 7);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(240, 25);
            label1.TabIndex = 2;
            label1.Text = "Currently Running Processes:";
            label1.Click += label1_Click;
            // 
            // RefreshProcessList
            // 
            RefreshProcessList.Location = new Point(1069, 3);
            RefreshProcessList.Name = "RefreshProcessList";
            RefreshProcessList.Size = new Size(111, 33);
            RefreshProcessList.TabIndex = 1;
            RefreshProcessList.Text = "Refresh";
            RefreshProcessList.UseVisualStyleBackColor = true;
            RefreshProcessList.Click += RefreshProcessList_Click;
            // 
            // allProcesses
            // 
            allProcesses.CheckOnClick = true;
            allProcesses.FormattingEnabled = true;
            allProcesses.Location = new Point(0, 43);
            allProcesses.Name = "allProcesses";
            allProcesses.Size = new Size(1181, 452);
            allProcesses.TabIndex = 0;
            allProcesses.SelectedIndexChanged += allProcesses_SelectedIndexChanged;
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(refreshWhiteAndBlacklistButton);
            tabPage6.Controls.Add(addToBlacklistFromInput);
            tabPage6.Controls.Add(addToBlacklistInputBox);
            tabPage6.Controls.Add(removeSelectedFromBlacklist);
            tabPage6.Controls.Add(blacklistDisplay);
            tabPage6.Controls.Add(label3);
            tabPage6.Controls.Add(addToWhitelistFromInput);
            tabPage6.Controls.Add(addToWhitelistInputBox);
            tabPage6.Controls.Add(removeSelectedFromWhitelist);
            tabPage6.Controls.Add(whitelistDisplay);
            tabPage6.Controls.Add(label2);
            tabPage6.Location = new Point(4, 34);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new Size(1183, 575);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "Lists";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // refreshWhiteAndBlacklistButton
            // 
            refreshWhiteAndBlacklistButton.Location = new Point(537, 241);
            refreshWhiteAndBlacklistButton.Name = "refreshWhiteAndBlacklistButton";
            refreshWhiteAndBlacklistButton.Size = new Size(112, 34);
            refreshWhiteAndBlacklistButton.TabIndex = 10;
            refreshWhiteAndBlacklistButton.Text = "Refresh";
            refreshWhiteAndBlacklistButton.UseVisualStyleBackColor = true;
            refreshWhiteAndBlacklistButton.Click += refreshWhiteAndBlacklistButton_Click;
            // 
            // addToBlacklistFromInput
            // 
            addToBlacklistFromInput.Location = new Point(903, 516);
            addToBlacklistFromInput.Name = "addToBlacklistFromInput";
            addToBlacklistFromInput.Size = new Size(173, 34);
            addToBlacklistFromInput.TabIndex = 9;
            addToBlacklistFromInput.Text = "Add to Blacklist";
            addToBlacklistFromInput.UseVisualStyleBackColor = true;
            addToBlacklistFromInput.Click += addToBlacklistFromInput_Click;
            // 
            // addToBlacklistInputBox
            // 
            addToBlacklistInputBox.Location = new Point(805, 479);
            addToBlacklistInputBox.Name = "addToBlacklistInputBox";
            addToBlacklistInputBox.Size = new Size(373, 31);
            addToBlacklistInputBox.TabIndex = 8;
            addToBlacklistInputBox.TextChanged += addToBlacklistInputBox_TextChanged;
            // 
            // removeSelectedFromBlacklist
            // 
            removeSelectedFromBlacklist.Location = new Point(875, 439);
            removeSelectedFromBlacklist.Name = "removeSelectedFromBlacklist";
            removeSelectedFromBlacklist.Size = new Size(226, 34);
            removeSelectedFromBlacklist.TabIndex = 7;
            removeSelectedFromBlacklist.Text = "Remove Selected";
            removeSelectedFromBlacklist.UseVisualStyleBackColor = true;
            removeSelectedFromBlacklist.Click += removeSelectedFromBlacklist_Click;
            // 
            // blacklistDisplay
            // 
            blacklistDisplay.CheckOnClick = true;
            blacklistDisplay.FormattingEnabled = true;
            blacklistDisplay.Location = new Point(805, 37);
            blacklistDisplay.Name = "blacklistDisplay";
            blacklistDisplay.Size = new Size(373, 396);
            blacklistDisplay.TabIndex = 6;
            blacklistDisplay.SelectedIndexChanged += blacklistDisplay_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(805, 9);
            label3.Name = "label3";
            label3.Size = new Size(74, 25);
            label3.TabIndex = 5;
            label3.Text = "Blacklist";
            // 
            // addToWhitelistFromInput
            // 
            addToWhitelistFromInput.Location = new Point(106, 516);
            addToWhitelistFromInput.Name = "addToWhitelistFromInput";
            addToWhitelistFromInput.Size = new Size(173, 34);
            addToWhitelistFromInput.TabIndex = 4;
            addToWhitelistFromInput.Text = "Add to Whitelist";
            addToWhitelistFromInput.UseVisualStyleBackColor = true;
            addToWhitelistFromInput.Click += addToWhitelistFromInput_Click;
            // 
            // addToWhitelistInputBox
            // 
            addToWhitelistInputBox.Location = new Point(8, 479);
            addToWhitelistInputBox.Name = "addToWhitelistInputBox";
            addToWhitelistInputBox.Size = new Size(373, 31);
            addToWhitelistInputBox.TabIndex = 3;
            addToWhitelistInputBox.TextChanged += addToWhitelistInputBox_TextChanged;
            // 
            // removeSelectedFromWhitelist
            // 
            removeSelectedFromWhitelist.Location = new Point(78, 439);
            removeSelectedFromWhitelist.Name = "removeSelectedFromWhitelist";
            removeSelectedFromWhitelist.Size = new Size(226, 34);
            removeSelectedFromWhitelist.TabIndex = 2;
            removeSelectedFromWhitelist.Text = "Remove Selected";
            removeSelectedFromWhitelist.UseVisualStyleBackColor = true;
            removeSelectedFromWhitelist.Click += removeSelectedFromWhitelist_Click;
            // 
            // whitelistDisplay
            // 
            whitelistDisplay.CheckOnClick = true;
            whitelistDisplay.FormattingEnabled = true;
            whitelistDisplay.Location = new Point(8, 37);
            whitelistDisplay.Name = "whitelistDisplay";
            whitelistDisplay.Size = new Size(373, 396);
            whitelistDisplay.TabIndex = 1;
            whitelistDisplay.SelectedIndexChanged += whitelistDisplay_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 9);
            label2.Name = "label2";
            label2.Size = new Size(80, 25);
            label2.TabIndex = 0;
            label2.Text = "Whitelist";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label5);
            tabPage3.Controls.Add(checkBox1);
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1183, 575);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Limits";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(64, 209);
            label5.Name = "label5";
            label5.Size = new Size(979, 128);
            label5.TabIndex = 1;
            label5.Text = "!!!Disabled b/c bugs!!!";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(8, 6);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(118, 29);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Use Limits";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(allowSystemProcesses);
            tabPage4.Controls.Add(storeTimeInAppdataCheckbox);
            tabPage4.Controls.Add(restrictBgProcesses);
            tabPage4.Location = new Point(4, 34);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1183, 575);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Extra";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // allowSystemProcesses
            // 
            allowSystemProcesses.AutoSize = true;
            allowSystemProcesses.Checked = true;
            allowSystemProcesses.CheckState = CheckState.Checked;
            allowSystemProcesses.Location = new Point(7, 88);
            allowSystemProcesses.Name = "allowSystemProcesses";
            allowSystemProcesses.Size = new Size(354, 29);
            allowSystemProcesses.TabIndex = 2;
            allowSystemProcesses.Text = "Always allow system required processes";
            allowSystemProcesses.UseVisualStyleBackColor = true;
            allowSystemProcesses.CheckedChanged += allowSystemProcesses_CheckedChanged;
            // 
            // storeTimeInAppdataCheckbox
            // 
            storeTimeInAppdataCheckbox.AutoSize = true;
            storeTimeInAppdataCheckbox.Location = new Point(8, 49);
            storeTimeInAppdataCheckbox.Name = "storeTimeInAppdataCheckbox";
            storeTimeInAppdataCheckbox.Size = new Size(248, 29);
            storeTimeInAppdataCheckbox.TabIndex = 1;
            storeTimeInAppdataCheckbox.Text = "Store time limit in appdata";
            storeTimeInAppdataCheckbox.UseVisualStyleBackColor = true;
            storeTimeInAppdataCheckbox.CheckedChanged += storeTimeInAppdataCheckbox_CheckedChanged;
            // 
            // restrictBgProcesses
            // 
            restrictBgProcesses.AutoSize = true;
            restrictBgProcesses.Location = new Point(8, 14);
            restrictBgProcesses.Name = "restrictBgProcesses";
            restrictBgProcesses.Size = new Size(277, 29);
            restrictBgProcesses.TabIndex = 0;
            restrictBgProcesses.Text = "Restrict Background Processes";
            restrictBgProcesses.UseVisualStyleBackColor = true;
            restrictBgProcesses.CheckedChanged += restrictBgProcesses_CheckedChanged;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(linkLabel1);
            tabPage5.Controls.Add(label9);
            tabPage5.Controls.Add(label8);
            tabPage5.Controls.Add(label7);
            tabPage5.Controls.Add(label6);
            tabPage5.Location = new Point(4, 34);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(1183, 575);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Info";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(1135, 546);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(45, 25);
            linkLabel1.TabIndex = 4;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "boo";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(331, 238);
            label9.Name = "label9";
            label9.Size = new Size(236, 25);
            label9.TabIndex = 3;
            label9.Text = "ok well, idk what to put here";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(151, 182);
            label8.Name = "label8";
            label8.Size = new Size(41, 25);
            label8.TabIndex = 2;
            label8.Text = "yep";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(195, 130);
            label7.Name = "label7";
            label7.Size = new Size(264, 25);
            label7.TabIndex = 1;
            label7.Text = "AKA there are going to be bugs";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(42, 72);
            label6.Name = "label6";
            label6.Size = new Size(599, 25);
            label6.TabIndex = 0;
            label6.Text = "This app was made by a dumb dumb who had no clue what he was doing";
            // 
            // saveFileButton
            // 
            saveFileButton.Location = new Point(6, 608);
            saveFileButton.Name = "saveFileButton";
            saveFileButton.Size = new Size(1186, 68);
            saveFileButton.TabIndex = 1;
            saveFileButton.Text = "Save File As";
            saveFileButton.UseVisualStyleBackColor = true;
            saveFileButton.Click += saveFileButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1194, 677);
            Controls.Add(saveFileButton);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "File Generator";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage6.ResumeLayout(false);
            tabPage6.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private CheckedListBox allProcesses;
        private Button saveFileButton;
        private Button RefreshProcessList;
        private Label label1;
        private Button addSelectedToBlackList;
        private Button addSelectedToWhitelist;
        private TabPage tabPage6;
        private CheckBox onlyShowWindowed;
        private Label label2;
        private Button addToBlacklistFromInput;
        private TextBox addToBlacklistInputBox;
        private Button removeSelectedFromBlacklist;
        private CheckedListBox blacklistDisplay;
        private Label label3;
        private Button addToWhitelistFromInput;
        private TextBox addToWhitelistInputBox;
        private Button removeSelectedFromWhitelist;
        private CheckedListBox whitelistDisplay;
        private Button refreshWhiteAndBlacklistButton;
        private ComboBox restrictionType;
        private Label label4;
        private Label label5;
        private CheckBox checkBox1;
        private CheckBox restrictBgProcesses;
        private CheckBox storeTimeInAppdataCheckbox;
        private CheckBox allowSystemProcesses;
        private Label label6;
        private Label label8;
        private Label label7;
        private LinkLabel linkLabel1;
        private Label label9;
    }
}
