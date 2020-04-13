using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherA.Models
{
    public class LogErrorTrace
    {
        [Key]
        public int LogErrorID { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public string TypeError { get; set; }
        public DateTime Date { get; set; }
    }
}