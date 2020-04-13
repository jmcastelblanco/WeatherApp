using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherA.Models
{
    public class AlertType
    {
        [Key]
        public int AlertTypeID { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Alert> Alerts { get; set; }
    }
}