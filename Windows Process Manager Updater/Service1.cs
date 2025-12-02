using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.Http;
using System.Runtime;
using System.Security.AccessControl;
using System.Security.Principal;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq.Expressions;

namespace Windows_Process_Manager_Updater
{
    public partial class Service1 : ServiceBase
    {

        



        private bool _running = true;

        public class UpdaterSettings
        {
            public bool AutoUpdate { get; set; }
            public bool UseServerFile { get; set; }
            public List<string> VersionURLs { get; set; }
            public List<string> UpdateURLs { get; set; }
            public List<string> RestrictionURLs { get; set; }
        }

        private UpdaterSettings _updaterSettings;

        private void LoadSettings()
        {
            string path = @"C:\Program Files (x86)\Windows Process Manager\settings.json";

            if (!File.Exists(path))
            {
                _updaterSettings = new UpdaterSettings()
                {
                    AutoUpdate = true,
                    UseServerFile = false,
                    VersionURLs = new List<string>(),
                    UpdateURLs = new List<string>(),
                    RestrictionURLs = new List<string>()
                };
                return;
            }

            try
            {
                string json = File.ReadAllText(path);
                _updaterSettings = JsonSerializer.Deserialize<UpdaterSettings>(json);
            }
            catch
            {
                _updaterSettings = new UpdaterSettings(); // fallback
            }
        }


        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            LoadSettings();
            Task.Run(() => {
                StartPipeServer();
            });
        }

        protected override void OnStop()
        {
            _running = false;
        }

        private string workerPath = Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory,
        "Update Worker.exe"
        );


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


                        pipeServer.WaitForConnection();

                        byte[] buffer = new byte[256];
                        int bytesRead = pipeServer.Read(buffer, 0, buffer.Length);
                        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                        string reply = "recived message";

                        //Do stuff here:

                        if (message.Equals("updateCheck", StringComparison.OrdinalIgnoreCase))
                        {
                        reply = "update check moved to GUI app and is checked again when updating";
                            
                        }

                        else if (message.Equals("downloadAndInstall", StringComparison.OrdinalIgnoreCase))
                        {
                            new Thread(() => {
                                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                                processStartInfo.FileName = workerPath;
                                processStartInfo.Arguments = "--downloadAndInstallFromSettingsFile";
                                processStartInfo.UseShellExecute = false;
                                processStartInfo.CreateNoWindow = true;
                                Process.Start(processStartInfo);
                            });
                        }

                    else if (message.Equals("checkRestrictFile", StringComparison.OrdinalIgnoreCase))
                    {
                        new Thread(() => {
                            ProcessStartInfo processStartInfo = new ProcessStartInfo();
                            processStartInfo.FileName = workerPath;
                            processStartInfo.Arguments = "--checkRestrictFile";
                            processStartInfo.UseShellExecute = false;
                            processStartInfo.CreateNoWindow = true;
                            Process.Start(processStartInfo);
                        });
                    }


                    else if (message.Equals("verify", StringComparison.OrdinalIgnoreCase))
                        {
                            bool ok1 = Directory.Exists(@"C:\Program Files (x86)\Windows Process Manager\");
                            bool ok2 = /*Directory.Exists(@"C:\ProgramData\WindowsProcessManager");*/ true;
                            bool ok3 = /*File.Exists(@"C:\ProgramData\WindowsProcessManager\updateSources.txt");*/true;

                            reply = (ok1 && ok2 && ok3) ? "=^.^=\nall good" : "missing-files";
                        }

                        // else if (message.StartsWith(":3c"))
                        // { //cmd debug stuff
                        //     new Thread(() =>
                        //     {
                        //         ProcessStartInfo psi = new ProcessStartInfo(); //this all will be commented out on the full release
                        //         string args = message.Length > 3 ? message.Substring(3).Trim() : "";
                        //         psi.FileName = "cmd.exe";
                        //         psi.Arguments = "/c " + args;
                        //         psi.UseShellExecute = false;
                        //         psi.CreateNoWindow = true;
                        //         Process.Start(psi);
                        //     }).Start();
                        // }

                        //reply to say that it connected properly:

                        byte[] replyBytes = Encoding.UTF8.GetBytes(reply);

                        pipeServer.Write(replyBytes, 0, replyBytes.Length);

                    }

                }
           


        }
    }
}
//lmao i deleted >200 lines of code cause it should have been in a worker