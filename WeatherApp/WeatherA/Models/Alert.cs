using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherA.Models
{
    public class Alert
    {
        [Key]
        public int AlertID { get; set; }

        public int AlertTypeID { get; set; }
        public string StationID { get; set; }
        public DateTime date { get; set; }
        public int WeatherSummaryID { get; set; }
        public int StateID { get; set; }
        public virtual AlertType AlertType { get; set; }
        public virtual State State { get; set; }

    }
}