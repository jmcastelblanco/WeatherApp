using System;
using WeatherA.Class;
using WeatherA.Models;
using WeatherA.Models.URLCurrent;
using WeatherServices;

namespace Weather.Service
{
    internal class WeatherDownload
    {
        private Consume consume = new Consume();
        private Serialization serialization = new Serialization();
        private DbHelper db = new DbHelper();
        private AlertsHelper alertH = new AlertsHelper();
        private ErrorHelper errorH = new ErrorHelper();

        public void ProcesarDescarga()
        {
            //errorH.AddTrace("message","typeError","source");
            string url = BuildCurrentDATAURL();
            errorH.AddTrace("DownloadData", "Trace", "ServicioWindows");
            string res = consume.DownloadData(url);
            errorH.AddTrace("serialization", "Trace", "ServicioWindows");
            CurrentData CurrentData = serialization.DesSerializar(res);
            errorH.AddTrace("SaveWeatherSummary", "Trace", "ServicioWindows");
            int id = db.saveWeatherSummary(CurrentData);
            if (id > 0)
            {
                errorH.AddTrace("VerifyAlert", "Trace", "ServicioWindows");
                alertH.VerifyAlert(CurrentData,id);
            }
            errorH.AddTrace("ExitDownloadData", "Trace", "ServicioWindows");

        }

        private string BuildCurrentDATAURL()
        {
            //"https://api.weather.com/v2/pws/observations/current?stationId=ISANJU36&format=json&units=e&apiKey=be06c9df19a94dd986c9df19a92dd9ea"
            string URL = string.Empty;
            string url = "https://api.weather.com/v2/pws/observations/current?stationId=";
            string StationID = this.GetParamValue("StationID");
            string Units = this.GetParamValue("Units");
            string APIKey = this.GetParamValue("APIKey");
            URL = url + StationID + "&format=json&units=" + Units + "&apiKey=" + APIKey;
            return URL;
        }

        public string GetParamValue(string codParam)
        {
            string param = db.getParamValue(codParam);
            return param;
        }
    }

}
