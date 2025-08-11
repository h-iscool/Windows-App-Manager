namespace ManagerGUI
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
            closeButton = new CuoreUI.Controls.cuiButton();
            cuiLabel1 = new CuoreUI.Controls.cuiLabel();
            cuiButton1 = new CuoreUI.Controls.cuiButton();
            SuspendLayout();
            // 
            // closeButton
            // 
            closeButton.BackColor = Color.FromArgb(45, 45, 45);
            closeButton.CheckButton = false;
            closeButton.Checked = false;
            closeButton.CheckedBackground = Color.FromArgb(255, 106, 0);
            closeButton.CheckedForeColor = Color.White;
            closeButton.CheckedImageTint = Color.White;
            closeButton.CheckedOutline = Color.FromArgb(255, 106, 0);
            closeButton.Content = "x";
            closeButton.Cursor = Cursors.Hand;
            closeButton.DialogResult = DialogResult.None;
            closeButton.Font = new Font("Microsoft Sans Serif", 9.75F);
            closeButton.ForeColor = SystemColors.ControlLight;
            closeButton.HoverBackground = Color.FromArgb(55, 55, 55);
            closeButton.HoverForeColor = SystemColors.ControlLight;
            closeButton.HoverImageTint = Color.White;
            closeButton.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            closeButton.Image = null;
            closeButton.ImageAutoCenter = true;
            closeButton.ImageExpand = new Point(0, 0);
            closeButton.ImageOffset = new Point(0, 0);
            closeButton.Location = new Point(1221, 1);
            closeButton.Name = "closeButton";
            closeButton.NormalBackground = Color.FromArgb(50, 50, 50);
            closeButton.NormalForeColor = SystemColors.ControlLight;
            closeButton.NormalImageTint = Color.White;
            closeButton.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            closeButton.OutlineThickness = 1F;
            closeButton.PressedBackground = Color.WhiteSmoke;
            closeButton.PressedForeColor = Color.FromArgb(32, 32, 32);
            closeButton.PressedImageTint = Color.White;
            closeButton.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            closeButton.Rounding = new Padding(0);
            closeButton.Size = new Size(66, 59);
            closeButton.TabIndex = 0;
            closeButton.TextAlignment = StringAlignment.Center;
            closeButton.TextOffset = new Point(0, 0);
            closeButton.Click += closeButton_Click;
            // 
            // cuiLabel1
            // 
            cuiLabel1.BackColor = Color.FromArgb(55, 55, 55);
            cuiLabel1.Content = "Process\\ Manager";
            cuiLabel1.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cuiLabel1.ForeColor = SystemColors.ControlLight;
            cuiLabel1.HorizontalAlignment = StringAlignment.Near;
            cuiLabel1.Location = new Point(2, 1);
            cuiLabel1.Margin = new Padding(5, 6, 5, 6);
            cuiLabel1.Name = "cuiLabel1";
            cuiLabel1.Size = new Size(1285, 59);
            cuiLabel1.TabIndex = 1;
            cuiLabel1.VerticalAlignment = StringAlignment.Center;
            cuiLabel1.Load += cuiLabel1_Load;
            // 
            // cuiButton1
            // 
            cuiButton1.CheckButton = false;
            cuiButton1.Checked = false;
            cuiButton1.CheckedBackground = Color.FromArgb(255, 106, 0);
            cuiButton1.CheckedForeColor = Color.White;
            cuiButton1.CheckedImageTint = Color.White;
            cuiButton1.CheckedOutline = Color.FromArgb(255, 106, 0);
            cuiButton1.Content = "Your text here!";
            cuiButton1.DialogResult = DialogResult.None;
            cuiButton1.Font = new Font("Microsoft Sans Serif", 9.75F);
            cuiButton1.ForeColor = Color.Black;
            cuiButton1.HoverBackground = Color.White;
            cuiButton1.HoverForeColor = Color.Black;
            cuiButton1.HoverImageTint = Color.White;
            cuiButton1.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            cuiButton1.Image = null;
            cuiButton1.ImageAutoCenter = true;
            cuiButton1.ImageExpand = new Point(0, 0);
            cuiButton1.ImageOffset = new Point(0, 0);
            cuiButton1.Location = new Point(2, 53);
            cuiButton1.Name = "cuiButton1";
            cuiButton1.NormalBackground = Color.White;
            cuiButton1.NormalForeColor = Color.Black;
            cuiButton1.NormalImageTint = Color.White;
            cuiButton1.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            cuiButton1.OutlineThickness = 1F;
            cuiButton1.PressedBackground = Color.WhiteSmoke;
            cuiButton1.PressedForeColor = Color.FromArgb(32, 32, 32);
            cuiButton1.PressedImageTint = Color.White;
            cuiButton1.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            cuiButton1.Rounding = new Padding(8);
            cuiButton1.Size = new Size(158, 64);
            cuiButton1.TabIndex = 2;
            cuiButton1.TextAlignment = StringAlignment.Center;
            cuiButton1.TextOffset = new Point(0, 0);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(50, 50, 50);
            ClientSize = new Size(1286, 716);
            Controls.Add(cuiButton1);
            Controls.Add(closeButton);
            Controls.Add(cuiLabel1);
            Name = "Form1";
            Text = "Process Manager";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private CuoreUI.Controls.cuiButton closeButton;
        private CuoreUI.Controls.cuiLabel cuiLabel1;
        private CuoreUI.Controls.cuiButton cuiButton1;
    }
}
