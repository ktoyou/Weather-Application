using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    internal class KelvinToCeilsConverter : ITemperatureConverter
    {
        public float Convert(float value) => value - 273;
    }
}
