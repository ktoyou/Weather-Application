using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Services
{
    internal interface IHttpAsync
    {
        Task<byte[]> GetAsync(string url);
    }
}
