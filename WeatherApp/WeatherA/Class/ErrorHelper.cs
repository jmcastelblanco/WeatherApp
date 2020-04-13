using System;
using System.Collections.Generic;
using System.Linq;
using WeatherA.Models;
using System.Web;

namespace WeatherA.Class
{
    public class ErrorHelper
    {
        private WeatherAContext db = new WeatherAContext();

        public void AddTrace(string message, string typeError, string source)
        {
            LogErrorTrace trace = new LogErrorTrace()
            {
                Message = message,
                TypeError = typeError,
                Source = source,
                Date = DateTime.Now
            };
            db.LogsError.Add(trace);
            db.SaveChanges();
        }
    }
}