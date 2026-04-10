using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace PhoneToPCPrint
{
    public static class ApiHandlers
    {
        public static void Connect(HttpListenerContext ctx)
        {
            var req = Read<AuthRequest>(ctx);

            if (!ConnectionManager.TryAdd(req.ClientId))
            {
                Respond(ctx, "FULL");
                return;
            }

            AuthManager.Register(req);
            Logger.Info($"Connected: {req.ClientId}");

            Respond(ctx, "CONNECTED");
        }

        public static void Disconnect(HttpListenerContext ctx)
        {
            var req = Read<AuthRequest>(ctx);

            ConnectionManager.Remove(req.ClientId);
            AuthManager.Remove(req.ClientId);

            Logger.Info($"Disconnected: {req.ClientId}");
            Respond(ctx, "DISCONNECTED");
        }

        public static void Print(HttpListenerContext ctx)
        {
            var req = Read<PrintRequest>(ctx);

            if (!AuthManager.Validate(req.ClientId, req.Token))
            {
                Respond(ctx, "UNAUTHORIZED");
                return;
            }

            if (req.FileData.Length > ConfigManager.MaxFileSize)
            {
                Respond(ctx, "FILE_TOO_LARGE");
                return;
            }

            string path = FileManager.Save(req);

            QueueManager.Enqueue(path);
            Logger.Print($"Queued: {path}");

            Respond(ctx, "PRINT_QUEUED");
        }

        public static void Delete(HttpListenerContext ctx)
        {
            var req = Read<FileRequest>(ctx);

            if (!AuthManager.Validate(req.ClientId, req.Token))
            {
                Respond(ctx, "UNAUTHORIZED");
                return;
            }

            bool ok = FileManager.Delete(req);
            Respond(ctx, ok ? "DELETED" : "NOT_FOUND");
        }

        public static void List(HttpListenerContext ctx)
        {
            var req = Read<AuthRequest>(ctx);

            if (!AuthManager.Validate(req.ClientId, req.Token))
            {
                Respond(ctx, "UNAUTHORIZED");
                return;
            }

            var files = FileManager.List(req.ClientId);
            Respond(ctx, JsonConvert.SerializeObject(files));
        }

        private static T Read<T>(HttpListenerContext ctx)
        {
            using (var r = new StreamReader(ctx.Request.InputStream))
                return JsonConvert.DeserializeObject<T>(r.ReadToEnd());
        }

        public static void Respond(HttpListenerContext ctx, string msg)
        {
            byte[] buf = Encoding.UTF8.GetBytes(msg);
            ctx.Response.OutputStream.Write(buf, 0, buf.Length);
            ctx.Response.Close();
        }
    }
}