using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeatherA.Class;
using WeatherA.Models;
using WeatherServices;
using Newtonsoft.Json;
using Twilio.AspNet.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace WeatherA.Controllers
{
    public class WeatherSummariesController : Controller
    {
        private WeatherAContext db = new WeatherAContext();
        

        // GET: WeatherSummaries
        public ActionResult Index()
        {
            
            return View(db.WeatherSummaries.FirstOrDefault());
        }
        public ActionResult History()
        {
            string result = string.Empty;
            string URL = "https://api.weather.com/v2/pws/dailysummary/7day?stationId=ISANJU36&format=json&units=e&apiKey=be06c9df19a94dd986c9df19a92dd9ea";
            Data data = new Data();
            Consume consume = new Consume();
            Serialization serialization = new Serialization();
            result = consume.DownloadData(URL);
            data = serialization.DesSerializar7(result);
            ViewBag.Hum1 = data.summaries[0].humidityAvg;
            ViewBag.Hum2 = data.summaries[1].humidityAvg;
            ViewBag.Hum3 = data.summaries[2].humidityAvg;
            ViewBag.Hum4 = data.summaries[3].humidityAvg;
            ViewBag.Hum5 = data.summaries[4].humidityAvg;
            ViewBag.Hum6 = data.summaries[5].humidityAvg;
            ViewBag.Hum7 = data.summaries[6].humidityAvg;
            ViewBag.Tem1 = data.summaries[0].imperial.tempAvg;
            ViewBag.Tem2 = data.summaries[1].imperial.tempAvg;
            ViewBag.Tem3 = data.summaries[2].imperial.tempAvg;
            ViewBag.Tem4 = data.summaries[3].imperial.tempAvg;
            ViewBag.Tem5 = data.summaries[4].imperial.tempAvg;
            ViewBag.Tem6 = data.summaries[5].imperial.tempAvg;
            ViewBag.Tem7 = data.summaries[6].imperial.tempAvg;
            ViewBag.Pre1 = 0;
            ViewBag.Pre2 = 0;
            ViewBag.Pre3 = 0;
            ViewBag.Pre4 = 0;
            ViewBag.Pre5 = 0;
            ViewBag.Pre6 = 0;
            ViewBag.Pre7 = 0;

            if (data.summaries[0].imperial.precipRate != null)
            {
                ViewBag.Pre1 = (float)data.summaries[0].imperial.precipRate * 100;
            }
            if (data.summaries[1].imperial.precipRate != null)
            {
                ViewBag.Pre2 = (float)data.summaries[1].imperial.precipRate * 100;
            }
            if (data.summaries[2].imperial.precipRate != null)
            {
                ViewBag.Pre3 = (float)data.summaries[2].imperial.precipRate * 100;
            }
            if (data.summaries[3].imperial.precipRate != null)
            {
                ViewBag.Pre4 = (float)data.summaries[3].imperial.precipRate * 100;
            }
            if (data.summaries[4].imperial.precipRate != null)
            {
                ViewBag.Pre5 = (float)data.summaries[4].imperial.precipRate * 100;
            }
            if (data.summaries[5].imperial.precipRate != null)
            {
                ViewBag.Pre6 = (float)data.summaries[5].imperial.precipRate * 100;
            }
            if (data.summaries[6].imperial.precipRate != null)
            {
                ViewBag.Pre7 = (float)data.summaries[6].imperial.precipRate * 100;
            }
            
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
