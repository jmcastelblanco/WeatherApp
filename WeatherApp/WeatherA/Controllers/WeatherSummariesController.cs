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
            ViewBag.Pre1 = data.summaries[0].imperial.precipRate;
            ViewBag.Pre2 = data.summaries[1].imperial.precipRate;
            ViewBag.Pre3 = data.summaries[2].imperial.precipRate;
            ViewBag.Pre4 = data.summaries[3].imperial.precipRate;
            ViewBag.Pre5 = data.summaries[4].imperial.precipRate;
            ViewBag.Pre6 = data.summaries[5].imperial.precipRate;
            ViewBag.Pre7 = data.summaries[6].imperial.precipRate;
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
