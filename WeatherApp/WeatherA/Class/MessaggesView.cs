using System;

namespace WeatherA.Class
{
    public class MessagesView
    {
        public string StationID { get; set; }
        public int WeatherSummaryID { get; set; }
        public int StateID { get; set; }
        public int AlertTypeID { get; set; }
        public DateTime Date { get; set; }
    }
}