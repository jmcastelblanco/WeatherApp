using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherA.Models.URLCurrent;

namespace WeatherA.Models.URLCurrent
{
    public class ObservationC
    {
        public string stationID { get; set; }
        public DateTime obsTimeUtc { get; set; }
        public DateTime obsTimeLocal { get; set; }
        public string neighborhood { get; set; }
        public string softwareType { get; set; }
        public string country { get; set; }
        public object solarRadiation { get; set; }
        public double lon { get; set; }
        public object realtimeFrequency { get; set; }
        public int epoch { get; set; }
        public double lat { get; set; }
        public object uv { get; set; }
        public object winddir { get; set; }
        public int humidity { get; set; }
        public int qcStatus { get; set; }
        public UkHybrid uk_hybrid { get; set; }
    }
}