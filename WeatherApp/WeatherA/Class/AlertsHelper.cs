using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WeatherA.Models;
using WeatherA.Models.URLCurrent;

namespace WeatherA.Class
{
    public class AlertsHelper
    {
        private WeatherAContext db = new WeatherAContext();
        private DbHelper dbH = new DbHelper();
        readonly string _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<MessagesView> GetAllMessages()
        {
            var messagesView = new List<MessagesView>();
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                using (var command = new SqlCommand(@"SELECT obsTimeLocal,humidity,temp,precipRate FROM [dbo].[WeatherSummaries]", connection))

                {
                    command.Notification = null;
                    var dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        messagesView.Add(item: new MessagesView
                        {
                            obsTimeUtc = reader["obsTimeLocal"].ToString(),
                            humidityAvg = Int32.Parse(reader["humidity"].ToString()),
                            humidityHigh = Int32.Parse(reader["temp"].ToString()),
                            humidityLow = Int32.Parse(reader["precipRate"].ToString()),
                        });
                    }
                }
            }
            var newList = messagesView.OrderByDescending(c => c.obsTimeUtc).ToList();
            return newList;
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            //if (e.Type == SqlNotificationType.Change)
            //{
            //    Hubs.MessagesHub.SendMessages();
            //}

            SqlDependency dependency =
             (SqlDependency)sender;
            dependency.OnChange -= dependency_OnChange;
            Hubs.MessagesHub.SendMessages(); //re-regist
        }
    
        public Alert VerifyAlert(CurrentData current,int id)
        {
            bool flatT = false;
            bool flatH = false;
            bool flatP = false;

            Alert alert = null;

            double temp = current.observations.FirstOrDefault().uk_hybrid.temp;
            double precipRate = current.observations.FirstOrDefault().uk_hybrid.precipRate;
            int humidity = current.observations.FirstOrDefault().humidity;
            int humidityMax = Int32.Parse(dbH.getParamValue("humidityMax"));
            int humidityMin = Int32.Parse(dbH.getParamValue("humidityMin"));
            double precipMax = Double.Parse(dbH.getParamValue("precipMax"));
            double precipMin = Double.Parse(dbH.getParamValue("precipMin"));
            double tempMax = Double.Parse(dbH.getParamValue("tempMax"));
            double tempMin = Double.Parse(dbH.getParamValue("tempMin"));

            if (temp > tempMin && temp < tempMin)
            {
                flatT = true;
            }
            if (precipRate > precipMin && precipRate < precipMin)
            {
                flatP = true;
            }
            if (humidity > humidityMin && humidity < humidityMin)
            {
                flatH = true;
            }
            if (flatH && flatP && flatT)
            {
                alert = new Alert
                {
                    AlertTypeID = 1,
                    StationID = current.observations.FirstOrDefault().stationID,
                    date = DateTime.Now,
                    WeatherSummaryID = id,
                    StateID = 1,
                };
                db.Alerts.Add(alert);
                DbHelper.Save(db);
            }
            return alert;
        }
    }
}