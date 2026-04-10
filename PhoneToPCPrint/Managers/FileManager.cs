using System.IO;

public static class FileManager
{
    public static string Save(PrintRequest req)
    {
        string dir = Path.Combine(AppPaths.SavesDir, req.ClientId);
        Directory.CreateDirectory(dir);

        string path = Path.Combine(dir, req.FileName);
        File.WriteAllBytes(path, req.FileData);

        return path;
    }

    public static bool Delete(FileRequest req)
    {
        string path = Path.Combine(ConfigManager.FilesDir, req.ClientId, req.FileName);

        if (!File.Exists(path)) return false;

        File.Delete(path);
        return true;
    }

    public static string[] List(string clientId)
    {
        string dir = Path.Combine(ConfigManager.FilesDir, clientId);
        if (!Directory.Exists(dir)) return new string[0];

        return Directory.GetFiles(dir);
    }
}