using System.IO;

public static class ConfigManager
{
    public static int Port = 8080;
    public static int MaxConnections = 5;
    public static int Interval = 100;
    public static long MaxFileSize = 10485760;

    public static string FilesDir = "Saves";
    public static string LogsDir = "Logs";

    public static void Load()
    {
        string path = AppPaths.ConfigPath;

        if (!File.Exists(path))
        {
            File.WriteAllText(path,
    @"[config]
port ; 8080
conns ; 5
innit ; 100
filesdir ; Saves
logdir ; Logs");
        }

        Directory.CreateDirectory(AppPaths.SavesDir);
        Directory.CreateDirectory(AppPaths.LogsDir);
    }
}