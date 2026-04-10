using System;
using System.IO;

public static class AppPaths
{
    public static string BaseDir =>
        AppDomain.CurrentDomain.BaseDirectory;

    public static string ConfigPath =>
        Path.Combine(BaseDir, "settings.config");

    public static string SavesDir =>
        Path.Combine(BaseDir, "Saves");

    public static string LogsDir =>
        Path.Combine(BaseDir, "Logs");
}