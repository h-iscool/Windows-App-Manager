using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Reflection;

public class UpdateInfo
{
    public string version { get; set; }
    public string[] urls { get; set; }
}

public class Updater
{
    private readonly string[] _versionJsonUrls;

    public Updater(string[] versionJsonUrls)
    {
        _versionJsonUrls = versionJsonUrls;
    }

    public async Task CheckAndUpdateAsync()
    {
        UpdateInfo? updateInfo = null;

        using var http = new HttpClient();

        // Try each JSON URL until one works
        foreach (var jsonUrl in _versionJsonUrls)
        {
            try
            {
                string json = await http.GetStringAsync(jsonUrl);
                updateInfo = JsonSerializer.Deserialize<UpdateInfo>(json);
                if (updateInfo != null)
                {
                    Console.WriteLine($"Got update info from: {jsonUrl}");
                    break;
                }
            }
            catch
            {
                Console.WriteLine($"Failed to fetch update info from: {jsonUrl}");
                // try next
            }
        }

        if (updateInfo == null)
        {
            Console.WriteLine("Failed to retrieve update info from all sources.");
            return;
        }

        if (!Version.TryParse(updateInfo.version, out Version remoteVersion))
        {
            Console.WriteLine("Invalid version format in update info.");
            return;
        }

        Version currentVersion = Assembly.GetExecutingAssembly().GetName().Version!;

        if (remoteVersion <= currentVersion)
        {
            Console.WriteLine($"No update needed. Current version: {currentVersion}, remote: {remoteVersion}");
            return;
        }

        Console.WriteLine($"Update available! Current version: {currentVersion}, new version: {remoteVersion}");

        // Try each installer URL
        foreach (var installerUrl in updateInfo.urls)
        {
            try
            {
                Console.WriteLine($"Trying to download installer from: {installerUrl}");
                var installerBytes = await http.GetByteArrayAsync(installerUrl);

                string tempPath = Path.Combine(Path.GetTempPath(), "update_installer.exe");
                await File.WriteAllBytesAsync(tempPath, installerBytes);

                Console.WriteLine("Running installer...");
                Process.Start(new ProcessStartInfo
                {
                    FileName = tempPath,
                    UseShellExecute = true
                });

                Environment.Exit(0);
                break; // Won't reach here, but good practice
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to download or run installer from {installerUrl}: {ex.Message}");
                // try next URL
            }
        }
    }
}
