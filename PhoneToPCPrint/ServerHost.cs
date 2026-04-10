using System;
using System.IO;

namespace PhoneToPCPrint
{
    public class ServerHost
    {
        private HttpServer _server;

        public void Start()
        {
            ConfigManager.Load();
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            Logger.Init();

            _server = new HttpServer();
            _server.Start();

            QueueManager.Start();
        }

        public void Stop()
        {
            _server?.Stop();
            QueueManager.Stop();
        }
    }
}