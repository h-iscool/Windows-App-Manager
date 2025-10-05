using System.Diagnostics;

namespace FileGen
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();

            refreshProcessList();
        }

        private void refreshProcessList() {
            allProcesses.Items.Clear();

            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                try
                {

                    if (onlyShowWindowed.Checked)
                    {
                        if (process.MainWindowHandle == IntPtr.Zero)
                        {
                            continue;
                        }
                    }
                    if (!allProcesses.Items.Contains(process.ProcessName))
                    {
                        allProcesses.Items.Add(process.ProcessName);
                    }
                }
                catch
                {
                }
            }
        }

        private void allProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RefreshProcessList_Click(object sender, EventArgs e)
        {
            refreshProcessList();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void onlyShowWindowed_CheckedChanged(object sender, EventArgs e)
        {
            refreshProcessList();
        }
    }
}