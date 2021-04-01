using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class WeatherResponse
    {


        public LocationResponse Location { get; set; }

        public CurrentResponse Current { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}
