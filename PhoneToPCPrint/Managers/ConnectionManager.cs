using System.Collections.Concurrent;
using System.Linq;

public static class ConnectionManager
{
    private static readonly ConcurrentDictionary<string, bool> _clients =
        new ConcurrentDictionary<string, bool>();

    public static bool TryAdd(string clientId)
    {
        if (_clients.Count >= ConfigManager.MaxConnections)
            return false;

        return _clients.TryAdd(clientId, true);
    }

    public static void Remove(string clientId)
    {
        _clients.TryRemove(clientId, out _);
    }

    public static bool IsConnected(string clientId)
    {
        return _clients.ContainsKey(clientId);
    }

    public static string[] GetAll()
    {
        return _clients.Keys.ToArray();
    }

    public static int Count => _clients.Count;
}