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
            linkLabel1 = new LinkLabel();
            tabPage2 = new TabPage();
            label1 = new Label();
            label2 = new Label();
            linkLabel2 = new LinkLabel();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
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
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(791, 421);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "File Generator";
            tabPage2.UseVisualStyleBackColor = true;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(200, 109);
            label2.Name = "label2";
            label2.Size = new Size(356, 15);
            label2.TabIndex = 2;
            label2.Text = "An application that allows for the restriction of windows processes";
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private LinkLabel linkLabel1;
        private TabPage tabPage2;
        private Label label1;
        private Label label2;
        private LinkLabel linkLabel2;
    }
}
