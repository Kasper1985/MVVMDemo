using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMDemo
{
    public class MyICommand : ICommand
    {
        Action _TargetEcexuteMethod;
        Func<bool> _TargetCanExecuteMethod;

        // Beware - should use weak references if command instance lifetime is longer than lifetime of UI objects that get hooked up to command
        // Prism commands solve this in their implementation public event
        public event EventHandler CanExecuteChanged = delegate { };

        public MyICommand(Action executeMethod)
        {
            _TargetEcexuteMethod = executeMethod;
        }

        public MyICommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _TargetEcexuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object parameter)
        {
            if (_TargetCanExecuteMethod != null)
                return _TargetCanExecuteMethod();
            if (_TargetEcexuteMethod != null)
                return true;

            return false;
        }

        void ICommand.Execute(object parameter)
        {
            if (_TargetEcexuteMethod != null)
                _TargetEcexuteMethod();
        }
    }
}