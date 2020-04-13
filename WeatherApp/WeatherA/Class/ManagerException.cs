using WeatherA.Models;

namespace WeatherA.Class
{
    public class ManagerException
    {
        private ErrorHelper ErrorH = new ErrorHelper();
        public void RegistrarError(ReporteError reporteError)
        {
            string a = reporteError.Error;
            ErrorH.AddTrace(a,"Error","_ManagerExeption");
        }
    }
}