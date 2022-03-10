using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApp.Services
{
    internal class HttpService : IHttpAsync
    {
        public async Task<byte[]> GetAsync(string url)
        {
            HttpClient client = new HttpClient();
            return await (await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, url))).Content.ReadAsByteArrayAsync();
        }
    }
}
