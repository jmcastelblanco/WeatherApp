using System;
using System.Configuration;
using System.Linq;
using WeatherA.Models;
using WeatherA.Models.URLCurrent;

namespace WeatherA.Class
{


    public class DbHelper
    {
        private WeatherAContext dbase = new WeatherAContext();
        readonly string _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private ErrorHelper errorH = new ErrorHelper();
        public static Response Save(WeatherAContext db)
        {
            try
            {
                db.SaveChanges();
                //Hubs.MessagesHub.SendMessages();
                return new Response { Succeeded = true, Message="Guardado Exitoso"};
            }
            catch (Exception ex)
            {
                var respuesta = new Response { Succeeded = false, };
                if (ex.InnerException != null &&
                    ex.InnerException.InnerException != null)
                {
                    if (ex.InnerException.InnerException.Message.Contains("_Index"))
                    {
                        respuesta.Message = "¡Error! el registro ya existe";
                        if (ex.InnerException.InnerException.Message.Contains("Referencia_Index"))
                        {
                            respuesta.Message = "¡Error! código ya existe";
                        }
                        if (ex.InnerException.InnerException.Message.Contains("Name_Index"))
                        {
                            respuesta.Message = "¡Error! el Nombre ya existe";
                        }
                    }
                    if (ex.InnerException.InnerException.Message.Contains("REFERENCE"))
                    {
                        respuesta.Message = "¡Error! no se puede eliminar. Tiene registros relacionados";
                    }

                }
                else
                {
                    respuesta.Message = ex.Message;
                }
                new ManagerException().RegistrarError(new ReporteError { Fecha = DateTime.Now, Error = ex.Message, Traza = ex.ToString(), Origen = "AppWEb", Referencia = "Consulta DB" });

                return respuesta;
            }
        }

        public int saveWeatherSummary(CurrentData currentData)
        {
            WeatherSummary weatherSummary = new WeatherSummary();

            ObservationC obs = currentData.observations.FirstOrDefault();

            weatherSummary.humidity = obs.humidity;
            weatherSummary.temp = obs.uk_hybrid.temp;
            weatherSummary.precipRate = obs.uk_hybrid.precipRate;
            weatherSummary.obsTimeLocal = obs.obsTimeLocal.ToString();
            weatherSummary.neighborhood = obs.neighborhood;
            weatherSummary.stationID = obs.stationID;

            dbase.WeatherSummaries.Add(weatherSummary);
            Response res = new Response();
            res = DbHelper.Save(dbase);
            errorH.AddTrace(res.Message, "Trace", "saveWeatherSummary");
            return weatherSummary.WeatherSummaryID > 0 ? weatherSummary.WeatherSummaryID : 0;
        }
        
        //public void saveWeatherSummary(DailyData dailyData)
        //{
        //    WeatherSummary weatherSummary = new WeatherSummary();
        //    int humidityAvg = 0;
        //    int humidityHigh = 0;
        //    int humidityLow = 0;
        //    int cont = 0;
        //    DateTime date = DateTime.MinValue;
        //    foreach (Observation item in dailyData.observations)
        //    {
        //        humidityAvg = humidityAvg + item.humidityHigh;
        //        humidityHigh = humidityHigh + item.humidityHigh;
        //        humidityLow = humidityLow + item.humidityLow;
        //        date = item.obsTimeUtc;
        //        cont++;
        //    }
        //    weatherSummary.humidityAvg = humidityAvg / cont;
        //    weatherSummary.humidityHigh = humidityHigh / cont;
        //    weatherSummary.humidityLow = humidityLow / cont;
        //    weatherSummary.obsTimeUtc = date;
        //    dbase.WeatherSummaries.Add(weatherSummary);
        //    Response res = new Response();
        //    res = DbHelper.Save(dbase);
        //}

        public string getParamValue(string codParam)
        {
            string param = dbase.Parameters.Where(es => es.CodParam == codParam).FirstOrDefault().Value1;
            return param;
        }

        public static int GetEstado(string descripcion, WeatherAContext db)
        {
            var estado = db.States.Where(e => e.Name == descripcion).FirstOrDefault();
            if (estado == null)
            {
                estado = new State { Name = descripcion, };
                db.States.Add(estado);
                db.SaveChanges();
            }
            return estado.StateID;
        }
    }
}