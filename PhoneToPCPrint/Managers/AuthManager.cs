using System.Collections.Generic;

public static class AuthManager
{
    private static readonly Dictionary<string, string> _clients = new Dictionary<string, string>();

    public static void Register(AuthRequest req)
    {
        _clients[req.ClientId] = SecurityManager.Hash(req.Token);
    }

    public static bool Validate(string id, string token)
    {
        return _clients.ContainsKey(id) &&
               _clients[id] == SecurityManager.Hash(token);
    }

    public static void Remove(string id)
    {
        if (_clients.ContainsKey(id))
            _clients.Remove(id);
    }
}