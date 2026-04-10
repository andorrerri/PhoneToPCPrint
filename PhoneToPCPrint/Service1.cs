using System.ServiceProcess;

namespace PhoneToPCPrint
{
    public partial class Service1 : ServiceBase
    {
        private ServerHost _host;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _host = new ServerHost();
            _host.Start();
        }

        protected override void OnStop()
        {
            _host?.Stop();
        }
    }
}