using System;
using System.IO;
using System.Net;

namespace WeatherA.Class
{
    public class Consume
    {
        private DbHelper db = new DbHelper();

        public string DownloadData(string url)
        {
            string html = string.Empty;
            string date = DateTime.Now.AddDays(-1).ToString("yyyyMMdd");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            return html;
        }

        public string getParamValue(string codParam)
        {
            string url = db.getParamValue(codParam);
            return url;
        }
    }
}