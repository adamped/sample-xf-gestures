using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mobile
{
    /// <summary>
    /// Quick and dirty command
    /// </summary>
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        Action<object> _action = null;

        public Command(Action<object> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
