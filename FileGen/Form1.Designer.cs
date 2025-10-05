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
            EnforceBlacklist = new CheckBox();
            EnforceWhitelist = new CheckBox();
            tabPage2 = new TabPage();
            onlyShowWindowed = new CheckBox();
            addSelectedToBlackList = new Button();
            addSelectedToWhitelist = new Button();
            label1 = new Label();
            RefreshProcessList = new Button();
            allProcesses = new CheckedListBox();
            tabPage6 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            button1 = new Button();
            label2 = new Label();
            whitelistDesplay = new CheckedListBox();
            removeSelectedFromWhitelist = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            textBox2 = new TextBox();
            button4 = new Button();
            checkedListBox1 = new CheckedListBox();
            label3 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage6.SuspendLayout();
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
            tabPage1.Controls.Add(EnforceBlacklist);
            tabPage1.Controls.Add(EnforceWhitelist);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1183, 575);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Main";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // EnforceBlacklist
            // 
            EnforceBlacklist.AutoSize = true;
            EnforceBlacklist.Location = new Point(9, 88);
            EnforceBlacklist.Name = "EnforceBlacklist";
            EnforceBlacklist.Size = new Size(165, 29);
            EnforceBlacklist.TabIndex = 1;
            EnforceBlacklist.Text = "Enforce blacklist";
            EnforceBlacklist.UseVisualStyleBackColor = true;
            // 
            // EnforceWhitelist
            // 
            EnforceWhitelist.AutoSize = true;
            EnforceWhitelist.Location = new Point(9, 53);
            EnforceWhitelist.Name = "EnforceWhitelist";
            EnforceWhitelist.Size = new Size(166, 29);
            EnforceWhitelist.TabIndex = 0;
            EnforceWhitelist.Text = "Enforce whitelist";
            EnforceWhitelist.UseVisualStyleBackColor = true;
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
            // 
            // addSelectedToWhitelist
            // 
            addSelectedToWhitelist.Location = new Point(625, 501);
            addSelectedToWhitelist.Name = "addSelectedToWhitelist";
            addSelectedToWhitelist.Size = new Size(552, 71);
            addSelectedToWhitelist.TabIndex = 3;
            addSelectedToWhitelist.Text = "Add selected to whitelist";
            addSelectedToWhitelist.UseVisualStyleBackColor = true;
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
            allProcesses.FormattingEnabled = true;
            allProcesses.Location = new Point(0, 43);
            allProcesses.Name = "allProcesses";
            allProcesses.Size = new Size(1181, 452);
            allProcesses.TabIndex = 0;
            allProcesses.SelectedIndexChanged += allProcesses_SelectedIndexChanged;
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(button3);
            tabPage6.Controls.Add(textBox2);
            tabPage6.Controls.Add(button4);
            tabPage6.Controls.Add(checkedListBox1);
            tabPage6.Controls.Add(label3);
            tabPage6.Controls.Add(button2);
            tabPage6.Controls.Add(textBox1);
            tabPage6.Controls.Add(removeSelectedFromWhitelist);
            tabPage6.Controls.Add(whitelistDesplay);
            tabPage6.Controls.Add(label2);
            tabPage6.Location = new Point(4, 34);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new Size(1183, 575);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "Lists";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1183, 575);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Limits";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 34);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1183, 575);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Extra";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 34);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(1183, 575);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Info";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(6, 608);
            button1.Name = "button1";
            button1.Size = new Size(1186, 68);
            button1.TabIndex = 1;
            button1.Text = "Save File As";
            button1.UseVisualStyleBackColor = true;
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
            // whitelistDesplay
            // 
            whitelistDesplay.FormattingEnabled = true;
            whitelistDesplay.Location = new Point(8, 37);
            whitelistDesplay.Name = "whitelistDesplay";
            whitelistDesplay.Size = new Size(373, 396);
            whitelistDesplay.TabIndex = 1;
            // 
            // removeSelectedFromWhitelist
            // 
            removeSelectedFromWhitelist.Location = new Point(78, 439);
            removeSelectedFromWhitelist.Name = "removeSelectedFromWhitelist";
            removeSelectedFromWhitelist.Size = new Size(226, 34);
            removeSelectedFromWhitelist.TabIndex = 2;
            removeSelectedFromWhitelist.Text = "Remove Selected";
            removeSelectedFromWhitelist.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(8, 479);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(373, 31);
            textBox1.TabIndex = 3;
            // 
            // button2
            // 
            button2.Location = new Point(106, 516);
            button2.Name = "button2";
            button2.Size = new Size(173, 34);
            button2.TabIndex = 4;
            button2.Text = "Add to Whitelist";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(903, 516);
            button3.Name = "button3";
            button3.Size = new Size(173, 34);
            button3.TabIndex = 9;
            button3.Text = "Add to Whitelist";
            button3.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(805, 479);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(373, 31);
            textBox2.TabIndex = 8;
            // 
            // button4
            // 
            button4.Location = new Point(875, 439);
            button4.Name = "button4";
            button4.Size = new Size(226, 34);
            button4.TabIndex = 7;
            button4.Text = "Remove Selected";
            button4.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(805, 37);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(373, 396);
            checkedListBox1.TabIndex = 6;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1194, 677);
            Controls.Add(button1);
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
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private CheckBox EnforceBlacklist;
        private CheckBox EnforceWhitelist;
        private CheckedListBox allProcesses;
        private Button button1;
        private Button RefreshProcessList;
        private Label label1;
        private Button addSelectedToBlackList;
        private Button addSelectedToWhitelist;
        private TabPage tabPage6;
        private CheckBox onlyShowWindowed;
        private Label label2;
        private Button button3;
        private TextBox textBox2;
        private Button button4;
        private CheckedListBox checkedListBox1;
        private Label label3;
        private Button button2;
        private TextBox textBox1;
        private Button removeSelectedFromWhitelist;
        private CheckedListBox whitelistDesplay;
    }
}
