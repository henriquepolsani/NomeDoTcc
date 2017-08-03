using System.ServiceProcess;

namespace SimpleClassroom.Worker
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Importer(),
                new Checker()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
