using Newtonsoft.Json;
using WeatherA.Models;
using WeatherA.Models.URLCurrent;

namespace WeatherServices
{
    public class Serialization
    {
        public CurrentData DesSerializar(string json)
        {
            CurrentData data = new CurrentData();
            data = JsonConvert.DeserializeObject<CurrentData>(json);
            return data;
        }
    }
}