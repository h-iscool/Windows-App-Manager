using System.Diagnostics;
using System.Drawing;
using System.IO.Pipes;
using System.Text;
using System.Text.Json;

namespace Windows_App_Manager_Worker {
    internal class Program {

        public class UpdaterSettings
        {
            public bool AutoUpdate { get; set; }
            public bool UseServerFile { get; set; }
            public List<string> VersionURLs { get; set; } = new List<string>();
            public List<string> UpdateURLs { get; set; } = new List<string>();
            public List<string> RestrictionURLs { get; set; } = new List<string>();
        }

        public class RestrictonData {
            public bool UseWhitelist { get; set; }
            public bool UseBlacklist { get; set; }
            public bool RestrictBackground { get; set; } = false;
            public bool RestrictSystem { get; set; }
            public List<string> ProcessNames { get; set; } = new List<string>();

        }

        

        private static void SendPipe(string msg) {
            try
            {
                string message = msg;

                if (Encoding.UTF8.GetBytes(message).Length > 255)
                {
                    throw new Exception("message is too large to send");
                }

                using (NamedPipeClientStream client = new NamedPipeClientStream(
                    ".",
                    "WindowsProcessManagerUpdaterPipe",
                    PipeDirection.InOut
                    ))
                {
                    client.Connect(5000);
                    byte[] msgBytes = Encoding.UTF8.GetBytes(message);
                    client.Write(msgBytes, 0, msgBytes.Length);
                    byte[] buffer = new byte[256];
                    int bytesRead = client.Read(buffer, 0, buffer.Length);
                    string responce = Encoding.UTF8.GetString(buffer);
                    client.Close();
                    Console.WriteLine(responce + "\n");

                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString() + "\n");
            }
        }

        public static bool NeedsUpdate(string url, string localExePath)
        {
            try
            {
                // Get local version
                var localVersion = FileVersionInfo.GetVersionInfo(localExePath).FileVersion;
                if (string.IsNullOrEmpty(localVersion))
                    return false; // can't check

                Version localVer = new Version(localVersion);

                // Get remote version from URL
                string remoteVersionString = new HttpClient()
                    .GetStringAsync(url)
                    .GetAwaiter()
                    .GetResult()
                    .Trim();

                if (Version.TryParse(remoteVersionString, out Version? remoteVer) && remoteVer != null)
                {
                    return remoteVer > localVer; // true if remote is newer
                }
            }
            catch
            {
                // ignore errors, just return false
            }

            return false;
        }

        static async Task<bool> DownloadFromUrl(string url, string outputFile)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage responce = await client.GetAsync(url))
                    {
                        responce.EnsureSuccessStatusCode();

                        byte[] data = await responce.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(outputFile, data);

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        static void Main(string[] args) {



            int timeoutTime = 1000;//ms

            Console.WriteLine("Settings init...");

            UpdaterSettings _updaterSettings = new UpdaterSettings();

            string settingsPath = @"C:\Program Files (x86)\Windows Process Manager\settings.json";

            try
            {
                string json = File.ReadAllText(settingsPath);
                _updaterSettings = JsonSerializer.Deserialize<UpdaterSettings>(json) ?? new UpdaterSettings();
            }
            catch
            {
                _updaterSettings = new UpdaterSettings(); // fallback
            }

            Console.WriteLine("checking for update...");
            bool needsUpdate = false;
            foreach (var item in _updaterSettings.VersionURLs)
            {
                if (!needsUpdate) {
                    if (NeedsUpdate(item, @"C:\Program Files (x86)\Windows Process Manager\Windows Process Manager.exe")) { 
                        needsUpdate = true;
                    }
                }
            }

            if (needsUpdate) {
                Console.WriteLine("needs an update");
                if (_updaterSettings.AutoUpdate) {
                    SendPipe("downloadAndInstall");
                }
                else
                {
                    Console.WriteLine("Auto Updates dissabled");
                }
            }
            else
            {
                Console.WriteLine("No update needed");
            }

            Console.WriteLine("checking restriction file...");
            //SendPipe("checkRestrictFile");

            string filePath = Path.Combine(Path.GetTempPath(), "restrictionSettings.json");
            if (_updaterSettings.UseServerFile)
            {
                bool dowloadedFile = false;
                _updaterSettings.RestrictionURLs.ForEach(url => {
                    if (!dowloadedFile)
                    {
                        dowloadedFile = DownloadFromUrl(url, filePath).GetAwaiter().GetResult();
                    }
                });
            }
            else
            {
                bool copied = false;

                _updaterSettings.RestrictionURLs.ForEach(path =>
                {
                    if (!copied)
                    {
                        try
                        {
                            if (File.Exists(path))
                            {
                                File.Copy(path, filePath, overwrite: true);
                                copied = true;
                                Console.WriteLine($"Copied restriction file from: {path}");
                            }
                        }
                        catch
                        {
                            Console.WriteLine($"couldnt copy");
                        }
                    }
                });
            }

            Console.WriteLine($"timing out for {timeoutTime}");
            Thread.Sleep(timeoutTime);
            Console.WriteLine("Starting restrictor");

            RestrictonData _restrictionData = new RestrictonData();

            try
            {
                string json = File.ReadAllText(filePath);
                _restrictionData = JsonSerializer.Deserialize<RestrictonData>(json) ?? new RestrictonData();
            }
            catch
            {
                _restrictionData = new RestrictonData(); // fallback
                Console.WriteLine("ERR NO DATA");
            }

            bool _running = true;

            while (_running)
            {
                Process[] processes; 
                if (_restrictionData.RestrictSystem || _restrictionData.RestrictBackground)
                {
                    processes = Process.GetProcesses();
                }
                else {
                    processes = Process.GetProcesses()
            .Where(p => p.MainWindowHandle != IntPtr.Zero && !string.IsNullOrWhiteSpace(p.MainWindowTitle)).ToArray();
                }

                    foreach (Process process in processes)
                    {

                        if (_restrictionData.UseWhitelist)
                        {
                        if (!(_restrictionData.ProcessNames.Contains(process.ProcessName)))
                        {
                            try
                            {
                                Console.WriteLine($"killing: {process.ProcessName}");
                                process.Kill();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                        }
                        }
                        else if (_restrictionData.UseBlacklist)
                        {
                            if (_restrictionData.ProcessNames.Contains(process.ProcessName))
                            {
                            try
                            {
                                Console.WriteLine($"killing: {process.ProcessName}");
                                process.Kill();
                            }
                            catch (Exception ex) { 
                                Console.WriteLine(ex.ToString()); 
                            }
                            }
                        }

                    }
                //Console.WriteLine("tick");
                Thread.Sleep(125); // 1/8sec delay to not *murder cutely* the cpu thread... :3
            }

        }
    }
}