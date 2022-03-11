using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using WeatherApp.Models;
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

        public bool WeatherLoading
        {
            get => _weatherLoading;
            set
            {
                _weatherLoading = value;
                OnPropertyChanged(nameof(WeatherLoading));
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

        public string CurrentWeatherImage
        {
            get => _currentWeatherImage;
            set
            {
                _currentWeatherImage = value;
                OnPropertyChanged(nameof(CurrentWeatherImage));
            }
        }

        public Visibility WeatherVisibility
        {
            get => _weatherVisibility;
            set
            {
                _weatherVisibility = value;
                OnPropertyChanged(nameof(WeatherVisibility));
            }
        }

        public MainWindowViewModel()
        {
            _weatherService = new WeatherService(new HttpService(), Resources.apiKey);
            _geolocationService = new GeolocationService(new HttpService(), Resources.geolocationApiKey);
            SetDefaults();

            Task.Run(LoadWeatherByGeolocation);
        }

        private void SetDefaults()
        {
            WeatherVisibility = Visibility.Collapsed;
            WeatherLoading = false;
        }

        private async Task LoadWeatherByGeolocation()
        {
            Response response = await _geolocationService.GetGeolocationAsync();
            switch (response)
            {
                case ErrorResponse errorResponse:
                    WeatherVisibility = Visibility.Hidden;
                    break;
                case GeolocationResponse geolocationResponse:
                    _city = geolocationResponse.City;
                    await LoadWeather();
                    break;
            }
        }

        private async Task LoadWeather()
        {
            WeatherLoading = true;
            Response response = await _weatherService.GetWeatherAsync(_city);
            switch (response)
            {
                case ErrorResponse errorResponse:
                    WeatherVisibility = Visibility.Hidden;
                    break;
                case WeatherResponse weatherResponse:
                    await Task.Delay(1000); // Это для того, чтобы анимация не дергалась, если данные приходят сразу
                    KelvinToCeilsConverter kelvinToCeils = new KelvinToCeilsConverter();
                    weatherResponse.Main.TempMax = (float)Math.Round(kelvinToCeils.Convert(weatherResponse.Main.TempMax), 1);
                    weatherResponse.Main.TempMin = (float)Math.Round(kelvinToCeils.Convert(weatherResponse.Main.TempMin), 1);
                    weatherResponse.Main.FeelsLike = (float)Math.Round(kelvinToCeils.Convert(weatherResponse.Main.FeelsLike), 1);
                    weatherResponse.Main.Temp = (float)Math.Round(kelvinToCeils.Convert(weatherResponse.Main.Temp), 1);
                    weatherResponse.Sunset = DateTimeOffset.FromUnixTimeSeconds(weatherResponse.Sys.Sunset).ToString("g");
                    weatherResponse.Sunrise = DateTimeOffset.FromUnixTimeSeconds(weatherResponse.Sys.Sunrise).ToString("g");

                    CurrentWeather = weatherResponse;
                    CurrentWeatherImage = $"/Assets/{CurrentWeather.Weather[0].Main.ToLower()}.png";

                    WeatherVisibility = Visibility.Visible;
                    WeatherLoading = false;
                    break;
            }
        }

        private readonly WeatherService _weatherService;

        private readonly GeolocationService _geolocationService;

        private WeatherResponse _weatherResponse;

        private string _city;

        private string _currentWeatherImage;

        private bool _weatherLoading;

        private Visibility _weatherVisibility;
    }
}
