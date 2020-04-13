﻿using System.ComponentModel.DataAnnotations;

namespace WeatherA.Models
{
    public class Parameters
    {
        [Key]
        public int RolID { get; set; }
        public string CodParam { get; set; }
        public string Value1 { get; set; }
        public string Description { get; set; }
    }
}