using System.Diagnostics;

namespace Windows_Process_Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool testBool = false;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Right && Control.ModifierKeys.HasFlag(Keys.Alt) && Control.ModifierKeys.HasFlag(Keys.Shift))
            {
                DialogResult result = MessageBox.Show("Open debug console?", "Open Debug Console?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    if (testBool)
                    {
                        new Thread(() =>
                        {
                            Application.Run(new DebugCli.Form1());
                        }).Start();

                    }
                    testBool = true;
                }
            }
            else
            {
                new Thread(() =>
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "https://github.com/h-iscool/Windows-App-Manager",
                        UseShellExecute = true
                    });

                }).Start();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Thread(() =>
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/h-iscool/Windows-App-Manager", //put a explination file here
                    UseShellExecute = true
                });

            }).Start();
        }
    }
}
