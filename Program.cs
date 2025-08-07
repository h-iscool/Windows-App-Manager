// Imports:
using System;
using System.Buffers.Text;
using System.Diagnostics;
using System.IO;
using System.Text;

// Define isLegacy var:
bool isLegacy = false;

//Check if legacy:

string restrictFilePath = "processList.appreistr";

if (!File.Exists(restrictFilePath)){
    Debug.WriteLine("No file exists, exiting...");
    Environment.Exit(0x1); //Exit with code 1
}

string restrictFileContent = File.ReadAllText(restrictFilePath);

restrictFileContent = Encoding.UTF8.GetString(Convert.FromBase64String(restrictFileContent));

Debug.WriteLine($"\nFile content:\n{restrictFileContent}\n");

if (restrictFileContent == null) {
    Debug.WriteLine("No file content found, exiting...");
    Environment.Exit(0x2);
}

if (restrictFileContent[0] == '#') {
    Debug.WriteLine("!!!LEGACY MODE!!!");
    isLegacy = true;
}

//Legacy support:
if (isLegacy) {
    //setup vars:
    string? tempReader=null;
    bool? whitelist=null;
    bool? restrictbg = null;
    int semicolonCount = 0;
    List<string> processList= new List<string>();
    bool mainLoop = true;

    for (int i = 0; restrictFileContent.Length > i; i++) { //read file:
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
            if (restrictbg == null) {//write restrictbg var
                if (tempReader == "#RESTRICTALLPROCESSES")
                {
                    Debug.WriteLine("Restrict all processes");
                    restrictbg = true;
                }
                else {
                    Debug.WriteLine("Restrict window processes");
                    restrictbg = false;
                }
            }
            if (semicolonCount > 4 && tempReader!=null) {
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

            tempReader=null;
        }
        else {
            tempReader +=restrictFileContent[i];
        }
    }

    while (mainLoop) {

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
        else {
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
