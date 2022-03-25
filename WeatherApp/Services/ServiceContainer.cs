using Microsoft.Extensions.DependencyInjection;
using System;
using WeatherApp.Properties;
using WeatherApp.ViewModels;

namespace WeatherApp.Services
{
    internal static class ServiceContainer
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        static ServiceContainer()
        {
            ServiceCollection collection = new ServiceCollection();

            collection.AddSingleton<MainWindowViewModel>();
            collection.AddSingleton(new GeolocationService(new HttpService(), Resources.geolocationApiKey));
            collection.AddSingleton(new WeatherService(new HttpService(), Resources.apiKey));

            ServiceProvider = collection.BuildServiceProvider();
        }
    }
}
