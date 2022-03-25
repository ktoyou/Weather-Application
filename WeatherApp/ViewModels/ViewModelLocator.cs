using Microsoft.Extensions.DependencyInjection;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
    internal class ViewModelLocator
    {
        private static ViewModelLocator Instance { get; set; } = new ViewModelLocator();

        public MainWindowViewModel MainWindowViewModel { get; set; } = ServiceContainer.ServiceProvider.GetService<MainWindowViewModel>();
    }
}
