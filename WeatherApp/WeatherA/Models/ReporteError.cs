﻿using System;

namespace WeatherA.Models
{
    public class ReporteError
    {
        public DateTime Fecha { get; set; }
        public string Error { get; set; }
        public string Traza { get; set; }
        public string Origen { get; set; }
        public string Referencia { get; set; }
    }
}