using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.ViewModels.Commands
{
    internal class AsyncCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public AsyncCommand(Func<Task> func)
        {
            _func = func;
        }

        public bool CanExecute(object parameter) => true;

        public async void Execute(object parameter) => await _func.Invoke();

        private Func<Task> _func;
    }
}
