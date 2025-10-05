using System.Diagnostics;
using System.Text;
using System.Linq;


namespace FileGen
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();

            restrictionType.SelectedIndex = 0;

            refreshProcessList();
            refreshWhiteAndBlackLists();
        }

        //Whitelist and Blacklist init

        private List<string> whitelist = new List<string>();
        private List<string> blacklist = new List<string>();

        private void refreshProcessList()
        {
            Debug.WriteLine("Refreshing Process List...");
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
            Debug.WriteLine("Done!");
        }

        private void refreshWhiteAndBlackLists()
        {
            Debug.WriteLine("Refreshing Whitelist and Blacklist...");
            whitelistDisplay.Items.Clear();
            blacklistDisplay.Items.Clear();

            foreach (string process in whitelist)
            {
                whitelistDisplay.Items.Add(process);
            }
            foreach (string process in blacklist)
            {
                blacklistDisplay.Items.Add(process);
            }
            Debug.WriteLine("Done!");
        }

        private string generateFile(bool raw = false) {
            string fileContents = "{";

            if (restrictionType.SelectedIndex == 0)
            {
                fileContents += "\"isWhitelist\":true,\"isBlacklist\":false,";
            }
            else if (restrictionType.SelectedIndex == 1)
            {
                fileContents += "\"isWhitelist\":false,\"isBlacklist\":true,";
            }
            else {
                fileContents += "\"isWhitelist\":true,\"isBlacklist\":true,";
            }

            if (restrictBgProcesses.Checked)
            {
                fileContents += "\"restrictBackground\":true,";
            }
            else {
                fileContents += "\"restrictBackground\":false,";
            }

            /*
             This is where the code for timelimit would go, but it isn't done yet
             */

            /*This next code will be temporary*/

            fileContents += "\"enforceTimeLimit\":false,\"timeLimit\":999999,\"timeLimitPerAppName\":{},\"storeTimeInAppdata\":true,\"checkForUpdates\":false,";

            if (allowSystemProcesses.Checked)
            {
                fileContents += "\"allowReqProcesses\":true,";
            }
            else {
                fileContents += "\"allowReqProcesses\":false,";
            }

            fileContents += $"\"allowedProcesses\":[{string.Join(",", whitelist.Select(w => $"\"{w}\""))}],";

            fileContents += $"\"bannedProcesses\":[{string.Join(",", blacklist.Select(w => $"\"{w}\""))}]";

            fileContents += "}";

            if (raw)
            {
                return fileContents;
            }
            else
            {
                fileContents = Convert.ToBase64String(Encoding.UTF8.GetBytes(fileContents));
                return fileContents;
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

        private void refreshWhiteAndBlacklistButton_Click(object sender, EventArgs e)
        {
            refreshWhiteAndBlackLists();
        }

        private void whitelistDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void blacklistDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addSelectedToBlackList_Click(object sender, EventArgs e)
        {
            foreach (var item in allProcesses.CheckedItems)
            {
                if (!blacklist.Contains(item.ToString()))
                {
                    blacklist.Add(item.ToString());
                }
            }
            refreshWhiteAndBlackLists();
        }

        private void addSelectedToWhitelist_Click(object sender, EventArgs e)
        {
            foreach (var item in allProcesses.CheckedItems)
            {
                if (!whitelist.Contains(item.ToString()))
                {
                    whitelist.Add(item.ToString());
                }
            }
            refreshWhiteAndBlackLists();
        }

        private void removeSelectedFromWhitelist_Click(object sender, EventArgs e)
        {
            foreach (var item in whitelistDisplay.CheckedItems)
            {
                if (whitelist.Contains(item.ToString()))
                {
                    whitelist.Remove(item.ToString());
                }
            }
            refreshWhiteAndBlackLists();
        }

        private void removeSelectedFromBlacklist_Click(object sender, EventArgs e)
        {
            foreach (var item in blacklistDisplay.CheckedItems)
            {
                if (blacklist.Contains(item.ToString()))
                {
                    blacklist.Remove(item.ToString());
                }
            }
            refreshWhiteAndBlackLists();
        }

        private void addToWhitelistInputBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void addToWhitelistFromInput_Click(object sender, EventArgs e)
        {
            if (!whitelist.Contains(addToWhitelistInputBox.Text))
            {
                whitelist.Add(addToWhitelistInputBox.Text);
            }
            refreshWhiteAndBlackLists();
        }

        private void addToBlacklistInputBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void addToBlacklistFromInput_Click(object sender, EventArgs e)
        {
            if (!blacklist.Contains(addToBlacklistInputBox.Text))
            {
                blacklist.Add(addToBlacklistInputBox.Text);
            }
            refreshWhiteAndBlackLists();
        }

        private void restrictionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (restrictionType.SelectedIndex == 2)
            {
                DialogResult result = MessageBox.Show("Using both a whitelist and blacklist is currently not recomended as it could potentialy crash the program. Would you like to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                }
                else
                {
                    restrictionType.SelectedIndex = 0;
                }
            }
        }

        private void restrictBgProcesses_CheckedChanged(object sender, EventArgs e)
        {
            if (restrictBgProcesses.Checked == true)
            {
                DialogResult a = MessageBox.Show("Restriction of background processes could lead to unwanted crashing of processes vital for windows to run, are you sure you want to do this?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (a == DialogResult.No)
                {
                    restrictBgProcesses.Checked = false;
                }
            }
        }

        private void storeTimeInAppdataCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("This doesnt do anything as time limit is disabled");
        }

        private void allowSystemProcesses_CheckedChanged(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("This is a backup to make sure your computer doesn't crash, are you sure you want to do this? (Dissabling this could easily cause a crash)", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (a == DialogResult.No)
            {
                allowSystemProcesses.Checked = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Hiii");
        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Config File";
            saveFileDialog.Filter = "App Restriction File (*.appreistr)|*.appreistr|All Files (*.*)|*.*";
            saveFileDialog.DefaultExt = "appreistr";
            saveFileDialog.FileName = "processList.appreistr";
            saveFileDialog.OverwritePrompt = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK) { 
                string path = saveFileDialog.FileName;
                try
                {

                    string fileContents = generateFile();

                    File.WriteAllText(path, fileContents);

                    MessageBox.Show("Done!");

                }
                catch (Exception ex) { 
                    MessageBox.Show($"{e.ToString()}","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}