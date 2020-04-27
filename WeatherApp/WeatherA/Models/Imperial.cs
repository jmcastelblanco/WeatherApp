namespace WeatherA.Models
{
    public class Imperial
    {
        public int tempHigh { get; set; }
        public int tempLow { get; set; }
        public int tempAvg { get; set; }
        public object windspeedHigh { get; set; }
        public object windspeedLow { get; set; }
        public object windspeedAvg { get; set; }
        public object windgustHigh { get; set; }
        public object windgustLow { get; set; }
        public object windgustAvg { get; set; }
        public int dewptHigh { get; set; }
        public int dewptLow { get; set; }
        public int dewptAvg { get; set; }
        public object windchillHigh { get; set; }
        public object windchillLow { get; set; }
        public object windchillAvg { get; set; }
        public int heatindexHigh { get; set; }
        public int heatindexLow { get; set; }
        public int heatindexAvg { get; set; }
        public object pressureMax { get; set; }
        public object pressureMin { get; set; }
        public object pressureTrend { get; set; }
        public double precipRate { get; set; }
        public double precipTotal { get; set; }
    }

}