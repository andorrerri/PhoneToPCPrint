using System.Net;
using System.Threading.Tasks;

namespace PhoneToPCPrint
{
    public class HttpServer
    {
        private HttpListener _listener;

        public void Start()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add($"http://*:{ConfigManager.Port}/");
            _listener.Start();

            Task.Run(Listen);
            Logger.Info("Server started");
        }

        public void Stop()
        {
            _listener?.Stop();
        }

        private async Task Listen()
        {
            while (true)
            {
                var ctx = await _listener.GetContextAsync();
                _ = Task.Run(() => Handle(ctx));
            }
        }

        private void Handle(HttpListenerContext ctx)
        {
            string path = ctx.Request.Url.AbsolutePath.ToLower();

            switch (path)
            {
                case "/connect": ApiHandlers.Connect(ctx); break;
                case "/disconnect": ApiHandlers.Disconnect(ctx); break;
                case "/print": ApiHandlers.Print(ctx); break;
                case "/delete": ApiHandlers.Delete(ctx); break;
                case "/list": ApiHandlers.List(ctx); break;
                default: ApiHandlers.Respond(ctx, "INVALID"); break;
            }
        }
    }
}