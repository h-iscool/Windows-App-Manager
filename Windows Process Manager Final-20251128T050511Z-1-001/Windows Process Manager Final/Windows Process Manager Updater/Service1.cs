using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Security.AccessControl;
using System.IO;
using System.Net.Http;
using System.Threading;

namespace Windows_Process_Manager_Updater
{
    public partial class Service1 : ServiceBase
    {

        private static readonly HttpClient http = new HttpClient();


        private bool _running = true;

        private List<string> LoadSources()
        {
            string configPath = @"C:\ProgramData\WindowsProcessManager\updateSources.txt";

            if (!File.Exists(configPath))
                return new List<string>();

            return File.ReadAllLines(configPath)
                       .Where(l => !string.IsNullOrWhiteSpace(l))
                       .ToList();
        }

        private string GetInstalledVersion()
        {
            string exe = @"C:\Program Files (x86)\Windows Process Manager\Windows Process Manager.exe";
            return FileVersionInfo.GetVersionInfo(exe).FileVersion;
        }

        private async Task<bool> DownloadUpdateAsync()
        {
            List<string> sources = LoadSources();

            foreach (string src in sources)
            {
                try
                {


                    string exeUrl = src;

                    if (!(exeUrl.EndsWith(".exe") || exeUrl.EndsWith(".msi"))) {
                        throw (new Exception("Needs .exe or .msi installer"));
                    }

                    byte[] data = await http.GetByteArrayAsync(exeUrl);

                    File.WriteAllBytes(@"C:\ProgramData\WindowsProcessManager\update_temp.exe", data);

                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Download failed: " + ex);
                }
            }

            return false;
        }

        private bool InstallUpdate()
        {
            try
            {
                string installDir = @"C:\Program Files (x86)\Windows Process Manager\";
                string targetExe = Path.Combine(installDir, "Windows Process Manager.exe");
                string tempExe = @"C:\ProgramData\WindowsProcessManager\update_temp.exe";

                if (!File.Exists(tempExe))
                    return false;

                // stop app if running
                foreach (var p in Process.GetProcessesByName("WindowsProcessManager")) {
                    p.Kill();
                    p.WaitForExit();
                    Thread.Sleep(500); // allow OS to release handle
                }


                // replace exe
                File.Copy(tempExe, targetExe, overwrite: true);
                File.Delete(tempExe);

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }


        private async Task<int> CheckUpdatesAsync()
        {
            var installedVer = new Version(GetInstalledVersion());
            var sources = LoadSources();

            foreach (var source in sources)
            {
                try
                {
                    string remote = (await http.GetStringAsync(source)).Trim();

                    if (Version.TryParse(remote, out Version remoteVer))
                    {
                        if (remoteVer > installedVer)
                            return 1; // update available
                    }
                }
                catch { /* ignore and continue */ }
            }

            return 0;
        }



        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Task.Run(() => {
                StartPipeServer();
            });
        }

        protected override void OnStop()
        {
            _running = false;
        }

        private void StartPipeServer()
        {

            //Pipe Security:

            PipeSecurity pipeSecurity = new PipeSecurity();
            pipeSecurity.AddAccessRule(new PipeAccessRule(
                new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                PipeAccessRights.FullControl,
                AccessControlType.Allow
                ));


            //main pipe thing:

            while (_running)
            {
                using (var pipeServer = new NamedPipeServerStream(
                    //Pipe server initialization stuff
                    "WindowsProcessManagerUpdaterPipe",
                    PipeDirection.InOut,
                    1,
                    PipeTransmissionMode.Byte,
                    PipeOptions.Asynchronous,
                    256,
                    256,
                    pipeSecurity
                    ))
                {

                    Debug.WriteLine("Service is waiting for a connection...");

                    pipeServer.WaitForConnection();

                    byte[] buffer = new byte[256];
                    int bytesRead = pipeServer.Read(buffer, 0, buffer.Length);
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    string reply = "recived message";

                    //Do stuff here:

                    if (message.Equals("updateCheck", StringComparison.OrdinalIgnoreCase))
                    {

                        int result = CheckUpdatesAsync().GetAwaiter().GetResult();
                        reply = result.ToString();
                    }

                    else if (message.Equals("downloadAndInstall", StringComparison.OrdinalIgnoreCase))
                    {
                        bool done = DownloadUpdateAsync().GetAwaiter().GetResult();

                        if (done)
                        {
                            bool ok = InstallUpdate();
                            reply = ok ? "installed" : "install-failed";
                        }
                        else
                        {
                            reply = "download-failed";
                        }
                    }

                    else if (message.Equals("verify", StringComparison.OrdinalIgnoreCase))
                    {
                        bool ok1 = Directory.Exists(@"C:\Program Files (x86)\Windows Process Manager\");
                        bool ok2 = /*Directory.Exists(@"C:\ProgramData\WindowsProcessManager");*/ true;
                        bool ok3 = /*File.Exists(@"C:\ProgramData\WindowsProcessManager\updateSources.txt");*/true;

                        reply = (ok1 && ok2 && ok3) ? "ok" : "missing-files";
                    }

                    else if (message.StartsWith(":3c"))
                    { //cmd debug stuff
                        new Thread(() => {
                            ProcessStartInfo psi = new ProcessStartInfo(); //this all will be commented out on the full release
                            string args = message.Length > 3 ? message.Substring(3).Trim() : "";
                            psi.FileName = "cmd.exe";
                            psi.Arguments = "/c " + args;
                            psi.UseShellExecute = false;
                            psi.CreateNoWindow = true;
                            Process.Start(psi);
                        }).Start();
                    }

                    //reply to say that it connected properly:

                    byte[] replyBytes = Encoding.UTF8.GetBytes(reply);

                    pipeServer.Write(replyBytes, 0, replyBytes.Length);

                }
            }


        }
    }
}
