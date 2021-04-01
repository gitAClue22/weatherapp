using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class CurrentResponse
    {
        public DateTime Last_Updated { get; set; }

        public decimal Temp_F { get; set; }

        public ConditionResponse Condition { get; set; }

        public decimal Wind_Mph { get; set; }

        public decimal Pressure_Mb { get; set; }

        public decimal Feelslike_F { get; set; }

        public float Vis_Miles { get; set; }

        public decimal Uv { get; set; }
    }
}
