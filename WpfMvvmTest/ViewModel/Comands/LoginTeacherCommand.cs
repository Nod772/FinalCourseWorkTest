using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfMvvmTest.ViewModel.Comands
{
    public class LoginTeacherCommand : ICommand
    {
        TeacherVM VM { get; set; }
        public event EventHandler CanExecuteChanged
        {

            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;

            }
        }

        public LoginTeacherCommand(TeacherVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return String.IsNullOrEmpty(parameter as string);

        }

        public void Execute(object parameter)
        {
            VM.Logins(parameter as string);
        }
    }
}
