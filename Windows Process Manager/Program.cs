// Imports:
using Microsoft.VisualBasic;
using System;               //use system
using System.Buffers.Text;  // use txt
using System.Diagnostics; // use diagnosticxs
using System.IO; //use io
using System.Runtime.CompilerServices;
using System.Text; //use text but wierd
using System.Windows.Forms;
using System.Text.Json;



class Program
{
    static void Main(string[] args)
    {
        // debug arguments:
        if (args.Length > 0) {

            bool continueProgram = true;

            if (args.Contains("killallself", StringComparer.OrdinalIgnoreCase)) {
                continueProgram = false;

                try
                {
                    Process current = Process.GetCurrentProcess();
                    string exeName = current.ProcessName;

                    Process[] allRunningInstances = Process.GetProcessesByName(exeName);

                    foreach (Process process in allRunningInstances)
                    {
                        try {
                            if (process.Id != current.Id) {
                                process.Kill(true);
                            }
                        }
                        catch (Exception ex){
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
                catch (Exception ex) { 
                    MessageBox.Show(ex.ToString());
                }

                
            }

            if (args.Contains("killall", StringComparer.OrdinalIgnoreCase)) {
                DialogResult killallanyway = MessageBox.Show("This is a debug command and is likely to crash your pc, are you sure you want to do this?","Are you sure?",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2);

                if (killallanyway == DialogResult.Yes) {
                    Process[] allProcesses = Process.GetProcesses();

                    foreach (Process process in allProcesses)
                    {
                        try
                        {
                            if (process.Id != Environment.ProcessId) {
                                process.Kill();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
                
            }

            if (args.Contains("hichat")) {
                MessageBox.Show("boo");
            }

            if (args.Contains("~nya")) {
                continueProgram = false;
                void colon3c()
                {
                    new Thread(() => { MessageBox.Show(":3c"); }).Start();
                }
                while (true) {
                    colon3c();
                    Thread.Sleep(10);
                }
                
            }

            if (args.Contains("msgboxTest", StringComparer.OrdinalIgnoreCase)) {
                continueProgram = false;
                MessageBox.Show("This is a test message box to see if it works in a console app","Title",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            if (args.Contains("argTest1")) {
                Console.WriteLine("This arg was called");
            }

            if (args.Contains("argTest2", StringComparer.OrdinalIgnoreCase)) { 
                Console.WriteLine("this is a arg that isnt case sensitive!!!");
            }

            if (!continueProgram){
                return;
            }
        
        }

        // Define isLegacy var:
        bool isLegacy = false;


        string restrictFilePath = "processList.appreistr"; //restriction file

        if (!File.Exists(restrictFilePath)) //check if it exists
        {
            Debug.WriteLine("No file exists, exiting...");
            Environment.Exit(0x1); //Exit with code 1
        }

        string restrictFileContent = File.ReadAllText(restrictFilePath); //reads file

        restrictFileContent = Encoding.UTF8.GetString(Convert.FromBase64String(restrictFileContent));

        Debug.WriteLine($"\nFile content:\n{restrictFileContent}\n");

        if (restrictFileContent == null)
        {
            Debug.WriteLine("No file content found, exiting...");
            Environment.Exit(0x2);
        }

        if (restrictFileContent[0] == '#')// check if legacy
        {
            Debug.WriteLine("!!!LEGACY MODE!!!");
            isLegacy = true;
        }

        //Legacy support:
        if (isLegacy)
        {
            //setup vars:
            string? tempReader = null;
            bool? whitelist = null;
            bool? restrictbg = null;
            int semicolonCount = 0;
            List<string> processList = new List<string>();
            bool mainLoop = true;

            for (int i = 0; restrictFileContent.Length > i; i++)
            { //read file:
                if (restrictFileContent[i] == ';') //if end char:
                {
                    semicolonCount++;
                    if (whitelist == null) // if whitelist var not writen:
                    { // write whitelist var
                        if (tempReader == "#WHITELIST")
                        {
                            Debug.WriteLine("whitelist mode");
                            whitelist = true;
                        }
                        else
                        {
                            Debug.WriteLine("blacklist mode");
                            whitelist = false;
                        }
                    }

                    // if restrictbg var not writen:
                    if (restrictbg == null)
                    {//write restrictbg var
                        if (tempReader == "#RESTRICTALLPROCESSES")
                        {
                            Debug.WriteLine("Restrict all processes");
                            restrictbg = true;
                        }
                        else
                        {
                            Debug.WriteLine("Restrict window processes");
                            restrictbg = false;
                        }
                    }
                    if (semicolonCount > 4 && tempReader != null)
                    {
                        //processList.Add(tempReader.Trim());
                        if (tempReader.StartsWith("System.Diagnostics.Process (") && tempReader.EndsWith(")"))
                        {
                            int startIndex = "System.Diagnostics.Process (".Length;
                            string procName = tempReader.Substring(startIndex, tempReader.Length - startIndex - 1);
                            processList.Add(procName.Trim());
                        }
                        else
                        {
                            processList.Add(tempReader.Trim());
                        }

                    }

                    tempReader = null;
                }
                else
                {
                    tempReader += restrictFileContent[i];
                }
            }

            while (mainLoop)
            {

                Process currentProcess = Process.GetCurrentProcess();



                if (whitelist == true)
                {
                    if (restrictbg == true)
                    {
                        Process[] runningProcesses = Process.GetProcesses();
                        foreach (Process process in runningProcesses)
                        {
                            try
                            {
                                if (!processList.Contains(process.ProcessName, StringComparer.OrdinalIgnoreCase))
                                {
                                    if (process.Id != currentProcess.Id)
                                    {
                                        Debug.WriteLine($"killing process: {process.ProcessName}");
                                        process.Kill();
                                    }
                                }
                            }
                            catch
                            {
                                Debug.WriteLine($"Error in restricting");
                            }
                        }
                    }
                    else
                    {
                        Process[] runningProcesses = Process.GetProcesses();
                        foreach (Process process in runningProcesses)
                        {
                            try
                            {
                                if (!(process.MainWindowHandle != IntPtr.Zero && !string.IsNullOrWhiteSpace(process.MainWindowTitle) && processList.Contains(process.ProcessName, StringComparer.OrdinalIgnoreCase)))
                                {

                                    if (!processList.Contains(process.ProcessName, StringComparer.OrdinalIgnoreCase))
                                    {
                                        if (process.Id != currentProcess.Id)
                                        {
                                            Debug.WriteLine($"killing process: {process.ProcessName}");
                                            process.Kill();
                                        }
                                    }
                                }
                            }
                            catch
                            {
                                Debug.WriteLine($"Error in restricting");
                            }
                        }
                    }
                }
                else
                {
                    if (restrictbg == true)
                    {
                        Process[] runningProcesses = Process.GetProcesses();
                        foreach (Process process in runningProcesses)
                        {
                            try
                            {
                                if (processList.Contains(process.ProcessName, StringComparer.OrdinalIgnoreCase))
                                {
                                    if (process.Id != currentProcess.Id)
                                    {
                                        Debug.WriteLine($"killing process: {process.ProcessName}");
                                        process.Kill();
                                    }
                                }
                            }
                            catch
                            {
                                Debug.WriteLine($"Error in restricting");
                            }
                        }
                    }
                    else
                    {
                        Process[] runningProcesses = Process.GetProcesses();
                        foreach (Process process in runningProcesses)
                        {
                            try
                            {
                                if (process.MainWindowHandle != IntPtr.Zero && !string.IsNullOrWhiteSpace(process.MainWindowTitle) && processList.Contains(process.ProcessName, StringComparer.OrdinalIgnoreCase))
                                {

                                    if (processList.Contains(process.ProcessName, StringComparer.OrdinalIgnoreCase))
                                    {
                                        if (process.Id != currentProcess.Id)
                                        {
                                            Debug.WriteLine($"killing process: {process.ProcessName}");
                                            process.Kill();
                                        }
                                    }
                                }
                            }
                            catch
                            {
                                Debug.WriteLine($"Error in restricting");
                            }
                        }
                    }
                }

                Thread.Sleep(250);
            }
        }
        else
        {
            // if NOT legacy

            // setup variables:

            List<string> systemReq = new List<string>() {
                "Idle","System","Registry","smss","csrss","wininit","winlogon","services","lsass",
                "svchost","fontdrvhost","dwm","WUDFHost","amdfendrsr","atiesrxx","dasHost",
                "atieclxx","spoolsv","AdminService","FMService64","Lenovo.Modern.ImController",
                "LenovoVantageService","LNBITSSvc","QcomWlanSrvx64","MpDefenderCoreService",
                "DAX3API","LenovoUtilityService","RtkAudUService64","SmartSense","UDClientService",
                "MsMpEng","WmiPrvSE","unsecapp","MSPCManagerService","NisSrv","AutoModeDetect",
                "conhost","SmartSenseController","sihost","taskhostw","FnHotkeyCapsLKNumLK",
                "explorer","CrossDeviceResume","SearchHost","StartMenuExperienceHost","FnHotkeyUtility",
                "Widgets","RuntimeBroker","WidgetService","msedgewebview2","ctfmon",
                "WindowsPackageManagerServer","TextInputHost","MessagingPlugin","SystemNotificationPlugin",
                "AppProvisioningPlugin","RadeonSoftware","CPUMetricsServer","LenovoVantage-(VantageCoreAddin)",
                "SecurityHealthSystray","SecurityHealthService","cncmd","cmd","AMDRSServ","crashhelper",
                "AMDRSSrcExt","Lenovo.Modern.ImController.PluginHost.Device",
                "LenovoVantage-(GenericMessagingAddin)","Locator","WmiApSrv","UserOOBEBroker",
                "dllhost","msedge","ApplicationFrameHost","SystemSettings","smartscreen","audiodg",
                "UserSSCtrl","WaaSMedicAgent","OneDrive.Sync.Service","backgroundTaskHost",
                "DataExchangeHost","ShellHost","devenv","PerfWatson2","StandardCollector.Service",
                "Microsoft.ServiceHub.Controller","ServiceHub.VSDetouredHost","ServiceHub.IdentityHost",
                "ServiceHub.ThreadedWaitDialog","ServiceHub.RoslynCodeAnalysisService",
                "ServiceHub.IntellicodeModelService","ServiceHub.Host.dotnet.x64",
                "ServiceHub.IndexingService","ServiceHub.TestWindowStoreHost","symsrvhost",
                "ServiceHub.DataWarehouseHost","MSBuild","VBCSCompiler","DesignToolsServer",
                "FileGen","Taskmgr","wscript"
            };

            bool mainLoop = true;

            bool isWhitelist = false;

            bool isBlacklist = false;

            bool restrictBackgroundProcesses = false;

            bool enforceTimeLimit = false;

            bool storeTimeLimitLocally = true;

            bool checkForUpdates = false;

            bool allowReqProcesses = true;

            int timeLimit = 999999999; //Time in minutes

            Dictionary<string, int> timeLimitPerAppName = new Dictionary<string, int>();

            List<string> AllowedProcessList = new List<string>();
            List<string> BannedProcessList = new List<string>();

            // parse into JSON format:

            using JsonDocument JSONdoc = JsonDocument.Parse(restrictFileContent);

            JsonElement JsonRootElement = JSONdoc.RootElement;

            //read bools:

            if (JsonRootElement.TryGetProperty("isWhitelist", out JsonElement isWhitelistElement)) {
                isWhitelist = isWhitelistElement.GetBoolean();
            }

            if (JsonRootElement.TryGetProperty("isBlacklist", out JsonElement isBlacklistElement))
            {
                isBlacklist = isBlacklistElement.GetBoolean();
            }

            if (JsonRootElement.TryGetProperty("restrictBackground", out JsonElement restrictBackgroundElement))
            {
                restrictBackgroundProcesses = restrictBackgroundElement.GetBoolean();
            }

            if (JsonRootElement.TryGetProperty("enforceTimeLimit", out JsonElement enforceTimeLimitElement))
            {
                enforceTimeLimit = enforceTimeLimitElement.GetBoolean();
            }

            if (JsonRootElement.TryGetProperty("checkForUpdates", out JsonElement checkForUpdatesElement))
            {
                checkForUpdates = checkForUpdatesElement.GetBoolean();
            }

            if (JsonRootElement.TryGetProperty("storeTimeInAppdata", out JsonElement storeTimeInAppdataElement))
            {
                storeTimeLimitLocally = storeTimeInAppdataElement.GetBoolean();
            }

            if (JsonRootElement.TryGetProperty("allowReqProcesses", out JsonElement allowReqProcessesElement))
            {
                allowReqProcesses = allowReqProcessesElement.GetBoolean();
            }

            // Try and get lists and dictionaries:

            if (JsonRootElement.TryGetProperty("allowedProcesses", out JsonElement allowedProcessesElement))
            {
                foreach (JsonElement item in allowedProcessesElement.EnumerateArray()) {
                    AllowedProcessList.Add(item.GetString());
                }
            }

            if (JsonRootElement.TryGetProperty("bannedProcesses", out JsonElement bannedProcessesElement))
            {
                foreach (JsonElement item in bannedProcessesElement.EnumerateArray())
                {
                    BannedProcessList.Add(item.GetString());
                }
            }

            if (JsonRootElement.TryGetProperty("timeLimitPerAppName", out JsonElement timeDictElem))
            {
                foreach (JsonProperty prop in timeDictElem.EnumerateObject())
                {
                    timeLimitPerAppName[prop.Name] = prop.Value.GetInt32();
                }
            }

            // Timelimit

            if (JsonRootElement.TryGetProperty("timeLimit", out JsonElement timeLimitElement))
            {
                timeLimit = timeLimitElement.GetInt32();
            }



            List<string> RequiredProcesses = new List<string>();


            //Main loop
            while (mainLoop) {

                //MessageBox.Show("Not using legacy is currently unsupported");

                //break;
                Process[] processes;
                if (restrictBackgroundProcesses)
                {
                    // All processes
                    processes = Process.GetProcesses();
                }
                else
                {
                    // Only processes with a main window
                    processes = Process.GetProcesses()
                                       .Where(p => p.MainWindowHandle != IntPtr.Zero &&
                                                   !string.IsNullOrWhiteSpace(p.MainWindowTitle))
                                       .ToArray();
                }


                if (isWhitelist)
                {
                    foreach (Process process in processes)
                    {
                        if (allowReqProcesses && systemReq.Contains(process.ProcessName))
                        {

                        }
                        else
                        {
                            if (!(AllowedProcessList.Contains(process.ProcessName) || AllowedProcessList.Contains(process.ToString()) || RequiredProcesses.Contains(process.ProcessName)))
                            {
                                process.Kill(true);
                            }
                            else
                            {
                                Console.WriteLine($"${process.ProcessName} is either a required process or is in the allowed list");
                            }
                        }
                    }
                }
                if (isBlacklist) {
                    foreach (Process process in processes) {
                        if ((BannedProcessList.Contains(process.ProcessName) || BannedProcessList.Contains(process.ToString())) && (!RequiredProcesses.Contains(process.ProcessName))) { 
                            process.Kill(true);
                        }
                    }
                }



                    Thread.Sleep(125);
            }
        }
    }
}