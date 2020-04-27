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
        public Data DesSerializar7(string json)
        {
            Data data = new Data();
            data = JsonConvert.DeserializeObject<Data>(json);
            return data;
        }
    }
}