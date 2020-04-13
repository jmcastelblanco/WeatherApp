using System;
using System.ServiceProcess;

namespace Weather.Service
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            if (Environment.UserInteractive)
            {
                new WeatherServices().DonwloadData(1);
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new WeatherServices()
                };

                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
