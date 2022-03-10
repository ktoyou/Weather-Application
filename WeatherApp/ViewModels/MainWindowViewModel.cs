using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Models.Responses;
using WeatherApp.Properties;
using WeatherApp.Services;
using WeatherApp.ViewModels.Commands;

namespace WeatherApp.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public ICommand GetWeatherCommand { get => new AsyncCommand(LoadWeather); }

        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        public WeatherResponse CurrentWeather
        {
            get => _weatherResponse;
            set
            {
                _weatherResponse = value;
                OnPropertyChanged(nameof(CurrentWeather));
            }
        }

        public MainWindowViewModel()
        {
            _weatherService = new WeatherService(new HttpService(), Resources.apiKey);
        }

        private async Task LoadWeather()
        {
            Response response = await _weatherService.GetWeatherAsync(City);
            switch (response)
            {
                case ErrorResponse errorResponse:
                    break;
                case WeatherResponse weatherResponse: CurrentWeather = weatherResponse; break;
            }
        }

        private readonly WeatherService _weatherService;

        private WeatherResponse _weatherResponse;

        private string _city;
    }
}
