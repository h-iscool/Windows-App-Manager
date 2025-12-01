using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Update_Worker
{


    internal class Program
    {



        static async Task<bool> CheckConnection(string URL) {
            try {
                using (HttpClient client = new HttpClient()) { 
                    HttpResponseMessage response = await client.GetAsync(URL,HttpCompletionOption.ResponseHeadersRead);
                    return response.IsSuccessStatusCode;
                }
            }
            catch { 
                return false;
            }
        }

        static async Task<bool> DownloadFromUrl(string url, string outputFile) {
            try
            {
                using (HttpClient client = new HttpClient()) {
                    using (HttpResponseMessage responce = await client.GetAsync(url)) { 
                        responce.EnsureSuccessStatusCode();

                        byte[] data = await responce.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(outputFile, data);

                        return true;
                    }
                }
            }
            catch (Exception ex){
                Console.WriteLine("Error: "+ex.Message);
                return false;
            }
        }

        static async Task<bool> InstallMsi(string path) {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "msiexec.exe";
                process.StartInfo.Arguments = $"/i \"{path}\" /quiet /norestart";
                process.StartInfo.UseShellExecute = false;

                process.Start();
                process.WaitForExit();

                return process.ExitCode == 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("MSI Install Error: " + ex.Message);
                return false;
            }
        }

        public class UpdaterSettings
        {
            public bool AutoUpdate { get; set; }
            public bool UseServerFile { get; set; }
            public List<string> VersionURLs { get; set; }
            public List<string> UpdateURLs { get; set; }
            public List<string> RestrictionURLs { get; set; }
        }


        static void Main(string[] args)
        {

            UpdaterSettings _updaterSettings = new UpdaterSettings();

            string settingsPath = @"C:\Program Files (x86)\Windows Process Manager\settings.json";

            try
            {
                string json = File.ReadAllText(settingsPath);
                _updaterSettings = JsonSerializer.Deserialize<UpdaterSettings>(json);
            }
            catch
            {
                _updaterSettings = new UpdaterSettings(); // fallback
            }

            // arg syntax:
            Console.WriteLine("Args:");
            foreach (string arg in args) { 
                Console.WriteLine(arg);
            }
            Console.WriteLine("\n");

            if (args.Length != 0) {

                if (args.Contains("--download"))
                {
                    int index = Array.IndexOf(args, "--download");

                    if (index >= 0 && index < args.Length - 1)
                    {
                        string downloadUrl = args[index + 1];
                        Console.WriteLine("URL: " + downloadUrl);

                        if (index < args.Length - 2)
                        {
                            string downloadFile = args[index + 2];
                            Console.WriteLine($"{downloadFile}");
                            bool result = DownloadFromUrl(downloadUrl, downloadFile).GetAwaiter().GetResult();
                            if (result)
                            {
                                Console.WriteLine("Download finished!");
                            }
                            else
                            {
                                Console.WriteLine("Download failed");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No inputted file output location");
                        }

                    }
                    else
                    {
                        Console.WriteLine("No URL input provided after --download.");
                    }
                }

                if (args.Contains("--install")) {

                    int index = Array.IndexOf(args, "--install");

                    if (index >= 0 && index < args.Length - 1) { 
                        string installerMsiPath = args[index + 1];
                        Console.WriteLine($"Installer: {installerMsiPath}");
                        if (File.Exists(installerMsiPath))
                        {
                            bool result = InstallMsi(installerMsiPath).GetAwaiter().GetResult();
                            if (!result)
                            {
                                Console.WriteLine("install failed");
                            }
                            else {
                                Console.WriteLine("Installed");
                            }
                        }
                        else { 
                            Console.WriteLine("Installer doesn't exist");
                        }
                    }
                }

                if (args.Contains("--downloadAndInstall")) {
                    int index = Array.IndexOf(args, "--downloadAndInstall");

                    if (index >= 0 && index < args.Length - 1)
                    {
                        string installerURL = args[index + 1];

                        Console.WriteLine("Installer URL: " + installerURL);

                        string tempDir = Path.Combine(Path.GetTempPath(), "WindowsProcessManagerUpdater");
                        Directory.CreateDirectory(tempDir);

                        string tempPath = Path.Combine(tempDir, "installer.msi");

                        bool downloaded = DownloadFromUrl(installerURL, tempPath).GetAwaiter().GetResult();

                        if (downloaded)
                        {
                            Console.WriteLine("Downloaded!");
                            bool installed = InstallMsi(tempPath).GetAwaiter().GetResult();
                            if (installed)
                            {
                                Console.WriteLine("installed successfully");
                            }
                            else
                            {
                                Console.WriteLine("couldn't install");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Couldn't download");
                        }


                    }
                    else {
                        Console.WriteLine("Needs an MSI url");
                    }
                }

                if (args.Contains("--downloadAndInstallFromSettingsFile"))
                {
                    //int index = Array.IndexOf(args, "--downloadAndInstallFromSettingsFile");

                    bool installedSucessfully = false;

                    _updaterSettings.UpdateURLs.ForEach(url =>
                    {
                        if (!installedSucessfully)
                        {
                            string installerURL = url;

                            Console.WriteLine("Installer URL: " + installerURL);

                            string tempDir = Path.Combine(Path.GetTempPath(), "WindowsProcessManagerUpdater");
                            Directory.CreateDirectory(tempDir);

                            string tempPath = Path.Combine(tempDir, "installer.msi");

                            bool downloaded = DownloadFromUrl(installerURL, tempPath).GetAwaiter().GetResult();

                            if (downloaded)
                            {
                                Console.WriteLine("Downloaded!");
                                bool installed = InstallMsi(tempPath).GetAwaiter().GetResult();
                                if (installed)
                                {
                                    installedSucessfully = true;
                                    Console.WriteLine("installed successfully");
                                }
                                else
                                {
                                    Console.WriteLine("couldn't install");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Couldn't download");
                            }
                        }
                    });
                    }

                if (args.Contains("--checkRestrictFile"))
                {
                    string filePath = @"C:\ProgramData\WindowsProcessManager\restrictionFile.json";
                    if (_updaterSettings.UseServerFile)
                    {
                        bool dowloadedFile = false;
                        _updaterSettings.RestrictionURLs.ForEach(url => {
                            if (!dowloadedFile) {
                                dowloadedFile = DownloadFromUrl(url, filePath).GetAwaiter().GetResult();
                            }
                        });
                    }
                    else {
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
                                catch { 
                                    
                                }
                            }
                        });
                    }
                }

            }
        }
    }
}
