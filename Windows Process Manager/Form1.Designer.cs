namespace Windows_Process_Manager
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
            linkLabel2 = new LinkLabel();
            label2 = new Label();
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            tabPage2 = new TabPage();
            button6 = new Button();
            checkBox1 = new CheckBox();
            label5 = new Label();
            checkedListBox2 = new CheckedListBox();
            comboBox1 = new ComboBox();
            label4 = new Label();
            button2 = new Button();
            button1 = new Button();
            textBox1 = new TextBox();
            label3 = new Label();
            checkedListBox1 = new CheckedListBox();
            tabPage3 = new TabPage();
            textBox4 = new TextBox();
            label8 = new Label();
            button5 = new Button();
            button4 = new Button();
            label7 = new Label();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            label6 = new Label();
            checkedListBox3 = new CheckedListBox();
            button3 = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(799, 449);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(linkLabel2);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(linkLabel1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(791, 421);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "About";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(342, 146);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(76, 15);
            linkLabel2.TabIndex = 3;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "How it works";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(200, 109);
            label2.Name = "label2";
            label2.Size = new Size(356, 15);
            label2.TabIndex = 2;
            label2.Text = "An application that allows for the restriction of windows processes";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 27.8571434F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(154, 46);
            label1.Name = "label1";
            label1.Size = new Size(471, 51);
            label1.TabIndex = 1;
            label1.Text = "Windows Process Manager";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(718, 402);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(70, 15);
            linkLabel1.TabIndex = 0;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Github repo";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(button6);
            tabPage2.Controls.Add(checkBox1);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(checkedListBox2);
            tabPage2.Controls.Add(comboBox1);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(button1);
            tabPage2.Controls.Add(textBox1);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(checkedListBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(791, 421);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Restriction File Generator";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(696, 89);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 10;
            button6.Text = "copy";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(341, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(176, 19);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "Show background processes";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(41, 296);
            label5.Name = "label5";
            label5.Size = new Size(129, 15);
            label5.TabIndex = 8;
            label5.Text = "*could cause instability";
            // 
            // checkedListBox2
            // 
            checkedListBox2.CheckOnClick = true;
            checkedListBox2.FormattingEnabled = true;
            checkedListBox2.Items.AddRange(new object[] { "Restrict background processes *", "Restrict system processes *" });
            checkedListBox2.Location = new Point(6, 55);
            checkedListBox2.Name = "checkedListBox2";
            checkedListBox2.Size = new Size(212, 238);
            checkedListBox2.TabIndex = 7;
            checkedListBox2.SelectedIndexChanged += checkedListBox2_SelectedIndexChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Whitelist", "Blacklist", "None" });
            comboBox1.Location = new Point(8, 26);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 6;
            comboBox1.Text = "Whitelist";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 8);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 5;
            label4.Text = "Options";
            // 
            // button2
            // 
            button2.Location = new Point(519, 0);
            button2.Name = "button2";
            button2.Size = new Size(64, 22);
            button2.TabIndex = 4;
            button2.Text = "refresh";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(561, 296);
            button1.Name = "button1";
            button1.Size = new Size(22, 23);
            button1.TabIndex = 3;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(277, 296);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(278, 23);
            textBox1.TabIndex = 2;
            textBox1.Click += textBox1_Click;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(277, 5);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 1;
            label3.Text = "Processes";
            // 
            // checkedListBox1
            // 
            checkedListBox1.CheckOnClick = true;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(277, 23);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(306, 274);
            checkedListBox1.TabIndex = 0;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(textBox4);
            tabPage3.Controls.Add(label8);
            tabPage3.Controls.Add(button5);
            tabPage3.Controls.Add(button4);
            tabPage3.Controls.Add(label7);
            tabPage3.Controls.Add(textBox3);
            tabPage3.Controls.Add(textBox2);
            tabPage3.Controls.Add(label6);
            tabPage3.Controls.Add(checkedListBox3);
            tabPage3.Controls.Add(button3);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(791, 421);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Settings Generator";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(514, 114);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(270, 129);
            textBox4.TabIndex = 9;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(532, 96);
            label8.Name = "label8";
            label8.Size = new Size(240, 15);
            label8.TabIndex = 8;
            label8.Text = "Restriction File URLs (OR path) (one per line)";
            label8.Click += label8_Click;
            // 
            // button5
            // 
            button5.Location = new Point(621, 395);
            button5.Name = "button5";
            button5.Size = new Size(167, 23);
            button5.TabIndex = 7;
            button5.Text = "Generate file (powershell)";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Location = new Point(652, 366);
            button4.Name = "button4";
            button4.Size = new Size(136, 23);
            button4.TabIndex = 6;
            button4.Text = "Generate file (manual)";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(297, 96);
            label7.Name = "label7";
            label7.Size = new Size(147, 15);
            label7.TabIndex = 5;
            label7.Text = "Update URLs (one per line)";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(238, 114);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(270, 129);
            textBox3.TabIndex = 4;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(8, 114);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(224, 129);
            textBox2.TabIndex = 3;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(45, 96);
            label6.Name = "label6";
            label6.Size = new Size(147, 15);
            label6.TabIndex = 2;
            label6.Text = "Version URLs (one per line)";
            // 
            // checkedListBox3
            // 
            checkedListBox3.CheckOnClick = true;
            checkedListBox3.FormattingEnabled = true;
            checkedListBox3.Items.AddRange(new object[] { "Dissable auto updates", "Use server restriction file" });
            checkedListBox3.Location = new Point(0, 0);
            checkedListBox3.Name = "checkedListBox3";
            checkedListBox3.Size = new Size(192, 58);
            checkedListBox3.TabIndex = 1;
            checkedListBox3.SelectedIndexChanged += checkedListBox3_SelectedIndexChanged;
            // 
            // button3
            // 
            button3.Location = new Point(695, 3);
            button3.Name = "button3";
            button3.Size = new Size(93, 23);
            button3.TabIndex = 0;
            button3.Text = "What is this?";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Windows Process Manager";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private LinkLabel linkLabel1;
        private Label label1;
        private Label label2;
        private LinkLabel linkLabel2;
        private TabPage tabPage2;
        private ComboBox comboBox1;
        private Label label4;
        private Button button2;
        private Button button1;
        private TextBox textBox1;
        private Label label3;
        private CheckedListBox checkedListBox1;
        private CheckedListBox checkedListBox2;
        private CheckBox checkBox1;
        private Label label5;
        private TabPage tabPage3;
        private Button button3;
        private CheckedListBox checkedListBox3;
        private Label label7;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label6;
        private Button button5;
        private Button button4;
        private TextBox textBox4;
        private Label label8;
        private Button button6;
    }
}
