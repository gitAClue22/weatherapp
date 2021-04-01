using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
using System.IO;
using WebApplication1.API;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.API
{
    public class WeatherAPI
    {
        public WeatherResponse CurrentWeatherData { get; set; }
        //private DateTime TimeSinceLastUpdate { get; set; }
        private Task WeatherWatcher { get; set; }
        public WeatherAPI()
        {
            CurrentWeatherData = GetWeatherData();
            CurrentWeatherData.LastUpdate = DateTime.Now;
            WeatherWatcher = new Task(() => WatchWeather());
            WeatherWatcher.Start();
        }
        public string City { get; set; }
        public int Zip { get; set; }

        public string GetURI()
        {
            return "https://api.weatherapi.com/v1/forecast.json?key=17c69a1e94dd4635940191216210103&q=32210&days=1&aqi=no&alerts=no";
        }

        protected HttpResponseMessage GET(string URL)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync(URL);
                result.Wait();

                return result.Result;
            }
        }

        public WeatherResponse GetWeatherData()
        {
            var response = GET(GetURI());

            string content = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Deserialize to WeatherResponse
                return JsonConvert.DeserializeObject<WeatherResponse>(content);
            } else
            {
                return null;
            }

        }

        public void WatchWeather()
        {
            while (true)
            {
                CurrentWeatherData = GetWeatherData();
                CurrentWeatherData.LastUpdate = DateTime.Now;
                Thread.Sleep(30000);
            }
        }

    }
}
