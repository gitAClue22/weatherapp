using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Data;
using WebApplication1.API;

namespace WebApplication1.Controllers
{
    public class WeatherController : Controller
    {
        private readonly ApplicationDBContext _context;
        //private readonly WeatherAPI _api;
        public WeatherController(ApplicationDBContext context, WeatherAPI api)
        {
            _context = context;
            //_api = api;
        }
        public IActionResult Widget()
        {
            //WeatherResponse data = _api.CurrentWeatherData;
            //return View(data);
            return View();
        }

        [HttpPost]
        public IActionResult PostWeather(WeatherResponse weatherdata)
        {
            Console.WriteLine("Received data");
            return RedirectToAction("Widget", weatherdata);
        }

        public IActionResult TestData()
        {

            WeatherAPI api = new WeatherAPI();

            Task<WeatherResponse> apitask = Task.Factory.StartNew(() => api.GetWeatherData());
            apitask.Wait();

            WeatherResponse weatherdata = apitask.Result;
            
            return RedirectToAction("Widget", weatherdata);
        }
    }
}
