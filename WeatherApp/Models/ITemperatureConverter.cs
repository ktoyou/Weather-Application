using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    internal interface ITemperatureConverter
    {
        float Convert(float value);
    }
}
