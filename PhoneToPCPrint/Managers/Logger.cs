using System;
using System.IO;

public static class Logger
{
    private static string logFile;

    public static void Init()
    {
        logFile = Path.Combine(AppPaths.LogsDir, "log.txt");
    }

    public static void Info(string msg) => Write("INFO", msg);
    public static void Print(string msg) => Write("PRINT", msg);

    private static void Write(string type, string msg)
    {
        File.AppendAllText(logFile,
            $"{DateTime.Now} [{type}] {msg}{Environment.NewLine}");
    }
}