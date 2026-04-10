using System;
using System.ServiceProcess;

namespace PhoneToPCPrint
{
    static class Program
    {
        static void Main()
        {
#if DEBUG
            var server = new ServerHost();
            server.Start();
            Console.WriteLine("Server running... Press ENTER to stop.");
            Console.ReadLine();
            server.Stop();
#else
            ServiceBase.Run(new Service1());
#endif
        }
    }
}