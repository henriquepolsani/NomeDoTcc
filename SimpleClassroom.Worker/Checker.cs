using System.ServiceProcess;

namespace SimpleClassroom.Worker
{
    public partial class Checker : ServiceBase
    {
        public Checker()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
