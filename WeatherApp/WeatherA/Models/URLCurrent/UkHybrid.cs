using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherA.Models.URLCurrent
{
    public class UkHybrid
    {
        public double? temp { get; set; }
        public int heatIndex { get; set; }
        public int dewpt { get; set; }
        public object windChill { get; set; }
        public object windSpeed { get; set; }
        public object windGust { get; set; }
        public double? pressure { get; set; }
        public double? precipRate { get; set; }
        public double? precipTotal { get; set; }
        public int elev { get; set; }
    }
}