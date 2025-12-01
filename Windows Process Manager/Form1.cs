using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.Security.Policy;
using System.Security.Principal;
using System.Text.Json;

namespace Windows_Process_Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RefreshProcessList(checkBox1.Checked);
            if (IsUserAdmin())
            {
                Debug.WriteLine("user is in admin group");
                //MessageBox.Show("User is admin");
            }
            else
            {
                Debug.WriteLine("user isnt in admin group");
                //MessageBox.Show("User is not admin");
            }
        }

        private bool isAppAdmin()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private bool IsUserAdmin()
        {
            var context = new PrincipalContext(ContextType.Machine);
            var user = UserPrincipal.Current;
            var group = GroupPrincipal.FindByIdentity(context, "Administrators");
            {
                if (user == null || group == null)
                    return false;
                return user.IsMemberOf(group);
            }
        }

        private void RefreshProcessList(bool showBG)
        {
            if (showBG)
            {
                Process[] processes = Process.GetProcesses();
                checkedListBox1.Items.Clear();

                foreach (Process process in processes)
                {
                    if (!(checkedListBox1.Items.Contains(process.ProcessName)))
                    {
                        checkedListBox1.Items.Add(process.ProcessName);
                    }
                }
            }
            else
            {
                var processes = Process.GetProcesses()
            .Where(p => p.MainWindowHandle != IntPtr.Zero && !string.IsNullOrWhiteSpace(p.MainWindowTitle));
                checkedListBox1.Items.Clear();

                foreach (Process process in processes)
                {
                    if (!(checkedListBox1.Items.Contains(process.ProcessName)))
                    {
                        checkedListBox1.Items.Add(process.ProcessName);
                    }
                }
            }
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshProcessList(checkBox1.Checked);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(checkedListBox1.Items.Contains(textBox1.Text)) && textBox1.Text.Trim() != "")
            {
                checkedListBox1.Items.Add(textBox1.Text);
                textBox1.Text = string.Empty;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private bool hasClickedTB1 = false;
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (!hasClickedTB1)
            {
                MessageBox.Show(
                    "A process name is a process's binary without the file extention.\n(ex. \"chrome.exe\" becomes \"chrome\")",
                    "Process Name Info Box",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
            }
            hasClickedTB1 = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            RefreshProcessList(checkBox1.Checked);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this app calls on a file to check things that will not be commonly changed like:\n" +
                " - auto update info\n" +
                " - if the restriction file is local\n" +
                " - the server for the restiction file (if needed)\n" +
                " - and maybe more if i forget to add it to this list\n\n" +
                "How is this safe?\n" +
                "The file is stored in Program Files x86, which normal users can't write to.\n" +
                "\nHow is the file made?\n" +
                "You can do it yourself OR use the generated powershell command.", "Info");
        }

        private string generateSettingsJSON()
        {

            var versionUrls = textBox2.Text
        .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            var updateURLs = textBox3.Text
        .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            var restrictionURLs = textBox4.Text
        .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            var settings = new
            {
                AutoUpdate = AutoUpdateChecked,
                UseServerFile = UseServerRestrictionFile,
                VersionURLs = versionUrls,
                UpdateURLs = updateURLs,
                RestrictionURLs = restrictionURLs

            };
            string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            return json;

            //Debug.WriteLine(settings.ToString());
            //return settings.ToString();
            //return "";
        }

        private void button4_Click(object sender, EventArgs e)//manual
        {
            Clipboard.SetText(generateSettingsJSON());
            MessageBox.Show("Copied JSON to clipboard.\nMake a file in C:\\Program Files (86x)\\Windows Process Manager called \"settings.json\"\nthen paste ctrl + v and save");
        }

        private void RunPowerShellAsAdmin(string script)
        {
            // Create a temporary .ps1 file
            string tempFile = Path.Combine(Path.GetTempPath(), "generated_settings.ps1");
            File.WriteAllText(tempFile, script);

            // Start PowerShell elevated
            ProcessStartInfo psi = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy Bypass -File \"{tempFile}\"",
                Verb = "runas", // this requests admin privileges
                UseShellExecute = true
            };

            try
            {
                Process.Start(psi);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("The script was not run because admin permission was denied.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string fileContents = generateSettingsJSON();
            string fileDir = @"C:\Program Files (x86)\Windows Process Manager\";
            string fileName = "settings.json";

            // Escape the JSON so it can be safely embedded in PowerShell
            //string escapedJson = fileContents.Replace("`", "``")
            //                                 .Replace("\"", "\\\"");

            //            string psScript = $@"
            //$dir = ""{fileDir}""

            //# Create directory if it doesn't exist
            //if (-Not (Test-Path -Path $dir)) {{
            //    New-Item -ItemType Directory -Path $dir | Out-Null
            //}}

            //# Write file
            //$path = Join-Path $dir ""{fileName}""
            //Set-Content -Path $path -Value @'{fileContents}'@ -Encoding UTF8
            //";


            string psScript = $@"
$dir = ""{fileDir}""

if (-Not (Test-Path -Path $dir)) {{
    New-Item -ItemType Directory -Path $dir | Out-Null
}}

$path = Join-Path $dir ""{fileName}""

$jsonContent = @'
{fileContents}
'@

Set-Content -Path $path -Value $jsonContent -Encoding UTF8
";



            // Show it to the user or copy to clipboard
            Clipboard.SetText(psScript);

            DialogResult a = MessageBox.Show("PowerShell script copied to clipboard!\nDo you want to run it now?", "Generated", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            if (a == DialogResult.Yes)
            {
                RunPowerShellAsAdmin(psScript);
            }
        }

        private bool AutoUpdateChecked = true;
        private bool UseServerRestrictionFile = false;
        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox3.CheckedItems.Contains("Dissable auto updates"))
            {
                AutoUpdateChecked = false;
            }
            else
            {
                AutoUpdateChecked = true;
            }

            if (checkedListBox3.CheckedItems.Contains("Use server restriction file"))
            {
                UseServerRestrictionFile = true;
            }
            else
            {
                UseServerRestrictionFile = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private string generateRestrictionJSON()
        {

            var pns = checkedListBox1.CheckedItems;

            bool whiteList, blacklist, restrictBG, restrictSys;

            if (comboBox1.Text == "Whitelist")
            {
                whiteList = true; blacklist = false; 

            }
            else if (comboBox1.Text == "Blacklist") { whiteList = false; blacklist = true; }
            else { whiteList = false; blacklist = false; }

            if (checkedListBox2.CheckedItems.Contains("Restrict background processes*")) {
                restrictBG = true;
            }
            else {  restrictBG = false; }

            if (checkedListBox2.CheckedItems.Contains("Restrict system processes *")) { 
                restrictSys = true;
            }
            else{ restrictSys = false; }

                var restr = new
                {
                    UseWhitelist = whiteList,
                    UseBlacklist = blacklist,
                    RestrictBackground = restrictBG,
                    RestrictSystem = restrictSys,
                    ProcessNames = pns

                };
            string json = JsonSerializer.Serialize(restr, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            return json;

            //Debug.WriteLine(settings.ToString());
            //return settings.ToString();
            //return "";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(generateRestrictionJSON());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
