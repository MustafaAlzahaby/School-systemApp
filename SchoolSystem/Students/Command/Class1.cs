using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project_Teacher.Command
{
    public class MyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public Action<object> _Excute { get; set; }
        public Predicate<object> _CanExcute { get; set; }

        public MyCommand(Action<object> _excute, Predicate<object> _canExcute)
        {
            this._Excute = _excute;
            this._CanExcute = _canExcute;
        }

        public bool CanExecute(object parameter)
        {
            return _CanExcute(parameter);
        }

        public void Execute(object parameter)
        {
            _Excute(parameter);
        }
    }
}