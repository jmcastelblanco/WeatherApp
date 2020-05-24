using System;
using System.ComponentModel.DataAnnotations;

namespace WeatherA.Models
{
    public class WeatherSummary
    {
        [Key]
        public int WeatherSummaryID { get; set; }
        public int humidity { get; set; }
        public double? temp  { get; set; }
        public double? precipRate  { get; set; }
        public string obsTimeLocal { get; set; }
        public string neighborhood  { get; set; }
        public string stationID  { get; set; }
    }
}